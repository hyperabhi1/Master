<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmLocation
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmLocation))
        Me.LstPlaceView = New System.Windows.Forms.ListView()
        Me.btnReset = New System.Windows.Forms.Button()
        Me.OK = New System.Windows.Forms.Button()
        Me.HorPanel = New System.Windows.Forms.Panel()
        Me.lblchangeNote = New System.Windows.Forms.Label()
        Me.lblMin = New System.Windows.Forms.Label()
        Me.lblHr = New System.Windows.Forms.Label()
        Me.txtDstMin = New System.Windows.Forms.TextBox()
        Me.lblDST = New System.Windows.Forms.Label()
        Me.txtDstHr = New System.Windows.Forms.TextBox()
        Me.lblDSTNote = New System.Windows.Forms.Label()
        Me.txtNS = New System.Windows.Forms.TextBox()
        Me.txtEW = New System.Windows.Forms.TextBox()
        Me.lblSep23 = New System.Windows.Forms.Label()
        Me.lblSep24 = New System.Windows.Forms.Label()
        Me.txtLatS = New System.Windows.Forms.TextBox()
        Me.txtLatM = New System.Windows.Forms.TextBox()
        Me.txtLatD = New System.Windows.Forms.TextBox()
        Me.lblSep21 = New System.Windows.Forms.Label()
        Me.lblSep22 = New System.Windows.Forms.Label()
        Me.txtLongS = New System.Windows.Forms.TextBox()
        Me.txtLongM = New System.Windows.Forms.TextBox()
        Me.txtLonD = New System.Windows.Forms.TextBox()
        Me.lbldms2 = New System.Windows.Forms.Label()
        Me.lblhm1 = New System.Windows.Forms.Label()
        Me.txtTzMn = New System.Windows.Forms.TextBox()
        Me.lbltzSep = New System.Windows.Forms.Label()
        Me.txtTzHr = New System.Windows.Forms.TextBox()
        Me.lblTZ = New System.Windows.Forms.Label()
        Me.txtCountry = New System.Windows.Forms.TextBox()
        Me.lblCountry = New System.Windows.Forms.Label()
        Me.txtState = New System.Windows.Forms.TextBox()
        Me.lblState = New System.Windows.Forms.Label()
        Me.txtPlaceAd = New System.Windows.Forms.TextBox()
        Me.lblPlace = New System.Windows.Forms.Label()
        Me.lblLat = New System.Windows.Forms.Label()
        Me.lblLong = New System.Windows.Forms.Label()
        Me.HorPanel.SuspendLayout()
        Me.SuspendLayout()
        '
        'LstPlaceView
        '
        Me.LstPlaceView.FullRowSelect = True
        Me.LstPlaceView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None
        Me.LstPlaceView.Location = New System.Drawing.Point(320, 57)
        Me.LstPlaceView.MultiSelect = False
        Me.LstPlaceView.Name = "LstPlaceView"
        Me.LstPlaceView.ShowGroups = False
        Me.LstPlaceView.Size = New System.Drawing.Size(376, 308)
        Me.LstPlaceView.Sorting = System.Windows.Forms.SortOrder.Ascending
        Me.LstPlaceView.TabIndex = 35
        Me.LstPlaceView.UseCompatibleStateImageBehavior = False
        Me.LstPlaceView.View = System.Windows.Forms.View.Details
        Me.LstPlaceView.Visible = False
        '
        'btnReset
        '
        Me.btnReset.Location = New System.Drawing.Point(462, 378)
        Me.btnReset.Name = "btnReset"
        Me.btnReset.Size = New System.Drawing.Size(75, 23)
        Me.btnReset.TabIndex = 33
        Me.btnReset.Text = "Reset"
        Me.btnReset.UseVisualStyleBackColor = True
        '
        'OK
        '
        Me.OK.AutoSize = True
        Me.OK.DialogResult = System.Windows.Forms.DialogResult.OK
        Me.OK.Location = New System.Drawing.Point(578, 378)
        Me.OK.Name = "OK"
        Me.OK.Size = New System.Drawing.Size(117, 23)
        Me.OK.TabIndex = 34
        Me.OK.Text = "OK"
        Me.OK.UseVisualStyleBackColor = True
        '
        'HorPanel
        '
        Me.HorPanel.BackColor = System.Drawing.Color.LightGoldenrodYellow
        Me.HorPanel.Controls.Add(Me.lblchangeNote)
        Me.HorPanel.Location = New System.Drawing.Point(1, 2)
        Me.HorPanel.Name = "HorPanel"
        Me.HorPanel.Size = New System.Drawing.Size(704, 45)
        Me.HorPanel.TabIndex = 0
        '
        'lblchangeNote
        '
        Me.lblchangeNote.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblchangeNote.ForeColor = System.Drawing.Color.Red
        Me.lblchangeNote.Location = New System.Drawing.Point(10, 7)
        Me.lblchangeNote.Name = "lblchangeNote"
        Me.lblchangeNote.Size = New System.Drawing.Size(684, 34)
        Me.lblchangeNote.TabIndex = 0
        Me.lblchangeNote.Text = resources.GetString("lblchangeNote.Text")
        Me.lblchangeNote.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'lblMin
        '
        Me.lblMin.AutoSize = True
        Me.lblMin.Location = New System.Drawing.Point(220, 375)
        Me.lblMin.Name = "lblMin"
        Me.lblMin.Size = New System.Drawing.Size(189, 13)
        Me.lblMin.TabIndex = 32
        Me.lblMin.Text = "Minute(s)      (Ahead of Standard Time)"
        '
        'lblHr
        '
        Me.lblHr.AutoSize = True
        Me.lblHr.Location = New System.Drawing.Point(138, 375)
        Me.lblHr.Name = "lblHr"
        Me.lblHr.Size = New System.Drawing.Size(41, 13)
        Me.lblHr.TabIndex = 30
        Me.lblHr.Text = "Hour(s)"
        '
        'txtDstMin
        '
        Me.txtDstMin.Location = New System.Drawing.Point(189, 371)
        Me.txtDstMin.MaxLength = 2
        Me.txtDstMin.Name = "txtDstMin"
        Me.txtDstMin.Size = New System.Drawing.Size(28, 20)
        Me.txtDstMin.TabIndex = 31
        Me.txtDstMin.Text = "00"
        '
        'lblDST
        '
        Me.lblDST.AutoSize = True
        Me.lblDST.Location = New System.Drawing.Point(16, 374)
        Me.lblDST.Name = "lblDST"
        Me.lblDST.Size = New System.Drawing.Size(86, 13)
        Me.lblDST.TabIndex = 28
        Me.lblDST.Text = "DST Correction :"
        '
        'txtDstHr
        '
        Me.txtDstHr.Location = New System.Drawing.Point(108, 371)
        Me.txtDstHr.MaxLength = 2
        Me.txtDstHr.Name = "txtDstHr"
        Me.txtDstHr.Size = New System.Drawing.Size(28, 20)
        Me.txtDstHr.TabIndex = 29
        Me.txtDstHr.Text = "00"
        '
        'lblDSTNote
        '
        Me.lblDSTNote.AutoSize = True
        Me.lblDSTNote.ForeColor = System.Drawing.Color.FromArgb(CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.lblDSTNote.Location = New System.Drawing.Point(12, 341)
        Me.lblDSTNote.Name = "lblDSTNote"
        Me.lblDSTNote.Size = New System.Drawing.Size(245, 13)
        Me.lblDSTNote.TabIndex = 27
        Me.lblDSTNote.Text = "Enter the DST(Daylight Saving Time) If Applicable."
        '
        'txtNS
        '
        Me.txtNS.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNS.Location = New System.Drawing.Point(231, 283)
        Me.txtNS.MaxLength = 1
        Me.txtNS.Name = "txtNS"
        Me.txtNS.Size = New System.Drawing.Size(26, 20)
        Me.txtNS.TabIndex = 26
        Me.txtNS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtEW
        '
        Me.txtEW.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtEW.Location = New System.Drawing.Point(231, 249)
        Me.txtEW.MaxLength = 1
        Me.txtEW.Name = "txtEW"
        Me.txtEW.Size = New System.Drawing.Size(26, 20)
        Me.txtEW.TabIndex = 18
        Me.txtEW.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblSep23
        '
        Me.lblSep23.AutoSize = True
        Me.lblSep23.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSep23.Location = New System.Drawing.Point(142, 287)
        Me.lblSep23.Name = "lblSep23"
        Me.lblSep23.Size = New System.Drawing.Size(10, 13)
        Me.lblSep23.TabIndex = 22
        Me.lblSep23.Text = ":"
        '
        'lblSep24
        '
        Me.lblSep24.AutoSize = True
        Me.lblSep24.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSep24.Location = New System.Drawing.Point(184, 287)
        Me.lblSep24.Name = "lblSep24"
        Me.lblSep24.Size = New System.Drawing.Size(10, 13)
        Me.lblSep24.TabIndex = 24
        Me.lblSep24.Text = ":"
        '
        'txtLatS
        '
        Me.txtLatS.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLatS.Location = New System.Drawing.Point(196, 283)
        Me.txtLatS.MaxLength = 2
        Me.txtLatS.Name = "txtLatS"
        Me.txtLatS.Size = New System.Drawing.Size(26, 20)
        Me.txtLatS.TabIndex = 25
        Me.txtLatS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtLatM
        '
        Me.txtLatM.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLatM.Location = New System.Drawing.Point(155, 283)
        Me.txtLatM.MaxLength = 2
        Me.txtLatM.Name = "txtLatM"
        Me.txtLatM.Size = New System.Drawing.Size(26, 20)
        Me.txtLatM.TabIndex = 23
        Me.txtLatM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtLatD
        '
        Me.txtLatD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLatD.Location = New System.Drawing.Point(108, 283)
        Me.txtLatD.MaxLength = 3
        Me.txtLatD.Name = "txtLatD"
        Me.txtLatD.Size = New System.Drawing.Size(32, 20)
        Me.txtLatD.TabIndex = 20
        Me.txtLatD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblSep21
        '
        Me.lblSep21.AutoSize = True
        Me.lblSep21.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSep21.Location = New System.Drawing.Point(143, 252)
        Me.lblSep21.Name = "lblSep21"
        Me.lblSep21.Size = New System.Drawing.Size(10, 13)
        Me.lblSep21.TabIndex = 14
        Me.lblSep21.Text = ":"
        '
        'lblSep22
        '
        Me.lblSep22.AutoSize = True
        Me.lblSep22.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSep22.Location = New System.Drawing.Point(183, 252)
        Me.lblSep22.Name = "lblSep22"
        Me.lblSep22.Size = New System.Drawing.Size(10, 13)
        Me.lblSep22.TabIndex = 16
        Me.lblSep22.Text = ":"
        '
        'txtLongS
        '
        Me.txtLongS.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLongS.Location = New System.Drawing.Point(196, 249)
        Me.txtLongS.MaxLength = 2
        Me.txtLongS.Name = "txtLongS"
        Me.txtLongS.Size = New System.Drawing.Size(26, 20)
        Me.txtLongS.TabIndex = 17
        Me.txtLongS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtLongM
        '
        Me.txtLongM.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLongM.Location = New System.Drawing.Point(155, 249)
        Me.txtLongM.MaxLength = 2
        Me.txtLongM.Name = "txtLongM"
        Me.txtLongM.Size = New System.Drawing.Size(26, 20)
        Me.txtLongM.TabIndex = 15
        Me.txtLongM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'txtLonD
        '
        Me.txtLonD.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtLonD.Location = New System.Drawing.Point(108, 249)
        Me.txtLonD.MaxLength = 3
        Me.txtLonD.Name = "txtLonD"
        Me.txtLonD.Size = New System.Drawing.Size(32, 20)
        Me.txtLonD.TabIndex = 13
        Me.txtLonD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lbldms2
        '
        Me.lbldms2.AutoSize = True
        Me.lbldms2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbldms2.Location = New System.Drawing.Point(124, 306)
        Me.lbldms2.Name = "lbldms2"
        Me.lbldms2.Size = New System.Drawing.Size(98, 15)
        Me.lbldms2.TabIndex = 21
        Me.lbldms2.Text = "(Deg : Min : Sec)"
        '
        'lblhm1
        '
        Me.lblhm1.AutoSize = True
        Me.lblhm1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblhm1.Location = New System.Drawing.Point(179, 187)
        Me.lblhm1.Name = "lblhm1"
        Me.lblhm1.Size = New System.Drawing.Size(64, 15)
        Me.lblhm1.TabIndex = 11
        Me.lblhm1.Text = "(Hrs : Min)"
        '
        'txtTzMn
        '
        Me.txtTzMn.BackColor = System.Drawing.SystemColors.Window
        Me.txtTzMn.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTzMn.Location = New System.Drawing.Point(147, 184)
        Me.txtTzMn.MaxLength = 2
        Me.txtTzMn.Name = "txtTzMn"
        Me.txtTzMn.Size = New System.Drawing.Size(27, 21)
        Me.txtTzMn.TabIndex = 10
        Me.txtTzMn.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lbltzSep
        '
        Me.lbltzSep.AutoSize = True
        Me.lbltzSep.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lbltzSep.Location = New System.Drawing.Point(136, 187)
        Me.lbltzSep.Name = "lbltzSep"
        Me.lbltzSep.Size = New System.Drawing.Size(10, 15)
        Me.lbltzSep.TabIndex = 9
        Me.lbltzSep.Text = ":"
        Me.lbltzSep.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'txtTzHr
        '
        Me.txtTzHr.BackColor = System.Drawing.SystemColors.Window
        Me.txtTzHr.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTzHr.Location = New System.Drawing.Point(108, 184)
        Me.txtTzHr.MaxLength = 2
        Me.txtTzHr.Name = "txtTzHr"
        Me.txtTzHr.Size = New System.Drawing.Size(27, 21)
        Me.txtTzHr.TabIndex = 8
        Me.txtTzHr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'lblTZ
        '
        Me.lblTZ.AutoSize = True
        Me.lblTZ.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTZ.Location = New System.Drawing.Point(30, 187)
        Me.lblTZ.Name = "lblTZ"
        Me.lblTZ.Size = New System.Drawing.Size(72, 15)
        Me.lblTZ.TabIndex = 7
        Me.lblTZ.Text = "Time Zone :"
        Me.lblTZ.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'txtCountry
        '
        Me.txtCountry.Location = New System.Drawing.Point(108, 125)
        Me.txtCountry.Name = "txtCountry"
        Me.txtCountry.Size = New System.Drawing.Size(206, 20)
        Me.txtCountry.TabIndex = 6
        '
        'lblCountry
        '
        Me.lblCountry.AutoSize = True
        Me.lblCountry.Location = New System.Drawing.Point(53, 128)
        Me.lblCountry.Name = "lblCountry"
        Me.lblCountry.Size = New System.Drawing.Size(49, 13)
        Me.lblCountry.TabIndex = 5
        Me.lblCountry.Text = "Country :"
        '
        'txtState
        '
        Me.txtState.Location = New System.Drawing.Point(108, 91)
        Me.txtState.Name = "txtState"
        Me.txtState.Size = New System.Drawing.Size(206, 20)
        Me.txtState.TabIndex = 4
        '
        'lblState
        '
        Me.lblState.AutoSize = True
        Me.lblState.Location = New System.Drawing.Point(64, 94)
        Me.lblState.Name = "lblState"
        Me.lblState.Size = New System.Drawing.Size(38, 13)
        Me.lblState.TabIndex = 3
        Me.lblState.Text = "State :"
        '
        'txtPlaceAd
        '
        Me.txtPlaceAd.Location = New System.Drawing.Point(108, 57)
        Me.txtPlaceAd.Name = "txtPlaceAd"
        Me.txtPlaceAd.Size = New System.Drawing.Size(206, 20)
        Me.txtPlaceAd.TabIndex = 2
        '
        'lblPlace
        '
        Me.lblPlace.AutoSize = True
        Me.lblPlace.Location = New System.Drawing.Point(62, 60)
        Me.lblPlace.Name = "lblPlace"
        Me.lblPlace.Size = New System.Drawing.Size(40, 13)
        Me.lblPlace.TabIndex = 1
        Me.lblPlace.Text = "Place :"
        '
        'lblLat
        '
        Me.lblLat.AutoSize = True
        Me.lblLat.Location = New System.Drawing.Point(51, 286)
        Me.lblLat.Name = "lblLat"
        Me.lblLat.Size = New System.Drawing.Size(51, 13)
        Me.lblLat.TabIndex = 19
        Me.lblLat.Text = "Latitude :"
        Me.lblLat.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblLong
        '
        Me.lblLong.AutoSize = True
        Me.lblLong.Location = New System.Drawing.Point(42, 252)
        Me.lblLong.Name = "lblLong"
        Me.lblLong.Size = New System.Drawing.Size(60, 13)
        Me.lblLong.TabIndex = 12
        Me.lblLong.Text = "Longitude :"
        Me.lblLong.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'frmLocation
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(706, 424)
        Me.Controls.Add(Me.LstPlaceView)
        Me.Controls.Add(Me.btnReset)
        Me.Controls.Add(Me.OK)
        Me.Controls.Add(Me.HorPanel)
        Me.Controls.Add(Me.lblMin)
        Me.Controls.Add(Me.lblHr)
        Me.Controls.Add(Me.txtDstMin)
        Me.Controls.Add(Me.lblDST)
        Me.Controls.Add(Me.txtDstHr)
        Me.Controls.Add(Me.lblDSTNote)
        Me.Controls.Add(Me.txtNS)
        Me.Controls.Add(Me.txtEW)
        Me.Controls.Add(Me.lblSep23)
        Me.Controls.Add(Me.lblSep24)
        Me.Controls.Add(Me.txtLatS)
        Me.Controls.Add(Me.txtLatM)
        Me.Controls.Add(Me.txtLatD)
        Me.Controls.Add(Me.lblSep21)
        Me.Controls.Add(Me.lblSep22)
        Me.Controls.Add(Me.txtLongS)
        Me.Controls.Add(Me.txtLongM)
        Me.Controls.Add(Me.txtLonD)
        Me.Controls.Add(Me.lbldms2)
        Me.Controls.Add(Me.lblhm1)
        Me.Controls.Add(Me.txtTzMn)
        Me.Controls.Add(Me.lbltzSep)
        Me.Controls.Add(Me.txtTzHr)
        Me.Controls.Add(Me.lblTZ)
        Me.Controls.Add(Me.txtCountry)
        Me.Controls.Add(Me.lblCountry)
        Me.Controls.Add(Me.txtState)
        Me.Controls.Add(Me.lblState)
        Me.Controls.Add(Me.txtPlaceAd)
        Me.Controls.Add(Me.lblPlace)
        Me.Controls.Add(Me.lblLat)
        Me.Controls.Add(Me.lblLong)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmLocation"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "True Astrology Software - Place Search"
        Me.HorPanel.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LstPlaceView As System.Windows.Forms.ListView
    Friend WithEvents btnReset As System.Windows.Forms.Button
    Friend WithEvents OK As System.Windows.Forms.Button
    Friend WithEvents HorPanel As System.Windows.Forms.Panel
    Friend WithEvents lblchangeNote As System.Windows.Forms.Label
    Friend WithEvents lblMin As System.Windows.Forms.Label
    Friend WithEvents lblHr As System.Windows.Forms.Label
    Friend WithEvents txtDstMin As System.Windows.Forms.TextBox
    Friend WithEvents lblDST As System.Windows.Forms.Label
    Friend WithEvents txtDstHr As System.Windows.Forms.TextBox
    Friend WithEvents lblDSTNote As System.Windows.Forms.Label
    Friend WithEvents txtNS As System.Windows.Forms.TextBox
    Friend WithEvents txtEW As System.Windows.Forms.TextBox
    Friend WithEvents lblSep23 As System.Windows.Forms.Label
    Friend WithEvents lblSep24 As System.Windows.Forms.Label
    Friend WithEvents txtLatS As System.Windows.Forms.TextBox
    Friend WithEvents txtLatM As System.Windows.Forms.TextBox
    Friend WithEvents txtLatD As System.Windows.Forms.TextBox
    Friend WithEvents lblSep21 As System.Windows.Forms.Label
    Friend WithEvents lblSep22 As System.Windows.Forms.Label
    Friend WithEvents txtLongS As System.Windows.Forms.TextBox
    Friend WithEvents txtLongM As System.Windows.Forms.TextBox
    Friend WithEvents txtLonD As System.Windows.Forms.TextBox
    Friend WithEvents lbldms2 As System.Windows.Forms.Label
    Friend WithEvents lblhm1 As System.Windows.Forms.Label
    Friend WithEvents txtTzMn As System.Windows.Forms.TextBox
    Friend WithEvents lbltzSep As System.Windows.Forms.Label
    Friend WithEvents txtTzHr As System.Windows.Forms.TextBox
    Friend WithEvents lblTZ As System.Windows.Forms.Label
    Friend WithEvents txtCountry As System.Windows.Forms.TextBox
    Friend WithEvents lblCountry As System.Windows.Forms.Label
    Friend WithEvents txtState As System.Windows.Forms.TextBox
    Friend WithEvents lblState As System.Windows.Forms.Label
    Friend WithEvents txtPlaceAd As System.Windows.Forms.TextBox
    Friend WithEvents lblPlace As System.Windows.Forms.Label
    Friend WithEvents lblLat As System.Windows.Forms.Label
    Friend WithEvents lblLong As System.Windows.Forms.Label
End Class
