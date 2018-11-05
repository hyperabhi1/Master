Imports System.Drawing.Printing

Public Class PrintDasa
    Private WithEvents PrintDoc As New PrintDocument

    Private _CHeading As String
    Private oStringFormat As StringFormat
    Private nTotalWidth As Int16
    Private nRowPos As Integer
    Private NewPage As Boolean
    Private nPageNo As Integer
    Private _StPageNo As Integer
    Private Header As String
    Private nPageCount As Integer = 0
    'Private _dasaLists As New TASystem.cDasaLists
    'Private _dBase As String
    Private _DasaListP As DataTable

    Public Property StPageNo() As Integer
        Get
            Return _StPageNo
        End Get
        Set(ByVal value As Integer)
            _StPageNo = value
        End Set
    End Property

    Public Property DasaListP() As DataTable
        Get
            Return _DasaListP
        End Get
        Set(value As DataTable)
            _DasaListP = value
        End Set
    End Property

    'Public Property nDasaList() As TASystem.cDasaLists
    '    Get
    '        Return _dasaLists
    '    End Get
    '    Set(ByVal value As TASystem.cDasaLists)
    '        _dasaLists = value
    '    End Set
    'End Property

    'Public Property dBase() As String
    '    Get
    '        Return _dBase
    '    End Get
    '    Set(ByVal value As String)
    '        _dBase = value
    '    End Set
    'End Property

    'Public Property CHeading() As String
    '    Get
    '        Return _CHeading
    '    End Get
    '    Set(ByVal value As String)
    '        _CHeading = value
    '    End Set
    'End Property

    Public Sub Print()
        PrintDoc.DefaultPageSettings.PaperSize.RawKind = 9
        PrintDoc.DefaultPageSettings.Landscape = False
        Try
            PrintDoc.Print()
        Catch pEx As Exception
            MessageBox.Show(pEx.Message)
        End Try
    End Sub

    Public Sub ShowPrintPreviewDialog()
        Dim dlg As New PrintPreviewDialog()
        PrintDoc.DefaultPageSettings.PaperSize.RawKind = 9
        PrintDoc.DefaultPageSettings.Landscape = False
        dlg.Document = PrintDoc
        dlg.PrintPreviewControl.Zoom = 1
        dlg.WindowState = FormWindowState.Maximized
        dlg.ShowDialog()
    End Sub

    Private Sub PrintDoc_BeginPrint(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintEventArgs) Handles PrintDoc.BeginPrint
        oStringFormat = New StringFormat
        oStringFormat.Alignment = StringAlignment.Near
        oStringFormat.LineAlignment = StringAlignment.Center
        oStringFormat.Trimming = StringTrimming.EllipsisCharacter
        nTotalWidth = 0
        nPageNo = StPageNo
        NewPage = True
        nRowPos = 0
        'getdetails()
    End Sub

    Private Sub Printdoc_PrintPage(ByVal sender As Object, ByVal e As System.Drawing.Printing.PrintPageEventArgs) Handles PrintDoc.PrintPage
        DrawDasa(e)
    End Sub

    Private Sub DrawFooter(ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        Dim ssPageNo As String = "Page " + nPageNo.ToString
        ' Left Align - Date/Time
        e.Graphics.DrawString("Printed By True Astrology Software " & Format(Now, "dd/MM/yyyy  HH:mm:ss"), New Font("Arial", 7, FontStyle.Bold), Brushes.Black, 36, e.MarginBounds.Top + e.MarginBounds.Height + 70)
        e.Graphics.DrawString(ssPageNo, New Font("Arial", 7, FontStyle.Regular), Brushes.Black, e.MarginBounds.Right, e.MarginBounds.Top + e.MarginBounds.Height + 60)
    End Sub

    Public Sub DrawDasa(ByVal e As System.Drawing.Printing.PrintPageEventArgs)
        If nPageCount = 0 Then
            nPageNo = StPageNo
        End If
        e.PageSettings.PaperSize.RawKind = 9
        Static nHeight As Int16 = 16
        Dim nRowsPerPage As Int16 'nWidth,
        Dim nTop As Int16 = CShort(e.MarginBounds.Top)
        Dim nLeft As Int16 = CShort(e.MarginBounds.Left) - 30
        Dim nCol As Int16 = 1
        Do While nRowPos < _DasaListP.Rows.Count
            If (nTop + nHeight) >= (e.MarginBounds.Height + e.MarginBounds.Top + 16) AndAlso nCol > 1 Then
                DrawFooter(e)
                NewPage = True
                nPageNo = CShort(nPageNo + 1)
                nPageCount += 1
                e.HasMorePages = True
                nCol = 1
                nLeft = CShort(e.MarginBounds.Left)
                Exit Sub
            Else
                If nTop + nHeight >= e.MarginBounds.Height + e.MarginBounds.Top + 16 AndAlso nCol < 2 Then
                    nLeft = e.MarginBounds.Right - 262
                    nCol += 1
                    nTop = CShort(e.MarginBounds.Top)
                Else
                    If NewPage Then
                        e.Graphics.DrawString("Dashas:", New Font("Arial", 10, FontStyle.Bold), Brushes.Black, 36, 36)
                        'e.Graphics.DrawString(CHeading, New Font("Arial", 10, FontStyle.Regular), Brushes.Black, 36 + e.Graphics.MeasureString("Dashas:", New Font("Arial", 10, FontStyle.Bold)).Width, 36)
                        'e.Graphics.DrawString("Dasha Base: " & dBase, New Font("Arial", 10, FontStyle.Bold), Brushes.Black, 36 + e.Graphics.MeasureString("Dashas:" & CHeading & "   ", New Font("Arial", 10, FontStyle.Bold)).Width, 36)
                        e.Graphics.DrawString("D : Dasha, B : Bhukti, A: Antara, S : Sookshma, P : Prana", New Font("Arial", 10, FontStyle.Bold Or FontStyle.Italic), Brushes.Black, 36, 56)
                        e.Graphics.DrawLine(New Pen(Color.Black, 1), 36, e.MarginBounds.Top, e.PageBounds.Width - 40, e.MarginBounds.Top)
                        e.Graphics.DrawString("D", New Font("Arial", 10, FontStyle.Bold Or FontStyle.Italic), Brushes.Black, nLeft, e.MarginBounds.Top - 16)
                        e.Graphics.DrawString("B", New Font("Arial", 10, FontStyle.Bold Or FontStyle.Italic), Brushes.Black, nLeft + 24, e.MarginBounds.Top - 16)
                        e.Graphics.DrawString("A", New Font("Arial", 10, FontStyle.Bold Or FontStyle.Italic), Brushes.Black, nLeft + 48, e.MarginBounds.Top - 16)
                        e.Graphics.DrawString("S", New Font("Arial", 10, FontStyle.Bold Or FontStyle.Italic), Brushes.Black, nLeft + 72, e.MarginBounds.Top - 16)
                        e.Graphics.DrawString("P", New Font("Arial", 10, FontStyle.Bold Or FontStyle.Italic), Brushes.Black, nLeft + 96, e.MarginBounds.Top - 16)
                        e.Graphics.DrawString("Closing Date & Time", New Font("Arial", 10, FontStyle.Bold Or FontStyle.Italic), Brushes.Black, nLeft + 120, e.MarginBounds.Top - 16)
                        e.Graphics.DrawString("D", New Font("Arial", 10, FontStyle.Bold Or FontStyle.Italic), Brushes.Black, e.MarginBounds.Right - 262, e.MarginBounds.Top - 16)
                        e.Graphics.DrawString("B", New Font("Arial", 10, FontStyle.Bold Or FontStyle.Italic), Brushes.Black, e.MarginBounds.Right - 262 + 24, e.MarginBounds.Top - 16)
                        e.Graphics.DrawString("A", New Font("Arial", 10, FontStyle.Bold Or FontStyle.Italic), Brushes.Black, e.MarginBounds.Right - 262 + 48, e.MarginBounds.Top - 16)
                        e.Graphics.DrawString("S", New Font("Arial", 10, FontStyle.Bold Or FontStyle.Italic), Brushes.Black, e.MarginBounds.Right - 262 + 72, e.MarginBounds.Top - 16)
                        e.Graphics.DrawString("P", New Font("Arial", 10, FontStyle.Bold Or FontStyle.Italic), Brushes.Black, e.MarginBounds.Right - 262 + 96, e.MarginBounds.Top - 16)
                        e.Graphics.DrawString("Closing Date & Time", New Font("Arial", 10, FontStyle.Bold Or FontStyle.Italic), Brushes.Black, e.MarginBounds.Right - 262 + 120, e.MarginBounds.Top - 16)
                        NewPage = False
                    End If
                    e.Graphics.DrawString(_DasaListP(nRowPos).Item("Dasha"), New Font("Arial", 8.5, FontStyle.Regular), Brushes.Black, nLeft, nTop)
                    e.Graphics.DrawString(_DasaListP(nRowPos).Item("Bhukti"), New Font("Arial", 8.5, FontStyle.Regular), Brushes.Black, nLeft + 24, nTop)
                    e.Graphics.DrawString(_DasaListP(nRowPos).Item("Antara"), New Font("Arial", 8.5, FontStyle.Regular), Brushes.Black, nLeft + 48, nTop)
                    e.Graphics.DrawString(_DasaListP(nRowPos).Item("Suk"), New Font("Arial", 8.5, FontStyle.Regular), Brushes.Black, nLeft + 72, nTop)
                    e.Graphics.DrawString(_DasaListP(nRowPos).Item("Pra"), New Font("Arial", 8.5, FontStyle.Regular), Brushes.Black, nLeft + 96, nTop)
                    e.Graphics.DrawString(_DasaListP(nRowPos).Item("Cl_Date"), New Font("Arial", 8.5, FontStyle.Regular), Brushes.Black, nLeft + 120, nTop)
                    nTop += nHeight
                    e.Graphics.DrawLine(Pens.Black, nLeft, nTop - 1, nLeft + 262, nTop - 1)
                    nRowPos = (nRowPos + 1)
                End If
            End If
            nRowsPerPage = (nRowsPerPage + 1)
        Loop
        DrawFooter(e)
        e.HasMorePages = False
    End Sub

    Public Sub New(ByVal sPageNo As Integer)
        StPageNo = sPageNo
        NewPage = True
    End Sub
End Class