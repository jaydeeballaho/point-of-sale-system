Public Class frmAddStockIn

    Private stock As New Stock
    Public product As Product
    Public qty As Integer = 0
    Private section As New Section

    Dim isExpiry As String = ""

    Private Sub bntCancel_Click(sender As Object, e As EventArgs) Handles bntCancel.Click
        Me.Close()
    End Sub

    Private Sub frmAddStockIn_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        section.LoadSectionToCBO(cboSection)
        stock.LoadStatusToCBO(cboStatus)
        dtpDoe.MinDate = frmMain.dtServer
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
            txtQty.Maximum = .Max - qty
        End With
    End Sub

    Private Sub btnStatus_Click(sender As Object, e As EventArgs) Handles btnStatus.Click
        Dim obj As New frmAddStatus
        obj.stock = Me.stock
        If obj.ShowDialog() = Windows.Forms.DialogResult.OK Then
            cboStatus.Items.Add(stock.ProductStatus)
            cboStatus.Sorted = True
            cboStatus.SelectedIndex = cboStatus.FindString(stock.ProductStatus)
        End If
    End Sub

    Private Sub cbExpire_CheckedChanged(sender As Object, e As EventArgs) Handles cbExpire.CheckedChanged
        If cbExpire.Checked = True Then
            dtpDoe.Enabled = True
            isExpiry = "Yes"
        Else
            isExpiry = "No"
            dtpDoe.Enabled = False
        End If
    End Sub

    Private Sub txtPrice_TextChanged(sender As Object, e As EventArgs) Handles txtPrice.TextChanged
        AllowedOnly(NumberWDot, txtPrice)
        CheckforDoubleDot(txtPrice)
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If cboSection.SelectedIndex < 0 Then
            MessageBox.Show("Section is required.", "Message", _
                           MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf txtQty.Value < 0 Then
            MessageBox.Show("Invalid Stock Quantity.", "Message", _
                           MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            With stock
                .ProductID = product.ProductID
                .SectionID = section.SectionArry(cboSection.SelectedIndex)
                .DOS = txtDos.Text
                .Price = txtPrice.Text
                .QTY = txtQty.Value
                .IsExpiry = isExpiry
                .DOE = dtpDoe.Value
                .ProductStatus = cboStatus.Text
                .By = txtBy.Text
                If .AddStocks() = True Then
                    MessageBox.Show("Stocks successfully added.", "Message", _
                          MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()
                Else
                    MessageBox.Show("Failed adding stocks.", "Message", _
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End With
        End If
    End Sub
End Class