Imports MySql.Data.MySqlClient

Public Class frmMain

    Public Shared flag As Integer = 0
    Public Shared UserID As Integer = 0
    Public Shared fullname As String = "Sir Admin"
    Public Shared dtServer As Date = DateTime.Now
    Public Shared userType As String = "Administrator"

    Private account As New Accounts

    Private Sub timerMain_Tick(sender As Object, e As EventArgs) Handles timerMain.Tick
        Dim sql As String = "SELECT now();"
        Try
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                dtServer = cmd.ExecuteScalar
                tsDate.Text = MonthName(dtServer.Month) + " " + dtServer.Day.ToString() + ", " + dtServer.Year.ToString()
                tsTime.Text = dtServer.ToString("hh:mm:ss tt")
                tsUser.Text = fullname
                tsType.Text = userType

                Dim s As New Stock
                s.DiffQty(gvQty, "", "", "", "", "")
                s.ViewStocksNotification(gvStocks, "", "", "", "", "")
                s.Remaining3(gvStocks, gvQty)
                s.RemoveStocks(gvStocks, gvQty)
                s.ViewExpiring(gvExpiry)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub frmMain_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If flag = 1 Then
            If MessageBox.Show("Are you sure you want to exit from the system?", "Message", MessageBoxButtons.YesNo, _
                           MessageBoxIcon.Question) = Windows.Forms.DialogResult.No Then
                e.Cancel = True
            End If
        End If
    End Sub

    Private Sub frmMain_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If e.KeyCode = Keys.F1 Then
            btnSearch.PerformClick()
        ElseIf e.KeyCode = Keys.F2 Then
            btnProduct.PerformClick()
        ElseIf e.KeyCode = Keys.F3 Then
            btnInventory.PerformClick()
        ElseIf e.KeyCode = Keys.F4 Then
            btnEmployee.PerformClick()
        ElseIf e.KeyCode = Keys.F5 Then
            btnSupplier.PerformClick()
        ElseIf e.KeyCode = Keys.F6 Then
            btnSection.PerformClick()
        ElseIf e.KeyCode = Keys.F7 Then
            btnSale.PerformClick()
        ElseIf e.KeyCode = Keys.F8 Then
            btnCashier.PerformClick()
        ElseIf e.Alt And e.KeyCode = Keys.F10 Then
            btnLogout.PerformClick()
        ElseIf e.Alt And e.KeyCode = Keys.F9 Then
            btnMyProfile.PerformClick()
        End If
    End Sub

    Private Sub frmMain_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Hide()
        Dim obj As New frmLogin
        obj.ShowDialog()
    End Sub

    Private Sub btnEmployee_Click(sender As Object, e As EventArgs) Handles btnEmployee.Click
        Dim obj As New frmManageAcc
        obj.ShowDialog()
    End Sub

    Private Sub btnSupplier_Click(sender As Object, e As EventArgs) Handles btnSupplier.Click
        Dim obj As New frmSupplier
        obj.ShowDialog()
    End Sub

    Private Sub btnSection_Click(sender As Object, e As EventArgs) Handles btnSection.Click
        Dim obj As New frmSection
        obj.ShowDialog()
    End Sub

    Private Sub btnProduct_Click(sender As Object, e As EventArgs) Handles btnProduct.Click
        Dim obj As New frmProduct
        obj.ShowDialog()
    End Sub

    Private Sub btnInventory_Click(sender As Object, e As EventArgs) Handles btnInventory.Click
        Dim obj As New frmStocks
        obj.ShowDialog()
    End Sub

    Private Sub btnSearch_Click(sender As Object, e As EventArgs) Handles btnSearch.Click
        Dim obj As New frmSearchProduct
        obj.ShowDialog()
    End Sub

    Private Sub btnLogout_Click(sender As Object, e As EventArgs) Handles btnLogout.Click
        If MessageBox.Show("Are you sure you want to log-out?", "Message", MessageBoxButtons.YesNo, _
                        MessageBoxIcon.Question) = Windows.Forms.DialogResult.Yes Then
            account.SetAccountDetails(UserID)
            account.Editstatus(0)
            Me.Hide()
            Me.timerMain.Stop()
            Dim obj As New frmLogin
            obj.ShowDialog()
        End If
    End Sub

    Private Sub btnCashier_Click(sender As Object, e As EventArgs) Handles btnCashier.Click
        Dim obj As New frmCashiering
        obj.ShowDialog()
    End Sub

    Private Sub btnSale_Click(sender As Object, e As EventArgs) Handles btnSale.Click
        Dim obj As New frmViewSales
        obj.ShowDialog()
    End Sub

    Private Sub btnMyProfile_Click(sender As Object, e As EventArgs) Handles btnMyProfile.Click
        Dim obj As New frmMyProfile
        account.SetAccountDetails(UserID)
        obj.user = Me.account
        obj.ShowDialog()
    End Sub
End Class
