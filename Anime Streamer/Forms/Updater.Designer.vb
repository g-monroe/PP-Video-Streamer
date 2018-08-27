<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Updater
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Updater))
        Me.NanoThemeContainer1 = New Anime_Streamer.NanoThemeContainer()
        Me.Prog = New Anime_Streamer.HuraProgressBar()
        Me.TagLabel2 = New Anime_Streamer.TagLabel()
        Me.TagLabel1 = New Anime_Streamer.TagLabel()
        Me.VLC = New System.Windows.Forms.RadioButton()
        Me.WMP = New System.Windows.Forms.RadioButton()
        Me.Status_lbl = New Anime_Streamer.TagLabel()
        Me.RichTextBox1 = New System.Windows.Forms.RichTextBox()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.NanoThemeContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'NanoThemeContainer1
        '
        Me.NanoThemeContainer1.Controls.Add(Me.Prog)
        Me.NanoThemeContainer1.Controls.Add(Me.TagLabel2)
        Me.NanoThemeContainer1.Controls.Add(Me.TagLabel1)
        Me.NanoThemeContainer1.Controls.Add(Me.VLC)
        Me.NanoThemeContainer1.Controls.Add(Me.WMP)
        Me.NanoThemeContainer1.Controls.Add(Me.Status_lbl)
        Me.NanoThemeContainer1.Controls.Add(Me.RichTextBox1)
        Me.NanoThemeContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NanoThemeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.NanoThemeContainer1.Name = "NanoThemeContainer1"
        Me.NanoThemeContainer1.Padding = New System.Windows.Forms.Padding(1, 32, 1, 1)
        Me.NanoThemeContainer1.Size = New System.Drawing.Size(284, 282)
        Me.NanoThemeContainer1.TabIndex = 0
        '
        'Prog
        '
        Me.Prog.BaseColour = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.Prog.BorderColour = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.Prog.FontColour = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.Prog.Location = New System.Drawing.Point(5, 253)
        Me.Prog.Maximum = 100
        Me.Prog.Name = "Prog"
        Me.Prog.ProgressColour = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.Prog.SecondColour = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.Prog.Size = New System.Drawing.Size(275, 23)
        Me.Prog.TabIndex = 6
        Me.Prog.Text = "HuraProgressBar1"
        Me.Prog.TwoColour = True
        Me.Prog.Value = 0
        '
        'TagLabel2
        '
        Me.TagLabel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.TagLabel2.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.TagLabel2.Location = New System.Drawing.Point(5, 211)
        Me.TagLabel2.Name = "TagLabel2"
        Me.TagLabel2.Size = New System.Drawing.Size(99, 36)
        Me.TagLabel2.TabIndex = 5
        Me.TagLabel2.Tag3D2 = True
        Me.TagLabel2.TagMColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.TagLabel2.TagMColor2 = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.TagLabel2.TagTColor = System.Drawing.Color.White
        Me.TagLabel2.Text = "Quit"
        '
        'TagLabel1
        '
        Me.TagLabel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.TagLabel1.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.TagLabel1.Location = New System.Drawing.Point(181, 211)
        Me.TagLabel1.Name = "TagLabel1"
        Me.TagLabel1.Size = New System.Drawing.Size(99, 36)
        Me.TagLabel1.TabIndex = 4
        Me.TagLabel1.Tag3D2 = True
        Me.TagLabel1.TagMColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.TagLabel1.TagMColor2 = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.TagLabel1.TagTColor = System.Drawing.Color.White
        Me.TagLabel1.Text = "Update"
        '
        'VLC
        '
        Me.VLC.AutoSize = True
        Me.VLC.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.VLC.ForeColor = System.Drawing.Color.White
        Me.VLC.Location = New System.Drawing.Point(197, 191)
        Me.VLC.Name = "VLC"
        Me.VLC.Size = New System.Drawing.Size(83, 17)
        Me.VLC.TabIndex = 3
        Me.VLC.TabStop = True
        Me.VLC.Text = "VLC Update"
        Me.VLC.UseVisualStyleBackColor = False
        '
        'WMP
        '
        Me.WMP.AutoSize = True
        Me.WMP.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.WMP.ForeColor = System.Drawing.Color.White
        Me.WMP.Location = New System.Drawing.Point(12, 191)
        Me.WMP.Name = "WMP"
        Me.WMP.Size = New System.Drawing.Size(90, 17)
        Me.WMP.TabIndex = 2
        Me.WMP.TabStop = True
        Me.WMP.Text = "WMP Update"
        Me.WMP.UseVisualStyleBackColor = False
        '
        'Status_lbl
        '
        Me.Status_lbl.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.Status_lbl.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.Status_lbl.Location = New System.Drawing.Point(12, 35)
        Me.Status_lbl.Name = "Status_lbl"
        Me.Status_lbl.Size = New System.Drawing.Size(260, 23)
        Me.Status_lbl.TabIndex = 1
        Me.Status_lbl.Tag3D2 = True
        Me.Status_lbl.TagMColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.Status_lbl.TagMColor2 = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.Status_lbl.TagTColor = System.Drawing.Color.White
        Me.Status_lbl.Text = "Update: "
        '
        'RichTextBox1
        '
        Me.RichTextBox1.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.RichTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.RichTextBox1.ForeColor = System.Drawing.Color.White
        Me.RichTextBox1.Location = New System.Drawing.Point(5, 64)
        Me.RichTextBox1.Name = "RichTextBox1"
        Me.RichTextBox1.ReadOnly = True
        Me.RichTextBox1.Size = New System.Drawing.Size(275, 121)
        Me.RichTextBox1.TabIndex = 0
        Me.RichTextBox1.Text = ""
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 10
        '
        'Updater
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(284, 282)
        Me.Controls.Add(Me.NanoThemeContainer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Updater"
        Me.Text = "Updater"
        Me.NanoThemeContainer1.ResumeLayout(False)
        Me.NanoThemeContainer1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents NanoThemeContainer1 As Anime_Streamer.NanoThemeContainer
    Friend WithEvents RichTextBox1 As System.Windows.Forms.RichTextBox
    Friend WithEvents TagLabel2 As Anime_Streamer.TagLabel
    Friend WithEvents TagLabel1 As Anime_Streamer.TagLabel
    Friend WithEvents VLC As System.Windows.Forms.RadioButton
    Friend WithEvents WMP As System.Windows.Forms.RadioButton
    Friend WithEvents Status_lbl As Anime_Streamer.TagLabel
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Prog As Anime_Streamer.HuraProgressBar
End Class
