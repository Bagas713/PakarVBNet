Public Class FormUlasan
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim ulasan As String = TextBox1.Text

        ' Panggil fungsi untuk menyimpan ulasan ke dalam database
        SimpanUlasan(ulasan)

        TextBox1.Clear()

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Hide()
        FormPakarDiagnosis.Show()

    End Sub
End Class