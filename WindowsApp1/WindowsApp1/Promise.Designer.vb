<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Promise
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
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.UIDTextBox = New System.Windows.Forms.TextBox()
        Me.HIDTextBox = New System.Windows.Forms.TextBox()
        Me.HCUSP_CALC_Button = New System.Windows.Forms.Button()
        Me.HCUSP_CALC_GridVw = New System.Windows.Forms.DataGridView()
        Me.Y1_Button = New System.Windows.Forms.Button()
        Me.Y1_GridVw = New System.Windows.Forms.DataGridView()
        Me.HPL_Button = New System.Windows.Forms.Button()
        Me.HPL_GridVw = New System.Windows.Forms.DataGridView()
        Me.HSS_Button = New System.Windows.Forms.Button()
        Me.HSS_GridVw = New System.Windows.Forms.DataGridView()
        Me.DRM_Button = New System.Windows.Forms.Button()
        Me.DRM_GridVw = New System.Windows.Forms.DataGridView()
        Me.Button1 = New System.Windows.Forms.Button()
        Me.CUSPID = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CUSPPLANET = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CUSPTYPE = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CUSPCAT = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.HCUSP_CALC_GridVw, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Y1_GridVw, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HPL_GridVw, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.HSS_GridVw, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DRM_GridVw, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(14, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(26, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "UID"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 42)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(26, 13)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "HID"
        '
        'UIDTextBox
        '
        Me.UIDTextBox.Location = New System.Drawing.Point(46, 13)
        Me.UIDTextBox.Name = "UIDTextBox"
        Me.UIDTextBox.Size = New System.Drawing.Size(153, 20)
        Me.UIDTextBox.TabIndex = 2
        '
        'HIDTextBox
        '
        Me.HIDTextBox.Location = New System.Drawing.Point(46, 39)
        Me.HIDTextBox.Name = "HIDTextBox"
        Me.HIDTextBox.Size = New System.Drawing.Size(29, 20)
        Me.HIDTextBox.TabIndex = 3
        '
        'HCUSP_CALC_Button
        '
        Me.HCUSP_CALC_Button.Location = New System.Drawing.Point(1020, 14)
        Me.HCUSP_CALC_Button.Name = "HCUSP_CALC_Button"
        Me.HCUSP_CALC_Button.Size = New System.Drawing.Size(145, 27)
        Me.HCUSP_CALC_Button.TabIndex = 4
        Me.HCUSP_CALC_Button.Text = "HCUSP_CALC"
        Me.HCUSP_CALC_Button.UseVisualStyleBackColor = True
        '
        'HCUSP_CALC_GridVw
        '
        Me.HCUSP_CALC_GridVw.AllowUserToAddRows = False
        Me.HCUSP_CALC_GridVw.AllowUserToDeleteRows = False
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.HCUSP_CALC_GridVw.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.HCUSP_CALC_GridVw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.HCUSP_CALC_GridVw.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.CUSPID, Me.CUSPPLANET, Me.CUSPTYPE, Me.CUSPCAT})
        Me.HCUSP_CALC_GridVw.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.HCUSP_CALC_GridVw.Location = New System.Drawing.Point(839, 55)
        Me.HCUSP_CALC_GridVw.Name = "HCUSP_CALC_GridVw"
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.HCUSP_CALC_GridVw.RowsDefaultCellStyle = DataGridViewCellStyle2
        Me.HCUSP_CALC_GridVw.Size = New System.Drawing.Size(455, 288)
        Me.HCUSP_CALC_GridVw.TabIndex = 6
        '
        'Y1_Button
        '
        Me.Y1_Button.Location = New System.Drawing.Point(574, 16)
        Me.Y1_Button.Name = "Y1_Button"
        Me.Y1_Button.Size = New System.Drawing.Size(75, 23)
        Me.Y1_Button.TabIndex = 5
        Me.Y1_Button.Text = "Y1"
        Me.Y1_Button.UseVisualStyleBackColor = True
        '
        'Y1_GridVw
        '
        Me.Y1_GridVw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.Y1_GridVw.Location = New System.Drawing.Point(443, 55)
        Me.Y1_GridVw.Name = "Y1_GridVw"
        Me.Y1_GridVw.Size = New System.Drawing.Size(351, 288)
        Me.Y1_GridVw.TabIndex = 6
        '
        'HPL_Button
        '
        Me.HPL_Button.Location = New System.Drawing.Point(123, 37)
        Me.HPL_Button.Name = "HPL_Button"
        Me.HPL_Button.Size = New System.Drawing.Size(166, 23)
        Me.HPL_Button.TabIndex = 7
        Me.HPL_Button.Text = "HCUSP_PROMISE_LINK"
        Me.HPL_Button.UseVisualStyleBackColor = True
        '
        'HPL_GridVw
        '
        Me.HPL_GridVw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.HPL_GridVw.Location = New System.Drawing.Point(49, 66)
        Me.HPL_GridVw.Name = "HPL_GridVw"
        Me.HPL_GridVw.Size = New System.Drawing.Size(365, 277)
        Me.HPL_GridVw.TabIndex = 8
        '
        'HSS_Button
        '
        Me.HSS_Button.Location = New System.Drawing.Point(101, 365)
        Me.HSS_Button.Name = "HSS_Button"
        Me.HSS_Button.Size = New System.Drawing.Size(135, 23)
        Me.HSS_Button.TabIndex = 9
        Me.HSS_Button.Text = "HCUSP_SIGN_SUB"
        Me.HSS_Button.UseVisualStyleBackColor = True
        '
        'HSS_GridVw
        '
        Me.HSS_GridVw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.HSS_GridVw.Location = New System.Drawing.Point(49, 394)
        Me.HSS_GridVw.Name = "HSS_GridVw"
        Me.HSS_GridVw.Size = New System.Drawing.Size(240, 265)
        Me.HSS_GridVw.TabIndex = 10
        '
        'DRM_Button
        '
        Me.DRM_Button.Location = New System.Drawing.Point(513, 365)
        Me.DRM_Button.Name = "DRM_Button"
        Me.DRM_Button.Size = New System.Drawing.Size(136, 23)
        Me.DRM_Button.TabIndex = 11
        Me.DRM_Button.Text = "DAILY_RULE_MAIN"
        Me.DRM_Button.UseVisualStyleBackColor = True
        '
        'DRM_GridVw
        '
        Me.DRM_GridVw.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DRM_GridVw.Location = New System.Drawing.Point(339, 394)
        Me.DRM_GridVw.Name = "DRM_GridVw"
        Me.DRM_GridVw.Size = New System.Drawing.Size(955, 265)
        Me.DRM_GridVw.TabIndex = 12
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(317, 4)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(113, 33)
        Me.Button1.TabIndex = 13
        Me.Button1.Text = "TRANSIT"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'CUSPID
        '
        Me.CUSPID.HeaderText = "CUSPID"
        Me.CUSPID.Name = "CUSPID"
        '
        'CUSPPLANET
        '
        Me.CUSPPLANET.HeaderText = "CUSPPLANET"
        Me.CUSPPLANET.MinimumWidth = 3
        Me.CUSPPLANET.Name = "CUSPPLANET"
        '
        'CUSPTYPE
        '
        Me.CUSPTYPE.HeaderText = "CUSPTYPE"
        Me.CUSPTYPE.MinimumWidth = 3
        Me.CUSPTYPE.Name = "CUSPTYPE"
        '
        'CUSPCAT
        '
        Me.CUSPCAT.HeaderText = "CUSPCAT"
        Me.CUSPCAT.MinimumWidth = 3
        Me.CUSPCAT.Name = "CUSPCAT"
        '
        'Form2
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1306, 703)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.DRM_GridVw)
        Me.Controls.Add(Me.DRM_Button)
        Me.Controls.Add(Me.HSS_GridVw)
        Me.Controls.Add(Me.HSS_Button)
        Me.Controls.Add(Me.HPL_GridVw)
        Me.Controls.Add(Me.HPL_Button)
        Me.Controls.Add(Me.Y1_GridVw)
        Me.Controls.Add(Me.Y1_Button)
        Me.Controls.Add(Me.HCUSP_CALC_GridVw)
        Me.Controls.Add(Me.HCUSP_CALC_Button)
        Me.Controls.Add(Me.HIDTextBox)
        Me.Controls.Add(Me.UIDTextBox)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Name = "Form2"
        Me.Text = "Form2"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        CType(Me.HCUSP_CALC_GridVw, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Y1_GridVw, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HPL_GridVw, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.HSS_GridVw, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DRM_GridVw, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents UIDTextBox As TextBox
    Friend WithEvents HIDTextBox As TextBox
    Friend WithEvents HCUSP_CALC_Button As Button
    Friend WithEvents HCUSP_CALC_GridVw As DataGridView
    Friend WithEvents Y1_Button As Button
    Friend WithEvents Y1_GridVw As DataGridView
    Friend WithEvents HPL_Button As Button
    Friend WithEvents HPL_GridVw As DataGridView
    Friend WithEvents HSS_Button As Button
    Friend WithEvents HSS_GridVw As DataGridView
    Friend WithEvents DRM_Button As Button
    Friend WithEvents DRM_GridVw As DataGridView
    Friend WithEvents Button1 As Button
    Friend WithEvents CUSPID As DataGridViewTextBoxColumn
    Friend WithEvents CUSPPLANET As DataGridViewTextBoxColumn
    Friend WithEvents CUSPTYPE As DataGridViewTextBoxColumn
    Friend WithEvents CUSPCAT As DataGridViewTextBoxColumn
End Class
