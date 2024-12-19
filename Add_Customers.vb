Imports MySql.Data.MySqlClient

Public Class Add_Customers
    Dim SqlConn As New MySqlConnection
    Dim SqlCmd As New MySqlCommand
    Dim SqlRd As MySqlDataReader
    Dim SqlDt As New DataTable
    Dim SqlQuery As String

    Dim server As String = "localhost"
    Dim username As String = "root"
    Dim password As String = "amey"
    Dim database As String = "canteen_management_system"

    Private Sub ButtonRegister_Click(sender As Object, e As EventArgs) Handles ButtonRegister.Click
        SqlConn.ConnectionString = "server=" + server + ";" + "user id=" + username + ";" _
        + "password=" + password + ";" + "database=" + database
        Try
            SqlConn.Open()
            SqlQuery = "Insert into canteen_management_system.customers values(" & txtCustomerId.Text & ",'" & txtFirstName.Text & "','" & txtLastName.Text & "','" & DateTimePickerDOB.Text & "','" & txtAddress.Text & "','" & txtCity.Text & "'," & txtPincode.Text & ",'" & txtPhone.Text & "')"
            SqlCmd = New MySqlCommand(SqlQuery, SqlConn)
            SqlRd = SqlCmd.ExecuteReader
            SqlConn.Close()

            SqlConn.Open()
            SqlQuery = "Insert into canteen_management_system.login_info values(" & txtCustomerId.Text & ",'" & TextBoxUsername.Text & "','" & TextBoxPassword.Text & "')"
            SqlCmd = New MySqlCommand(SqlQuery, SqlConn)
            SqlRd = SqlCmd.ExecuteReader
            MessageBox.Show("Registration Successful!!")
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Food items", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Finally
            SqlConn.Dispose()
        End Try
        Me.Close()
    End Sub

    Private Sub Add_Customers_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub
End Class