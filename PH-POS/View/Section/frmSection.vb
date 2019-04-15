Public Class frmSection
    Private Section As New Section

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        Dim obj As New frmAddSection
        If obj.ShowDialog() = DialogResult.OK Then
            Section.ViewSection(gvSearch)
        End If
    End Sub

    Private Sub gvSection_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles gvSearch.CellContentClick
        If e.ColumnIndex = 5 Then
            Section.SetSectionDetails(gvSearch.SelectedRows(0).Cells(0).Value)
            If MessageBox.Show("Are you sure you want to delete the Section  " + Section.SectionName, "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                If Section.DeleteSection() = True Then
                    Section.ViewSection(gvSearch)
                Else
                    MessageBox.Show("Failed to delete. Please try again.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            End If
        ElseIf e.ColumnIndex = 4 Then
            Section.SetSectionDetails(gvSearch.SelectedRows(0).Cells(0).Value)
            Dim obj As New frmEditSection
            obj.Section = Me.Section
            If obj.ShowDialog = DialogResult.OK Then
                Section.ViewSection(gvSearch)
            End If
        End If
    End Sub

    Private Sub txtSearch_TextChanged(sender As Object, e As EventArgs) Handles txtSearch.TextChanged
        AllowedOnly(Alpha, txtSearch)
        SentenceCase(txtSearch)
        Section.SearchSection(txtSearch.Text, gvSearch)
    End Sub

    Private Sub Section_Setting_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Section.ViewSection(gvSearch)
    End Sub
End Class