Imports System.Data.SqlClient
Imports Dapper
Imports DapperExtensions

Public Class ManageHistoryAccount
    'Dim connstr = "data source=NITESH-PC;initial catalog=ASTROLOGYSOFTWARE_DB;integrated security=True;"
    'Dim connstr = "data source=WIN-KSTUPT6CJRC;initial catalog=ASTROLOGYSOFTWARE_DB;integrated security=True;multipleactiveresultsets=True;"
    Shared connstr = "data source=49.50.103.132;initial catalog=ASTROLOGYSOFTWARE_DB;integrated security=False;multipleactiveresultsets=True;User Id=sa;password=pSI)TA1t0K[);"

    Public Shared Function UpdateHistoryAccount()

        Using cn As New SqlConnection(connstr)
            cn.Open()

            Dim GetAccount = cn.GetList(Of ACCOUNT)
            Dim GetStmnetSeq = cn.GetList(Of ADBADMIN).FirstOrDefault(Function(s) s.ADBADMINUSERID.Trim = "STMNTSEQ")
            Dim GetAccountTXN = cn.GetList(Of ACCOUNT_TXN)
            Dim month = ""
            'YEAR
            Dim year = Date.Now.Year.ToString()
            If (Date.Now.Month < 10) Then
                month = "0" + Date.Now.Month + 1.ToString
            Else
                month = Date.Now.Month + 1.ToString
            End If
            For Each account As ACCOUNT In GetAccount
                Dim toAdd = New ACCOUNT_HIST
                toAdd.HISACCOUNTUSERID = account.ACCOUNTUSERID
                toAdd.HISACCOUNT = account.ACCOUNT
                toAdd.HISACCOUNTCCY = account.ACCOUNTCCY
                toAdd.HISACCTSTMTDATE = Date.UtcNow

                toAdd.ACCOUNTBAL = account.ACCOUNTBAL
                toAdd.ACCOUNTDEBIT = account.ACCOUNTDEBIT
                toAdd.ACCOUNTCREDIT = account.ACCOUNTCREDIT
                toAdd.ACCOUNTSTMTID = GetStmnetSeq.STMNTSEQ
                INSERT_INTO_ACCOUNT_HIST(toAdd)

            Next
            For Each account_txn As ACCOUNT_TXN In GetAccountTXN
                Dim toAdd = New HACCOUNT_TXN

                toAdd.HTXNACCOUNTUSERID = account_txn.TXNACCOUNTUSERID
                toAdd.HTXNACCOUNT = account_txn.TXNACCOUNT
                toAdd.HTXNACCOUNTCCY = account_txn.TXNACCOUNTCCY
                toAdd.HTXNTYPE = account_txn.TXNTYPE
                toAdd.HTAXCODE = account_txn.TAXCODE
                toAdd.HTXNCODE = account_txn.TXNCODE
                toAdd.HTXNDATE = account_txn.TXNDATE
                toAdd.HTXNTIME = account_txn.TXNTIME
                toAdd.HTXNAMOUNT = account_txn.TXNAMOUNT
                toAdd.HTXNIREF = account_txn.TXNIREF
                toAdd.HTXNEREF = account_txn.TXNEREF
                toAdd.HTXNACCOUNTSTMTSEQ = GetStmnetSeq.STMNTSEQ
                toAdd.HTXNTAXCODE = account_txn.TXNTAXCODE
                toAdd.NARRATION = account_txn.NARRATION
                toAdd.BATCHID = account_txn.BATCHID
                toAdd.TRANSACTIONID = account_txn.TRANSACTIONID

                'cn.Insert(Of HACCOUNT_TXN)(toAdd)
                INSERT_INTO_HACCOUT_TXN(toAdd)
                'cn.Delete(Of ACCOUNT_TXN)(account_txn)
                DELETE_FROM_ACCOUNT_TXN(account_txn)
            Next
            Dim newyear = Convert.ToInt32(year.Substring(2, 2))
            GetStmnetSeq.STMNTSEQ = month + newyear
            cn.Update(Of ADBADMIN)(GetStmnetSeq)
            cn.Close()
        End Using

        Return Nothing

    End Function

    Shared Sub INSERT_INTO_ACCOUNT_HIST(ByVal ACCOUNTHIST As ACCOUNT_HIST)
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        con.ConnectionString = connstr
        con.Open()
        cmd.Connection = con
        cmd.CommandText = $"INSERT INTO ACCOUNT_HIST VALUES('" + ACCOUNTHIST.HISACCOUNTUSERID + "', '" + ACCOUNTHIST.HISACCOUNT + "', '" + ACCOUNTHIST.HISACCOUNTCCY + "', '" + ACCOUNTHIST.HISACCTSTMTDATE.ToString + "', '" + ACCOUNTHIST.ACCOUNTBAL.ToString + "', '" + ACCOUNTHIST.ACCOUNTCREDIT.ToString + "', '" + ACCOUNTHIST.ACCOUNTDEBIT.ToString + "', '" + ACCOUNTHIST.ACCOUNTSTMTID + "', '" + ACCOUNTHIST.TRANSACTIONID.ToString + "', '" + ACCOUNTHIST.EXTREF + "')"
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub
    Shared Sub INSERT_INTO_HACCOUT_TXN(ByVal HACCOUNTTXT As HACCOUNT_TXN)
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        con.ConnectionString = connstr
        con.Open()
        cmd.Connection = con
        cmd.CommandText = $"INSERT INTO HACCOUNT_TXN VALUES('" + HACCOUNTTXT.HTXNACCOUNTUSERID + "', '" + HACCOUNTTXT.HTXNACCOUNT + "', '" + HACCOUNTTXT.HTXNACCOUNTCCY + "', '" + HACCOUNTTXT.HTXNTYPE + "', '" + HACCOUNTTXT.HTAXCODE + "', " + HACCOUNTTXT.HTXNCODE.ToString + ", '" + HACCOUNTTXT.HTXNDATE.ToString + "', '" + HACCOUNTTXT.HTXNTIME + "', '" + HACCOUNTTXT.HTXNAMOUNT.ToString + "', '" + HACCOUNTTXT.HTXNIREF.ToString + "', '" + HACCOUNTTXT.HTXNEREF + "', '" + HACCOUNTTXT.HTXNACCOUNTSTMTSEQ + "', '" + HACCOUNTTXT.HTXNTAXCODE + "', '" + HACCOUNTTXT.TRANSACTIONID.ToString + "', '" + HACCOUNTTXT.BATCHID.ToString + "', '" + HACCOUNTTXT.NARRATION + "', '" + HACCOUNTTXT.TXNREVERSED + "')"
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub
    Shared Sub DELETE_FROM_ACCOUNT_TXN(ByVal ACCOUNTTXN As ACCOUNT_TXN)
        Dim con As New SqlConnection
        Dim cmd As New SqlCommand
        con.ConnectionString = connstr
        con.Open()
        cmd.Connection = con
        cmd.CommandText = "DELETE FROM ACCOUNT_TXN WHERE TXNACCOUNTUSERID = '" + ACCOUNTTXN.TXNACCOUNTUSERID + "' AND TXNACCOUNT = '" + ACCOUNTTXN.TXNACCOUNT + "' AND ID = '" + ACCOUNTTXN.ID.ToString + "';"
        cmd.ExecuteNonQuery()
        con.Close()
    End Sub
