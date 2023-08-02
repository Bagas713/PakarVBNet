Imports System.Windows.Forms.VisualStyles.VisualStyleElement
Imports System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel
Imports MySql.Data.MySqlClient

Public Class Form1
    Public loggedInUserId As Integer

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bukaDB()
        TextBox2.UseSystemPasswordChar = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim username As String = TextBox1.Text
        Dim password As String = TextBox2.Text

        If ValidateLogin(username, password) Then
            ' Jika login berhasil, set variabel global untuk menyimpan informasi pengguna yang login
            SessionModule.loggedInUser = username

            ' Set loggedInUserId dengan ID pengguna yang berhasil login
            Me.loggedInUserId = GetUserIdByUsername(username)

            ' Cek peran pengguna yang berhasil login
            Dim level As String = GetUserRoleByUsername(username)

            ' Tampilkan form yang sesuai berdasarkan peran pengguna
            If level = "admin" Then
                ' Jika admin yang login, tampilkan form Akun
                Dim formAkun As New FormAkun()
                formAkun.Show()
            Else
                ' Jika user biasa yang login, tampilkan form Profile
                Dim formProfile As New FormProfile()
                Form2.Show()
            End If

            ' Tutup form login setelah berhasil login dan menampilkan form sesuai peran


        Else
            MessageBox.Show("Login gagal. Periksa kembali username dan password Anda.", "Login Gagal", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        FormRegister.Show()
        Me.Hide()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim result As DialogResult = MessageBox.Show("Apakah Anda yakin ingin keluar dari aplikasi?", "Konfirmasi Keluar", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        ' Cek apakah pengguna menekan tombol "Yes" pada MessageBox
        If result = DialogResult.Yes Then

        End If
        ' Panggil fungsi DoLogout dari SessionModule untuk logout jika diperlukan
        ' (jika aplikasi memerlukan proses logout sebelum keluar)
        ' SessionModule.DoLogout()

        ' Keluar dari aplikasi sepenuhnya
        Application.Exit()
    End Sub

End Class