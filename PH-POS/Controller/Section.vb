Imports MySql.Data.MySqlClient

Public Class Section

    Public SectionArry As New ArrayList

    Private _Sectionid As Integer
    Public Property SectionID As Integer
        Set(value As Integer)
            _Sectionid = value
        End Set
        Get
            Return _Sectionid
        End Get
    End Property

    Private _Sectionname As String
    Public Property SectionName As String
        Set(value As String)
            _Sectionname = value
        End Set
        Get
            Return _Sectionname
        End Get
    End Property

    Private _SectionDetails As String
    Public Property SectionDetails As String
        Set(value As String)
            _SectionDetails = value
        End Set
        Get
            Return _SectionDetails
        End Get
    End Property

    Public Sub SetSectionDetails(id As Integer)
        Try
            Dim sql As String
            sql = "SELECT * FROM Section WHERE idSection = " & id & ";"
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                While reader.Read()
                    SectionID = reader(0)
                    SectionName = reader(1)
                    SectionDetails = reader(2)
                End While
                reader.Close()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Function AddSection() As Boolean
        Try
            Dim bool As Boolean = False
            Dim sql As String = "INSERT INTO Section (Sectionname,details) VALUES (@0,@1);"
            If IsConnected() = True Then
                ServerExecuteSQL(sql, SectionName, SectionDetails)
                Commit()
                bool = True
            End If
            Return bool
        Catch ex As Exception
            Rollback()
            Return False
        End Try
    End Function

    Public Function EditSection() As Boolean
        Try
            Dim bool As Boolean = False
            Dim sql As String = "UPDATE Section SET Sectionname=@0,details=@1 WHERE idSection = @2;"
            If IsConnected() = True Then
                ServerExecuteSQL(sql, SectionName, SectionDetails, SectionID)
                Commit()
                bool = True
            End If
            Return bool
        Catch ex As Exception
            Rollback()
            Return False
        End Try
    End Function

    Public Function DeleteSection() As Boolean
        Try
            Dim bool As Boolean = False
            Dim sql As String = "DELETE FROM Section WHERE idSection = @0;"
            If IsConnected() = True Then
                ServerExecuteSQL(sql, SectionID)
                Commit()
                bool = True
            End If
            Return bool
        Catch ex As Exception
            Rollback()
            Return False
        End Try
    End Function

    Public Sub LoadSectionToCBO(cbo As ComboBox)
        Try
            Dim sql As String
            sql = "SELECT * FROM Section ORDER BY Sectionname ASC;"
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                cbo.Items.Clear()
                SectionArry.Clear()
                While reader.Read()
                    cbo.Items.Add(reader("Sectionname"))
                    SectionArry.Add(reader("idSection"))
                End While
                reader.Close()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub LoadAllSectionToCBO(cbo As ComboBox)
        Try
            Dim sql As String
            sql = "SELECT * FROM Section ORDER BY Sectionname ASC;"
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                cbo.Items.Clear()
                SectionArry.Clear()
                cbo.Items.Add("All")
                While reader.Read()
                    cbo.Items.Add(reader("Sectionname"))
                    SectionArry.Add(reader("idSection"))
                End While
                reader.Close()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub SearchSection(kw As String, gv As DataGridView)
        Try
            Dim sql As String
            Dim i As Integer = 0
            sql = "SELECT * FROM Section WHERE (Sectionname LIKE '" & kw & "%') ORDER BY Sectionname ASC;"
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                gv.Rows.Clear()
                While reader.Read()
                    i = i + 1
                    With gv
                        .Rows.Add(reader(0), i, reader(1), reader(2), "Edit", "Delete")
                    End With
                End While
                reader.Close()
                gv.ClearSelection()
            End If
        Catch ex As Exception
        End Try
    End Sub
    Public Sub ViewSection(gv As DataGridView)
        Try
            Dim sql As String
            Dim i As Integer = 0
            sql = "SELECT * FROM Section ORDER BY Sectionname ASC;"
            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                gv.Rows.Clear()
                While reader.Read()
                    i = i + 1
                    With gv
                        .Rows.Add(reader(0), i, reader(1), reader(2), "Edit", "Delete")
                    End With
                End While
                reader.Close()
                gv.ClearSelection()
            End If
        Catch ex As Exception
        End Try
    End Sub

    Public Sub ViewStocksInHistory(gv As DataGridView, id As Integer)
        Try
            Dim sql As String
            Dim i As Integer = 0
            sql = "SELECT DISTINCT SECTIONNAME, p.idproduct FROM Product as p INNER JOIN stocks ON p.idproduct=stocks.idproduct INNER JOIN section ON stocks.idsection=section.idsection" _
              & " WHERE p.idproduct=" & id & " ORDER BY sectionname ASC;"

            If IsConnected() = True Then
                Dim cmd = New MySqlCommand(sql, getServerConnection)
                Dim reader As MySqlDataReader = cmd.ExecuteReader()
                gv.Rows.Clear()
                While reader.Read()
                    i = i + 1
                    With gv
                        .Rows.Add(reader(0), i.ToString, reader("sectionname"))
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
