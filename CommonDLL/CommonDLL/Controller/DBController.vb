Imports System.Data.SqlClient
Imports System.Globalization

Public Class DBController
    'Public constr = "data source=DESKTOP-JBRFH9E;initial catalog=HEADLETTERS_ENGINE;integrated security=True;"
    'Public constr = "data source=WIN-KSTUPT6CJRC;initial catalog=HEADLETTERS_ENGINE;integrated security=True;multipleactiveresultsets=True;"
    'Public constr = "data source=WIN-KSTUPT6CJRC;initial catalog=HEADLETTERS_ENGINE;integrated security=False;multipleactiveresultsets=True;User Id=sa;password=pSI)TA1t0K[);"
    Public Shared constr = "data source=49.50.103.132;initial catalog=HEADLETTERS_ENGINE;integrated security=False;User Id=sa;password=pSI)TA1t0K[)"

    Shared Function Select_From_HRAKE(ByVal UID As String, ByVal HID As String) As List(Of HRAKE)
        Dim connection As SqlConnection = New SqlConnection(constr)
        Dim query = $"SELECT * FROM HEADLETTERS_ENGINE.DBO.HRAKE WHERE UID = '" + UID + "' AND HID = '" + HID + "' AND HKEY = 'RA';
                                SELECT * FROM HEADLETTERS_ENGINE.DBO.HRAKE WHERE UID = '" + UID + "' AND HID = '" + HID + "' AND HKEY = 'KE';"
        Dim cmd As New SqlCommand(query, connection)
        Dim da As New SqlDataAdapter(cmd)
        Dim ds As New DataSet()
        Dim HRAKEList As New List(Of HRAKE)
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
        Return HRAKEList
    End Function

    Shared Function Select_From_HCUSP(ByVal UID As String, ByVal HID As String) As List(Of HCUSP)
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim reader As SqlDataReader
        Dim HCUSPList As New List(Of HCUSP)
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
        Return HCUSPList
    End Function

    Shared Function Select_From_HPLANET(ByVal UID As String, ByVal HID As String) As List(Of HPLANET)
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim reader As SqlDataReader
        Dim HPLANETList As New List(Of HPLANET)
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
        Return HPLANETList
    End Function

    Shared Function Select_From_HPLANET_SLCHECK(ByVal UID As String, ByVal HID As String, ByVal Planet As String) As List(Of String)
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim reader As SqlDataReader
        Dim HP3List As New List(Of String)
        Try
            con.ConnectionString = constr
            con.Open()
            cmd.Connection = con
            cmd.CommandText = "SELECT * FROM HEADLETTERS_ENGINE.DBO.HPLANET WHERE PLHUSERID = '" + UID + "' AND PLHID = '" + HID + "' AND HP3 = '" + Planet + "';"
            reader = cmd.ExecuteReader()
            While reader.Read()
                If reader("PLANET").ToString().Trim <> "NE" And reader("PLANET").ToString().Trim <> "UR" And reader("PLANET").ToString().Trim <> "PL" Then
                    HP3List.Add(reader("HP3").ToString().Trim)
                End If
            End While
        Catch ex As Exception
            Dim strFile As String = String.Format("C:\Astro\ServiceLogs\Errors\Promise_Error.txt")
            IO.File.AppendAllText(strFile, String.Format(vbCrLf + "UID=> " + UID + "  ::  HID=> " + HID + vbCrLf + "Error Occured at-- {0}{1}{2}", Environment.NewLine + DateTime.Now, Environment.NewLine, ex.Message + vbCrLf + ex.StackTrace))
        Finally
            con.Close()
        End Try
        Return HP3List
    End Function

    Shared Sub Insert_Into_HCUSP_CALC(ByVal UID As String, ByVal HID As String, ByVal HCUSPList As List(Of HCUSP), ByVal HPLANETList As List(Of HPLANET))
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
                    Dim HCUSPCP1 = CommonController.SplitInTwoChar(HCUSPList.Item(i).CP1)
                    For j As Integer = 0 To HCUSPCP1.Count - 1
                        HCUSPQueryCP1 = HCUSPQueryCP1 + "INSERT INTO HEADLETTERS_ENGINE.DBO.HCUSP_CALC VALUES ('" + HCUSPList.Item(i).CUSPUSERID + "','" + HCUSPList.Item(i).CUSPHID + "','" + HCUSPList.Item(i).CUSP + "','" + HCUSPCP1(j) + "','1','" + If(j = 0, "1", "3") + "');" + vbCrLf
                    Next
                Else
                    HCUSPQueryCP1 = "INSERT INTO HEADLETTERS_ENGINE.DBO.HCUSP_CALC VALUES ('" + HCUSPList.Item(i).CUSPUSERID + "','" + HCUSPList.Item(i).CUSPHID + "','" + HCUSPList.Item(i).CUSP + "','" + HCUSPList.Item(i).CP1 + "','1','1');" + vbCrLf
                End If
                If HCUSPList.Item(i).CP2.Length > 2 Then
                    Dim HCUSPCP2 = CommonController.SplitInTwoChar(HCUSPList.Item(i).CP2)
                    For j As Integer = 0 To HCUSPCP2.Count - 1
                        HCUSPQueryCP2 = HCUSPQueryCP2 + "INSERT INTO HEADLETTERS_ENGINE.DBO.HCUSP_CALC VALUES ('" + HCUSPList.Item(i).CUSPUSERID + "','" + HCUSPList.Item(i).CUSPHID + "','" + HCUSPList.Item(i).CUSP + "','" + HCUSPCP2(j) + "','2','" + If(j = 0, "1", "3") + "');" + vbCrLf
                    Next
                Else
                    HCUSPQueryCP2 = "INSERT INTO HEADLETTERS_ENGINE.DBO.HCUSP_CALC VALUES ('" + HCUSPList.Item(i).CUSPUSERID + "','" + HCUSPList.Item(i).CUSPHID + "','" + HCUSPList.Item(i).CUSP + "','" + HCUSPList.Item(i).CP2 + "','2','1');" + vbCrLf
                End If
                If HCUSPList.Item(i).CP3.Length > 2 Then
                    Dim HCUSPCP3 = CommonController.SplitInTwoChar(HCUSPList.Item(i).CP3)
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
                    Dim HPlanetArray = CommonController.SplitInTwoChar(HPLANETList.Item(i).PLANET)
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

    Shared Sub Conversion_of_HCUSP_RAKE(ByVal UID As String, ByVal HID As String, ByRef HCUSPList As List(Of HCUSP), ByVal HRAKEList As List(Of HRAKE))
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

    Shared Sub Conversion_of_HPLANET_RAKE(ByVal UID As String, ByVal HID As String, ByRef HPLANETList As List(Of HPLANET), ByVal HRAKEList As List(Of HRAKE))
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

    Shared Function Select_HCUSP_CALC(ByVal UID As String, ByVal HID As String) As List(Of HCUSP_CALC)
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim reader As SqlDataReader
        Dim HCUSP_CALCList As New List(Of HCUSP_CALC)
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
        Return HCUSP_CALCList
    End Function

    Shared Function Select_HCUSP_CALC_Expanded(ByVal UID As String, ByVal HID As String) As List(Of HCUSP_CALC)
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim reader As SqlDataReader
        Dim HCUSP_CALCList As New List(Of HCUSP_CALC)
        Try
            con.ConnectionString = constr
            con.Open()
            cmd.Connection = con
            cmd.CommandText = "SELECT * FROM HEADLETTERS_ENGINE.DBO.HCUSP_CALC WHERE CUSPUSERID = '" + UID + "' AND CUSPHID = '" + HID + "' AND CUSPCAT = '3';"
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
        Return HCUSP_CALCList
    End Function

    Shared Function Select_HCUSP_CALC_Expanded(ByVal UID As String, ByVal HID As String, ByVal Planet As String) As List(Of HCUSP_CALC)
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim reader As SqlDataReader
        Dim HCUSP_CALCList As New List(Of HCUSP_CALC)
        Try
            con.ConnectionString = constr
            con.Open()
            cmd.Connection = con
            cmd.CommandText = "SELECT * FROM HEADLETTERS_ENGINE.DBO.HCUSP_CALC WHERE CUSPUSERID = '" + UID + "' AND CUSPHID = '" + HID + "' AND CUSPCAT = '3' AND CUSPPLANET = '" + Planet + "';"
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
        Return HCUSP_CALCList
    End Function

    Shared Function Select_HCUSP_CALC_UnExpanded(ByVal UID As String, ByVal HID As String) As List(Of HCUSP_CALC)
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim reader As SqlDataReader
        Dim HCUSP_CALCList As New List(Of HCUSP_CALC)
        Try
            con.ConnectionString = constr
            con.Open()
            cmd.Connection = con
            cmd.CommandText = "SELECT * FROM HEADLETTERS_ENGINE.DBO.HCUSP_CALC WHERE CUSPUSERID = '" + UID + "' AND CUSPHID = '" + HID + "' AND CUSPCAT <> '3';"
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
        Return HCUSP_CALCList
    End Function

    Shared Function Select_HCUSP_CALC_UnExpanded(ByVal UID As String, ByVal HID As String, ByVal Planet As String) As List(Of HCUSP_CALC)
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim reader As SqlDataReader
        Dim HCUSP_CALCList As New List(Of HCUSP_CALC)
        Try
            con.ConnectionString = constr
            con.Open()
            cmd.Connection = con
            cmd.CommandText = "SELECT * FROM HEADLETTERS_ENGINE.DBO.HCUSP_CALC WHERE CUSPUSERID = '" + UID + "' AND CUSPHID = '" + HID + "' AND CUSPCAT <> '3' AND CUSPPLANET = '" + Planet + "';"
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
        Return HCUSP_CALCList
    End Function

    Shared Function Select_Cusp_From_HCUSP_CALC_Where_Planet(ByVal UID As String, ByVal HID As String, ByVal Planet As String, ByVal CUSPCAT As String) As List(Of String)
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim reader As SqlDataReader
        Dim CUSPList As New List(Of String)
        Try
            con.ConnectionString = constr
            con.Open()
            cmd.Connection = con
            cmd.CommandText = "SELECT * FROM HEADLETTERS_ENGINE.DBO.HCUSP_CALC WHERE CUSPUSERID = '" + UID + "' AND CUSPHID = '" + HID + "' AND CUSPPLANET = '" + Planet + "' AND CUSPTYPE = '1' AND CUSPCAT = '3';"
            reader = cmd.ExecuteReader()
            While reader.Read()
                CUSPList.Add(reader("CUSPID").ToString().Trim)
            End While
        Catch ex As Exception
            Dim strFile As String = String.Format("C:\Astro\ServiceLogs\Errors\Promise_Error.txt")
            IO.File.AppendAllText(strFile, String.Format(vbCrLf + "UID=> " + UID + "  ::  HID=> " + HID + vbCrLf + "Error Occured at-- {0}{1}{2}", Environment.NewLine + DateTime.Now, Environment.NewLine, ex.Message + vbCrLf + ex.StackTrace))
        Finally
            con.Close()
        End Try
        Return CUSPList
    End Function

    Shared Function Select_From_Y1(ByVal UID As String, ByVal HID As String) As List(Of Y1)
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim reader As SqlDataReader
        Dim Y1List As New List(Of Y1)
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
        Return Y1List
    End Function

    Shared Function Select_Star_From_HREQUEST_API(ByVal REQCAT As Integer) As List(Of HREQUEST_API)
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim reader As SqlDataReader
        Dim HREQUEST_APIList As New List(Of HREQUEST_API)
        Try
            con.ConnectionString = constr
            con.Open()
            cmd.Connection = con
            cmd.CommandText = "SELECT * FROM ASTROLOGYSOFTWARE_DB.DBO.HREQUEST_API WHERE REQCAT = " + REQCAT.ToString() + ";"
            reader = cmd.ExecuteReader()
            While reader.Read()
                Dim HREQUESTAPI = New HREQUEST_API With {
                    .RQUSERID = reader("RQUSERID").ToString().Trim,
                    .RQHID = reader("RQHID").ToString().Trim,
                    .RQID = reader("RQID").ToString().Trim,
                    .REQCAT = reader("REQCAT").ToString().Trim,
                    .RQPDATE = reader("RQPDATE"),
                    .RQLONGTIDUE = reader("RQLONGTIDUE").ToString().Trim,
                    .RQLONGTITUDEEW = reader("RQLONGTITUDEEW").ToString().Trim,
                    .RQLATITUDE = reader("RQLATITUDE").ToString().Trim,
                    .RQLATITUDENS = reader("RQLATITUDENS").ToString().Trim,
                    .RQDST = reader("RQDST"),
                    .RQTIMEZ = reader("RQTIMEZ").ToString().Trim
                }
                HREQUEST_APIList.Add(HREQUESTAPI)
            End While
        Catch ex As Exception
            Dim strFile As String = String.Format("C:\Astro\ServiceLogs\Errors\Prediction_Error.txt")
            IO.File.AppendAllText(strFile, String.Format(vbCrLf + "REQCAT=> " + REQCAT.ToString() + vbCrLf + "Error Occured at-- {0}{1}{2}", Environment.NewLine + DateTime.Now, Environment.NewLine, ex.Message + vbCrLf + ex.StackTrace))
        Finally
            con.Close()
        End Try
        Return HREQUEST_APIList
    End Function

    Shared Function Get_Date_Of_Birth(ByRef UID As String, ByRef HID As String) As DateTime
        Dim DOB As DateTime
        Dim SelectRECTIFIEDDATE = "SELECT RECTIFIEDDATESTRING FROM ASTROLOGYSOFTWARE_DB.DBO.HMAIN WHERE HUSERID = '" + UID + "' AND HID = '" + HID + "' AND RECTIFIEDDATE IS NOT NULL;"
        Dim con As New SqlConnection(constr)
        Try
            con.Open()
            Dim cmd As New SqlCommand(SelectRECTIFIEDDATE, con)
            Dim da As New SqlDataAdapter(cmd)
            Dim ds As New DataSet()
            da.Fill(ds)
            Dim DateOfBirth = CType(ds.Tables(0).Rows(0)(0), DateTime).ToString("dd-MM-yyyy HH:mm:ss.fff", CultureInfo.InvariantCulture)
            DOB = Convert.ToDateTime(DateOfBirth)
        Catch ex As Exception
            Dim strFile As String = String.Format("C:\Astro\ServiceLogs\Errors\Common_Error.txt")
            IO.File.AppendAllText(strFile, String.Format(vbCrLf + "UID=> " + UID + "  ::  HID=> " + HID + vbCrLf + "Error Occured at-- {0}{1}{2}", Environment.NewLine + DateTime.Now, Environment.NewLine, ex.Message + vbCrLf + ex.StackTrace))
        Finally
            con.Close()
        End Try
        Return DOB
    End Function

    Shared Function Select_HREQUEST() As List(Of HREQUEST)
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim reader As SqlDataReader
        Dim HREQUESTList As New List(Of HREQUEST)
        Try
            con.ConnectionString = constr
            con.Open()
            cmd.Connection = con
            cmd.CommandText = "SELECT * FROM ASTROLOGYSOFTWARE_DB.DBO.HREQUEST;"
            reader = cmd.ExecuteReader()
            While reader.Read()
                Dim HREQUEST_ = New HREQUEST With {
                    .RQUSERID = reader("RQUSERID").ToString().Trim,
                    .RQHID = reader("RQHID").ToString().Trim,
                    .RQID = reader("RQID").ToString().Trim,
                    .REQCAT = reader("REQCAT").ToString().Trim,
                    .RQSPECIALDETAILS = reader("RQSPECIALDETAILS").ToString().Trim,
                    .RQSDATE = reader("RQSDATE"),
                    .RQEDATE = reader("RQEDATE"),
                    .RQLONGTIDUE = reader("RQLONGTIDUE").ToString().Trim,
                    .RQLONGTITUDEEW = reader("RQLONGTITUDEEW").ToString().Trim,
                    .RQLATITUDE = reader("RQLATITUDE").ToString().Trim,
                    .RQLATITUDENS = reader("RQLATITUDENS").ToString().Trim,
                    .RQDST = reader("RQDST"),
                    .RQRECDELETED = reader("RQRECDELETED").ToString().Trim,
                    .RQPRSTATUS = reader("RQPRSTATUS").ToString().Trim,
                    .RQUNREAD = reader("RQUNREAD").ToString().Trim,
                    .RQCHARGE = reader("RQCHARGE").ToString().Trim,
                    .RQBID = reader("RQBID").ToString().Trim,
                    .TIMESTAMP = reader("TIMESTAMP").ToString().Trim,
                    .GPSCOORDINATES = reader("GPSCOORDINATES").ToString().Trim,
                    .RQADATE = reader("RQADATE"),
                    .RQATIME = reader("RQATIME"),
                    .REQCREDATE = reader("REQCREDATE"),
                    .ISPROCESSED = reader("ISPROCESSED").ToString().Trim,
                    .ISCOPEDAPIREQUEST = reader("ISCOPEDAPIREQUEST").ToString().Trim
                }
                HREQUESTList.Add(HREQUEST_)
            End While
        Catch ex As Exception
            Dim strFile As String = String.Format("C:\Astro\ServiceLogs\Errors\Prediction_Error.txt")
            IO.File.AppendAllText(strFile, String.Format(vbCrLf + "Error Occured at-- {0}{1}{2}", Environment.NewLine + DateTime.Now, Environment.NewLine, ex.Message + vbCrLf + ex.StackTrace))
        Finally
            con.Close()
        End Try
        Return HREQUESTList
    End Function

    Shared Function Select_HREQUEST_WeeklyPrediction() As List(Of HREQUEST)
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim reader As SqlDataReader
        Dim HREQUESTList As New List(Of HREQUEST)
        Try
            con.ConnectionString = constr
            con.Open()
            cmd.Connection = con
            cmd.CommandText = $"SELECT * FROM ASTROLOGYSOFTWARE_DB.DBO.HREQUEST WHERE REQCAT = 1 AND RQSDATE IS NOT NULL 
                               AND RQEDATE IS NOT NULL AND RQADATE IS NOT NULL AND RQATIME IS NOT NULL AND REQCREDATE IS NOT NULL;"
            reader = cmd.ExecuteReader()
            While reader.Read()
                Dim HREQUEST_ = New HREQUEST With {
                    .RQUSERID = reader("RQUSERID").ToString().Trim,
                    .RQHID = reader("RQHID").ToString().Trim,
                    .RQID = reader("RQID").ToString().Trim,
                    .REQCAT = reader("REQCAT").ToString().Trim,
                    .RQSPECIALDETAILS = reader("RQSPECIALDETAILS").ToString().Trim,
                    .RQSDATE = reader("RQSDATE"),
                    .RQEDATE = reader("RQEDATE"),
                    .RQLONGTIDUE = reader("RQLONGTIDUE").ToString().Trim,
                    .RQLONGTITUDEEW = reader("RQLONGTITUDEEW").ToString().Trim,
                    .RQLATITUDE = reader("RQLATITUDE").ToString().Trim,
                    .RQLATITUDENS = reader("RQLATITUDENS").ToString().Trim,
                    .RQDST = reader("RQDST"),
                    .RQRECDELETED = reader("RQRECDELETED").ToString().Trim,
                    .RQPRSTATUS = reader("RQPRSTATUS").ToString().Trim,
                    .RQUNREAD = reader("RQUNREAD").ToString().Trim,
                    .RQCHARGE = reader("RQCHARGE").ToString().Trim,
                    .RQBID = reader("RQBID").ToString().Trim,
                    .TIMESTAMP = reader("TIMESTAMP").ToString().Trim,
                    .GPSCOORDINATES = reader("GPSCOORDINATES").ToString().Trim,
                    .RQADATE = reader("RQADATE"),
                    .RQATIME = reader("RQATIME"),
                    .REQCREDATE = reader("REQCREDATE"),
                    .ISPROCESSED = reader("ISPROCESSED").ToString().Trim,
                    .ISCOPEDAPIREQUEST = reader("ISCOPEDAPIREQUEST").ToString().Trim
                }
                HREQUESTList.Add(HREQUEST_)
            End While
        Catch ex As Exception
            Dim strFile As String = String.Format("C:\Astro\ServiceLogs\Errors\Prediction_Error.txt")
            IO.File.AppendAllText(strFile, String.Format(vbCrLf + "Error Occured at-- {0}{1}{2}", Environment.NewLine + DateTime.Now, Environment.NewLine, ex.Message + vbCrLf + ex.StackTrace))
        Finally
            con.Close()
        End Try
        Return HREQUESTList
    End Function

    Shared Function Select_HREQUEST_DailyPrediction() As List(Of HREQUEST)
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim reader As SqlDataReader
        Dim HREQUESTList As New List(Of HREQUEST)
        Try
            con.ConnectionString = constr
            con.Open()
            cmd.Connection = con
            cmd.CommandText = $"SELECT * FROM ASTROLOGYSOFTWARE_DB.DBO.HREQUEST WHERE REQCAT = 2 AND RQSDATE IS NOT NULL 
                               AND RQEDATE IS NOT NULL AND RQADATE IS NOT NULL AND RQATIME IS NOT NULL AND REQCREDATE IS NOT NULL;"
            reader = cmd.ExecuteReader()
            While reader.Read()
                Dim HREQUEST_ = New HREQUEST With {
                    .RQUSERID = reader("RQUSERID").ToString().Trim,
                    .RQHID = reader("RQHID").ToString().Trim,
                    .RQID = reader("RQID").ToString().Trim,
                    .REQCAT = reader("REQCAT").ToString().Trim,
                    .RQSPECIALDETAILS = reader("RQSPECIALDETAILS").ToString().Trim,
                    .RQSDATE = reader("RQSDATE"),
                    .RQEDATE = reader("RQEDATE"),
                    .RQLONGTIDUE = reader("RQLONGTIDUE").ToString().Trim,
                    .RQLONGTITUDEEW = reader("RQLONGTITUDEEW").ToString().Trim,
                    .RQLATITUDE = reader("RQLATITUDE").ToString().Trim,
                    .RQLATITUDENS = reader("RQLATITUDENS").ToString().Trim,
                    .RQDST = reader("RQDST"),
                    .RQRECDELETED = reader("RQRECDELETED").ToString().Trim,
                    .RQPRSTATUS = reader("RQPRSTATUS").ToString().Trim,
                    .RQUNREAD = reader("RQUNREAD").ToString().Trim,
                    .RQCHARGE = reader("RQCHARGE").ToString().Trim,
                    .RQBID = reader("RQBID").ToString().Trim,
                    .TIMESTAMP = reader("TIMESTAMP").ToString().Trim,
                    .GPSCOORDINATES = reader("GPSCOORDINATES").ToString().Trim,
                    .RQADATE = reader("RQADATE"),
                    .RQATIME = reader("RQATIME"),
                    .REQCREDATE = reader("REQCREDATE"),
                    .ISPROCESSED = reader("ISPROCESSED").ToString().Trim,
                    .ISCOPEDAPIREQUEST = reader("ISCOPEDAPIREQUEST").ToString().Trim
                }
                HREQUESTList.Add(HREQUEST_)
            End While
        Catch ex As Exception
            Dim strFile As String = String.Format("C:\Astro\ServiceLogs\Errors\Prediction_Error.txt")
            IO.File.AppendAllText(strFile, String.Format(vbCrLf + "Error Occured at-- {0}{1}{2}", Environment.NewLine + DateTime.Now, Environment.NewLine, ex.Message + vbCrLf + ex.StackTrace))
        Finally
            con.Close()
        End Try
        Return HREQUESTList
    End Function

    Shared Function Select_HREQUEST_TransitPrediction() As List(Of HREQUEST)
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim reader As SqlDataReader
        Dim HREQUESTList As New List(Of HREQUEST)
        Try
            con.ConnectionString = constr
            con.Open()
            cmd.Connection = con
            cmd.CommandText = $"SELECT * FROM ASTROLOGYSOFTWARE_DB.DBO.HREQUEST WHERE REQCAT IN (4,5,6,7,8,9,10) AND RQSDATE IS NOT NULL 
                               AND RQEDATE IS NOT NULL AND RQADATE IS NOT NULL AND RQATIME IS NOT NULL AND REQCREDATE IS NOT NULL;"
            reader = cmd.ExecuteReader()
            While reader.Read()
                Dim HREQUEST_ = New HREQUEST With {
                    .RQUSERID = reader("RQUSERID").ToString().Trim,
                    .RQHID = reader("RQHID").ToString().Trim,
                    .RQID = reader("RQID").ToString().Trim,
                    .REQCAT = reader("REQCAT").ToString().Trim,
                    .RQSPECIALDETAILS = reader("RQSPECIALDETAILS").ToString().Trim,
                    .RQSDATE = reader("RQSDATE"),
                    .RQEDATE = reader("RQEDATE"),
                    .RQLONGTIDUE = reader("RQLONGTIDUE").ToString().Trim,
                    .RQLONGTITUDEEW = reader("RQLONGTITUDEEW").ToString().Trim,
                    .RQLATITUDE = reader("RQLATITUDE").ToString().Trim,
                    .RQLATITUDENS = reader("RQLATITUDENS").ToString().Trim,
                    .RQDST = reader("RQDST"),
                    .RQRECDELETED = reader("RQRECDELETED").ToString().Trim,
                    .RQPRSTATUS = reader("RQPRSTATUS").ToString().Trim,
                    .RQUNREAD = reader("RQUNREAD").ToString().Trim,
                    .RQCHARGE = reader("RQCHARGE").ToString().Trim,
                    .RQBID = reader("RQBID").ToString().Trim,
                    .TIMESTAMP = reader("TIMESTAMP").ToString().Trim,
                    .GPSCOORDINATES = reader("GPSCOORDINATES").ToString().Trim,
                    .RQADATE = reader("RQADATE"),
                    .RQATIME = reader("RQATIME"),
                    .REQCREDATE = reader("REQCREDATE"),
                    .ISPROCESSED = reader("ISPROCESSED").ToString().Trim,
                    .ISCOPEDAPIREQUEST = reader("ISCOPEDAPIREQUEST").ToString().Trim
                }
                HREQUESTList.Add(HREQUEST_)
            End While
        Catch ex As Exception
            Dim strFile As String = String.Format("C:\Astro\ServiceLogs\Errors\Prediction_Error.txt")
            IO.File.AppendAllText(strFile, String.Format(vbCrLf + "Error Occured at-- {0}{1}{2}", Environment.NewLine + DateTime.Now, Environment.NewLine, ex.Message + vbCrLf + ex.StackTrace))
        Finally
            con.Close()
        End Try
        Return HREQUESTList
    End Function

    Shared Function Select_HREQUESTAPI_WeeklyPrediction() As List(Of HREQUEST_API)
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim reader As SqlDataReader
        Dim HREQUEST_APIList As New List(Of HREQUEST_API)
        Try
            con.ConnectionString = constr
            con.Open()
            cmd.Connection = con
            cmd.CommandText = "SELECT * FROM ASTROLOGYSOFTWARE_DB.DBO.HREQUEST_API WHERE REQCAT = 1;"
            reader = cmd.ExecuteReader()
            While reader.Read()
                Dim HREQUESTAPI = New HREQUEST_API With {
                    .RQUSERID = reader("RQUSERID").ToString().Trim,
                    .RQHID = reader("RQHID").ToString().Trim,
                    .RQID = reader("RQID").ToString().Trim,
                    .REQCAT = reader("REQCAT").ToString().Trim,
                    .RQPDATE = reader("RQPDATE"),
                    .RQLONGTIDUE = reader("RQLONGTIDUE").ToString().Trim,
                    .RQLONGTITUDEEW = reader("RQLONGTITUDEEW").ToString().Trim,
                    .RQLATITUDE = reader("RQLATITUDE").ToString().Trim,
                    .RQLATITUDENS = reader("RQLATITUDENS").ToString().Trim,
                    .RQDST = reader("RQDST"),
                    .RQTIMEZ = reader("RQTIMEZ").ToString().Trim
                }
                HREQUEST_APIList.Add(HREQUESTAPI)
            End While
        Catch ex As Exception
            Dim strFile As String = String.Format("C:\Astro\ServiceLogs\Errors\Prediction_Error.txt")
            IO.File.AppendAllText(strFile, String.Format(vbCrLf + "Error Occured at-- {0}{1}{2}", Environment.NewLine + DateTime.Now, Environment.NewLine, ex.Message + vbCrLf + ex.StackTrace))
        Finally
            con.Close()
        End Try
        Return HREQUEST_APIList
    End Function

    Shared Function Select_HREQUESTAPI_DailyPrediction() As List(Of HREQUEST_API)
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim reader As SqlDataReader
        Dim HREQUEST_APIList As New List(Of HREQUEST_API)
        Try
            con.ConnectionString = constr
            con.Open()
            cmd.Connection = con
            cmd.CommandText = "SELECT * FROM ASTROLOGYSOFTWARE_DB.DBO.HREQUEST_API WHERE REQCAT = 2;"
            reader = cmd.ExecuteReader()
            While reader.Read()
                Dim HREQUESTAPI = New HREQUEST_API With {
                    .RQUSERID = reader("RQUSERID").ToString().Trim,
                    .RQHID = reader("RQHID").ToString().Trim,
                    .RQID = reader("RQID").ToString().Trim,
                    .REQCAT = reader("REQCAT").ToString().Trim,
                    .RQPDATE = reader("RQPDATE"),
                    .RQLONGTIDUE = reader("RQLONGTIDUE").ToString().Trim,
                    .RQLONGTITUDEEW = reader("RQLONGTITUDEEW").ToString().Trim,
                    .RQLATITUDE = reader("RQLATITUDE").ToString().Trim,
                    .RQLATITUDENS = reader("RQLATITUDENS").ToString().Trim,
                    .RQDST = reader("RQDST"),
                    .RQTIMEZ = reader("RQTIMEZ").ToString().Trim
                }
                HREQUEST_APIList.Add(HREQUESTAPI)
            End While
        Catch ex As Exception
            Dim strFile As String = String.Format("C:\Astro\ServiceLogs\Errors\Prediction_Error.txt")
            IO.File.AppendAllText(strFile, String.Format(vbCrLf + "Error Occured at-- {0}{1}{2}", Environment.NewLine + DateTime.Now, Environment.NewLine, ex.Message + vbCrLf + ex.StackTrace))
        Finally
            con.Close()
        End Try
        Return HREQUEST_APIList
    End Function

    Shared Function Select_HREQUEST_For_UID_HID(UID As String, HID As String, REQCAT As String) As List(Of HREQUEST)
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        Dim reader As SqlDataReader
        Dim HREQUESTList As New List(Of HREQUEST)
        Try
            con.ConnectionString = constr
            con.Open()
            cmd.Connection = con
            cmd.CommandText = $"SELECT * FROM ASTROLOGYSOFTWARE_DB.DBO.HREQUEST WHERE REQCAT IN (4,5,6,7,8,9,10) AND RQUSERID = '" + UID + "' AND RQHID = '" + HID + "';"
            reader = cmd.ExecuteReader()
            While reader.Read()
                Dim HREQUEST_ = New HREQUEST With {
                    .RQUSERID = reader("RQUSERID").ToString().Trim,
                    .RQHID = reader("RQHID").ToString().Trim,
                    .RQID = reader("RQID").ToString().Trim,
                    .REQCAT = reader("REQCAT").ToString().Trim
                }
                HREQUESTList.Add(HREQUEST_)
            End While
        Catch ex As Exception
            Dim strFile As String = String.Format("C:\Astro\ServiceLogs\Errors\Prediction_Error.txt")
            IO.File.AppendAllText(strFile, String.Format(vbCrLf + "Error Occured at-- {0}{1}{2}", Environment.NewLine + DateTime.Now, Environment.NewLine, ex.Message + vbCrLf + ex.StackTrace))
        Finally
            con.Close()
        End Try
        Return HREQUESTList
    End Function


End Class
