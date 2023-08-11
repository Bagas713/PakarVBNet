Public Class FormDiagnosis3
    Private Sub FormDiagnosis3_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Tambahkan daftar pertanyaan ke dalam ComboBoxPertanyaan
        ComboBox1.Items.Add("Permukaan Tidak Rapat")
        ComboBox1.Items.Add("Goresan Pada Lubang")
        ComboBox1.Items.Add("Bentuk Lubang Baut Tidak Sesuai")
        ComboBox1.Items.Add("Diameter Bagian Atas Tidak Sesuai")
        ComboBox1.Items.Add("Diameter Bagian Bawah Tidak Sesuai")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        FormPakar.Show()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim selectedKerusakan As String = ComboBox1.SelectedItem

        If selectedKerusakan IsNot Nothing Then
            Dim result As DialogResult = MessageBox.Show("Apakah kerusakan ini sering terjadi?", "Pertanyaan", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If result = DialogResult.Yes Then
                ' Tampilkan form hasil diagnosis dengan jenis kerusakan terpilih sebagai parameter
                Dim formHasilDiagnosis3 As New FormHasilDiagnosis3(selectedKerusakan)
                Me.Hide()

                formHasilDiagnosis3.ShowDialog()
            Else
                ' Tampilkan form pertanyaan tambahan berdasarkan jenis kerusakan terpilih


            End If
        Else
            MessageBox.Show("Silakan pilih jenis kerusakan terlebih dahulu.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub
End Class