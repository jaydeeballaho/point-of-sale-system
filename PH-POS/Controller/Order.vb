Imports MySql.Data.MySqlClient
Imports System.Globalization

Public Class Order

    Private _idorder As Integer = 0
    Public Property OrderID As Integer
        Set(value As Integer)
            _idorder = value
        End Set
        Get
            Return _idorder
        End Get
    End Property
    Private _qty As Double = 0
    Public Property Qty As Double
        Set(value As Double)
            _qty = value
        End Set
        Get
            Return _qty
        End Get
    End Property
    Private _t As Double = 0
    Public Property T As Double
        Set(value As Double)
            _t = value
        End Set
        Get
            Return _t
        End Get
    End Property
    Private _d As Double = 0
    Public Property D As Double
        Set(value As Double)
            _d = value
        End Set
        Get
            Return _d
        End Get
    End Property
    Private _gt As Double = 0
    Public Property GT As Double
        Set(value As Double)
            _gt = value
        End Set
        Get
            Return _gt
        End Get
    End Property
    Private _doo As Date
    Public Property DOO As Date
        Set(value As Date)
            _doo = value
        End Set
        Get
            Return _doo
        End Get
    End Property
    Private _cashier As String = ""
    Public Property Cashier As String
        Set(value As String)
            _cashier = value
        End Set
        Get
            Return _cashier
        End Get
    End Property
    Public Sub SetOrderID()
        Try
            Dim sql As String
            sql = "SELECT LAST_INSERT_ID();"
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                OrderID = Integer.Parse(cmd.ExecuteScalar)
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Function AddOrder() As Boolean
        Try
            Dim bool As Boolean = False
            Dim sql As String = "INSERT INTO orderpay (doo,cashier,t,d,gt) VALUES (@0,@1,@2,@3,@4);"
            If IsConnected() = True Then
                ServerExecuteSQL(sql, DOO, Cashier, T, D, GT)
                Commit()
                bool = True
            End If
            Return bool
        Catch ex As Exception
            MsgBox(ex.Message)
            Rollback()
            Return False
        End Try
    End Function

    Public Sub ViewSales(gv As DataGridView, d1 As Date, d2 As Date, c As String)
        Try
            Dim sql As String
            Dim i As Integer = 0
            sql = "SELECT * FROM product as p INNER JOIN stockout as s ON p.idproduct=s.idproduct INNER JOIN " _
                & "orderpay as ord ON s.idorder=ord.idorder WHERE DATE(doo) >= DATE('" & d1.ToString("yyyy-MM-dd") & "') AND " _
                & "DATE(doo) <= DATE('" & d2.ToString("yyyy-MM-dd") & "') AND reason = 'Paid' and cashier LIKE '" & c & "%' ORDER BY doo DESC;"
            Dim d As String = ""
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                gv.Rows.Clear()
                While reader.Read()
                    i = i + 1
                    With gv
                        .Rows.Add(reader(0), i, reader("productname"), reader("productcode"), reader("unit"), _
                                          Decimal.Parse(reader("unitprice")).ToString("N", CultureInfo.InvariantCulture), _
                                          reader("qty"), Decimal.Parse(reader("unitprice") * reader("qty")).ToString("N", CultureInfo.InvariantCulture), _
                                          Date.Parse(reader("doo")).ToShortDateString(), reader("cashier"))

                    End With
                End While
                reader.Close()

                gv.ClearSelection()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
End Class
