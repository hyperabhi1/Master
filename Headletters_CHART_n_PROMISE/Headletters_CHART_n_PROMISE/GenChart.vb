Imports System.Collections.Specialized
Imports System.Data.SqlClient
Imports System.Globalization
Imports System.IO
Imports CommonDLL
Module Connstr
    'Public connstr = "data source=DESKTOP-JBRFH9E;initial catalog=HEADLETTERS_ENGINE;integrated security=True;"
    'Public connstr = "data source=WIN-KSTUPT6CJRC;initial catalog=HEADLETTERS_ENGINE;integrated security=True;multipleactiveresultsets=True;"
    'Public constr = "data source=WIN-KSTUPT6CJRC;initial catalog=ASTROLOGYSOFTWARE_DB;integrated security=False;multipleactiveresultsets=True;User Id=sa;password=pSI)TA1t0K[);"
    'Public constr = "data source=WIN-KSTUPT6CJRC;initial catalog=ASTROLOGYSOFTWARE_DB;integrated security=False;multipleactiveresultsets=True;User Id=sa;password=pSI)TA1t0K[);"
    Public Constr = "data source=49.50.103.132;initial catalog=HEADLETTERS_ENGINE;integrated security=False;User Id=sa;password=pSI)TA1t0K[)"
    'Public Constr = "data source=49.50.90.23;initial catalog=HEADLETTERS_ENGINE;integrated security=False;User Id=sa;password=)QPWmL8%085x"

