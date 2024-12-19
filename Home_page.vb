Public Class Home_page
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Customer_login.Show()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Admin_Login.Show()
    End Sub

    Private Sub Home_page_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnNewCustomer_Click(sender As Object, e As EventArgs) Handles btnNewCustomer.Click
        Add_Customers.Show()
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Application.Exit()
    End Sub
End Class
