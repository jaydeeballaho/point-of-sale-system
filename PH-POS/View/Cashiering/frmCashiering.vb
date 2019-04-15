Imports System.Windows.Forms
Imports System.Globalization
Public Class frmCashiering

    Private pro As New Product
    Private order As New Order
    Private stocks As New Stock

    Private Sub btnClose_Click(sender As Object, e As EventArgs) Handles btnDiscount.Click
        If gvOrder.RowCount > 0 Then
            Dim obj As New frmAdminPass
            If obj.ShowDialog() = Windows.Forms.DialogResult.OK Then
                Dim d As New frmDiscount
                order.Qty = txtTota.Text
                d.order = Me.order
                If d.ShowDialog() = Windows.Forms.DialogResult.OK Then
                    txtDis.Text = Decimal.Parse(order.Qty).ToString("N", CultureInfo.InvariantCulture)
                    Calculate()
                End If
            End If
        End If
        gvOrder.Focus()
    End Sub

    Private Sub frmCashiering_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F2 Then
            btnNew.PerformClick()
        ElseIf e.KeyCode = Keys.F3 Then
            btnSearch.PerformClick()
        ElseIf e.KeyCode = Keys.F6 Then
            btnDiscount.PerformClick()
        ElseIf e.KeyCode = Keys.F4 Then
            btnPay.PerformClick()
        ElseIf e.KeyCode = Keys.Escape Then
            btnClose.PerformClick()
        ElseIf e.Control And Keys.P Then
            btnPrint.PerformClick()
        ElseIf e.KeyCode = Keys.Enter Then
            If txtSearch.Text.Count > 5 Then
                pro.ProductCode = txtSearch.Text
                pro.SetProductUsingCode(txtSearch.Text)
                For Each r As DataGridViewRow In gvOrder.Rows
                    If r.Cells(0).Value.ToString = pro.ProductID.ToString Then
                        r.Cells(6).Value = r.Cells(6).Value + txtQty.Value
                        Calculate()
                        gvOrder.ClearSelection()
                        txtSearch.Clear()
                        kw = ""
                        Exit Sub
                    End If
                Next
                gvOrder.Rows.Add(pro.ProductID, gvOrder.RowCount + 1, pro.ProductName, pro.ProductCode, _
                                 pro.Unit, Decimal.Parse(pro.Price).ToString("N", CultureInfo.InvariantCulture), _
                                 txtQty.Value, Decimal.Parse(pro.Price * txtQty.Value).ToString("N", CultureInfo.InvariantCulture), _
                                  "Remove")
                Calculate()
                gvOrder.ClearSelection()
                txtSearch.Clear()
                kw = ""
            End If
        End If
    End Sub
    Dim kw As String = ""
    Private Sub frmCashiering_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If IsNumeric(e.KeyChar) Then
            kw = kw + e.KeyChar.ToString()
            txtSearch.Text = txtSearch.Text + e.KeyChar.ToString()
        End If
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim obj As New frmSearchItemForCashier
        obj.pro = Me.pro
        If obj.ShowDialog() = Windows.Forms.DialogResult.OK Then
            txtSearch.Text = pro.ProductCode
            For Each r As DataGridViewRow In gvOrder.Rows
                If r.Cells(0).Value.ToString = pro.ProductID.ToString Then
                    r.Cells(6).Value = r.Cells(6).Value + txtQty.Value
                    Calculate()
                    gvOrder.ClearSelection()
                    Exit Sub
                End If
            Next
            gvOrder.Rows.Add(pro.ProductID, gvOrder.RowCount + 1, pro.ProductName, pro.ProductCode, _
                             pro.Unit, Decimal.Parse(pro.Price).ToString("N", CultureInfo.InvariantCulture), _
                             txtQty.Value, Decimal.Parse(pro.Price * txtQty.Value).ToString("N", CultureInfo.InvariantCulture), _
                              "Remove")
            Calculate()
            gvOrder.ClearSelection()
        End If
        gvOrder.Focus()
    End Sub

    Sub Calculate()
        Dim d As Decimal = 0
        For Each r As DataGridViewRow In gvOrder.Rows
            r.Cells(7).Value = Decimal.Parse(r.Cells(6).Value * r.Cells(5).Value).ToString("N", CultureInfo.InvariantCulture)
            d = d + r.Cells(7).Value
            r.Cells(1).Value = r.Index + 1
        Next
        txtTota.Text = d.ToString("N", CultureInfo.InvariantCulture)
        txtGT.Text = Decimal.Parse((d - txtDis.Text)).ToString("N", CultureInfo.InvariantCulture)
        gvOrder.ClearSelection()
    End Sub

    Private Sub gvOrder_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gvOrder.CellContentClick
        If e.ColumnIndex = 8 Then
            gvOrder.Rows.RemoveAt(gvOrder.SelectedRows(0).Index)
        ElseIf e.ColumnIndex = 9 Then

        End If
    End Sub

    Private Sub gvOrder_RowsAdded(sender As Object, e As DataGridViewRowsAddedEventArgs) Handles gvOrder.RowsAdded
        Calculate()
        txtQty.Value = 1
    End Sub

    Private Sub gvOrder_RowsRemoved(sender As Object, e As DataGridViewRowsRemovedEventArgs) Handles gvOrder.RowsRemoved
        Calculate()
    End Sub

    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        txtSearch.Clear()
        txtQty.Value = 1
        gvOrder.Rows.Clear()
        txtDis.Text = "0.00"
        txtGT.Text = "0.00"
        gvOrder.Focus()
    End Sub

    Private Sub btnPay_Click(sender As Object, e As EventArgs) Handles btnPay.Click
        If gvOrder.RowCount > 0 Then
            With order
                .DOO = frmMain.dtServer
                .Cashier = frmMain.fullname
                .T = txtTota.Text
                .D = txtDis.Text
                .GT = txtGT.Text
                If .AddOrder() = True Then
                    .SetOrderID()
                    Dim s As New Stock
                    s.StockID = .OrderID
                    For Each r As DataGridViewRow In gvOrder.Rows
                        With s
                            .ProductID = r.Cells(0).Value
                            .QTY = r.Cells(6).Value
                            .Reason = "Paid"
                            .DOS = order.DOO
                            .By = order.Cashier
                            .Price = r.Cells(5).Value
                            .AddStockOut()
                        End With
                    Next
                    MessageBox.Show("Paid successfully", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                    btnNew.PerformClick()
                End If
            End With
        End If
        gvOrder.Focus()
    End Sub

    Private Sub btnClose_Click_1(sender As Object, e As EventArgs) Handles btnClose.Click
        Me.Close()
    End Sub

    Private Sub btnUp_Click(sender As Object, e As EventArgs) Handles btnUp.Click
        If txtQty.Value <> txtQty.Maximum Then
            txtQty.Value = txtQty.Value + 1
        End If
        gvOrder.Focus()
    End Sub

    Private Sub btnDw_Click(sender As Object, e As EventArgs) Handles btnDw.Click
        If txtQty.Value <> txtQty.Minimum Then
            txtQty.Value = txtQty.Value - 1
        End If
        gvOrder.Focus()
    End Sub

    Private Sub txtTota_TextChanged(sender As Object, e As EventArgs) Handles txtTota.TextChanged
        If Val(txtTota.Text) > 0 Then
            btnPay.Enabled = True
            btnPrint.Enabled = True
        Else
            btnPay.Enabled = False
            btnPrint.Enabled = False
        End If
    End Sub

    Private Sub btnPrint_Click(sender As Object, e As EventArgs) Handles btnPrint.Click
        Try
            If gvOrder.RowCount > 0 Then
                With order
                    .DOO = frmMain.dtServer
                    .Cashier = frmMain.fullname
                    .T = txtTota.Text
                    .D = txtDis.Text
                    .GT = txtGT.Text
                    If .AddOrder() = True Then
                        .SetOrderID()
                        Dim s As New Stock
                        s.StockID = .OrderID
                        For Each r As DataGridViewRow In gvOrder.Rows
                            With s
                                .ProductID = r.Cells(0).Value
                                .QTY = r.Cells(6).Value
                                .Reason = "Paid"
                                .DOS = order.DOO
                                .By = order.Cashier
                                .Price = r.Cells(5).Value
                                .AddStockOut()
                            End With
                        Next
                        MessageBox.Show("Paid successfully", "", MessageBoxButtons.OK, MessageBoxIcon.Information)
                        Dim frm As New frmPrint
                        Dim rpt As New crptReceipt
                        Dim dt As New DataTable

                        With dt
                            .Columns.Add("No.")
                            .Columns.Add("ProductName")
                            .Columns.Add("ProductCode")
                            .Columns.Add("Unit")
                            .Columns.Add("UnitPrice")
                            .Columns.Add("Qty")
                            .Columns.Add("UnitTotal")
                        End With

                        For Each r As DataGridViewRow In gvOrder.Rows
                            dt.Rows.Add(r.Cells(1).Value, r.Cells(2).Value, r.Cells(3).Value, r.Cells(4).Value, r.Cells(5).Value, _
                                        r.Cells(6).Value, r.Cells(7).Value)
                        Next
                        rpt.SetDataSource(dt)

                        rpt.SetParameterValue(0, txtTota.Text)
                        rpt.SetParameterValue(1, txtDis.Text)
                        rpt.SetParameterValue(2, txtGT.Text)
                        rpt.SetParameterValue(3, order.Cashier)

                        frm.rptViewer.ReportSource = rpt

                        frm.ShowDialog()
                        btnNew.PerformClick()
                    End If
                End With
            End If
            gvOrder.Focus()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class
