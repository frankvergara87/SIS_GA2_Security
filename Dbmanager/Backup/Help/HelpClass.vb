
Imports Microsoft.VisualBasic
Imports System
Imports System.Text
Imports System.IO
 

    MustInherit Class HelpClass

    Public Shared Function getSetting(ByVal Nombre As String) As String
        'Dim lstr_setting As String = ""
        'Try
        Return Configuration.ConfigurationSettings.AppSettings(Nombre).ToString()
        'Catch ex As Exception
        '    lstr_setting = ex.ToString
        'End Try
        'Return lstr_setting
    End Function

    Public Shared Function getTextFile(ByVal Archivo As String) As String

        Dim str As New StringBuilder
        Try
            Dim oFile As New IO.StreamReader(Archivo)
            While oFile.EndOfStream = False
                str.Append(oFile.ReadLine)
            End While
        Catch : End Try

        Return str.ToString

    End Function


    'Declaración de la API (Para Liberar Memoria http://gdev.wordpress.com/2005/11/30/liberar-memoria-con-vb-net/)
    Private Declare Auto Function SetProcessWorkingSetSize Lib "kernel32.dll" (ByVal procHandle As IntPtr, ByVal min As Int32, ByVal max As Int32) As Boolean

    Public Shared Function TodayNumeric() As String
        Return Today.Year & "" & IIf(Today.Month < 10, "0" & Today.Month, Today.Month) & "" & IIf(Today.Day < 10, "0" & Today.Day, Today.Day)
    End Function

    Public Shared Function NowNumeric() As String
        Return IIf(Now.Hour < 10, "0" & Now.Hour, Now.Hour) & "" & IIf(Now.Minute < 10, "0" & Now.Minute, Now.Minute) & "" & IIf(Now.Second < 10, "0" & Now.Second, Now.Second)
    End Function
    'Funcion de liberacion de memoria
    Public Shared Sub ClearMemory()

        Try

            ''Forzando la liberación de memoria
            GC.WaitForPendingFinalizers()
            GC.Collect()
            Dim Mem As Process
            Mem = Process.GetCurrentProcess()
            SetProcessWorkingSetSize(Mem.Handle, -1, -1)

        Catch : End Try

    End Sub

    Public Shared Sub LogThis(ByVal EventToLog As String)
        Try

            Dim strFile As String = "" & TodayNumeric() & ".txt"

            Dim LogPath As String = System.Web.HttpContext.Current.Session("webapppath").ToString()

            If IO.Directory.Exists(LogPath & "\log") = False Then
                IO.Directory.CreateDirectory(LogPath & "\log")
            End If

            Using objFile As New StreamWriter(LogPath & "\log" & "\" & strFile, True)
                objFile.WriteLine("ERROR : " & Today.ToShortDateString & " HORA : " & Today.ToShortTimeString)
                objFile.WriteLine(EventToLog)
                objFile.Flush()
                objFile.Close()
                objFile.Dispose()
            End Using

        Catch : End Try
    End Sub

End Class
 