End Module
Public Class GenChart
    Dim ST(12) As String
    Dim C As String() = {"01", "02", "03", "04", "05", "06", "07", "08", "09", "10", "11", "12"}
    Sub Main()
        Dim UID = ""
        Dim HID = ""
        Dim personalDetails As PersonalDetails = New PersonalDetails()
        Dim P_list(12) As String
        Dim H_List(12) As String
        Dim HstrCusp(12) As String
        Dim Hplanets(12) As String
        Dim BirthLagna(12, 2) As String
        Dim BirthBhav(12, 2) As String
        Dim BirthSouth(12) As String
        Dim Horo As New TASystem.TrueAstro

        Dim connection As SqlConnection = New SqlConnection(Constr)
        Try
            Dim cmd As New SqlCommand($"SELECT HUSERID, HID, RECTIFIEDDATE, RECTIFIEDTIME, RECTIFIEDDST, RECTIFIEDPLACE, RECTIFIEDLONGTITUDE, RECTIFIEDLONGTITUDEEW, RECTIFIEDLATITUDE,
                                        RECTIFIEDLATITUDENS, RECTIFIEDTIMEZONE, HNAME, HDOBNATIVE, HPLACE, HHOURS, HMIN, HSS, HAMPM, HMARRIAGEDATE, HFIRSTCHILDPLACE, HCRDATE, HDRR, HDRRD, RECTIFIEDDATESTRING
	                                    FROM ASTROLOGYSOFTWARE_DB.DBO.HMAIN WHERE RECTIFIEDTIME IS NOT NULL AND RECTIFIEDDATE IS NOT NULL AND RECTIFIEDDST IS NOT NULL AND RECTIFIEDDATESTRING IS NOT NULL
                                        AND RECTIFIEDTIMEZONE IS NOT NULL AND HSTATUS = '2';", connection)
            Dim da As New SqlDataAdapter(cmd)
            Dim RowsData As New DataSet()
            da.Fill(RowsData)
            For i As Integer = 0 To RowsData.Tables(0).Rows.Count - 1
                Try
                    Dim DateTimeB As New NameValueCollection
                    Dim PlaceDataB As New NameValueCollection
                    Dim BData As New NameValueCollection
                    Dim PlaceData As New NameValueCollection
                    Dim BasicData As New NameValueCollection
                    UID = RowsData.Tables(0).Rows(i)(0).Trim.ToString()
                    HID = RowsData.Tables(0).Rows(i)(1).Trim.ToString()
                    Dim RECTIFIEDDATESTRING = RowsData.Tables(0).Rows(i)(23).ToString().Trim
                    '10/10/1994 22:10:10.000
                    Dim RECTIFIEDDATE_Personal = RECTIFIEDDATESTRING
                    Dim RECTIFIEDDATE = CType(RowsData.Tables(0).Rows(i)(2), DateTime).ToString("yyyy-MM-dd HH:mm:ss.fff", CultureInfo.InvariantCulture)
                    Dim RECTIFIEDTIME = CType(RowsData.Tables(0).Rows(i)(3).ToString(), DateTime).ToString("HH:mm:ss.fff", CultureInfo.InvariantCulture)
                    Dim RECTIFIEDDST = RowsData.Tables(0).Rows(i)(4).ToString().Trim
                    Dim RECTIFIEDPLACE = RowsData.Tables(0).Rows(i)(5).ToString().Trim
                    Dim RECTIFIEDLONGTITUDE = RowsData.Tables(0).Rows(i)(6).Trim.ToString().Trim
                    Dim RECTIFIEDLONGTITUDEEW = RowsData.Tables(0).Rows(i)(7).ToString().Trim
                    Dim RECTIFIEDLATITUDE = RowsData.Tables(0).Rows(i)(8).ToString().Trim
                    Dim RECTIFIEDLATITUDENS = RowsData.Tables(0).Rows(i)(9).ToString().Trim
                    Dim RECTIFIEDTZ = RowsData.Tables(0).Rows(i)(10).ToString().Trim
                    Dim Year = RECTIFIEDDATESTRING.Split("/")(2).Substring(0, 4)
                    Dim Month = RECTIFIEDDATESTRING.Split("/")(1)
                    Dim Day = RECTIFIEDDATESTRING.Split("/")(0)
                    Dim Hour = RECTIFIEDDATESTRING.Split(" ")(1).Substring(0, 2)
                    Dim Min = RECTIFIEDDATESTRING.Split(":")(1)
                    Dim Sec = RECTIFIEDDATESTRING.Split(":")(2).Substring(0, 2)
                    Dim MSec = RECTIFIEDDATESTRING.Split(".")(1)
                    BData.Add("Year", Year)
                    BData.Add("Month", Month)
                    BData.Add("Day", Day)
                    BData.Add("Hour", Hour)
                    BData.Add("Min", Min)
                    BData.Add("Sec", Sec)
                    BData.Add("mSec", MSec)
                    DateTimeB = BData
                    Dim Place = ""
                    Dim State = ""
                    Dim Country = ""
                    If RECTIFIEDPLACE.Split("-").Length = 3 Then
                        Place = RECTIFIEDPLACE.Split("-")(0)
                        State = RECTIFIEDPLACE.Split("-")(1)
                        Country = RECTIFIEDPLACE.Split("-")(2)
                    ElseIf RECTIFIEDPLACE.Split("-").Length = 2 Then
                        Place = RECTIFIEDPLACE.Split("-")(0)
                        State = "NA"
                        Country = RECTIFIEDPLACE.Split("-")(2)
                    ElseIf RECTIFIEDPLACE.Split("-").Length = 1 Then
                        Place = RECTIFIEDPLACE.Split("-")(0)
                        State = "NA"
                        Country = "NA"
                    ElseIf RECTIFIEDPLACE.Contains("-") <> False Then
                        Place = RECTIFIEDPLACE
                        State = "NA"
                        Country = "NA"
                    Else
                        Throw New System.Exception("Invalid RECTIFIEDPLACE format exception.")
                    End If
                    Dim lon, lat, geoLat, Tz As Double
                    lon = RECTIFIEDLONGTITUDE.Split("^")(0) + RECTIFIEDLONGTITUDE.Split("^")(1) / 60 + RECTIFIEDLONGTITUDE.Split("^")(2) / 3600
                    geoLat = RECTIFIEDLATITUDE.Split("^")(0) + RECTIFIEDLATITUDE.Split("^")(1) / 60 + RECTIFIEDLATITUDE.Split("^")(2) / 3600
                    Dim eW = RECTIFIEDLONGTITUDEEW
                    Dim nS = RECTIFIEDLATITUDENS
                    If eW = "W" Then
                        lon = -lon
                        Tz = -Tz
                    End If
                    lat = (Math.Atan(Math.Tan(geoLat * Math.PI / 180) * 0.99330546)) * 180 / Math.PI
                    If nS = "S" Then
                        lat = -lat
                    End If
                    Dim TzB = Val(RECTIFIEDTZ.Split(":")(0).Substring(1, 2)) + RECTIFIEDTZ.Split(":")(1) / 60
                    Dim DstB = RECTIFIEDDST
                    PlaceData.Add("Place", Place)
                    PlaceData.Add("State", State)
                    PlaceData.Add("Country", Country)
                    PlaceData.Add("lonB", lon)
                    PlaceData.Add("latB", lat)
                    PlaceData.Add("eW", eW)
                    PlaceData.Add("nS", nS)
                    PlaceData.Add("TzB", TzB)
                    PlaceData.Add("DstB", DstB)
                    PlaceDataB = PlaceData
                    Horo.getBirthPlanetCusp(DateTimeB, PlaceDataB, P_list, H_List)
                    Horo.getBirthLagnaBhav(DateTimeB, PlaceDataB, BirthLagna, BirthBhav, BirthSouth)
                    Dim DasaListP As New DataTable
                    DasaListP.Columns.Add("Dasha")
                    DasaListP.Columns.Add("Bhukti")
                    DasaListP.Columns.Add("Antara")
                    DasaListP.Columns.Add("Suk")
                    DasaListP.Columns.Add("Pra")
                    DasaListP.Columns.Add("Cl_Date")
                    Horo.getBirthDasaDBA(DateTimeB, PlaceDataB, DasaListP)
                    Horo.getBirthInfo(DateTimeB, PlaceDataB, BasicData)
#Region "Personal Details"
                    personalDetails.DateofBirth = RECTIFIEDDATE_Personal.Split(" ")(0)
                    personalDetails.DayofBirth = CommonController.GetDayOfTheWeek(DateTime.Parse(RECTIFIEDDATE.Split(" ")(0).Replace("-", "/")).DayOfWeek)
                    personalDetails.TimeofBirth = RECTIFIEDDATE_Personal.Split(" ")(1)
                    personalDetails.PlaceofBirth = RECTIFIEDPLACE
                    personalDetails.Latitude = RECTIFIEDLATITUDE.Split("^")(0) + "° " + RECTIFIEDLATITUDE.Split("^")(1) + "' " + RECTIFIEDLATITUDE.Split("^")(2) + """ " & RECTIFIEDLATITUDENS
                    personalDetails.Longitude = RECTIFIEDLONGTITUDE.Split("^")(0) + "° " + RECTIFIEDLONGTITUDE.Split("^")(1) + "' " + RECTIFIEDLONGTITUDE.Split("^")(2) + """ " & RECTIFIEDLONGTITUDEEW
                    personalDetails.NameoftheChartOwner = RowsData.Tables(0).Rows(i)(11).ToString().Trim
                    personalDetails.Rashi = BasicData("Rashi")
                    personalDetails.Star = BasicData("NakPada")
                    personalDetails.SunSign = BasicData("WestRashi")
                    personalDetails.BalanceDasa = BasicData("DasaBal")
                    Dim DOB__ = RowsData.Tables(0).Rows(i)(12).ToString().Trim.Split(" ")(0)
                    personalDetails.OriginalDOBByChartOwner = DOB__.Split("/")(1) + "-" + DOB__.Split("/")(0) + "-" + DOB__.Split("/")(2)
                    personalDetails.OriginalPOBByChartOwner = RowsData.Tables(0).Rows(i)(13).ToString().Trim
                    personalDetails.OriginalTOBByChartOwner = RowsData.Tables(0).Rows(i)(14).ToString() + ":" + RowsData.Tables(0).Rows(i)(15).ToString() + ":" + RowsData.Tables(0).Rows(i)(16).ToString() + " " + RowsData.Tables(0).Rows(i)(17).Trim
                    personalDetails.Marriage = If(RowsData.Tables(0).Rows(i)(18).ToString().Trim.ToUpper() = "NULL", "", RowsData.Tables(0).Rows(i)(18).ToString().Trim)
                    personalDetails.FirstChild = If(RowsData.Tables(0).Rows(i)(19).ToString().Trim.ToUpper() = "NULL", "", RowsData.Tables(0).Rows(i)(19).ToString().Trim)
                    personalDetails.LastCallRecieved = If(RowsData.Tables(0).Rows(i)(20).ToString().Trim.ToUpper() = "NULL", "", RowsData.Tables(0).Rows(i)(20).ToString().Trim)
                    personalDetails.DemiseOfRelatives = If(RowsData.Tables(0).Rows(i)(21).ToString().Trim.ToUpper() = "NULL", "", RowsData.Tables(0).Rows(i)(21).ToString().Trim)
#End Region
                    DELETE_ALL_RECORDS(UID, HID)
                    DBController.UPDATE_HCUSP(UID, HID, H_List)
                    DBController.UPDATE_HPLANET(UID, HID, P_list)
                    DBController.UPDATE_HDASA(UID, HID, DasaListP)

                    Dim HCUSPList = DBController.Select_HCUSP(UID, HID)
                    GetCuspString(HCUSPList, ST)
                    Dim HPLANETList = DBController.Select_HPLANET(UID, HID)
                    UpdateCuspString(HPLANETList, ST)

                    DBController.WriteToCUSP(UID, HID, C, ST)
                    WriteToHRAKE(UID, HID)

                    Dim genHTMLChart As GenHTMLChart = New GenHTMLChart()
                    genHTMLChart.GenHTMLChartMain(HID, UID, P_list, H_List, BirthLagna, BirthBhav, BirthSouth, DasaListP, personalDetails)
                    Dim Promise_ As New Promise()
                    Promise_.MainHIDUID(UID, HID)
                    DBController.UPDATE_HMAIN_CHARTnPROMISE(UID, HID)

                Catch ex As Exception
                    Dim strFile As String = String.Format("C:\Astro\ServiceLogs\Errors\ChartGen_Error.txt")
                    File.AppendAllText(strFile, String.Format(vbCrLf + "Error Occured at-- {0}{1}{2}", Environment.NewLine + DateTime.Now, Environment.NewLine, ex.Message + vbCrLf + ex.StackTrace))
                    Continue For
                End Try
            Next
        Catch ex As Exception
            Dim strFile As String = String.Format("C:\Astro\ServiceLogs\Errors\ChartGen_Error.txt")
            File.AppendAllText(strFile, String.Format(vbCrLf + "Error Occured at-- {0}{1}{2}", Environment.NewLine + DateTime.Now, Environment.NewLine, ex.Message + vbCrLf + ex.StackTrace))
        Finally
            connection.Close()
        End Try
    End Sub
    Sub DELETE_ALL_RECORDS(ByRef UID As String, ByRef HID As String)
        DBController.DELETE_CUSP(UID, HID)
        DBController.DELETE_HCUSP(UID, HID)
        DBController.DELETE_HPLANET(UID, HID)
        DBController.DELETE_HDASA(UID, HID)
        DBController.DELETE_HRAKE(UID, HID)
    End Sub
    Sub GetCuspString(ByVal HCUSPList As List(Of HCUSP), ByRef ST() As String)
        For i = 0 To 11
            ST(i) = HCUSPList(i).CP1 + HCUSPList(i).CP2 + HCUSPList(i).CP3
        Next
    End Sub
    Function GetPlanetShortName(ByVal Pl As String)
        Dim Planet As String = "Not_A_Planet"
        Select Case Pl
            Case "Mars"
                Planet = "MA"
            Case "Venus"
                Planet = "VE"
            Case "Saturn"
                Planet = "SA"
            Case "Jupiter"
                Planet = "JU"
            Case "Sun"
                Planet = "SU"
            Case "Moon"
                Planet = "MO"
            Case "Mercury"
                Planet = "ME"
            Case "T.Rahu"
                Planet = "RA"
            Case "T.Ketu"
                Planet = "KE"
            Case "Neptune"
                Planet = "NE"
            Case "Pluto"
                Planet = "PL"
            Case "Uranus"
                Planet = "UR"
        End Select
        Return Planet
    End Function
    Function GetCuspPrefix(ByVal s As String)
        Dim ov = "NA"
        Select Case s
            Case "1"
                ov = "01"
            Case "2"
                ov = "02"
            Case "3"
                ov = "03"
            Case "4"
                ov = "04"
            Case "5"
                ov = "05"
            Case "6"
                ov = "06"
            Case "7"
                ov = "07"
            Case "8"
                ov = "08"
            Case "9"
                ov = "09"
            Case "10"
                ov = "10"
            Case "11"
                ov = "11"
            Case "12"
                ov = "12"
            Case Else
        End Select
        Return ov
    End Function
    Shared Sub UpdateCuspString(ByVal HPLANETList As List(Of HPLANET), ByRef ST() As String)
        Dim FL As Boolean
        For Each _HPLANET As HPLANET In HPLANETList
            Select Case _HPLANET.HPHOUSE
                Case "01"
                    FL = CommonController.CHECKSTR(ST(0), _HPLANET.PLANET)
                    If FL = False And (ST(0).ToUpper.Contains(_HPLANET.PLANET) = False) And (_HPLANET.PLANET <> "NE") And (_HPLANET.PLANET <> "PL") And (_HPLANET.PLANET <> "UR") Then
                        ST(0) = ST(0) + _HPLANET.PLANET
                    End If
                Case "02"
                    FL = CommonController.CHECKSTR(ST(1), _HPLANET.PLANET)
                    If FL = False And (ST(1).ToUpper.Contains(_HPLANET.PLANET) = False) And (_HPLANET.PLANET <> "NE") And (_HPLANET.PLANET <> "PL") And (_HPLANET.PLANET <> "UR") Then
                        ST(1) = ST(1) + _HPLANET.PLANET
                    End If
                Case "03"
                    FL = CommonController.CHECKSTR(ST(2), _HPLANET.PLANET)
                    If FL = False And (ST(2).ToUpper.Contains(_HPLANET.PLANET) = False) And (_HPLANET.PLANET <> "NE") And (_HPLANET.PLANET <> "PL") And (_HPLANET.PLANET <> "UR") Then
                        ST(2) = ST(2) + _HPLANET.PLANET
                    End If
                Case "04"
                    FL = CommonController.CHECKSTR(ST(3), _HPLANET.PLANET)
                    If FL = False And (ST(3).ToUpper.Contains(_HPLANET.PLANET) = False) And (_HPLANET.PLANET <> "NE") And (_HPLANET.PLANET <> "PL") And (_HPLANET.PLANET <> "UR") Then
                        ST(3) = ST(3) + _HPLANET.PLANET
                    End If
                Case "05"
                    FL = CommonController.CHECKSTR(ST(4), _HPLANET.PLANET)
                    If FL = False And (ST(4).ToUpper.Contains(_HPLANET.PLANET) = False) And (_HPLANET.PLANET <> "NE") And (_HPLANET.PLANET <> "PL") And (_HPLANET.PLANET <> "UR") Then
                        ST(4) = ST(4) + _HPLANET.PLANET
                    End If
                Case "06"
                    FL = CommonController.CHECKSTR(ST(5), _HPLANET.PLANET)
                    If FL = False And (ST(5).ToUpper.Contains(_HPLANET.PLANET) = False) And (_HPLANET.PLANET <> "NE") And (_HPLANET.PLANET <> "PL") And (_HPLANET.PLANET <> "UR") Then
                        ST(5) = ST(5) + _HPLANET.PLANET
                    End If
                Case "07"
                    FL = CommonController.CHECKSTR(ST(6), _HPLANET.PLANET)
                    If FL = False And (ST(6).ToUpper.Contains(_HPLANET.PLANET) = False) And (_HPLANET.PLANET <> "NE") And (_HPLANET.PLANET <> "PL") And (_HPLANET.PLANET <> "UR") Then
                        ST(6) = ST(6) + _HPLANET.PLANET
                    End If
                Case "08"
                    FL = CommonController.CHECKSTR(ST(7), _HPLANET.PLANET)
                    If FL = False And (ST(7).ToUpper.Contains(_HPLANET.PLANET) = False) And (_HPLANET.PLANET <> "NE") And (_HPLANET.PLANET <> "PL") And (_HPLANET.PLANET <> "UR") Then
                        ST(7) = ST(7) + _HPLANET.PLANET
                    End If
                Case "09"
                    FL = CommonController.CHECKSTR(ST(8), _HPLANET.PLANET)
                    If FL = False And (ST(8).ToUpper.Contains(_HPLANET.PLANET) = False) And (_HPLANET.PLANET <> "NE") And (_HPLANET.PLANET <> "PL") And (_HPLANET.PLANET <> "UR") Then
                        ST(8) = ST(8) + _HPLANET.PLANET
                    End If
                Case "10"
                    FL = CommonController.CHECKSTR(ST(9), _HPLANET.PLANET)
                    If FL = False And (ST(9).ToUpper.Contains(_HPLANET.PLANET) = False) And (_HPLANET.PLANET <> "NE") And (_HPLANET.PLANET <> "PL") And (_HPLANET.PLANET <> "UR") Then
                        ST(9) = ST(9) + _HPLANET.PLANET
                    End If
                Case "11"
                    FL = CommonController.CHECKSTR(ST(10), _HPLANET.PLANET)
                    If FL = False And (ST(10).ToUpper.Contains(_HPLANET.PLANET) = False) And (_HPLANET.PLANET <> "NE") And (_HPLANET.PLANET <> "PL") And (_HPLANET.PLANET <> "UR") Then
                        ST(10) = ST(10) + _HPLANET.PLANET
                    End If
                Case "12"
                    FL = CommonController.CHECKSTR(ST(11), _HPLANET.PLANET)
                    If FL = False And (ST(11).ToUpper.Contains(_HPLANET.PLANET) = False) And (_HPLANET.PLANET <> "NE") And (_HPLANET.PLANET <> "PL") And (_HPLANET.PLANET <> "UR") Then
                        ST(11) = ST(11) + _HPLANET.PLANET
                    End If
                Case Else
            End Select
        Next
    End Sub
    Sub WriteToHRAKE(ByRef UID As String, ByRef HID As String)
        Dim FR1 As String = ""
        Dim FK1 As String = ""
        Dim R1 As String = ""
        Dim R2 As String = ""
        Dim K1 As String = ""
        Dim K2 As String = ""
        Dim SelectHPLANET_RA = "SELECT * FROM HEADLETTERS_ENGINE.DBO.HPLANET WHERE PLHUSERID = '" + UID + "' AND PLHID = '" + HID + "' AND PLANET = 'RA'"
        Dim SelectHPLANET_KE = "SELECT * FROM HEADLETTERS_ENGINE.DBO.HPLANET WHERE PLHUSERID = '" + UID + "' AND PLHID = '" + HID + "' AND PLANET = 'KE'"
        Dim connection As SqlConnection = New SqlConnection(constr)
        connection.Open()
        Dim cmd As New SqlCommand(SelectHPLANET_RA, connection)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet()
        da.Fill(ds)
        R1 = (ds.Tables(0).Rows(0)).ItemArray(5).ToString()
        R2 = (ds.Tables(0).Rows(0)).ItemArray(6).ToString()
        Dim cmd0 As New SqlCommand(SelectHPLANET_KE, connection)
        Dim da0 As New SqlDataAdapter(cmd0)
        Dim ds0 As New DataSet()
        da0.Fill(ds0)
        K1 = (ds0.Tables(0).Rows(0)).ItemArray(5).ToString()
        K2 = (ds0.Tables(0).Rows(0)).ItemArray(6).ToString()
        connection.Close()

        Dim FLX As Boolean = True
        FLX = CommonController.CHECKSTR(FR1, R1)
        If FLX = False And R1 IsNot "RA" Then
            FR1 = FR1 + R1
        End If
        FLX = CommonController.CHECKSTR(FR1, R2)
        If FLX = False And R1 IsNot "RA" Then
            FR1 = FR1 + R2
        End If
        FLX = CommonController.CHECKSTR(FK1, K1)
        If FLX = False And K1 IsNot "KE" Then
            FK1 = FK1 + K1
        End If
        FLX = CommonController.CHECKSTR(FK1, K2)
        If FLX = False And K1 IsNot "KE" Then
            FK1 = FK1 + K2
        End If
        'CHECK FOR RA AND KE AS DUPLICATES
        FLX = CommonController.CHECKSTR(FR1, "KE")
        If FLX = True Then
            FLX = CommonController.CHECKSTR(FR1, K1)
            If FLX = False And K1 IsNot "RA" Then
                FR1 = FR1 + K1
            End If
            FLX = CommonController.CHECKSTR(FR1, K2)
            If FLX = False And K2 IsNot "RA" Then
                FR1 = FR1 + K2
            End If
        End If
        FLX = CommonController.CHECKSTR(FK1, "RA")
        If FLX = True Then
            FLX = CommonController.CHECKSTR(FK1, R1)
            If FLX = False And R1 IsNot "KE" Then
                FK1 = FK1 + R1
            End If
            If FLX = False And R2 IsNot "KE" Then
                FK1 = FK1 + R2
            End If
        End If
        FR1 = FR1.ToUpper()
        Dim R = FR1
        FK1 = FK1.ToUpper()
        Dim K = FK1
        If FR1.Contains("KE") Then
            FR1 = FR1.Replace("KE", "KE" + K)
        End If
        If FK1.ToUpper.Contains("RA") Then
            FK1 = FK1.Replace("RA", "RA" + R)
        End If
        Dim FR1_ARRAY = CommonController.SplitInTwoChar(FR1).ToList()
        Dim FR1_DISTINCT = FR1_ARRAY.Distinct().ToArray()
        Dim FR = String.Join("", FR1_DISTINCT)
        Dim FK1_ARRAY = CommonController.SplitInTwoChar(FK1).ToList()
        Dim FK1_DISTINCT = FK1_ARRAY.Distinct().ToArray()
        Dim FK = String.Join("", FK1_DISTINCT)
        Dim InsertHRAKE_RA = "INSERT INTO HEADLETTERS_ENGINE.DBO.HRAKE VALUES ('" + UID + "','" + HID + "','RA','" + FR + "');"
        Dim InsertHRAKE_KE = "INSERT INTO HEADLETTERS_ENGINE.DBO.HRAKE VALUES ('" + UID + "','" + HID + "','KE','" + FK + "');"
        connection.Open()
        Dim cmd1 As New SqlCommand(InsertHRAKE_RA + InsertHRAKE_KE, connection)
        Dim da1 As New SqlDataAdapter(cmd1)
        Dim ds1 As New DataSet()
        da1.Fill(ds1)
        connection.Close()
    End Sub
End Class
Public Class PersonalDetails
    Public Property NameoftheChartOwner As String
    Public Property DateofBirth As String
    Public Property PlaceofBirth As String
    Public Property TimeofBirth As String
    Public Property Latitude As String
    Public Property Longitude As String
    Public Property DayofBirth As String
    Public Property Rashi As String
    Public Property Star As String
    Public Property SunSign As String
    Public Property BalanceDasa As String
    Public Property OriginalDOBByChartOwner As String
    Public Property OriginalPOBByChartOwner As String
    Public Property OriginalTOBByChartOwner As String
    Public Property Marriage As String
    Public Property FirstChild As String
    Public Property LastCallRecieved As String
    Public Property DemiseOfRelatives As String
End Class