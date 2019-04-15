Public Class frmEditProduct
   
    Public product As Product

    Dim alert As String = "No"

    Private Sub frmAddProduct_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        product.LoadBrandToCBO(cboBrand)
        product.LoadClassToCBO(cboClass)
        product.LoadCategoryToCBO(cboCategory)
        product.LoadMadeInToCBO(cboMadeIn)
        product.LoadUnitToCBO(cboUnit)
      
        With product
            txtCode.Text = .ProductCode
            txtPName.Text = .ProductName
            If .Brand <> "" Then
                cboBrand.SelectedIndex = cboBrand.FindString(.Brand)
            End If
            If .Classes <> "" Then
                cboClass.SelectedIndex = cboClass.FindString(.Classes)
            End If
            If .Category <> "" Then
                cboCategory.SelectedIndex = cboCategory.FindString(.Category)
            End If
            If .MadeIn <> "" Then
                cboMadeIn.SelectedIndex = cboMadeIn.FindString(.MadeIn)
            End If
            txtWeight.Text = .SizeWeight
            cboUnit.SelectedIndex = cboUnit.FindString(.Unit)
            txtMax.Value = .Max
            txtDes.Text = .Desc
            txtPrice.Text = .Price
            If .Alert = "Yes" Then
                rbYes.Checked = True
            Else
                rbNo.Checked = True
            End If
            txtAlert.Value = .AlertNo
        End With
    End Sub

    Private Sub bntCancel_Click(sender As Object, e As EventArgs) Handles bntCancel.Click
        Me.Close()
    End Sub

    Private Sub rbNo_CheckedChanged(sender As Object, e As EventArgs) Handles rbNo.CheckedChanged
        If rbNo.Checked = True Then
            txtAlert.Enabled = False
            alert = "No"
        Else
            txtAlert.Enabled = True
        End If
    End Sub

    Private Sub rbYes_CheckedChanged(sender As Object, e As EventArgs) Handles rbYes.CheckedChanged
        If rbYes.Checked = True Then
            txtAlert.Enabled = True
            alert = "Yes"
        Else
            txtAlert.Enabled = False
        End If
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If IsTextBoxEmpty(txtPName, txtCode, txtPrice) = True Then
            MessageBox.Show("Product Code, Name and Unit Price are required.", "Message", _
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf cboUnit.SelectedIndex < 0 Then
            MessageBox.Show("Product Unit is required.", "Message", _
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            With product
                .ProductCode = txtCode.Text
                .ProductName = txtPName.Text
                .Brand = cboBrand.Text
                .Classes = cboClass.Text
                .Category = cboCategory.Text
                .MadeIn = cboMadeIn.Text
                .SizeWeight = txtWeight.Text
                .Unit = cboUnit.Text
                .Max = txtMax.Value
                .Desc = txtDes.Text
                .Alert = alert
                .AlertNo = txtAlert.Value
                .Price = txtPrice.Text
                If .EditProduct() = True Then
                    MessageBox.Show("Product successfully saved.", "Message", _
                          MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()
                Else
                    MessageBox.Show("Failed saving product.", "Message", _
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End With
        End If
    End Sub

    Private Sub txtCode_TextChanged(sender As Object, e As EventArgs) Handles txtCode.TextChanged
        AllowedOnly(Alpha, txtCode)
    End Sub

    Private Sub txtPName_TextChanged(sender As Object, e As EventArgs) Handles txtPName.TextChanged
        AllowedOnly(Alpha, txtPName)
        SentenceCase(txtPName)
    End Sub

    Private Sub txtWeight_TextChanged(sender As Object, e As EventArgs) Handles txtWeight.TextChanged
        AllowedOnly(Alpha, txtWeight)
    End Sub

    Private Sub txtDes_TextChanged(sender As Object, e As EventArgs) Handles txtDes.TextChanged
        AllowedOnly(Alpha, txtDes)
    End Sub

    Private Sub btnBrand_Click(sender As Object, e As EventArgs) Handles btnBrand.Click
        Dim obj As New frmAddBrand
        obj.product = Me.product
        If obj.ShowDialog() = Windows.Forms.DialogResult.OK Then
            cboBrand.Items.Add(product.Brand)
            cboBrand.Sorted = True
            cboBrand.SelectedIndex = cboBrand.FindString(product.Brand)
        End If
    End Sub

    Private Sub btnClass_Click(sender As Object, e As EventArgs) Handles btnClass.Click
        Dim obj As New frmAddClass
        obj.product = Me.product
        If obj.ShowDialog() = Windows.Forms.DialogResult.OK Then
            cboClass.Items.Add(product.Classes)
            cboClass.Sorted = True
            cboClass.SelectedIndex = cboClass.FindString(product.Classes)
        End If
    End Sub

    Private Sub btnCategory_Click(sender As Object, e As EventArgs) Handles btnCategory.Click
        Dim obj As New frmAddCategory
        obj.product = Me.product
        If obj.ShowDialog() = Windows.Forms.DialogResult.OK Then
            cboCategory.Items.Add(product.Category)
            cboCategory.Sorted = True
            cboCategory.SelectedIndex = cboCategory.FindString(product.Category)
        End If
    End Sub

    Private Sub btnMade_Click(sender As Object, e As EventArgs) Handles btnMade.Click
        Dim obj As New frmAddMade
        obj.product = Me.product
        If obj.ShowDialog() = Windows.Forms.DialogResult.OK Then
            cboMadeIn.Items.Add(product.MadeIn)
            cboMadeIn.Sorted = True
            cboMadeIn.SelectedIndex = cboMadeIn.FindString(product.MadeIn)
        End If
    End Sub

    Private Sub btnUnit_Click(sender As Object, e As EventArgs) Handles btnUnit.Click
        Dim obj As New frmAddUnit
        obj.product = Me.product
        If obj.ShowDialog() = Windows.Forms.DialogResult.OK Then
            cboUnit.Items.Add(product.Unit)
            cboUnit.Sorted = True
            cboUnit.SelectedIndex = cboUnit.FindString(product.Unit)
        End If
    End Sub

    Private Sub txtPrice_TextChanged(sender As Object, e As EventArgs) Handles txtPrice.TextChanged
        AllowedOnly(NumberWDot, txtPrice)
        CheckforDoubleDot(txtPrice)
    End Sub

    Private Sub btnGenCode_Click(sender As Object, e As EventArgs) Handles btnGenCode.Click
        txtCode.Text = product.GenerateGTIN()
    End Sub
End Class