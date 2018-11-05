Imports System.Data.SqlClient

Public Class Promise
    Public constr = "data source=49.50.103.132;initial catalog=ASTROLOGYSOFTWARE_DB;integrated security=False;multipleactiveresultsets=True;User Id=sa;password=pSI)TA1t0K[);"
    Dim HCUSP_CALC_Tbl As DataTable
    Dim Y1_Tbl As DataTable
    Dim HPL_Tbl As DataTable
    Dim HSS_Tbl As DataTable
    Dim DRM_Tbl As DataTable
    Dim UID = ""
    Dim HID = ""
    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        HIDTextBox.Text = "1"
        UIDTextBox.Text = "vcdubai@gmail.com"
        'TextBoxHH.Text = "11"
        'TextBoxMM.Text = "00"
        'TextBoxSS.Text = "00"
        'TextBoxMS.Text = "000"
        Y1_Tbl = New DataTable
        'Y1_Tbl.Columns.Add("UID")
        'Y1_Tbl.Columns.Add("HID")
        Y1_Tbl.Columns.Add("FKEY")
        Y1_Tbl.Columns.Add("TKEY")
        Y1_Tbl.Columns.Add("PLANETS")


        HCUSP_CALC_Tbl = New DataTable
        'HCUSP_CALC_Tbl.Columns.Add("CUSPUSERID")
        ' HCUSP_CALC_Tbl.Columns.Add("CUSPHID")
        HCUSP_CALC_Tbl.Columns.Add("CUSPID")
        HCUSP_CALC_Tbl.Columns.Add("CUSPPLANET")
        HCUSP_CALC_Tbl.Columns.Add("CUSPTYPE")
        HCUSP_CALC_Tbl.Columns.Add("CUSPCAT")

        HPL_Tbl = New DataTable
        HPL_Tbl.Columns.Add("CUSPKEY")
        HPL_Tbl.Columns.Add("TCOUNT")
        HPL_Tbl.Columns.Add("SKEY")

        HSS_Tbl = New DataTable
        HSS_Tbl.Columns.Add("CUSP")
        HSS_Tbl.Columns.Add("PLANET")

        DRM_Tbl = New DataTable
        DRM_Tbl.Columns.Add("MAIN")
        DRM_Tbl.Columns.Add("S1")
        DRM_Tbl.Columns.Add("S2")
        DRM_Tbl.Columns.Add("S3")
        DRM_Tbl.Columns.Add("S4")
        DRM_Tbl.Columns.Add("S5")
        DRM_Tbl.Columns.Add("S6")
        DRM_Tbl.Columns.Add("RULESID")
        DRM_Tbl.Columns.Add("CCOUNT")
        DRM_Tbl.Columns.Add("DESCRIPTION")
        DRM_Tbl.Columns.Add("RTOTAL")
        DRM_Tbl.Columns.Add("FREQ")
        DRM_Tbl.Columns.Add("CATEGORY")
    End Sub
    Private Sub HCUSP_CALC_Button_Click(sender As Object, e As EventArgs) Handles HCUSP_CALC_Button.Click
        UID = UIDTextBox.Text
        HID = HIDTextBox.Text
        HCUSP_CALC_Tbl.Clear()
        Dim connection As SqlConnection = New SqlConnection(constr)
        connection.Open()
        Dim cmd As New SqlCommand($"select * from HEADLETTERS_ENGINE.DBO.HCUSP_CALC WHERE CUSPUSERID = '" + UID + "' AND CUSPHID = '" + HID + "';", connection)
        Dim da As New SqlDataAdapter(cmd)
        Dim RowsData As New DataSet()

        da.Fill(RowsData)
        If RowsData.Tables(0).Rows.Count > 0 Then
            For Each row As DataRow In RowsData.Tables(0).Rows
                HCUSP_CALC_Tbl.Rows.Add(New Object() {row.Item(2).ToString().Trim, row.Item(3).ToString().Trim, row.Item(4).ToString().Trim, row.Item(5).ToString().Trim})
            Next
        Else
            MessageBox.Show("There is no HCUSP_CALC for this user.")
            Return
        End If
        HCUSP_CALC_GridVw.DataSource = HCUSP_CALC_Tbl
        If HCUSP_CALC_Tbl.Rows.Count > 0 Then
            Dim cell As Windows.Forms.DataGridViewCell = HCUSP_CALC_GridVw.Rows(0).Cells(0)
            HCUSP_CALC_GridVw.CurrentCell = cell


        End If
        connection.Close()
    End Sub

    Private Sub Y1_Button_Click(sender As Object, e As EventArgs) Handles Y1_Button.Click
        UID = UIDTextBox.Text
        HID = HIDTextBox.Text
        Y1_Tbl.Clear()
        Dim connection As SqlConnection = New SqlConnection(constr)
        connection.Open()
        Dim cmd As New SqlCommand($"select * from HEADLETTERS_ENGINE.DBO.Y1 WHERE UID = '" + UID + "' AND HID = '" + HID + "';", connection)
        Dim da As New SqlDataAdapter(cmd)
        Dim RowsData As New DataSet()

        da.Fill(RowsData)
        If RowsData.Tables(0).Rows.Count > 0 Then
            For Each row As DataRow In RowsData.Tables(0).Rows
                Y1_Tbl.Rows.Add(New Object() {row.Item(2).ToString().Trim, row.Item(3).ToString().Trim, row.Item(4).ToString().Trim})
            Next
        Else
            MessageBox.Show("There is no Y1 for this user.")
            Return
        End If
        Y1_GridVw.DataSource = Y1_Tbl
        If Y1_Tbl.Rows.Count > 0 Then
            Dim cell As Windows.Forms.DataGridViewCell = Y1_GridVw.Rows(0).Cells(0)
            Y1_GridVw.CurrentCell = cell


        End If
        connection.Close()
    End Sub

    Private Sub HPL_Button_Click(sender As Object, e As EventArgs) Handles HPL_Button.Click
        UID = UIDTextBox.Text
        HID = HIDTextBox.Text
        HPL_Tbl.Clear()
        Dim connection As SqlConnection = New SqlConnection(constr)
        connection.Open()
        Dim cmd As New SqlCommand($"select * from HEADLETTERS_ENGINE.DBO.HCUSP_PROMISE_LINK WHERE UID = '" + UID + "' AND HID = '" + HID + "';", connection)
        Dim da As New SqlDataAdapter(cmd)
        Dim RowsData As New DataSet()

        da.Fill(RowsData)
        If RowsData.Tables(0).Rows.Count > 0 Then
            For Each row As DataRow In RowsData.Tables(0).Rows
                HPL_Tbl.Rows.Add(New Object() {row.Item(2).ToString().Trim, row.Item(4).ToString().Trim, row.Item(3).ToString().Trim})
            Next
        Else
            MessageBox.Show("There is no Y1 for this user.")
            Return
        End If
        HPL_GridVw.DataSource = HPL_Tbl
        If HPL_Tbl.Rows.Count > 0 Then
            Dim cell As Windows.Forms.DataGridViewCell = HPL_GridVw.Rows(0).Cells(0)
            HPL_GridVw.CurrentCell = cell


        End If
        connection.Close()
    End Sub

    Private Sub HSS_Button_Click(sender As Object, e As EventArgs) Handles HSS_Button.Click
        UID = UIDTextBox.Text
        HID = HIDTextBox.Text
        HSS_Tbl.Clear()
        Dim connection As SqlConnection = New SqlConnection(constr)
        connection.Open()
        Dim cmd As New SqlCommand($"select * from HEADLETTERS_ENGINE.DBO.HCUSP_PROMISE_LINK WHERE UID = '" + UID + "' AND HID = '" + HID + "';", connection)
        Dim da As New SqlDataAdapter(cmd)
        Dim RowsData As New DataSet()

        da.Fill(RowsData)
        If RowsData.Tables(0).Rows.Count > 0 Then
            For Each row As DataRow In RowsData.Tables(0).Rows
                HSS_Tbl.Rows.Add(New Object() {row.Item(2).ToString().Trim, row.Item(3).ToString().Trim})
            Next
        Else
            MessageBox.Show("There is no HCUSP SIGN SUB for this user.")
            Return
        End If
        HSS_GridVw.DataSource = HSS_Tbl
        If HSS_Tbl.Rows.Count > 0 Then
            Dim cell As Windows.Forms.DataGridViewCell = HSS_GridVw.Rows(0).Cells(0)
            HSS_GridVw.CurrentCell = cell


        End If
        connection.Close()
    End Sub


    Private Sub DRM_Button_Click(sender As Object, e As EventArgs) Handles DRM_Button.Click
        UID = UIDTextBox.Text
        HID = HIDTextBox.Text
        DRM_Tbl.Clear()
        Dim connection As SqlConnection = New SqlConnection(constr)
        connection.Open()
        Dim cmd As New SqlCommand($"select * from HEADLETTERS_ENGINE.DBO.DAILY_RULES_MAIN WHERE UID = '" + UID + "' AND HID = '" + HID + "';", connection)
        Dim da As New SqlDataAdapter(cmd)
        Dim RowsData As New DataSet()

        da.Fill(RowsData)
        If RowsData.Tables(0).Rows.Count > 0 Then
            For Each row As DataRow In RowsData.Tables(0).Rows
                DRM_Tbl.Rows.Add(New Object() {row.Item(2).ToString(), row.Item(3).ToString(), row.Item(4).ToString(), row.Item(5).ToString(), row.Item(6).ToString(), row.Item(7).ToString(), row.Item(8).ToString(), row.Item(9).ToString(), row.Item(10).ToString(), row.Item(11).ToString(), row.Item(12).ToString(), row.Item(13).ToString(), row.Item(14).ToString()})
            Next
        Else
            MessageBox.Show("There is no DAILY RULES MAIN for this user.")
            Return
        End If
        DRM_GridVw.DataSource = DRM_Tbl
        If DRM_Tbl.Rows.Count > 0 Then
            Dim cell As Windows.Forms.DataGridViewCell = DRM_GridVw.Rows(0).Cells(0)
            DRM_GridVw.CurrentCell = cell


        End If
        connection.Close()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim f2 As New Promise
        f2.Hide()
        Dim DOc As New Transit
        DOc.Show()
    End Sub
End Class