Imports System.Windows.Forms
Imports System.Globalization

Public Class frmMain
    Friend Shared MyChartForrms As New Collection

    Public Shared ReadOnly Property fCount() As Integer
        Get
            Return MyChartForrms.Count
        End Get
    End Property

    Private Sub mnuNewChart_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles mnuNewChart.Click
        frmBirthData.ShowDialog()
    End Sub
End Class
