Public Class Form2
    Public Shared Property Instance As Form2

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        FormSistem.Show()
        Me.Hide()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        FormTentang.Show()
        Me.Hide()
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Dim result As DialogResult = MessageBox.Show("Apakah Anda yakin ingin keluar?", "Konfirmasi Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

        ' Cek apakah pengguna menekan tombol "Yes" pada MessageBox
        If result = DialogResult.Yes Then
            ' Panggil fungsi DoLogout dari mdlFungsiUmun untuk logout.
            DoLogout()

            ' Tampilkan kembali form login setelah logout
            Form1.Show()
            Me.Close()
        End If
    End Sub

    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Form2.Instance = Me
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        ' Dapatkan ID pengguna yang berhasil login
        Dim userId As Integer = Form1.loggedInUserId

        ' Buka FormProfile dan berikan ID pengguna yang berhasil login
        Dim formProfile As New FormProfile()
        formProfile.userId = userId
        formProfile.Show()
        Hide()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        FormDiagnosis.Show()
        Me.Close()
    End Sub
End Class