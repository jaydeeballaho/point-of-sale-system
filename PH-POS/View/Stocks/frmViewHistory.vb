Public Class frmViewHistory

    Private stock As New Stock
    Public product As Product
    Private section As New Section

    Dim p As String = ""
    Dim d As Boolean = False
    Dim d2 As Boolean = False
    Dim s As String = ""
    Private Sub frmViewHistory_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        section.LoadAllSectionToCBO(cboSection)
        cboSection.SelectedIndex = cboSection.FindString("All")
        txtSearch.Text = product.ProductName
        txtSearch2.Text = product.ProductName
        p = product.ProductCode
        stock.ViewStocksInHistory(gvSearch, s, p, d, dtpFrom.Value, dtpTo.Value)
        stock.ViewStockOutHistory(gvSearch2, p, d2, dtpFrom2.Value, dtpTo2.Value)
    End Sub

    Private Sub cboSection_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSection.SelectedIndexChanged
        If cboSection.Text = "All" Then
            s = ""
        Else
            s = cboSection.Text
        End If
        stock.ViewStocksInHistory(gvSearch, s, p, d, dtpFrom.Value, dtpTo.Value)
    End Sub

    Private Sub cbAll_CheckedChanged(sender As Object, e As EventArgs) Handles cbAll.CheckedChanged
        If cbAll.Checked = True Then
            p = ""
            stock.ViewStocksInHistory(gvSearch, s, p, d, dtpFrom.Value, dtpTo.Value)
            txtSearch.Enabled = False
            txtSearch.Clear()
        Else
            p = product.ProductCode
            stock.ViewStocksInHistory(gvSearch, s, p, d, dtpFrom.Value, dtpTo.Value)
            txtSearch.Enabled = False
            txtSearch.Text = product.ProductName
        End If
    End Sub

    Private Sub cbInclude_CheckedChanged(sender As Object, e As EventArgs) Handles cbInclude.CheckedChanged
        If cbInclude.Checked = True Then
            d = True
            dtpFrom.Enabled = True
            dtpTo.Enabled = True
        Else
            d = False
            dtpFrom.Enabled = False
            dtpTo.Enabled = False
        End If
        stock.ViewStocksInHistory(gvSearch, s, p, d, dtpFrom.Value, dtpTo.Value)
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        AllowedOnly(Alpha, txtSearch)
        'p = txtSearch.Text
        'stock.ViewStocksInHistory(gvSearch, s, p, d, dtpFrom.Value, dtpTo.Value)
    End Sub

    Private Sub dtpFrom_ValueChanged(sender As Object, e As EventArgs) Handles dtpFrom.ValueChanged
        stock.ViewStocksInHistory(gvSearch, s, p, d, dtpFrom.Value, dtpTo.Value)
    End Sub

    Private Sub dtpTo_ValueChanged(sender As Object, e As EventArgs) Handles dtpTo.ValueChanged
        stock.ViewStocksInHistory(gvSearch, s, p, d, dtpFrom.Value, dtpTo.Value)
    End Sub

    Private Sub gvSearch_SelectionChanged(sender As Object, e As EventArgs) Handles gvSearch.SelectionChanged
        gvSearch.ClearSelection()
    End Sub

    Private Sub CheckBox1_CheckedChanged(sender As Object, e As EventArgs) Handles cbAll2.CheckedChanged
        If cbAll2.Checked = True Then
            p = ""
            stock.ViewStockOutHistory(gvSearch2, p, d2, dtpFrom2.Value, dtpTo2.Value)
            txtSearch2.Enabled = False
            txtSearch2.Clear()
        Else
            p = product.ProductCode
            stock.ViewStockOutHistory(gvSearch2, p, d2, dtpFrom2.Value, dtpTo2.Value)
            txtSearch2.Enabled = False
            txtSearch2.Text = product.ProductName
        End If
    End Sub

    Private Sub cbInclude2_CheckedChanged(sender As Object, e As EventArgs) Handles cbInclude2.CheckedChanged
        If cbInclude2.Checked = True Then
            d2 = True
            dtpFrom2.Enabled = True
            dtpTo2.Enabled = True
        Else
            d2 = False
            dtpFrom2.Enabled = False
            dtpTo2.Enabled = False
        End If
        stock.ViewStockOutHistory(gvSearch2, p, d2, dtpFrom2.Value, dtpTo2.Value)
    End Sub

    Private Sub dtpFrom2_ValueChanged(sender As Object, e As EventArgs) Handles dtpFrom2.ValueChanged
        stock.ViewStockOutHistory(gvSearch2, p, d2, dtpFrom2.Value, dtpTo2.Value)
    End Sub

    Private Sub dtpTo2_ValueChanged(sender As Object, e As EventArgs) Handles dtpTo2.ValueChanged
        stock.ViewStockOutHistory(gvSearch2, p, d2, dtpFrom2.Value, dtpTo2.Value)
    End Sub
End Class