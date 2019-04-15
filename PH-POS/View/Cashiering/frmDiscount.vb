Imports System.Windows.Forms

Public Class frmDiscount

    Public order As Order
    Dim d As Decimal = 0

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        order.Qty = d
        Me.DialogResult = Windows.Forms.DialogResult.OK
        Me.Close()
    End Sub

    Private Sub rbAmount_CheckedChanged(sender As Object, e As EventArgs) Handles rbAmount.CheckedChanged
        If rbAmount.Checked = True Then
            txtDis.DecimalPlaces = 2
            txtDis.Maximum = order.Qty
            txtDis.Enabled = True
        End If
    End Sub

    Private Sub rbPer_CheckedChanged(sender As Object, e As EventArgs) Handles rbPer.CheckedChanged
        If rbPer.Checked = True Then
            txtDis.DecimalPlaces = 0
            txtDis.Maximum = 100
            txtDis.Enabled = True
        End If
    End Sub

    Private Sub txtDis_ValueChanged(sender As Object, e As EventArgs) Handles txtDis.ValueChanged
        If rbAmount.Checked = True Then
            d = txtDis.Value
        ElseIf rbPer.Checked = True Then
            d = order.Qty * (txtDis.Value / 100)
        End If
    End Sub

    Private Sub bntCancel_Click(sender As Object, e As EventArgs) Handles bntCancel.Click
        Me.Close()
    End Sub
End Class
