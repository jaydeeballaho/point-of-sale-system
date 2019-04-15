Public Class frmAddAcc
    Private col As New Accounts
    Private Sub bntCancel_Click(sender As Object, e As EventArgs) Handles bntCancel.Click
        Me.DialogResult = DialogResult.Cancel
        Me.Close()
    End Sub
    Private Sub txtName_TextChanged(sender As Object, e As EventArgs) Handles txtName.TextChanged
        AllowedOnly(LetterOnly, txtName)
        SentenceCase(txtName)
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        '  Dim sex As String
        If IsTextBoxEmpty(txtName, txtPw, txtUserName) = True Or cboType.SelectedIndex = -1 Then
            MessageBox.Show("Name, User Name, Password and Position are required.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        ElseIf col.ValidateUserName(txtUserName.Text) = False Then
            MessageBox.Show("Your User Name is already exist.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUserName.Focus()
        Else

            col.FirstName = txtName.Text
            col.LastName = txtLastName.Text
            col.Position = cboType.Text
            col.UserName = txtUserName.Text
            col.Password = txtPw.Text
            If col.AddAccount = True Then
                MessageBox.Show("Successfully Saved.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
                Me.DialogResult = DialogResult.OK
                Me.Close()
            Else
                MessageBox.Show("Failed to save.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            End If
        End If

    End Sub

    Private Sub txtUserName_Leave(sender As Object, e As EventArgs) Handles txtUserName.Leave

        If col.ValidateUserName(txtUserName.Text) = False Then
            MessageBox.Show("Your User Name is already exist.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            txtUserName.Focus()
        End If
    End Sub

    Private Sub Add_Account_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub txtLastName_TextChanged(sender As Object, e As EventArgs) Handles txtLastName.TextChanged
        AllowedOnly(LetterOnly, txtLastName)
        SentenceCase(txtLastName)
    End Sub

    Private Sub txtUserName_TextChanged(sender As Object, e As EventArgs) Handles txtUserName.TextChanged
        AllowedOnly("ñabcdefghijklmnopqrstuvwxyzÑ1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ-_", txtUserName)
    End Sub

    Private Sub txtPw_TextChanged(sender As Object, e As EventArgs) Handles txtPw.TextChanged
        AllowedOnly("ñabcdefghijklmnopqrstuvwxyzÑ1234567890ABCDEFGHIJKLMNOPQRSTUVWXYZ-_", txtPw)
    End Sub
End Class