Imports System.Data.OleDb
Imports System.Math
Imports System.Collections.Specialized

Public Class frmTrLocator

    Private LongTrL, LatTrL, tzTrL, DstTrL As Double
    Private EW, NS As String
    Private myAyanflg As Boolean
    Private SubNo As Integer
    Friend PlaceDataB As NameValueCollection

    Private Sub frmTrLocator_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        Me.Hide()
    End Sub

    Private Sub frmTrLocator_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        cmbSgn.SelectedIndex = 0
        FillStar()
        cmbStl.SelectedIndex = 0
        cmbSub.SelectedIndex = 0
        cmbSSL.SelectedIndex = 0
        cmbSuk.SelectedIndex = 0
        cmbPra.SelectedIndex = 0
        cmbSPra.SelectedIndex = 0
        cmbSSPra.SelectedIndex = 0
        cmbBody.SelectedIndex = 0
        GetCurLocation()
        resetButtons()
        txtYear.Text = Now.Year
        txtMonth.Text = Now.Month
        txtDay.Text = Now.Day
        resetLabels()
        'LoadList()
        lblCombination.Text = ""
        lblNotes.Text = "Transit Position Locator helps you to reach the required planetary or Ascendant Position quickly and convniently. The results are accurate within few hundred miliseconds." & vbCrLf & vbCrLf & "For Rahu/Ketu their exit dates/times and for all other Planets/Ascendant their entry Date/Times are indicated."
    End Sub

    Private Sub FillStar()
        cmbStl.Items.Clear()
        If cmbSgn.Text = "Ari" Or cmbSgn.Text = "Leo" Or cmbSgn.Text = "Sag" Then
            cmbStl.Items.AddRange({"Ke", "Ve", "Su"})
        ElseIf cmbSgn.Text = "Tau" Or cmbSgn.Text = "Vir" Or cmbSgn.Text = "Cap" Then
            cmbStl.Items.AddRange({"Su", "Mo", "Ma"})
        ElseIf cmbSgn.Text = "Gem" Or cmbSgn.Text = "Lib" Or cmbSgn.Text = "Aqu" Then
            cmbStl.Items.AddRange({"Ma", "Ra", "Ju"})
        ElseIf cmbSgn.Text = "Can" Or cmbSgn.Text = "Sco" Or cmbSgn.Text = "Pis" Then
            cmbStl.Items.AddRange({"Ju", "Sa", "Me"})
        End If
    End Sub

    Private Sub cmbSgn_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cmbSgn.SelectedIndexChanged
        FillStar()
        cmbStl.SelectedIndex = 0
        resetButtons()
        resetLabels()
    End Sub

    Private Sub resetLabels()
        lblDateAs.Text = ""
        lblTimeAs.Text = ""
    End Sub

    Private Sub GetCurLocation()
        lblHorPlace.Text = PlaceDataB.Item("Place") & "-" & PlaceDataB.Item("State") & "-" & PlaceDataB.Item("Country")
        LongTrL = PlaceDataB.Item("lonB")
        EW = PlaceDataB.Item("eW")
        LatTrL = PlaceDataB.Item("latB")
        NS = PlaceDataB.Item("nS")
        tzTrL = PlaceDataB.Item("TzB")
        DstTrL = PlaceDataB.Item("DstB")
        If EW = "W" Then
            LongTrL = -LongTrL
            tzTrL = -tzTrL
        End If
        LatTrL = (Atan(Tan(LatTrL * PI / 180) * 0.99330546)) * 180 / PI
        If NS = "S" Then
            LatTrL = -LatTrL
        End If
        tzTrL = tzTrL + DstTrL
    End Sub

    Private Sub resetButtons()
        btnCalculate.Enabled = True
    End Sub

    Private Sub btnCalculate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnCalculate.Click
        Me.Cursor = Cursors.WaitCursor
        If txtDay.Text = 0 Or txtDay.Text = "" Or txtMonth.Text = 0 Or txtMonth.Text = "" Or txtYear.Text = 0 Or txtYear.Text = "" Then
            Me.Cursor = Cursors.Default
            MsgBox("Please enter the Date Correctly.", MsgBoxStyle.Critical)
            Exit Sub
        End If
        btnCalculate.Enabled = False
        Dim DateStr As String = ""
        Dim TimeStr As String = ""
        Dim DateTimeB As New NameValueCollection
        DateTimeB.Add("Year", txtYear.Text)
        DateTimeB.Add("Month", txtMonth.Text)
        DateTimeB.Add("Day", txtDay.Text)
        DateTimeB.Add("Hour", 0)
        DateTimeB.Add("Min", 0)
        DateTimeB.Add("Sec", 0)
        DateTimeB.Add("mSec", 0)

        Dim KPLords As New NameValueCollection
        KPLords.Add("Sign", cmbSgn.Text)
        KPLords.Add("STL", cmbStl.Text)
        KPLords.Add("SL", cmbSub.Text)
        KPLords.Add("SSL", cmbSSL.Text)
        KPLords.Add("Suk", cmbSuk.Text)
        KPLords.Add("Pra", cmbPra.Text)
        KPLords.Add("sPra", cmbSPra.Text)
        KPLords.Add("SSP", cmbSSPra.Text)

        Dim dError As String = ""
        Dim Horo As New TASystem.TrueAstro
        If cmbBody.Text = "Asc" Then
            Horo.getDateForAsc(DateTimeB, PlaceDataB, KPLords, DateStr, TimeStr, dError)
            If dError.Length > 0 Then
                MsgBox(dError)
            End If
        Else
            Horo.getDateForPlanet(DateTimeB, PlaceDataB, cmbBody.Text, KPLords, DateStr, TimeStr, dError)
            If dError.Length > 0 Then
                MsgBox(dError)
            End If
        End If

        lblDateAs.Text = DateStr
        lblTimeAs.Text = TimeStr
        Me.Cursor = Cursors.Default
    End Sub


    Private Sub txtDayAs_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDay.KeyPress
        If e.KeyChar = vbBack Or e.KeyChar = Chr(13) Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
            MsgBox("Please enter Date in numerals(0-9)", MsgBoxStyle.Information, Me.Text & "- Error")
        End If
    End Sub

    Private Sub txtDayAs_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDay.KeyUp
        If CheckMaxLength(txtDay.MaxLength, txtDay.TextLength) = True Then
            txtMonth.Focus()
            txtMonth.SelectAll()
        Else : Exit Sub
            If txtDay.Text <> "" Then
                If dayValidate(txtDay.Text) = False Then
                    txtDay.Text = ""
                    txtDay.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub txtMonthAs_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMonth.KeyPress
        If e.KeyChar = vbBack Or e.KeyChar = Chr(13) Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
            MsgBox("Please enter Month in numerals(0-9)", MsgBoxStyle.Information, Me.Text & "- Error")
        End If
    End Sub

    Private Sub txtMonthAs_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMonth.KeyUp
        If CheckMaxLength(txtMonth.MaxLength, txtMonth.TextLength) = True Then
            txtYear.Focus()
            txtYear.SelectAll()
        Else : Exit Sub
        End If
        If txtMonth.Text <> "" Then
            If monthValidate(txtMonth.Text) = False Then
                txtMonth.Text = ""
                txtMonth.Focus()
            End If
        End If
    End Sub


    Private Sub txtYearAs_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtYear.KeyPress
        If e.KeyChar = vbBack Or e.KeyChar = Chr(13) Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
            MsgBox("Please enter Year in numerals(0-9)", MsgBoxStyle.Information, Me.Text & "- Error")
        End If
    End Sub

    Private Sub txtYearAs_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtYear.KeyUp
        If CheckMaxLength(txtYear.MaxLength, txtYear.TextLength) = True Then
            btnCalculate.Focus()
        Else : Exit Sub
        End If
        If txtYear.Text <> "" Then
            If YearValidate(txtYear.Text) = False Then
                txtYear.Text = ""
                txtYear.Focus()
            End If
        End If
    End Sub

    Private Sub cmbPra_SelectedIndexChanged(sender As Object, e As System.EventArgs) Handles cmbPra.SelectedIndexChanged, cmbSSL.SelectedIndexChanged, cmbSub.SelectedIndexChanged, cmbStl.SelectedIndexChanged, cmbSuk.SelectedIndexChanged, cmbSPra.SelectedIndexChanged, cmbSSPra.SelectedIndexChanged, cmbBody.SelectedIndexChanged
        resetButtons()
        resetLabels()
    End Sub

    Private Sub btnPlace_Click(sender As System.Object, e As System.EventArgs) Handles btnPlace.Click
        Dim frmDlg As New frmLocation
        frmDlg.ShowDialog()
        If frmDlg.DialogResult = System.Windows.Forms.DialogResult.OK Then
            PlaceDataB = frmDlg.PlaceData
        End If
        GetCurLocation()
        frmDlg.Close()
    End Sub
End Class