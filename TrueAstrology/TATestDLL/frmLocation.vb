Imports System.Globalization
Imports System.Data.OleDb
Imports System.Collections.Specialized

Public Class frmLocation
    'Private LongD, LongM, LongS, LatD, LatM, LatS As Integer
    'Private eW, nS As String
    Private p_Id As String
    Friend PlaceData As New NameValueCollection

    Private Sub resetControls()
        LstPlaceView.Visible = False
        LstPlaceView.Items.Clear()
        txtCountry.Text = ""
        txtLatD.Text = ""
        txtLatM.Text = ""
        txtLatS.Text = ""
        txtLonD.Text = ""
        txtLongM.Text = ""
        txtLongS.Text = ""
        txtPlaceAd.Text = ""
        txtState.Text = ""
        txtTzHr.Text = ""
        txtTzMn.Text = ""
        txtDstHr.Text = "0"
        txtDstMin.Text = "00"
    End Sub

    Private Sub frmLocation_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        resetControls()
    End Sub

    Private Sub FillList(ByVal strFinalCondition As String)
        Dim strSql As String
        Dim lstX As ListViewItem
        strSql = " Select * from LatLonTable Where " & strFinalCondition
        Dim strConnection As String = ConString2
        Dim uccon As New OleDbConnection(strConnection)
        Dim myCommand As New OleDbCommand(strSql, uccon)
        Dim dreader As System.Data.OleDb.OleDbDataReader
        myCommand.Connection.Open()
        myCommand.CommandType = CommandType.Text
        myCommand.CommandText = strSql
        dreader = myCommand.ExecuteReader()
        LstPlaceView.Columns.Clear()
        LstPlaceView.Clear()
        LstPlaceView.Columns.Add("", 300, HorizontalAlignment.Left)
        While dreader.Read
            lstX = LstPlaceView.Items.Add(Convert.ToString(dreader("Place"), (Globalization.CultureInfo.InvariantCulture)) _
                               & " - " & Convert.ToString(IIf(IsDBNull(dreader("State")), "", dreader("State")), (Globalization.CultureInfo.InvariantCulture)) _
                               & " - " & Convert.ToString(IIf(IsDBNull(dreader("Country")), "", dreader("Country")), (Globalization.CultureInfo.InvariantCulture)) _
                               & " - " & dreader("LatDeg") & "° " & dreader("LatMin") & "' " & dreader("LatSec") & "'' " & dreader("NS") _
                               & " - " & dreader("LongDeg") & "° " & dreader("LongMin") & "' " & dreader("LongSec") & "'' " & dreader("EW"))
            lstX.SubItems.Add(dreader("LatLonID"))
        End While
        dreader.Close()
        uccon.Close()
    End Sub

    Private Sub lstPlaceView_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles LstPlaceView.DoubleClick
        Dim p As Integer
        For p = LstPlaceView.Items.Count - 1 To 0 Step -1
            If LstPlaceView.SelectedIndices.Contains(p) Then
                txtPlaceAd.Text = LstPlaceView.Items.Item(p).Text
                p_Id = LstPlaceView.Items.Item(p).SubItems(1).Text
            End If
        Next
        LstPlaceView.Visible = False
        GetParameter()
        OK.Focus()
    End Sub

    Private Sub lstPlaceView_ItemActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles LstPlaceView.ItemActivate
        Dim p As Integer
        For p = LstPlaceView.Items.Count - 1 To 0 Step -1
            If LstPlaceView.SelectedIndices.Contains(p) Then
                'txtPlace.Text = lstPlaceView.Items.Item(p).Text
            End If
        Next
    End Sub

    Private Sub lstPlaceView_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles LstPlaceView.KeyUp
        If e.KeyCode = 27 Or e.KeyCode = 13 Then
            txtPlaceAd.SelectionStart = txtPlaceAd.Text.Length
        End If
    End Sub

    Private Sub GetParameter()
        Dim strSql As String
        'Dim strfields() As String
        'strfields = Split(txtPlaceAd.Text, " - ")
        'Dim Pname As String
        'Dim Sname As String
        'Dim CName As String
        'Pname = strfields(0).ToString
        'Sname = strfields(1).ToString
        'CName = strfields(2).ToString
        strSql = "Select * from LatLonTable Where LatLonID = ?"
        Dim strConnection As String = ConString2
        Dim uccon As New OleDbConnection(strConnection)
        Dim myCommand As New OleDbCommand(strSql, uccon)
        Dim dreader As System.Data.OleDb.OleDbDataReader
        myCommand.Connection.Open()
        myCommand.Parameters.AddWithValue("LatLonID", p_Id)
        myCommand.CommandType = CommandType.Text
        dreader = myCommand.ExecuteReader()
        While dreader.Read
            txtPlaceAd.Text = CStr(dreader("Place"))
            txtState.Text = IIf(IsDBNull(dreader("State")), "", dreader("State"))
            txtCountry.Text = IIf(IsDBNull(dreader("Country")), "", dreader("Country"))
            txtLonD.Text = CStr(dreader("LongDeg"))
            txtLongM.Text = CStr(dreader("LongMin"))
            txtLongS.Text = CStr(dreader("LongSec"))
            txtEW.Text = CStr(dreader("EW"))
            txtLatD.Text = CStr(dreader("LatDeg"))
            txtLatM.Text = CStr(dreader("LatMin"))
            txtLatS.Text = CStr(dreader("LatSec"))
            txtNS.Text = CStr(dreader("NS"))
            txtTzHr.Text = Format(Val(dreader("TimeZoneHour")), "00")
            txtTzMn.Text = Format(Val(dreader("TimeZoneMin")), "00")
        End While
        dreader.Close()
        uccon.Close()
    End Sub

    Private Sub txtPlaceAd_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPlaceAd.KeyUp
        Dim strCondition As String = ""
        If e.KeyCode = 27 Then txtPlaceAd.Text = ""
        LstPlaceView.Visible = True
        If strCondition = "" Then
            strCondition = "Place Like '" & txtPlaceAd.Text.Replace("'", "''") & "%'"
        Else
            strCondition = "Place Like '" & txtPlaceAd.Text.Replace("'", "''") & "%'"
        End If
        If txtPlaceAd.TextLength > 2 Then
            FillList(strCondition)
        Else
            LstPlaceView.Clear()
        End If
        If LstPlaceView.Items.Count > 0 Then
            LstPlaceView.Visible = True
        End If
        If e.KeyCode = Keys.Tab And txtPlaceAd.Text <> "" Then
            LstPlaceView.Visible = False
        End If
    End Sub

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        resetControls()
        txtPlaceAd.Focus()
    End Sub

    Private Sub OK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK.Click
        If txtValidate() = True Then
            Dim lon, lat, geoLat, Tz As Double
            lon = txtLonD.Text + txtLongM.Text / 60 + txtLongS.Text / 3600
            geoLat = txtLatD.Text + txtLatM.Text / 60 + txtLatS.Text / 3600
            Tz = Val(txtTzHr.Text) + Val(txtTzMn.Text) / 60
            If txtEW.Text = "W" Then
                lon = -lon
                Tz = -Tz
            End If
            lat = (Math.Atan(Math.Tan(geoLat * Math.PI / 180) * 0.99330546)) * 180 / Math.PI
            If txtNS.Text = "S" Then
                lat = -lat
            End If

            PlaceData.Add("Place", txtPlaceAd.Text)
            PlaceData.Add("State", txtState.Text)
            PlaceData.Add("Country", txtCountry.Text)

            PlaceData.Add("lonB", lon)
            PlaceData.Add("latB", lat)
            PlaceData.Add("eW", txtEW.Text)
            PlaceData.Add("nS", txtNS.Text)
            PlaceData.Add("TzB", Tz)
            PlaceData.Add("DstB", Val(txtDstHr.Text) + Val(txtDstMin.Text) / 60)
        End If
        resetControls()
        txtPlaceAd.Focus()
        Me.Hide()
    End Sub

    Private Function txtValidate() As Boolean
        If txtPlaceAd.Text = "" Then
            MsgBox("Please Enter Place Name.", MsgBoxStyle.Critical)
            txtPlaceAd.Focus()
            txtValidate = False
            Exit Function
        End If
        'If txtState.Text = "" Then
        '    MsgBox("Please Enter State Name.", MsgBoxStyle.Critical)
        '    txtState.Focus()
        '    txtValidate = False
        '    Exit Function
        'End If
        If txtCountry.Text = "" Then
            MsgBox("Please Enter Country Name.", MsgBoxStyle.Critical)
            txtCountry.Focus()
            txtValidate = False
            Exit Function
        End If
        If txtTzHr.Text = "" Then
            MsgBox("Please Enter Time Zone Hour.", MsgBoxStyle.Critical)
            txtTzHr.Focus()
            txtValidate = False
            Exit Function
        End If
        If txtTzMn.Text = "" Then
            MsgBox("Please Enter Time Zone Minutes.", MsgBoxStyle.Critical)
            txtTzMn.Focus()
            txtValidate = False
            Exit Function
        End If
        If txtLonD.Text = "" Or txtLongM.Text = "" Or txtLongS.Text = "" Or txtEW.Text = "" Then
            MsgBox("Please Enter Longitude in Deg.-Min.-Sec..", MsgBoxStyle.Critical)
            txtLonD.Focus()
            txtValidate = False
            Exit Function
        End If
        If txtLatD.Text = "" Or txtLatM.Text = "" Or txtLatS.Text = "" Or txtNS.Text = "" Then
            MsgBox("Please Enter Latitude in Deg.-Min.-Sec..", MsgBoxStyle.Critical)
            txtLatD.Focus()
            txtValidate = False
            Exit Function
        End If
        txtValidate = True
    End Function

    Private Sub txtLatD_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLatD.KeyPress
        If e.KeyChar = vbBack Or e.KeyChar = Chr(13) Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
            MsgBox("Please enter numerals(0-9)", MsgBoxStyle.Information, Me.Text & "- Error")
        End If
    End Sub

    Private Sub txtLatD_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLatD.KeyUp
        If CheckMaxLength(txtLatD.MaxLength, txtLatD.TextLength) = True Then
            txtLatM.Focus()
            txtLatM.SelectAll()
        End If
        If txtLatD.Text <> "" Then
            If DegValidate(txtLatD.Text) = False Then
                txtLatD.Text = ""
                txtLatD.Focus()
            End If
        End If
    End Sub

    Private Sub txtLatM_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLatM.KeyPress
        If e.KeyChar = vbBack Or e.KeyChar = Chr(13) Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
            MsgBox("Please enter in numerals(0-9)", MsgBoxStyle.Information, Me.Text & "- Error")
        End If
    End Sub

    Private Sub txtLatM_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLatM.KeyUp
        If CheckMaxLength(txtLatM.MaxLength, txtLatM.TextLength) = True Then
            txtLatS.Focus()
            txtLatS.SelectAll()
        End If
        If txtLatM.Text <> "" Then
            If MinValidate(txtLatM.Text) = False Then
                txtLatM.Text = ""
                txtLatM.Focus()
            End If
        End If
    End Sub

    Private Sub txtLatS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLatS.KeyPress
        If e.KeyChar = vbBack Or e.KeyChar = Chr(13) Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
            MsgBox("Please enter in numerals(0-9)", MsgBoxStyle.Information, Me.Text & "- Error")
        End If
    End Sub

    Private Sub txtLatS_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLatS.KeyUp
        If CheckMaxLength(txtLatS.MaxLength, txtLatS.TextLength) = True Then
            txtNS.Focus()
            txtNS.SelectAll()
        End If
        If txtLatS.Text <> "" Then
            If MinValidate(txtLatS.Text) = False Then
                txtLatS.Text = ""
                txtLatS.Focus()
            End If
        End If
    End Sub

    Private Sub txtLonD_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLonD.KeyPress
        If e.KeyChar = vbBack Or e.KeyChar = Chr(13) Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
            MsgBox("Please enter in numerals(0-9)", MsgBoxStyle.Information, Me.Text & "- Error")
        End If
    End Sub

    Private Sub txtLonD_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLonD.KeyUp
        If CheckMaxLength(txtLonD.MaxLength, txtLonD.TextLength) = True Then
            txtLongM.Focus()
            txtLongM.SelectAll()
        End If
        If txtLonD.Text <> "" Then
            If DegValidate(txtLonD.Text) = False Then
                txtLonD.Text = ""
                txtLonD.Focus()
            End If
        End If
    End Sub

    Private Sub txtLongM_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLongM.KeyPress
        If e.KeyChar = vbBack Or e.KeyChar = Chr(13) Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
            MsgBox("Please enter in numerals(0-9)", MsgBoxStyle.Information, Me.Text & "- Error")
        End If
    End Sub

    Private Sub txtLongM_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLongM.KeyUp
        If CheckMaxLength(txtLongM.MaxLength, txtLongM.TextLength) = True Then
            txtLongS.Focus()
            txtLongS.SelectAll()
        End If
        If txtLongM.Text <> "" Then
            If MinValidate(txtLongM.Text) = False Then
                txtLongM.Text = ""
                txtLongM.Focus()
            End If
        End If
    End Sub

    Private Sub txtLongS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtLongS.KeyPress
        If e.KeyChar = vbBack Or e.KeyChar = Chr(13) Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
            MsgBox("Please enter in numerals(0-9)", MsgBoxStyle.Information, Me.Text & "- Error")
        End If
    End Sub

    Private Sub txtLongS_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtLongS.KeyUp
        If CheckMaxLength(txtLongS.MaxLength, txtLongS.TextLength) = True Then
            txtEW.Focus()
            txtEW.SelectAll()
        End If
        If txtLongS.Text <> "" Then
            If MinValidate(txtLongS.Text) = False Then
                txtLongS.Text = ""
                txtLongS.Focus()
            End If
        End If
    End Sub

    Private Sub txtTzHr_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTzHr.KeyPress
        If e.KeyChar = vbBack Or e.KeyChar = Chr(13) Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
            MsgBox("Please enter in numerals(0-9)", MsgBoxStyle.Information, Me.Text & "- Error")
        End If
    End Sub

    Private Sub txtTzHr_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTzHr.KeyUp
        If CheckMaxLength(txtTzHr.MaxLength, txtTzHr.TextLength) = True Then
            txtTzMn.Focus()
            txtTzMn.SelectAll()
        End If
        If txtTzHr.Text <> "" Then
            If HourValidate(txtTzHr.Text) = False Then
                txtTzHr.Text = ""
                txtTzHr.Focus()
            End If
        End If
    End Sub

    Private Sub txtTzMn_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTzMn.KeyPress
        If e.KeyChar = vbBack Or e.KeyChar = Chr(13) Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
            MsgBox("Please enter in numerals(0-9)", MsgBoxStyle.Information, Me.Text & "- Error")
        End If
    End Sub

    Private Sub txtTzMn_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTzMn.KeyUp
        If CheckMaxLength(txtTzMn.MaxLength, txtTzMn.TextLength) = True Then
            txtLonD.Focus()
            txtLonD.SelectAll()
        End If
        If txtTzMn.Text <> "" Then
            If MinValidate(txtTzMn.Text) = False Then
                txtTzMn.Text = ""
                txtTzMn.Focus()
            End If
        End If
    End Sub

    Private Sub txtEW_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtEW.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.E) Or e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.W) Then Exit Sub
        e.Handled = True
        MsgBox("Please enter (E) or (W) only.", MsgBoxStyle.Critical)
        txtEW.Focus()
    End Sub

    Private Sub txtEW_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtEW.KeyUp
        If CheckMaxLength(txtEW.MaxLength, txtEW.TextLength) = True Then
            txtLatD.Focus()
            txtLatD.SelectAll()
        End If
    End Sub

    Private Sub txtNS_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtNS.KeyPress
        If e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.N) Or e.KeyChar = Microsoft.VisualBasic.ChrW(Keys.S) Then Exit Sub
        e.Handled = True
        MsgBox("Please enter (N) or (S) only.", MsgBoxStyle.Critical)
        txtNS.Focus()
    End Sub

    Private Sub txtNS_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtNS.KeyUp
        If CheckMaxLength(txtNS.MaxLength, txtNS.TextLength) = True Then
            txtDstHr.Focus()
            txtDstHr.SelectAll()
        End If
    End Sub

    Private Sub txtDstHr_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDstHr.KeyPress
        If e.KeyChar = vbBack Or e.KeyChar = Chr(13) Or e.KeyChar = "-" Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
            MsgBox("Please enter in numerals(0-9)", MsgBoxStyle.Information, Me.Text & "- Error")
        End If
    End Sub

    Private Sub txtDstHr_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDstHr.KeyUp
        If CheckMaxLength(txtDstHr.MaxLength, txtDstHr.TextLength) = True Then
            txtDstMin.Focus()
            txtDstMin.SelectAll()
        End If
        If txtDstHr.Text <> "" Then
            If HourValidate(txtDstHr.Text) = False Then
                txtDstHr.Text = ""
                txtDstHr.Focus()
            End If
        End If
    End Sub

    Private Sub txtDstMin_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDstMin.KeyPress
        If e.KeyChar = vbBack Or e.KeyChar = Chr(13) Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
            MsgBox("Please enter in numerals(0-9)", MsgBoxStyle.Information, Me.Text & "- Error")
        End If
    End Sub

    Private Sub txtDstMin_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDstMin.KeyUp
        If CheckMaxLength(txtDstMin.MaxLength, txtDstMin.TextLength) = True Then
            txtLonD.Focus()
            txtLonD.SelectAll()
        End If
        If txtDstMin.Text <> "" Then
            If MinValidate(txtDstMin.Text) = False Then
                txtDstMin.Text = ""
                txtDstMin.Focus()
            End If
        End If
    End Sub
End Class