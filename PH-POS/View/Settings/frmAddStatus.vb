Public Class frmAddStatus
   
    Public stock As Stock

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If IsTextBoxEmpty(txtName) = True Then
            MessageBox.Show("No Product Status.", "Message", _
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            stock.ProductStatus = txtName.Text
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub bntCancel_Click(sender As Object, e As EventArgs) Handles bntCancel.Click
        Me.Close()
    End Sub

    Private Sub txtName_TextChanged(sender As Object, e As EventArgs) Handles txtName.TextChanged
        AllowedOnly(Alpha, txtName)
        SentenceCase(txtName)
    End Sub
End Class