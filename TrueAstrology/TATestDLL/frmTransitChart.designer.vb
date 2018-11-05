<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTransitChart
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
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle4 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle5 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmTransitChart))
        Me.Label1 = New System.Windows.Forms.Label()
        Me.pcLagna = New System.Windows.Forms.PictureBox()
        Me.lblPlPo = New System.Windows.Forms.Label()
        Me.txtLat = New System.Windows.Forms.TextBox()
        Me.lblLat = New System.Windows.Forms.Label()
        Me.txtLong = New System.Windows.Forms.TextBox()
        Me.lblLong = New System.Windows.Forms.Label()
        Me.lblhm2 = New System.Windows.Forms.Label()
        Me.txtDstHr = New System.Windows.Forms.TextBox()
        Me.lblWT = New System.Windows.Forms.Label()
        Me.lblhm1 = New System.Windows.Forms.Label()
        Me.txtTzHr = New System.Windows.Forms.TextBox()
        Me.lblTZ = New System.Windows.Forms.Label()
        Me.txtPlaceD = New System.Windows.Forms.TextBox()
        Me.txtMonth1 = New System.Windows.Forms.TextBox()
        Me.txtYear1 = New System.Windows.Forms.TextBox()
        Me.lblSep1 = New System.Windows.Forms.Label()
        Me.lblSep2 = New System.Windows.Forms.Label()
        Me.txtDay1 = New System.Windows.Forms.TextBox()
        Me.txtHr1 = New System.Windows.Forms.TextBox()
        Me.txtMin1 = New System.Windows.Forms.TextBox()
        Me.txtSec1 = New System.Windows.Forms.TextBox()
        Me.btnCal1 = New System.Windows.Forms.Button()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.txtState = New System.Windows.Forms.TextBox()
        Me.txtCountry = New System.Windows.Forms.TextBox()
        Me.Label25 = New System.Windows.Forms.Label()
        Me.Label26 = New System.Windows.Forms.Label()
        Me.Label27 = New System.Windows.Forms.Label()
        Me.Label28 = New System.Windows.Forms.Label()
        Me.Label29 = New System.Windows.Forms.Label()
        Me.Label30 = New System.Windows.Forms.Label()
        Me.Label31 = New System.Windows.Forms.Label()
        Me.Label32 = New System.Windows.Forms.Label()
        Me.Label33 = New System.Windows.Forms.Label()
        Me.Label34 = New System.Windows.Forms.Label()
        Me.Label35 = New System.Windows.Forms.Label()
        Me.btnPlace = New System.Windows.Forms.Button()
        Me.Label36 = New System.Windows.Forms.Label()
        Me.lblToday = New System.Windows.Forms.Label()
        Me.lblWday = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.DgDasa = New System.Windows.Forms.DataGridView()
        Me.lbltithi = New System.Windows.Forms.Label()
        Me.DgPl = New System.Windows.Forms.DataGridView()
        Me.PictureBoxS = New System.Windows.Forms.PictureBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.txtmSec = New System.Windows.Forms.TextBox()
        Me.Planet = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.plSgnC = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pDMS = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.pRL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.plSTLc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.plSLc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PlSSLc = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.H_SukL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.H_PraL = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgPlSPra = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.dgSSP = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.PDirn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        CType(Me.pcLagna, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DgDasa, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DgPl, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBoxS, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Blue
        Me.Label1.Location = New System.Drawing.Point(6, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(383, 13)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "TRANSIT RASHI CHART"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'pcLagna
        '
        Me.pcLagna.BackColor = System.Drawing.Color.White
        Me.pcLagna.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.pcLagna.Enabled = False
        Me.pcLagna.Location = New System.Drawing.Point(5, 23)
        Me.pcLagna.Margin = New System.Windows.Forms.Padding(0)
        Me.pcLagna.Name = "pcLagna"
        Me.pcLagna.Size = New System.Drawing.Size(425, 222)
        Me.pcLagna.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.pcLagna.TabIndex = 94
        Me.pcLagna.TabStop = False
        '
        'lblPlPo
        '
        Me.lblPlPo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblPlPo.ForeColor = System.Drawing.Color.Blue
        Me.lblPlPo.Location = New System.Drawing.Point(5, 246)
        Me.lblPlPo.Name = "lblPlPo"
        Me.lblPlPo.Size = New System.Drawing.Size(384, 16)
        Me.lblPlPo.TabIndex = 31
        Me.lblPlPo.Text = "TRANSIT PLANETARY POSITIONS"
        Me.lblPlPo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtLat
        '
        Me.txtLat.BackColor = System.Drawing.SystemColors.Window
        Me.txtLat.Enabled = False
        Me.txtLat.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLat.Location = New System.Drawing.Point(93, 194)
        Me.txtLat.Name = "txtLat"
        Me.txtLat.ReadOnly = True
        Me.txtLat.Size = New System.Drawing.Size(219, 21)
        Me.txtLat.TabIndex = 43
        Me.txtLat.TabStop = False
        '
        'lblLat
        '
        Me.lblLat.AutoSize = True
        Me.lblLat.Location = New System.Drawing.Point(46, 199)
        Me.lblLat.Name = "lblLat"
        Me.lblLat.Size = New System.Drawing.Size(45, 13)
        Me.lblLat.TabIndex = 42
        Me.lblLat.Text = "Latitude"
        Me.lblLat.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtLong
        '
        Me.txtLong.BackColor = System.Drawing.SystemColors.Window
        Me.txtLong.Enabled = False
        Me.txtLong.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLong.Location = New System.Drawing.Point(93, 165)
        Me.txtLong.Name = "txtLong"
        Me.txtLong.ReadOnly = True
        Me.txtLong.Size = New System.Drawing.Size(219, 21)
        Me.txtLong.TabIndex = 41
        Me.txtLong.TabStop = False
        '
        'lblLong
        '
        Me.lblLong.AutoSize = True
        Me.lblLong.Location = New System.Drawing.Point(37, 169)
        Me.lblLong.Name = "lblLong"
        Me.lblLong.Size = New System.Drawing.Size(54, 13)
        Me.lblLong.TabIndex = 40
        Me.lblLong.Text = "Longitude"
        Me.lblLong.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblhm2
        '
        Me.lblhm2.AutoSize = True
        Me.lblhm2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblhm2.Location = New System.Drawing.Point(170, 254)
        Me.lblhm2.Name = "lblhm2"
        Me.lblhm2.Size = New System.Drawing.Size(34, 15)
        Me.lblhm2.TabIndex = 53
        Me.lblhm2.Text = "(Hrs)"
        '
        'txtDstHr
        '
        Me.txtDstHr.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDstHr.Location = New System.Drawing.Point(93, 251)
        Me.txtDstHr.MaxLength = 2
        Me.txtDstHr.Name = "txtDstHr"
        Me.txtDstHr.Size = New System.Drawing.Size(76, 21)
        Me.txtDstHr.TabIndex = 50
        Me.txtDstHr.Text = "0"
        Me.txtDstHr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtDstHr.WordWrap = False
        '
        'lblWT
        '
        Me.lblWT.AutoSize = True
        Me.lblWT.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWT.Location = New System.Drawing.Point(4, 254)
        Me.lblWT.Name = "lblWT"
        Me.lblWT.Size = New System.Drawing.Size(87, 15)
        Me.lblWT.TabIndex = 49
        Me.lblWT.Text = "War Time/DST"
        Me.lblWT.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblhm1
        '
        Me.lblhm1.AutoSize = True
        Me.lblhm1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblhm1.Location = New System.Drawing.Point(172, 225)
        Me.lblhm1.Name = "lblhm1"
        Me.lblhm1.Size = New System.Drawing.Size(34, 15)
        Me.lblhm1.TabIndex = 48
        Me.lblhm1.Text = "(Hrs)"
        '
        'txtTzHr
        '
        Me.txtTzHr.BackColor = System.Drawing.SystemColors.Window
        Me.txtTzHr.Enabled = False
        Me.txtTzHr.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTzHr.Location = New System.Drawing.Point(93, 222)
        Me.txtTzHr.MaxLength = 2
        Me.txtTzHr.Name = "txtTzHr"
        Me.txtTzHr.ReadOnly = True
        Me.txtTzHr.Size = New System.Drawing.Size(76, 21)
        Me.txtTzHr.TabIndex = 45
        Me.txtTzHr.TabStop = False
        Me.txtTzHr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblTZ
        '
        Me.lblTZ.AutoSize = True
        Me.lblTZ.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTZ.Location = New System.Drawing.Point(25, 225)
        Me.lblTZ.Name = "lblTZ"
        Me.lblTZ.Size = New System.Drawing.Size(66, 15)
        Me.lblTZ.TabIndex = 44
        Me.lblTZ.Text = "Time Zone"
        Me.lblTZ.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtPlaceD
        '
        Me.txtPlaceD.BackColor = System.Drawing.SystemColors.Window
        Me.txtPlaceD.Enabled = False
        Me.txtPlaceD.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPlaceD.Location = New System.Drawing.Point(93, 82)
        Me.txtPlaceD.Name = "txtPlaceD"
        Me.txtPlaceD.ReadOnly = True
        Me.txtPlaceD.Size = New System.Drawing.Size(219, 21)
        Me.txtPlaceD.TabIndex = 35
        '
        'txtMonth1
        '
        Me.txtMonth1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMonth1.Location = New System.Drawing.Point(41, 532)
        Me.txtMonth1.MaxLength = 2
        Me.txtMonth1.Name = "txtMonth1"
        Me.txtMonth1.Size = New System.Drawing.Size(24, 20)
        Me.txtMonth1.TabIndex = 62
        Me.txtMonth1.Text = "00"
        Me.txtMonth1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtYear1
        '
        Me.txtYear1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtYear1.Location = New System.Drawing.Point(80, 532)
        Me.txtYear1.MaxLength = 4
        Me.txtYear1.Name = "txtYear1"
        Me.txtYear1.Size = New System.Drawing.Size(35, 20)
        Me.txtYear1.TabIndex = 64
        Me.txtYear1.Text = "0000"
        Me.txtYear1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblSep1
        '
        Me.lblSep1.AutoSize = True
        Me.lblSep1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSep1.Location = New System.Drawing.Point(66, 535)
        Me.lblSep1.Name = "lblSep1"
        Me.lblSep1.Size = New System.Drawing.Size(10, 13)
        Me.lblSep1.TabIndex = 63
        Me.lblSep1.Text = "-"
        Me.lblSep1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblSep2
        '
        Me.lblSep2.AutoSize = True
        Me.lblSep2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSep2.Location = New System.Drawing.Point(30, 535)
        Me.lblSep2.Name = "lblSep2"
        Me.lblSep2.Size = New System.Drawing.Size(10, 13)
        Me.lblSep2.TabIndex = 61
        Me.lblSep2.Text = "-"
        Me.lblSep2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtDay1
        '
        Me.txtDay1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDay1.Location = New System.Drawing.Point(6, 532)
        Me.txtDay1.MaxLength = 2
        Me.txtDay1.Name = "txtDay1"
        Me.txtDay1.Size = New System.Drawing.Size(24, 20)
        Me.txtDay1.TabIndex = 60
        Me.txtDay1.Text = "00"
        Me.txtDay1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtHr1
        '
        Me.txtHr1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHr1.Location = New System.Drawing.Point(133, 532)
        Me.txtHr1.MaxLength = 2
        Me.txtHr1.Name = "txtHr1"
        Me.txtHr1.Size = New System.Drawing.Size(24, 20)
        Me.txtHr1.TabIndex = 66
        Me.txtHr1.Text = "00"
        Me.txtHr1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtMin1
        '
        Me.txtMin1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMin1.Location = New System.Drawing.Point(174, 532)
        Me.txtMin1.MaxLength = 2
        Me.txtMin1.Name = "txtMin1"
        Me.txtMin1.Size = New System.Drawing.Size(24, 20)
        Me.txtMin1.TabIndex = 68
        Me.txtMin1.Text = "00"
        Me.txtMin1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtSec1
        '
        Me.txtSec1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtSec1.Location = New System.Drawing.Point(214, 532)
        Me.txtSec1.MaxLength = 2
        Me.txtSec1.Name = "txtSec1"
        Me.txtSec1.Size = New System.Drawing.Size(24, 20)
        Me.txtSec1.TabIndex = 70
        Me.txtSec1.Text = "00"
        Me.txtSec1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'btnCal1
        '
        Me.btnCal1.Location = New System.Drawing.Point(311, 531)
        Me.btnCal1.Name = "btnCal1"
        Me.btnCal1.Size = New System.Drawing.Size(75, 23)
        Me.btnCal1.TabIndex = 71
        Me.btnCal1.Text = "Calculate"
        Me.btnCal1.UseVisualStyleBackColor = True
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(117, 535)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(13, 13)
        Me.Label2.TabIndex = 65
        Me.Label2.Text = "::"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(160, 535)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(10, 13)
        Me.Label3.TabIndex = 67
        Me.Label3.Text = ":"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(201, 535)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(10, 13)
        Me.Label4.TabIndex = 69
        Me.Label4.Text = ":"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtState
        '
        Me.txtState.BackColor = System.Drawing.SystemColors.Window
        Me.txtState.Enabled = False
        Me.txtState.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtState.Location = New System.Drawing.Point(93, 109)
        Me.txtState.Name = "txtState"
        Me.txtState.ReadOnly = True
        Me.txtState.Size = New System.Drawing.Size(219, 21)
        Me.txtState.TabIndex = 37
        '
        'txtCountry
        '
        Me.txtCountry.BackColor = System.Drawing.SystemColors.Window
        Me.txtCountry.Enabled = False
        Me.txtCountry.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCountry.Location = New System.Drawing.Point(93, 136)
        Me.txtCountry.Name = "txtCountry"
        Me.txtCountry.ReadOnly = True
        Me.txtCountry.Size = New System.Drawing.Size(219, 21)
        Me.txtCountry.TabIndex = 39
        '
        'Label25
        '
        Me.Label25.ForeColor = System.Drawing.Color.Red
        Me.Label25.Location = New System.Drawing.Point(3, 481)
        Me.Label25.Name = "Label25"
        Me.Label25.Size = New System.Drawing.Size(338, 30)
        Me.Label25.TabIndex = 33
        Me.Label25.Text = "Enter Date(s) and Time(s) below and Click 'Calculate' button to get the transit P" & _
    "ositions."
        Me.Label25.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label26
        '
        Me.Label26.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label26.ForeColor = System.Drawing.Color.Red
        Me.Label26.Location = New System.Drawing.Point(10, 9)
        Me.Label26.Name = "Label26"
        Me.Label26.Size = New System.Drawing.Size(303, 54)
        Me.Label26.TabIndex = 1
        Me.Label26.Text = "If you want transit for any place other than Birth /Horary place then click the P" & _
    "lace button below." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Then enter date of transit and Click Calculate button."
        '
        'Label27
        '
        Me.Label27.AutoSize = True
        Me.Label27.Location = New System.Drawing.Point(57, 86)
        Me.Label27.Name = "Label27"
        Me.Label27.Size = New System.Drawing.Size(34, 13)
        Me.Label27.TabIndex = 34
        Me.Label27.Text = "Place"
        Me.Label27.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label28
        '
        Me.Label28.AutoSize = True
        Me.Label28.Location = New System.Drawing.Point(59, 114)
        Me.Label28.Name = "Label28"
        Me.Label28.Size = New System.Drawing.Size(32, 13)
        Me.Label28.TabIndex = 36
        Me.Label28.Text = "State"
        Me.Label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label29
        '
        Me.Label29.AutoSize = True
        Me.Label29.Location = New System.Drawing.Point(48, 141)
        Me.Label29.Name = "Label29"
        Me.Label29.Size = New System.Drawing.Size(43, 13)
        Me.Label29.TabIndex = 38
        Me.Label29.Text = "Country"
        Me.Label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label30
        '
        Me.Label30.AutoSize = True
        Me.Label30.Location = New System.Drawing.Point(3, 515)
        Me.Label30.Name = "Label30"
        Me.Label30.Size = New System.Drawing.Size(26, 13)
        Me.Label30.TabIndex = 54
        Me.Label30.Text = "Day"
        '
        'Label31
        '
        Me.Label31.AutoSize = True
        Me.Label31.Location = New System.Drawing.Point(39, 516)
        Me.Label31.Name = "Label31"
        Me.Label31.Size = New System.Drawing.Size(37, 13)
        Me.Label31.TabIndex = 55
        Me.Label31.Text = "Month"
        '
        'Label32
        '
        Me.Label32.AutoSize = True
        Me.Label32.Location = New System.Drawing.Point(80, 515)
        Me.Label32.Name = "Label32"
        Me.Label32.Size = New System.Drawing.Size(29, 13)
        Me.Label32.TabIndex = 56
        Me.Label32.Text = "Year"
        '
        'Label33
        '
        Me.Label33.AutoSize = True
        Me.Label33.Location = New System.Drawing.Point(133, 516)
        Me.Label33.Name = "Label33"
        Me.Label33.Size = New System.Drawing.Size(26, 13)
        Me.Label33.TabIndex = 57
        Me.Label33.Text = "Hrs."
        '
        'Label34
        '
        Me.Label34.AutoSize = True
        Me.Label34.Location = New System.Drawing.Point(172, 516)
        Me.Label34.Name = "Label34"
        Me.Label34.Size = New System.Drawing.Size(32, 13)
        Me.Label34.TabIndex = 58
        Me.Label34.Text = "Mins."
        '
        'Label35
        '
        Me.Label35.AutoSize = True
        Me.Label35.Location = New System.Drawing.Point(211, 516)
        Me.Label35.Name = "Label35"
        Me.Label35.Size = New System.Drawing.Size(34, 13)
        Me.Label35.TabIndex = 59
        Me.Label35.Text = "Secs."
        '
        'btnPlace
        '
        Me.btnPlace.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnPlace.Location = New System.Drawing.Point(207, 237)
        Me.btnPlace.Name = "btnPlace"
        Me.btnPlace.Size = New System.Drawing.Size(105, 23)
        Me.btnPlace.TabIndex = 121
        Me.btnPlace.Text = "Place....."
        Me.btnPlace.UseVisualStyleBackColor = True
        '
        'Label36
        '
        Me.Label36.AutoSize = True
        Me.Label36.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label36.ForeColor = System.Drawing.Color.Blue
        Me.Label36.Location = New System.Drawing.Point(581, 29)
        Me.Label36.Name = "Label36"
        Me.Label36.Size = New System.Drawing.Size(64, 13)
        Me.Label36.TabIndex = 165
        Me.Label36.Text = "D-B-A-S-P"
        Me.Label36.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblToday
        '
        Me.lblToday.AutoSize = True
        Me.lblToday.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblToday.ForeColor = System.Drawing.Color.Blue
        Me.lblToday.Location = New System.Drawing.Point(410, 507)
        Me.lblToday.Name = "lblToday"
        Me.lblToday.Size = New System.Drawing.Size(113, 16)
        Me.lblToday.TabIndex = 166
        Me.lblToday.Text = "DBASP for Day is"
        Me.lblToday.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblWday
        '
        Me.lblWday.AutoSize = True
        Me.lblWday.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblWday.ForeColor = System.Drawing.Color.Blue
        Me.lblWday.Location = New System.Drawing.Point(410, 531)
        Me.lblWday.Name = "lblWday"
        Me.lblWday.Size = New System.Drawing.Size(84, 16)
        Me.lblWday.TabIndex = 167
        Me.lblWday.Text = "Vedic Day is"
        Me.lblWday.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label26)
        Me.GroupBox1.Controls.Add(Me.lblTZ)
        Me.GroupBox1.Controls.Add(Me.txtTzHr)
        Me.GroupBox1.Controls.Add(Me.btnPlace)
        Me.GroupBox1.Controls.Add(Me.lblhm1)
        Me.GroupBox1.Controls.Add(Me.lblWT)
        Me.GroupBox1.Controls.Add(Me.txtDstHr)
        Me.GroupBox1.Controls.Add(Me.lblhm2)
        Me.GroupBox1.Controls.Add(Me.lblLong)
        Me.GroupBox1.Controls.Add(Me.Label29)
        Me.GroupBox1.Controls.Add(Me.txtLong)
        Me.GroupBox1.Controls.Add(Me.Label28)
        Me.GroupBox1.Controls.Add(Me.lblLat)
        Me.GroupBox1.Controls.Add(Me.Label27)
        Me.GroupBox1.Controls.Add(Me.txtLat)
        Me.GroupBox1.Controls.Add(Me.txtPlaceD)
        Me.GroupBox1.Controls.Add(Me.txtState)
        Me.GroupBox1.Controls.Add(Me.txtCountry)
        Me.GroupBox1.Location = New System.Drawing.Point(473, 213)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(315, 279)
        Me.GroupBox1.TabIndex = 168
        Me.GroupBox1.TabStop = False
        '
        'DgDasa
        '
        Me.DgDasa.AllowUserToAddRows = False
        Me.DgDasa.AllowUserToDeleteRows = False
        Me.DgDasa.AllowUserToResizeColumns = False
        Me.DgDasa.AllowUserToResizeRows = False
        Me.DgDasa.BackgroundColor = System.Drawing.SystemColors.Window
        Me.DgDasa.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable
        Me.DgDasa.ColumnHeadersHeight = 18
        Me.DgDasa.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DgDasa.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically
        Me.DgDasa.Enabled = False
        Me.DgDasa.EnableHeadersVisualStyles = False
        Me.DgDasa.Location = New System.Drawing.Point(481, 57)
        Me.DgDasa.MultiSelect = False
        Me.DgDasa.Name = "DgDasa"
        Me.DgDasa.ReadOnly = True
        Me.DgDasa.RowHeadersVisible = False
        Me.DgDasa.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DgDasa.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DgDasa.RowTemplate.Height = 15
        Me.DgDasa.RowTemplate.ReadOnly = True
        Me.DgDasa.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgDasa.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.DgDasa.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgDasa.ShowCellToolTips = False
        Me.DgDasa.Size = New System.Drawing.Size(305, 156)
        Me.DgDasa.TabIndex = 317
        '
        'lbltithi
        '
        Me.lbltithi.AutoSize = True
        Me.lbltithi.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltithi.ForeColor = System.Drawing.Color.Blue
        Me.lbltithi.Location = New System.Drawing.Point(410, 556)
        Me.lbltithi.Name = "lbltithi"
        Me.lbltithi.Size = New System.Drawing.Size(33, 16)
        Me.lbltithi.TabIndex = 318
        Me.lbltithi.Text = "Tithi"
        Me.lbltithi.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'DgPl
        '
        Me.DgPl.AllowUserToAddRows = False
        Me.DgPl.AllowUserToDeleteRows = False
        Me.DgPl.AllowUserToResizeColumns = False
        Me.DgPl.AllowUserToResizeRows = False
        Me.DgPl.BackgroundColor = System.Drawing.Color.White
        Me.DgPl.ClipboardCopyMode = System.Windows.Forms.DataGridViewClipboardCopyMode.Disable
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        DataGridViewCellStyle1.BackColor = System.Drawing.Color.Pink
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DgPl.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DgPl.ColumnHeadersHeight = 18
        Me.DgPl.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        Me.DgPl.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Planet, Me.plSgnC, Me.pDMS, Me.pRL, Me.plSTLc, Me.plSLc, Me.PlSSLc, Me.H_SukL, Me.H_PraL, Me.dgPlSPra, Me.dgSSP, Me.PDirn})
        Me.DgPl.Enabled = False
        Me.DgPl.EnableHeadersVisualStyles = False
        Me.DgPl.Location = New System.Drawing.Point(3, 262)
        Me.DgPl.MultiSelect = False
        Me.DgPl.Name = "DgPl"
        Me.DgPl.ReadOnly = True
        Me.DgPl.RowHeadersVisible = False
        Me.DgPl.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        Me.DgPl.RowTemplate.DefaultCellStyle.Font = New System.Drawing.Font("Tahoma", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DgPl.RowTemplate.Height = 15
        Me.DgPl.RowTemplate.ReadOnly = True
        Me.DgPl.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DgPl.ScrollBars = System.Windows.Forms.ScrollBars.None
        Me.DgPl.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DgPl.ShowCellToolTips = False
        Me.DgPl.Size = New System.Drawing.Size(464, 215)
        Me.DgPl.TabIndex = 322
        '
        'PictureBoxS
        '
        Me.PictureBoxS.BackColor = System.Drawing.Color.White
        Me.PictureBoxS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.PictureBoxS.Enabled = False
        Me.PictureBoxS.Location = New System.Drawing.Point(794, 23)
        Me.PictureBoxS.Margin = New System.Windows.Forms.Padding(0)
        Me.PictureBoxS.Name = "PictureBoxS"
        Me.PictureBoxS.Size = New System.Drawing.Size(360, 450)
        Me.PictureBoxS.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBoxS.TabIndex = 323
        Me.PictureBoxS.TabStop = False
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(252, 516)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(42, 13)
        Me.Label5.TabIndex = 324
        Me.Label5.Text = "mSecs."
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(242, 535)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(10, 13)
        Me.Label6.TabIndex = 325
        Me.Label6.Text = ":"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtmSec
        '
        Me.txtmSec.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtmSec.Location = New System.Drawing.Point(255, 532)
        Me.txtmSec.MaxLength = 3
        Me.txtmSec.Name = "txtmSec"
        Me.txtmSec.Size = New System.Drawing.Size(48, 20)
        Me.txtmSec.TabIndex = 326
        Me.txtmSec.Text = "000"
        Me.txtmSec.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Planet
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.Planet.DefaultCellStyle = DataGridViewCellStyle2
        Me.Planet.HeaderText = "Planet"
        Me.Planet.Name = "Planet"
        Me.Planet.ReadOnly = True
        Me.Planet.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.Planet.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.Planet.Width = 55
        '
        'plSgnC
        '
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        Me.plSgnC.DefaultCellStyle = DataGridViewCellStyle3
        Me.plSgnC.HeaderText = "Sign"
        Me.plSgnC.Name = "plSgnC"
        Me.plSgnC.ReadOnly = True
        Me.plSgnC.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.plSgnC.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.plSgnC.Width = 36
        '
        'pDMS
        '
        DataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.pDMS.DefaultCellStyle = DataGridViewCellStyle4
        Me.pDMS.HeaderText = "D-M-S"
        Me.pDMS.Name = "pDMS"
        Me.pDMS.ReadOnly = True
        Me.pDMS.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.pDMS.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.pDMS.Width = 60
        '
        'pRL
        '
        Me.pRL.HeaderText = "R L"
        Me.pRL.Name = "pRL"
        Me.pRL.ReadOnly = True
        Me.pRL.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.pRL.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.pRL.Width = 32
        '
        'plSTLc
        '
        Me.plSTLc.HeaderText = "STL"
        Me.plSTLc.Name = "plSTLc"
        Me.plSTLc.ReadOnly = True
        Me.plSTLc.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.plSTLc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.plSTLc.Width = 32
        '
        'plSLc
        '
        Me.plSLc.HeaderText = "SL"
        Me.plSLc.Name = "plSLc"
        Me.plSLc.ReadOnly = True
        Me.plSLc.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.plSLc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.plSLc.Width = 32
        '
        'PlSSLc
        '
        Me.PlSSLc.HeaderText = "SSL"
        Me.PlSSLc.Name = "PlSSLc"
        Me.PlSSLc.ReadOnly = True
        Me.PlSSLc.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.PlSSLc.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.PlSSLc.Width = 32
        '
        'H_SukL
        '
        Me.H_SukL.HeaderText = "SukL"
        Me.H_SukL.Name = "H_SukL"
        Me.H_SukL.ReadOnly = True
        Me.H_SukL.Width = 35
        '
        'H_PraL
        '
        Me.H_PraL.HeaderText = "PraL"
        Me.H_PraL.Name = "H_PraL"
        Me.H_PraL.ReadOnly = True
        Me.H_PraL.Width = 35
        '
        'dgPlSPra
        '
        Me.dgPlSPra.HeaderText = "sPraL"
        Me.dgPlSPra.Name = "dgPlSPra"
        Me.dgPlSPra.ReadOnly = True
        Me.dgPlSPra.Width = 40
        '
        'dgSSP
        '
        Me.dgSSP.HeaderText = "SSP"
        Me.dgSSP.Name = "dgSSP"
        Me.dgSSP.ReadOnly = True
        Me.dgSSP.Width = 40
        '
        'PDirn
        '
        DataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter
        Me.PDirn.DefaultCellStyle = DataGridViewCellStyle5
        Me.PDirn.HeaderText = "Dir"
        Me.PDirn.Name = "PDirn"
        Me.PDirn.ReadOnly = True
        Me.PDirn.Resizable = System.Windows.Forms.DataGridViewTriState.[False]
        Me.PDirn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.NotSortable
        Me.PDirn.Width = 32
        '
        'frmTransitChart
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1160, 583)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.txtmSec)
        Me.Controls.Add(Me.PictureBoxS)
        Me.Controls.Add(Me.DgPl)
        Me.Controls.Add(Me.lbltithi)
        Me.Controls.Add(Me.DgDasa)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.lblWday)
        Me.Controls.Add(Me.lblToday)
        Me.Controls.Add(Me.Label36)
        Me.Controls.Add(Me.Label35)
        Me.Controls.Add(Me.Label34)
        Me.Controls.Add(Me.Label33)
        Me.Controls.Add(Me.Label32)
        Me.Controls.Add(Me.Label31)
        Me.Controls.Add(Me.Label30)
        Me.Controls.Add(Me.Label25)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.btnCal1)
        Me.Controls.Add(Me.txtSec1)
        Me.Controls.Add(Me.txtMin1)
        Me.Controls.Add(Me.txtHr1)
        Me.Controls.Add(Me.txtMonth1)
        Me.Controls.Add(Me.txtYear1)
        Me.Controls.Add(Me.lblSep1)
        Me.Controls.Add(Me.lblSep2)
        Me.Controls.Add(Me.txtDay1)
        Me.Controls.Add(Me.lblPlPo)
        Me.Controls.Add(Me.pcLagna)
        Me.Controls.Add(Me.Label1)
        Me.DoubleBuffered = True
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmTransitChart"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "True Astrology Software - Transit Chart"
        CType(Me.pcLagna, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DgDasa, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DgPl, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBoxS, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents pcLagna As System.Windows.Forms.PictureBox
    Friend WithEvents lblPlPo As System.Windows.Forms.Label
    Friend WithEvents txtLat As System.Windows.Forms.TextBox
    Friend WithEvents lblLat As System.Windows.Forms.Label
    Friend WithEvents txtLong As System.Windows.Forms.TextBox
    Friend WithEvents lblLong As System.Windows.Forms.Label
    Friend WithEvents lblhm2 As System.Windows.Forms.Label
    Friend WithEvents txtDstHr As System.Windows.Forms.TextBox
    Friend WithEvents lblWT As System.Windows.Forms.Label
    Friend WithEvents lblhm1 As System.Windows.Forms.Label
    Friend WithEvents txtTzHr As System.Windows.Forms.TextBox
    Friend WithEvents lblTZ As System.Windows.Forms.Label
    Friend WithEvents txtPlaceD As System.Windows.Forms.TextBox
    Friend WithEvents txtMonth1 As System.Windows.Forms.TextBox
    Friend WithEvents txtYear1 As System.Windows.Forms.TextBox
    Friend WithEvents lblSep1 As System.Windows.Forms.Label
    Friend WithEvents lblSep2 As System.Windows.Forms.Label
    Friend WithEvents txtDay1 As System.Windows.Forms.TextBox
    Friend WithEvents txtHr1 As System.Windows.Forms.TextBox
    Friend WithEvents txtMin1 As System.Windows.Forms.TextBox
    Friend WithEvents txtSec1 As System.Windows.Forms.TextBox
    Friend WithEvents btnCal1 As System.Windows.Forms.Button
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtState As System.Windows.Forms.TextBox
    Friend WithEvents txtCountry As System.Windows.Forms.TextBox
    Friend WithEvents Label25 As System.Windows.Forms.Label
    Friend WithEvents Label26 As System.Windows.Forms.Label
    Friend WithEvents Label27 As System.Windows.Forms.Label
    Friend WithEvents Label28 As System.Windows.Forms.Label
    Friend WithEvents Label29 As System.Windows.Forms.Label
    Friend WithEvents Label30 As System.Windows.Forms.Label
    Friend WithEvents Label31 As System.Windows.Forms.Label
    Friend WithEvents Label32 As System.Windows.Forms.Label
    Friend WithEvents Label33 As System.Windows.Forms.Label
    Friend WithEvents Label34 As System.Windows.Forms.Label
    Friend WithEvents Label35 As System.Windows.Forms.Label
    Friend WithEvents btnPlace As System.Windows.Forms.Button
    Friend WithEvents Label36 As System.Windows.Forms.Label
    Friend WithEvents lblToday As System.Windows.Forms.Label
    Friend WithEvents lblWday As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents DgDasa As System.Windows.Forms.DataGridView
    Friend WithEvents lbltithi As System.Windows.Forms.Label
    Friend WithEvents DgPl As System.Windows.Forms.DataGridView
    Friend WithEvents PictureBoxS As System.Windows.Forms.PictureBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents txtmSec As System.Windows.Forms.TextBox
    Friend WithEvents Planet As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents plSgnC As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pDMS As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents pRL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents plSTLc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents plSLc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PlSSLc As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents H_SukL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents H_PraL As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgPlSPra As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents dgSSP As System.Windows.Forms.DataGridViewTextBoxColumn
    Friend WithEvents PDirn As System.Windows.Forms.DataGridViewTextBoxColumn
End Class
