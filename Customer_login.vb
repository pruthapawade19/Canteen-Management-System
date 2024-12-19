Imports MySql.Data.MySqlClient

Public Class Customer_login
    Dim SqlConn As New MySqlConnection
    Dim SqlCmd As New MySqlCommand
    Dim SqlDt As New DataTable
    Dim SqlQuery As String
    Dim sqlDta As MySqlDataAdapter

    Dim server As String = "localhost"
    Dim username As String = "root"
    Dim password As String = "amey"
    Dim database As String = "canteen_management_system"

    Public logedCustomerId As Integer

    Private Sub Customer_login_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles txtCustomerUsername.TextChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        txtCustomerUsername.Text = ""
        txtCustomerPassword.Text = ""
    End Sub

    Public Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SqlConn.ConnectionString = "server=" + server + ";" + "user id=" + username + ";" _
        + "password=" + password + ";" + "database=" + database

        SqlConn.Open()

        SqlCmd.Connection = SqlConn
        SqlQuery = "SELECT customer_id FROM canteen_management_system.login_info WHERE username = @username AND password = @password"

        SqlCmd = New MySqlCommand(SqlQuery, SqlConn)

        SqlCmd.Parameters.Add("@username", MySqlDbType.VarChar).Value = txtCustomerUsername.Text
        SqlCmd.Parameters.Add("@password", MySqlDbType.VarChar).Value = txtCustomerPassword.Text

        sqlDta = New MySqlDataAdapter(SqlCmd)
        sqlDta.Fill(SqlDt)

        If SqlDt.Rows.Count <= 0 Then
            MessageBox.Show("Incorrect Username or Password!")
        Else
            logedCustomerId = CInt(SqlCmd.ExecuteScalar)
            MessageBox.Show("Login Successfully!!")
            Place_order.Show()
        End If
        SqlCmd.ExecuteNonQuery()
        SqlConn.Close()
        Me.Close()
    End Sub
End Class