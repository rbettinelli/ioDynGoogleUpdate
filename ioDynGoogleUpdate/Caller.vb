Imports System.Net
Imports System.Timers
Imports Microsoft.VisualBasic.Logging

Public Class Caller

    Public myTimer As New Timer

    Public Property Domain As String
    Public Property Username As String
    Public Property Password As String
    Public Property Interval As Integer

    Public Sub SetTimer()

        LogFile("Starting Domain : " & Domain & " timer.")
        AddHandler myTimer.Elapsed, AddressOf Timer_Tick
        myTimer.AutoReset = True
        myTimer.Interval = Interval * 60 * 1000
        myTimer.Start()
    End Sub

    Private Sub Timer_Tick(source As Object, e As EventArgs)
        LogFile("Timer : " & Domain & " Tick!")
        DoDynDnsCall()

    End Sub

    Public Sub DoDynDnsCall()
        LogFile("Setting Dyn Domain :" & Domain)
        Dim client = New WebClient With {
            .Credentials = New NetworkCredential(Username, Password)
        }
        Dim response = client.DownloadString("https://domains.google.com/nic/update?hostname=" + Domain)
        LogFile("Response Dyn Domain : " & Domain & " ----> " & response)
    End Sub


End Class
