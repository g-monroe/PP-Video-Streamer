<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UControl_PopularItem
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
        Me.Desc2 = New System.Windows.Forms.RichTextBox()
        Me.Namelbl = New System.Windows.Forms.Label()
        Me.Picture = New System.Windows.Forms.PictureBox()
        Me.TagLabel1 = New Anime_Streamer.TagLabel()
        Me.TagLabel2 = New Anime_Streamer.TagLabel()
        CType(Me.Picture, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Desc2
        '
        Me.Desc2.BackColor = System.Drawing.Color.White
        Me.Desc2.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Desc2.Location = New System.Drawing.Point(81, 47)
        Me.Desc2.Name = "Desc2"
        Me.Desc2.ReadOnly = True
        Me.Desc2.Size = New System.Drawing.Size(384, 50)
        Me.Desc2.TabIndex = 6
        Me.Desc2.Text = "This is an Anime Description duhh..."
        '
        'Namelbl
        '
        Me.Namelbl.AutoSize = True
        Me.Namelbl.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.25!)
        Me.Namelbl.Location = New System.Drawing.Point(82, 3)
        Me.Namelbl.Name = "Namelbl"
        Me.Namelbl.Size = New System.Drawing.Size(88, 17)
        Me.Namelbl.TabIndex = 5
        Me.Namelbl.Text = "Anime Name"
        '
        'Picture
        '
        Me.Picture.Image = Global.Anime_Streamer.My.Resources.Resources.Home_UnSel
        Me.Picture.Location = New System.Drawing.Point(3, 3)
        Me.Picture.Name = "Picture"
        Me.Picture.Size = New System.Drawing.Size(73, 94)
        Me.Picture.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Picture.TabIndex = 4
        Me.Picture.TabStop = False
        '
        'TagLabel1
        '
        Me.TagLabel1.BackColor = System.Drawing.Color.White
        Me.TagLabel1.Font = New System.Drawing.Font("Segoe UI", 8.0!)
        Me.TagLabel1.Location = New System.Drawing.Point(85, 23)
        Me.TagLabel1.Name = "TagLabel1"
        Me.TagLabel1.Size = New System.Drawing.Size(111, 23)
        Me.TagLabel1.TabIndex = 7
        Me.TagLabel1.Tag3D2 = False
        Me.TagLabel1.TagMColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.TagLabel1.TagMColor2 = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.TagLabel1.TagTColor = System.Drawing.Color.White
        Me.TagLabel1.Text = "Dubbed"
        '
        'TagLabel2
        '
        Me.TagLabel2.BackColor = System.Drawing.Color.White
        Me.TagLabel2.Cursor = System.Windows.Forms.Cursors.Hand
        Me.TagLabel2.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.TagLabel2.Location = New System.Drawing.Point(202, 23)
        Me.TagLabel2.Name = "TagLabel2"
        Me.TagLabel2.Size = New System.Drawing.Size(79, 23)
        Me.TagLabel2.TabIndex = 8
        Me.TagLabel2.Tag3D2 = False
        Me.TagLabel2.TagMColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.TagLabel2.TagMColor2 = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.TagLabel2.TagTColor = System.Drawing.Color.White
        Me.TagLabel2.Text = "Watch"
        '
        'UControl_PopularItem
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.TagLabel2)
        Me.Controls.Add(Me.TagLabel1)
        Me.Controls.Add(Me.Desc2)
        Me.Controls.Add(Me.Namelbl)
        Me.Controls.Add(Me.Picture)
        Me.Name = "UControl_PopularItem"
        Me.Size = New System.Drawing.Size(474, 101)
        CType(Me.Picture, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Desc2 As System.Windows.Forms.RichTextBox
    Friend WithEvents Namelbl As System.Windows.Forms.Label
    Friend WithEvents Picture As System.Windows.Forms.PictureBox
    Friend WithEvents TagLabel1 As Anime_Streamer.TagLabel
    Friend WithEvents TagLabel2 As Anime_Streamer.TagLabel

End Class
