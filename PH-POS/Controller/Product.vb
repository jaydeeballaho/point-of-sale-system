Imports MySql.Data.MySqlClient
Imports System.Globalization

Public Class Product

    Private _Productid As Integer
    Public Property ProductID As Integer
        Set(value As Integer)
            _Productid = value
        End Set
        Get
            Return _Productid
        End Get
    End Property

    Private _ProductCode As String
    Public Property ProductCode As String
        Set(value As String)
            _ProductCode = value
        End Set
        Get
            Return _ProductCode
        End Get
    End Property

    Private _Productname As String
    Public Property ProductName As String
        Set(value As String)
            _Productname = value
        End Set
        Get
            Return _Productname
        End Get
    End Property

    Private _brand As String
    Public Property Brand As String
        Set(value As String)
            _brand = value
        End Set
        Get
            Return _brand
        End Get
    End Property

    Private _class As String
    Public Property Classes As String
        Set(value As String)
            _class = value
        End Set
        Get
            Return _class
        End Get
    End Property

    Private _category As String
    Public Property Category As String
        Set(value As String)
            _category = value
        End Set
        Get
            Return _category
        End Get
    End Property

    Private _madein As String
    Public Property MadeIn As String
        Set(value As String)
            _madein = value
        End Set
        Get
            Return _madein
        End Get
    End Property

    Private _sizeWeight As String
    Public Property SizeWeight As String
        Set(value As String)
            _sizeWeight = value
        End Set
        Get
            Return _sizeWeight
        End Get
    End Property

    Private _unit As String
    Public Property Unit As String
        Set(value As String)
            _unit = value
        End Set
        Get
            Return _unit
        End Get
    End Property

    Private _max As Integer
    Public Property Max As Integer
        Set(value As Integer)
            _max = value
        End Set
        Get
            Return _max
        End Get
    End Property

    Private _desc As String
    Public Property Desc As String
        Set(value As String)
            _desc = value
        End Set
        Get
            Return _desc
        End Get
    End Property

    Private _alert As String
    Public Property Alert As String
        Set(value As String)
            _alert = value
        End Set
        Get
            Return _alert
        End Get
    End Property

    Private _alertNo As Integer
    Public Property AlertNo As String
        Set(value As String)
            _alertNo = value
        End Set
        Get
            Return _alertNo
        End Get
    End Property

    Private _price As Decimal
    Public Property Price As Decimal
        Set(value As Decimal)
            _price = value
        End Set
        Get
            Return _price
        End Get
    End Property
    Public Function SetProductUsingCode(id As String) As Boolean
        Try
            Dim sql As String
            Dim bool As Boolean = False
            sql = "SELECT * FROM Product WHERE productcode = '" & id & "' LIMIT 1;"
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    ProductID = reader(0)
                    ProductCode = reader(1)
                    ProductName = reader(2)
                    Brand = reader(3)
                    Classes = reader(4)
                    Category = reader(5)
                    MadeIn = reader(6)
                    SizeWeight = reader(7)
                    Unit = reader(8)
                    Desc = reader(9)
                    Alert = reader(10)
                    AlertNo = reader(11)
                    Max = reader(12)
                    Price = reader(13)
                    bool = True
                End While
                reader.Close()

            End If
            Return bool
        Catch ex As Exception
            MsgBox(ex.Message)
            Return False
        End Try
    End Function
    Public Sub SetProductDetails(id As Integer)
        Try
            Dim sql As String
            sql = "SELECT * FROM Product WHERE idProduct = " & id & " LIMIT 1;"
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    ProductID = reader(0)
                    ProductCode = reader(1)
                    ProductName = reader(2)
                    Brand = reader(3)
                    Classes = reader(4)
                    Category = reader(5)
                    MadeIn = reader(6)
                    SizeWeight = reader(7)
                    Unit = reader(8)
                    Desc = reader(9)
                    Alert = reader(10)
                    AlertNo = reader(11)
                    Max = reader(12)
                    Price = reader(13)
                End While
                reader.Close()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Function AddProduct() As Boolean
        Try
            Dim bool As Boolean = False
            Dim sql As String = "INSERT INTO Product (productcode,Productname,brand,class,category,madein,sizeweight,unit,description,alert,stocktoalert,maxstock,unitprice) VALUES (@0,@1,@2,@3,@4,@5,@6,@7,@8,@9,@10,@11,@12);"
            If IsConnected() = True Then
                ServerExecuteSQL(sql, ProductCode, ProductName, Brand, Classes, Category, MadeIn, SizeWeight, Unit, Desc, Alert, AlertNo, Max, Price)
                Commit()
                bool = True
            End If
            Return bool
        Catch ex As Exception
            Rollback()
            Return False
        End Try
    End Function

    Public Function EditProduct() As Boolean
        Try
            Dim bool As Boolean = False
            Dim sql As String = "UPDATE Product SET Productcode=@0,productname=@1,brand=@2,class=@3,category=@4,madein=@5,sizeweight=@6,unit=@7,maxstock=@8,description=@9,alert=@10,stocktoalert=@11,unitprice=@12 WHERE idProduct = @13;"
            If IsConnected() = True Then
                ServerExecuteSQL(sql, ProductCode, ProductName, Brand, Classes, Category, MadeIn, SizeWeight, Unit, Max, Desc, Alert, AlertNo, Price, ProductID)
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

    Public Function DeleteProduct() As Boolean
        Try
            Dim bool As Boolean = False
            Dim sql As String = "DELETE FROM Product WHERE idproduct = @0;"
            If IsConnected() = True Then
                ServerExecuteSQL(sql, ProductID)
                Commit()
                bool = True
            End If
            Return bool
        Catch ex As Exception
            Rollback()
            Return False
        End Try
    End Function

    Public Function GenerateGTIN() As String
        Dim un As String = ""
        Dim rdm As New Random()
        Dim allowChrs() As Char = "0123456789".ToCharArray()
        For i As Integer = 0 To 11
            un += allowChrs(rdm.Next(0, allowChrs.Length))
        Next
        If IsExist(un) = True Then
            GenerateGTIN()
        End If
        Return un
    End Function
    Public Function IsExist(str As String) As Boolean
        Try
            Dim bool As Boolean = False
            Dim sql As String = "SELECT * FROM product WHERE BINARY productcode = '" & str & "' LIMIT 1;"
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                If reader.HasRows Then
                    bool = True
                End If
                reader.Close()
            End If
            Return bool
        Catch ex As Exception
            Return False
        End Try
    End Function

    Public Sub LoadBrandToCBO(cbo As ComboBox)
        Try
            Dim sql As String
            sql = "SELECT DISTINCT brand FROM Product WHERE brand <> '' ORDER BY brand ASC;"
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                cbo.Items.Clear()
                While reader.Read()
                    cbo.Items.Add(reader("brand"))
                End While
                reader.Close()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub LoadAllBrandToCBO(cbo As ComboBox)
        Try
            Dim sql As String
            sql = "SELECT DISTINCT brand FROM Product WHERE brand <> '' ORDER BY brand ASC;"
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                cbo.Items.Clear()
                cbo.Items.Add("All")
                While reader.Read()
                    cbo.Items.Add(reader("brand"))
                End While
                reader.Close()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub LoadClassToCBO(cbo As ComboBox)
        Try
            Dim sql As String
            sql = "SELECT DISTINCT class FROM Product WHERE class <> '' ORDER BY class ASC;"
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                cbo.Items.Clear()
                While reader.Read()
                    cbo.Items.Add(reader("class"))
                End While
                reader.Close()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub LoadAllClassToCBO(cbo As ComboBox)
        Try
            Dim sql As String
            sql = "SELECT DISTINCT class FROM Product WHERE class <> '' ORDER BY class ASC;"
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                cbo.Items.Clear()
                cbo.Items.Add("All")
                While reader.Read()
                    cbo.Items.Add(reader("class"))
                End While
                reader.Close()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub LoadCategoryToCBO(cbo As ComboBox)
        Try
            Dim sql As String
            sql = "SELECT DISTINCT Category FROM Product WHERE category <> '' ORDER BY Category ASC;"
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                cbo.Items.Clear()
                While reader.Read()
                    cbo.Items.Add(reader("Category"))
                End While
                reader.Close()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub LoadAllCategoryToCBO(cbo As ComboBox)
        Try
            Dim sql As String
            sql = "SELECT DISTINCT Category FROM Product WHERE category <> '' ORDER BY Category ASC;"
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                cbo.Items.Clear()
                cbo.Items.Add("All")
                While reader.Read()
                    cbo.Items.Add(reader("Category"))
                End While
                reader.Close()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub LoadMadeInToCBO(cbo As ComboBox)
        Try
            Dim sql As String
            sql = "SELECT DISTINCT MadeIn FROM Product WHERE madein <> '' ORDER BY MadeIn ASC;"
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                cbo.Items.Clear()
                While reader.Read()
                    cbo.Items.Add(reader("MadeIn"))
                End While
                reader.Close()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub LoadAllMadeInToCBO(cbo As ComboBox)
        Try
            Dim sql As String
            sql = "SELECT DISTINCT MadeIn FROM Product WHERE madein <> '' ORDER BY MadeIn ASC;"
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                cbo.Items.Clear()
                cbo.Items.Add("All")
                While reader.Read()
                    cbo.Items.Add(reader("MadeIn"))
                End While
                reader.Close()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub LoadUnitToCBO(cbo As ComboBox)
        Try
            Dim sql As String
            sql = "SELECT DISTINCT Unit FROM Product WHERE unit <> '' ORDER BY Unit ASC;"
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                cbo.Items.Clear()
                While reader.Read()
                    cbo.Items.Add(reader("Unit"))
                End While
                reader.Close()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub LoadAllUnitToCBO(cbo As ComboBox)
        Try
            Dim sql As String
            sql = "SELECT DISTINCT Unit FROM Product WHERE unit <> '' ORDER BY Unit ASC;"
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                cbo.Items.Clear()
                cbo.Items.Add("All")
                While reader.Read()
                    cbo.Items.Add(reader("Unit"))
                End While
                reader.Close()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub ViewProduct(gv As DataGridView, b As String, c As String, t As String, m As String, a As String)
        Try
            Dim sql As String
            Dim i As Integer = 0
            sql = "SELECT * FROM Product as p WHERE brand LIKE '" & b & "%' AND class LIKE '" & c & "%' AND category LIKE '" & t & "%' AND madein LIKE '" & m & "%' AND alert LIKE '" & a & "%' ORDER BY Productname ASC;"
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                gv.Rows.Clear()
                While reader.Read()
                    i = i + 1
                    With gv
                        .Rows.Add(reader(0), i, reader(2), reader(1), reader(8), Decimal.Parse(reader(13)).ToString("N", CultureInfo.InvariantCulture), reader(3), _
                                  reader(4), reader(5), reader(6), reader(7), reader(10), "Edit", "Delete")

                        If reader(10) = "Yes" Then
                            gv.Rows(gv.RowCount - 1).Cells(11).Style.ForeColor = Color.Red
                        Else
                            gv.Rows(gv.RowCount - 1).Cells(11).Style.ForeColor = Color.Black
                        End If
                    End With
                End While
                reader.Close()
                gv.ClearSelection()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub SearchProduct(gv As DataGridView, b As String, c As String, t As String, m As String, a As String, kw As String)
        Try
            Dim sql As String
            Dim i As Integer = 0
            sql = "SELECT * FROM Product as p WHERE (productcode LIKE '" & kw & "%' OR productname LIKE '" & kw & "%' OR CONCAT(productname,' ',unit) LIKE '" & kw & "%') and brand LIKE '" & b & "%' AND class LIKE '" & c & "%' AND category LIKE '" & t & "%' AND madein LIKE '" & m & "%' AND alert LIKE '" & a & "%' ORDER BY Productname ASC;"
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                gv.Rows.Clear()
                While reader.Read()
                    i = i + 1
                    With gv
                        .Rows.Add(reader(0), i, reader(2), reader(1), reader(8), Decimal.Parse(reader(13)).ToString("N", CultureInfo.InvariantCulture), reader(3), _
                                  reader(4), reader(5), reader(6), reader(7), reader(10), "Edit", "Delete")

                        If reader(10) = "Yes" Then
                            gv.Rows(gv.RowCount - 1).Cells(11).Style.ForeColor = Color.Red
                        Else
                            gv.Rows(gv.RowCount - 1).Cells(11).Style.ForeColor = Color.Black
                        End If
                    End With
                End While
                reader.Close()
                gv.ClearSelection()
            End If
        Catch ex As Exception
        End Try
    End Sub
End Class
