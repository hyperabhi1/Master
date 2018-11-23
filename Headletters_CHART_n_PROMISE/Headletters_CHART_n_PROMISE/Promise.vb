Imports System.Data.SqlClient
Imports CommonDLL

Public Class Promise
    Dim HID = ""
    Dim UID = ""
    Dim RQID = ""
    'Public constr = "data source=DESKTOP-JBRFH9E;initial catalog=HEADLETTERS_ENGINE;integrated security=True;"
    'Public constr = "data source=WIN-KSTUPT6CJRC;initial catalog=HEADLETTERS_ENGINE;integrated security=True;multipleactiveresultsets=True;"
    Public constr = "data source=49.50.103.132;initial catalog=HEADLETTERS_ENGINE;integrated security=False;User Id=sa;password=pSI)TA1t0K[)"
    'Public constr = "data source=WIN-KSTUPT6CJRC;initial catalog=HEADLETTERS_ENGINE;integrated security=False;multipleactiveresultsets=True;User Id=sa;password=pSI)TA1t0K[);"

    Sub MainHIDUID(ByVal UID As String, ByVal HID As String)
        Dim HCUSPList As New List(Of HCUSP)
        Dim HRAKEList As New List(Of HRAKE)
        Dim HPLANETList As New List(Of HPLANET)
        Dim HCUSPCALCList As New List(Of HCUSP_CALC)
        DELETE_RECORDS(UID, HID)
        HRAKEList = DBController.Select_HRAKE(UID, HID)
        HCUSPList = DBController.Select_HCUSP(UID, HID)
        HPLANETList = DBController.Select_HPLANET(UID, HID)
        Conversion_of_HCUSP_for_RAKE(UID, HID, HCUSPList, HRAKEList)
        Conversion_of_HPLANET_for_RAKE(UID, HID, HPLANETList, HRAKEList)
        Update_HCUSP_CALCList(UID, HID, HCUSPList, HPLANETList, HCUSPCALCList)
        DBController.INSERT_INTO_HCUSP_CALC(UID, HID, HCUSPCALCList)
        Dim HCUSP_CALCList As New List(Of HCUSP_CALC)
        Dim HCUSP_SIGN_SUBList As New List(Of HCUSP_SIGN_SUB)
        Dim Y1List As New List(Of Y1)
        HCUSP_CALCList.Clear()
        HCUSP_CALCList = DBController.Select_HCUSP_CALC(UID, HID)
        Get_From_HCUSPCALC_and_Insert_in_Y1(UID, HID, HCUSP_CALCList)
        Y1List = DBController.Select_Y1(UID, HID)
        DBController.Get_From_Y1_and_Insert_in_HCUSP_PROMISE_LINK(UID, HID, Y1List)

        Dim DAILY_RULES_SUBList As New List(Of DAILY_RULES_SUB)
        Dim DAILY_RULES_TEMPLATEList As New List(Of DAILY_RULES_TEMPLATE)
        Dim HCUSP_PROMISE_LINKList As New List(Of HCUSP_PROMISE_LINK)
        Dim DAILY_RULES_MAINList As New List(Of DAILY_RULES_MAIN)
        DAILY_RULES_TEMPLATEList = DBController.Select_DAILY_RULES_TEMPLATE()
        DAILY_RULES_SUBList = DBController.Select_DAILY_RULES_SUB(UID, HID)
        HCUSP_PROMISE_LINKList = DBController.Select_HCUSP_PROMISE_LINK(UID, HID)
        DBController.UPDATE_DAILY_RULES_MAIN(UID, HID, DAILY_RULES_TEMPLATEList)
        DAILY_RULES_MAINList = DBController.Select_DAILY_RULES_MAIN(UID, HID)
        Process_Promise1(UID, HID, DAILY_RULES_MAINList, DAILY_RULES_SUBList, HCUSP_PROMISE_LINKList)
        DBController.DELETE_HPROMISE(UID, HID)
        DAILY_RULES_MAINList.Clear()
        DAILY_RULES_MAINList = DBController.Select_DAILY_RULES_MAIN(UID, HID)
        DBController.DELETE_HPROMISE(UID, HID)
        DBController.INSERT_INTO_HPROMISE(UID, HID, DAILY_RULES_MAINList)
    End Sub
    Sub DELETE_RECORDS(ByVal UID As String, ByVal HID As String)
        DBController.DELETE_HCUSP_CALC(UID, HID)
        DBController.DELETE_HCUSP_SIGN_SUB(UID, HID)
        DBController.DELETE_Y1(UID, HID)
        DBController.DELETE_HCUSP_PROMISE_LINK(UID, HID)
        DBController.DELETE_DAILY_RULES_MAIN(UID, HID)
        DBController.DELETE_HPROMISE(UID, HID)
    End Sub
    Sub Conversion_of_HCUSP_for_RAKE(ByVal UID As String, ByVal HID As String, ByVal HCUSPList As List(Of HCUSP), ByVal HRAKEList As List(Of HRAKE))
        Dim HcuspListCount = HCUSPList.Count - 1
        For i As Integer = 0 To HcuspListCount
            If HCUSPList.Item(i).CP1 = "RA" Then
                Dim CP1Expand = "RA"
                Dim S1SplitRA = CommonController.SplitInTwoChar(HRAKEList.Item(0).S1.ToString().Trim)
                For j As Integer = 0 To S1SplitRA.Length - 1
                    If S1SplitRA(j) = "KE" Then
                        CP1Expand = CP1Expand + "KE"
                        Dim S1SplitKE = CommonController.SplitInTwoChar(HRAKEList.Item(1).S1.ToString().Trim)
                        For k As Integer = 0 To S1SplitKE.Length - 1
                            CP1Expand = CP1Expand + S1SplitKE(k)
                        Next
                    Else
                        CP1Expand = CP1Expand + S1SplitRA(j)
                    End If
                Next
                HCUSPList.Item(i).CP1 = CP1Expand
            ElseIf HCUSPList.Item(i).CP1 = "KE" Then
                Dim CP1Expand = "KE"
                Dim S1SplitKE = CommonController.SplitInTwoChar(HRAKEList.Item(1).S1.ToString().Trim)
                For j As Integer = 0 To S1SplitKE.Length - 1
                    If S1SplitKE(j) = "RA" Then
                        CP1Expand = CP1Expand + "RA"
                        Dim S1SplitRA = CommonController.SplitInTwoChar(HRAKEList.Item(0).S1.ToString().Trim)
                        For k As Integer = 0 To S1SplitRA.Length - 1
                            CP1Expand = CP1Expand + S1SplitRA(k)
                        Next
                    Else
                        CP1Expand = CP1Expand + S1SplitKE(j)
                    End If
                Next
                HCUSPList.Item(i).CP1 = CP1Expand
            End If
            If HCUSPList.Item(i).CP2 = "RA" Then
                Dim CP2Expand = "RA"
                Dim S1SplitRA = CommonController.SplitInTwoChar(HRAKEList.Item(0).S1.ToString().Trim)
                For j As Integer = 0 To S1SplitRA.Length - 1
                    If S1SplitRA(j) = "KE" Then
                        CP2Expand = CP2Expand + "KE"
                        Dim S1SplitKE = CommonController.SplitInTwoChar(HRAKEList.Item(1).S1.ToString().Trim)
                        For k As Integer = 0 To S1SplitKE.Length - 1
                            CP2Expand = CP2Expand + S1SplitKE(k)
                        Next
                    Else
                        CP2Expand = CP2Expand + S1SplitRA(j)
                    End If
                Next
                HCUSPList.Item(i).CP2 = CP2Expand
            ElseIf HCUSPList.Item(i).CP2 = "KE" Then
                Dim CP2Expand = "KE"
                Dim S1SplitKE = CommonController.SplitInTwoChar(HRAKEList.Item(1).S1.ToString().Trim)
                For j As Integer = 0 To S1SplitKE.Length - 1
                    If S1SplitKE(j) = "RA" Then
                        CP2Expand = CP2Expand + "RA"
                        Dim S1SplitRA = CommonController.SplitInTwoChar(HRAKEList.Item(0).S1.ToString().Trim)
                        For k As Integer = 0 To S1SplitRA.Length - 1
                            CP2Expand = CP2Expand + S1SplitRA(k)
                        Next
                    Else
                        CP2Expand = CP2Expand + S1SplitKE(j)
                    End If
                Next
                HCUSPList.Item(i).CP2 = CP2Expand
            End If
            If HCUSPList.Item(i).CP3 = "RA" Then
                Dim CP3Expand = "RA"
                Dim S1SplitRA = CommonController.SplitInTwoChar(HRAKEList.Item(0).S1.ToString().Trim)
                For j As Integer = 0 To S1SplitRA.Length - 1
                    If S1SplitRA(j) = "KE" Then
                        CP3Expand = CP3Expand + "KE"
                        Dim S1SplitKE = CommonController.SplitInTwoChar(HRAKEList.Item(1).S1.ToString().Trim)
                        For k As Integer = 0 To S1SplitKE.Length - 1
                            CP3Expand = CP3Expand + S1SplitKE(k)
                        Next
                    Else
                        CP3Expand = CP3Expand + S1SplitRA(j)
                    End If
                Next
                HCUSPList.Item(i).CP3 = CP3Expand
            ElseIf HCUSPList.Item(i).CP3 = "KE" Then
                Dim CP3Expand = "KE"
                Dim S1SplitKE = CommonController.SplitInTwoChar(HRAKEList.Item(1).S1.ToString().Trim)
                For j As Integer = 0 To S1SplitKE.Length - 1
                    If S1SplitKE(j) = "RA" Then
                        CP3Expand = CP3Expand + "RA"
                        Dim S1SplitRA = CommonController.SplitInTwoChar(HRAKEList.Item(0).S1.ToString().Trim)
                        For k As Integer = 0 To S1SplitRA.Length - 1
                            CP3Expand = CP3Expand + S1SplitRA(k)
                        Next
                    Else
                        CP3Expand = CP3Expand + S1SplitKE(j)
                    End If
                Next
                HCUSPList.Item(i).CP3 = CP3Expand
            End If
        Next
    End Sub
    Sub Conversion_of_HPLANET_for_RAKE(ByVal UID As String, ByVal HID As String, ByVal HPLANETList As List(Of HPLANET), ByVal HRAKEList As List(Of HRAKE))
        Dim HplanetListCount = HPLANETList.Count - 1
        For i As Integer = 0 To HplanetListCount
            If HPLANETList.Item(i).PLANET = "RA" Then
                Dim PlanetExpand = "RA"
                Dim S1SplitRA = CommonController.SplitInTwoChar(HRAKEList.Item(0).S1.ToString().Trim)
                For j As Integer = 0 To S1SplitRA.Length - 1
                    If S1SplitRA(j) = "KE" Then
                        PlanetExpand = PlanetExpand + "KE"
                        Dim S1SplitKE = CommonController.SplitInTwoChar(HRAKEList.Item(1).S1.ToString().Trim)
                        For k As Integer = 0 To S1SplitKE.Length - 1
                            PlanetExpand = PlanetExpand + S1SplitKE(k)
                        Next
                    Else
                        PlanetExpand = PlanetExpand + S1SplitRA(j)
                    End If
                Next
                HPLANETList.Item(i).PLANET = PlanetExpand
            ElseIf HPLANETList.Item(i).PLANET = "KE" Then
                Dim PlanetExpand = "KE"
                Dim S1SplitKE = CommonController.SplitInTwoChar(HRAKEList.Item(1).S1.ToString().Trim)
                For j As Integer = 0 To S1SplitKE.Length - 1
                    If S1SplitKE(j) = "RA" Then
                        PlanetExpand = PlanetExpand + "RA"
                        Dim S1SplitRA = CommonController.SplitInTwoChar(HRAKEList.Item(0).S1.ToString().Trim)
                        For k As Integer = 0 To S1SplitRA.Length - 1
                            PlanetExpand = PlanetExpand + S1SplitRA(k)
                        Next
                    Else
                        PlanetExpand = PlanetExpand + S1SplitKE(j)
                    End If
                Next
                HPLANETList.Item(i).PLANET = PlanetExpand
            End If
        Next
    End Sub
    Sub Update_HCUSP_CALCList(ByVal UID As String, ByVal HID As String, ByVal HCUSPList As List(Of HCUSP), ByVal HPLANETList As List(Of HPLANET), ByRef HCUSP_CALCList As List(Of HCUSP_CALC))
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        con.ConnectionString = constr
        DBController.DELETE_HCUSP_CALC(UID, HID)
        If HCUSPList.Count <> 0 Then
            For i As Integer = 0 To HCUSPList.Count - 1
                If HCUSPList.Item(i).CP1.Length > 2 Then
                    Dim HCUSPCP1 = CommonController.SplitInTwoChar(HCUSPList.Item(i).CP1)
                    For j As Integer = 0 To HCUSPCP1.Count - 1
                        Dim hCusp_Calc = New HCUSP_CALC With {.CUSPUSERID = HCUSPList.Item(i).CUSPUSERID, .CUSPHID = HCUSPList.Item(i).CUSPHID, .CUSPID = HCUSPList.Item(i).CUSP, .CUSPPLANET = HCUSPCP1(j), .CUSPTYPE = "1", .CUSPCAT = If(j = 0, "1", "3")}
                        HCUSP_CALCList.Add(hCusp_Calc)
                    Next
                Else
                    Dim hCusp_Calc = New HCUSP_CALC With {.CUSPUSERID = HCUSPList.Item(i).CUSPUSERID, .CUSPHID = HCUSPList.Item(i).CUSPHID, .CUSPID = HCUSPList.Item(i).CUSP, .CUSPPLANET = HCUSPList.Item(i).CP1, .CUSPTYPE = "1", .CUSPCAT = "1"}
                    HCUSP_CALCList.Add(hCusp_Calc)
                End If
                If HCUSPList.Item(i).CP2.Length > 2 Then
                    Dim HCUSPCP2 = CommonController.SplitInTwoChar(HCUSPList.Item(i).CP2)
                    For j As Integer = 0 To HCUSPCP2.Count - 1
                        Dim hCusp_Calc = New HCUSP_CALC With {.CUSPUSERID = HCUSPList.Item(i).CUSPUSERID, .CUSPHID = HCUSPList.Item(i).CUSPHID, .CUSPID = HCUSPList.Item(i).CUSP, .CUSPPLANET = HCUSPCP2(j), .CUSPTYPE = "2", .CUSPCAT = If(j = 0, "1", "3")}
                        HCUSP_CALCList.Add(hCusp_Calc)
                    Next
                Else
                    Dim hCusp_Calc = New HCUSP_CALC With {.CUSPUSERID = HCUSPList.Item(i).CUSPUSERID, .CUSPHID = HCUSPList.Item(i).CUSPHID, .CUSPID = HCUSPList.Item(i).CUSP, .CUSPPLANET = HCUSPList.Item(i).CP2, .CUSPTYPE = "2", .CUSPCAT = "1"}
                    HCUSP_CALCList.Add(hCusp_Calc)
                End If
                If HCUSPList.Item(i).CP3.Length > 2 Then
                    Dim HCUSPCP3 = CommonController.SplitInTwoChar(HCUSPList.Item(i).CP3)
                    For j As Integer = 0 To HCUSPCP3.Count - 1
                        Dim hCusp_Calc = New HCUSP_CALC With {.CUSPUSERID = HCUSPList.Item(i).CUSPUSERID, .CUSPHID = HCUSPList.Item(i).CUSPHID, .CUSPID = HCUSPList.Item(i).CUSP, .CUSPPLANET = HCUSPCP3(j), .CUSPTYPE = "3", .CUSPCAT = If(j = 0, "1", "3")}
                        HCUSP_CALCList.Add(hCusp_Calc)
                    Next
                Else
                    Dim hCusp_Calc = New HCUSP_CALC With {.CUSPUSERID = HCUSPList.Item(i).CUSPUSERID, .CUSPHID = HCUSPList.Item(i).CUSPHID, .CUSPID = HCUSPList.Item(i).CUSP, .CUSPPLANET = HCUSPList.Item(i).CP3, .CUSPTYPE = "3", .CUSPCAT = "1"}
                    HCUSP_CALCList.Add(hCusp_Calc)
                End If
            Next
        End If
        If HPLANETList.Count <> 0 Then
            For i As Integer = 0 To HPLANETList.Count - 1
                Dim MultiPlanetQuery = ""
                If HPLANETList.Item(i).PLANET.Length > 2 Then
                    Dim HPlanetArray = CommonController.SplitInTwoChar(HPLANETList.Item(i).PLANET)
                    For j As Integer = 0 To HPlanetArray.Count - 1
                        Dim hCusp_Calc = New HCUSP_CALC With {.CUSPUSERID = HPLANETList.Item(i).PLHUSERID, .CUSPHID = HPLANETList.Item(i).PLHID, .CUSPID = HPLANETList.Item(i).HPHOUSE, .CUSPPLANET = HPlanetArray(j), .CUSPTYPE = "7", .CUSPCAT = If(j = 0, "2", "3")}
                        HCUSP_CALCList.Add(hCusp_Calc)
                    Next
                Else
                    Dim hCusp_Calc = New HCUSP_CALC With {.CUSPUSERID = HPLANETList.Item(i).PLHUSERID, .CUSPHID = HPLANETList.Item(i).PLHID, .CUSPID = HPLANETList.Item(i).HPHOUSE, .CUSPPLANET = HPLANETList.Item(i).PLANET, .CUSPTYPE = "7", .CUSPCAT = "2"}
                    HCUSP_CALCList.Add(hCusp_Calc)
                End If
            Next
        End If
    End Sub
    Sub Get_From_HCUSPCALC_and_Insert_in_Y1(ByVal UID As String, ByVal HID As String, ByVal HCUSP_CALCList As List(Of HCUSP_CALC), Optional IsExpanded As Boolean = False)
        Dim con As SqlConnection = New SqlConnection(constr)
        Dim InsertIntoY1 = ""
        For Each HcusPCalc As HCUSP_CALC In HCUSP_CALCList
            Dim s_key = HcusPCalc.CUSPUSERID + HcusPCalc.CUSPHID + HcusPCalc.CUSPID + HcusPCalc.CUSPPLANET + HcusPCalc.CUSPTYPE.ToString + HcusPCalc.CUSPCAT
            For i = 1 To 12
                Dim s_key1 = HcusPCalc.CUSPUSERID + HcusPCalc.CUSPHID + i.ToString("D2") + HcusPCalc.CUSPPLANET + "11"
                Dim qr1 = ""
                Dim qr2 = ""
                Dim qr3 = ""
                Dim qr4 = ""
                Dim qr5 = ""
                If s_key <> s_key1 Then
                    Dim q1 = $"SELECT COUNT(*) FROM HCUSP_CALC WHERE CUSPUSERID = '" + UID + "' AND CUSPHID = '" + HID + "' AND CUSPID = '" + i.ToString("D2") + "' AND CUSPPLANET = '" + HcusPCalc.CUSPPLANET + "' AND CUSPTYPE = '1' AND CUSPCAT = '1';" + vbCrLf
                    Dim q2 = $"SELECT COUNT(*) FROM HCUSP_CALC WHERE CUSPUSERID = '" + UID + "' AND CUSPHID = '" + HID + "' AND CUSPID = '" + i.ToString("D2") + "' AND CUSPPLANET = '" + HcusPCalc.CUSPPLANET + "' AND CUSPTYPE = '2' AND CUSPCAT = '1';" + vbCrLf
                    Dim q3 = $"SELECT COUNT(*) FROM HCUSP_CALC WHERE CUSPUSERID = '" + UID + "' AND CUSPHID = '" + HID + "' AND CUSPID = '" + i.ToString("D2") + "' AND CUSPPLANET = '" + HcusPCalc.CUSPPLANET + "' AND CUSPTYPE = '3' AND CUSPCAT = '1';" + vbCrLf
                    Dim q4 = $"SELECT COUNT(*) FROM HCUSP_CALC WHERE CUSPUSERID = '" + UID + "' AND CUSPHID = '" + HID + "' AND CUSPID = '" + i.ToString("D2") + "' AND CUSPPLANET = '" + HcusPCalc.CUSPPLANET + "' AND CUSPTYPE = '7' AND CUSPCAT = '2';" + vbCrLf
                    Dim q5 = If(IsExpanded, "SELECT COUNT(*) FROM HCUSP_CALC WHERE CUSPUSERID = '" + UID + "' AND CUSPHID = '" + HID + "' AND CUSPID = '" + i.ToString("D2") + "' AND CUSPPLANET = '" + HcusPCalc.CUSPPLANET + "' AND CUSPTYPE = '7' AND CUSPCAT = '3';", "")
                    Dim cmd As New SqlCommand(q1 + q2 + q3 + q4 + q5, con)
                    Dim da As New SqlDataAdapter(cmd)
                    Dim ds As New DataSet()
                    da.Fill(ds)
                    Dim C1 = ds.Tables(0).Rows(0)(0).ToString().Trim()
                    Dim c2 = ds.Tables(1).Rows(0)(0).ToString().Trim()
                    Dim c3 = ds.Tables(2).Rows(0)(0).ToString().Trim()
                    Dim c4 = ds.Tables(3).Rows(0)(0).ToString().Trim()
                    Dim c5 = If(IsExpanded, ds.Tables(4).Rows(0)(0).ToString().Trim(), "")
                    If C1 <> "0" Then
                        qr1 = "INSERT INTO Y1 VALUES ('" + UID + "','" + HID + "', '" + HcusPCalc.CUSPID + "','" + i.ToString("D2") + "','" + HcusPCalc.CUSPPLANET + "')" + vbCrLf
                    End If
                    If c2 <> "0" Then
                        qr2 = "INSERT INTO Y1 VALUES ('" + UID + "','" + HID + "', '" + HcusPCalc.CUSPID + "','" + i.ToString("D2") + "','" + HcusPCalc.CUSPPLANET + "')" + vbCrLf
                    End If
                    If c3 <> "0" Then
                        qr3 = "INSERT INTO Y1 VALUES ('" + UID + "','" + HID + "', '" + HcusPCalc.CUSPID + "','" + i.ToString("D2") + "','" + HcusPCalc.CUSPPLANET + "')" + vbCrLf
                    End If
                    If c4 <> "0" Then
                        qr4 = "INSERT INTO Y1 VALUES ('" + UID + "','" + HID + "', '" + HcusPCalc.CUSPID + "','" + i.ToString("D2") + "','" + HcusPCalc.CUSPPLANET + "')" + vbCrLf
                    End If
                    If c5 <> "0" And c5 <> "" Then
                        qr5 = "INSERT INTO Y1 VALUES ('" + UID + "','" + HID + "', '" + HcusPCalc.CUSPID + "','" + i.ToString("D2") + "','" + HcusPCalc.CUSPPLANET + "')" + vbCrLf
                    End If
                End If
                InsertIntoY1 = InsertIntoY1 + qr1 + qr2 + qr3 + qr4 + qr5
            Next
        Next
        Dim c0n As New SqlConnection
        Dim c0d As New SqlCommand
        Try
            c0n.ConnectionString = constr
            c0n.Open()
            c0d.Connection = c0n
            c0d.CommandText = InsertIntoY1
            c0d.ExecuteNonQuery()
        Catch ex As Exception
            Dim strFile As String = String.Format("C:\Astro\ServiceLogs\Errors\Promise_Error.txt")
            IO.File.AppendAllText(strFile, String.Format(vbCrLf + "UID=> " + UID + "  ::  HID=> " + HID + vbCrLf + "Error Occured at-- {0}{1}{2}", Environment.NewLine + DateTime.Now, Environment.NewLine, ex.Message + vbCrLf + ex.StackTrace))
        Finally
            con.Close()
        End Try
    End Sub
    Sub Process_Promise1(ByVal UID As String, ByVal HID As String, ByVal DAILY_RULES_MAINList As List(Of DAILY_RULES_MAIN), ByVal DAILY_RULES_SUBList As List(Of DAILY_RULES_SUB), ByVal HCUSP_PROMISE_LINKList As List(Of HCUSP_PROMISE_LINK))
        For i As Integer = 0 To DAILY_RULES_MAINList.Count - 1
            Dim mr = DAILY_RULES_MAINList.Item(i).RULESID
            Dim FoundDRS = (From DAILY_RULES_SUB In DAILY_RULES_SUBList
                            Where DAILY_RULES_SUB.RULESID = mr
                            Select DAILY_RULES_SUB).ToList()
            If FoundDRS.Count > 0 Then
                Dim pos = 0
                Dim neg = 0
                Dim mc1 = FoundDRS.Item(0).C1
                Dim mc1pm = FoundDRS.Item(0).C1PM
                Dim mc2 = FoundDRS.Item(0).C2
                Dim mc2pm = FoundDRS.Item(0).C2PM
                Dim mc3 = FoundDRS.Item(0).C3
                Dim mc3pm = FoundDRS.Item(0).C3PM
                Dim mc4 = FoundDRS.Item(0).C4
                Dim mc4pm = FoundDRS.Item(0).C4PM
                Dim mc5 = FoundDRS.Item(0).C5
                Dim mc5pm = FoundDRS.Item(0).C5PM

                Dim FoundHPL_MC1 = (From HCUSP_PROMISE_LINK In HCUSP_PROMISE_LINKList
                                    Where HCUSP_PROMISE_LINK.UID = UID And HCUSP_PROMISE_LINK.HID = HID And HCUSP_PROMISE_LINK.CUSPKEY = mc1
                                    Select HCUSP_PROMISE_LINK).ToList()
                If FoundHPL_MC1.Count > 0 Then
                    Dim mc = FoundHPL_MC1.Item(0).TCOUNT
                    If mc1pm = "+" Then
                        pos = pos + mc
                    Else
                        neg = neg + mc
                    End If
                End If

                Dim FoundHPL_MC2 = (From HCUSP_PROMISE_LINK In HCUSP_PROMISE_LINKList
                                    Where HCUSP_PROMISE_LINK.UID = UID And HCUSP_PROMISE_LINK.HID = HID And HCUSP_PROMISE_LINK.CUSPKEY = mc2
                                    Select HCUSP_PROMISE_LINK).ToList()
                If FoundHPL_MC2.Count > 0 Then
                    Dim mc = FoundHPL_MC2.Item(0).TCOUNT
                    If mc2pm = "+" Then
                        pos = pos + mc
                    Else
                        neg = neg + mc
                    End If
                End If

                Dim FoundHPL_MC3 = (From HCUSP_PROMISE_LINK In HCUSP_PROMISE_LINKList
                                    Where HCUSP_PROMISE_LINK.UID = UID And HCUSP_PROMISE_LINK.HID = HID And HCUSP_PROMISE_LINK.CUSPKEY = mc3
                                    Select HCUSP_PROMISE_LINK).ToList()
                If FoundHPL_MC3.Count > 0 Then
                    Dim mc = FoundHPL_MC3.Item(0).TCOUNT
                    If mc3pm = "+" Then
                        pos = pos + mc
                    Else
                        neg = neg + mc
                    End If
                End If

                Dim FoundHPL_MC4 = (From HCUSP_PROMISE_LINK In HCUSP_PROMISE_LINKList
                                    Where HCUSP_PROMISE_LINK.UID = UID And HCUSP_PROMISE_LINK.HID = HID And HCUSP_PROMISE_LINK.CUSPKEY = mc4
                                    Select HCUSP_PROMISE_LINK).ToList()
                If FoundHPL_MC4.Count > 0 Then
                    Dim mc = FoundHPL_MC4.Item(0).TCOUNT
                    If mc4pm = "+" Then
                        pos = pos + mc
                    Else
                        neg = neg + mc
                    End If
                End If

                Dim FoundHPL_MC5 = (From HCUSP_PROMISE_LINK In HCUSP_PROMISE_LINKList
                                    Where HCUSP_PROMISE_LINK.UID = UID And HCUSP_PROMISE_LINK.HID = HID And HCUSP_PROMISE_LINK.CUSPKEY = mc5
                                    Select HCUSP_PROMISE_LINK).ToList()
                If FoundHPL_MC5.Count > 0 Then
                    Dim mc = FoundHPL_MC5.Item(0).TCOUNT
                    If mc5pm = "+" Then
                        pos = pos + mc
                    Else
                        neg = neg + mc
                    End If
                End If
                DBController.UPDATE_DAILY_RULES_MAIN(UID, HID, (pos - neg), mr)
            End If
        Next
        For i As Integer = 0 To DAILY_RULES_MAINList.Count - 1
            Dim Diff = DAILY_RULES_MAINList.Item(i).CCOUNT - DAILY_RULES_MAINList.Item(i).RTOTAL
            If Diff > 2 Then
                DBController.UPDATE_DAILY_RULES_MAIN(UID, HID, "low/medium", DAILY_RULES_MAINList.Item(i).RULESID)
            Else
                DBController.UPDATE_DAILY_RULES_MAIN(UID, HID, "high", DAILY_RULES_MAINList.Item(i).RULESID)
            End If
        Next
    End Sub
End Class