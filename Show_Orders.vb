Imports MySql.Data.MySqlClient

Public Class Show_Orders
    Dim SqlConn As New MySqlConnection
    Dim SqlCmd As New MySqlCommand
    Dim SqlRd As MySqlDataReader
    Dim SqlDt As New DataTable

    Dim server As String = "localhost"
    Dim username As String = "root"
    Dim password As String = "amey"
    Dim database As String = "canteen_management_system"

    Dim SqlQuery As String

    Private bitmap As Bitmap

    Private Sub updateTable()
        SqlConn.ConnectionString = "server=" + server + ";" + "user id=" + username + ";" _
        + "password=" + password + ";" + "database=" + database

        SqlConn.Open()
        SqlCmd.Connection = SqlConn
        SqlCmd.CommandText = "SELECT * FROM canteen_management_system.orders_list"
        SqlRd = SqlCmd.ExecuteReader
        SqlDt.Load(SqlRd)
        SqlRd.Close()
        SqlConn.Close()
        DataGridView1.DataSource = SqlDt
    End Sub
    Private Sub Show_Orders_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        updateTable()
    End Sub
End Class