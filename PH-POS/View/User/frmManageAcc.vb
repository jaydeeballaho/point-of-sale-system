Public Class frmManageAcc
    Private Account As New Accounts
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim obj As New frmAddAcc
        If obj.ShowDialog() = DialogResult.OK Then
            Account.ViewAccounts(gvAccount)
        End If
    End Sub

    Private Sub gvAccount_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gvAccount.CellContentClick
        If e.ColumnIndex = 6 Then
            Account.SetAccountDetails(gvAccount.SelectedRows(0).Cells(0).Value)
            If MessageBox.Show("Are you sure you want to delete the account of  " + Account.UserName, "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                If Account.DeleteAccount() = True Then
                    Account.ViewAccounts(gvAccount)
                Else
                    MessageBox.Show("Failed to delete. Please try again.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If
        ElseIf e.ColumnIndex = 5 Then
            Account.SetAccountDetails(gvAccount.SelectedRows(0).Cells(0).Value)
            Dim obj As New frmEditAcc
            obj.col = Me.Account
            If obj.ShowDialog = DialogResult.OK Then
                Account.ViewAccounts(gvAccount)
            End If
        End If
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged
        AllowedOnly(LetterWSpecial, TextBox2)
        SentenceCase(TextBox2)
        Account.Searchname(TextBox2.Text, gvAccount)
    End Sub

    Private Sub Account_Setting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Account.ViewAccounts(gvAccount)
    End Sub
End Class