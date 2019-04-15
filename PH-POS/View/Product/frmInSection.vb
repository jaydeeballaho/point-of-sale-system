Imports System.Windows.Forms

Public Class frmInSection

    Public product As Product
    Private section As New Section

    Private Sub frmInSection_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        section.ViewStocksInHistory(gvSearch, product.ProductID)
    End Sub

    Private Sub gvSearch_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gvSearch.CellContentClick

    End Sub

    Private Sub gvSearch_SelectionChanged(sender As Object, e As EventArgs) Handles gvSearch.SelectionChanged
        gvSearch.ClearSelection()
    End Sub
End Class
