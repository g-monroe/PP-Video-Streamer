<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UControl_OnGSeries
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
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
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Namebox = New System.Windows.Forms.RichTextBox()
        Me.Picture = New System.Windows.Forms.PictureBox()
        Me.TagLabel2 = New Anime_Streamer.TagLabel()
        CType(Me.Picture, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Namebox
        '
        Me.Namebox.BackColor = System.Drawing.Color.White
        Me.Namebox.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Namebox.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.Namebox.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Namebox.ForeColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.Namebox.Location = New System.Drawing.Point(56, 3)
        Me.Namebox.Name = "Namebox"
        Me.Namebox.ReadOnly = True
        Me.Namebox.Size = New System.Drawing.Size(126, 36)
        Me.Namebox.TabIndex = 5
        Me.Namebox.Text = "Name of the Ongoing Anime"
        '
        'Picture
        '
        Me.Picture.Location = New System.Drawing.Point(3, 3)
        Me.Picture.Name = "Picture"
        Me.Picture.Size = New System.Drawing.Size(48, 61)
        Me.Picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Picture.TabIndex = 4
        Me.Picture.TabStop = False
        '
        'TagLabel2
        '
        Me.TagLabel2.BackColor = System.Drawing.Color.White
        Me.TagLabel2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.TagLabel2.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.TagLabel2.Location = New System.Drawing.Point(57, 41)
        Me.TagLabel2.Name = "TagLabel2"
        Me.TagLabel2.Size = New System.Drawing.Size(100, 23)
        Me.TagLabel2.TabIndex = 9
        Me.TagLabel2.Tag3D2 = False
        Me.TagLabel2.TagMColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.TagLabel2.TagMColor2 = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.TagLabel2.TagTColor = System.Drawing.Color.White
        Me.TagLabel2.Text = "Watch"
        '
        'UControl_OnGSeries
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TagLabel2)
        Me.Controls.Add(Me.Namebox)
        Me.Controls.Add(Me.Picture)
        Me.Name = "UControl_OnGSeries"
        Me.Size = New System.Drawing.Size(182, 70)
        CType(Me.Picture, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Namebox As System.Windows.Forms.RichTextBox
    Friend WithEvents Picture As System.Windows.Forms.PictureBox
    Friend WithEvents TagLabel2 As Anime_Streamer.TagLabel

End Class
