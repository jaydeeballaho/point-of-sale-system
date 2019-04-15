Public Class frmStocks

    Private product As New Product
    Private section As New Section
    Private stocks As New Stock

    Dim u As String
    Dim b As String
    Dim c As String
    Dim t As String
    Dim m As String

    Private Sub frmStocks_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loadView()
    End Sub
    Private Sub loadView()
        product.LoadAllUnitToCBO(cboUnit)
        cboUnit.SelectedIndex = cboUnit.FindString("All")

        product.LoadAllBrandToCBO(cboBrand)
        cboBrand.SelectedIndex = cboBrand.FindString("All")

        product.LoadAllClassToCBO(cboClass)
        cboClass.SelectedIndex = cboClass.FindString("All")

        product.LoadAllCategoryToCBO(cboCategory)
        cboCategory.SelectedIndex = cboCategory.FindString("All")

        product.LoadAllMadeInToCBO(cboMadeIn)
        cboMadeIn.SelectedIndex = cboMadeIn.FindString("All")

        stocks.DiffQty(gvQty, b, c, t, m, u)
        stocks.ViewStocks(gvSearch, b, c, t, m, u)
        stocks.Remaining(gvSearch, gvQty)

    End Sub

    Private Sub cboBrand_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboBrand.SelectedIndexChanged
        If cboBrand.Text = "All" Then
            b = ""
        Else
            b = cboBrand.Text
        End If
        stocks.DiffQty(gvQty, b, c, t, m, u)
        stocks.ViewStocks(gvSearch, b, c, t, m, u)
        stocks.Remaining(gvSearch, gvQty)
    End Sub

    Private Sub cboClass_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboClass.SelectedIndexChanged
        If cboClass.Text = "All" Then
            c = ""
        Else
            c = cboClass.Text
        End If
        stocks.DiffQty(gvQty, b, c, t, m, u)
        stocks.ViewStocks(gvSearch, b, c, t, m, u)
        stocks.Remaining(gvSearch, gvQty)
    End Sub

    Private Sub cboCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCategory.SelectedIndexChanged
        If cboCategory.Text = "All" Then
            t = ""
        Else
            t = cboCategory.Text
        End If
        stocks.DiffQty(gvQty, b, c, t, m, u)
        stocks.ViewStocks(gvSearch, b, c, t, m, u)
        stocks.Remaining(gvSearch, gvQty)
    End Sub

    Private Sub cboMadeIn_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboMadeIn.SelectedIndexChanged
        If cboMadeIn.Text = "All" Then
            m = ""
        Else
            m = cboMadeIn.Text
        End If
        stocks.DiffQty(gvQty, b, c, t, m, u)
        stocks.ViewStocks(gvSearch, b, c, t, m, u)
        stocks.Remaining(gvSearch, gvQty)
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        AllowedOnly(Alpha, txtSearch)
        SentenceCase(txtSearch)
        stocks.DiffQty(gvQty, b, c, t, m, u)
        stocks.SearchStocks(gvSearch, b, c, t, m, u, txtSearch.Text)
        stocks.Remaining(gvSearch, gvQty)
    End Sub

    Private Sub btnReset_Click(sender As Object, e As EventArgs) Handles btnReset.Click
        loadView()
    End Sub

    Private Sub cboUnit_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboUnit.SelectedIndexChanged
        If cboUnit.Text = "All" Then
            u = ""
        Else
            u = cboUnit.Text
        End If
        stocks.DiffQty(gvQty, b, c, t, m, u)
        stocks.ViewStocks(gvSearch, b, c, t, m, u)
        stocks.Remaining(gvSearch, gvQty)
    End Sub

    Private Sub gvSearch_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gvSearch.CellContentClick
        If e.ColumnIndex = 12 Then
            Dim obj As New frmAddStockIn
            Me.product.SetProductDetails(gvSearch.SelectedRows(0).Cells(0).Value)
            obj.qty = gvSearch.SelectedRows(0).Cells(6).Value
            obj.product = Me.product
            If obj.ShowDialog() = Windows.Forms.DialogResult.OK Then
                loadView()
            End If
        ElseIf e.ColumnIndex = 13 Then
            Dim obj As New frmAddStockOut
            Me.product.SetProductDetails(gvSearch.SelectedRows(0).Cells(0).Value)
            obj.qty = gvSearch.SelectedRows(0).Cells(6).Value
            obj.product = Me.product
            If obj.ShowDialog() = Windows.Forms.DialogResult.OK Then
                loadView()
            End If
        ElseIf e.ColumnIndex = 14 Then
            Dim obj As New frmViewHistory
            Me.product.SetProductDetails(gvSearch.SelectedRows(0).Cells(0).Value)
            obj.product = Me.product
            If obj.ShowDialog() = Windows.Forms.DialogResult.OK Then
                loadView()
            End If
        End If
    End Sub
End Class