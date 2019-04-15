Imports System.Globalization

Public Class frmSearchProduct

    Private product As New Product
    Private section As New Section
    Private stocks As New Stock
    Private order As New Order

    Dim b As String = ""
    Dim c As String = ""
    Dim t As String = ""
    Dim m As String = ""
    Dim u As String = ""

    Private Sub frmSearchProduct_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F1 Then
            bntCancel.PerformClick()
        ElseIf e.KeyCode = Keys.Escape Then
            btnClose.PerformClick()
        End If
    End Sub

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

    Sub ReCount()
        Dim d As Decimal = 0
        For Each r As DataGridViewRow In gvOrder.Rows
            r.Cells(1).Value = r.Index + 1
            r.Cells(7).Value = Decimal.Parse(r.Cells(5).Value * r.Cells(6).Value).ToString("N", CultureInfo.InvariantCulture)
            d = d + (r.Cells(7).Value)
            gvOrder.ClearSelection()
            gvSearch.ClearSelection()
        Next
        txtTotal.Text = d.ToString("N", CultureInfo.InvariantCulture)
    End Sub
    Private Sub gvSearch_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gvSearch.CellContentClick
        If e.ColumnIndex = 8 Then
            Dim obj As New frmAddQty
            Me.order.Qty = 0
            obj.order = Me.order
            obj.txtQty.Maximum = gvSearch.SelectedRows(0).Cells(6).Value
            If obj.ShowDialog() = Windows.Forms.DialogResult.OK And order.Qty > 0 Then
                For Each r As DataGridViewRow In gvOrder.Rows
                    If r.Cells(0).Value = gvSearch.SelectedRows(0).Cells(0).Value Then
                        r.Cells(6).Value = r.Cells(6).Value + order.Qty
                        ReCount()
                        Exit Sub
                    End If
                Next
                Dim d As Decimal = 0
                d = Decimal.Parse(gvSearch.SelectedRows(0).Cells(5).Value * order.Qty)
                gvOrder.Rows.Add(gvSearch.SelectedRows(0).Cells(0).Value, gvSearch.SelectedRows(0).Cells(1).Value, _
                                 gvSearch.SelectedRows(0).Cells(2).Value, gvSearch.SelectedRows(0).Cells(3).Value, _
                                 gvSearch.SelectedRows(0).Cells(4).Value, gvSearch.SelectedRows(0).Cells(5).Value, _
                                 order.Qty, d.ToString("N", CultureInfo.InvariantCulture), "Edit Item", "Remove")
                ReCount()
            End If
        ElseIf e.ColumnIndex = 9 Then
            Dim obj As New frmInSection
            product.SetProductDetails(gvSearch.SelectedRows(0).Cells(0).Value)
            obj.product = Me.product
            If obj.ShowDialog() = Windows.Forms.DialogResult.OK Then

            End If
        End If
    End Sub

    Private Sub gvOrder_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles gvOrder.RowsAdded
        ReCount()
    End Sub

    Private Sub gvOrder_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles gvOrder.RowsRemoved
        ReCount()
    End Sub

    Private Sub bntCancel_Click(sender As Object, e As EventArgs) Handles bntCancel.Click
        If MessageBox.Show("Are you sure you want to cancel?", "", MessageBoxButtons.YesNo, MessageBoxIcon.Question) _
            = Windows.Forms.DialogResult.Yes Then
            txtSearch.Clear()
            gvOrder.Rows.Clear()
            txtSearch.Focus()
        End If
    End Sub

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub gvOrder_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gvOrder.CellContentClick
        If e.ColumnIndex = 8 Then
            Dim obj As New frmAddQty
            Me.order.Qty = gvOrder.SelectedRows(0).Cells(6).Value
            obj.order = Me.order
            '  obj.txtQty.Maximum = gvSearch.SelectedRows(0).Cells(6).Value
            If obj.ShowDialog() = Windows.Forms.DialogResult.OK Then
                If order.Qty = 0 Then
                    gvOrder.Rows.RemoveAt(gvOrder.SelectedRows(0).Index)
                Else
                    gvOrder.SelectedRows(0).Cells(6).Value = order.Qty
                End If
                ReCount()
            End If
        ElseIf e.ColumnIndex = 9 Then
            gvOrder.Rows.RemoveAt(gvOrder.SelectedRows(0).Index)
            ReCount()
        End If
    End Sub
End Class