Imports System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel

Public Class FormPertanyaan
    Private selectedKerusakan As String

    Public Sub New(selectedKerusakan As String)
        InitializeComponent()
        Me.selectedKerusakan = selectedKerusakan
        LoadPertanyaan()
        ' Cek peran pengguna yang berhasil login
        Dim level As String = GetUserRoleByUsername(username)
    End Sub

    Public Property username As String

    Private Sub LoadPertanyaan()
        ' Tentukan pertanyaan tambahan berdasarkan jenis kerusakan terpilih
        Select Case selectedKerusakan
            Case "Permukaan Tidak Rapat"
                LabelPertanyaan.Text = "Base Jig Mengalami Pelengkungan atau Patahnya Pin Clamping?"
            Case "Goresan Pada Lubang"
                LabelPertanyaan.Text = "Pin Clamping Patah atau Cutter Bergetar atau Goyang Digunakan?"
            Case "Bentuk Lubang Baut Tidak Sesuai"
                LabelPertanyaan.Text = "Pin Clamping Mengalami Penyok atau Miring Pada Base Jig?"
            Case "Diameter Bagian Atas Tidak Sesuai"
                LabelPertanyaan.Text = "Cutter Bergetar atau Goyang Saat Digunakan?"
            Case "Diameter Bagian Bawah Tidak Sesuai"
                LabelPertanyaan.Text = "Base Jig Miring?"
            Case Else
                LabelPertanyaan.Text = "Pertanyaan tambahan untuk jenis kerusakan ini belum tersedia."
        End Select
    End Sub

    Private Sub ButtonTidak_Click(sender As Object, e As EventArgs) Handles ButtonTidak.Click
        ' Tampilkan pesan sesuai dengan jawaban TIDAK yang dipilih
        MessageBox.Show(LabelPertanyaan.Text, "Pertanyaan Tambahan", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Dim formHasilDiagnosis As New FormHasilDiagnosis(selectedKerusakan)
        formHasilDiagnosis.ShowDialog()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Form2.Show()
        Hide()

    End Sub
End Class
