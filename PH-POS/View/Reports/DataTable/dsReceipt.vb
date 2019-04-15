Partial Class dsReceipt
    Partial Class dsReceiptDataTable

        Private Sub dsReceiptDataTable_ColumnChanging(sender As Object, e As DataColumnChangeEventArgs) Handles Me.ColumnChanging
            If (e.Column.ColumnName = Me._No_Column.ColumnName) Then
                'Add user code here
            End If

        End Sub

    End Class

End Class
