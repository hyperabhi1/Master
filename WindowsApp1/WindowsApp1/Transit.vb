Imports CommonDLL

Public Class Transit
    Dim HRAKE_Tbl As New DataTable
    Dim HCUSP_CALC_Ex_Tbl As New DataTable
    Dim HCUSP_CALC_UnEx_Tbl As New DataTable
    Private Sub Document1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        HID_TextBox.Text = "1"
        UID_TextBox.Text = "vcdubai@gmail.com"
        Planet_List.Text = "JU"
        GetAllTables()
    End Sub

    Private Sub Get_All_Button_Click(sender As Object, e As EventArgs) Handles Get_All_Button.Click
        HRAKE_Tbl.Clear()
        HRAKE_Tbl = CommonController.ConvertListToDataTable(DBController.Select_From_HRAKE(UID_TextBox.Text, HID_TextBox.Text))
        HRAKE_Tbl.Columns.Remove("UID")
        HRAKE_Tbl.Columns.Remove("HID")
        HRAKE_GridVw.DataSource = HRAKE_Tbl
        If HRAKE_Tbl.Rows.Count > 0 Then
            Dim cell As Windows.Forms.DataGridViewCell = HRAKE_GridVw.Rows(0).Cells(0)
            HRAKE_GridVw.CurrentCell = cell
        End If

        HCUSP_CALC_UnEx_Tbl.Clear()
        HCUSP_CALC_UnEx_Tbl = CommonController.ConvertListToDataTable(DBController.Select_HCUSP_CALC_UnExpanded(UID_TextBox.Text, HID_TextBox.Text))
        HCUSP_CALC_UnEx_Tbl.Columns.Remove("CUSPUSERID")
        HCUSP_CALC_UnEx_Tbl.Columns.Remove("CUSPHID")
        HCUSP_CALC_UnEx_GridVw.DataSource = HCUSP_CALC_UnEx_Tbl
        If HCUSP_CALC_UnEx_Tbl.Rows.Count > 0 Then
            Dim cell As Windows.Forms.DataGridViewCell = HCUSP_CALC_UnEx_GridVw.Rows(0).Cells(0)
            HCUSP_CALC_UnEx_GridVw.CurrentCell = cell
        End If

        HCUSP_CALC_Ex_Tbl.Clear()
        HCUSP_CALC_Ex_Tbl = CommonController.ConvertListToDataTable(DBController.Select_HCUSP_CALC_Expanded(UID_TextBox.Text, HID_TextBox.Text))
        HCUSP_CALC_Ex_Tbl.Columns.Remove("CUSPUSERID")
        HCUSP_CALC_Ex_Tbl.Columns.Remove("CUSPHID")
        HCUSP_CALC_Ex_GridVw.DataSource = HCUSP_CALC_Ex_Tbl
        If HCUSP_CALC_Ex_Tbl.Rows.Count > 0 Then
            Dim cell As Windows.Forms.DataGridViewCell = HCUSP_CALC_Ex_GridVw.Rows(0).Cells(0)
            HCUSP_CALC_Ex_GridVw.CurrentCell = cell
        End If
    End Sub

    Sub GetAllTables()
        HRAKE_Tbl.Clear()
        HRAKE_Tbl = CommonController.ConvertListToDataTable(DBController.Select_From_HRAKE(UID_TextBox.Text, HID_TextBox.Text))
        HRAKE_Tbl.Columns.Remove("UID")
        HRAKE_Tbl.Columns.Remove("HID")
        HRAKE_GridVw.DataSource = HRAKE_Tbl
        If HRAKE_Tbl.Rows.Count > 0 Then
            Dim cell As Windows.Forms.DataGridViewCell = HRAKE_GridVw.Rows(0).Cells(0)
            HRAKE_GridVw.CurrentCell = cell
        End If

        HCUSP_CALC_UnEx_Tbl.Clear()
        HCUSP_CALC_UnEx_Tbl = CommonController.ConvertListToDataTable(DBController.Select_HCUSP_CALC_UnExpanded(UID_TextBox.Text, HID_TextBox.Text))
        HCUSP_CALC_UnEx_Tbl.Columns.Remove("CUSPUSERID")
        HCUSP_CALC_UnEx_Tbl.Columns.Remove("CUSPHID")
        HCUSP_CALC_UnEx_GridVw.DataSource = HCUSP_CALC_UnEx_Tbl
        If HCUSP_CALC_UnEx_Tbl.Rows.Count > 0 Then
            Dim cell As Windows.Forms.DataGridViewCell = HCUSP_CALC_UnEx_GridVw.Rows(0).Cells(0)
            HCUSP_CALC_UnEx_GridVw.CurrentCell = cell
        End If

        HCUSP_CALC_Ex_Tbl.Clear()
        HCUSP_CALC_Ex_Tbl = CommonController.ConvertListToDataTable(DBController.Select_HCUSP_CALC_Expanded(UID_TextBox.Text, HID_TextBox.Text))
        HCUSP_CALC_Ex_Tbl.Columns.Remove("CUSPUSERID")
        HCUSP_CALC_Ex_Tbl.Columns.Remove("CUSPHID")
        HCUSP_CALC_Ex_GridVw.DataSource = HCUSP_CALC_Ex_Tbl
        If HCUSP_CALC_Ex_Tbl.Rows.Count > 0 Then
            Dim cell As Windows.Forms.DataGridViewCell = HCUSP_CALC_Ex_GridVw.Rows(0).Cells(0)
            HCUSP_CALC_Ex_GridVw.CurrentCell = cell
        End If
    End Sub
    Private Sub CuspId_Button_Click(sender As Object, e As EventArgs) Handles CuspId_Button.Click
        Un_ExpandedCusps.Text = ""
        ExpandedCusps.Text = ""
        Dim ExCUsps = ""
        Dim UnExCUsps = ""
        Dim HRAKE As New DataTable
        Dim ExPLs = ""

        If Planet_List.Text = "RA" Then
            Dim Cusps_UnExpanded = DBController.Select_HCUSP_CALC_UnExpanded(UID_TextBox.Text, HID_TextBox.Text, Planet_List.Text)
            For Each HCUSPCALC As HCUSP_CALC In Cusps_UnExpanded
                UnExCUsps = UnExCUsps + "-" + HCUSPCALC.CUSPID
            Next
            HRAKE = CommonController.ConvertListToDataTable(DBController.Select_From_HRAKE(UID_TextBox.Text, HID_TextBox.Text))
            ExPLs = ExPLs + HRAKE.Rows(0)(3)
            Dim PlanetArray = CommonController.SplitInTwoChar(ExPLs)
            For i = 0 To PlanetArray.Length - 1
                Dim Cusps_Expanded = DBController.Select_HCUSP_CALC_Expanded(UID_TextBox.Text, HID_TextBox.Text, PlanetArray(i))
                For Each HCUSPCALC As HCUSP_CALC In Cusps_Expanded
                    ExCUsps = ExCUsps + "-" + HCUSPCALC.CUSPID
                Next
            Next
            UnExCUsps = String.Join("", UnExCUsps.Split("-").Distinct.ToArray())
            ExCUsps = String.Join("", ExCUsps.Split("-").Distinct.ToArray())
            Un_ExpandedCusps.Text = UnExCUsps
            ExpandedCusps.Text = ExCUsps
        ElseIf Planet_List.Text = "KE" Then
            Dim Cusps_UnExpanded = DBController.Select_HCUSP_CALC_UnExpanded(UID_TextBox.Text, HID_TextBox.Text, Planet_List.Text)
            For Each HCUSPCALC As HCUSP_CALC In Cusps_UnExpanded
                UnExCUsps = UnExCUsps + "-" + HCUSPCALC.CUSPID
            Next
            HRAKE = CommonController.ConvertListToDataTable(DBController.Select_From_HRAKE(UID_TextBox.Text, HID_TextBox.Text))
            ExPLs = ExPLs + HRAKE.Rows(1)(3)
            Dim PlanetArray = CommonController.SplitInTwoChar(ExPLs)
            For i = 0 To PlanetArray.Length - 1
                Dim Cusps_Expanded = DBController.Select_HCUSP_CALC_Expanded(UID_TextBox.Text, HID_TextBox.Text, PlanetArray(i))
                For Each HCUSPCALC As HCUSP_CALC In Cusps_Expanded
                    ExCUsps = ExCUsps + "-" + HCUSPCALC.CUSPID
                Next
            Next
            UnExCUsps = String.Join("", UnExCUsps.Split("-").Distinct.ToArray())
            ExCUsps = String.Join("", ExCUsps.Split("-").Distinct.ToArray())
            Un_ExpandedCusps.Text = UnExCUsps
            ExpandedCusps.Text = ExCUsps
        Else
            Dim Cusps_Expanded = DBController.Select_HCUSP_CALC_UnExpanded(UID_TextBox.Text, HID_TextBox.Text, Planet_List.Text)
            For Each HCUSPCALC As HCUSP_CALC In Cusps_Expanded
                UnExCUsps = UnExCUsps + "-" + HCUSPCALC.CUSPID
            Next
            UnExCUsps = String.Join("", UnExCUsps.Split("-").Distinct.ToArray())
            Un_ExpandedCusps.Text = UnExCUsps
        End If
    End Sub
End Class