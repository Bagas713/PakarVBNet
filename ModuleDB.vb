Imports MySql.Data.MySqlClient
Module mdlFungsiUmun
    Dim serv As String = "Server = localhost" & ";"
    Dim dbase As String = "Database = diagnosiskerusakan" & ";"
    Dim uid As String = "uid = root" & ";"
    Dim pwd As String = "pwd = " & ";"
    Dim ConString = serv & dbase & uid & pwd & "default command timeout = 
3600; Allow User Variables = true"
    Public db As New MySqlConnection(ConString)
    Public myCommand As MySqlCommand
    Public myAdapter As MySqlDataAdapter
    Public myDataset As DataSet
    Public myReader As MySqlDataReader
    Public str As String

    Public Sub bukaDB()
        Try
            tutupDB()
            db.Open()
            'MessageBox.Show("Connection Successfully", "Connection", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As MySqlException
            MessageBox.Show("Caution!" & ex.Message, "Connection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End Try
    End Sub
    Public Sub tutupDB()
        If db.State = ConnectionState.Open Then
            db.Close()
        End If
    End Sub

    Public Sub BukaFormLogin(formRegistrasi As Form)
        Dim formLogin As New Form1()
        formLogin.Show()
    End Sub

    Public Sub BukaMenuUtama(formRegistrasi As Form)
        Dim formUtama As New Form2()
        formUtama.Show()
    End Sub

    Public Sub register(ByVal namaLengkap As String, ByVal username As String,
    ByVal password As String, ByVal retypePassword As String)
        ' Validasi input data
        If String.IsNullOrWhiteSpace(namaLengkap) Then
            MessageBox.Show("Nama lengkap harus diisi.")
            Return
        End If

        If String.IsNullOrWhiteSpace(username) Then
            MessageBox.Show("Username harus diisi.")
            Return
        End If

        If String.IsNullOrWhiteSpace(password) Then
            MessageBox.Show("Password harus diisi.")
            Return
        End If

        If String.IsNullOrWhiteSpace(retypePassword) Then
            MessageBox.Show("Ketik ulang password harus diisi.")
            Return
        End If

        ' Verifikasi password di-retype
        If password <> retypePassword Then
            MessageBox.Show("Password yang di-retype tidak cocok. Silakan ketik ulang password dengan benar.")
            Return
        End If

        myCommand = New MySqlCommand
        myCommand.Connection = db
        myCommand.CommandText = "INSERT INTO users (namaLengkap, username, password, level) VALUES 
(@namaLengkap, @username, @password, @level)"
        myCommand.Parameters.AddWithValue("@namaLengkap", namaLengkap)
        myCommand.Parameters.AddWithValue("@username", username)
        myCommand.Parameters.AddWithValue("@password", password)
        myCommand.Parameters.AddWithValue("@level", "user")
        Try
            bukaDB()
            myCommand.ExecuteNonQuery()
            MessageBox.Show("Registrasi berhasil! Anda telah terdaftar sebagai user.")
            ' Setelah berhasil mendaftar, Anda bisa membuka form lain atau melakukan tindakan lainnya.

        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan saat mendaftar: " & ex.Message)
        End Try
    End Sub


    Public Function ValidateLogin(username As String, password As String) As Boolean
        Dim query As String = "SELECT * FROM users WHERE username = @username AND password = @password"

        Try
            bukaDB()

            ' Initialize MySqlCommand here
            Using myCommand As New MySqlCommand(query, db)
                myCommand.Parameters.AddWithValue("@username", username)
                myCommand.Parameters.AddWithValue("@password", password)

                ' Gunakan ExecuteReader untuk mendapatkan data hasil query
                Dim myReader As MySqlDataReader = myCommand.ExecuteReader()

                ' Jika data pengguna ditemukan (baris data ada), maka login berhasil
                If myReader.HasRows Then
                    myReader.Close() ' Tutup koneksi jika sudah tidak diperlukan
                    Return True
                Else
                    myReader.Close() ' Tutup koneksi jika sudah tidak diperlukan
                    Return False
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan: " & ex.Message)
        End Try

        ' Jika terjadi kesalahan saat login, kembalikan nilai False
        Return False
    End Function




    ' Fungsi untuk melakukan logout dan menghapus informasi login pengguna
    Public Sub DoLogout()

        If Form2.Instance IsNot Nothing Then
            Form2.Instance.Close()
        End If

        If FormProfile.Instance IsNot Nothing Then
            FormProfile.Instance.Close()
        End If

        Form1.Show()
    End Sub

    Public Sub DoLogout1()

        If FormProfile.Instance IsNot Nothing Then
            FormProfile.Instance.Close()
        End If
        Form1.Show()
    End Sub


    Public Function GetUserIdByUsername(username As String) As Integer
        Dim query As String = "SELECT id FROM users WHERE username = @username"
        Dim userId As Integer = -1 ' Default value jika ID tidak ditemukan

        Try
            bukaDB()
            Using myCommand As New MySqlCommand(query, db)
                myCommand.Parameters.AddWithValue("@username", username)
                Dim result As Object = myCommand.ExecuteScalar()

                If result IsNot Nothing AndAlso Not DBNull.Value.Equals(result) Then
                    userId = Convert.ToInt32(result)
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan saat mengambil data pengguna: " & ex.Message)
        Finally
            tutupDB()
        End Try

        Return userId
    End Function


    Public Sub ubahProfile(namaLengkap As String, username As String, password As String, id As Integer)
        Try
            bukaDB()

            ' Update data profil pengguna berdasarkan ID pengguna
            Using myCommand As New MySqlCommand("UPDATE users SET namaLengkap = @namaLengkap, username = @username WHERE id = @id", db)
                myCommand.Parameters.AddWithValue("@namaLengkap", namaLengkap)
                myCommand.Parameters.AddWithValue("@username", username)
                myCommand.Parameters.AddWithValue("@id", id)
                myCommand.ExecuteNonQuery()
            End Using

            ' Jika password tidak kosong, update juga password pengguna
            If Not String.IsNullOrEmpty(password) Then
                ubahPassword(password, id)
            End If

            MessageBox.Show("Data profil berhasil diperbarui.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan saat memperbarui data profil: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            tutupDB()
        End Try
    End Sub

    Public Sub ubahPassword(password As String, id As Integer)
        Try
            bukaDB()

            ' Update password pengguna berdasarkan ID pengguna
            Using myCommand As New MySqlCommand("UPDATE users SET password = @password WHERE id = @id", db)
                myCommand.Parameters.AddWithValue("@password", password)
                myCommand.Parameters.AddWithValue("@id", id)
                myCommand.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan saat memperbarui password: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            tutupDB()
        End Try
    End Sub

    Public Sub SaveDiagnosisData(kerusakan As String, hasilDiagnosis As String)
        Dim query As String = "INSERT INTO hasil_diagnosisi ( kerusakan, hasilDiagnosis) VALUES (@kerusakan, @hasilDiagnosis)"

        Try
            bukaDB()
            Using myCommand As New MySqlCommand(query, db)
                myCommand.Parameters.AddWithValue("@kerusakan", kerusakan)
                myCommand.Parameters.AddWithValue("@hasilDiagnosis", hasilDiagnosis)
                myCommand.ExecuteNonQuery()
            End Using
        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan saat menyimpan data diagnosis: " & ex.Message)
        Finally
            tutupDB()
        End Try
    End Sub

    Public Function GetUserRoleByUsername(username As String) As String
        Dim query As String = "SELECT level FROM users WHERE username = @username"
        Dim level As String = ""

        Try
            bukaDB()
            Using myCommand As New MySqlCommand(query, db)
                myCommand.Parameters.AddWithValue("@username", username)
                Dim result As Object = myCommand.ExecuteScalar()

                If result IsNot Nothing AndAlso Not DBNull.Value.Equals(result) Then
                    level = Convert.ToString(result)
                End If
            End Using
        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan saat mengambil data peran pengguna: " & ex.Message)
        Finally
            tutupDB()
        End Try

        Return level
    End Function

    Public Function getUsers() As DataTable
        Dim myDataTable As DataTable
        Try
            bukaDB()
            myCommand = New MySqlCommand("SELECT * FROM users ORDER BY 
    id", db)
            myAdapter = New MySqlDataAdapter(myCommand)
            myDataset = New DataSet
            myAdapter.Fill(myDataset, "id")
            myDataTable = myDataset.Tables(0)
            Return (myDataTable)
        Catch ex As Exception
            MsgBox(ex.Message)
            Return Nothing
        Finally
            tutupDB()
        End Try
    End Function

    Public Sub hapus_menu(ByVal username As String)
        myCommand = New MySqlCommand
        myCommand.Connection = db
        myCommand.CommandText = "DELETE FROM users WHERE username = @username"
        myCommand.Parameters.AddWithValue("@username", username)
        Try
            bukaDB()
            myCommand.ExecuteNonQuery()
            bersih_menu()
            tutupDB()
        Catch ex As Exception
            MsgBox(ex.Message)
            MsgBox("Gagal menghapus data")
        Finally
            tutupDB()
        End Try
    End Sub


    Public Sub bersih_menu()
        With FormAkunProfile
            .TextBox1.Text = ""
            .TextBox2.Text = ""
            .TextBox3.Text = ""
            .ComboBox1.Text = ""
        End With
    End Sub

    Public Sub ubahProfile1(namaLengkap As String, username As String, password As String)
        Try
            bukaDB()
            Using myCommand As New MySqlCommand("UPDATE users SET namaLengkap = @namaLengkap, password = @password WHERE username = @username", db)
                myCommand.Parameters.AddWithValue("@namaLengkap", namaLengkap)
                myCommand.Parameters.AddWithValue("@username", username)
                myCommand.Parameters.AddWithValue("@password", password)
                myCommand.ExecuteNonQuery()
            End Using
            MessageBox.Show("Data profil berhasil diperbarui.", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan saat memperbarui data profil: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try

    End Sub

    Public Sub ubahUserRole(username As String, role As String)
        ' ...
        ' Ubah query menjadi menggunakan kondisi WHERE username = @username
        Using myCommand As New MySqlCommand("UPDATE users SET level = @level WHERE username = @username", db)
            myCommand.Parameters.AddWithValue("@level", role)
            myCommand.Parameters.AddWithValue("@username", username)
            myCommand.ExecuteNonQuery()
        End Using
        ' ...
    End Sub

    Public Sub SimpanUlasan(ulasan As String)
        Try
            bukaDB()

            ' Query SQL untuk menyimpan ulasan ke dalam tabel ulasan
            Dim query As String = "INSERT INTO ulasan (ulasan) VALUES (@ulasan)"
            Using myCommand As New MySqlCommand(query, db)
                myCommand.Parameters.AddWithValue("@ulasan", ulasan)
                myCommand.ExecuteNonQuery()
            End Using

            MessageBox.Show("Ulasan berhasil disimpan!", "Sukses", MessageBoxButtons.OK, MessageBoxIcon.Information)
            
        Catch ex As Exception
            MessageBox.Show("Terjadi kesalahan saat menyimpan ulasan: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        Finally
            tutupDB()
        End Try
    End Sub


End Module
