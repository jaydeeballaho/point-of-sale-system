Imports MySql.Data.MySqlClient

Public Class Supplier

    Public SupplierArry As New ArrayList

    Private _Supplierid As Integer
    Public Property SupplierID As Integer
        Set(value As Integer)
            _Supplierid = value
        End Set
        Get
            Return _Supplierid
        End Get
    End Property

    Private _Suppliername As String
    Public Property SupplierName As String
        Set(value As String)
            _Suppliername = value
        End Set
        Get
            Return _Suppliername
        End Get
    End Property

    Private _SupplierAddress As String
    Public Property SupplierAddress As String
        Set(value As String)
            _SupplierAddress = value
        End Set
        Get
            Return _SupplierAddress
        End Get
    End Property

    Private _telephone As String
    Public Property Telephone As String
        Set(value As String)
            _telephone = value
        End Set
        Get
            Return _telephone
        End Get
    End Property

    Public Sub SetSupplierDetails(id As Integer)
        Try
            Dim sql As String
            sql = "SELECT * FROM Supplier WHERE idSupplier = " & id & ";"
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    SupplierID = reader(0)
                    SupplierName = reader(1)
                    SupplierAddress = reader(2)
                    Telephone = reader(3)
                End While
                reader.Close()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Function AddSupplier() As Boolean
        Try
            Dim bool As Boolean = False
            Dim sql As String = "INSERT INTO Supplier (Suppliername,Supplieraddress,telephone) VALUES (@0,@1,@2);"
            If IsConnected() = True Then
                ServerExecuteSQL(sql, SupplierName, SupplierAddress, Telephone)
                Commit()
                bool = True
            End If
            Return bool
        Catch ex As Exception
            Rollback()
            Return False
        End Try
    End Function

    Public Function EditSupplier() As Boolean
        Try
            Dim bool As Boolean = False
            Dim sql As String = "UPDATE Supplier SET Suppliername=@0,Supplieraddress=@1,telephone=@2 WHERE idSupplier = @3;"
            If IsConnected() = True Then
                ServerExecuteSQL(sql, SupplierName, SupplierAddress, Telephone, SupplierID)
                Commit()
                bool = True
            End If
            Return bool
        Catch ex As Exception
            Rollback()
            Return False
        End Try
    End Function

    Public Function DeleteSupplier() As Boolean
        Try
            Dim bool As Boolean = False
            Dim sql As String = "DELETE FROM Supplier WHERE idSupplier = @0;"
            If IsConnected() = True Then
                ServerExecuteSQL(sql, SupplierID)
                Commit()
                bool = True
            End If
            Return bool
        Catch ex As Exception
            Rollback()
            Return False
        End Try
    End Function

    Public Sub LoadSupplierToCBO(cbo As ComboBox)
        Try
            Dim sql As String
            sql = "SELECT idsupplier,suppliername FROM Supplier ORDER BY Suppliername ASC;"
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                cbo.Items.Clear()
                SupplierArry.Clear()
                While reader.Read()
                    cbo.Items.Add(reader("Suppliername"))
                    SupplierArry.Add(reader("idsupplier"))
                End While
                reader.Close()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub SearchSupplier(kw As String, gv As DataGridView)
        Try
            Dim sql As String
            Dim i As Integer = 0
            sql = "SELECT * FROM Supplier WHERE (Suppliername LIKE '" & kw & "%') ORDER BY Suppliername ASC;"
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                gv.Rows.Clear()
                While reader.Read()
                    i = i + 1
                    With gv
                        .Rows.Add(reader(0), i, reader(1), reader(2), reader(3), "Edit", "Delete")
                    End With
                End While
                reader.Close()
                gv.ClearSelection()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub ViewSupplier(gv As DataGridView)
        Try
            Dim sql As String
            Dim i As Integer = 0
            sql = "SELECT * FROM Supplier ORDER BY Suppliername ASC;"
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                gv.Rows.Clear()
                While reader.Read()
                    i = i + 1
                    With gv
                        .Rows.Add(reader(0), i, reader(1), reader(2), reader(3), "Edit", "Delete")
                    End With
                End While
                reader.Close()
                gv.ClearSelection()
            End If
        Catch ex As Exception
        End Try
    End Sub

End Class
