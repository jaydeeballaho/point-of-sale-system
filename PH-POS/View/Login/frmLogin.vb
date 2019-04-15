Public Class frmLogin
    Private account As New Accounts
    Dim i As Integer = 0
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If IsTextBoxEmpty(txtName, txtpw) = True Then
            MessageBox.Show("Please eneter User Name And Password.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            If account.login(txtName.Text, txtpw.Text) = True Then
                account.SetAcctID(txtName.Text, txtpw.Text)
                account.SetAccountDetails(account.Acctid)
                account.Editstatus(1)
                frmMain.UserID = account.Acctid
                frmMain.fullname = account.FirstName + " " + account.LastName
                frmMain.userType = account.Position
                i = 1
                If account.Position = "Administrator" Then
                    For Each btn As Button In frmMain.flowPanel.Controls
                        btn.Show()
                    Next
                ElseIf account.Position = "Staff" Then
                    For Each btn As Button In frmMain.flowPanel.Controls
                        btn.Hide()
                    Next
                    frmMain.btnSearch.Show()
                    '      frmMain.btnOrder.Show()
                    frmMain.btnProduct.Show()
                ElseIf account.Position = "Cashier" Then
                    For Each btn As Button In frmMain.flowPanel.Controls
                        btn.Hide()
                    Next
                    frmMain.btnProduct.Show()
                    frmMain.btnInventory.Show()
                    frmMain.btnCashier.Show()
                End If
                frmMain.Show()
                frmMain.timerMain.Start()
                Me.DialogResult = DialogResult.OK
                Me.Close()
                frmMain.flag = 1
            Else
                MessageBox.Show("Please enter a valid user name and password. Please try again.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If
    End Sub

    Private Sub frmLogin_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If i = 0 Then
            frmMain.flag = 0
            frmMain.Close()
        End If
    End Sub
    Sub EnableButton()
        If txtName.Text.Count = 0 Or txtpw.Text.Count = 0 Then
            btnSave.Enabled = False
        Else
            btnSave.Enabled = True
        End If
    End Sub
    Private Sub txtName_TextChanged(sender As Object, e As EventArgs) Handles txtName.TextChanged
        AllowedOnly("ñabcdefghijklmnopqrstuvwxyzÑ1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ-_", txtName)
        EnableButton()
    End Sub

    Private Sub txtpw_TextChanged(sender As Object, e As EventArgs) Handles txtpw.TextChanged
        AllowedOnly("ñabcdefghijklmnopqrstuvwxyzÑ1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ-_", txtpw)
        EnableButton()
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        Dim obj As New frmConnection
        obj.ShowDialog()
    End Sub

    Private Sub linkClose_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs)
        Me.Close()
    End Sub
End Class