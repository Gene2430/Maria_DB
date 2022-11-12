Imports System.Linq.Expressions

Module Module1
    Public cn As New ADODB.Connection
    Public rs As New ADODB.Recordset
    Public sql As String

    Public Sub openCon()
        cn = New ADODB.Connection
        cn.ConnectionString = "Driver={MySQL ODBC 8.0 Unicode Driver}; Server=localhost; PWD=admin; UID=root; Port=3306; Database=employee_db;"
        cn.Open()

    End Sub
End Module
