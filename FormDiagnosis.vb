Public Class FormDiagnosis

    Private userId As Integer ' Field untuk menyimpan userId pengguna yang login

    Private Sub FormDiagnosis_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Tambahkan daftar pertanyaan ke dalam ComboBoxPertanyaan
        ComboBox1.Items.Add("Permukaan Tidak Rapat")
        ComboBox1.Items.Add("Goresan Pada Lubang")
        ComboBox1.Items.Add("Bentuk Lubang Baut Tidak Sesuai")
        ComboBox1.Items.Add("Diameter Bagian Atas Tidak Sesuai")
        ComboBox1.Items.Add("Diameter Bagian Bawah Tidak Sesuai")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Form2.Show()
        Me.Close()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim selectedKerusakan As String = ComboBox1.SelectedItem

        If selectedKerusakan IsNot Nothing Then
            Dim result As DialogResult = MessageBox.Show("Apakah kerusakan ini sering terjadi?", "Pertanyaan", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If result = DialogResult.Yes Then
                ' Tampilkan form hasil diagnosis dengan jenis kerusakan terpilih sebagai parameter
                Dim formHasilDiagnosis As New FormHasilDiagnosis(selectedKerusakan)
                formHasilDiagnosis.ShowDialog()
            Else
                ' Tampilkan form pertanyaan tambahan berdasarkan jenis kerusakan terpilih
                Dim formPertanyaan As New FormPertanyaan(selectedKerusakan)
                formPertanyaan.ShowDialog()
            End If
        Else
            MessageBox.Show("Silakan pilih jenis kerusakan terlebih dahulu.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    ' Method untuk mengatur nilai userId dari Form1 (atau Form sebelumnya)
    Public Sub SetUserId(userId As Integer)
        Me.userId = userId
    End Sub
End Class
