Public Class frmEditSupplier

    Public supp As Supplier

    Private Sub txtName_TextChanged(sender As Object, e As EventArgs) Handles txtName.TextChanged
        AllowedOnly(Alpha, txtName)
        SentenceCase(txtName)
    End Sub

    Private Sub txtAddress_TextChanged(sender As Object, e As EventArgs) Handles txtAddress.TextChanged
        AllowedOnly(Alpha, txtAddress)
        SentenceCase(txtAddress)
    End Sub

    Private Sub bntCancel_Click(sender As Object, e As EventArgs) Handles bntCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If IsTextBoxEmpty(txtName, txtAddress) = True Then
            MessageBox.Show("Supplier name, address are required.", "Message", _
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            With supp
                .SupplierName = txtName.Text
                .SupplierAddress = txtAddress.Text
                .Telephone = txtNo.Text
                If .EditSupplier() = True Then
                    MessageBox.Show("Supplier successfully saved.", "Message", _
                          MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()
                Else
                    MessageBox.Show("Failed saving supplier.", "Message", _
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End With
        End If
    End Sub

    Private Sub frmEditSupplier_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtName.Text = supp.SupplierName
        txtAddress.Text = supp.SupplierAddress
        txtNo.Text = supp.Telephone
    End Sub
End Class