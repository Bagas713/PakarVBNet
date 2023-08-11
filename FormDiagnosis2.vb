Public Class FormDiagnosis2
    Private Sub FormDiagnosis2_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Tambahkan daftar pertanyaan ke dalam ComboBoxPertanyaan
        ComboBox1.Items.Add("Permukaan Tidak Rapat")
        ComboBox1.Items.Add("Goresan Pada Lubang")
        ComboBox1.Items.Add("Bentuk Lubang Baut Tidak Sesuai")
        ComboBox1.Items.Add("Diameter Bagian Atas Tidak Sesuai")
        ComboBox1.Items.Add("Diameter Bagian Bawah Tidak Sesuai")
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Hide()
        FormAkun.Show()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim selectedKerusakan As String = ComboBox1.SelectedItem

        If selectedKerusakan IsNot Nothing Then
            Dim result As DialogResult = MessageBox.Show("Apakah kerusakan ini sering terjadi?", "Pertanyaan", MessageBoxButtons.YesNo, MessageBoxIcon.Question)

            If result = DialogResult.Yes Then
                ' Tampilkan form hasil diagnosis dengan jenis kerusakan terpilih sebagai parameter
                Dim formHasilDiagnosis2 As New FormHasilDiagnosis2(selectedKerusakan)
                Me.Hide()

                FormHasilDiagnosis2.ShowDialog()
            Else
                ' Tampilkan form pertanyaan tambahan berdasarkan jenis kerusakan terpilih


            End If
        Else
            MessageBox.Show("Silakan pilih jenis kerusakan terlebih dahulu.", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Warning)
        End If
    End Sub

    Private Sub GroupBox1_Enter(sender As Object, e As EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBox1.SelectedIndexChanged

    End Sub
End Class