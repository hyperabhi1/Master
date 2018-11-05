Imports System.Math
Imports System.Collections.Specialized

Public Class frmBasicData
    Friend PlaceDataB As New NameValueCollection
    Friend DateTimeB As New NameValueCollection

    Private Sub frmBasicData_Paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles Me.Paint
        Dim Horo As New TASystem.TrueAstro
        Dim BasicData As New NameValueCollection
        Horo.getBirthInfo(DateTimeB, PlaceDataB, BasicData)
        Dim X As Integer = 10
        Dim Y As Integer = 0
        Dim Wd As Integer = 190
        Dim Ht As Integer = 21
        Dim nTabs As Single = 0
        Dim lnSp As Single = 26
        e.Graphics.FillRectangle((Brushes.Pink), New Rectangle(1, 6, Me.Width, 46))
        Dim flags As TextFormatFlags = TextFormatFlags.HorizontalCenter Or TextFormatFlags.VerticalCenter
        TextRenderer.DrawText(e.Graphics, "BASIC DATA", New System.Drawing.Font("Microsoft Sans Serif", 24, FontStyle.Bold), New Rectangle(1, 4, Me.Width, 46), Color.Black, Color.Pink, flags)
        Y = 60
        DrawTextH(e, "Asc : ", X, Y, Wd, Ht)
        DrawTextV(e, BasicData("Asc"), X + Wd + nTabs, Y, Wd, Ht)
        Y += lnSp
        DrawTextH(e, "Rashi : ", X, Y, Wd, Ht)
        DrawTextV(e, BasicData("Rashi"), X + Wd + nTabs, Y, Wd, Ht)

        Y += lnSp
        DrawTextH(e, "Nakshatra : ", X, Y, Wd, Ht)
        DrawTextV(e, BasicData("NakPada"), X + Wd + nTabs, Y, Wd, Ht)

        Y += lnSp
        DrawTextH(e, "Sun Sign : ", X, Y, Wd, Ht)
        DrawTextV(e, BasicData("WestRashi"), X + Wd + nTabs, Y, Wd, Ht)

        Y += lnSp
        DrawTextH(e, "Tithi : ", X, Y, Wd, Ht)
        DrawTextV(e, BasicData("BTithi"), X + Wd + nTabs, Y, Wd, Ht)

        Y += lnSp
        DrawTextH(e, "Sidereal Time : ", X, Y, Wd, Ht)
        DrawTextV(e, BasicData("SidTime"), X + Wd + nTabs, Y, Wd, Ht)

        Y += lnSp
        DrawTextH(e, "Ayanamsa : ", X, Y, Wd, Ht)
        DrawTextV(e, BasicData("Ayanamsha"), X + Wd + nTabs, Y, Wd, Ht)

        Y += lnSp
        DrawTextH(e, "Vimshottari Balance Dasa : ", X, Y, Wd, Ht)
        DrawTextV(e, BasicData("DasaBal"), X + Wd + nTabs, Y, Wd + 100, Ht)

    End Sub

    Private Sub DrawTextV(ByVal e As PaintEventArgs, ByVal strText As String, ByVal X As Integer, ByVal Y As Integer, ByVal Wd As Integer, ByVal Ht As Integer)
        Dim flags As TextFormatFlags = TextFormatFlags.Left Or TextFormatFlags.Top Or TextFormatFlags.NoPrefix Or TextFormatFlags.Default
        TextRenderer.DrawText(e.Graphics, strText, New System.Drawing.Font("Microsoft Sans Serif", 10, FontStyle.Regular), New Rectangle(X, Y, Wd, Ht), Color.Blue, Color.Transparent, flags)
    End Sub

    Private Sub DrawTextVE(ByVal e As PaintEventArgs, ByVal strText As String, ByVal X As Integer, ByVal Y As Integer, ByVal Wd As Integer, ByVal Ht As Integer)
        Dim flags As TextFormatFlags = TextFormatFlags.Left Or TextFormatFlags.Top Or TextFormatFlags.NoPrefix
        TextRenderer.DrawText(e.Graphics, strText, New System.Drawing.Font("Microsoft Sans Serif", 10, FontStyle.Regular), New Rectangle(X, Y, Wd, Ht), Color.Blue, Color.Transparent, flags)
    End Sub

    Private Sub DrawTextH(ByVal e As PaintEventArgs, ByVal strText As String, ByVal X As Integer, ByVal Y As Integer, ByVal Wd As Integer, ByVal Ht As Integer)
        Dim flags As TextFormatFlags = TextFormatFlags.Right Or TextFormatFlags.Top Or TextFormatFlags.NoPrefix
        TextRenderer.DrawText(e.Graphics, strText, New System.Drawing.Font("Microsoft Sans Serif", 10, FontStyle.Regular), New Rectangle(X, Y, Wd, Ht), Color.Black, Color.Transparent, flags)
    End Sub

    Private Sub DrawTextVH(ByVal e As PaintEventArgs, ByVal strText As String, ByVal X As Integer, ByVal Y As Integer, ByVal Wd As Integer, ByVal Ht As Integer)
        Dim flags As TextFormatFlags = TextFormatFlags.Left Or TextFormatFlags.Top Or TextFormatFlags.NoPrefix
        TextRenderer.DrawText(e.Graphics, strText, New System.Drawing.Font("Kruti Dev 020", 14.5, FontStyle.Regular), New Rectangle(X, Y, Wd, Ht), Color.Blue, Color.Transparent, flags)
    End Sub
End Class