End Class
Public Class ACCOUNT
    Public Property ACCOUNTUSERID As String
    Public Property ACCOUNT As String
    Public Property ACCOUNTCCY As String
    Public Property ACCOUNTBAL As Decimal
    Public Property ACCOUNTCREDIT As Decimal
    Public Property ACCOUNTDEBIT As Decimal
    Public Property ACCOUNTSTMTID As Decimal


End Class

Public Class ACCOUNT_HIST
    Public Property HISACCOUNTUSERID As String
    Public Property HISACCOUNT As String
    Public Property HISACCOUNTCCY As String
    Public Property HISACCTSTMTDATE As Date
    Public Property ACCOUNTBAL As Decimal
    Public Property ACCOUNTCREDIT As Decimal
    Public Property ACCOUNTDEBIT As Decimal
    Public Property ACCOUNTSTMTID As String
    Public Property TRANSACTIONID As Integer
    Public Property EXTREF As String

End Class

Public Class HACCOUNT_TXN
    Public Property HTXNACCOUNTUSERID As String
    Public Property HTXNACCOUNT As String
    Public Property HTXNACCOUNTCCY As String
    Public Property HTXNTYPE As String
    Public Property HTAXCODE As String
    Public Property HTXNCODE As Decimal
    Public Property HTXNDATE As Date
    Public Property HTXNTIME As String
    Public Property HTXNAMOUNT As Decimal
    Public Property HTXNIREF As Decimal
    Public Property HTXNEREF As String
    Public Property HTXNACCOUNTSTMTSEQ As String
    Public Property HTXNTAXCODE As String
    Public Property TRANSACTIONID As Decimal
    Public Property BATCHID As Decimal
    Public Property NARRATION As String
    Public Property TXNREVERSED As String
    Public Property ID As Integer
End Class

Public Class ACCOUNT_TXN
    Public Property TXNACCOUNTUSERID As String
    Public Property TXNACCOUNT As String
    Public Property TXNACCOUNTCCY As String
    Public Property TXNTYPE As String
    Public Property TAXCODE As String
    Public Property TXNCODE As Decimal
    Public Property TXNDATE As Date
    Public Property TXNTIME As String
    Public Property TXNAMOUNT As Decimal
    Public Property TXNIREF As Decimal
    Public Property TXNEREF As String
    Public Property TXNACCOUNTSTMTSEQ As String
    Public Property TXNTAXCODE As String
    Public Property TXNHID As String
    Public Property TXNRQID As String
    Public Property TXNREVERSED As String
    Public Property EXTREF As String
    Public Property ID As Integer
    Public Property NARRATION As String
    Public Property BATCHID As Decimal
    Public Property TRANSACTIONID As Decimal

End Class
Public Class ADBADMIN
    Public Property ADBADMINUSERID As String
    Public Property ADBADMINPW As String
    Public Property ADBACCOUNT As Nullable(Of Decimal)
    Public Property ADBUSERUNIQUE As Nullable(Of Decimal)
    Public Property STMNTSEQ As String
    Public Property TRANSACTIONID As Nullable(Of Decimal)
    Public Property BATCHID As Nullable(Of Decimal)
    Public Property ChargeFileLink As String
    Public Property TCLink As String
End Class