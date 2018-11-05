Imports System.Data.oledb
Imports System.Math
Imports System.Collections.Specialized

Public Class frmTransitChart
    Private StrPlanet(13) As String
    Friend LagnaB As Integer
    Friend trLat, TrLon, sdTzDst, DstHr, DstMin, Dst As Double
    Private StrCuspTr(13) As String
    Private pIS(13) As String
    Private LongD, LongM, LongS, LatD, LatM, TzHr, TzMin, LatS As Integer
    Private eW, nS As String
    Friend Dasa(9, 4) As String
    Private Bhukti(9, 5) As String
    Private Antara(9, 6) As String
    Private Suk(9, 7) As String
    Private Pra(17, 8) As String
    Private STL As String
    Private SL As String
    Private SSL As String
    Private SukL As String
    Private PraL As String
    Private trDate As Date
    Private tzSign As String
    Private AyanDMS As String
    Private rasiIndex(12) As Integer
    Private HAscMc(9) As Double
    Friend PlaceDataB As New NameValueCollection
    Private TransitLagna(12, 2) As String
    Private TrSouth(12) As String
    Friend DateTimeB As New NameValueCollection
    Private PlaceDataT As New NameValueCollection

    Private Sub ClearForm()
        txtDay1.Text = "00"
        txtHr1.Text = "00"
        txtMonth1.Text = "00"
        txtYear1.Text = "0000"
        txtMin1.Text = "00"
        txtSec1.Text = "00"
    End Sub

    Private Sub frmTransitChart_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        PlaceDataT = PlaceDataB
        Me.txtPlaceD.Text = PlaceDataT.Item("Place")
        Me.txtState.Text = PlaceDataT.Item("State")
        Me.txtCountry.Text = PlaceDataT.Item("Country")
        Me.txtTzHr.Text = PlaceDataT.Item("TzB")
        Me.txtDstHr.Text = PlaceDataT.Item("DstB")
        Me.txtLong.Text = PlaceDataT.Item("lonB") & PlaceDataT.Item("eW")
        Me.txtLat.Text = PlaceDataT.Item("latB") & PlaceDataT.Item("nS")
        Me.Cursor = Cursors.WaitCursor
        Dim x, y As Integer
        'Me.Size = New Size(670, 660)
        x = SystemInformation.VirtualScreen.Width - Me.Width - 2
        y = SystemInformation.VirtualScreen.Height - Me.Height - 32
        Me.Location = New Point(x, y)
        Dim RPTime As Date = Now
        Dim DatetimeC As New NameValueCollection
        DatetimeC.Add("mSec", RPTime.Millisecond)
        DatetimeC.Add("Sec", RPTime.Second)
        DatetimeC.Add("Min", RPTime.Minute)
        DatetimeC.Add("Hour", RPTime.Hour)
        DatetimeC.Add("Day", RPTime.Day)
        DatetimeC.Add("Month", RPTime.Month)
        DatetimeC.Add("Year", RPTime.Year)
        Dim TzDst As Double = CDbl(PlaceDataB.Item("TzB")) + CDbl(PlaceDataB.Item("DstB"))
        Dim Horo As New TASystem.TrueAstro
        Horo.getTransitList(DatetimeC, PlaceDataT, StrPlanet)

        Horo.getTransitLagna(LagnaB, DatetimeC, PlaceDataT, PlaceDataT, TransitLagna, TrSouth)
        loadList()
        pcLagna.Refresh()
        PictureBoxS.Refresh()
        pcLagna.Update()
        PictureBoxS.Update()
        Horo.getDasaByDate(DatetimeC, TzDst, Dasa, Bhukti, Antara, Suk, Pra)
        LoadDasa4()
        Dim DayDasa As String = ""
        Horo.getBirthDasaFordateTime(DatetimeC, DateTimeB, PlaceDataB, DayDasa)
        lblToday.Text = "D-B-A-S-P for the Day is " & DayDasa
        lbltithi.Text = Horo.getTithi(DatetimeC, PlaceDataT)
        lblWday.Text = "Vedic Day is " & Horo.getVedicDay(DatetimeC, PlaceDataT)
        Dim cDateTime As DateTime = New DateTime(DatetimeC.Item("Year"), DatetimeC.Item("Month"), DatetimeC.Item("Day"), DatetimeC.Item("Hour"), DatetimeC.Item("Min"), DatetimeC.Item("Sec"))
        Me.Text = "Transit Chart for " & Format(cDateTime, "dd/MM/yyyy :: HH:mm:ss")
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub loadList()
        Dim strP(12) As String
        Dim pls As String
        Dim i As Integer
        DgPl.Rows.Clear()
        For i = 0 To 12
            strP = Split(StrPlanet(i), "|")
            pls = strP(0)
            Dim Sgn As String = strP(1)
            Dim DMS As String = strP(2)
            Dim SgnL As String = strP(3)
            Dim STL As String = strP(4)
            Dim SL As String = strP(5)
            Dim SSL As String = strP(6)
            Dim SukL As String = strP(7)
            Dim PraL As String = strP(8)
            Dim sPraL As String = strP(9)
            Dim ssPraL As String = strP(10)
            Dim Retro As String = strP(11)
            Dim plRow1 As Object() = New Object() {pls, Sgn, DMS, SgnL, STL, SL, SSL, SukL, PraL, sPraL, ssPraL, IIf(Retro = "R", "Ret", "")}
            DgPl.Rows.Add(plRow1)
        Next
        DgPl.ClearSelection()
    End Sub

    Private Sub drawRasiNorth(ByVal gOff As Graphics, ByVal X As Integer, ByVal Y As Integer)
        Dim Hno(12) As Integer
        For i As Integer = 1 To 12
            Hno(i) = TransitLagna(i, 0)
            pIS(i) = TransitLagna(i, 1)
        Next
        DrawNChart(gOff, X, Y, 420, 219, True)
        writePlanetsN(gOff, X, Y, 420, 219, True, True, pIS)
        writeHouseNosN(gOff, X, Y, 420, 219, Hno, True)
    End Sub

    Private Sub drawChartSouth(ByVal gOff As Graphics, ByVal X As Single, ByVal Y As Single, ByVal Wd As Single, ByVal Ht As Single)
        DrawSChart(gOff, X, Y, Wd, Ht)
        writeSPlanet(gOff, X, Y, Wd, Ht, TrSouth, 0)
    End Sub

    Private Sub btnCal1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCal1.Click
        If txtDay1.Text = 0 Or txtDay1.Text = "" Or txtMonth1.Text = 0 Or txtMonth1.Text = "" Or txtYear1.Text = 0 Or txtYear1.Text = "" Then
            MsgBox("Please enter Correct Date.", MsgBoxStyle.Critical)
            Exit Sub
        End If
        Me.Cursor = Cursors.WaitCursor
        Dim RPTime As Date = Now
        Dim DatetimeC As New NameValueCollection
        DatetimeC.Add("mSec", txtmSec.Text)
        DatetimeC.Add("Sec", txtSec1.Text)
        DatetimeC.Add("Min", txtMin1.Text)
        DatetimeC.Add("Hour", txtHr1.Text)
        DatetimeC.Add("Day", txtDay1.Text)
        DatetimeC.Add("Month", txtMonth1.Text)
        DatetimeC.Add("Year", txtYear1.Text)
        Dim TzDst As Double = CDbl(PlaceDataB.Item("TzB")) + CDbl(PlaceDataB.Item("DstB"))
        Dim Horo As New TASystem.TrueAstro
        Horo.getTransitList(DatetimeC, PlaceDataT, StrPlanet)

        Horo.getTransitLagna(LagnaB, DatetimeC, PlaceDataT, PlaceDataT, TransitLagna, TrSouth)
        loadList()
        pcLagna.Refresh()
        PictureBoxS.Refresh()
        pcLagna.Update()
        PictureBoxS.Update()
        Horo.getDasaByDate(DatetimeC, TzDst, Dasa, Bhukti, Antara, Suk, Pra)
        LoadDasa4()
        Dim DayDasa As String = ""
        Horo.getBirthDasaFordateTime(DatetimeC, DateTimeB, PlaceDataB, DayDasa)
        lblToday.Text = "D-B-A-S-P for the Day is " & DayDasa
        lbltithi.Text = Horo.getTithi(DatetimeC, PlaceDataT)
        lblWday.Text = "Vedic Day is " & Horo.getVedicDay(DatetimeC, PlaceDataT)
        Dim cDateTime As DateTime = New DateTime(DatetimeC.Item("Year"), DatetimeC.Item("Month"), DatetimeC.Item("Day"), DatetimeC.Item("Hour"), DatetimeC.Item("Min"), DatetimeC.Item("Sec"))
        Me.Text = "Transit Chart for " & Format(cDateTime, "dd/MM/yyyy :: HH:mm:ss")
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub txtMin1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMin1.KeyUp
        If CheckMaxLength(txtMin1.MaxLength, txtMin1.TextLength) = True Then
            txtSec1.Focus()
            txtSec1.SelectAll()
        Else
            Exit Sub
        End If
        If txtMin1.Text <> "" Then
            If MinValidate(txtMin1.Text) = False Then
                txtMin1.Text = ""
                txtMin1.Focus()
            End If
        End If
    End Sub

    Private Sub txtDay1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDay1.KeyUp
        If CheckMaxLength(txtDay1.MaxLength, txtDay1.TextLength) = True Then
            txtMonth1.Focus()
            txtMonth1.SelectAll()
        Else
            Exit Sub
        End If
        If txtDay1.Text <> "" Then
            If dayValidate(txtDay1.Text) = False Then
                txtDay1.Text = ""
                txtDay1.Focus()
            End If
        End If
    End Sub


    Private Sub txtMonth1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMonth1.KeyUp
        If CheckMaxLength(txtMonth1.MaxLength, txtMonth1.TextLength) = True Then
            txtYear1.Focus()
            txtYear1.SelectAll()
        Else
            Exit Sub
        End If
        If txtMonth1.Text <> "" Then
            If monthValidate(txtMonth1.Text) = False Then
                txtMonth1.Text = ""
                txtMonth1.Focus()
            End If
        End If
    End Sub


    Private Sub txtYear1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtYear1.KeyUp
        If CheckMaxLength(txtYear1.MaxLength, txtYear1.TextLength) = True Then
            txtHr1.Focus()
            txtHr1.SelectAll()
        Else
            Exit Sub
        End If
        If txtYear1.Text <> "" Then
            If YearValidate(txtYear1.Text) = False Then
                txtYear1.Text = ""
                txtYear1.Focus()
            End If
        End If
    End Sub


    Private Sub txtHr1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtHr1.KeyUp
        If CheckMaxLength(txtHr1.MaxLength, txtHr1.TextLength) = True Then
            txtMin1.Focus()
            txtMin1.SelectAll()
        Else
            Exit Sub
        End If
        If txtHr1.Text <> "" Then
            If HourValidate(txtHr1.Text) = False Then
                txtHr1.Text = ""
                txtHr1.Focus()
            End If
        End If
    End Sub


    Private Sub txtSec1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSec1.KeyUp
        If CheckMaxLength(txtSec1.MaxLength, txtSec1.TextLength) = True Then
            txtmSec.Focus()
        Else
            Exit Sub
        End If
        If txtSec1.Text <> "" Then
            If SecValidate(txtSec1.Text) = False Then
                txtSec1.Text = ""
                txtSec1.Focus()
            End If
        End If
    End Sub

    Private Sub btnPlace_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnPlace.Click
        Dim frmDlg As New frmLocation
        frmDlg.ShowDialog()
        If frmDlg.DialogResult = System.Windows.Forms.DialogResult.OK Then
            PlaceDataT = frmDlg.PlaceData
            txtCountry.Text = PlaceDataT.Item("Country")
            txtState.Text = PlaceDataT.Item("State")
            txtPlaceD.Text = PlaceDataT.Item("Place")
            Me.txtPlaceD.Text = PlaceDataT.Item("Place")
            Me.txtState.Text = PlaceDataT.Item("State")
            Me.txtCountry.Text = PlaceDataT.Item("Country")
            Me.txtTzHr.Text = PlaceDataT.Item("TzB")
            Me.txtDstHr.Text = PlaceDataT.Item("DstB")
            Me.txtLong.Text = PlaceDataT.Item("lonB") & PlaceDataT.Item("eW")
            Me.txtLat.Text = PlaceDataT.Item("latB") & PlaceDataT.Item("nS")
        End If
        frmDlg.Close()
        'Me.TopLevel = True
    End Sub

    Private Sub getTithiName()
        Dim slen, mlen As Double
        Dim strSun(), strMo() As String
        Dim tithi As Integer
        Dim tithiname() As String = {"Shukla Paksha - Pratipada", "Shukla Paksha - Dviteeya", "Shukla Paksha - Triteeya", "Shukla Paksha - Chaturthi", "Shukla Paksha - Panchami", "Shukla Paksha - Shasti", "Shukla Paksha - Saptami", "Shukla Paksha - Asthami", "Shukla Paksha - Navami", "Shukla Paksha - Dasami", "Shukla Paksha - Ekadasi", "Shukla Paksha - Dvadasi", "Shukla Paksha - Trayodasi", "Shukla Paksha - Chaturdasi", "Shukla Paksha - Purnima", "Krishna Paksha - Pratipada", "Krishna Paksha - Dviteeya", "Krishna Paksha - Triteeya", "Krishna Paksha - Chaturthi", "Krishna Paksha - Panchami", "Krishna Paksha - Shasti", "Krishna Paksha - Saptami", "Krishna Paksha - Asthami", "Krishna Paksha - Navami", "Krishna Paksha - Dasami", "Krishna Paksha - Ekadasi", "Krishna Paksha - Dvadasi", "Krishna Paksha - Trayodasi", "Krishna Paksha - Chaturdasi", "Krishna Paksha - Amavasya"}
        strSun = Split(StrPlanet(1), "|")
        strMo = Split(StrPlanet(2), "|")
        slen = strSun(1)
        mlen = strMo(1)
        tithi = Int(red_deg(mlen - slen) / 12)
        lbltithi.Text = tithiname(tithi)
    End Sub

    Private Sub LoadDasa4()
        Dim i As Integer
        DgDasa.Rows.Clear()
        DgDasa.Columns.Clear()
        DgDasa.Columns.Add("D", "D")
        DgDasa.Columns(0).Width = 31
        DgDasa.Columns.Add("B", "B")
        DgDasa.Columns(1).Width = 31
        DgDasa.Columns.Add("A", "A")
        DgDasa.Columns(2).Width = 31
        DgDasa.Columns.Add("S", "S")
        DgDasa.Columns(3).Width = 31
        DgDasa.Columns.Add("P", "P")
        DgDasa.Columns(4).Width = 31
        DgDasa.Columns.Add("Ending Date and Time", "Ending Date and Time")
        DgDasa.Columns(5).Width = 145
        Dim pls As String = ""
        For i = 0 To 8
            pls = Pra(i, 0)
            Dim dl As Object() = New Object() {pls, Pra(i, 1), Pra(i, 2), Pra(i, 3), Pra(i, 4), Pra(i, 8)}
            DgDasa.Rows.Add(dl)
        Next
        DgDasa.ClearSelection()
    End Sub

    Private Sub pcLagna_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pcLagna.Paint
        e.Graphics.Clear(Color.White)
        drawRasiNorth(e.Graphics, 1, 1)
    End Sub

    Private Sub PictureBoxS_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PictureBoxS.Paint
        e.Graphics.Clear(Color.White)
        drawChartSouth(e.Graphics, 1, 1, 356, 446)
    End Sub
End Class