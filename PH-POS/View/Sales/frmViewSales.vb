Imports System.Windows.Forms
Imports System.Globalization

Public Class frmViewSales

    Private order As New Order
    Private acc As New Accounts

    Private Sub frmViewSales_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        acc.LoadAllCashierToCBO(cboCashier)
        cboCashier.SelectedIndex = 0
        order.ViewSales(gvSearch, dtpFrom.Value, dtpTo.Value, c)
    End Sub

    Private Sub dtpFrom_ValueChanged(sender As Object, e As EventArgs) Handles dtpFrom.ValueChanged
        order.ViewSales(gvSearch, dtpFrom.Value, dtpTo.Value, c)
    End Sub

    Private Sub dtpTo_ValueChanged(sender As Object, e As EventArgs) Handles dtpTo.ValueChanged
        order.ViewSales(gvSearch, dtpFrom.Value, dtpTo.Value, c)
    End Sub
    Sub Calculate()
        Dim d As Decimal = 0
        For Each r As DataGridViewRow In gvSearch.Rows
            d = d + r.Cells(7).Value
        Next
        txtTotal.Text = d.ToString("N", CultureInfo.InvariantCulture)
    End Sub
    Private Sub gvSearch_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gvSearch.CellContentClick

    End Sub

    Private Sub gvSearch_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles gvSearch.RowsAdded
        Calculate()
    End Sub

    Private Sub gvSearch_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles gvSearch.RowsRemoved
        Calculate()
    End Sub
    Dim c As String = ""
    Private Sub cboCashier_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCashier.SelectedIndexChanged
        If cboCashier.Text = "All" Then
            c = ""
        Else
            c = cboCashier.Text
        End If
        order.ViewSales(gvSearch, dtpFrom.Value, dtpTo.Value, c)
    End Sub
End Class
