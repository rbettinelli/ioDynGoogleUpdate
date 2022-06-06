Imports System.IO
Imports Newtonsoft.Json
Imports System.Runtime.InteropServices

Public Class Service1

    Public Enum ServiceState
        SERVICE_STOPPED = 1
        SERVICE_START_PENDING = 2
        SERVICE_STOP_PENDING = 3
        SERVICE_RUNNING = 4
        SERVICE_CONTINUE_PENDING = 5
        SERVICE_PAUSE_PENDING = 6
        SERVICE_PAUSED = 7
    End Enum

    <StructLayout(LayoutKind.Sequential)>
    Public Structure ServiceStatus
        Public dwServiceType As Long
        Public dwCurrentState As ServiceState
        Public dwControlsAccepted As Long
        Public dwWin32ExitCode As Long
        Public dwServiceSpecificExitCode As Long
        Public dwCheckPoint As Long
        Public dwWaitHint As Long
    End Structure


    Private MyCallers As New List(Of Caller)

    Public Sub New()
        MyBase.New()
        InitializeComponent()
    End Sub

    Public Sub RunAsConsole()
        OnStart(Nothing)
        Console.WriteLine("Running...")
        Console.ReadLine()
        'OnStop()

    End Sub


    Protected Overrides Sub OnStart(ByVal args() As String)
        System.IO.Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory)
        LogFile("Started....")
        ' Update the service state to Start Pending.
        '---------------------[ Do My Setup ]---------------
        CheckForSetup()
        SetupTimers()
        '---------------------------------------------------
        ' Update the service state to Running.
    End Sub

    Protected Overrides Sub OnStop()
        LogFile("Stoppped....")
    End Sub

    Protected Sub CheckForSetup()

        If Not File.Exists("MySites.ini") Then
            LogFile("Ini Doesnt Exist....")
            Dim txtout As String = "[{" + Chr(34) + "Domain" + Chr(34) + ":" + Chr(34) + "yourdomain.com" + Chr(34) +
            "," + Chr(34) + "Username" + Chr(34) + ":" + Chr(34) + "AaAaAaAaAa" + Chr(34) + "," + Chr(34) +
            "Password" + Chr(34) + ":" + Chr(34) + "PpPpPpPpPpPp" + Chr(34) + "," + Chr(34) + "Interval" + Chr(34) + ":60}]"

            My.Computer.FileSystem.WriteAllText("MySites.ini", txtout, False)
            LogFile("Ini Created....")
            My.Application.Log.WriteEntry("MySites.ini File Created. Edit file and Restart Service")
            LogFile("Will wait for user to mod & restart....")

            Me.Stop()
            Environment.Exit(0)

        Else
            Dim fileReader As String
            fileReader = My.Computer.FileSystem.ReadAllText("MySites.ini")
            LogFile("Ini Read....")
            MyCallers = JsonConvert.DeserializeObject(Of List(Of Caller))(fileReader)
        End If

    End Sub

    Protected Sub SetupTimers()
        For Each Caller In MyCallers
            Caller.DoDynDnsCall()
            Caller.SetTimer()
        Next
    End Sub

End Class
