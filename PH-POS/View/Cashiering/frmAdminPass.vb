Imports System.Windows.Forms

Public Class frmAdminPass

    Private u As New Accounts
   
    Private Sub bntCancel_Click(sender As Object, e As EventArgs) Handles bntCancel.Click
        Me.Close()
    End Sub

    Private Sub frmAdminPass_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        u.SetAdminDetails()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If txtpw.Text <> u.Password Then
            MessageBox.Show("Incorrect Administrator Password", "", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            Me.DialogResult = Windows.Forms.DialogResult.OK
            Me.Close()
        End If
    End Sub

    Private Sub txtpw_TextChanged(sender As Object, e As EventArgs) Handles txtpw.TextChanged
        AllowedOnly("ñabcdefghijklmnopqrstuvwxyzÑ1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ-_", txtpw)
    End Sub
End Class
