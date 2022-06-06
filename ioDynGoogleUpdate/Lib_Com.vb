Imports System.IO
Module Lib_Com
    Public Sub LogFile(txtout As String)
        'Dim pth As String = Directory.GetCurrentDirectory()
        Dim fle As String = "logfile.txt"

        If Not file.Exists(fle) Then
            Dim fly As System.IO.StreamWriter
            fly = My.Computer.FileSystem.OpenTextFileWriter(fle, False)
            fly.WriteLine(Now.ToString & " ** New File Start ** ")
            fly.Close()
        End If

        Dim flx As System.IO.StreamWriter
        flx = My.Computer.FileSystem.OpenTextFileWriter(fle, True)
        flx.WriteLine(Now.ToString & " > " & txtout)
        flx.Close()

    End Sub

End Module
