Imports MySql.Data.MySqlClient
Public Class Accounts
    Private _Acctid As Integer
    Public Property Acctid As Integer
        Set(value As Integer)
            _Acctid = value
        End Set
        Get
            Return _Acctid
        End Get
    End Property

    Private _firstname As String
    Public Property FirstName As String
        Set(value As String)
            _firstname = value
        End Set
        Get
            Return _firstname
        End Get
    End Property

    Private _lastname As String
    Public Property LastName As String
        Set(value As String)
            _lastname = value
        End Set
        Get
            Return _lastname
        End Get
    End Property

    Private _Position As String
    Public Property Position As String
        Set(value As String)
            _Position = value
        End Set
        Get
            Return _Position
        End Get
    End Property

    Private _UserNAme As String
    Public Property UserName As String
        Set(value As String)
            _UserNAme = value
        End Set
        Get
            Return _UserNAme
        End Get
    End Property

    Private _Password As String
    Public Property Password As String
        Set(value As String)
            _Password = value
        End Set
        Get
            Return _Password
        End Get
    End Property

    Private _Count As Integer
    Public Property Count As Integer
        Set(value As Integer)
            _Count = value
        End Set
        Get
            Return _Count
        End Get
    End Property

    Public Function AddAccount() As Boolean
        Try
            Dim bool As Boolean = False
            Dim sql As String = "INSERT INTO Account (firstname,lastname, Position,UserName,Password,Status) VALUES (@0,@1,@2,@3,@4,@5);"
            If IsConnected() = True Then
                ServerExecuteSQL(sql, FirstName, LastName, Position, UserName, Password, 0)
                Commit()
                bool = True
            End If
            Return bool
        Catch ex As Exception
            Rollback()
            ' MsgBox(ex.ToString, vbCritical, "Error")
            Return False
        End Try
    End Function
    Public Function EditAccount() As Boolean
        Try
            Dim bool As Boolean = False
            Dim sql As String = "UPDATE Account SET firstname=@0,lastname=@1, Position=@2,UserName=@3,Password=@4 Where acctid = @5;"
            If IsConnected() = True Then
                ServerExecuteSQL(sql, FirstName, LastName, Position, UserName, Password, Acctid)
                Commit()
                bool = True
            End If
            Return bool
        Catch ex As Exception
            Rollback()
            ' MsgBox(ex.ToString, vbCritical, "Error")
            Return False
        End Try
    End Function
    Public Function ValidateUserName(cnt As String) As Boolean
        Try
            Dim sql As String
            Dim bool As Boolean
            Dim i As Integer = 0
            sql = "SELECT Username From Account Where username = '" & cnt & "';"
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                If reader.HasRows Then
                    bool = False
                Else
                    bool = True
                End If
                reader.Close()
            End If
            Return bool
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Sub ViewAccounts(gv As DataGridView)
        Try
            Dim sql As String
            Dim i As Integer = 0
            sql = "SELECT * FROM account where acctid <> " & frmMain.UserID & " ORDER BY acctID ASC;"
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                gv.Rows.Clear()
                While reader.Read()
                    i = i + 1
                    With gv
                        .Rows.Add(reader(0), i, reader(1) + " " + reader(2), reader(4), reader(3), "Edit", "Delete")
                    End With
                End While
                reader.Close()
                gv.ClearSelection()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub SetAccountDetails(id As Integer)
        Try
            Dim sql As String
            sql = "SELECT * FROM Account WHERE acctID = " & id & ";"
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    Acctid = reader(0)
                    FirstName = reader(1)
                    LastName = reader(2)
                    Position = reader(3)
                    UserName = reader(4)
                    Password = reader(5)
                End While
                reader.Close()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub SetAdminDetails()
        Try
            Dim sql As String
            sql = "SELECT * FROM Account WHERE position = 'Administrator';"
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    Acctid = reader(0)
                    FirstName = reader(1)
                    LastName = reader(2)
                    Position = reader(3)
                    UserName = reader(4)
                    Password = reader(5)
                End While
                reader.Close()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Function DeleteAccount() As Boolean
        Try
            Dim bool As Boolean = False
            Dim sql As String = "DELETE FROM Account WHERE acctID= @0;"
            If IsConnected() = True Then
                ServerExecuteSQL(sql, Acctid)
                Commit()
                bool = True
            End If
            Return bool
        Catch ex As Exception
            Rollback()
            Return False
        End Try
    End Function

    Public Sub Searchname(kw As String, gv As DataGridView)
        Try
            Dim sql As String
            Dim i As Integer = 0
            sql = "SELECT * FROM Account WHERE (firstname LIKE '" & kw & "%' or lastname LIKE '" & kw & "%') and acctid <> " & frmMain.UserID & " ORDER BY firstname,lastname DESC;"
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                gv.Rows.Clear()
                While reader.Read()
                    i = i + 1
                    With gv
                        .Rows.Add(reader("Acctid"), i, reader("firstname") + " " + reader("lastname"), reader("username"), _
                                  reader("Position"), "Edit", "Delete")
                    End With
                End While
                reader.Close()
                gv.ClearSelection()
            End If
        Catch ex As Exception
        End Try
    End Sub

    '---LOGIN-------

    Public Function login(cnt As String, tmp As String) As Boolean
        Try
            Dim sql As String
            sql = "SELECT * From Account Where binary username ='" & cnt & "' and binary password = '" & tmp & "' and Status = 0;"
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                If reader.HasRows Then
                    Return True
                Else
                    Return False
                End If
            Else
                Return False
            End If
        Catch ex As Exception
            ' MsgBox(ex.ToString, vbCritical, "Error")
            Return False
        End Try
    End Function
    Public Sub SetAcctID(cnt As String, tmp As String)
        Try

            Dim sql As String
            sql = "SELECT acctid FROM account Where '" & cnt & "' = username and '" & tmp & "' = password and Status = 0"
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    Acctid = (reader("acctid"))
                    frmMain.UserID = Acctid
                End While
                reader.Close()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Function Editstatus(i As Integer) As Boolean
        Try
            If Position = "Administrator" Then
                i = 0
            End If
            Dim bool As Boolean = False
            Dim sql As String = "UPDATE Account SET Status=@0 WHERE Acctid = @1;"
            If IsConnected() = True Then
                ServerExecuteSQL(sql, i, Acctid)
                Commit()
                bool = True
            End If
            Return bool
        Catch ex As Exception
            Rollback()
            Return False
        End Try
    End Function

    Public Function Editpassword(str As String, ctr As String) As Boolean
        Try

            Dim bool As Boolean = False
            Dim sql As String = "UPDATE Account SET  Password =@0 WHERE Acctid = @1 and Password = @2;"
            If IsConnected() = True Then
                ServerExecuteSQL(sql, str, frmMain.UserID, ctr)
                Commit()
                bool = True
            End If
            Return bool
        Catch ex As Exception
            Rollback()
            Return False
        End Try
    End Function

    Public Function ValidatePassword(cnt As String) As Boolean
        Try
            Dim sql As String
            Dim bool As Boolean
            Dim i As Integer = 0
            sql = "SELECT Password From Account Where '" & cnt & "' = Password and acctid = '" & frmMain.UserID & "';"
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                If reader.HasRows Then
                    bool = True
                Else
                    bool = False
                End If
                reader.Close()
            End If
            Return bool
        Catch ex As Exception
            Return False
        End Try
    End Function
    Public Sub LoadAllCashierToCBO(cbo As ComboBox)
        Try
            Dim sql As String
            sql = "SELECT * FROM Account WHERE position <> 'Staff' ORDER BY firstname,lastname ASC;"
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                cbo.Items.Clear()
                cbo.Items.Add("All")
                While reader.Read()
                    cbo.Items.Add(reader("firstname") + " " + reader("lastname"))
                End While
                reader.Close()
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class
