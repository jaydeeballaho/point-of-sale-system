Public Class frmAddSection

    Private Section As New Section

    Private Sub txtName_TextChanged(sender As Object, e As EventArgs) Handles txtName.TextChanged
        AllowedOnly(Alpha, txtName)
        SentenceCase(txtName)
    End Sub

    Private Sub txtDes_TextChanged(sender As Object, e As EventArgs) Handles txtDes.TextChanged
        AllowedOnly(Alpha, txtDes)
        SentenceCase(txtDes)
    End Sub

    Private Sub bntCancel_Click(sender As Object, e As EventArgs) Handles bntCancel.Click
        Me.DialogResult = Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        If IsTextBoxEmpty(txtName) = True Then
            MessageBox.Show("Section Name is required.", "Message", _
                            MessageBoxButtons.OK, MessageBoxIcon.Warning)
        Else
            With Section
                .SectionName = txtName.Text
                .SectionDetails = txtDes.Text
                If .AddSection() = True Then
                    MessageBox.Show("Section successfully added.", "Message", _
                          MessageBoxButtons.OK, MessageBoxIcon.Information)
                    Me.DialogResult = Windows.Forms.DialogResult.OK
                    Me.Close()
                Else
                    MessageBox.Show("Failed adding section.", "Message", _
                          MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End With
        End If
    End Sub
End Class