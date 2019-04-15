Imports System.Windows.Forms

Public Class frmMyProfile

    Public user As Accounts
    Private Sub frmMyProfile_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        With user
            txtLastName.Text = .LastName
            txtName.Text = .FirstName
            txtUserName.Text = .UserName
            txtPw.Text = .Password
            txtPos.Text = .Position
        End With
    End Sub
End Class
