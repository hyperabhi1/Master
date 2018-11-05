Imports System.Reflection

Public Class CommonController
    Shared Function GetCuspNo(ByVal s As String)
        Dim ov = "NA"
        Select Case s
            Case "Cusp I"
                ov = "01"
            Case "Cusp II"
                ov = "02"
            Case "Cusp III"
                ov = "03"
            Case "Cusp IV"
                ov = "04"
            Case "Cusp V"
                ov = "05"
            Case "Cusp VI"
                ov = "06"
            Case "Cusp VII"
                ov = "07"
            Case "Cusp VIII"
                ov = "08"
            Case "Cusp IX"
                ov = "09"
            Case "Cusp X"
                ov = "10"
            Case "Cusp XI"
                ov = "11"
            Case "Cusp XII"
                ov = "12"
            Case Else
        End Select
        Return ov
    End Function

    Shared Function GetPlanetShortName(ByVal Pl As String)
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

    Shared Function GetCuspPrefix(ByVal s As String)
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

    Shared Function SplitInTwoChar(ByRef S1 As String) As String()
        Dim S1Split = New String(S1.Length / 2 + (If(S1.Length Mod 2 = 0, 0, 1)) - 1) {}
        For i As Integer = 0 To S1Split.Length - 1
            S1Split(i) = S1.Substring(i * 2, If(i * 2 + 2 > S1.Length, 1, 2))
        Next
        Return S1Split
    End Function

    Shared Function GetDayOfTheWeek(ByVal day As String) As String
        Dim DayOfWeek() = {"Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday"}
        Return DayOfWeek(Convert.ToInt32(day))
    End Function

    Shared Function Get_Planet_from_REQCAT(x As String) As String
        If x = "4" Then
            Return "JU"
        ElseIf x = "5" Then
            Return "SA"
        ElseIf x = "6" Then
            Return "RA"
        ElseIf x = "7" Then
            Return "KE"
        ElseIf x = "8" Then
            Return "MA"
        ElseIf x = "9" Then
            Return "SU"
        ElseIf x = "10" Then
            Return "ME"
        Else
            Return "NA"
        End If
    End Function

    Shared Function Get_REQCAT_from_Planet(x As String) As String
        If x = "JU" Then
            Return "4"
        ElseIf x = "SA" Then
            Return "5"
        ElseIf x = "RA" Then
            Return "6"
        ElseIf x = "KE" Then
            Return "7"
        ElseIf x = "MA" Then
            Return "8"
        ElseIf x = "SU" Then
            Return "9"
        ElseIf x = "ME" Then
            Return "10"
        Else
            Return "NA"
        End If
    End Function

    Shared Function ConvertListToDataTable(Of T)(ByVal items As List(Of T)) As DataTable
        Dim dataTable As DataTable = New DataTable(GetType(T).Name)
        Dim Props As PropertyInfo() = GetType(T).GetProperties(BindingFlags.[Public] Or BindingFlags.Instance)

        For Each prop As PropertyInfo In Props
            dataTable.Columns.Add(prop.Name)
        Next

        For Each item As T In items
            Dim values = New Object(Props.Length - 1) {}

            For i As Integer = 0 To Props.Length - 1
                values(i) = Props(i).GetValue(item, Nothing)
            Next

            dataTable.Rows.Add(values)
        Next

        Return dataTable
    End Function
End Class
