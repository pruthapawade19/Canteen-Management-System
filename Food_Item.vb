Imports MySql.Data.MySqlClient

Public Class Food_Item
    Dim SqlConn As New MySqlConnection
    Dim SqlCmd As New MySqlCommand
    Dim SqlRd As MySqlDataReader
    Dim SqlDt As New DataTable
    
    Dim server As String = "localhost"
    Dim username As String = "root"
    Dim password As String = "amey"
    Dim database As String = "canteen_management_system"

    Dim SqlQuery As String

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

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Food_Item_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        updateTable()
    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs)
        Dim iCancel As DialogResult
        iCancel = MessageBox.Show("Do you want to cancel?", "Food items", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        If iCancel = DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnSubmit.Click

        SqlConn.ConnectionString = "server=" + server + ";" + "user id=" + username + ";" _
        + "password=" + password + ";" + "database=" + database
        Try
            SqlConn.Open()
            SqlQuery = "Insert into canteen_management_system.food_items(item_id,item_name,unit_price,food_category_no) value(" & txtItemId.Text & ",'" & txtItemName.Text & "'," & txtUnitPrice.Text & "," & txtFoodCategoryNo.Text & ")"

            SqlCmd = New MySqlCommand(SqlQuery, SqlConn)
            SqlRd = SqlCmd.ExecuteReader
            SqlConn.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Food items", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Finally
            SqlConn.Dispose()
        End Try
        updateTable()
    End Sub

    Private Sub MaskedTextBox4_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles txtItemName.MaskInputRejected

    End Sub

    Private Sub Button1_Click_1(sender As Object, e As EventArgs) Handles btnDelete.Click
        SqlConn.ConnectionString = "server=" + server + ";" + "user id=" + username + ";" _
        + "password=" + password + ";" + "database=" + database
        Try
            SqlConn.Open()
            SqlQuery = "DELETE FROM canteen_management_system.food_items WHERE item_id = " & txtItemId.Text

            SqlCmd = New MySqlCommand(SqlQuery, SqlConn)
            SqlRd = SqlCmd.ExecuteReader
            SqlConn.Close()

        Catch ex As Exception
            MessageBox.Show(ex.Message, "Food items", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Finally
            SqlConn.Dispose()
        End Try
        For Each row As DataGridViewRow In DataGridView1.SelectedRows
            DataGridView1.Rows.Remove(row)
        Next
        updateTable()
    End Sub

    Private Sub btnUpdate_Click(sender As Object, e As EventArgs) Handles btnUpdate.Click

        SqlConn.ConnectionString = "server=" + server + ";" + "user id=" + username + ";" _
       + "password=" + password + ";" + "database=" + database

        SqlConn.Open()

        SqlCmd.Connection = SqlConn
        SqlQuery = "update canteen_management_system.food_items set item_name = '" & txtItemName.Text & "', unit_price = " & Integer.Parse(txtUnitPrice.Text) & ", food_category_no = " & Integer.Parse(txtFoodCategoryNo.Text) & " where item_id = " & Integer.Parse(txtItemId.Text)

        SqlCmd = New MySqlCommand(SqlQuery, SqlConn)

        SqlCmd.ExecuteNonQuery()
        SqlConn.Close()
        updateTable()

    End Sub

    Private Sub DataGridView1_cellclick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellClick
        Try
            txtItemId.Enabled = False
            txtItemId.Text = DataGridView1.SelectedRows(0).Cells(0).Value.ToString
            txtItemName.Text = DataGridView1.SelectedRows(0).Cells(1).Value.ToString
            txtUnitPrice.Text = DataGridView1.SelectedRows(0).Cells(2).Value.ToString
            txtFoodCategoryNo.Text = DataGridView1.SelectedRows(0).Cells(3).Value.ToString
        Catch ex As Exception

        End Try
    End Sub

    Private Sub txtSearch_MaskInputRejected(sender As Object, e As MaskInputRejectedEventArgs) Handles txtSearch.MaskInputRejected

    End Sub

    Private Sub txtSearch_KeyPress(sender As Object, e As KeyPressEventArgs) Handles txtSearch.KeyPress
        Try
            If Asc(e.KeyChar) = 13 Then
                Dim dv As DataView
                dv = SqlDt.DefaultView
                dv.RowFilter = String.Format("item_name Like '%{0}%'", txtSearch.Text)
                DataGridView1.DataSource = dv.ToTable()
            End If
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Button1_Click_2(sender As Object, e As EventArgs) Handles Button1.Click
        txtItemId.Enabled = True
        txtItemId.Text = ""
        txtItemName.Text = ""
        txtSearch.Text = ""
        txtFoodCategoryNo.Text = ""
        txtUnitPrice.Text = ""
    End Sub
End Class
