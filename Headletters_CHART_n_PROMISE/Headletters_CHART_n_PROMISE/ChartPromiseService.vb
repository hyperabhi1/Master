﻿Public Class ChartPromiseService
    Dim timer As Timers.Timer
    Dim IsProcessing = False
    Protected Overrides Sub OnStart(ByVal args() As String)
        timer = New Timers.Timer()
        timer.Interval = 1000
        AddHandler timer.Elapsed, AddressOf TriggerGenChart
        timer.Enabled = True
        Dim strFile As String = String.Format("C:\Astro\ServiceLogs\ChartPromise\ChartGenService_Status.txt")
        IO.File.AppendAllText(strFile, String.Format("Service Started at-- {0}{1}", DateTime.Now, Environment.NewLine))
    End Sub

    Protected Overrides Sub OnStop()
        timer.Enabled = False
        Dim strFile As String = String.Format("C:\Astro\ServiceLogs\ChartPromise\ChartGenService_Status.txt")
        IO.File.AppendAllText(strFile, String.Format("Service Stopped at-- {0}{1}", DateTime.Now, Environment.NewLine))
    End Sub

    Private Sub TriggerGenChart(obj As Object, e As EventArgs)
        Try
            If IsProcessing = False Then
                IsProcessing = True
                Dim Gen_Chart As New GenChart
                Gen_Chart.Main()
                IsProcessing = False
            End If
        Catch ex As Exception
            Dim strFile As String = String.Format("C:\Astro\ServiceLogs\Errors\ChartGen_Error.txt")
            IO.File.AppendAllText(strFile, String.Format(vbCrLf + "Error Occured at-- {0}{1}{2}", Environment.NewLine + DateTime.Now, Environment.NewLine, ex.Message + vbCrLf + ex.StackTrace))
        End Try
    End Sub
End Class
