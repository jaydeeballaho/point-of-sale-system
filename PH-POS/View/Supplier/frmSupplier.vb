Public Class frmSupplier

    Private Supplier As New Supplier

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim obj As New frmAddSupplier
        If obj.ShowDialog() = DialogResult.OK Then
            Supplier.ViewSupplier(gvSearch)
        End If
    End Sub

    Private Sub gvSupplier_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gvSearch.CellContentClick
        If e.ColumnIndex = 6 Then
            Supplier.SetSupplierDetails(gvSearch.SelectedRows(0).Cells(0).Value)
            If MessageBox.Show("Are you sure you want to delete the Supplier  " + Supplier.SupplierName, "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                If Supplier.DeleteSupplier() = True Then
                    Supplier.ViewSupplier(gvSearch)
                Else
                    MessageBox.Show("Failed to delete. Please try again.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If
        ElseIf e.ColumnIndex = 5 Then
            Supplier.SetSupplierDetails(gvSearch.SelectedRows(0).Cells(0).Value)
            Dim obj As New frmEditSupplier
            obj.supp = Me.Supplier
            If obj.ShowDialog = DialogResult.OK Then
                Supplier.ViewSupplier(gvSearch)
            End If
        End If
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        AllowedOnly(Alpha, txtSearch)
        SentenceCase(txtSearch)
        Supplier.SearchSupplier(txtSearch.Text, gvSearch)
    End Sub

    Private Sub Supplier_Setting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Supplier.ViewSupplier(gvSearch)
    End Sub
End Class