Imports MySql.Data.MySqlClient
Imports Mysqlx.XDevAPI.Common

Public Class FormProfile
    Public Shared Property Instance As FormProfile
    Public Property userId As Integer
    Private Sub FormProfile_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Ambil data profil pengguna dari database berdasarkan ID pengguna yang berhasil login
        Dim query As String = "SELECT namaLengkap, username, password FROM users WHERE id = @userId"

        Try
            bukaDB()
            Using myCommand As New MySqlCommand(query, db)
                myCommand.Parameters.AddWithValue("@userId", userId) ' Gunakan properti userId di sini
                Dim reader As MySqlDataReader = myCommand.ExecuteReader()

                If reader.Read() Then
                    ' Set nilai TextBox sesuai dengan data profil yang diambil dari database
                    TextBox1.Text = reader("namaLengkap").ToString()
                    TextBox2.Text = reader("username").ToString()
                    TextBox3.Text = reader("password").ToString()
                End If

                reader.Close()
            End Using
        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan saat mengambil data profil: " & ex.Message)
        Finally
            tutupDB()
        End Try
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        ' Cek apakah pengguna menekan tombol "Yes" pada MessageBox

        ' Panggil fungsi DoLogout dari mdlFungsiUmun untuk logout.

        ' Tampilkan kembali form login setelah logout
        Form2.Show()
        Hide()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Try
            ' Perbarui data profil pengguna berdasarkan ID pengguna yang berhasil login
            Dim userId As Integer = Form1.loggedInUserId
            ubahProfile(TextBox1.Text, TextBox2.Text, TextBox3.Text, userId)
        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan saat memperbarui data profil: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub
End Class
