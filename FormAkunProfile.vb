Imports MySql.Data.MySqlClient
Imports Mysqlx.XDevAPI.Common

Public Class FormAkunProfile
    Public Shared Property Instance As FormProfile
    Public Property userId As Integer

    Private Sub FormAkunProfile_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        bukaDB()
        DataGridView1.DataSource = getUsers()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        ' Cek apakah pengguna menekan tombol "Yes" pada MessageBox


        ' Tampilkan kembali form login setelah logout
        FormAkun.Show()
        Hide()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Try
            ' Ambil data dari TextBox dan ComboBox
            Dim namaLengkap As String = TextBox1.Text
            Dim username As String = TextBox2.Text
            Dim password As String = TextBox3.Text
            Dim level As String = ComboBox1.Text

            ' Perbarui data profil pengguna berdasarkan username pengguna
            ubahProfile1(namaLengkap, username, password)

            ' Perbarui level pengguna berdasarkan username pengguna
            ubahUserRole(username, level)

            MessageBox.Show("Data profil berhasil diperbarui.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan saat memperbarui data profil: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

        DataGridView1.DataSource = getUsers() ' Refresh GridView dengan data terbaru
    End Sub

    Private Sub DataGridView1_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.CellContentClick
        If e.RowIndex >= 0 Then
            Dim row As DataGridViewRow = DataGridView1.Rows(e.RowIndex)
            TextBox1.Text = row.Cells("namaLengkap").Value.ToString()
            TextBox2.Text = row.Cells("username").Value.ToString()
            TextBox3.Text = row.Cells("password").Value.ToString()
            ComboBox1.Text = row.Cells("level").Value.ToString()
        End If
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        If DataGridView1.SelectedRows.Count > 0 Then
            Dim selectedUsername As String = DataGridView1.SelectedRows(0).Cells("username").Value.ToString()

            If MessageBox.Show("Apakah Anda yakin ingin menghapus akun " & selectedUsername & "?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
                Try
                    ' Panggil fungsi hapus_menu dengan username pengguna yang dipilih
                    hapus_menu(selectedUsername)

                    ' Refresh GridView setelah menghapus data
                    DataGridView1.DataSource = getUsers()
                Catch ex As Exception
                    MessageBox.Show("Terjadi kesalahan saat menghapus data: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
                End Try
            End If
        Else
            MessageBox.Show("Pilih satu baris data untuk menghapus.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
End Class