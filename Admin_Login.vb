Public Class Admin_Login
    Private Sub Label3_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub Admin_Login_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub Label3_Click_1(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If txtAdminUsername.Text = "admin" And txtAdminPasswrd.Text = "admin" Then
            Me.Close()
            Admin_Home.Show()
            MessageBox.Show("login successfully!")
        Else
            MessageBox.Show("Incorrect Username or Password!!")
        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        txtAdminPasswrd.Text = ""
        txtAdminUsername.Text = ""
    End Sub
End Class