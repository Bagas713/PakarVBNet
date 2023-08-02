

Public Class FormRegister
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form1.Show()
        Me.Hide()
    End Sub

    Private Sub FormRegister_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bukaDB()
        TextBox3.UseSystemPasswordChar = True
        TextBox4.UseSystemPasswordChar = True
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            register(TextBox1.Text, TextBox2.Text, TextBox3.Text, TextBox4.Text)
            BukaFormLogin(Me)
        Catch ex As Exception

        End Try
    End Sub

    Private Sub LinkLabel1_LinkClicked(sender As Object, e As LinkLabelLinkClickedEventArgs) Handles LinkLabel1.LinkClicked
        BukaFormLogin(Me)
    End Sub

End Class