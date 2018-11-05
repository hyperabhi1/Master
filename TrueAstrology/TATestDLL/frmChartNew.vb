Imports System.Globalization
Imports System.Math
Imports System.Data.OleDb
Imports System.Collections.Specialized

Public Class frmChartNew
    Private lmt, Tz, Dst As Double
    Private myYear, myDay, myMonth, myHour As Double
    Private lon, lat, geoLat As Double
    Private m_Hr, m_Min, m_Sec, m_mSec As Integer
    Private myAyanVal As Double
    Private Sgn As String
    Private SgnL As String
    Private StarN As String
    Private STL As String
    Private SL As String
    Private SSL As String
    Private SukL As String
    Private PraL As String
    Private DMS As String
    Private SSubArc As String
    Private Dasa(9, 4) As String
    Private Bhukti(9, 5) As String
    Private Antara(9, 6) As String
    Private Suk(9, 7) As String
    Private Pra(18, 8) As String
    Private d_level As Integer
    Private pIH(12) As String
    Private pIS(12) As String
    Private HstrCusp(12) As String
    Private Hplanets(12) As String
    Private HAscMc(9) As Double
    Private SidT, AyanDMS As String
    Private RObl As String
    Private lblOvl As String
    Private Ps(12) As String
    Private rasiIndex(12) As Integer
    Private RPDayN As String
    Private GMT As String
    Private LMTCor As String
    Private CastRPStr1 As String
    Private CastRPStr2 As String
    Friend DateTimeB As New NameValueCollection
    Friend PlaceDataB As New NameValueCollection
    Private BirthLagna(12, 2) As String
    Private BirthBhav(12, 2) As String
    Private BirthSouth(12) As String

    Private Sub ComputeHoro()
        Try
            Dim P_list(12) As String
            Dim H_List(12) As String
            'Dim Hr As Double = (DateTimeB.Item("Hour") * 3600 + DateTimeB.Item("Min") * 60 + DateTimeB.Item("Sec") + DateTimeB.Item("mSec") / 1000) / 3600 - (PlaceDataB.Item("TzB") + PlaceDataB.Item("DstB"))
            'Dim tjdB As Double = NativeMethods.swe_julday(DateTimeB.Item("Year"), DateTimeB.Item("Month"), DateTimeB.Item("Day"), Hr, 1)
            'Dim X(5) As Double
            'Dim iflag As Integer
            'Dim ret_flag As Integer
            'Dim serr(255) As Char
            'iflag = 322
            'NativeMethods.swe_set_ephe_path(Application.StartupPath.ToString(CultureInfo.InvariantCulture))
            'ret_flag = NativeMethods.swe_calc_ut(tjdB, 1, iflag, X(0), serr)
            Dim Horo As New TASystem.TrueAstro
            Horo.getBirthPlanetCusp(DateTimeB, PlaceDataB, P_list, H_List)
            Hplanets = P_list
            HstrCusp = H_List
            Horo.getBirthLagnaBhav(DateTimeB, PlaceDataB, BirthLagna, BirthBhav, BirthSouth)
            Dim err As String = Horo.getError
            If err.Length > 0 Then
                MsgBox(err)
            End If
        Catch ex As Exception
            MsgBox(ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub

    Private Sub LoadPlanets()
        Try
            Dim strP(12) As String
            Dim pls As String
            Dim i As Integer
            DgLvP.Rows.Clear()
            For i = 1 To 12
                strP = Split(Hplanets(i), "|")
                pls = strP(0)
                Dim Sgn As String = strP(1)
                Dim DMS As String = strP(2)
                Dim SgnL As String = strP(3)
                Dim STL As String = strP(4)
                Dim SL As String = strP(5)
                Dim SSL As String = strP(6)
                Dim SukL As String = strP(7)
                Dim PraL As String = strP(8)
                Dim Retro As String = strP(9)
                Dim PlinH As String = strP(10)
                Dim PoS As String = strP(11)
                Dim pRow As Object() = New Object() {pls, Sgn, DMS, SgnL, STL, SL, SSL, SukL, PraL, PlinH, Retro, PoS}
                DgLvP.Rows.Add(pRow)
            Next
            DgLvP.ClearSelection()
            DgLvP.Refresh()
        Catch ex As Exception
            MsgBox(ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub

    Private Sub LoadCusp()
        Try
            Dim strP(12) As String
            Dim i As Integer
            DgLvH.Rows.Clear()
            For i = 1 To 12
                strP = Split(HstrCusp(i), "|")
                Dim Sgn As String = strP(1)
                Dim DMS As String = strP(2)
                Dim SgnL As String = strP(3)
                Dim STL As String = strP(4)
                Dim SL As String = strP(5)
                Dim SSL As String = strP(6)
                Dim SukL As String = strP(7)
                Dim PraL As String = strP(8)
                Dim SSArc As String = strP(9)
                Dim PraArc As String = strP(10)
                Dim pRow As Object() = New Object() {GetRoman(i), Sgn, DMS, SgnL, STL, SL, SSL, SukL, PraL, SSArc, PraArc}
                DgLvH.Rows.Add(pRow)
            Next
            DgLvH.ClearSelection()
        Catch ex As Exception
            MsgBox(ex.Message & vbCrLf & ex.StackTrace)
        End Try
    End Sub

    Private Sub frmChart_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.SetStyle(ControlStyles.ResizeRedraw, True)
        Me.SetStyle(ControlStyles.AllPaintingInWmPaint Or _
                ControlStyles.UserPaint Or ControlStyles.DoubleBuffer, True)
        If SystemInformation.VirtualScreen.Width < 1156 Or SystemInformation.VirtualScreen.Height < 768 Then
            Me.AutoScroll = True
        End If
        Try
            ComputeHoro()
            ComputeRP()
            LoadPlanets()
            LoadCusp()
            ComputeDasa()
        Catch ex As ApplicationException
            MessageBox.Show(ex.Message & vbCrLf & vbCrLf & ex.StackTrace, "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification)
        End Try
    End Sub

    Private Sub ComputeRP()
        Dim Horo As New TASystem.TrueAstro
        Dim RPTime As Date = Now
        Dim RPValues As New NameValueCollection
        Dim DatetimeC As New NameValueCollection
        DatetimeC.Add("mSec", RPTime.Millisecond)
        DatetimeC.Add("Sec", RPTime.Second)
        DatetimeC.Add("Min", RPTime.Minute)
        DatetimeC.Add("Hour", RPTime.Hour)
        DatetimeC.Add("Day", RPTime.Day)
        DatetimeC.Add("Month", RPTime.Month)
        DatetimeC.Add("Year", RPTime.Year)
        Horo.ComputeRP(DatetimeC, PlaceDataB, RPValues)

        lblRPTime.Text = " At " & Format(CDbl(DatetimeC.Item("Hour")), "00") & ":" & Format(CDbl(DatetimeC.Item("Min")), "00") & ":" & Format(DatetimeC.Item("Sec") + DatetimeC.Item("mSec") / 1000, "00.000") & "Hrs." & "on " & Format(RPTime, "dd/MM/yyyy")
        lblRPDayL.Text = RPValues.Item("DayL")
        RPDayN = RPValues.Item("DayN")
        lblRPAsc.Text = RPValues.Item("AsSgnL") & " / " & RPValues.Item("AsSTL") & " / " & RPValues.Item("AsSL") & " / " & RPValues.Item("AsSSL") & " / " & RPValues.Item("AsSukL") & " / " & RPValues.Item("AsPraL")
        lblRPMo.Text = RPValues.Item("MoSgnL") & " / " & RPValues.Item("MoSTL") & " / " & RPValues.Item("MoSL") & " / " & RPValues.Item("MoSSL") & " / " & RPValues.Item("MoSukL") & " / " & RPValues.Item("MoPraL")
        lblRahu.Text = "T.Rahu : "
        lblRPRahu.Text = RPValues.Item("RaSgnL") & " / " & RPValues.Item("RaSTL")
        lblKetu.Text = "T.Ketu : "
        lblRPKetu.Text = RPValues.Item("KeSgnL") & " / " & RPValues.Item("KeSTL")
    End Sub

    Private Sub btnRP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRP.Click
        ComputeRP()
    End Sub

    Private Sub ComputeDasa()
        Dim Horo As New TASystem.TrueAstro
        Horo.getBirthDasa(DateTimeB, PlaceDataB, Dasa)
        LoadDasa()
    End Sub

    Private Sub LoadDasa()
        Dim i As Integer
        DgDasa.Rows.Clear()
        DgDasa.Columns.Clear()
        DgDasa.Columns.Add("D", "")
        DgDasa.Columns(0).Width = 31
        DgDasa.Columns.Add("Ending Date and Time", "")
        DgDasa.Columns(1).Width = 145
        Dim pls As String
        For i = 0 To 8
            pls = Dasa(i, 0)
            Dim dl As Object() = New Object() {pls, Dasa(i, 4)}
            DgDasa.Rows.Add(dl)
        Next
        d_level = 1
        btnB.Visible = False
        btnA.Visible = False
        btnS.Visible = False
        btnP.Visible = False
        btnDate.Left = btnDasa.Left + 30
        DgDasa.ClearSelection()
    End Sub

    Private Sub GetNextLevel(ByVal d_Level As Integer, ByVal p As Integer)
        Dim Horo As New TASystem.TrueAstro
        Select Case d_Level
            Case 0
                LoadDasa()
            Case 1
                Horo.getDasabyLevel(DateTimeB, PlaceDataB, d_Level, p, Dasa, Bhukti)
                LoadDasa1()
            Case 2
                Horo.getDasabyLevel(DateTimeB, PlaceDataB, d_Level, p, Bhukti, Antara)
                LoadDasa2()
            Case 3
                Horo.getDasabyLevel(DateTimeB, PlaceDataB, d_Level, p, Antara, Suk)
                LoadDasa3()
            Case 4
                Horo.getDasabyLevel(DateTimeB, PlaceDataB, d_Level, p, Suk, Pra)
                LoadDasa4()
        End Select
    End Sub

    Private Sub LoadDasa1()
        Dim i As Integer
        DgDasa.Rows.Clear()
        DgDasa.Columns.Clear()
        DgDasa.Columns.Add("D", "")
        DgDasa.Columns(0).Width = 31
        DgDasa.Columns.Add("B", "")
        DgDasa.Columns(1).Width = 31
        DgDasa.Columns.Add("Ending Date and Time", "")
        DgDasa.Columns(2).Width = 145
        Dim pls As String = ""
        For i = 0 To 8
            pls = Bhukti(i, 0)
            Dim dl As Object() = New Object() {pls, Bhukti(i, 1), Bhukti(i, 5)}
            DgDasa.Rows.Add(dl)
        Next
        d_level = 2
        btnB.Visible = True
        btnA.Visible = False
        btnS.Visible = False
        btnP.Visible = False
        btnDate.Left = btnB.Left + 30
        DgDasa.ClearSelection()
    End Sub

    Private Sub LoadDasa2()
        Dim i As Integer
        DgDasa.Rows.Clear()
        DgDasa.Columns.Clear()
        DgDasa.Columns.Add("D", "")
        DgDasa.Columns(0).Width = 31
        DgDasa.Columns.Add("B", "")
        DgDasa.Columns(1).Width = 31
        DgDasa.Columns.Add("A", "")
        DgDasa.Columns(2).Width = 31
        DgDasa.Columns.Add("Ending Date and Time", "")
        DgDasa.Columns(3).Width = 145
        Dim pls As String = ""
        For i = 0 To 8
            pls = Antara(i, 0)
            Dim dl As Object() = New Object() {pls, Antara(i, 1), Antara(i, 2), Antara(i, 6)}
            DgDasa.Rows.Add(dl)
        Next
        d_level = 3
        btnB.Visible = True
        btnA.Visible = True
        btnS.Visible = False
        btnP.Visible = False
        btnDate.Left = btnA.Left + 30
        DgDasa.ClearSelection()
    End Sub

    Private Sub LoadDasa3()
        Dim i As Integer
        DgDasa.Rows.Clear()
        DgDasa.Columns.Clear()
        DgDasa.Columns.Add("D", "")
        DgDasa.Columns(0).Width = 31
        DgDasa.Columns.Add("B", "")
        DgDasa.Columns(1).Width = 31
        DgDasa.Columns.Add("A", "")
        DgDasa.Columns(2).Width = 31
        DgDasa.Columns.Add("S", "")
        DgDasa.Columns(3).Width = 31
        DgDasa.Columns.Add("Ending Date and Time", "")
        DgDasa.Columns(4).Width = 145
        Dim pls As String = ""
        For i = 0 To 8
            pls = Suk(i, 0)
            Dim dl As Object() = New Object() {pls, Suk(i, 1), Suk(i, 2), Suk(i, 3), Suk(i, 7)}
            DgDasa.Rows.Add(dl)
        Next
        d_level = 4
        btnB.Visible = True
        btnA.Visible = True
        btnS.Visible = True
        btnP.Visible = False
        btnDate.Left = btnS.Left + 30
        DgDasa.ClearSelection()
    End Sub

    Private Sub DgDasa_CellDoubleClick(ByVal sender As Object, ByVal e As System.Windows.Forms.DataGridViewCellEventArgs) Handles DgDasa.CellDoubleClick
        Dim i As Integer
        i = DgDasa.CurrentCell.RowIndex
        GetNextLevel(d_level, i)
        DgDasa.ClearSelection()
    End Sub

    Private Sub LoadDasa4()
        Dim i As Integer
        DgDasa.Rows.Clear()
        DgDasa.Columns.Clear()
        DgDasa.Columns.Add("D", "")
        DgDasa.Columns(0).Width = 31
        DgDasa.Columns.Add("B", "")
        DgDasa.Columns(1).Width = 31
        DgDasa.Columns.Add("A", "")
        DgDasa.Columns(2).Width = 31
        DgDasa.Columns.Add("S", "")
        DgDasa.Columns(3).Width = 31
        DgDasa.Columns.Add("P", "")
        DgDasa.Columns(4).Width = 31
        DgDasa.Columns.Add("Ending Date and Time", "")
        DgDasa.Columns(5).Width = 145
        Dim pls As String = ""
        For i = 0 To 8
            pls = Pra(i, 0)
            Dim dl As Object() = New Object() {pls, Pra(i, 1), Pra(i, 2), Pra(i, 3), Pra(i, 4), Pra(i, 8)}
            DgDasa.Rows.Add(dl)
        Next
        d_level = 5
        btnB.Visible = True
        btnA.Visible = True
        btnS.Visible = True
        btnP.Visible = True
        btnDate.Left = btnP.Left + 30
        DgDasa.ClearSelection()
    End Sub

    Private Sub btnDasa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnDasa.Click
        LoadDasa()
    End Sub

    Private Sub btnB_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnB.Click
        LoadDasa1()
    End Sub

    Private Sub btnA_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnA.Click
        LoadDasa2()
    End Sub

    Private Sub btnS_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnS.Click
        LoadDasa3()
    End Sub

    Private Sub btnCurDasa_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCurDasa.Click
        Dim Horo As New TASystem.TrueAstro
        Dim RPTime As Date = Now
        Dim DatetimeC As New NameValueCollection
        DatetimeC("mSec") = RPTime.Millisecond
        DatetimeC("Sec") = RPTime.Second
        DatetimeC("Min") = RPTime.Minute
        DatetimeC("Hour") = RPTime.Hour
        DatetimeC("Day") = RPTime.Day
        DatetimeC("Month") = RPTime.Month
        DatetimeC("Year") = RPTime.Year
        Horo.getDasaByDate(DatetimeC, PlaceDataB("TzB") + PlaceDataB("Dst"), Dasa, Bhukti, Antara, Suk, Pra)
        LoadDasa4()
    End Sub

    Private Sub btnVimD1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVimD1.Click
        If txtVimY1.Text = 0 Or txtVimMon1.Text = 0 Or txtVimDay1.Text = 0 Then
            MessageBox.Show("Please Enter Correct Date", "", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification)
            txtVimDay1.Focus()
            txtVimDay1.SelectAll()
            Exit Sub
        End If
        Dim Horo As New TASystem.TrueAstro
        Dim RPTime As Date = Now
        Dim DatetimeC As New NameValueCollection
        DatetimeC("mSec") = 0
        DatetimeC("Sec") = 0
        DatetimeC("Min") = 0
        DatetimeC("Hour") = 0
        DatetimeC("Day") = txtVimDay1.Text
        DatetimeC("Month") = txtVimMon1.Text
        DatetimeC("Year") = txtVimY1.Text
        Horo.getDasaByDate(DatetimeC, PlaceDataB("TzB") + PlaceDataB("Dst"), Dasa, Bhukti, Antara, Suk, Pra)
        LoadDasa4()
    End Sub

    Private Sub drawRasiNorth(ByVal gOff As Graphics, ByVal X As Single, ByVal Y As Single)
        Dim Hno(12) As Integer
        For i As Integer = 1 To 12
            Hno(i) = BirthLagna(i, 0)
            pIS(i) = BirthLagna(i, 1)
        Next
        DrawNChart(gOff, X, Y, 330, 194)
        writePlanetsN(gOff, X, Y, 330, 194, True, True, pIS)
        writeHouseNosN(gOff, X, Y, 330, 194, Hno, True)
    End Sub

    Private Sub drawBhavaNorth(ByVal gOff As Graphics, ByVal X As Single, ByVal Y As Single)
        Dim Hno(12) As Integer
        For i As Integer = 1 To 12
            Hno(i) = BirthBhav(i, 0)
            pIH(i) = BirthBhav(i, 1)
        Next
        DrawNChart(gOff, X, Y, 330, 194)
        writePlanetsN(gOff, X, Y, 330, 194, True, True, pIH)
        writeHouseNosN(gOff, X, Y, 330, 194, Hno, True)
    End Sub

    Private Sub drawChartSouth(ByVal gOff As Graphics, ByVal X As Single, ByVal Y As Single, ByVal Wd As Single, ByVal Ht As Single)      
        DrawSChart(gOff, X, Y, Wd, Ht)
        writeSPlanet(gOff, X, Y, Wd, Ht, BirthSouth, 0)
    End Sub

    Private Sub PicBoxChart_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles PicBoxChart.Paint
        e.Graphics.Clear(Color.White)
        drawRasiNorth(e.Graphics, 1, 1)
        drawBhavaNorth(e.Graphics, 1, 216)
    End Sub

    Private Sub pcSouth_Paint(ByVal sender As Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles pcSouth.Paint
        e.Graphics.Clear(Color.White)
        drawChartSouth(e.Graphics, 1, 1, 330, 412)
    End Sub

    Private Sub txtVimDay1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtVimDay1.KeyPress
        If e.KeyChar = vbBack Or e.KeyChar = Chr(13) Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
            MsgBox("Please enter numerals(0-9)", MsgBoxStyle.Information, Me.Text & "- Error")
        End If
    End Sub

    Private Sub txtVimDay1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtVimDay1.KeyUp
        If CheckMaxLength(txtVimDay1.MaxLength, txtVimDay1.TextLength) = True Then
            txtVimMon1.Focus()
            txtVimMon1.SelectAll()
        Else : Exit Sub
        End If
        If txtVimDay1.Text <> "" Then
            If dayValidate(txtVimDay1.Text) = False Then
                txtVimDay1.Text = ""
                txtVimDay1.Focus()
            End If
        End If
    End Sub

    Private Sub txtVimMon1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtVimMon1.KeyPress
        If e.KeyChar = vbBack Or e.KeyChar = Chr(13) Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
            MsgBox("Please enter numerals(0-9)", MsgBoxStyle.Information, Me.Text & "- Error")
        End If
    End Sub

    Private Sub txtVimMon1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtVimMon1.KeyUp
        If CheckMaxLength(txtVimMon1.MaxLength, txtVimMon1.TextLength) = True Then
            txtVimY1.Focus()
            txtVimY1.SelectAll()
        Else : Exit Sub
        End If
        If txtVimMon1.Text <> "" Then
            If monthValidate(txtVimMon1.Text) = False Then
                txtVimMon1.Text = ""
                txtVimMon1.Focus()
            End If
        End If
    End Sub

    Private Sub txtVimY1_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtVimY1.KeyPress
        If e.KeyChar = vbBack Or e.KeyChar = Chr(13) Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
            MsgBox("Please enter numerals(0-9)", MsgBoxStyle.Information, Me.Text & "- Error")
        End If
    End Sub

    Private Sub txtVimY1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtVimY1.KeyUp
        If CheckMaxLength(txtVimY1.MaxLength, txtVimY1.TextLength) = True Then
            btnVimD1.Focus()
        Else : Exit Sub
        End If
        If txtVimY1.Text <> "" Then
            If YearValidate(txtVimY1.Text) = False Then
                txtVimY1.Text = ""
                txtVimY1.Focus()
            End If
        End If
    End Sub

    Private Sub btnTramsit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnTramsit.Click
        With frmTransitChart
            .DateTimeB = DateTimeB
            .PlaceDataB = PlaceDataB
            .LagnaB = rasiIndex(1)
            .Dasa = Dasa
            .trLat = lat
            .TrLon = lon
            .sdTzDst = PlaceDataB("TzB") + PlaceDataB("Dst")
        End With
        frmTransitChart.ShowDialog()
    End Sub

    Private Sub btnDasha_Click(sender As System.Object, e As System.EventArgs) Handles btnDasha.Click
        Me.Cursor = Cursors.WaitCursor
        Dim DBPrint As New PrintDasa(1)
        Dim Horo As New TASystem.TrueAstro
        Dim DasaListP As New DataTable
        DasaListP.Columns.Add("Dasha")
        DasaListP.Columns.Add("Bhukti")
        DasaListP.Columns.Add("Antara")
        DasaListP.Columns.Add("Suk")
        DasaListP.Columns.Add("Pra")
        DasaListP.Columns.Add("Cl_Date")
        Horo.getBirthDasaDBA(DateTimeB, PlaceDataB, DasaListP)
        Dim gt As New GenHTMLChart
        gt.GenHTMLChartMain(DasaListP)
        DBPrint.DasaListP = DasaListP
        Me.Cursor = Cursors.Default
        DBPrint.ShowPrintPreviewDialog()
    End Sub

    Private Sub btnBirthData_Click(sender As System.Object, e As System.EventArgs) Handles btnBirthData.Click
        Dim frm As New frmBasicData
        frm.PlaceDataB = PlaceDataB
        frm.DateTimeB = DateTimeB
        frm.ShowDialog()
    End Sub

    Private Sub btnTrLoc_Click(sender As System.Object, e As System.EventArgs) Handles btnTrLoc.Click
        Dim frm As New frmTrLocator
        frm.PlaceDataB = PlaceDataB
        frm.ShowDialog()
    End Sub

    Private Sub btnDasha3Yr_Click(sender As Object, e As System.EventArgs) Handles btnDasha3Yr.Click
        Me.Cursor = Cursors.WaitCursor
        Dim DBPrint As New PrintDasa(1)
        Dim Horo As New TASystem.TrueAstro
        Dim DasaListP As New DataTable
        DasaListP.Columns.Add("Dasha")
        DasaListP.Columns.Add("Bhukti")
        DasaListP.Columns.Add("Antara")
        DasaListP.Columns.Add("Suk")
        DasaListP.Columns.Add("Pra")
        DasaListP.Columns.Add("Cl_Date")

        Dim RPTime As Date = Now
        Dim DatetimeC As New NameValueCollection
        DatetimeC.Add("mSec", RPTime.Millisecond)
        DatetimeC.Add("Sec", RPTime.Second)
        DatetimeC.Add("Min", RPTime.Minute)
        DatetimeC.Add("Hour", RPTime.Hour)
        DatetimeC.Add("Day", RPTime.Day)
        DatetimeC.Add("Month", RPTime.Month)
        DatetimeC.Add("Year", RPTime.Year)

        Dim EndDate As New NameValueCollection
        Dim Yr As Double = 40 * 365
        Dim e_Dt As Date = Now.AddDays(Yr)
        EndDate.Add("mSec", e_Dt.Millisecond)
        EndDate.Add("Sec", e_Dt.Second)
        EndDate.Add("Min", e_Dt.Minute)
        EndDate.Add("Hour", e_Dt.Hour)
        EndDate.Add("Day", e_Dt.Day)
        EndDate.Add("Month", e_Dt.Month)
        EndDate.Add("Year", e_Dt.Year)
        Horo.getDasabyDateRange(DateTimeB, PlaceDataB, DatetimeC, EndDate, DasaListP)
        Dim gt As New GenHTMLChart
        gt.GenHTMLChartMain(DasaListP)
        DBPrint.DasaListP = DasaListP
        Me.Cursor = Cursors.Default
        DBPrint.ShowPrintPreviewDialog()
    End Sub
End Class