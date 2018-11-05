Imports Headletters_CHART_n_PROMISE

Module Module1

    Sub Main()
        Dim Chart As New GenChart
        '        Chart.Main()
        ManageHistoryAccount.UpdateHistoryAccount()

        Dim s As Integer() = {1, 2, 3, 3, 4}
        s = s.Distinct().ToArray()
        Dim x = {"SA", "SU", "SA", "MO", "MA", "RA"}
        Dim xx = "SA-SA-SE-SU-MO-MO-MA"
        xx = xx.Distinct().ToArray()
        Dim xxzx = ""
        'Dim s(20) As String
        'Dim d = 0
        'Dim count = 0
        'For c = 0 To x.Length - 1
        '    For d = 0 To s.Length - 1
        '        If x(c) = s(d) Then
        '            Exit For
        '        End If
        '    Next
        '
        '    If d = count Then
        '        s(count) = x(c)
        '        count += 1
        '    End If
        'Next
    End Sub

End Module
