<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UControl_NewRelease
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
        Me.Picture_PB = New System.Windows.Forms.PictureBox()
        Me.TagLabel1 = New Anime_Streamer.TagLabel()
        Me.Name_RTB = New System.Windows.Forms.RichTextBox()
        CType(Me.Picture_PB, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Picture_PB
        '
        Me.Picture_PB.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Picture_PB.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.Picture_PB.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Picture_PB.ErrorImage = Global.Anime_Streamer.My.Resources.Resources.Logo_TopBar
        Me.Picture_PB.Image = Global.Anime_Streamer.My.Resources.Resources.Home_UnSel
        Me.Picture_PB.Location = New System.Drawing.Point(3, 3)
        Me.Picture_PB.Name = "Picture_PB"
        Me.Picture_PB.Size = New System.Drawing.Size(103, 115)
        Me.Picture_PB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.Picture_PB.TabIndex = 3
        Me.Picture_PB.TabStop = False
        '
        'TagLabel1
        '
        Me.TagLabel1.BackColor = System.Drawing.Color.White
        Me.TagLabel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TagLabel1.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.TagLabel1.Location = New System.Drawing.Point(0, 0)
        Me.TagLabel1.Name = "TagLabel1"
        Me.TagLabel1.Size = New System.Drawing.Size(109, 151)
        Me.TagLabel1.TabIndex = 2
        Me.TagLabel1.Tag3D2 = False
        Me.TagLabel1.TagMColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.TagLabel1.TagMColor2 = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.TagLabel1.TagTColor = System.Drawing.Color.White
        '
        'Name_RTB
        '
        Me.Name_RTB.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.Name_RTB.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Name_RTB.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Name_RTB.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Name_RTB.Font = New System.Drawing.Font("Microsoft Sans Serif", 6.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Name_RTB.ForeColor = System.Drawing.Color.White
        Me.Name_RTB.Location = New System.Drawing.Point(0, 127)
        Me.Name_RTB.Name = "Name_RTB"
        Me.Name_RTB.ReadOnly = True
        Me.Name_RTB.Size = New System.Drawing.Size(109, 24)
        Me.Name_RTB.TabIndex = 4
        Me.Name_RTB.Text = "Anime Name #Kawaii"
        '
        'UControl_NewRelease
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.Controls.Add(Me.Name_RTB)
        Me.Controls.Add(Me.Picture_PB)
        Me.Controls.Add(Me.TagLabel1)
        Me.Name = "UControl_NewRelease"
        Me.Size = New System.Drawing.Size(109, 151)
        CType(Me.Picture_PB, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Picture_PB As System.Windows.Forms.PictureBox
    Friend WithEvents TagLabel1 As Anime_Streamer.TagLabel
    Friend WithEvents Name_RTB As System.Windows.Forms.RichTextBox

End Class
