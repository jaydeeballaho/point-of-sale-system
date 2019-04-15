Imports System.Windows.Forms

Public Class frmSearchItemForCashier

    Public pro As Product
    Private stocks As New Stock

    Dim b As String = ""
    Dim c As String = ""
    Dim t As String = ""
    Dim m As String = ""
    Dim u As String = ""

    Private Sub frmStocks_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadView()
        gvSearch.Rows.Clear()
    End Sub
    Private Sub loadView()
        stocks.DiffQty(gvQty, b, c, t, m, u)
        stocks.SearchProductInStocks(gvSearch, b, c, t, m, u, txtSearch.Text)
        stocks.Remaining2(gvSearch, gvQty)
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        AllowedOnly(Alpha, txtSearch)
        SentenceCase(txtSearch)
        If txtSearch.Text.Count > 0 Then
            stocks.DiffQty(gvQty, b, c, t, m, u)
            stocks.SearchProductInStocks(gvSearch, b, c, t, m, u, txtSearch.Text)
            stocks.Remaining2(gvSearch, gvQty)
        Else
            gvSearch.Rows.Clear()
        End If
    End Sub

  
    Private Sub gvSearch_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gvSearch.CellContentClick
        If e.ColumnIndex = 8 Then
            pro.SetProductDetails(gvSearch.SelectedRows(0).Cells(0).Value)
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub
End Class
