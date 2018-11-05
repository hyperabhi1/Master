<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTrLocator
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTrLocator))
        Me.btnCalculate = New System.Windows.Forms.Button()
        Me.lblStart = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.txtMonth = New System.Windows.Forms.TextBox()
        Me.txtYear = New System.Windows.Forms.TextBox()
        Me.lblSep1 = New System.Windows.Forms.Label()
        Me.lblSep2 = New System.Windows.Forms.Label()
        Me.txtDay = New System.Windows.Forms.TextBox()
        Me.Label45 = New System.Windows.Forms.Label()
        Me.Label49 = New System.Windows.Forms.Label()
        Me.lblDateAs = New System.Windows.Forms.Label()
        Me.lblTimeAs = New System.Windows.Forms.Label()
        Me.lblNotes = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblHorPlace = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.lblCombination = New System.Windows.Forms.Label()
        Me.btnPlace = New System.Windows.Forms.Button()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.cmbPra = New System.Windows.Forms.ComboBox()
        Me.cmbSuk = New System.Windows.Forms.ComboBox()
        Me.cmbSSL = New System.Windows.Forms.ComboBox()
        Me.cmbSub = New System.Windows.Forms.ComboBox()
        Me.cmbStl = New System.Windows.Forms.ComboBox()
        Me.cmbSgn = New System.Windows.Forms.ComboBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.cmbBody = New System.Windows.Forms.ComboBox()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.cmbSPra = New System.Windows.Forms.ComboBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.cmbSSPra = New System.Windows.Forms.ComboBox()
        Me.SuspendLayout()
        '
        'btnCalculate
        '
        Me.btnCalculate.AutoSize = True
        Me.btnCalculate.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.btnCalculate.Location = New System.Drawing.Point(676, 51)
        Me.btnCalculate.Name = "btnCalculate"
        Me.btnCalculate.Size = New System.Drawing.Size(74, 26)
        Me.btnCalculate.TabIndex = 28
        Me.btnCalculate.Text = "Calculate"
        Me.btnCalculate.UseVisualStyleBackColor = True
        '
        'lblStart
        '
        Me.lblStart.AutoSize = True
        Me.lblStart.ForeColor = System.Drawing.Color.Red
        Me.lblStart.Location = New System.Drawing.Point(582, 9)
        Me.lblStart.Name = "lblStart"
        Me.lblStart.Size = New System.Drawing.Size(67, 16)
        Me.lblStart.TabIndex = 19
        Me.lblStart.Text = "Start Date"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(630, 34)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(37, 16)
        Me.Label32.TabIndex = 25
        Me.Label32.Text = "Year"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(587, 34)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(44, 16)
        Me.Label31.TabIndex = 22
        Me.Label31.Text = "Month"
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(557, 34)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(33, 16)
        Me.Label30.TabIndex = 20
        Me.Label30.Text = "Day"
        '
        'txtMonth
        '
        Me.txtMonth.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMonth.Location = New System.Drawing.Point(594, 54)
        Me.txtMonth.MaxLength = 2
        Me.txtMonth.Name = "txtMonth"
        Me.txtMonth.Size = New System.Drawing.Size(24, 20)
        Me.txtMonth.TabIndex = 24
        Me.txtMonth.Text = "00"
        Me.txtMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtYear
        '
        Me.txtYear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtYear.Location = New System.Drawing.Point(630, 54)
        Me.txtYear.MaxLength = 4
        Me.txtYear.Name = "txtYear"
        Me.txtYear.Size = New System.Drawing.Size(35, 20)
        Me.txtYear.TabIndex = 27
        Me.txtYear.Text = "0000"
        Me.txtYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblSep1
        '
        Me.lblSep1.AutoSize = True
        Me.lblSep1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSep1.Location = New System.Drawing.Point(619, 58)
        Me.lblSep1.Name = "lblSep1"
        Me.lblSep1.Size = New System.Drawing.Size(10, 13)
        Me.lblSep1.TabIndex = 26
        Me.lblSep1.Text = "-"
        Me.lblSep1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSep2
        '
        Me.lblSep2.AutoSize = True
        Me.lblSep2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSep2.Location = New System.Drawing.Point(583, 58)
        Me.lblSep2.Name = "lblSep2"
        Me.lblSep2.Size = New System.Drawing.Size(10, 13)
        Me.lblSep2.TabIndex = 23
        Me.lblSep2.Text = "-"
        Me.lblSep2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtDay
        '
        Me.txtDay.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDay.Location = New System.Drawing.Point(557, 54)
        Me.txtDay.MaxLength = 2
        Me.txtDay.Name = "txtDay"
        Me.txtDay.Size = New System.Drawing.Size(24, 20)
        Me.txtDay.TabIndex = 21
        Me.txtDay.Text = "00"
        Me.txtDay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label45
        '
        Me.Label45.AutoSize = True
        Me.Label45.ForeColor = System.Drawing.Color.Red
        Me.Label45.Location = New System.Drawing.Point(12, 9)
        Me.Label45.Name = "Label45"
        Me.Label45.Size = New System.Drawing.Size(133, 16)
        Me.Label45.TabIndex = 0
        Me.Label45.Text = "Select a combination"
        '
        'Label49
        '
        Me.Label49.AutoSize = True
        Me.Label49.ForeColor = System.Drawing.Color.Red
        Me.Label49.Location = New System.Drawing.Point(767, 15)
        Me.Label49.Name = "Label49"
        Me.Label49.Size = New System.Drawing.Size(156, 16)
        Me.Label49.TabIndex = 29
        Me.Label49.Text = "Resultant Date and Time"
        '
        'lblDateAs
        '
        Me.lblDateAs.AutoSize = True
        Me.lblDateAs.Location = New System.Drawing.Point(767, 55)
        Me.lblDateAs.Name = "lblDateAs"
        Me.lblDateAs.Size = New System.Drawing.Size(72, 16)
        Me.lblDateAs.TabIndex = 30
        Me.lblDateAs.Text = "31/12/2008"
        '
        'lblTimeAs
        '
        Me.lblTimeAs.AutoSize = True
        Me.lblTimeAs.Location = New System.Drawing.Point(855, 55)
        Me.lblTimeAs.Name = "lblTimeAs"
        Me.lblTimeAs.Size = New System.Drawing.Size(56, 16)
        Me.lblTimeAs.TabIndex = 31
        Me.lblTimeAs.Text = "24:00:00"
        '
        'lblNotes
        '
        Me.lblNotes.ForeColor = System.Drawing.Color.DarkGreen
        Me.lblNotes.Location = New System.Drawing.Point(9, 191)
        Me.lblNotes.Name = "lblNotes"
        Me.lblNotes.Size = New System.Drawing.Size(276, 160)
        Me.lblNotes.TabIndex = 38
        Me.lblNotes.Text = "notes"
        '
        'Label1
        '
        Me.Label1.AutoEllipsis = True
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(541, 161)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(146, 16)
        Me.Label1.TabIndex = 35
        Me.Label1.Text = "Transit Locator for : "
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblHorPlace
        '
        Me.lblHorPlace.AutoEllipsis = True
        Me.lblHorPlace.AutoSize = True
        Me.lblHorPlace.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHorPlace.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblHorPlace.Location = New System.Drawing.Point(671, 161)
        Me.lblHorPlace.Name = "lblHorPlace"
        Me.lblHorPlace.Size = New System.Drawing.Size(0, 13)
        Me.lblHorPlace.TabIndex = 36
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(496, 97)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(168, 16)
        Me.Label2.TabIndex = 32
        Me.Label2.Text = "Combination Selected :"
        '
        'lblCombination
        '
        Me.lblCombination.AutoSize = True
        Me.lblCombination.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblCombination.ForeColor = System.Drawing.Color.Red
        Me.lblCombination.Location = New System.Drawing.Point(665, 97)
        Me.lblCombination.Name = "lblCombination"
        Me.lblCombination.Size = New System.Drawing.Size(55, 16)
        Me.lblCombination.TabIndex = 33
        Me.lblCombination.Text = "Label3"
        '
        'btnPlace
        '
        Me.btnPlace.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPlace.Location = New System.Drawing.Point(545, 187)
        Me.btnPlace.Name = "btnPlace"
        Me.btnPlace.Size = New System.Drawing.Size(105, 23)
        Me.btnPlace.TabIndex = 37
        Me.btnPlace.Text = "Place....."
        Me.btnPlace.UseVisualStyleBackColor = True
        '
        'Label26
        '
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.Red
        Me.Label26.Location = New System.Drawing.Point(535, 119)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(303, 35)
        Me.Label26.TabIndex = 34
        Me.Label26.Text = "If you want transit for any place other than Birth place then click the Place but" & _
    "ton below."
        '
        'cmbPra
        '
        Me.cmbPra.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbPra.FormattingEnabled = True
        Me.cmbPra.Items.AddRange(New Object() {"Ke", "Ve", "Su", "Mo", "Ma", "Ra", "Ju", "Sa", "Me"})
        Me.cmbPra.Location = New System.Drawing.Point(342, 53)
        Me.cmbPra.Name = "cmbPra"
        Me.cmbPra.Size = New System.Drawing.Size(50, 24)
        Me.cmbPra.TabIndex = 12
        '
        'cmbSuk
        '
        Me.cmbSuk.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSuk.FormattingEnabled = True
        Me.cmbSuk.Items.AddRange(New Object() {"Ke", "Ve", "Su", "Mo", "Ma", "Ra", "Ju", "Sa", "Me"})
        Me.cmbSuk.Location = New System.Drawing.Point(276, 53)
        Me.cmbSuk.Name = "cmbSuk"
        Me.cmbSuk.Size = New System.Drawing.Size(50, 24)
        Me.cmbSuk.TabIndex = 10
        '
        'cmbSSL
        '
        Me.cmbSSL.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSSL.FormattingEnabled = True
        Me.cmbSSL.Items.AddRange(New Object() {"Ke", "Ve", "Su", "Mo", "Ma", "Ra", "Ju", "Sa", "Me"})
        Me.cmbSSL.Location = New System.Drawing.Point(210, 53)
        Me.cmbSSL.Name = "cmbSSL"
        Me.cmbSSL.Size = New System.Drawing.Size(50, 24)
        Me.cmbSSL.TabIndex = 8
        '
        'cmbSub
        '
        Me.cmbSub.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSub.FormattingEnabled = True
        Me.cmbSub.Items.AddRange(New Object() {"Ke", "Ve", "Su", "Mo", "Ma", "Ra", "Ju", "Sa", "Me"})
        Me.cmbSub.Location = New System.Drawing.Point(144, 53)
        Me.cmbSub.Name = "cmbSub"
        Me.cmbSub.Size = New System.Drawing.Size(50, 24)
        Me.cmbSub.TabIndex = 6
        '
        'cmbStl
        '
        Me.cmbStl.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbStl.FormattingEnabled = True
        Me.cmbStl.Location = New System.Drawing.Point(78, 53)
        Me.cmbStl.Name = "cmbStl"
        Me.cmbStl.Size = New System.Drawing.Size(50, 24)
        Me.cmbStl.TabIndex = 4
        '
        'cmbSgn
        '
        Me.cmbSgn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSgn.FormattingEnabled = True
        Me.cmbSgn.Items.AddRange(New Object() {"Ari", "Tau", "Gem", "Can", "Leo", "Vir", "Lib", "Sco", "Sag", "Cap", "Aqu", "Pis"})
        Me.cmbSgn.Location = New System.Drawing.Point(12, 53)
        Me.cmbSgn.Name = "cmbSgn"
        Me.cmbSgn.Size = New System.Drawing.Size(60, 24)
        Me.cmbSgn.TabIndex = 2
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(13, 34)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(35, 16)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Sign"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(81, 34)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(32, 16)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Star"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(147, 34)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(32, 16)
        Me.Label5.TabIndex = 5
        Me.Label5.Text = "Sub"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(209, 34)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 16)
        Me.Label6.TabIndex = 7
        Me.Label6.Text = "Sub Sub"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(280, 34)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(31, 16)
        Me.Label7.TabIndex = 9
        Me.Label7.Text = "Suk"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(345, 34)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(44, 16)
        Me.Label10.TabIndex = 11
        Me.Label10.Text = "Prana"
        '
        'cmbBody
        '
        Me.cmbBody.FormattingEnabled = True
        Me.cmbBody.Items.AddRange(New Object() {"Asc", "Su", "Mo", "Ma", "Me", "Ju", "Ve", "Sa", "Ra", "Ke", "Ur", "Ne", "Pl"})
        Me.cmbBody.Location = New System.Drawing.Point(12, 132)
        Me.cmbBody.Name = "cmbBody"
        Me.cmbBody.Size = New System.Drawing.Size(78, 24)
        Me.cmbBody.TabIndex = 18
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.ForeColor = System.Drawing.Color.Red
        Me.Label11.Location = New System.Drawing.Point(12, 106)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(146, 16)
        Me.Label11.TabIndex = 17
        Me.Label11.Text = "Select Transiting Body "
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(413, 34)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(51, 16)
        Me.Label8.TabIndex = 13
        Me.Label8.Text = "sPrana"
        '
        'cmbSPra
        '
        Me.cmbSPra.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSPra.FormattingEnabled = True
        Me.cmbSPra.Items.AddRange(New Object() {"Ke", "Ve", "Su", "Mo", "Ma", "Ra", "Ju", "Sa", "Me"})
        Me.cmbSPra.Location = New System.Drawing.Point(410, 53)
        Me.cmbSPra.Name = "cmbSPra"
        Me.cmbSPra.Size = New System.Drawing.Size(50, 24)
        Me.cmbSPra.TabIndex = 14
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(476, 34)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(62, 16)
        Me.Label9.TabIndex = 15
        Me.Label9.Text = "SSPrana"
        '
        'cmbSSPra
        '
        Me.cmbSSPra.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbSSPra.FormattingEnabled = True
        Me.cmbSSPra.Items.AddRange(New Object() {"Ke", "Ve", "Su", "Mo", "Ma", "Ra", "Ju", "Sa", "Me"})
        Me.cmbSSPra.Location = New System.Drawing.Point(473, 53)
        Me.cmbSSPra.Name = "cmbSSPra"
        Me.cmbSSPra.Size = New System.Drawing.Size(50, 24)
        Me.cmbSSPra.TabIndex = 16
        '
        'frmTrLocator
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1035, 379)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.cmbSSPra)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.cmbSPra)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.cmbBody)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.cmbPra)
        Me.Controls.Add(Me.cmbSuk)
        Me.Controls.Add(Me.cmbSSL)
        Me.Controls.Add(Me.cmbSub)
        Me.Controls.Add(Me.cmbStl)
        Me.Controls.Add(Me.cmbSgn)
        Me.Controls.Add(Me.btnPlace)
        Me.Controls.Add(Me.Label26)
        Me.Controls.Add(Me.lblCombination)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.lblHorPlace)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblNotes)
        Me.Controls.Add(Me.lblTimeAs)
        Me.Controls.Add(Me.lblDateAs)
        Me.Controls.Add(Me.Label49)
        Me.Controls.Add(Me.Label45)
        Me.Controls.Add(Me.Label32)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.txtMonth)
        Me.Controls.Add(Me.txtYear)
        Me.Controls.Add(Me.lblSep1)
        Me.Controls.Add(Me.lblSep2)
        Me.Controls.Add(Me.txtDay)
        Me.Controls.Add(Me.lblStart)
        Me.Controls.Add(Me.btnCalculate)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTrLocator"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "True Astrology Software - Transit Locator"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents btnCalculate As System.Windows.Forms.Button
    Friend WithEvents lblStart As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents txtMonth As System.Windows.Forms.TextBox
    Friend WithEvents txtYear As System.Windows.Forms.TextBox
    Friend WithEvents lblSep1 As System.Windows.Forms.Label
    Friend WithEvents lblSep2 As System.Windows.Forms.Label
    Friend WithEvents txtDay As System.Windows.Forms.TextBox
    Friend WithEvents Label45 As System.Windows.Forms.Label
    Friend WithEvents Label49 As System.Windows.Forms.Label
    Friend WithEvents lblDateAs As System.Windows.Forms.Label
    Friend WithEvents lblTimeAs As System.Windows.Forms.Label
    Friend WithEvents lblNotes As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblHorPlace As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents lblCombination As System.Windows.Forms.Label
    Friend WithEvents btnPlace As System.Windows.Forms.Button
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents cmbPra As System.Windows.Forms.ComboBox
    Friend WithEvents cmbSuk As System.Windows.Forms.ComboBox
    Friend WithEvents cmbSSL As System.Windows.Forms.ComboBox
    Friend WithEvents cmbSub As System.Windows.Forms.ComboBox
    Friend WithEvents cmbStl As System.Windows.Forms.ComboBox
    Friend WithEvents cmbSgn As System.Windows.Forms.ComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents cmbBody As System.Windows.Forms.ComboBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents cmbSPra As System.Windows.Forms.ComboBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents cmbSSPra As System.Windows.Forms.ComboBox
End Class
