Imports System.Data.SqlClient

Public Class Promise
    Dim HID = ""
    Dim UID = ""
    Dim RQID = ""
    'Public constr = "data source=DESKTOP-JBRFH9E;initial catalog=HEADLETTERS_ENGINE;integrated security=True;"
    'Public constr = "data source=WIN-KSTUPT6CJRC;initial catalog=HEADLETTERS_ENGINE;integrated security=True;multipleactiveresultsets=True;"
    Public constr = "data source=49.50.103.132;initial catalog=HEADLETTERS_ENGINE;integrated security=False;User Id=sa;password=pSI)TA1t0K[)"
    'Public constr = "data source=WIN-KSTUPT6CJRC;initial catalog=HEADLETTERS_ENGINE;integrated security=False;multipleactiveresultsets=True;User Id=sa;password=pSI)TA1t0K[);"
    Function SplitInTwoChar(ByRef S1 As String) As String()
        Dim S1Split = New String(S1.Length / 2 + (If(S1.Length Mod 2 = 0, 0, 1)) - 1) {}
        For i As Integer = 0 To S1Split.Length - 1
            S1Split(i) = S1.Substring(i * 2, If(i * 2 + 2 > S1.Length, 1, 2))
        Next
        Return S1Split
    End Function
    Sub MainHIDUID(ByVal UID As String, ByVal HID As String)
        Dim HCUSPList As New List(Of HCUSP)
        Dim HRAKEList As New List(Of HRAKE)
        Dim HPLANETList As New List(Of HPLANET)
        Dim HCUSPCALCList As New List(Of HCUSP_CALC)
        DELETE_RECORDS(UID, HID)
        Select_From_HRAKE(UID, HID, HRAKEList)
        Select_From_HCUSP(UID, HID, HCUSPList)
        Select_From_HPLANET(UID, HID, HPLANETList)
        Conversion_of_HCUSP_RAKE(UID, HID, HCUSPList, HRAKEList)
        Conversion_of_HPLANET_RAKE(UID, HID, HPLANETList, HRAKEList)
        Insert_Into_HCUSP_CALC(UID, HID, HCUSPList, HPLANETList)

        Dim HCUSP_CALCList As New List(Of HCUSP_CALC)
        Dim HCUSP_SIGN_SUBList As New List(Of HCUSP_SIGN_SUB)
        Dim Y1List As New List(Of Y1)
        Select_From_HCUSP_CALC(UID, HID, HCUSP_CALCList)
        DoSomethingNew(UID, HID, HCUSP_CALCList)
        Select_From_Y1(UID, HID, Y1List)
        DoSomethingNewGood(UID, HID, Y1List)

        Dim DAILY_RULES_SUBList As New List(Of DAILY_RULES_SUB)
        Dim DAILY_RULES_TEMPLATEList As New List(Of DAILY_RULES_TEMPLATE)
        Dim HCUSP_PROMISE_LINKList As New List(Of HCUSP_PROMISE_LINK)
        Dim DAILY_RULES_MAINList As New List(Of DAILY_RULES_MAIN)
        Select_From_DAILY_RULES_TEMPLATE(UID, HID, DAILY_RULES_TEMPLATEList)
        Select_From_DAILY_RULES_SUB(UID, HID, DAILY_RULES_SUBList)
        Select_From_HCUSP_PROMISE_LINK(UID, HID, HCUSP_PROMISE_LINKList)
        Update_DAILY_RULES_MAIN(UID, HID, DAILY_RULES_TEMPLATEList)
        Select_From_DAILY_RULES_MAIN(UID, HID, DAILY_RULES_MAINList)
        Process_Promise1(UID, HID, DAILY_RULES_MAINList, DAILY_RULES_SUBList, HCUSP_PROMISE_LINKList)
        INSERT_INTO_HPROMISE(UID, HID)
    End Sub
    Sub DELETE_RECORDS(ByVal UID As String, ByVal HID As String)
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Try
            con.ConnectionString = constr
            con.Open()
            cmd.CommandTimeout = 1800
            cmd.Connection = con
            cmd.CommandText = $"DELETE FROM HEADLETTERS_ENGINE.DBO.HCUSP_CALC WHERE CUSPUSERID = '" + UID + "' AND CUSPHID = '" + HID + "';
                                DELETE FROM HEADLETTERS_ENGINE.DBO.HCUSP_SIGN_SUB WHERE UID = '" + UID + "' AND HID = '" + HID + "';
                                DELETE FROM HEADLETTERS_ENGINE.DBO.Y1 WHERE UID = '" + UID + "' AND HID = '" + HID + "';
                                DELETE FROM HEADLETTERS_ENGINE.DBO.HCUSP_PROMISE_LINK WHERE UID = '" + UID + "' AND HID = '" + HID + "';
                                DELETE FROM HEADLETTERS_ENGINE.DBO.DAILY_RULES_MAIN WHERE UID = '" + UID + "' AND HID ='" + HID + "';
                                DELETE FROM ASTROLOGYSOFTWARE_DB.DBO.HPROMISE WHERE PMUSERID = '" + UID + "' AND PMHID = '" + HID + "';"
            cmd.ExecuteNonQuery()
        Catch EX As Exception
            Dim strFile As String = String.Format("C:\Astro\ServiceLogs\Errors\Promise_Error.txt")
            IO.File.AppendAllText(strFile, String.Format(vbCrLf + "UID=> " + UID + "  ::  HID=> " + HID + vbCrLf + "Error Occured at-- {0}{1}{2}", Environment.NewLine + DateTime.Now, Environment.NewLine, EX.Message + vbCrLf + EX.StackTrace))
            con.Close()
        End Try
    End Sub
    Sub Select_From_HRAKE(ByVal UID As String, ByVal HID As String, ByRef HRAKEList As List(Of HRAKE))
        Dim connection As SqlConnection = New SqlConnection(constr)
        Dim query = $"SELECT * FROM HEADLETTERS_ENGINE.DBO.HRAKE WHERE UID = '" + UID + "' AND HID = '" + HID + "' AND HKEY = 'RA';
                                SELECT * FROM HEADLETTERS_ENGINE.DBO.HRAKE WHERE UID = '" + UID + "' AND HID = '" + HID + "' AND HKEY = 'KE';"
        Dim cmd As New SqlCommand(query, connection)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet()
        Try
            connection.Open()
            da.Fill(ds)
            If ds.Tables(0).Rows.Count <> 0 Then
                Dim hRA = New HRAKE With {
                    .UID = ds.Tables(0).Rows(0).Item(0).ToString().Trim,
                    .HID = ds.Tables(0).Rows(0).Item(1).ToString().Trim,
                    .HKEY = ds.Tables(0).Rows(0).Item(2).ToString().Trim,
                    .S1 = ds.Tables(0).Rows(0).Item(3).ToString().Trim
                }
                HRAKEList.Add(hRA)
            End If
            If ds.Tables(1).Rows.Count <> 0 Then
                Dim hKE = New HRAKE With {
                    .UID = ds.Tables(1).Rows(0).Item(0).ToString().Trim,
                    .HID = ds.Tables(1).Rows(0).Item(1).ToString().Trim,
                    .HKEY = ds.Tables(1).Rows(0).Item(2).ToString().Trim,
                    .S1 = ds.Tables(1).Rows(0).Item(3).ToString().Trim
                }
                HRAKEList.Add(hKE)
            End If
        Catch ex As Exception
            Dim strFile As String = String.Format("C:\Astro\ServiceLogs\Errors\Promise_Error.txt")
            IO.File.AppendAllText(strFile, String.Format(vbCrLf + "UID=> " + UID + "  ::  HID=> " + HID + vbCrLf + "Error Occured at-- {0}{1}{2}", Environment.NewLine + DateTime.Now, Environment.NewLine, ex.Message + vbCrLf + ex.StackTrace))
        Finally
            connection.Close()
        End Try
    End Sub
    Sub Select_From_HCUSP(ByVal UID As String, ByVal HID As String, ByRef HCUSPList As List(Of HCUSP))
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim reader As SqlDataReader
        Try
            con.ConnectionString = constr
            con.Open()
            cmd.Connection = con
            cmd.CommandText = "SELECT * FROM HEADLETTERS_ENGINE.DBO.HCUSP WHERE CUSPUSERID = '" + UID + "' AND CUSPHID = '" + HID + "';"
            reader = cmd.ExecuteReader()
            While reader.Read()
                Dim hCusp = New HCUSP With {
                    .CUSPUSERID = reader("CUSPUSERID").ToString().Trim,
                    .CUSPHID = reader("CUSPHID").ToString().Trim,
                    .CUSP = reader("CUSP").ToString().Trim,
                    .SIGN = reader("SIGN").ToString().Trim,
                    .DMS = reader("DMS").ToString().Trim,
                    .CP1 = reader("CP1").ToString().ToUpper().Trim,
                    .CP2 = reader("CP2").ToString().ToUpper().Trim,
                    .CP3 = reader("CP3").ToString().ToUpper().Trim
                }
                HCUSPList.Add(hCusp)
            End While
        Catch ex As Exception
            Dim strFile As String = String.Format("C:\Astro\ServiceLogs\Errors\Promise_Error.txt)")
            IO.File.AppendAllText(strFile, String.Format(vbCrLf + "UID=> " + UID + "  :: HID => " + HID + vbCrLf + "Error Occured at-- {0}{1}{2}", Environment.NewLine + DateTime.Now, Environment.NewLine, ex.Message + vbCrLf + ex.StackTrace))
        Finally
            con.Close()
        End Try
    End Sub
    Sub Select_From_HPLANET(ByVal UID As String, ByVal HID As String, ByRef HPLANETList As List(Of HPLANET))
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim reader As SqlDataReader
        Try
            con.ConnectionString = constr
            con.Open()
            cmd.Connection = con
            cmd.CommandText = "SELECT * FROM HEADLETTERS_ENGINE.DBO.HPLANET WHERE PLHUSERID = '" + UID + "' AND PLHID = '" + HID + "';"
            reader = cmd.ExecuteReader()
            While reader.Read()
                If reader("PLANET").ToString().Trim <> "NE" And reader("PLANET").ToString().Trim <> "UR" And reader("PLANET").ToString().Trim <> "PL" Then
                    Dim hPlanet = New HPLANET With {
                    .PLHUSERID = reader("PLHUSERID").ToString().Trim,
                    .PLHID = reader("PLHID").ToString().Trim,
                    .PLANET = reader("PLANET").ToString().Trim,
                    .SIGN = reader("SIGN").ToString().Trim,
                    .DMS = reader("DMS").ToString().Trim,
                    .HP1 = reader("HP1").ToString().Trim,
                    .HP2 = reader("HP2").ToString().Trim,
                    .HP3 = reader("HP3").ToString().Trim,
                    .HP4 = reader("HP4").ToString().Trim,
                    .HP5 = reader("HP5").ToString().Trim,
                    .HP6 = reader("HP6").ToString().Trim,
                    .HPHOUSE = reader("HPHOUSE").ToString().Trim
                }
                    HPLANETList.Add(hPlanet)
                End If
            End While
        Catch ex As Exception
            Dim strFile As String = String.Format("C:\Astro\ServiceLogs\Errors\Promise_Error.txt")
            IO.File.AppendAllText(strFile, String.Format(vbCrLf + "UID=> " + UID + "  ::  HID=> " + HID + vbCrLf + "Error Occured at-- {0}{1}{2}", Environment.NewLine + DateTime.Now, Environment.NewLine, ex.Message + vbCrLf + ex.StackTrace))
        Finally
            con.Close()
        End Try
    End Sub
    Sub Conversion_of_HCUSP_RAKE(ByVal UID As String, ByVal HID As String, ByVal HCUSPList As List(Of HCUSP), ByVal HRAKEList As List(Of HRAKE))
        Dim HcuspListCount = HCUSPList.Count - 1
        For i As Integer = 0 To HcuspListCount
            If HCUSPList.Item(i).CP1 = "RA" Then
                Dim CP1Expand = "RA"
                Dim S1SplitRA = SplitInTwoChar(HRAKEList.Item(0).S1.ToString().Trim)
                For j As Integer = 0 To S1SplitRA.Length - 1
                    If S1SplitRA(j) = "KE" Then
                        CP1Expand = CP1Expand + "KE"
                        Dim S1SplitKE = SplitInTwoChar(HRAKEList.Item(1).S1.ToString().Trim)
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
                Dim S1SplitKE = SplitInTwoChar(HRAKEList.Item(1).S1.ToString().Trim)
                For j As Integer = 0 To S1SplitKE.Length - 1
                    If S1SplitKE(j) = "RA" Then
                        CP1Expand = CP1Expand + "RA"
                        Dim S1SplitRA = SplitInTwoChar(HRAKEList.Item(0).S1.ToString().Trim)
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
                Dim S1SplitRA = SplitInTwoChar(HRAKEList.Item(0).S1.ToString().Trim)
                For j As Integer = 0 To S1SplitRA.Length - 1
                    If S1SplitRA(j) = "KE" Then
                        CP2Expand = CP2Expand + "KE"
                        Dim S1SplitKE = SplitInTwoChar(HRAKEList.Item(1).S1.ToString().Trim)
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
                Dim S1SplitKE = SplitInTwoChar(HRAKEList.Item(1).S1.ToString().Trim)
                For j As Integer = 0 To S1SplitKE.Length - 1
                    If S1SplitKE(j) = "RA" Then
                        CP2Expand = CP2Expand + "RA"
                        Dim S1SplitRA = SplitInTwoChar(HRAKEList.Item(0).S1.ToString().Trim)
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
                Dim S1SplitRA = SplitInTwoChar(HRAKEList.Item(0).S1.ToString().Trim)
                For j As Integer = 0 To S1SplitRA.Length - 1
                    If S1SplitRA(j) = "KE" Then
                        CP3Expand = CP3Expand + "KE"
                        Dim S1SplitKE = SplitInTwoChar(HRAKEList.Item(1).S1.ToString().Trim)
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
                Dim S1SplitKE = SplitInTwoChar(HRAKEList.Item(1).S1.ToString().Trim)
                For j As Integer = 0 To S1SplitKE.Length - 1
                    If S1SplitKE(j) = "RA" Then
                        CP3Expand = CP3Expand + "RA"
                        Dim S1SplitRA = SplitInTwoChar(HRAKEList.Item(0).S1.ToString().Trim)
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
    Sub Conversion_of_HPLANET_RAKE(ByVal UID As String, ByVal HID As String, ByVal HPLANETList As List(Of HPLANET), ByVal HRAKEList As List(Of HRAKE))
        Dim HplanetListCount = HPLANETList.Count - 1
        For i As Integer = 0 To HplanetListCount
            If HPLANETList.Item(i).PLANET = "RA" Then
                Dim PlanetExpand = "RA"
                Dim S1SplitRA = SplitInTwoChar(HRAKEList.Item(0).S1.ToString().Trim)
                For j As Integer = 0 To S1SplitRA.Length - 1
                    If S1SplitRA(j) = "KE" Then
                        PlanetExpand = PlanetExpand + "KE"
                        Dim S1SplitKE = SplitInTwoChar(HRAKEList.Item(1).S1.ToString().Trim)
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
                Dim S1SplitKE = SplitInTwoChar(HRAKEList.Item(1).S1.ToString().Trim)
                For j As Integer = 0 To S1SplitKE.Length - 1
                    If S1SplitKE(j) = "RA" Then
                        PlanetExpand = PlanetExpand + "RA"
                        Dim S1SplitRA = SplitInTwoChar(HRAKEList.Item(0).S1.ToString().Trim)
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
    Sub Insert_Into_HCUSP_CALC(ByVal UID As String, ByVal HID As String, ByVal HCUSPList As List(Of HCUSP), ByVal HPLANETList As List(Of HPLANET))
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim HCUSPQuery = ""
        Dim HPLANETQuery = ""
        con.ConnectionString = constr
        Try
            con.Open()
            cmd.Connection = con
            cmd.CommandText = "DELETE FROM HEADLETTERS_ENGINE.DBO.HCUSP_CALC WHERE CUSPUSERID = '" + UID + "' AND CUSPHID = '" + HID + "';"
            cmd.ExecuteNonQuery()
        Catch ex As Exception
            Dim strFile As String = String.Format("C:\Astro\ServiceLogs\Errors\Promise_Error.txt")
            IO.File.AppendAllText(strFile, String.Format(vbCrLf + "UID=> " + UID + "  ::  HID=> " + HID + vbCrLf + "Error Occured at-- {0}{1}{2}", Environment.NewLine + DateTime.Now, Environment.NewLine, ex.Message + vbCrLf + ex.StackTrace))
        Finally
            con.Close()
        End Try
        If HCUSPList.Count <> 0 Then
            For i As Integer = 0 To HCUSPList.Count - 1
                Dim HCUSPQueryCP1 = ""
                Dim HCUSPQueryCP2 = ""
                Dim HCUSPQueryCP3 = ""
                If HCUSPList.Item(i).CP1.Length > 2 Then
                    Dim HCUSPCP1 = SplitInTwoChar(HCUSPList.Item(i).CP1)
                    For j As Integer = 0 To HCUSPCP1.Count - 1
                        HCUSPQueryCP1 = HCUSPQueryCP1 + "INSERT INTO HEADLETTERS_ENGINE.DBO.HCUSP_CALC VALUES ('" + HCUSPList.Item(i).CUSPUSERID + "','" + HCUSPList.Item(i).CUSPHID + "','" + HCUSPList.Item(i).CUSP + "','" + HCUSPCP1(j) + "','1','" + If(j = 0, "1", "3") + "');" + vbCrLf
                    Next
                Else
                    HCUSPQueryCP1 = "INSERT INTO HEADLETTERS_ENGINE.DBO.HCUSP_CALC VALUES ('" + HCUSPList.Item(i).CUSPUSERID + "','" + HCUSPList.Item(i).CUSPHID + "','" + HCUSPList.Item(i).CUSP + "','" + HCUSPList.Item(i).CP1 + "','1','1');" + vbCrLf
                End If
                If HCUSPList.Item(i).CP2.Length > 2 Then
                    Dim HCUSPCP2 = SplitInTwoChar(HCUSPList.Item(i).CP2)
                    For j As Integer = 0 To HCUSPCP2.Count - 1
                        HCUSPQueryCP2 = HCUSPQueryCP2 + "INSERT INTO HEADLETTERS_ENGINE.DBO.HCUSP_CALC VALUES ('" + HCUSPList.Item(i).CUSPUSERID + "','" + HCUSPList.Item(i).CUSPHID + "','" + HCUSPList.Item(i).CUSP + "','" + HCUSPCP2(j) + "','2','" + If(j = 0, "1", "3") + "');" + vbCrLf
                    Next
                Else
                    HCUSPQueryCP2 = "INSERT INTO HEADLETTERS_ENGINE.DBO.HCUSP_CALC VALUES ('" + HCUSPList.Item(i).CUSPUSERID + "','" + HCUSPList.Item(i).CUSPHID + "','" + HCUSPList.Item(i).CUSP + "','" + HCUSPList.Item(i).CP2 + "','2','1');" + vbCrLf
                End If
                If HCUSPList.Item(i).CP3.Length > 2 Then
                    Dim HCUSPCP3 = SplitInTwoChar(HCUSPList.Item(i).CP3)
                    For j As Integer = 0 To HCUSPCP3.Count - 1
                        HCUSPQueryCP3 = HCUSPQueryCP3 + "INSERT INTO HEADLETTERS_ENGINE.DBO.HCUSP_CALC VALUES ('" + HCUSPList.Item(i).CUSPUSERID + "','" + HCUSPList.Item(i).CUSPHID + "','" + HCUSPList.Item(i).CUSP + "','" + HCUSPCP3(j) + "','3','" + If(j = 0, "1", "3") + "');" + vbCrLf
                    Next
                Else
                    HCUSPQueryCP3 = "INSERT INTO HEADLETTERS_ENGINE.DBO.HCUSP_CALC VALUES ('" + HCUSPList.Item(i).CUSPUSERID + "','" + HCUSPList.Item(i).CUSPHID + "','" + HCUSPList.Item(i).CUSP + "','" + HCUSPList.Item(i).CP3 + "','3','1');" + vbCrLf
                End If
                HCUSPQuery = HCUSPQuery + HCUSPQueryCP1 + HCUSPQueryCP2 + HCUSPQueryCP3
            Next
            Try
                con.Open()
                cmd.Connection = con
                cmd.CommandText = HCUSPQuery
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                Dim strFile As String = String.Format("C:\Astro\ServiceLogs\Errors\Promise_Error.txt")
                IO.File.AppendAllText(strFile, String.Format(vbCrLf + "UID=> " + UID + "  ::  HID=> " + HID + vbCrLf + "Error Occured at-- {0}{1}{2}", Environment.NewLine + DateTime.Now, Environment.NewLine, ex.Message + vbCrLf + ex.StackTrace))
            Finally
                con.Close()
            End Try
        End If
        If HPLANETList.Count <> 0 Then
            For i As Integer = 0 To HPLANETList.Count - 1
                Dim MultiPlanetQuery = ""
                If HPLANETList.Item(i).PLANET.Length > 2 Then
                    Dim HPlanetArray = SplitInTwoChar(HPLANETList.Item(i).PLANET)
                    For j As Integer = 0 To HPlanetArray.Count - 1
                        MultiPlanetQuery = MultiPlanetQuery + "INSERT INTO HEADLETTERS_ENGINE.DBO.HCUSP_CALC VALUES ('" + HPLANETList.Item(i).PLHUSERID + "','" + HPLANETList.Item(i).PLHID + "','" + HPLANETList.Item(i).HPHOUSE + "','" + HPlanetArray(j) + "','7','" + If(j = 0, "2", "3") + "');" + vbCrLf
                    Next
                Else
                    MultiPlanetQuery = "INSERT INTO HEADLETTERS_ENGINE.DBO.HCUSP_CALC VALUES ('" + HPLANETList.Item(i).PLHUSERID + "','" + HPLANETList.Item(i).PLHID + "','" + HPLANETList.Item(i).HPHOUSE + "','" + HPLANETList.Item(i).PLANET + "','7','2');" + vbCrLf
                End If
                HPLANETQuery = HPLANETQuery + MultiPlanetQuery
            Next
            Try
                con.Open()
                cmd.Connection = con
                cmd.CommandText = HPLANETQuery
                cmd.ExecuteNonQuery()
            Catch ex As Exception
                Dim strFile As String = String.Format("C:\Astro\ServiceLogs\Errors\Promise_Error.txt")
                IO.File.AppendAllText(strFile, String.Format(vbCrLf + "UID=> " + UID + "  ::  HID=> " + HID + vbCrLf + "Error Occured at-- {0}{1}{2}", Environment.NewLine + DateTime.Now, Environment.NewLine, ex.Message + vbCrLf + ex.StackTrace))
            Finally
                con.Close()
            End Try
        End If
    End Sub
    Sub Select_From_HCUSP_CALC(ByVal UID As String, ByVal HID As String, ByRef HCUSP_CALCList As List(Of HCUSP_CALC))
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim reader As SqlDataReader
        Try
            con.ConnectionString = constr
            con.Open()
            cmd.Connection = con
            cmd.CommandText = "SELECT * FROM HEADLETTERS_ENGINE.DBO.HCUSP_CALC WHERE CUSPUSERID = '" + UID + "' AND CUSPHID = '" + HID + "';"
            reader = cmd.ExecuteReader()
            While reader.Read()
                Dim hCusp_Calc = New HCUSP_CALC With {
                    .CUSPUSERID = reader("CUSPUSERID").ToString().Trim,
                    .CUSPHID = reader("CUSPHID").ToString().Trim,
                    .CUSPID = reader("CUSPID").ToString().Trim,
                    .CUSPPLANET = reader("CUSPPLANET").ToString().Trim,
                    .CUSPTYPE = reader("CUSPTYPE"),
                    .CUSPCAT = reader("CUSPCAT").ToString().ToUpper().Trim
                }
                HCUSP_CALCList.Add(hCusp_Calc)
            End While
        Catch ex As Exception
            Dim strFile As String = String.Format("C:\Astro\ServiceLogs\Errors\Promise_Error.txt")
            IO.File.AppendAllText(strFile, String.Format(vbCrLf + "UID=> " + UID + "  ::  HID=> " + HID + vbCrLf + "Error Occured at-- {0}{1}{2}", Environment.NewLine + DateTime.Now, Environment.NewLine, ex.Message + vbCrLf + ex.StackTrace))
        Finally
            con.Close()
        End Try
    End Sub
    Sub DoSomethingNew(ByVal UID As String, ByVal HID As String, ByVal HCUSP_CALCList As List(Of HCUSP_CALC))
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
                If s_key <> s_key1 Then
                    Dim q1 = $"SELECT COUNT(*) FROM HCUSP_CALC WHERE CUSPUSERID = '" + UID + "' AND CUSPHID = '" + HID + "' AND CUSPID = '" + i.ToString("D2") + "' AND CUSPPLANET = '" + HcusPCalc.CUSPPLANET + "' AND CUSPTYPE = '1' AND CUSPCAT = '1';" + vbCrLf
                    Dim q2 = $"SELECT COUNT(*) FROM HCUSP_CALC WHERE CUSPUSERID = '" + UID + "' AND CUSPHID = '" + HID + "' AND CUSPID = '" + i.ToString("D2") + "' AND CUSPPLANET = '" + HcusPCalc.CUSPPLANET + "' AND CUSPTYPE = '2' AND CUSPCAT = '1';" + vbCrLf
                    Dim q3 = $"SELECT COUNT(*) FROM HCUSP_CALC WHERE CUSPUSERID = '" + UID + "' AND CUSPHID = '" + HID + "' AND CUSPID = '" + i.ToString("D2") + "' AND CUSPPLANET = '" + HcusPCalc.CUSPPLANET + "' AND CUSPTYPE = '3' AND CUSPCAT = '1';" + vbCrLf
                    Dim q4 = $"SELECT COUNT(*) FROM HCUSP_CALC WHERE CUSPUSERID = '" + UID + "' AND CUSPHID = '" + HID + "' AND CUSPID = '" + i.ToString("D2") + "' AND CUSPPLANET = '" + HcusPCalc.CUSPPLANET + "' AND CUSPTYPE = '7' AND CUSPCAT = '2';" + vbCrLf
                    Dim cmd As New SqlCommand(q1 + q2 + q3 + q4, con)
                    Dim da As New SqlDataAdapter(cmd)
                    Dim ds As New DataSet()
                    da.Fill(ds)
                    Dim C1 = ds.Tables(0).Rows(0)(0).ToString().Trim()
                    Dim c2 = ds.Tables(1).Rows(0)(0).ToString().Trim()
                    Dim c3 = ds.Tables(2).Rows(0)(0).ToString().Trim()
                    Dim c4 = ds.Tables(3).Rows(0)(0).ToString().Trim()
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
                End If
                InsertIntoY1 = InsertIntoY1 + qr1 + qr2 + qr3 + qr4
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
    Sub Select_From_Y1(ByVal UID As String, ByVal HID As String, ByRef Y1List As List(Of Y1))
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim reader As SqlDataReader
        Try
            con.ConnectionString = constr
            con.Open()
            cmd.Connection = con
            cmd.CommandText = "SELECT DISTINCT * FROM HEADLETTERS_ENGINE.DBO.Y1 WHERE UID = '" + UID + "' AND HID = '" + HID + "';"
            reader = cmd.ExecuteReader()
            While reader.Read()
                Dim y1 = New Y1 With {
                    .UID = reader("UID").ToString().Trim,
                    .HID = reader("HID").ToString().Trim,
                    .FKEY = reader("FKEY").ToString().Trim,
                    .TKEY = reader("TKEY").ToString().Trim,
                    .PLANET = reader("PLANET").ToString().Trim
                }
                Y1List.Add(y1)
            End While
        Catch ex As Exception
            Dim strFile As String = String.Format("C:\Astro\ServiceLogs\Errors\Promise_Error.txt")
            IO.File.AppendAllText(strFile, String.Format(vbCrLf + "UID=> " + UID + "  ::  HID=> " + HID + vbCrLf + "Error Occured at-- {0}{1}{2}", Environment.NewLine + DateTime.Now, Environment.NewLine, ex.Message + vbCrLf + ex.StackTrace))
        Finally
            con.Close()
        End Try
    End Sub
    Sub DoSomethingNewGood(ByVal UID As String, ByVal HID As String, ByRef Y1List As List(Of Y1))
        Dim tEMPtABLE = "CREATE TABLE #_HCUSP_PROMISE_LINK_ (UID varchar(254), HID varchar(30), CUSPKEY varchar(4), TCOUNT INT, SKEY VARCHAR(254));" + vbCrLf
        Dim dROPtABLE = "If(OBJECT_ID('tempdb..#_HCUSP_PROMISE_LINK_') Is Not Null) Begin Drop Table #_HCUSP_PROMISE_LINK_ End;"
        Dim iNSRtABLE = ""
        For i = 0 To Y1List.Count - 1
            Dim k1 = Y1List.Item(i).UID + Y1List.Item(i).HID + Y1List.Item(i).FKEY + Y1List.Item(i).TKEY
            iNSRtABLE = iNSRtABLE + "INSERT INTO #_HCUSP_PROMISE_LINK_ VALUES ('" + Y1List.Item(i).UID + "','" + Y1List.Item(i).HID + "','" + Y1List.Item(i).FKEY + "" + Y1List.Item(i).TKEY + "',1,'" + k1 + "');" + vbCrLf
        Next
        Dim iNSRtHPrL = "INSERT INTO HEADLETTERS_ENGINE.DBO.HCUSP_PROMISE_LINK SELECT UID,HID,CUSPKEY,COUNT(*) AS TCOUNT,SKEY FROM #_HCUSP_PROMISE_LINK_  where uid = '" + UID + "' and hid = '" + HID + "' GROUP BY UID,HID,CUSPKEY,SKEY HAVING COUNT(*) <> 0" + vbCrLf
        Dim c0n As New SqlConnection
        Dim c0d As New SqlCommand
        Try
            c0n.ConnectionString = constr
            c0n.Open()
            c0d.Connection = c0n
            c0d.CommandText = tEMPtABLE + iNSRtABLE + iNSRtHPrL + dROPtABLE
            c0d.ExecuteNonQuery()
        Catch ex As Exception
            Dim strFile As String = String.Format("C:\Astro\ServiceLogs\Errors\Promise_Error.txt")
            IO.File.AppendAllText(strFile, String.Format(vbCrLf + "UID=> " + UID + "  ::  HID=> " + HID + vbCrLf + "Error Occured at-- {0}{1}{2}", Environment.NewLine + DateTime.Now, Environment.NewLine, ex.Message + vbCrLf + ex.StackTrace))
        Finally
            c0n.Close()
        End Try
    End Sub
    Sub Select_From_DAILY_RULES_TEMPLATE(ByVal UID As String, ByVal HID As String, ByRef DAILY_RULES_TEMPLATEList As List(Of DAILY_RULES_TEMPLATE))
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim reader As SqlDataReader
        Try
            con.ConnectionString = constr
            con.Open()
            cmd.Connection = con
            cmd.CommandText = "SELECT * FROM HEADLETTERS_ENGINE.DBO.DAILY_RULES_TEMPLATE;"
            reader = cmd.ExecuteReader()
            While reader.Read()
                Dim Daily_Rules_Template = New DAILY_RULES_TEMPLATE With {
                    .MAIN = reader("MAIN").ToString().Trim,
                    .S1 = reader("S1").ToString().Trim,
                    .S2 = reader("S2").ToString().Trim,
                    .S3 = reader("S3").ToString().Trim,
                    .S4 = reader("S4").ToString().Trim,
                    .S5 = reader("S5").ToString().Trim,
                    .S6 = reader("S6").ToString().Trim,
                    .RULESID = reader("RULESID").ToString().Trim,
                    .CCOUNT = If(IsDBNull(reader("CCOUNT")), 0, reader("CCOUNT")),
                    .DESCRIPTION = reader("DESCRIPTION").ToString().Trim,
                    .CATEGORY = reader("CATEGORY").ToString().Trim,
                    .RTOTAL = If(IsDBNull(reader("RTOTAL")), 0, reader("RTOTAL")),
                    .CUSPINDEX = reader("CUSPINDEX").ToString().Trim,
                    .DUP = reader("DUP").ToString().Trim
                }
                DAILY_RULES_TEMPLATEList.Add(Daily_Rules_Template)
            End While
        Catch ex As Exception
            Dim strFile As String = String.Format("C:\Astro\ServiceLogs\PromiseWork\Promise_Error.txt")
            IO.File.AppendAllText(strFile, String.Format(vbCrLf + "UID=> " + UID + "  ::  HID=> " + HID + vbCrLf + "Error Occured at-- {0}{1}{2}", Environment.NewLine + DateTime.Now, Environment.NewLine, ex.Message + vbCrLf + ex.StackTrace))
        Finally
            con.Close()
        End Try
    End Sub
    Sub Update_DAILY_RULES_MAIN(ByVal UID As String, ByVal HID As String, ByRef DAILY_RULE_TEMPLATEList As List(Of DAILY_RULES_TEMPLATE))
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Try
            con.ConnectionString = constr
            con.Open()
            cmd.Connection = con
            cmd.CommandText = $";"
            cmd.ExecuteNonQuery()
            cmd.CommandText = $"DELETE FROM HEADLETTERS_ENGINE.DBO.DAILY_RULES_MAIN WHERE UID = '" + UID + "' AND HID = '" + HID + "';"
            cmd.ExecuteNonQuery()
            For i As Integer = 0 To DAILY_RULE_TEMPLATEList.Count - 1
                cmd.CommandText = $"INSERT INTO HEADLETTERS_ENGINE.DBO.DAILY_RULES_MAIN VALUES('" + UID + "', '" + HID + "','" + DAILY_RULE_TEMPLATEList(i).MAIN + "',
                                    '" + DAILY_RULE_TEMPLATEList(i).S1 + "', '" + DAILY_RULE_TEMPLATEList(i).S2 + "', '" + DAILY_RULE_TEMPLATEList(i).S3 + "',
                                    '" + DAILY_RULE_TEMPLATEList(i).S4 + "', '" + DAILY_RULE_TEMPLATEList(i).S5 + "', '" + DAILY_RULE_TEMPLATEList(i).S6 + "',
                                    '" + DAILY_RULE_TEMPLATEList(i).RULESID + "'," + DAILY_RULE_TEMPLATEList(i).CCOUNT.ToString() + ",'" + DAILY_RULE_TEMPLATEList(i).DESCRIPTION + "',
                                    NULL, NULL, '" + DAILY_RULE_TEMPLATEList(i).CATEGORY + "');"
                cmd.ExecuteNonQuery()
            Next
        Catch ex As Exception
            Dim strFile As String = String.Format("C:\Astro\ServiceLogs\PromiseWork\Promise_Error.txt")
            IO.File.AppendAllText(strFile, String.Format(vbCrLf + "UID=> " + UID + "  ::  HID=> " + HID + vbCrLf + "Error Occured at-- {0}{1}{2}", Environment.NewLine + DateTime.Now, Environment.NewLine, ex.Message + vbCrLf + ex.StackTrace))
        Finally
            con.Close()
        End Try
    End Sub
    Sub Select_From_DAILY_RULES_MAIN(ByVal UID As String, ByVal HID As String, ByRef DAILY_RULES_MAINList As List(Of DAILY_RULES_MAIN))
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim reader As SqlDataReader
        Try
            con.ConnectionString = constr
            con.Open()
            cmd.Connection = con
            cmd.CommandText = "SELECT * FROM HEADLETTERS_ENGINE.DBO.DAILY_RULES_MAIN WHERE UID = '" + UID + "' AND HID = '" + HID + "'"
            reader = cmd.ExecuteReader()
            While reader.Read()
                Dim Daily_Rules_Main = New DAILY_RULES_MAIN With {
                    .UID = reader("UID").ToString().Trim,
                    .HID = reader("HID").ToString().Trim,
                    .MAIN = reader("MAIN").ToString().Trim,
                    .S1 = reader("S1").ToString().Trim,
                    .S2 = reader("S2").ToString().Trim,
                    .S3 = reader("S3").ToString().Trim,
                    .S4 = reader("S4").ToString().Trim,
                    .S5 = reader("S5").ToString().Trim,
                    .S6 = reader("S6").ToString().Trim,
                    .RULESID = reader("RULESID").ToString().Trim,
                    .CCOUNT = If(IsDBNull(reader("CCOUNT")), 0, reader("CCOUNT")),
                    .DESCRIPTION = reader("DESCRIPTION").ToString().Trim,
                    .RTOTAL = If(IsDBNull(reader("RTOTAL")), 0, reader("RTOTAL")),
                    .FREQ = reader("FREQ").ToString().Trim,
                    .CATEGORY = reader("CATEGORY").ToString().Trim
                }
                DAILY_RULES_MAINList.Add(Daily_Rules_Main)
            End While
        Catch ex As Exception
            Dim strFile As String = String.Format("C:\Astro\ServiceLogs\PromiseWork\Promise_Error.txt")
            IO.File.AppendAllText(strFile, String.Format(vbCrLf + "UID=> " + UID + "  ::  HID=> " + HID + vbCrLf + "Error Occured at-- {0}{1}{2}", Environment.NewLine + DateTime.Now, Environment.NewLine, ex.Message + vbCrLf + ex.StackTrace))
        Finally
            con.Close()
        End Try
    End Sub
    Sub Select_From_DAILY_RULES_SUB(ByVal UID As String, ByVal HID As String, ByRef DAILY_RULES_SUBList As List(Of DAILY_RULES_SUB))
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim reader As SqlDataReader
        Try
            con.ConnectionString = constr
            con.Open()
            cmd.Connection = con
            cmd.CommandText = "SELECT * FROM HEADLETTERS_ENGINE.DBO.DAILY_RULES_SUB;"
            reader = cmd.ExecuteReader()
            While reader.Read()
                Dim Daily_Rules_Sub = New DAILY_RULES_SUB With {
                    .RULESID = reader("RULESID").ToString().Trim,
                    .C1 = reader("C1").ToString().Trim,
                    .C1PM = reader("C1PM").ToString().Trim,
                    .C2 = reader("C2").ToString().Trim,
                    .C2PM = reader("C2PM").ToString().Trim,
                    .C3 = reader("C3").ToString().Trim,
                    .C3PM = reader("C3PM").ToString().Trim,
                    .C4 = reader("C4").ToString().Trim,
                    .C4PM = reader("C4PM").ToString().Trim,
                    .C5 = reader("C5").ToString().Trim,
                    .C5PM = reader("C5PM").ToString().Trim
                }
                DAILY_RULES_SUBList.Add(Daily_Rules_Sub)
            End While
        Catch ex As Exception
            Dim strFile As String = String.Format("C:\Astro\ServiceLogs\PromiseWork\Promise_Error.txt")
            IO.File.AppendAllText(strFile, String.Format(vbCrLf + "UID=> " + UID + "  ::  HID=> " + HID + vbCrLf + "Error Occured at-- {0}{1}{2}", Environment.NewLine + DateTime.Now, Environment.NewLine, ex.Message + vbCrLf + ex.StackTrace))
        Finally
            con.Close()
        End Try
    End Sub
    Sub Select_From_HCUSP_PROMISE_LINK(ByVal UID As String, ByVal HID As String, ByRef HCUSP_PROMISE_LINKList As List(Of HCUSP_PROMISE_LINK))
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim reader As SqlDataReader
        Try
            con.ConnectionString = constr
            con.Open()
            cmd.Connection = con
            cmd.CommandText = "SELECT * FROM HEADLETTERS_ENGINE.DBO.HCUSP_PROMISE_LINK WHERE UID = '" + UID + "' AND HID = '" + HID + "';"
            reader = cmd.ExecuteReader()
            While reader.Read()
                Dim HCusp_Promise_Link = New HCUSP_PROMISE_LINK With {
                    .UID = reader("UID").ToString().Trim,
                    .HID = reader("HID").ToString().Trim,
                    .CUSPKEY = reader("CUSPKEY").ToString().Trim,
                    .TCOUNT = reader("TCOUNT"),
                    .SKEY = reader("SKEY").ToString().Trim
                }
                HCUSP_PROMISE_LINKList.Add(HCusp_Promise_Link)
            End While
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

                Dim con As New SqlConnection
                Dim cmd As New SqlCommand
                Try
                    con.ConnectionString = constr
                    con.Open()
                    cmd.Connection = con
                    cmd.CommandText = $"UPDATE HEADLETTERS_ENGINE.DBO.DAILY_RULES_MAIN SET RTOTAL = " + (pos - neg).ToString() + " WHERE RULESID = '" + mr + "' AND UID  = '" + UID + "' AND HID = '" + HID + "';"
                    cmd.ExecuteNonQuery()
                Catch ex As Exception
                    Dim strFile As String = String.Format("C:\Astro\ServiceLogs\PromiseWork\Promise_Error.txt")
                    IO.File.AppendAllText(strFile, String.Format(vbCrLf + "UID=> " + UID + "  ::  HID=> " + HID + vbCrLf + "Error Occured at-- {0}{1}{2}", Environment.NewLine + DateTime.Now, Environment.NewLine, ex.Message + vbCrLf + ex.StackTrace))
                Finally
                    con.Close()
                End Try
            End If
        Next
        For i As Integer = 0 To DAILY_RULES_MAINList.Count - 1
            Dim Diff = DAILY_RULES_MAINList.Item(i).CCOUNT - DAILY_RULES_MAINList.Item(i).RTOTAL
            Dim con As New SqlConnection
            Dim cmd As New SqlCommand
            Try
                con.ConnectionString = constr
                con.Open()
                cmd.Connection = con

                If Diff > 2 Then
                    cmd.CommandText = $"UPDATE HEADLETTERS_ENGINE.DBO.DAILY_RULES_MAIN SET FREQ = 'low/medium' WHERE RULESID = '" + DAILY_RULES_MAINList.Item(i).RULESID + "' AND UID  = '" + UID + "' AND HID = '" + HID + "';"
                    cmd.ExecuteNonQuery()
                Else
                    cmd.CommandText = $"UPDATE HEADLETTERS_ENGINE.DBO.DAILY_RULES_MAIN SET FREQ = 'high' WHERE RULESID = '" + DAILY_RULES_MAINList.Item(i).RULESID + "' AND UID  = '" + UID + "' AND HID = '" + HID + "';"
                    cmd.ExecuteNonQuery()
                End If
            Catch ex As Exception
                Dim strFile As String = String.Format("C:\Astro\ServiceLogs\PromiseWork\Promise_Error.txt")
                IO.File.AppendAllText(strFile, String.Format(vbCrLf + "UID=> " + UID + "  ::  HID=> " + HID + vbCrLf + "Error Occured at-- {0}{1}{2}", Environment.NewLine + DateTime.Now, Environment.NewLine, ex.Message + vbCrLf + ex.StackTrace))
            Finally
                con.Close()
            End Try
        Next
    End Sub
    Sub INSERT_INTO_HPROMISE(ByVal UID As String, ByVal HID As String)
        Dim SelectDAILY_RULES_MAIN = "DELETE FROM ASTROLOGYSOFTWARE_DB.DBO.HPROMISE WHERE PMUSERID = '" + UID + "' AND PMHID = '" + HID + "';SELECT * FROM HEADLETTERS_ENGINE.DBO.DAILY_RULES_MAIN WHERE UID = '" + UID + "' AND HID = '" + HID + "';"
        Dim con As New SqlConnection(constr)
        con.Open()
        Dim cmd As New SqlCommand(SelectDAILY_RULES_MAIN, con)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet()
        da.Fill(ds)
        con.Close()
        Dim DTNow = DateTime.Now.ToString()
        Dim conn As New SqlConnection
        Dim cmdd As New SqlCommand
        conn.ConnectionString = constr
        conn.Open()
        cmdd.Connection = conn
        Dim DELETE_FROM_HPROMISE = "DELETE FROM ASTROLOGYSOFTWARE_DB.DBO.HPROMISE WHERE PMUSERID = '" + UID + "' AND PMHID = '" + HID + "';SELECT * FROM HEADLETTERS_ENGINE.DBO.DAILY_RULES_MAIN WHERE UID = '" + UID + "' AND HID = '" + HID + "';"
        Dim INSERT_INTO_HPROMISE = ""
        For i As Integer = 0 To ds.Tables(0).Rows.Count - 1
            INSERT_INTO_HPROMISE = INSERT_INTO_HPROMISE + $"INSERT INTO ASTROLOGYSOFTWARE_DB.DBO.HPROMISE VALUES
                                    ('" + UID + "','" + HID + "','" + (i + 1).ToString() + "',
                                    '11','" + DTNow + "','" + DTNow + "','" + DTNow + "',
                                    '" + ds.Tables(0).Rows(i)(14).ToString.Trim + "','" + ds.Tables(0).Rows(i)(9) + "',
                                    '" + ds.Tables(0).Rows(i)(13) + "','" + ds.Tables(0).Rows(i)(11) + "'
                                    ,NULL,NULL,NULL,NULL,NULL,'2',NULL,NULL);" + vbCrLf
        Next
        cmdd.CommandText = DELETE_FROM_HPROMISE + vbCrLf + INSERT_INTO_HPROMISE
        cmdd.ExecuteNonQuery()
        conn.Close()
    End Sub

    Public Class HCUSP
        Property CUSPUSERID As String
        Property CUSPHID As String
        Property CUSP As String
        Property SIGN As String
        Property DMS As String
        Property CP1 As String
        Property CP2 As String
        Property CP3 As String
    End Class
    Public Class HRAKE
        Property UID As String
        Property HID As String
        Property HKEY As String
        Property S1 As String
    End Class
    Public Class HPLANET
        Property PLHUSERID As String
        Property PLHID As String
        Property PLANET As String
        Property SIGN As String
        Property DMS As String
        Property HP1 As String
        Property HP2 As String
        Property HP3 As String
        Property HP4 As String
        Property HP5 As String
        Property HP6 As String
        Property HPHOUSE As String
    End Class
    Public Class HCUSP_CALC
        Property CUSPUSERID As String
        Property CUSPHID As String
        Property CUSPID As String
        Property CUSPPLANET As String
        Property CUSPTYPE As String
        Property CUSPCAT As String
    End Class
    Class HCUSP_SIGN_SUB
        Property UID As String
        Property HID As String
        Property CUSP As String
        Property PLANET As String
    End Class
    Class Y1
        Property UID As String
        Property HID As String
        Property FKEY As String
        Property TKEY As String
        Property PLANET As String
    End Class
    Class HCUSP_PROMISE_LINK
        Property UID As String
        Property HID As String
        Property CUSPKEY As String
        Property TCOUNT As Integer
        Property SKEY As String
    End Class
    Class DAILY_RULES_SUB
        Property RULESID As String
        Property C1 As String
        Property C1PM As String
        Property C2 As String
        Property C2PM As String
        Property C3 As String
        Property C3PM As String
        Property C4 As String
        Property C4PM As String
        Property C5 As String
        Property C5PM As String
    End Class
    Class DAILY_RULES_TEMPLATE
        Property MAIN As String
        Property S1 As String
        Property S2 As String
        Property S3 As String
        Property S4 As String
        Property S5 As String
        Property S6 As String
        Property RULESID As String
        Property CCOUNT As Integer
        Property DESCRIPTION As String
        Property CATEGORY As String
        Property RTOTAL As Integer
        Property CUSPINDEX As String
        Property DUP As String
    End Class
    Public Class DAILY_RULES_MAIN
        Property UID As String
        Property HID As String
        Property MAIN As String
        Property S1 As String
        Property S2 As String
        Property S3 As String
        Property S4 As String
        Property S5 As String
        Property S6 As String
        Property RULESID As String
        Property CCOUNT As Integer
        Property DESCRIPTION As String
        Property RTOTAL As Integer
        Property FREQ As String
        Property CATEGORY As String
    End Class
End Class