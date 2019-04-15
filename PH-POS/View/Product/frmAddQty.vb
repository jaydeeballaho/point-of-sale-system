Public Class frmAddQty

    Public order As Order

    Private Sub bntCancel_Click_1(sender As Object, e As EventArgs) Handles bntCancel.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        order.Qty = txtQty.Value
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub frmAddQty_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        txtQty.Value = order.Qty
    End Sub
End Class