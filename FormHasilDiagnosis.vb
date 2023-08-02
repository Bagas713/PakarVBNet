Imports Microsoft.VisualBasic.ApplicationServices

Public Class FormHasilDiagnosis
    Private selectedKerusakan As String

    Public Sub New(selectedKerusakan As String)
        InitializeComponent()
        Me.selectedKerusakan = selectedKerusakan
        LoadHasilDiagnosis()
    End Sub

    Private Sub LoadHasilDiagnosis()
        ' Tentukan hasil diagnosis berdasarkan jenis kerusakan terpilih
        Select Case selectedKerusakan
            Case "Permukaan Tidak Rapat"
                LabelHasilDiagnosis.Text = "Hasil Diagnosis Kerusakan dan Solusi Perbaikannya:" & vbCrLf & vbCrLf &
                    "Kerusakan pada permukaan tidak rapat, diakibatkan dari base jig mengalami pelengkungan atau patahnya pin clamping." & vbCrLf & vbCrLf &
                    "Solusinya yaitu dengan cara:" & vbCrLf &
                    "- Memposisikan base jig secara center pada saat pemasangan jig clamping, untuk menghindari terjadinya pelengkungan 
  pada base jig dan menyesuaikan pin clamping dengan tinggi dari rel jig." & vbCrLf &
                    "- Tidak terlalu kencang saat melakukan pemasangan pin clamping." & vbCrLf & vbCrLf &
                    "Untuk alternatif lainnya, Anda dapat menggunakan mesin surface grinding." & vbCrLf & vbCrLf &
                    "Jika kurang jelas, Anda dapat menghubungi nomor di bawah ini:" & vbCrLf &
                    "Tim Jig Clamping - 085780565425"
            Case "Goresan Pada Lubang"
                LabelHasilDiagnosis.Text = "Hasil Diagnosis Kerusakan dan Solusi Perbaikannya:" & vbCrLf & vbCrLf &
                    "Kerusakan pada goresan pada lubang, diakibatkan dari pin clamping patah atau cutter bergetar/goyang saat digunakan." & vbCrLf & vbCrLf &
                    "Solusinya yaitu dengan cara:" & vbCrLf &
                    "- Tidak terlalu kencang saat melakukan pemasangan pin clamping." & vbCrLf &
                    "- Memegang base jig agar cutter tidak bergetar saat digunakan." & vbCrLf &
                    "- Mengatur kecepatan yang sesuai pada saat proses milling, agar kecepatan tersebut tidak terlalu tinggi." & vbCrLf & vbCrLf &
                    "Jika kurang jelas, Anda dapat menghubungi nomor di bawah ini:" & vbCrLf &
                    "Tim Jig Clamping - 085780565425"
            Case "Bentuk Lubang Baut Tidak Sesuai"
                LabelHasilDiagnosis.Text = "Hasil Diagnosis Kerusakan dan Solusi Perbaikannya:" & vbCrLf & vbCrLf &
                    "Kerusakan pada bentuk lubang baut tidak sesuai, diakibatkan dari Pin clamping mengalami penyok atau miring pada
  base jig." & vbCrLf & vbCrLf &
                    "Jika kurang jelas, Anda dapat menghubungi nomor di bawah ini:" & vbCrLf &
                    "Tim Jig Clamping - 085780565425"
            Case "Diameter Bagian Atas Tidak Sesuai"
                LabelHasilDiagnosis.Text = "Hasil Diagnosis Kerusakan dan Solusi Perbaikannya:" & vbCrLf & vbCrLf &
                    "Kerusakan pada diameter bagian atas tidak sesuai, diakibatkan dari cutter bergetar/goyang saat digunakan." & vbCrLf & vbCrLf &
                    "Solusinya yaitu dengan cara:" & vbCrLf &
                    "- Memegang base jig agar cutter tidak bergetar saat digunakan." & vbCrLf &
                    "- Mengatur kecepatan yang sesuai pada saat proses milling, agar kecepatan tersebut tidak terlalu tinggi." & vbCrLf & vbCrLf &
                    "Jika kurang jelas, Anda dapat menghubungi nomor di bawah ini:" & vbCrLf &
                    "Tim Jig Clamping - 085780565425"
            Case "Diameter Bagian Bawah Tidak Sesuai"
                LabelHasilDiagnosis.Text = "Hasil Diagnosis Kerusakan dan Solusi Perbaikannya:" & vbCrLf & vbCrLf &
                    "Kerusakan pada diameter bagian bawah tidak sesuai, diakibatkan dari base jig miring." & vbCrLf & vbCrLf &
                    "Solusinya yaitu dengan cara:" & vbCrLf &
                    "- Memposisikan base jig secara center pada saat pemasangan jig clamping." & vbCrLf &
                    "- Membersihkan base jig secara berkala untuk menghindari base jig yang kotor." & vbCrLf & vbCrLf &
                    "Untuk alternatif lainnya, Anda dapat menggunakan mesin surface grinding." & vbCrLf & vbCrLf &
                    "Jika kurang jelas, Anda dapat menghubungi nomor di bawah ini:" & vbCrLf &
                    "Tim Jig Clamping - 085780565425"
            Case Else
                LabelHasilDiagnosis.Text = "Jenis kerusakan ini tidak tersedia dalam hasil diagnosis."
        End Select
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs)
        Form2.Show()
        Close()

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim hasilDiagnosis As String = LabelHasilDiagnosis.Text

        ' Panggil fungsi untuk menyimpan data hasil diagnosis ke database
        SaveDiagnosisData(selectedKerusakan, hasilDiagnosis)

        ' Tutup form setelah data disimpan
        Form2.Show()
        Hide()

    End Sub
End Class
