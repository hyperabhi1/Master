<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Transit
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.UID_TextBox = New System.Windows.Forms.TextBox()
        Me.UID_Label = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.HID_TextBox = New System.Windows.Forms.TextBox()
        Me.Planet_Label = New System.Windows.Forms.Label()
        Me.HRAKE_GridVw = New System.Windows.Forms.DataGridView()
        Me.HCUSP_CALC_UnEx_GridVw = New System.Windows.Forms.DataGridView()
        Me.HCUSP_CALC_Ex_GridVw = New System.Windows.Forms.DataGridView()
        Me.Get_All_Button = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Planet_List = New System.Windows.Forms.ComboBox()
        Me.CuspId_Button = New System.Windows.Forms.Button()
        Me.ExpandedCusps = New System.Windows.Forms.TextBox()
        Me.Un_ExpandedCusps = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        CType(Me.HRAKE_GridVw, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HCUSP_CALC_UnEx_GridVw, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HCUSP_CALC_Ex_GridVw, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'UID_TextBox
        '
        Me.UID_TextBox.Location = New System.Drawing.Point(44, 12)
        Me.UID_TextBox.Name = "UID_TextBox"
        Me.UID_TextBox.Size = New System.Drawing.Size(158, 20)
        Me.UID_TextBox.TabIndex = 0
        '
        'UID_Label
        '
        Me.UID_Label.AutoSize = True
        Me.UID_Label.Location = New System.Drawing.Point(12, 15)
        Me.UID_Label.Name = "UID_Label"
        Me.UID_Label.Size = New System.Drawing.Size(26, 13)
        Me.UID_Label.TabIndex = 1
        Me.UID_Label.Text = "UID"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(219, 15)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(26, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "HID"
        '
        'HID_TextBox
        '
        Me.HID_TextBox.Location = New System.Drawing.Point(251, 12)
        Me.HID_TextBox.Name = "HID_TextBox"
        Me.HID_TextBox.Size = New System.Drawing.Size(25, 20)
        Me.HID_TextBox.TabIndex = 3
        '
        'Planet_Label
        '
        Me.Planet_Label.AutoSize = True
        Me.Planet_Label.Location = New System.Drawing.Point(283, 15)
        Me.Planet_Label.Name = "Planet_Label"
        Me.Planet_Label.Size = New System.Drawing.Size(37, 13)
        Me.Planet_Label.TabIndex = 4
        Me.Planet_Label.Text = "Planet"
        '
        'HRAKE_GridVw
        '
        Me.HRAKE_GridVw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.HRAKE_GridVw.Location = New System.Drawing.Point(951, 27)
        Me.HRAKE_GridVw.Name = "HRAKE_GridVw"
        Me.HRAKE_GridVw.Size = New System.Drawing.Size(247, 77)
        Me.HRAKE_GridVw.TabIndex = 6
        '
        'HCUSP_CALC_UnEx_GridVw
        '
        Me.HCUSP_CALC_UnEx_GridVw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.HCUSP_CALC_UnEx_GridVw.Location = New System.Drawing.Point(844, 138)
        Me.HCUSP_CALC_UnEx_GridVw.Name = "HCUSP_CALC_UnEx_GridVw"
        Me.HCUSP_CALC_UnEx_GridVw.Size = New System.Drawing.Size(447, 197)
        Me.HCUSP_CALC_UnEx_GridVw.TabIndex = 9
        '
        'HCUSP_CALC_Ex_GridVw
        '
        Me.HCUSP_CALC_Ex_GridVw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.HCUSP_CALC_Ex_GridVw.Location = New System.Drawing.Point(844, 388)
        Me.HCUSP_CALC_Ex_GridVw.Name = "HCUSP_CALC_Ex_GridVw"
        Me.HCUSP_CALC_Ex_GridVw.Size = New System.Drawing.Size(447, 185)
        Me.HCUSP_CALC_Ex_GridVw.TabIndex = 11
        '
        'Get_All_Button
        '
        Me.Get_All_Button.Location = New System.Drawing.Point(776, 27)
        Me.Get_All_Button.Name = "Get_All_Button"
        Me.Get_All_Button.Size = New System.Drawing.Size(124, 53)
        Me.Get_All_Button.TabIndex = 13
        Me.Get_All_Button.Text = "Get All Tables"
        Me.Get_All_Button.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Location = New System.Drawing.Point(1052, 9)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(46, 15)
        Me.Label2.TabIndex = 14
        Me.Label2.Text = "HRAKE"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label3.Location = New System.Drawing.Point(1011, 116)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(147, 15)
        Me.Label3.TabIndex = 15
        Me.Label3.Text = "HCUSP_CALC Un Expanded"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label4.Location = New System.Drawing.Point(1011, 356)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(130, 15)
        Me.Label4.TabIndex = 16
        Me.Label4.Text = "HCUSP_CALC Expanded"
        '
        'Planet_List
        '
        Me.Planet_List.FormattingEnabled = True
        Me.Planet_List.Items.AddRange(New Object() {"JU", "SA", "RA", "KE", "ME", "VE", "SU", "MO", "MA"})
        Me.Planet_List.Location = New System.Drawing.Point(326, 12)
        Me.Planet_List.Name = "Planet_List"
        Me.Planet_List.Size = New System.Drawing.Size(36, 21)
        Me.Planet_List.TabIndex = 17
        '
        'CuspId_Button
        '
        Me.CuspId_Button.Location = New System.Drawing.Point(162, 57)
        Me.CuspId_Button.Name = "CuspId_Button"
        Me.CuspId_Button.Size = New System.Drawing.Size(145, 23)
        Me.CuspId_Button.TabIndex = 18
        Me.CuspId_Button.Text = "CUSPS"
        Me.CuspId_Button.UseVisualStyleBackColor = True
        '
        'ExpandedCusps
        '
        Me.ExpandedCusps.Location = New System.Drawing.Point(262, 116)
        Me.ExpandedCusps.Name = "ExpandedCusps"
        Me.ExpandedCusps.ReadOnly = True
        Me.ExpandedCusps.Size = New System.Drawing.Size(198, 20)
        Me.ExpandedCusps.TabIndex = 19
        '
        'Un_ExpandedCusps
        '
        Me.Un_ExpandedCusps.Location = New System.Drawing.Point(31, 116)
        Me.Un_ExpandedCusps.Name = "Un_ExpandedCusps"
        Me.Un_ExpandedCusps.ReadOnly = True
        Me.Un_ExpandedCusps.Size = New System.Drawing.Size(198, 20)
        Me.Un_ExpandedCusps.TabIndex = 20
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label5.Location = New System.Drawing.Point(81, 91)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(74, 15)
        Me.Label5.TabIndex = 21
        Me.Label5.Text = "Un-Expanded"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label6.Location = New System.Drawing.Point(323, 91)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(57, 15)
        Me.Label6.TabIndex = 22
        Me.Label6.Text = "Expanded"
        '
        'Transit
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1303, 586)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Un_ExpandedCusps)
        Me.Controls.Add(Me.ExpandedCusps)
        Me.Controls.Add(Me.CuspId_Button)
        Me.Controls.Add(Me.Planet_List)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Get_All_Button)
        Me.Controls.Add(Me.HCUSP_CALC_Ex_GridVw)
        Me.Controls.Add(Me.HCUSP_CALC_UnEx_GridVw)
        Me.Controls.Add(Me.HRAKE_GridVw)
        Me.Controls.Add(Me.Planet_Label)
        Me.Controls.Add(Me.HID_TextBox)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.UID_Label)
        Me.Controls.Add(Me.UID_TextBox)
        Me.Name = "Transit"
        Me.Text = "Document1"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.HRAKE_GridVw, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HCUSP_CALC_UnEx_GridVw, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HCUSP_CALC_Ex_GridVw, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents UID_TextBox As TextBox
    Friend WithEvents UID_Label As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents HID_TextBox As TextBox
    Friend WithEvents Planet_Label As Label
    Friend WithEvents HRAKE_GridVw As DataGridView
    Friend WithEvents HCUSP_CALC_UnEx_GridVw As DataGridView
    Friend WithEvents HCUSP_CALC_Ex_GridVw As DataGridView
    Friend WithEvents Get_All_Button As Button
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Planet_List As ComboBox
    Friend WithEvents CuspId_Button As Button
    Friend WithEvents ExpandedCusps As TextBox
    Friend WithEvents Un_ExpandedCusps As TextBox
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
End Class
