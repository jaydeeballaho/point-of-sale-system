Public Class frmProduct

    Private product As New Product

    Dim b As String
    Dim c As String
    Dim t As String
    Dim m As String
    Dim s As String

    Private Sub loadView()
        product.LoadAllBrandToCBO(cboBrand)
        cboBrand.SelectedIndex = cboBrand.FindString("All")

        product.LoadAllClassToCBO(cboClass)
        cboClass.SelectedIndex = cboClass.FindString("All")

        product.LoadAllCategoryToCBO(cboCategory)
        cboCategory.SelectedIndex = cboCategory.FindString("All")

        product.LoadAllMadeInToCBO(cboMadeIn)
        cboMadeIn.SelectedIndex = cboMadeIn.FindString("All")

        cboSection.SelectedIndex = cboSection.FindString("All")

        product.ViewProduct(gvSearch, b, c, t, m, s)
        product.ViewProduct(gvPro, b, c, t, m, s)
    End Sub

    Private Sub frmProduct_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If frmMain.userType = "Administrator" Then
            gvSearch.Visible = True
            gvPro.Visible = False
        Else
            gvSearch.Visible = False
            gvPro.Visible = True
        End If
        loadView()
    End Sub

    Private Sub cboBrand_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboBrand.SelectedIndexChanged
        If cboBrand.Text = "All" Then
            b = ""
        Else
            b = cboBrand.Text
        End If
        product.ViewProduct(gvSearch, b, c, t, m, s)
        product.ViewProduct(gvPro, b, c, t, m, s)
    End Sub

    Private Sub cboClass_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboClass.SelectedIndexChanged
        If cboClass.Text = "All" Then
            c = ""
        Else
            c = cboClass.Text
        End If
        product.ViewProduct(gvSearch, b, c, t, m, s)
        product.ViewProduct(gvPro, b, c, t, m, s)
    End Sub

    Private Sub cboCategory_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboCategory.SelectedIndexChanged
        If cboCategory.Text = "All" Then
            t = ""
        Else
            t = cboCategory.Text
        End If
        product.ViewProduct(gvSearch, b, c, t, m, s)
        product.ViewProduct(gvPro, b, c, t, m, s)
    End Sub

    Private Sub cboMadeIn_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboMadeIn.SelectedIndexChanged
        If cboMadeIn.Text = "All" Then
            m = ""
        Else
            m = cboMadeIn.Text
        End If
        product.ViewProduct(gvSearch, b, c, t, m, s)
        product.ViewProduct(gvPro, b, c, t, m, s)
    End Sub

    Private Sub cboSection_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cboSection.SelectedIndexChanged
        If cboSection.Text = "All" Then
            s = ""
        Else
            s = cboSection.Text
        End If
        product.ViewProduct(gvSearch, b, c, t, m, s)
        product.ViewProduct(gvPro, b, c, t, m, s)
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        AllowedOnly(Alpha, txtSearch)
        SentenceCase(txtSearch)
        product.SearchProduct(gvSearch, b, c, t, m, s, txtSearch.Text)
        product.SearchProduct(gvPro, b, c, t, m, s, txtSearch.Text)
    End Sub

    Private Sub gvSearch_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gvSearch.CellContentClick
        If e.ColumnIndex = 13 Then
            product.SetProductDetails(gvSearch.SelectedRows(0).Cells(0).Value)
            If MessageBox.Show("Are you sure you want to delete the Product " + product.ProductName, "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                If product.DeleteProduct() = True Then
                    product.ViewProduct(gvSearch, b, c, t, m, s)
                    product.ViewProduct(gvPro, b, c, t, m, s)
                Else
                    MessageBox.Show("Failed to delete product. Please try again.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If
        ElseIf e.ColumnIndex = 12 Then
            product.SetProductDetails(gvSearch.SelectedRows(0).Cells(0).Value)
            Dim obj As New frmEditProduct
            obj.product = Me.product
            If obj.ShowDialog = DialogResult.OK Then
                product.ViewProduct(gvSearch, b, c, t, m, s)
                product.ViewProduct(gvPro, b, c, t, m, s)
                loadView()
            End If
        End If
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim obj As New frmAddProduct
        If obj.ShowDialog() = Windows.Forms.DialogResult.OK Then
            product.ViewProduct(gvSearch, b, c, t, m, s)
            product.ViewProduct(gvPro, b, c, t, m, s)
            loadView()
        End If
    End Sub

    Private Sub btnRes_Click(sender As Object, e As EventArgs) Handles btnRes.Click
        loadView()
    End Sub
End Class