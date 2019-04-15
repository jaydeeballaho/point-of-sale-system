Imports MySql.Data.MySqlClient
Imports System.Globalization

Public Class Stock

    'Stock-In
    Private _stockid As Integer
    Public Property StockID As Integer
        Set(value As Integer)
            _stockid = value
        End Set
        Get
            Return _stockid
        End Get
    End Property

    Private _Productid As Integer
    Public Property ProductID As Integer
        Set(value As Integer)
            _Productid = value
        End Set
        Get
            Return _Productid
        End Get
    End Property

    Private _idsection As Integer
    Public Property SectionID As Integer
        Set(value As Integer)
            _idsection = value
        End Set
        Get
            Return _idsection
        End Get
    End Property

    Private _dos As Date
    Public Property DOS As Date
        Set(value As Date)
            _dos = value
        End Set
        Get
            Return _dos
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

    Private _qty As Double
    Public Property QTY As Double
        Set(value As Double)
            _qty = value
        End Set
        Get
            Return _qty
        End Get
    End Property

    Private _isexpiry As String
    Public Property IsExpiry As String
        Set(value As String)
            _isexpiry = value
        End Set
        Get
            Return _isexpiry
        End Get
    End Property

    Private _doe As Date
    Public Property DOE As Date
        Set(value As Date)
            _doe = value
        End Set
        Get
            Return _doe
        End Get
    End Property

    Private _ProductStatus As String
    Public Property ProductStatus As String
        Set(value As String)
            _ProductStatus = value
        End Set
        Get
            Return _ProductStatus
        End Get
    End Property

    Private _by As String
    Public Property By As String
        Set(value As String)
            _by = value
        End Set
        Get
            Return _by
        End Get
    End Property

    Private _reason As String
    Public Property Reason As String
        Set(value As String)
            _reason = value
        End Set
        Get
            Return _reason
        End Get
    End Property

    Public Sub SetStockDetails(id As Integer)
        Try
            Dim sql As String
            sql = "SELECT * FROM stocks WHERE idstock = " & id & ";"
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    StockID = reader(0)
                    ProductID = reader(1)
                    SectionID = reader(2)
                    DOS = reader(3)
                    Price = reader(4)
                    QTY = reader(5)
                    IsExpiry = reader(6)
                    DOE = reader(7)
                    ProductStatus = reader(8)
                    By = reader(9)
                End While
                reader.Close()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Function AddStocks() As Boolean
        Try
            Dim bool As Boolean = False
            Dim sql As String = "INSERT INTO stocks (idproduct,idsection,dos,sellingpriceperunit,quantity,isexpiry,doe,productstatus,stockby) VALUES (@0,@1,@2,@3,@4,@5,@6,@7,@8);"
            If IsConnected() = True Then
                ServerExecuteSQL(sql, ProductID, SectionID, DOS, Price, QTY, IsExpiry, DOE, ProductStatus, By)
                Commit()
                bool = True
            End If
            Return bool
        Catch ex As Exception
            Rollback()
            Return False
        End Try
    End Function
    Public Function AddStockOut() As Boolean
        Try
            Dim bool As Boolean = False
            Dim sql As String = "INSERT INTO stockout (idproduct,qty,reason,dout,stockoutby,idorder,price) VALUES (@0,@1,@2,@3,@4,@5,@6);"
            If IsConnected() = True Then
                ServerExecuteSQL(sql, ProductID, QTY, Reason, DOS, By, StockID, Price)
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
    Public Sub LoadStatusToCBO(cbo As ComboBox)
        Try
            Dim sql As String
            sql = "SELECT DISTINCT productstatus FROM stocks WHERE productstatus <> '' ORDER BY productstatus ASC;"
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                cbo.Items.Clear()
                While reader.Read()
                    cbo.Items.Add(reader("productstatus"))
                End While
                reader.Close()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub DiffQty(gv As DataGridView, b As String, c As String, t As String, m As String, u As String)
        Try
            Dim sql As String
            Dim i As Integer = 0
            sql = "SELECT p.idproduct,coalesce(sum(qty),0)FROM Product as p LEFT JOIN stockout ON p.idproduct=stockout.idproduct " _
                & "WHERE unit LIKE '" & u & "%' AND brand " _
                & "LIKE '" & b & "%' AND class LIKE '" & c & "%' AND category LIKE '" & t & "%' AND madein LIKE '" & m & "%' " _
                & "GROUP BY p.idproduct ORDER BY Productname ASC;"
            Dim d As String = ""
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                gv.Rows.Clear()
                While reader.Read()
                    i = i + 1
                    With gv
                        .Rows.Add(reader(0), reader(1))
                    End With
                End While
                reader.Close()
                gv.ClearSelection()
            End If
        Catch ex As Exception
            '  MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub Remaining(gv1 As DataGridView, gv2 As DataGridView)
        For Each r As DataGridViewRow In gv1.Rows
            '  r.Cells(6).Value = r.Cells(6).Value - gv2.Rows(r.Index).Cells()
            For Each row As DataGridViewRow In gv2.Rows
                If r.Cells(0).Value = row.Cells(0).Value Then
                    r.Cells(6).Value = r.Cells(6).Value - row.Cells(1).Value
                    If r.Cells(6).Value <= 0 Then
                        r.Cells(6).Style.ForeColor = Color.Red
                        r.Cells(13).Value = ""
                    Else
                        r.Cells(13).Value = "Stock-Out"
                        r.Cells(6).Style.ForeColor = Color.Black
                    End If
                End If
            Next
        Next
    End Sub
    Public Sub Remaining2(gv1 As DataGridView, gv2 As DataGridView)
        For Each r As DataGridViewRow In gv1.Rows
            '  r.Cells(6).Value = r.Cells(6).Value - gv2.Rows(r.Index).Cells()
            For Each row As DataGridViewRow In gv2.Rows
                If r.Cells(0).Value = row.Cells(0).Value Then
                    r.Cells(6).Value = r.Cells(6).Value - row.Cells(1).Value
                    If r.Cells(6).Value <= 0 Then
                        r.Cells(6).Style.ForeColor = Color.Red
                        r.Cells(8).Value = ""
                    Else
                        r.Cells(8).Value = "Add Item"
                        r.Cells(6).Style.ForeColor = Color.Black
                    End If
                End If
            Next
        Next
    End Sub
    Public Sub Remaining3(gv1 As DataGridView, gv2 As DataGridView)
        For Each r As DataGridViewRow In gv1.Rows
            '  r.Cells(6).Value = r.Cells(6).Value - gv2.Rows(r.Index).Cells()
            For Each row As DataGridViewRow In gv2.Rows
                If r.Cells(0).Value = row.Cells(0).Value Then
                    r.Cells(4).Value = r.Cells(4).Value - row.Cells(1).Value
                    If r.Cells(4).Value <= 0 Then
                        r.Cells(4).Style.ForeColor = Color.Red
                        ' r.Cells(8).Value = ""
                    Else
                        ' r.Cells(8).Value = "Add Item"
                        r.Cells(4).Style.ForeColor = Color.Black
                    End If
                End If
            Next
        Next
    End Sub
    Public Sub RemoveStocks(gv1 As DataGridView, gv2 As DataGridView)
        For Each r As DataGridViewRow In gv1.Rows
            If r.Cells(5).Value.ToString() <> "Yes" Then
                gv1.Rows.Remove(r)
            End If
        Next
        gv2.Rows.Clear()
        For Each r As DataGridViewRow In gv1.Rows
            If r.Cells(4).Value > ((r.Cells(6).Value / 100) * r.Cells(7).Value) Then
                gv2.Rows.Add(r.Cells(0).Value)
            End If
        Next
        For Each r As DataGridViewRow In gv2.Rows
            For Each row As DataGridViewRow In gv1.Rows
                If row.Cells(0).Value = r.Cells(0).Value Then
                    gv1.Rows.Remove(row)
                End If
            Next
        Next
        For Each r As DataGridViewRow In gv1.Rows
            r.Cells(1).Value = r.Index + 1
        Next
    End Sub
    Public Sub ViewStocks(gv As DataGridView, b As String, c As String, t As String, m As String, u As String)
        Try
            Dim sql As String
            Dim i As Integer = 0
            sql = "SELECT p.idproduct,productname,productcode,coalesce(sum(quantity),0),unit,p.unitprice," _
                & "brand,sizeweight,class,category,madein FROM Product as p LEFT JOIN stocks ON p.idproduct=stocks.idproduct " _
                & "WHERE unit LIKE '" & u & "%' AND brand " _
                & "LIKE '" & b & "%' AND class LIKE '" & c & "%' AND category LIKE '" & t & "%' AND madein LIKE '" & m & "%' " _
                & "GROUP BY p.idproduct ORDER BY Productname ASC;"
            Dim d As String = ""
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                gv.Rows.Clear()
                While reader.Read()
                    i = i + 1
                    With gv
                        If reader(3) <= 0 Then
                            .Rows.Add(reader(0), i, reader("productname"), reader("productcode"), reader("unit"), _
                                      Decimal.Parse(reader("unitprice")).ToString("N", CultureInfo.InvariantCulture), _
                                      reader("coalesce(sum(quantity),0)"), _
                                      reader("brand"), reader("class"), reader("category"), reader("madein"), _
                                      reader("sizeweight"), "Stock-In", "", "History")
                            .Rows(.RowCount - 1).Cells(6).Style.ForeColor = Color.Red
                        Else
                            .Rows.Add(reader(0), i, reader("productname"), reader("productcode"), reader("unit"), _
                                        Decimal.Parse(reader("unitprice")).ToString("N", CultureInfo.InvariantCulture), _
                                        reader("coalesce(sum(quantity),0)"), _
                                        reader("brand"), reader("class"), reader("category"), reader("madein"), _
                                        reader("sizeweight"), "Stock-In", "Stock-Out", "History")
                            .Rows(.RowCount - 1).Cells(6).Style.ForeColor = Color.Black
                        End If
                    End With
                End While
                reader.Close()
                gv.ClearSelection()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub SearchStocks(gv As DataGridView, b As String, c As String, t As String, m As String, u As String, kw As String)
        Try
            Dim sql As String
            Dim i As Integer = 0
            sql = "SELECT p.idproduct,productname,productcode,coalesce(sum(quantity),0),unit,p.unitprice," _
                & "brand,sizeweight,class,category,madein FROM Product as p LEFT JOIN stocks ON p.idproduct=stocks.idproduct " _
                & "WHERE (productcode LIKE '" & kw & "%' OR productname " _
                & "LIKE '" & kw & "%' OR CONCAT(productname,' ',unit) LIKE '" & kw & "%') AND unit LIKE '" & u & "%' AND brand " _
                & "LIKE '" & b & "%' AND class LIKE '" & c & "%' AND category LIKE '" & t & "%' AND madein LIKE '" & m & "%' " _
                & "GROUP BY p.idproduct ORDER BY Productname ASC;"
            Dim d As String = ""
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                gv.Rows.Clear()
                While reader.Read()
                    i = i + 1
                    With gv
                        If reader(3) <= 0 Then
                            .Rows.Add(reader(0), i, reader("productname"), reader("productcode"), reader("unit"), _
                                      Decimal.Parse(reader("unitprice")).ToString("N", CultureInfo.InvariantCulture), _
                                      reader("coalesce(sum(quantity),0)"), _
                                      reader("brand"), reader("class"), reader("category"), reader("madein"), _
                                      reader("sizeweight"), "Stock-In", "", "History")
                            .Rows(.RowCount - 1).Cells(6).Style.ForeColor = Color.Red
                        Else
                            .Rows.Add(reader(0), i, reader("productname"), reader("productcode"), reader("unit"), _
                                        Decimal.Parse(reader("unitprice")).ToString("N", CultureInfo.InvariantCulture), _
                                        reader("coalesce(sum(quantity),0)"), _
                                        reader("brand"), reader("class"), reader("category"), reader("madein"), _
                                        reader("sizeweight"), "Stock-In", "Stock-Out", "History")
                            .Rows(.RowCount - 1).Cells(6).Style.ForeColor = Color.Black
                        End If
                    End With
                End While
                reader.Close()
                gv.ClearSelection()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub SearchProductInStocks(gv As DataGridView, b As String, c As String, t As String, m As String, u As String, kw As String)
        Try
            Dim sql As String
            Dim i As Integer = 0
            sql = "SELECT p.idproduct,productname,productcode,coalesce(sum(quantity),0),unit,p.unitprice," _
                & "brand,sizeweight,class,category,madein FROM Product as p LEFT JOIN stocks ON p.idproduct=stocks.idproduct " _
                & "WHERE (productcode LIKE '" & kw & "%' OR productname " _
                & "LIKE '" & kw & "%' OR CONCAT(productname,' ',unit) LIKE '" & kw & "%') AND unit LIKE '" & u & "%' AND brand " _
                & "LIKE '" & b & "%' AND class LIKE '" & c & "%' AND category LIKE '" & t & "%' AND madein LIKE '" & m & "%' " _
                & "GROUP BY idproduct ORDER BY Productname ASC;"
            Dim d As String = ""
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                gv.Rows.Clear()
                While reader.Read()
                    i = i + 1
                    With gv
                        If reader(3) <= 0 Then
                            .Rows.Add(reader(0), i, reader("productname"), reader("productcode"), reader("unit"), _
                                      Decimal.Parse(reader("unitprice")).ToString("N", CultureInfo.InvariantCulture), _
                                      reader("coalesce(sum(quantity),0)"), _
                                      reader("brand"),"", "Section")
                            .Rows(.RowCount - 1).Cells(6).Style.ForeColor = Color.Red
                        Else
                            .Rows.Add(reader(0), i, reader("productname"), reader("productcode"), reader("unit"), _
                                        Decimal.Parse(reader("unitprice")).ToString("N", CultureInfo.InvariantCulture), _
                                        reader("coalesce(sum(quantity),0)"), _
                                        reader("brand"), "Add Item", "Section")
                            .Rows(.RowCount - 1).Cells(6).Style.ForeColor = Color.Black
                        End If
                    End With
                End While
                reader.Close()
                gv.ClearSelection()
            End If
        Catch ex As Exception
            '  MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub ViewStocksInHistory(gv As DataGridView, s As String, p As String, d As Boolean, d1 As Date, d2 As Date)
        Try
            Dim sql As String
            Dim i As Integer = 0
            If d = True Then
                sql = "SELECT * FROM Product as p INNER JOIN stocks ON p.idproduct=stocks.idproduct INNER JOIN section ON stocks.idsection=section.idsection" _
                & " WHERE sectionname LIKE '" & s & "%' AND (productcode LIKE '" & p & "%') " _
                & " AND DATE(dos) >= DATE('" & d1.ToString("yyyy-MM-dd") & "') AND DATE(dos) <= DATE('" & d2.ToString("yyyy-MM-dd") & "') ORDER BY dos DESC;"
            Else
                sql = "SELECT * FROM Product as p INNER JOIN stocks ON p.idproduct=stocks.idproduct INNER JOIN section ON stocks.idsection=section.idsection" _
                & " WHERE sectionname LIKE '" & s & "%' AND (productcode LIKE '" & p & "%') ORDER BY dos DESC;"
            End If

            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                gv.Rows.Clear()
                While reader.Read()
                    i = i + 1
                    With gv
                        If reader("isexpiry") = "Yes" Then
                            .Rows.Add(reader("idstock"), i.ToString(), reader("productname"), reader("productcode"), reader("unit"), _
                                  Decimal.Parse(reader("sellingpriceperunit")).ToString("N", CultureInfo.InvariantCulture), _
                                  Date.Parse(reader("dos")).ToShortDateString(), reader("quantity"), reader("sectionname"), _
                                  Date.Parse(reader("doe")).ToShortDateString(), reader("productstatus"), reader("stockby"))
                        Else
                            .Rows.Add(reader("idstock"), i.ToString(), reader("productname"), reader("productcode"), reader("unit"), _
                                 Decimal.Parse(reader("sellingpriceperunit")).ToString("N", CultureInfo.InvariantCulture), _
                                 Date.Parse(reader("dos")).ToShortDateString(), reader("quantity"), reader("sectionname"), _
                                 "", reader("productstatus"), reader("stockby"))
                        End If
                    End With
                End While
                reader.Close()
                gv.ClearSelection()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub ViewExpiring(gv As DataGridView)
        Try
            Dim sql As String
            Dim i As Integer = 0
            sql = "SELECT * FROM Product as p INNER JOIN stocks ON p.idproduct=stocks.idproduct INNER JOIN section ON stocks.idsection=section.idsection" _
                & " WHERE DATEDIFF (Now(),doe) >= 7 ORDER BY doe DESC"
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                gv.Rows.Clear()
                While reader.Read()
                    i = i + 1
                    With gv
                        If reader("isexpiry") = "Yes" Then
                            .Rows.Add(reader("idstock"), gv.RowCount + 1, reader("productname"), _
                                  reader("quantity"), reader("sectionname"), _
                                  Date.Parse(reader("doe")).ToShortDateString())
                        End If
                    End With
                End While
                reader.Close()
                gv.ClearSelection()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub

    Public Sub ViewStocksNotification(gv As DataGridView, b As String, c As String, t As String, m As String, u As String)
        Try
            Dim sql As String
            Dim i As Integer = 0
            sql = "SELECT p.idproduct,productname,productcode,coalesce(sum(quantity),0),unit,p.unitprice," _
                & "brand,sizeweight,class,category,madein,alert,stocktoalert,maxstock FROM Product as p LEFT JOIN stocks ON p.idproduct=stocks.idproduct " _
                & "WHERE unit LIKE '" & u & "%' AND brand " _
                & "LIKE '" & b & "%' AND class LIKE '" & c & "%' AND category LIKE '" & t & "%' AND madein LIKE '" & m & "%' " _
                & "GROUP BY stocks.idproduct ORDER BY Productname ASC;"
            Dim d As String = ""
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                gv.Rows.Clear()
                While reader.Read()
                    i = i + 1
                    With gv
                        If reader(3) <= 0 Then
                            .Rows.Add(reader(0), i, reader("productname"), reader("unit"), _
                                      reader("coalesce(sum(quantity),0)"), reader("alert"), reader("stocktoalert"), reader("maxstock"))
                            .Rows(.RowCount - 1).Cells(3).Style.ForeColor = Color.Red
                        Else
                            .Rows.Add(reader(0), i, reader("productname"), reader("unit"), _
                                    reader("coalesce(sum(quantity),0)"), reader("alert"), reader("stocktoalert"), reader("maxstock"))
                            .Rows(.RowCount - 1).Cells(3).Style.ForeColor = Color.Black
                        End If
                    End With
                End While
                reader.Close()
                gv.ClearSelection()
            End If
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
    End Sub
    Public Sub ViewStockOutHistory(gv As DataGridView, p As String, d As Boolean, d1 As Date, d2 As Date)
        Try
            Dim sql As String
            Dim i As Integer = 0
            If d = True Then
                sql = "SELECT * FROM Product as p INNER JOIN stockout ON p.idproduct=stockout.idproduct " _
                & "WHERE stockout.reason <> 'Paid' AND (productcode LIKE '" & p & "%') " _
                & "AND DATE(dout) >= DATE('" & d1.ToString("yyyy-MM-dd") & "') AND DATE(dout) <= DATE('" & d2.ToString("yyyy-MM-dd") & "') ORDER BY dout DESC;"
            Else
                sql = "SELECT * FROM Product as p INNER JOIN stockout ON p.idproduct=stockout.idproduct " _
                & "WHERE stockout.reason <> 'Paid' AND (productcode LIKE '" & p & "%') ORDER BY dout DESC;"
            End If

            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                gv.Rows.Clear()
                While reader.Read()
                    i = i + 1
                    With gv
                        .Rows.Add(reader("idstockout"), i.ToString(), reader("productname"), reader("productcode"), reader("unit"), _
                                 Decimal.Parse(reader("unitprice")).ToString("N", CultureInfo.InvariantCulture), _
                                 Date.Parse(reader("dout")).ToShortDateString(), reader("qty"), reader("stockoutby"))
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
