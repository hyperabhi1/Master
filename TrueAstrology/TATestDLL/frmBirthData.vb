Imports System.Globalization
Imports System.Data.OleDb
Imports System.Collections.Specialized

Public Class frmBirthData
    Private LongD, LongM, LongS, LatD, LatM, LatS As Integer
    Private eW, nS As String
    Private p_Id As Integer

    Private Sub btnReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReset.Click
        ClearForm()
    End Sub

    Private Sub ClearForm()
        txtdd.Text = ""
        txtmm.Text = ""
        txtYear.Text = ""
        txtHr.Text = ""
        txtMin.Text = ""
        txtSec.Text = ""
        txtmSec.Text = ""
        txtTzHr.Text = ""
        txtTzMn.Text = ""
        txtTzSec.Text = ""
        txtDstHr.Text = "0"
        txtDstMn.Text = "00"
        txtPlace.Text = ""
        txtLong.Text = ""
        txtLat.Text = ""
    End Sub

    Private Sub btnOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOK.Click
        If tValidate() = False Then Exit Sub
        Dim frm As New frmChartNew
        Dim BData As New NameValueCollection
        BData.Add("Year", txtYear.Text)
        BData.Add("Month", txtmm.Text)
        BData.Add("Day", txtdd.Text)
        BData.Add("Hour", txtHr.Text)
        BData.Add("Min", txtMin.Text)
        BData.Add("Sec", txtSec.Text)
        BData.Add("mSec", txtmSec.Text)
        frm.DateTimeB = BData
        Dim lon, lat, geoLat, Tz As Double
        Dim PlaceData As New NameValueCollection
        lon = LongD + LongM / 60 + LongS / 3600
        'lon = 78 + 41 / 60 + 11 / 3600
        geoLat = LatD + LatM / 60 + LatS / 3600
        'geoLat = 10 + 48 / 60 + 18 / 3600
        Tz = Val(txtTzHr.Text) + Val(txtTzMn.Text) / 60 + Val(txtTzSec.Text) / 3600
        'mychages
        eW = "E"
        nS = "N"
        If eW = "W" Then
            lon = -lon
            Tz = -Tz
        End If
        lat = (Math.Atan(Math.Tan(geoLat * Math.PI / 180) * 0.99330546)) * 180 / Math.PI
        If nS = "S" Then
            lat = -lat
        End If

        Dim StrPlace(3) As String
        StrPlace = Split(txtPlace.Text, "-")
        PlaceData.Add("Place", StrPlace(0))
        PlaceData.Add("State", StrPlace(1))
        PlaceData.Add("Country", StrPlace(2))

        PlaceData.Add("lonB", lon)
        PlaceData.Add("latB", lat)
        PlaceData.Add("eW", eW)
        PlaceData.Add("nS", nS)
        PlaceData.Add("TzB", Tz)
        PlaceData.Add("DstB", Val(txtDstHr.Text) + Val(txtDstMn.Text) / 60)
        frm.PlaceDataB = PlaceData
        frm.MdiParent = frmMain
        frmMain.MyChartForrms.Add(frm, frm.GetHashCode.ToString(Globalization.CultureInfo.InvariantCulture))
        frm.Show()
        Me.Close()
    End Sub

    Private Function tValidate() As Boolean
        If txtdd.Text = "" Or txtdd.Text = 0 Then
            tValidate = False
            MessageBox.Show("Please enter Date.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification)
            Exit Function
        End If
        If txtmm.Text = "" Or txtmm.Text = 0 Then
            tValidate = False
            MessageBox.Show("Please enter Month.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification)
            Exit Function
        End If
        If txtYear.Text = "" Or txtYear.Text = 0 Then
            tValidate = False
            MessageBox.Show("Please enter Year.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification)
            Exit Function
        End If
        If txtHr.Text = "" Then
            tValidate = False
            MessageBox.Show("Please enter Time.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification)
            Exit Function
        End If
        'If txtMin.Text = "" Then
        '    tValidate = False
        '    MessageBox.Show("Please enter Time.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error)
        '    Exit Function
        'End If
        'If txtSec.Text = "" Then
        '    tValidate = False
        '    Exit Function
        'End If
        If txtPlace.Text = "" Then
            tValidate = False
            MessageBox.Show("Please Select Place.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification)
            Exit Function
        End If
        If txtLong.Text = "" Then
            tValidate = False
            MessageBox.Show("Please Select Place.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification)
            Exit Function
        End If
        If txtLat.Text = "" Then
            tValidate = False
            MessageBox.Show("Please Select Place.", Me.Text, MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification)
            Exit Function
        End If
        Try
            Dim DateTest As Date = New Date(txtYear.Text, txtmm.Text, txtdd.Text)
        Catch ex As Exception
            MessageBox.Show("Wrong Date", " ", MessageBoxButtons.OK, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1, MessageBoxOptions.ServiceNotification)
            txtdd.Focus()
            tValidate = False
            Exit Function
        End Try
        tValidate = True
    End Function

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
        lstPlaceView.Columns.Clear()
        lstPlaceView.Clear()
        lstPlaceView.Columns.Add("", lstPlaceView.Size.Width, HorizontalAlignment.Left)
        While dreader.Read
            lstX = lstPlaceView.Items.Add(Convert.ToString(dreader("Place"), (Globalization.CultureInfo.InvariantCulture)) _
                   & " - " & Convert.ToString(IIf(IsDBNull(dreader("State")), "", dreader("State")), (Globalization.CultureInfo.InvariantCulture)) _
                   & " - " & Convert.ToString(IIf(IsDBNull(dreader("Country")), "", dreader("Country")), (Globalization.CultureInfo.InvariantCulture)) _
                   & " - " & dreader("LatDeg") & "° " & dreader("LatMin") & "' " & dreader("LatSec") & "'' " & dreader("NS") _
                   & " - " & dreader("LongDeg") & "° " & dreader("LongMin") & "' " & dreader("LongSec") & "'' " & dreader("EW"))
            lstX.SubItems.Add(dreader("LatLonID"))
        End While
        dreader.Close()
        uccon.Close()
    End Sub

    Private Sub txtPlace_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtPlace.KeyUp
        Dim strCondition As String = ""
        If e.KeyCode = 27 Then txtPlace.Text = ""
        lstPlaceView.Visible = True
        If strCondition = "" Then
            strCondition = "Place Like '" & txtPlace.Text.Replace("'", "''") & "%'"
        Else
            strCondition = "Place Like '" & txtPlace.Text.Replace("'", "''") & "%'"
        End If
        If txtPlace.TextLength > 2 Then
            FillList(strCondition)
        Else
            lstPlaceView.Items.Clear()
        End If
        If e.KeyCode = Keys.Tab And txtPlace.Text <> "" Then
            lstPlaceView.Visible = False
        End If
    End Sub

    Private Sub lstPlaceView_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstPlaceView.DoubleClick
        Dim p As Integer
        For p = lstPlaceView.Items.Count - 1 To 0 Step -1
            If lstPlaceView.SelectedIndices.Contains(p) Then
                txtPlace.Text = lstPlaceView.Items.Item(p).Text
                p_Id = lstPlaceView.Items.Item(p).SubItems(1).Text
            End If
        Next
        lstPlaceView.Visible = False
        GetParameter()
    End Sub

    Private Sub lstPlaceView_ItemActivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles lstPlaceView.ItemActivate
        Dim p As Integer
        For p = lstPlaceView.Items.Count - 1 To 0 Step -1
            If lstPlaceView.SelectedIndices.Contains(p) Then
                txtPlace.Text = lstPlaceView.Items.Item(p).Text
            End If
        Next
    End Sub

    Private Sub lstPlaceView_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles lstPlaceView.KeyUp
        If e.KeyCode = 27 Or e.KeyCode = 13 Then
            lstPlaceView.Visible = False
            txtPlace.Visible = True
            txtPlace.SelectionStart = txtPlace.Text.Length
        End If
    End Sub

    Private Sub GetParameter()
        Dim strSql As String
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
            txtPlace.Text = CStr(dreader("Place")) & " - " & IIf(IsDBNull(dreader("State")), "", dreader("State")) & " - " & IIf(IsDBNull(dreader("Country")), "", dreader("Country"))
            LongD = CInt(dreader("LongDeg"))
            LongM = CInt(dreader("LongMin"))
            LongS = CInt(dreader("LongSec"))
            eW = CStr(dreader("EW"))
            LatD = CInt(dreader("LatDeg"))
            LatM = CInt(dreader("LatMin"))
            LatS = CInt(dreader("LatSec"))
            nS = CStr(dreader("NS"))
            txtLong.Text = Format(LongD, "#00") & "- " & Format(LongM, "00") & "- " & Format(LongS, "00") & "- " & eW
            txtLat.Text = Format(LatD, "#00") & "- " & Format(LatM, "00") & "- " & Format(LatS, "00") & "- " & nS
            txtTzHr.Text = Format(Val(dreader("TimeZoneHour")), "00")
            txtTzMn.Text = Format(Val(dreader("TimeZoneMin")), "00")
            txtTzSec.Text = "00"
        End While
        dreader.Close()
        uccon.Close()
    End Sub

    Private Sub frmNewEdit_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        'Me.Dispose()
    End Sub

    Private Sub frmNewEdit_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        ClearForm()
        txtdd.Text = Now.Day
        txtmm.Text = Now.Month
        txtYear.Text = Now.Year
        txtHr.Text = Now.Hour
        txtMin.Text = Now.Minute
        txtSec.Text = Now.Second
        txtmSec.Text = Now.Millisecond
    End Sub

    Private Sub txtdd_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtdd.KeyPress
        If e.KeyChar = vbBack Or e.KeyChar = Chr(13) Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
            MsgBox("Please enter Date in numerals(0-9)", MsgBoxStyle.Information, Me.Text & "- Error")
        End If
    End Sub

    Private Sub txtdd_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtdd.KeyUp
        If CheckMaxLength(txtdd.MaxLength, txtdd.TextLength) = True Then
            txtmm.Focus()
            txtmm.SelectAll()
        Else : Exit Sub
            If txtdd.Text <> "" Then
                If dayValidate(txtdd.Text) = False Then
                    txtdd.Text = ""
                    txtdd.Focus()
                End If
            End If
        End If
    End Sub

    Private Sub txtHr_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHr.KeyPress
        If e.KeyChar = vbBack Or e.KeyChar = Chr(13) Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
            MsgBox("Please enter Hour in numerals(0-9)", MsgBoxStyle.Information, Me.Text & "- Error")
        End If
    End Sub

    Private Sub txtHr_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtHr.KeyUp
        If CheckMaxLength(txtHr.MaxLength, txtHr.TextLength) = True Then
            txtMin.Focus()
            txtMin.SelectAll()
        Else : Exit Sub
        End If
        If txtHr.Text <> "" Then
            If HourValidate(txtHr.Text) = False Then
                txtHr.Text = ""
                txtHr.Focus()
            End If
        End If
    End Sub

    Private Sub txtMin_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMin.KeyPress
        If e.KeyChar = vbBack Or e.KeyChar = Chr(13) Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
            MsgBox("Please enter Minutes in numerals(0-9)", MsgBoxStyle.Information, Me.Text & "- Error")
        End If
    End Sub

    Private Sub txtMin_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtMin.KeyUp
        If CheckMaxLength(txtMin.MaxLength, txtMin.TextLength) = True Then
            txtSec.Focus()
            txtSec.SelectAll()
        Else : Exit Sub
        End If
        If txtMin.Text <> "" Then
            If MinValidate(txtMin.Text) = False Then
                txtMin.Text = ""
                txtMin.Focus()
            End If
        End If
    End Sub

    Private Sub txtmm_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtmm.KeyPress
        If e.KeyChar = vbBack Or e.KeyChar = Chr(13) Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
            MsgBox("Please enter Month in numerals(0-9)", MsgBoxStyle.Information, Me.Text & "- Error")
        End If
    End Sub

    Private Sub txtmm_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtmm.KeyUp
        If CheckMaxLength(txtmm.MaxLength, txtmm.TextLength) = True Then
            txtYear.Focus()
            txtYear.SelectAll()
        Else : Exit Sub
        End If
        If txtmm.Text <> "" Then
            If monthValidate(txtmm.Text) = False Then
                txtmm.Text = ""
                txtmm.Focus()
            End If
        End If
    End Sub

    Private Sub txtYear_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtYear.KeyPress
        If e.KeyChar = vbBack Or e.KeyChar = Chr(13) Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
            MsgBox("Please enter Year in numerals(0-9)", MsgBoxStyle.Information, Me.Text & "- Error")
        End If
    End Sub

    Private Sub txtYear_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtYear.KeyUp
        If CheckMaxLength(txtYear.MaxLength, txtYear.TextLength) = True Then
            txtHr.Focus()
            txtHr.SelectAll()
        End If
    End Sub

    Private Sub txtSec_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtSec.KeyPress
        If e.KeyChar = vbBack Or e.KeyChar = Chr(13) Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
            MsgBox("Please enter Seconds in numerals(0-9)", MsgBoxStyle.Information, Me.Text & "- Error")
        End If
    End Sub

    Private Sub txtmSec_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtmSec.KeyPress
        If e.KeyChar = vbBack Or e.KeyChar = Chr(13) Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
            MsgBox("Please enter Seconds in numerals(0-9)", MsgBoxStyle.Information, Me.Text & "- Error")
        End If
    End Sub

    Private Sub txtSec_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtSec.KeyUp
        If CheckMaxLength(txtSec.MaxLength, txtSec.TextLength) = True Then
            txtmSec.Focus()
            txtmSec.SelectAll()
        Else : Exit Sub
        End If
        If txtSec.Text <> "" Then
            If MinValidate(txtSec.Text) = False Then
                txtSec.Text = ""
                txtSec.Focus()
            End If
        End If
    End Sub

    Private Sub txtmSec_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtmSec.KeyUp
        If CheckMaxLength(txtmSec.MaxLength, txtmSec.TextLength) = True Then
            txtPlace.Focus()
            txtPlace.SelectAll()
        Else : Exit Sub
        End If
        If txtmSec.Text <> "" Then
            If MiliValidate(txtmSec.Text) = False Then
                txtmSec.Text = ""
                txtmSec.Focus()
            End If
        End If
    End Sub

    Private Sub txtDstHr_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDstHr.KeyPress
        If e.KeyChar = vbBack Or e.KeyChar = Chr(13) Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
            MsgBox("Please enter Hours in numerals(0-9)", MsgBoxStyle.Information, Me.Text & "- Error")
        End If
    End Sub

    Private Sub txtDstMn_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtDstMn.KeyPress
        If e.KeyChar = vbBack Or e.KeyChar = Chr(13) Then Exit Sub
        If Not IsNumeric(e.KeyChar) Then
            e.Handled = True
            MsgBox("Please enter Minutes in numerals(0-9)", MsgBoxStyle.Information, Me.Text & "- Error")
        End If
    End Sub

    Private Sub txtDstHr_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDstHr.KeyUp
        If CheckMaxLength(txtDstHr.MaxLength, txtDstHr.TextLength) = True Then
            txtDstMn.Focus()
            txtDstMn.SelectAll()
        Else : Exit Sub
        End If
        If txtDstHr.Text <> "" Then
            If HourValidate(txtDstHr.Text) = False Then
                txtDstHr.Text = ""
                txtDstHr.Focus()
            End If
        End If
    End Sub

    Private Sub txtDstMn_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtDstMn.KeyUp
        If CheckMaxLength(txtDstMn.MaxLength, txtDstMn.TextLength) = True Then
            txtPlace.Focus()
            txtPlace.SelectAll()
        Else : Exit Sub
        End If
        If txtDstMn.Text <> "" Then
            If MinValidate(txtDstMn.Text) = False Then
                txtDstMn.Text = ""
                txtDstMn.Focus()
            End If
        End If
    End Sub
End Class