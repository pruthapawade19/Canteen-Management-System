Imports MySql.Data.MySqlClient

Public Class Place_order
    Dim SqlConn As New MySqlConnection
    Dim SqlCmd As New MySqlCommand
    Dim SqlRd As MySqlDataReader
    Dim SqlDt As New DataTable

    Dim server As String = "localhost"
    Dim username As String = "root"
    Dim password As String = "amey"
    Dim database As String = "canteen_management_system"

    Dim SqlQuery As String

    Dim itemId As Integer
    Dim itemPrice As Integer

    Private Sub updateTable()
        SqlConn.ConnectionString = "server=" + server + ";" + "user id=" + username + ";" _
        + "password=" + password + ";" + "database=" + database

        SqlConn.Open()
        SqlCmd.Connection = SqlConn
        SqlCmd.CommandText = "SELECT * FROM canteen_management_system.food_item_list"
        SqlRd = SqlCmd.ExecuteReader
        SqlDt.Load(SqlRd)
        SqlRd.Close()
        SqlConn.Close()
        DataGridView1.DataSource = SqlDt
    End Sub
    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles TextBoxCustomerId.TextChanged

    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBoxFirstName.TextChanged

    End Sub

    Private Sub Place_order_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        updateTable()
        SqlConn.ConnectionString = "server=" + server + ";" + "user id=" + username + ";" _
        + "password=" + password + ";" + "database=" + database
        Try
            SqlConn.Open()
            SqlQuery = "select * from canteen_management_system.orders_list where customer_id = " & Customer_login.logedCustomerId

            SqlCmd = New MySqlCommand(SqlQuery, SqlConn)
            SqlRd = SqlCmd.ExecuteReader
            While SqlRd.Read
                TextBoxFirstName.Text = SqlRd.GetString("first_name") + " " + SqlRd.GetString("last_name")
            End While

            SqlConn.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            SqlConn.Dispose()
        End Try
        TextBoxCustomerId.Text = Customer_login.logedCustomerId

        Try
            SqlConn.Open()
            SqlQuery = "select * from canteen_management_system.food_categories"

            SqlCmd = New MySqlCommand(SqlQuery, SqlConn)
            SqlRd = SqlCmd.ExecuteReader
            While SqlRd.Read
                ComboBoxCategary.Items.Add(SqlRd.GetString("food_category"))
            End While

            SqlConn.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            SqlConn.Dispose()
        End Try
    End Sub

    Private Sub ComboBoxItemName_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxItemName.SelectedIndexChanged
        SqlConn.ConnectionString = "server=" + server + ";" + "user id=" + username + ";" _
        + "password=" + password + ";" + "database=" + database
        Try
            SqlConn.Open()
            SqlQuery = "select * from canteen_management_system.food_items where item_name = @item_name"

            SqlCmd = New MySqlCommand(SqlQuery, SqlConn)
            SqlCmd.Parameters.Add("@item_name", MySqlDbType.VarChar).Value = ComboBoxItemName.Text
            SqlRd = SqlCmd.ExecuteReader
            While SqlRd.Read
                itemId = SqlRd.GetString("item_id")
                itemPrice = SqlRd.GetString("unit_price")
            End While
            MessageBox.Show(itemPrice)
            SqlConn.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            SqlConn.Dispose()
        End Try
    End Sub

    Private Sub TextBoxTotalPrice_TextChanged(sender As Object, e As EventArgs) Handles TextBoxTotalPrice.TextChanged

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBoxCategary.SelectedIndexChanged
        SqlConn.ConnectionString = "server=" + server + ";" + "user id=" + username + ";" _
        + "password=" + password + ";" + "database=" + database

        Try
            SqlConn.Open()
            SqlQuery = "select * from canteen_management_system.food_item_list WHERE food_category = @category"
            SqlCmd = New MySqlCommand(SqlQuery, SqlConn)
            SqlCmd.Parameters.Add("@category", MySqlDbType.VarChar).Value = ComboBoxCategary.Text
            SqlRd = SqlCmd.ExecuteReader
            ComboBoxItemName.Items.Clear()
            While SqlRd.Read
                ComboBoxItemName.Items.Add(SqlRd.GetString("item_name"))
            End While
            SqlConn.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            SqlConn.Dispose()
        End Try
    End Sub

    Private Sub TextBoxQuentity_TextChanged(sender As Object, e As EventArgs) Handles TextBoxQuantity.TextChanged
        Try

            TextBoxTotalPrice.Text = itemPrice * TextBoxQuantity.Text
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        SqlConn.ConnectionString = "server=" + server + ";" + "user id=" + username + ";" _
        + "password=" + password + ";" + "database=" + database
        Try
            SqlConn.Open()
            SqlQuery = "Insert into canteen_management_system.orders(item_id,customer_id,quantity,price) values(" & itemId & "," & TextBoxCustomerId.Text & "," & TextBoxQuantity.Text & "," & TextBoxTotalPrice.Text & ")"

            SqlCmd = New MySqlCommand(SqlQuery, SqlConn)
            SqlRd = SqlCmd.ExecuteReader
            SqlConn.Close()
            MessageBox.Show("Order Placed!")
            Me.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message, "Food items", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Finally
            SqlConn.Dispose()
        End Try
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        ComboBoxCategary.Text = ""
        ComboBoxItemName.Text = ""
        TextBoxQuantity.Text = ""
        TextBoxTotalPrice.Text = ""
        TextBox3.Text = ""
    End Sub
End Class