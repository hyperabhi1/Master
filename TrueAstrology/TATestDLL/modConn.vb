Module modConn
    Friend NotInheritable Class NativeMethods
        Private Sub New()
        End Sub
        Public Declare Function swe_calc_ut Lib "swedll32.dll" Alias "_swe_calc_ut@24" (ByVal tjd_ut As Double, ByVal ipl As Int32, ByVal iflag As Int32, ByRef x As Double, ByVal serr As String) As Int32   ' x must be first of six array elements        ' serr must be able to hold 256 bytes
        '      Declare Function swe_calc_ut Lib "swedll32.dll" Alias "_swe_calc_ut@24" (ByVal tjd_ut As Double, ByVal ipl As Integer, ByVal iflag As Integer, ByRef X As Double, ByVal serr As String) As Integer ' x must be first of six array elements
        Declare Function swe_close Lib "swedll32.dll" Alias "_swe_close@0" () As Integer
        Declare Function swe_date_conversion Lib "swedll32.dll" Alias "_swe_date_conversion@28" (ByVal Year_Renamed As Integer, ByVal Month_Renamed As Integer, ByVal Day_Renamed As Integer, ByVal utime As Double, ByVal cal As Byte, ByRef tjd As Double) As Integer
        Declare Function swe_day_of_week Lib "swedll32.dll" Alias "_swe_day_of_week@8" (ByVal jd As Double) As Integer
        Declare Function swe_degnorm Lib "swedll32.dll" Alias "_swe_degnorm@8" (ByVal jd As Double) As Double
        Declare Function swe_get_ayanamsa Lib "swedll32.dll" Alias "_swe_get_ayanamsa@8" (ByVal tjd_et As Double) As Double
        Declare Function swe_get_ayanamsa_ut Lib "swedll32.dll" Alias "_swe_get_ayanamsa_ut@8" (ByVal tjd_ut As Double) As Double
        Declare Function swe_houses_ex Lib "swedll32.dll" Alias "_swe_houses_ex@40" (ByVal tjd_ut As Double, ByVal iflag As Integer, ByVal geolat As Double, ByVal geolon As Double, ByVal ihsy As Integer, ByRef hcusps As Double, ByRef ascmc As Double) As Integer ' hcusps must be first of 13 array elements
        Declare Function swe_julday Lib "swedll32.dll" Alias "_swe_julday@24" (ByVal Year_Renamed As Integer, ByVal Month_Renamed As Integer, ByVal Day_Renamed As Integer, ByVal hour_Renamed As Double, ByVal gregflg As Integer) As Double
        Declare Function swe_lun_eclipse_when Lib "swedll32.dll" Alias "_swe_lun_eclipse_when@28" (ByVal tjd_start As Double, ByVal ifl As Integer, ByVal ifltype As Integer, ByRef tret As Double, ByVal backward As Integer, ByVal serr As String) As Integer
        Declare Sub swe_revjul Lib "swedll32.dll" Alias "_swe_revjul@28" (ByVal tjd As Double, ByVal gregflg As Integer, ByRef Year_Renamed As Integer, ByRef Month_Renamed As Integer, ByRef Day_Renamed As Integer, ByRef hour_Renamed As Double)
        Declare Function swe_rise_trans Lib "swedll32.dll" Alias "_swe_rise_trans@52" (ByVal tjd_ut As Double, ByVal ipl As Integer, ByVal starname As String, ByVal epheflag As Integer, ByVal rsmi As Integer, ByRef geopos As Double, ByVal atpress As Double, ByVal attemp As Double, ByRef tret As Double, ByVal serr As String) As Integer
        Declare Sub swe_set_ephe_path Lib "swedll32.dll" Alias "_swe_set_ephe_path@4" (ByVal path As String)
        Declare Function swe_set_sid_mode Lib "swedll32.dll" Alias "_swe_set_sid_mode@20" (ByVal sid_mode As Integer, ByVal t0 As Double, ByVal ayan_t0 As Double) As Integer
        Declare Function swe_set_topo Lib "swedll32.dll" Alias "_swe_set_topo@24" (ByVal geolon As Double, ByVal geolat As Double, ByVal altitude As Double) As Short
        Declare Function swe_sidtime Lib "swedll32.dll" Alias "_swe_sidtime@8" (ByVal tjd_ut As Double) As Double
        Declare Function swe_sol_eclipse_how Lib "swedll32.dll" Alias "_swe_sol_eclipse_how@24" (ByVal tjd_ut As Double, ByVal ifl As Integer, ByRef geopos As Double, ByRef attr As Double, ByVal serr As String) As Integer
        Declare Function swe_sol_eclipse_when_glob Lib "swedll32.dll" Alias "_swe_sol_eclipse_when_glob@28" (ByVal tjd_start As Double, ByVal ifl As Integer, ByVal ifltype As Integer, ByRef tret As Double, ByVal backward As Integer, ByVal serr As String) As Integer
        Declare Function swe_sol_eclipse_when_loc Lib "swedll32.dll" Alias "_swe_sol_eclipse_when_loc@32" (ByVal tjd_start As Double, ByVal ifl As Integer, ByRef geopos As Double, ByRef tret As Double, ByRef attr As Double, ByVal backward As Integer, ByVal serr As String) As Integer
        Declare Function swe_sol_eclipse_where Lib "swedll32.dll" Alias "_swe_sol_eclipse_where@24" (ByVal tjd_ut As Double, ByVal ifl As Integer, ByRef geopos As Double, ByRef attr As Double, ByVal serr As String) As Integer
    End Class

    Public ConString2 As String = "Jet OLEDB:Global Partial Bulk Ops=2;Jet OLEDB:Registry Path=;Jet OLEDB:Database Locking Mode=1;Data Source= " & Application.StartupPath & "\ChartData.CTX" & ";Jet OLEDB:Engine Type=5;Provider=Microsoft.Jet.OLEDB.4.0;Jet OLEDB:System database=;Jet OLEDB:SFP=False;persist security info=False;Extended Properties=;Mode=Share Deny None;Jet OLEDB:Encrypt Database=False;Jet OLEDB:Create System Database=False;Jet OLEDB:Don't Copy Locale on Compact=False;Jet OLEDB:Compact Without Replica Repair=False;User ID=Admin;Jet OLEDB:Database Password = mrps13120517; Jet OLEDB:Global Bulk Transactions=1"

    Public Function CheckMaxLength(ByVal mxl As Integer, ByVal txtl As Integer) As Boolean
        If txtl = mxl Then
            CheckMaxLength = True
        Else
            CheckMaxLength = False
        End If
    End Function

    Public Function dayValidate(ByVal dd As Integer) As Boolean
        If dd = 0 Then
            dayValidate = True
            Exit Function
        End If
        If dd < 1 Or dd > 31 Then
            MsgBox("Invalid Date!, Please re-enter date.", MsgBoxStyle.Information)
            dayValidate = False
        Else : dayValidate = True
        End If
    End Function

    Public Function monthValidate(ByVal mm As Integer) As Boolean
        If mm = 0 Then
            monthValidate = True
            Exit Function
        End If
        If mm < 1 Or mm > 12 Then
            MsgBox("Invalid Month!, Please re-enter month.", MsgBoxStyle.Information)
            monthValidate = False
        Else : monthValidate = True
        End If
    End Function

    Public Function YearValidate(ByVal mm As Integer) As Boolean
        If mm = 0 Then
            YearValidate = True
            Exit Function
        End If

        If mm < 1800 Or mm > 5400 Then
            MsgBox("Invalid Year!, Please re-enter Year.", MsgBoxStyle.Information)
            YearValidate = False
        Else : YearValidate = True
        End If
    End Function

    Public Function HourValidate(ByVal mm As Integer) As Boolean
        If mm = 0 Then
            HourValidate = True
            Exit Function
        End If
        If mm < 0 Or mm > 24 Then
            MsgBox("Invalid Hours!, Please re-enter Hours,", MsgBoxStyle.Information)
            HourValidate = False
        Else : HourValidate = True
        End If
    End Function

    Public Function MinValidate(ByVal mm As Integer) As Boolean
        If mm = 0 Then
            MinValidate = True
            Exit Function
        End If
        If mm < 0 Or mm > 60 Then
            MsgBox("Invalid Minutes/Seconds!, Please re-enter Minutes/Seconds.", MsgBoxStyle.Information)
            MinValidate = False
        Else : MinValidate = True
        End If
    End Function

    Public Function MiliValidate(ByVal mm As Integer) As Boolean
        If mm = 0 Then
            Return True
            Exit Function
        End If
        If mm < 0 Or mm > 999 Then
            MsgBox("Invalid Mili Seconds!, Please re-enter Mili Seconds.", MsgBoxStyle.Information)
            Return False
        Else : Return True
        End If
    End Function

    Public Function SecValidate(ByVal mm As Integer) As Boolean
        If mm = 0 Then
            SecValidate = True
            Exit Function
        End If
        If mm < 0 Or mm > 60 Then
            MsgBox("Invalid Seconds!, Please re-enter Seconds.", MsgBoxStyle.Information)
            SecValidate = False
        Else : SecValidate = True
        End If
    End Function

    Public Function DegValidate(ByVal dd As Integer) As Boolean
        If dd = 0 Then
            DegValidate = True
            Exit Function
        End If
        If dd < 0 Or dd > 180 Then
            MsgBox("Invalid Degree!, Please re-enter Degrees.", MsgBoxStyle.Information)
            DegValidate = False
        Else : DegValidate = True
        End If
    End Function

    Public Function GetRoman(ByVal I As Integer) As String
        Select Case I
            Case 1
                GetRoman = "Cusp I"
            Case 2
                GetRoman = "Cusp II"
            Case 3
                GetRoman = "Cusp III"
            Case 4
                GetRoman = "Cusp IV"
            Case 5
                GetRoman = "Cusp V"
            Case 6
                GetRoman = "Cusp VI"
            Case 7
                GetRoman = "Cusp VII"
            Case 8
                GetRoman = "Cusp VIII"
            Case 9
                GetRoman = "Cusp IX"
            Case 10
                GetRoman = "Cusp X"
            Case 11
                GetRoman = "Cusp XI"
            Case 12
                GetRoman = "Cusp XII"
            Case Else
                GetRoman = ""
        End Select
    End Function

    Public Function a_red(ByVal x As Double, ByVal a As Double) As Double
        a_red = (x - Math.Floor(x / a) * a)
    End Function

    Public Function red_deg(ByVal len As Double) As Double
        red_deg = a_red(len, 360)
    End Function

    Public Sub DrawNChart(ByVal gOff As Graphics, ByVal X As Integer, ByVal Y As Integer, ByVal wd As Integer, ByVal ht As Integer, Optional ByVal Col As Boolean = True)
        Dim BDPen As Pen
        Dim RPen As Pen
        Dim GPen As Pen
        If Col = True Then
            BDPen = New Pen(Color.Blue, 2)
            RPen = New Pen(Color.Red, 1)
            GPen = New Pen(Color.DarkGreen, 1)
        Else
            BDPen = New Pen(Color.Black, 0.25)
            RPen = New Pen(Color.Black, 0.25)
            GPen = New Pen(Color.Black, 0.25)
        End If
        gOff.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
        gOff.DrawRectangle(BDPen, X, Y, wd, ht)
        gOff.DrawLine(GPen, X + 16, Y, X + 16, Y + 16)
        gOff.DrawLine(GPen, X, Y + 16, X + 16, Y + 16)
        gOff.DrawLine(GPen, X + wd - 16, Y, X + wd - 16, Y + 16)
        gOff.DrawLine(GPen, X + wd - 16, Y + 16, X + wd, Y + 16)
        gOff.DrawLine(GPen, X, Y + ht - 16, X + 16, Y + ht - 16)
        gOff.DrawLine(GPen, X + 16, Y + ht - 16, X + 16, Y + ht)
        gOff.DrawLine(GPen, X + wd - 16, Y + ht, X + wd - 16, Y + ht - 16)
        gOff.DrawLine(GPen, X + wd, Y + ht - 16, X + wd - 16, Y + ht - 16)
        gOff.DrawLine(GPen, CSng(X + wd / 2), Y, CSng(X + wd / 2), Y + 16)
        gOff.DrawLine(GPen, CSng(X + wd / 2), Y + ht - 16, CSng(X + wd / 2), Y + ht)
        gOff.DrawLine(GPen, X, CSng(Y + ht / 2), X + 16, CSng(Y + ht / 2))
        gOff.DrawLine(GPen, X + wd - 16, CSng(Y + ht / 2), X + wd, CSng(Y + ht / 2))
        gOff.DrawLine(RPen, X + 16, Y + 16, X + wd - 16, Y + ht - 16)
        gOff.DrawLine(RPen, X + 16, Y + ht - 16, X + wd - 16, Y + 16)
        gOff.DrawLine(RPen, CSng(X + wd / 2), Y + 16, X + wd - 16, CSng(Y + ht / 2))
        gOff.DrawLine(RPen, CSng(X + wd / 2), Y + 16, X + 16, CSng(Y + ht / 2))
        gOff.DrawLine(RPen, CSng(X + wd / 2), Y + ht - 16, X + wd - 16, CSng(Y + ht / 2))
        gOff.DrawLine(RPen, CSng(X + wd / 2), Y + ht - 16, X + 16, CSng(Y + ht / 2))
    End Sub

    Public Sub writePlanetsN(ByVal gOff As Graphics, ByVal X As Integer, ByVal Y As Integer, ByVal wd As Integer, ByVal ht As Integer, ByVal ShowAsc As Boolean, ByVal Col As Boolean, ByVal PinHNo() As String)
        Dim myFont As Font = New Font("Tahoma", 8, FontStyle.Regular)
        Dim myFontB As Font = New Font("Tahoma", 8, FontStyle.Bold)
        Dim myBrush As Brush = Brushes.Black
        Dim drawFormat As New StringFormat
        gOff.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
        drawFormat.Alignment = StringAlignment.Center
        drawFormat.LineAlignment = StringAlignment.Center
        If ShowAsc = True Then
            Dim drawRect As New RectangleF(X + wd / 2 - 15, Y + 26, 30, 15)
            If Col = True Then
                gOff.DrawString("ASC", myFontB, Brushes.Blue, drawRect, drawFormat)
            Else
                gOff.DrawString("ASC", myFontB, Brushes.Black, drawRect, drawFormat)
            End If
        End If
        'For u As Integer = 1 To 12
        '    PinHNo(u) = "Su Mo Ma Me Ju Ve Sa Ra Ke"
        'Next
        Dim drawRect1 As New RectangleF(X + wd / 2 - 42, Y + 41, 84, 28)
        gOff.DrawString(PinHNo(1), myFont, myBrush, drawRect1, drawFormat)

        Dim drawRect4 As New RectangleF(X + wd / 4 - 42 + 8, Y + ht / 2 - 14, 84, 28)
        gOff.DrawString(PinHNo(4), myFont, myBrush, drawRect4, drawFormat)

        Dim drawRect7 As New RectangleF(X + wd / 2 - 42, Y + ht * 0.75 - 8 - 14, 84, 28)
        gOff.DrawString(PinHNo(7), myFont, myBrush, drawRect7, drawFormat)

        Dim drawRect10 As New RectangleF(X + wd * 0.75 - 8 - 42, Y + ht / 2 - 14, 84, 28)
        gOff.DrawString(PinHNo(10), myFont, myBrush, drawRect10, drawFormat)

        Dim drawRect2 As New RectangleF(X + wd / 4 - 42 + 8, Y + 2, 97, 28)
        gOff.DrawString(PinHNo(2), myFont, myBrush, drawRect2, drawFormat)

        Dim drawRect6 As New RectangleF(X + wd / 4 - 42 + 8, Y + ht - 30, 97, 28)
        gOff.DrawString(PinHNo(6), myFont, myBrush, drawRect6, drawFormat)

        Dim drawRect8 As New RectangleF(X + wd * 0.75 - 42 - 8, Y + ht - 30, 97, 28)
        gOff.DrawString(PinHNo(8), myFont, myBrush, drawRect8, drawFormat)

        Dim drawRect12 As New RectangleF(X + wd * 0.75 - 42 - 8, Y + 2, 97, 28)
        gOff.DrawString(PinHNo(12), myFont, myBrush, drawRect12, drawFormat)

        Dim drawRect3 As New RectangleF(X + 2, Y + ht / 4 - 18 + 8, 64, 36)
        gOff.DrawString(PinHNo(3), myFont, myBrush, drawRect3, drawFormat)

        Dim drawRect5 As New RectangleF(X + 2, Y + ht * 0.75 - 18 - 8, 64, 36)
        gOff.DrawString(PinHNo(5), myFont, myBrush, drawRect5, drawFormat)

        Dim drawRect9 As New RectangleF(X + wd - 66, Y + ht * 0.75 - 18 - 8, 64, 36)
        gOff.DrawString(PinHNo(9), myFont, myBrush, drawRect9, drawFormat)

        Dim drawRect11 As New RectangleF(X + wd - 66, Y + ht / 4 - 18 + 8, 64, 36)
        gOff.DrawString(PinHNo(11), myFont, myBrush, drawRect11, drawFormat)

    End Sub

    Public Sub writeHouseNosN(ByVal gOff As Graphics, ByVal X As Integer, ByVal Y As Integer, ByVal wd As Integer, ByVal ht As Integer, ByVal Hno() As Integer, ByVal col As Boolean)
        Dim myFont As Font = New Font("Tahoma", 8, FontStyle.Regular)
        Dim myBrush As Brush
        If col = True Then
            myBrush = Brushes.Red
        Else
            myBrush = Brushes.Black
        End If

        gOff.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
        Dim drawFormat As New StringFormat
        drawFormat.Alignment = StringAlignment.Center
        drawFormat.LineAlignment = StringAlignment.Center
        drawFormat.FormatFlags = StringFormatFlags.NoClip
        Dim drawRect1 As New RectangleF(X + (wd - 17) / 2, Y + ht / 2 - 18, 17, 12)
        gOff.DrawString(Hno(1), myFont, myBrush, drawRect1, drawFormat)

        Dim drawRect2 As New RectangleF(X + wd / 4 - 17 / 2 + 8, Y + ht / 4 - 16 + 8, 17, 12)
        gOff.DrawString(Hno(2), myFont, myBrush, drawRect2, drawFormat)

        Dim drawRect3 As New RectangleF(X + wd / 4 - 28 + 8, Y + ht / 4 + 8 - 6, 17, 12)
        gOff.DrawString(Hno(3), myFont, myBrush, drawRect3, drawFormat)

        Dim drawRect4 As New RectangleF(X + wd / 2 - 28, Y + ht / 2 - 6, 17, 12)
        gOff.DrawString(Hno(4), myFont, myBrush, drawRect4, drawFormat)

        Dim drawRect5 As New RectangleF(X + wd / 4 - 28 + 8, Y + ht * 0.75 - 8 - 6, 17, 12)
        gOff.DrawString(Hno(5), myFont, myBrush, drawRect5, drawFormat)

        Dim drawRect6 As New RectangleF(X + wd / 4 - 17 / 2 + 8, Y + ht * 0.75 + 16 - 16, 17, 12)
        gOff.DrawString(Hno(6), myFont, myBrush, drawRect6, drawFormat)

        Dim drawRect7 As New RectangleF(X + (wd - 17) / 2, Y + ht / 2 + 6, 17, 12)
        gOff.DrawString(Hno(7), myFont, myBrush, drawRect7, drawFormat)

        Dim drawRect8 As New RectangleF(X + wd * 0.75 - 8 - 17 / 2, Y + ht * 0.75 + 16 - 16, 17, 12)
        gOff.DrawString(Hno(8), myFont, myBrush, drawRect8, drawFormat)

        Dim drawRect9 As New RectangleF(X + wd * 0.75 - 8 + 12, Y + ht * 0.75 - 8 - 6, 17, 12)
        gOff.DrawString(Hno(9), myFont, myBrush, drawRect9, drawFormat)

        Dim drawRect10 As New RectangleF(X + wd / 2 + 12, Y + ht / 2 - 6, 17, 12)
        gOff.DrawString(Hno(10), myFont, myBrush, drawRect10, drawFormat)

        Dim drawRect11 As New RectangleF(X + wd * 0.75 - 8 + 12, Y + ht / 4 + 8 - 6, 17, 12)
        gOff.DrawString(Hno(11), myFont, myBrush, drawRect11, drawFormat)

        Dim drawRect12 As New RectangleF(X + wd * 0.75 - 8 - 17 / 2, Y + ht / 4 - 16 + 8, 17, 12)
        gOff.DrawString(Hno(12), myFont, myBrush, drawRect12, drawFormat)
    End Sub

    Public Sub DrawSChart(ByVal gOff As Graphics, ByVal X As Single, ByVal Y As Single, ByVal Wd As Single, ByVal Ht As Single)
        Dim OrPen As Pen = New Pen(Color.DarkOrange, 0.5)
        Dim MgPen As Pen = New Pen(Color.Magenta, 0.5)
        gOff.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
        gOff.DrawRectangle(MgPen, X, Y, Wd, Ht)
        gOff.DrawLine(OrPen, CInt(X + Wd / 4), CInt(Y), CInt(X + Wd / 4), CInt(Y + Ht))
        gOff.DrawLine(OrPen, CInt(X + Wd * 3 / 4), Y, CInt(X + Wd * 3 / 4), CInt(Y + Ht))
        gOff.DrawLine(OrPen, CInt(X), CInt(Y + Ht / 2), CInt(X + Wd / 4), CInt(Y + Ht / 2))
        gOff.DrawLine(OrPen, CInt(X + Wd * 3 / 4), CInt(Y + Ht / 2), CInt(X + Wd), CInt(Y + Ht / 2))
        gOff.DrawLine(OrPen, CInt(X), CInt(Y + Ht * 3 / 4), CInt(X + Wd), CInt(Y + Ht * 3 / 4))
        gOff.DrawLine(OrPen, CInt(X + Wd / 2), CInt(Y + Ht * 3 / 4), CInt(X + Wd / 2), CInt(Y + Ht))
        gOff.DrawLine(OrPen, CInt(X), CInt(Y + Ht / 4), CInt(X + Wd), CInt(Y + Ht / 4))
        gOff.DrawLine(OrPen, CInt(X + Wd / 2), Y, CInt(X + Wd / 2), CInt(Y + Ht / 4))
    End Sub

    Public Sub writeSPlanet(ByVal gOff As Graphics, ByVal X As Single, ByVal Y As Single, ByVal Wd As Single, ByVal Ht As Single, ByVal PinH() As String, ByVal ShowAsc As Integer)
        Dim myFont As Font = New Font("Tahoma", 8, FontStyle.Regular)
        Dim myBrush As Brush = Brushes.Black
        Dim drawFormat As New StringFormat
        drawFormat.Alignment = StringAlignment.Center
        drawFormat.LineAlignment = StringAlignment.Near
        gOff.SmoothingMode = Drawing2D.SmoothingMode.None
        Dim Xa, Ya As Integer
        If ShowAsc = 1 Or ShowAsc = 8 Then
            Xa = X + 0.375 * Wd - 13.68
        ElseIf ShowAsc = 2 Or ShowAsc = 7 Then
            Xa = X + 0.625 * Wd - 13.68
        ElseIf ShowAsc = 3 Or ShowAsc = 4 Or ShowAsc = 5 Or ShowAsc = 6 Then
            Xa = X + 0.875 * Wd - 13.68
        ElseIf ShowAsc = 9 Or ShowAsc = 10 Or ShowAsc = 11 Or ShowAsc = 12 Then
            Xa = X + 0.125 * Wd - 13.68
        End If
        If ShowAsc = 1 Or ShowAsc = 2 Or ShowAsc = 3 Or ShowAsc = 12 Then
            Ya = Y + 0
        ElseIf ShowAsc = 4 Or ShowAsc = 11 Then
            Ya = Y + 0.25 * Ht
        ElseIf ShowAsc = 5 Or ShowAsc = 10 Then
            Ya = Y + 0.5 * Ht
        ElseIf ShowAsc = 9 Or ShowAsc = 8 Or ShowAsc = 7 Or ShowAsc = 6 Then
            Ya = Y + 0.75 * Ht
        End If
        If ShowAsc <> 0 Then
            Dim drawRect As New RectangleF(Xa, Ya, 27.36, 15.84)
            gOff.DrawString("ASC", myFont, Brushes.Black, drawRect, drawFormat)
        End If
        drawFormat.Alignment = StringAlignment.Center
        drawFormat.LineAlignment = StringAlignment.Center
        Dim drawRect1 As New RectangleF(X + Wd / 4, Y, Wd / 4, Ht / 4)
        gOff.DrawString(PinH(1), myFont, myBrush, drawRect1, drawFormat)
        Dim drawRect2 As New RectangleF(X + Wd / 2, Y, Wd / 4, Ht / 4)
        gOff.DrawString(PinH(2), myFont, myBrush, drawRect2, drawFormat)
        Dim drawRect3 As New RectangleF(X + Wd * 3 / 4, Y, Wd / 4, Ht / 4)
        gOff.DrawString(PinH(3), myFont, myBrush, drawRect3, drawFormat)
        Dim drawRect4 As New RectangleF(X + Wd * 3 / 4, Y + Ht / 4, Wd / 4, Ht / 4)
        gOff.DrawString(PinH(4), myFont, myBrush, drawRect4, drawFormat)
        Dim drawRect5 As New RectangleF(X + Wd * 3 / 4, Y + Ht / 2, Wd / 4, Ht / 4)
        gOff.DrawString(PinH(5), myFont, myBrush, drawRect5, drawFormat)
        Dim drawRect6 As New RectangleF(X + Wd * 3 / 4, Y + Ht * 3 / 4, Wd / 4, Ht / 4)
        gOff.DrawString(PinH(6), myFont, myBrush, drawRect6, drawFormat)
        Dim drawRect7 As New RectangleF(X + Wd / 2, Y + Ht * 3 / 4, Wd / 4, Ht / 4)
        gOff.DrawString(PinH(7), myFont, myBrush, drawRect7, drawFormat)
        Dim drawRect8 As New RectangleF(X + Wd / 4, Y + Ht * 3 / 4, Wd / 4, Ht / 4)
        gOff.DrawString(PinH(8), myFont, myBrush, drawRect8, drawFormat)
        Dim drawRect9 As New RectangleF(X, Y + Ht * 3 / 4, Wd / 4, Ht / 4)
        gOff.DrawString(PinH(9), myFont, myBrush, drawRect9, drawFormat)
        Dim drawRect10 As New RectangleF(X, Y + Ht / 2, Wd / 4, Ht / 4)
        gOff.DrawString(PinH(10), myFont, myBrush, drawRect10, drawFormat)
        Dim drawRect11 As New RectangleF(X, Y + Ht / 4, Wd / 4, Ht / 4)
        gOff.DrawString(PinH(11), myFont, myBrush, drawRect11, drawFormat)
        Dim drawRect12 As New RectangleF(X, Y, Wd / 4, Ht / 4)
        gOff.DrawString(PinH(12), myFont, myBrush, drawRect12, drawFormat)
    End Sub
End Module
