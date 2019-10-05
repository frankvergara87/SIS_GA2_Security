Imports System.Collections
Imports System.Data.Sqlclient

Namespace DataObjects

    Public Class Parameter

        Dim obj As New Collection

        ''' <summary>
        '''  Pocedimiento que agrega a la colección de parametros el nombre de un parametro
        '''  y el valor asociado, no es necesario indicar el tipo de dato a ingresar.
        ''' </summary>

        Public Sub Add(ByVal ParameterName As String, ByVal ParameterValue As Object)
            obj.Add(New SqlParameter(ParameterName, ParameterValue), ParameterName)
        End Sub

        Public Sub Add(ByVal ParameterName As String, ByVal ParameterValue As Object, ByVal Orientation As ParameterDirection)
            Dim objParam As New SqlParameter(ParameterName, ParameterValue)
            objParam.Direction = Orientation
            obj.Add(objParam)
        End Sub

        Public Sub ParameterOrientation(ByVal ParameterName As String, ByVal Orientation As ParameterDirection)
            CType(obj.Item(ParameterName), SqlParameter).Direction = Orientation
        End Sub

        ''' <summary>
        '''  Pocedimiento que elimina un objeto de la colección de parametros en base a su posición
        ''' en dicha colección de objetos
        ''' </summary>

        Public Sub Remove(ByVal Indice As Integer)
            obj.Remove(Indice)
        End Sub

        ''' <summary>
        '''  Pocedimiento que elimina un objeto de la colección de parametros en base al nombre del parametro
        ''' en dicha colección de objetos
        ''' </summary>

        Public Sub Remove(ByVal ParameterName As String)
            obj.Remove(ParameterName)
        End Sub

        ''' <summary>
        '''  Función que devuelve el elementos SqlParameter de la colección en base a su posición
        ''' </summary>

        Public ReadOnly Property Item(ByVal Indice As Integer) As SqlParameter
            Get
                Return obj.Item(Indice)
            End Get
        End Property


        ''' <summary>
        '''  Función que devuelve el elementos SqlParameter de la colección en base a su nombre de parametro
        ''' </summary>


        Public ReadOnly Property Item(ByVal KeyValue As String) As SqlParameter
            Get
                Return obj.Item(KeyValue)
            End Get
        End Property


        ''' <summary>
        '''  Propiedad que devuelve el número de elementos de la colección
        ''' </summary>


        Public ReadOnly Property Count()
            Get
                Return obj.Count
            End Get

        End Property

    End Class

End Namespace
