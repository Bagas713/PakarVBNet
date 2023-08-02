<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FormPertanyaan
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormPertanyaan))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.ButtonTidak = New System.Windows.Forms.Button()
        Me.LabelPertanyaan = New System.Windows.Forms.Label()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.GroupBox1.Controls.Add(Me.Button3)
        Me.GroupBox1.Controls.Add(Me.ButtonTidak)
        Me.GroupBox1.Controls.Add(Me.LabelPertanyaan)
        Me.GroupBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.2!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GroupBox1.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GroupBox1.Location = New System.Drawing.Point(68, 88)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(694, 238)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Pertanyaan"
        '
        'Button3
        '
        Me.Button3.ForeColor = System.Drawing.Color.Black
        Me.Button3.Location = New System.Drawing.Point(577, 180)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(93, 38)
        Me.Button3.TabIndex = 3
        Me.Button3.Text = "Selesai"
        Me.Button3.UseVisualStyleBackColor = True
        '
        'ButtonTidak
        '
        Me.ButtonTidak.Location = New System.Drawing.Point(23, 182)
        Me.ButtonTidak.Name = "ButtonTidak"
        Me.ButtonTidak.Size = New System.Drawing.Size(75, 34)
        Me.ButtonTidak.TabIndex = 2
        Me.ButtonTidak.Text = "Tidak"
        Me.ButtonTidak.UseVisualStyleBackColor = True
        '
        'LabelPertanyaan
        '
        Me.LabelPertanyaan.AutoSize = True
        Me.LabelPertanyaan.Location = New System.Drawing.Point(19, 70)
        Me.LabelPertanyaan.Name = "LabelPertanyaan"
        Me.LabelPertanyaan.Size = New System.Drawing.Size(324, 20)
        Me.LabelPertanyaan.TabIndex = 0
        Me.LabelPertanyaan.Text = "Apakah Kerusakan Ini Sering Terjadi?"
        Me.LabelPertanyaan.TextAlign = System.Drawing.ContentAlignment.TopCenter
        '
        'FormPertanyaan
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.BackgroundImage = CType(resources.GetObject("$this.BackgroundImage"), System.Drawing.Image)
        Me.ClientSize = New System.Drawing.Size(829, 418)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox1)
        Me.Name = "FormPertanyaan"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pertanyaan"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents LabelPertanyaan As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents ButtonTidak As Button
End Class
