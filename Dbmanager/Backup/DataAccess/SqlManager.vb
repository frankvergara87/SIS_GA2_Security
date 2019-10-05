Imports System.Data.SqlClient
Imports System.Data
Imports Microsoft.VisualBasic 
Imports System.Data.common

Namespace DataObjects

    Public Class SqlManager
        Implements IDisposable

        'Variable que establece la cadena de conexion
        Dim BaseDatos As String
        'variable que indica si es encriptada
        Dim _isCrypted As Boolean = False
        'Cadena de Conexion establecida por el usuario
        Dim CadenaConexion As String = ""
        'Variable que establece el tipo de control de transacción
        Dim TipoControlTransaccion As TransactionType = TransactionType.Automatic
        'Objeto que Obtiene la conexión para todas las transacciones
        'siempre y cuando sea del tipo de control de transacción manual
        Dim objGlobalConnection As SqlConnection
        'Objeto que Establece el punto de control de transacción global
        'para todas las transacciones
        Dim objGlobalTransaction As SqlTransaction
        'Variable que establece el tiempo de respuesta (Por defecto 60 está a segundos)
        Dim TiempoRespuesta As Integer = 1200
        'Objeto Conexion Unico por toda la Clase
        Dim objConneccion As SqlConnection
        'Objeto que retendra la coleccion de los ultimos parametros utilizados en un stored procedure
        Dim ObjParameterCollection As New Hashtable

        ''' <summary>
        ''' Clase que facilita el acceso a datos para iSeries DB2 AS400.
        ''' Posee 5 Funciones y 2 Procedimientos, cada uno con sobrecarga de parametros.
        ''' Indique la llave o clave del archivo de configuracion app.config
        ''' </summary>

        Sub New(ByVal ConfigKey As String)
            CadenaConexion = ConfigKey
        End Sub


        Sub New(ByVal ConfigKey As String, ByVal EncryptedString As Boolean)
            CadenaConexion = ConfigKey
            Me._isCrypted = True
        End Sub
        ''' <summary>
        ''' Clase que facilita el acceso a datos para iSeries DB2 AS400.
        ''' Posee 5 Funciones y 2 Procedimientos, cada uno con sobrecarga de parametros.
        ''' Este tipo de inicialización leerá el archivo de configuracion
        ''' </summary>

        Sub New()
            'Default config (por defecto, infomado en la documentación)
            If HelpClass.getSetting("ConnectionMode") <> "WebService" Then
                BaseDatos = "DataBase"
                TiempoRespuesta = CInt(HelpClass.getSetting("timeout"))
            End If 
        End Sub
 

        ''' <summary>
        '''  Propiedad que establece el tipo de control de transacción.
        ''' Puede ser: Automatica ->El Procedimiento se encarga de establecer el Begin, commit o rollback  .
        '' 	Manual -> el programador tiene que establecer el begin, Commit y RollBack de toda la conexion.
        ''' </summary>

        Public Sub TransactionController(ByVal Value As TransactionType)
            TipoControlTransaccion = Value
        End Sub

        Public Property Transaction_Controller() As TransactionType
            Get
                Return TipoControlTransaccion
            End Get
            Set(ByVal value As TransactionType)
                TipoControlTransaccion = value
            End Set
        End Property

        Public ReadOnly Property ParameterCollection() As Hashtable
            Get
                'Procedimiento que lista la coleccion de parametros del stored procedures
                Return ObjParameterCollection
            End Get
        End Property

        ''' <summary>
        '''  Procedimiento que Inicia el control de transacción e instancia la conexion al servidor
        ''' </summary>

        Public Sub BeginGlobalTransaction()
            Try
                Me.objGlobalConnection = New SqlConnection("")
                objGlobalConnection.Open()
                Me.objGlobalTransaction = Me.objGlobalConnection.BeginTransaction(IsolationLevel.Chaos)

            Catch ex As Exception
                Throw New Exception(ex.ToString())
            End Try
        End Sub

        ''' <summary>
        '''  Procedimiento que Confirma el control de transacción y cierra la conexion
        ''' </summary>

        Public Sub CommitGlobalTransaction()
            Try
                Me.objGlobalTransaction.Commit()
                Me.objGlobalConnection.Close()
                objGlobalConnection.Dispose()

            Catch ex As Exception
                Throw New Exception(ex.ToString())
            End Try
        End Sub

        ''' <summary>
        '''  Procedimiento que Restaura el control de transacción y cierra la conexion
        ''' </summary>

        Public Sub RollBackGlobalTransaction()
            Try
                Me.objGlobalTransaction.Rollback()
                Me.objGlobalConnection.Close()
            Catch ex As Exception
                Throw New Exception(ex.ToString())
            End Try
        End Sub

        ''' <summary>
        '''  Función que devuelve un DataSet en base a un stored procedure [StoredPocedure param] y
        '''  un objeto (tipo colección) de parametros
        ''' </summary>

        Public Function ExecuteDataSet(ByVal StoreProcedure As String, ByVal sqlparams As Parameter) As DataSet

            Dim objData As New DataSet
            Dim objTransaction As SqlTransaction

            Try

                Using cnx As New SqlConnection(Me.Conectar())
                  
                    Dim cmdAdaptador As SqlDataAdapter
                    Dim cmd As New SqlCommand

                    cmd.Connection = cnx
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.CommandText = StoreProcedure
                    cmd.CommandTimeout = Me.TiempoRespuesta

                    Dim i As Integer
                    Dim SqlParametro As SqlParameter

                    If Not (sqlparams Is Nothing) Then
                        For i = 1 To sqlparams.Count
                            ' SqlParametro = CType(sqlparams.Item(i), SqlParameter)
                            cmd.Parameters.Add(CType(sqlparams.Item(i), SqlParameter))
                        Next
                    End If

                    'Verificando el tipo de control de transacción

                        cnx.Open()
                 
                    cmdAdaptador = New SqlDataAdapter(cmd)
                    cmdAdaptador.Fill(objData)
                    fillParameterCollection(cmd.Parameters)

                     cnx.Close()
                     cmd.Dispose()
                    SqlParametro = Nothing
                    cmd = Nothing
                End Using

            Catch ex As Exception
                 HelpClass.LogThis(ex.ToString)
                Throw New Exception(ex.ToString())
            End Try

            objTransaction = Nothing
            Return objData

        End Function

        ''' <summary>
        '''  Función que devuelve un DataSet en base a una cadena SQL
        ''' </summary>

        Public Function ExecuteDataSet(ByVal Query As String) As DataSet

            Dim objData As New DataSet
            Dim objTransaction As SqlTransaction

            Try

                Using cnx As New SqlConnection(Me.Conectar())
                  
                    Dim cmdAdaptador As SqlDataAdapter
                    Dim cmd As New SqlCommand

                    cmd.Connection = cnx
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = Query
                    cmd.CommandTimeout = Me.TiempoRespuesta

                         cnx.Open()
               
                    cmdAdaptador = New SqlDataAdapter(cmd)

                    cmdAdaptador.Fill(objData)
           cnx.Close() 
                    cmd.Dispose()
                    cmd = Nothing
                End Using

            Catch ex As Exception
                HelpClass.LogThis(ex.ToString)
                Throw New Exception(ex.ToString())
            End Try

            objTransaction = Nothing
            Return objData

        End Function

        ''' <summary>
        '''  Procedimiento que ejecuta una instrucción SQL en base a un stored procedure [StoredPocedure param] y
        '''  un objeto (tipo colección) de parametros
        ''' </summary>

        Public Sub ExecuteNonQuery(ByVal StoreProcedure As String, ByVal sqlparams As Parameter)

            If HelpClass.getSetting("ConnectionMode") = "WebService" Then
                Me.executeStatementWebService(StoreProcedure, sqlparams)
                Exit Sub
            End If


            Dim objResultado As String = ""
            Dim objTransaction As SqlTransaction

            Try
                'Obteniendo una conexion a la base de datos

                Using cnx As New SqlConnection(Me.Conectar())
                    
                    Dim cmd As New SqlCommand
                    cmd.Connection = cnx
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.CommandText = StoreProcedure
                    cmd.CommandTimeout = Me.TiempoRespuesta

                    Dim i As Integer
                    Dim SqlParametro As SqlParameter
                    Dim s As String = ""
                    If Not (sqlparams Is Nothing) Then
                        For i = 1 To sqlparams.Count
                            'SqlParametro = CType(sqlparams.Item(i), SqlParameter)
                            'cmd.Parameters.Add(SqlParametro.ParameterName, SqlParametro.Value)
                            cmd.Parameters.Add(CType(sqlparams.Item(i), SqlParameter))
                            s = s & "'" & sqlparams.Item(i).Value & "',"
                        Next
                    End If
 
                    cnx.Open() 
 
                    cmd.ExecuteNonQuery()
                    fillParameterCollection(cmd.Parameters)
   
                    cnx.Close()
                    cmd.Dispose()
                    SqlParametro = Nothing
                    cmd = Nothing 

                End Using

            Catch ex As Exception 
                HelpClass.LogThis(ex.ToString)
                Throw New Exception(ex.ToString())
            End Try

            objTransaction = Nothing

        End Sub

        ''' <summary>
        '''  Procedimiento que ejecuta una instrucción SQL en base a un stored procedure [StoredPocedure param] y
        '''  un objeto (tipo colección) de parametros
        ''' </summary>

        Public Sub ExecuteNonQuery(ByVal Query As String)

            Dim objResultado As String = "" 

            Try
                'Obteniendo una conexion a la base de datos

                Using cnx As New SqlConnection(Me.Conectar())
                      
                    Dim cmd As New SqlCommand
                    cmd.Connection = cnx
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = Query
                    cmd.CommandTimeout = Me.TiempoRespuesta
 
                    cnx.Open()

                    cmd.ExecuteNonQuery()
  
                    cnx.Close()
                    cmd.Dispose()
                    cmd = Nothing 

                End Using

            Catch ex As Exception 
                HelpClass.LogThis(ex.ToString)
                Throw New Exception(ex.ToString())
            End Try
 
        End Sub

        ''' <summary>
        '''  Función que puede devolver (opcional) un objeto, (confirmación de operación)
        '''  en base a un stored procedure [StoredPocedure param] y
        '''  un objeto (tipo colección) de parametros
        ''' </summary>

        Public Function ExecuteNoQuery(ByVal StoreProcedure As String, ByVal sqlparams As Parameter) As String

            If HelpClass.getSetting("ConnectionMode") = "WebService" Then
                Return Me.executeStatementWebService(StoreProcedure, sqlparams)
            End If

            Dim objResultado As String = ""
            Dim objTransaction As SqlTransaction
            Try
                'Obteniendo una conexion a la base de datos

                Using cnx As New SqlConnection(Me.Conectar())
                      
                    Dim cmd As New SqlCommand
                    cmd.Connection = cnx
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.CommandText = StoreProcedure
                    cmd.CommandTimeout = Me.TiempoRespuesta

                    Dim i As Integer
                    Dim SqlParametro As SqlParameter

                    If Not (sqlparams Is Nothing) Then
                        For i = 1 To sqlparams.Count
                            'SqlParametro = CType(sqlparams.Item(i), SqlParameter)
                            cmd.Parameters.Add(CType(sqlparams.Item(i), SqlParameter))
                        Next
                    End If

                    cnx.Open()
                    
                    objResultado = cmd.ExecuteScalar()
                    fillParameterCollection(cmd.Parameters)

                         cnx.Close()
                    cmd.Dispose()
                    SqlParametro = Nothing
                    cmd = Nothing
                End Using


            Catch ex As Exception
                 HelpClass.LogThis(ex.ToString)
                Throw New Exception(ex.ToString())
            End Try

            objTransaction = Nothing
            Return objResultado

        End Function

        ''' <summary>
        '''  Función que puede devolver (opcional) un objeto, (confirmación de operación)
        '''  en base a una instrucción SQL
        ''' </summary>

        Public Function ExecuteNoQuery(ByVal Query As String) As String
            Dim objResultado As String = ""
            Dim objTransaction As SqlTransaction
            Try
                'Obteniendo una conexion a la base de datos

                Using cnx As New SqlConnection(Me.Conectar())
                     
                    Dim cmd As New SqlCommand
                    cmd.Connection = cnx
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = Query
                    cmd.CommandTimeout = Me.TiempoRespuesta

                    If Me.TipoControlTransaccion = TransactionType.Automatic Then
                        cnx.Open()
                        objTransaction = cnx.BeginTransaction(IsolationLevel.RepeatableRead)
                        cmd.Transaction = objTransaction
                    Else
                        cmd.Transaction = Me.objGlobalTransaction
                    End If

                    objResultado = cmd.ExecuteScalar()
                    fillParameterCollection(cmd.Parameters)

                     cnx.Close()
                    cmd.Dispose()
                    cmd = Nothing
                End Using

            Catch ex As Exception
                HelpClass.LogThis(ex.ToString)
                Throw New Exception(ex.ToString())

            End Try
            objTransaction = Nothing
            Return objResultado

        End Function
  
        ''' <summary>
        '''  Función que devuelve un único resultado 
        '''  en base a un stored procedure [StoredPocedure param] y
        '''  un objeto (tipo colección) de parametros
        ''' </summary>

        Public Function ExecuteScalar(ByVal StoreProcedure As String, ByVal sqlparams As Parameter) As String
            Dim objResultado As String = ""
            If HelpClass.getSetting("ConnectionMode") = "WebService" Then
                Return Me.getDataWebService(StoreProcedure, sqlparams).Rows(0).Item(0).ToString()
            End If
            Dim objTransaction As SqlTransaction
            Try
                'Obteniendo una conexion a la base de datos

                Using cnx As New SqlConnection(Me.Conectar())
                     
                    Dim cmd As New SqlCommand
                    cmd.Connection = cnx
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.CommandText = StoreProcedure
                    cmd.CommandTimeout = Me.TiempoRespuesta

                    Dim i As Integer
                    Dim SqlParametro As SqlParameter

                    If Not (sqlparams Is Nothing) Then
                        For i = 1 To sqlparams.Count
                            ' SqlParametro = CType(sqlparams.Item(i), SqlParameter)
                            cmd.Parameters.Add(CType(sqlparams.Item(i), SqlParameter))
                        Next
                    End If

                          cnx.Open()
                
                    objResultado = cmd.ExecuteScalar().ToString()
                    fillParameterCollection(cmd.Parameters)

                           cnx.Close() 
                    cmd.Dispose()
                    SqlParametro = Nothing
                    cmd = Nothing
                End Using

            Catch ex As Exception
                 HelpClass.LogThis(ex.ToString)
                Throw New Exception(ex.ToString())
            End Try

            objTransaction = Nothing
            Return objResultado
        End Function

        ''' <summary>
        '''  Función que devuelve un único resultado 
        '''  en base a una instucción SQL
        ''' </summary>

        Public Function ExecuteScalar(ByVal Query As String) As String
            Dim objResultado As String = ""
            Dim objTransaction As SqlTransaction
            Try
                'Obteniendo una conexion a la base de datos

                Using cnx As New SqlConnection(Me.Conectar())
                    
                    Dim cmd As New SqlCommand
                    cmd.Connection = cnx
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = Query
                    cmd.CommandTimeout = Me.TiempoRespuesta

                         cnx.Open()
               
                    objResultado = cmd.ExecuteScalar().ToString()

                          cnx.Close() 
                    cmd.Dispose()
                    cmd = Nothing 

                End Using

            Catch ex As Exception
                HelpClass.LogThis(ex.ToString)
                Throw New Exception(ex.ToString())
            End Try

            objTransaction = Nothing
            Return objResultado

        End Function

        ''' <summary>
        '''  Función que devuelve un DataTable 
        '''  en base a un stored procedure [StoredPocedure param] y
        '''  un objeto (tipo colección) de parametros
        ''' </summary>

        Public Function ExecuteDataTable(ByVal StoreProcedure As String, ByVal sqlparams As Parameter) As DataTable

            If HelpClass.getSetting("ConnectionMode") = "WebService" Then
                Return Me.getDataWebService(StoreProcedure, sqlparams)
            End If


            Dim objData As New DataSet
            Dim objTransaction As SqlTransaction

            Try

                Using cnx As New SqlConnection(Me.Conectar())

                    Dim cmdAdaptador As SqlDataAdapter
                    Dim cmd As New SqlCommand

                    cmd.Connection = cnx
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.CommandText = StoreProcedure
                    cmd.CommandTimeout = Me.TiempoRespuesta

                    Dim i As Integer
                    Dim SqlParametro As SqlParameter

                    If Not (sqlparams Is Nothing) Then
                        For i = 1 To sqlparams.Count
                            '  SqlParametro = CType(sqlparams.Item(i), SqlParameter)
                            cmd.Parameters.Add(CType(sqlparams.Item(i), SqlParameter))
                        Next
                    End If

                    cmdAdaptador = New SqlDataAdapter(cmd)

                    cnx.Open()

                    cmdAdaptador.Fill(objData)

                    cnx.Close()
                    cmd.Dispose()
                    cnx.Dispose()
                    SqlParametro = Nothing
                    cmd = Nothing
                End Using

            Catch ex As Exception
                HelpClass.LogThis(ex.ToString)
                Throw New Exception(ex.ToString())
            End Try

            objTransaction = Nothing
            Return objData.Tables(0).Copy()

        End Function

        ''' <summary>
        '''  Función que devuelve un único resultado 
        '''  en base a una instucción SQL
        ''' </summary>

        Public Function ExecuteDataTable(ByVal Query As String) As DataTable
            Dim objData As New DataSet
            Dim objTransaction As SqlTransaction

            Try

                Using cnx As New SqlConnection(Me.Conectar())
             
                    Dim cmdAdaptador As SqlDataAdapter
                    Dim cmd As New SqlCommand

                    cmd.Connection = cnx
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = Query
                    cmd.CommandTimeout = Me.TiempoRespuesta

                    cmdAdaptador = New SqlDataAdapter(cmd)

                        cnx.Open()
             
                    cmdAdaptador.Fill(objData)

                          cnx.Close() 
                    cmd.Dispose()
                    cmd = Nothing
                End Using

            Catch ex As Exception
                 HelpClass.LogThis(ex.ToString)
                Throw New Exception(ex.ToString())
            End Try

            objTransaction = Nothing
            Return objData.Tables(0).Copy()
        End Function

        ''' <summary>
        '''  Función que devuelve un DataTableReader 
        '''  en base a un stored procedure [StoredPocedure param] y
        '''  un objeto (tipo colección) de parametros
        ''' </summary>

        Public Function ExecuteIDataReader(ByVal StoreProcedure As String, ByVal sqlparams As Parameter) As IDataReader

            Dim objData As New DataSet
            Dim objTransaction As SqlTransaction

            Try

                Using cnx As New SqlConnection(Me.Conectar())
            
                    Dim cmdAdaptador As SqlDataAdapter
                    Dim cmd As New SqlCommand

                    cmd.Connection = cnx
                    cmd.CommandType = CommandType.StoredProcedure
                    cmd.CommandText = StoreProcedure
                    cmd.CommandTimeout = Me.TiempoRespuesta

                    Dim i As Integer
                    Dim SqlParametro As SqlParameter

                    If Not (sqlparams Is Nothing) Then
                        For i = 1 To sqlparams.Count
                            '  SqlParametro = CType(sqlparams.Item(i), SqlParameter)
                            cmd.Parameters.Add(CType(sqlparams.Item(i), SqlParameter))
                        Next
                    End If

                    cmdAdaptador = New SqlDataAdapter(cmd)

                         cnx.Open()
                
                    cmdAdaptador.Fill(objData)

                         cnx.Close() 
                    cmd.Dispose()
                    SqlParametro = Nothing
                    cmd = Nothing
                End Using

            Catch ex As Exception
                   HelpClass.LogThis(ex.ToString)
                Throw New Exception(ex.ToString())
            End Try

            objTransaction = Nothing
            Return objData.Tables(0).Copy().CreateDataReader()

        End Function


        Public Function ExecuteIDataReader(ByVal Query As String) As IDataReader
            Dim objData As New DataSet
            Dim objTransaction As SqlTransaction

            Try

                Using cnx As New SqlConnection(Me.Conectar())
                   
                    Dim cmdAdaptador As SqlDataAdapter
                    Dim cmd As New SqlCommand

                    cmd.Connection = cnx
                    cmd.CommandType = CommandType.Text
                    cmd.CommandText = Query
                    cmd.CommandTimeout = Me.TiempoRespuesta

                    cmdAdaptador = New SqlDataAdapter(cmd)

                         cnx.Open()
               
                    cmdAdaptador.Fill(objData)

                        cnx.Close() 
                    cmd.Dispose()
                    cmd = Nothing
                End Using


            Catch ex As Exception
                 HelpClass.LogThis(ex.ToString)
                Throw New Exception(ex.ToString())
            End Try

            objTransaction = Nothing
            Return objData.Tables(0).Copy().CreateDataReader()
        End Function

        Private Sub fillParameterCollection(ByVal objCmdParams As SqlParameterCollection)

            ObjParameterCollection.Clear()

            For i As Integer = 0 To objCmdParams.Count - 1
                If objCmdParams(i).Direction = ParameterDirection.Output Then
                    ObjParameterCollection.Add(objCmdParams(i).ParameterName, objCmdParams(i).Value)
                End If
            Next

        End Sub

        Public Function Conectar() As String

            Dim cnx As SqlConnection = Nothing
            Dim ConnStr As String = ""
            Try
                If Me.BaseDatos <> "" Then
                    'ConnStr = Configuration.ConfigurationSettings.AppSettings(BaseDatos)
                    If HelpClass.getSetting("ConnectionStringMode") = "EncryptMode" Then
                        ConnStr = New CryptoSecurity.CryptoHelper().Decrypt(Configuration.ConfigurationSettings.AppSettings(BaseDatos))
                    Else
                        ConnStr = Configuration.ConfigurationSettings.AppSettings(BaseDatos)
                    End If
                Else
                    If Me._isCrypted = True Then
                        ConnStr = New CryptoSecurity.CryptoHelper().Decrypt(Me.CadenaConexion)
                    Else
                        ConnStr = Me.CadenaConexion
                    End If
                End If
            Catch ex As Exception
                ' HelpClass.LogThis(ex.ToString)
                Throw New Exception(ex.ToString())
            End Try
            'Devolviendo la cadena de Conexion a la Base de Datos
            Return ConnStr

        End Function
  
        ''' <summary>
        ''' Funcion para obtener si un usuario tiene o no acceso al AS-400
        ''' </summary>
        Public Function Probar_Conexion(ByVal ConnStr As String) As Boolean
            Dim cnx As SqlConnection = Nothing
            Dim resultado As Boolean = False
            Try
                cnx = New SqlConnection(ConnStr)
                cnx.Open()
                resultado = True
                cnx.Close()
                cnx.Dispose()
                Try
                    System.Web.HttpContext.Current.Session("ses") = "ENABLED"
                Catch : End Try
            Catch ex As Exception

                resultado = False
            End Try
                'Devolviendo la cadena de Conexion a la Base de Datos
                Return resultado
        End Function

        ''' <summary>
        ''' Propiedad para establecer el tiempo de respuesta de un comando Sql
        ''' </summary>
        Public Property TimeOutCommand() As Integer
            Get
                Return Me.TiempoRespuesta
            End Get
            Set(ByVal value As Integer)
                Me.TiempoRespuesta = value
            End Set
        End Property

        Private disposedValue As Boolean = False        ' Para detectar llamadas redundantes

        ' IDisposable
        Protected Overridable Sub Dispose(ByVal disposing As Boolean)
            If Not Me.disposedValue Then
                If disposing Then
                    Me.Dispose()
                End If
                ' TODO: Liberar recursos no administrados compartidos
            End If
            Me.disposedValue = True
        End Sub

        Private Function XmlParser(ByVal objxmlData As String) As DataTable
            Dim dst As New DataSet
            Dim objxml As New Xml.XmlTextReader(New IO.StringReader(objxmlData))
            dst.ReadXml(objxml)
            Return dst.Tables(0).Copy
        End Function

        Private Function getDataWebService(ByVal StoredProcedure As String, ByVal Parameters As Parameter) As DataTable

            Dim lstr_parameter As New Text.StringBuilder
            Dim objWebService As New Service
            If Not (Parameters Is Nothing) Then
                lstr_parameter.Append("<Data>")
                For i As Integer = 1 To Parameters.Count
                    lstr_parameter.Append("<DataRow>")
                    lstr_parameter.Append("<paramname>" & CType(Parameters.Item(i), SqlParameter).ParameterName & "</paramname>")
                    lstr_parameter.Append("<paramvalue>" & CType(Parameters.Item(i), SqlParameter).Value.ToString() & "</paramvalue>")
                    lstr_parameter.Append("<paramtype>" & CType(Parameters.Item(i), SqlParameter).Direction & "</paramtype>")
                    lstr_parameter.Append("</DataRow>")

                Next
                lstr_parameter.Append("</Data>")
            End If
            'Ejecutando y devolviendo
            Return XmlParser(objWebService.getData(StoredProcedure, lstr_parameter.ToString))

        End Function

        Private Function executeStatementWebService(ByVal StoredProcedure As String, ByVal Parameters As Parameter) As String

            Dim lstr_parameter As New Text.StringBuilder
            lstr_parameter.Append("<Data>")
            Dim objWebService As New Service
            If Not (Parameters Is Nothing) Then
                For i As Integer = 1 To Parameters.Count
                    lstr_parameter.Append("<DataRow>")
                    lstr_parameter.Append("<paramname>" & CType(Parameters.Item(i), SqlParameter).ParameterName & "</paramname>")
                    lstr_parameter.Append("<paramvalue>" & CType(Parameters.Item(i), SqlParameter).Value.ToString() & "</paramvalue>")
                    lstr_parameter.Append("<paramtype>" & CType(Parameters.Item(i), SqlParameter).Direction & "</paramtype>")
                    lstr_parameter.Append("</DataRow>")

                Next
            End If
            lstr_parameter.Append("</Data>")
            'Ejecutando y devolviendo
            Return objWebService.executeStatement(StoredProcedure, lstr_parameter.ToString)


        End Function

#Region " IDisposable Support "
        ' Visual Basic agregó este código para implementar correctamente el modelo descartable.
        Public Sub Dispose() Implements IDisposable.Dispose
            ' No cambie este código. Coloque el código de limpieza en Dispose (ByVal que se dispone como Boolean).
            'Dispose(True)
            Try
                If Me.Transaction_Controller = TransactionType.Manual Then
                    objGlobalConnection.Close()
                    objGlobalTransaction.Dispose()
                    objGlobalConnection.Dispose()
                End If

                GC.SuppressFinalize(Me)
            Catch : End Try
        End Sub
#End Region


    End Class

End Namespace
