Public Class frmAddStockOut
    
    Private stock As New Stock
    Public product As Product
    Public qty As Double = 0

    Private Sub frmAddStockIn_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With product
            txtCode.Text = .ProductCode
            txtPName.Text = .ProductName
            txtBrand.Text = .Brand
            txtClass.Text = .Classes
            txtCategory.Text = .Category
            txtMade.Text = .MadeIn
            txtSize.Text = .SizeWeight
            txtUnit.Text = .Unit
            txtMax.Text = .Max
            txtDes.Text = .Desc
            txtPrice.Text = .Price
            txtCurrent.Text = qty
            txtDos.Text = frmMain.dtServer.ToShortDateString()
            txtBy.Text = frmMain.fullname
            txtQty.Maximum = qty
        End With
    End Sub

    Private Sub txtReason_TextChanged(sender As Object, e As EventArgs) Handles txtReason.TextChanged
        AllowedOnly(Alpha, txtReason)
    End Sub

    Private Sub bntCancel_Click_1(sender As Object, e As EventArgs) Handles bntCancel.Click
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If txtQty.Value < 0 Then
            MessageBox.Show("Invalid Stock Quantity.", "Message", _
                           MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            With stock
                .ProductID = product.ProductID
                .QTY = txtQty.Value
                .Reason = txtReason.Text
                .DOS = txtDos.Text
                .By = txtBy.Text
                .StockID = 0
                .Price = txtPrice.Text
                If .AddStockOut() = True Then
                    MessageBox.Show("Product successfully stock-out.", "Message", _
                          MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()
                Else
                    MessageBox.Show("Failed stocking-out.", "Message", _
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End With
        End If
    End Sub
End Class