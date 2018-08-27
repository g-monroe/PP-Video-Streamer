<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Loading
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Loading))
        Me.NanoThemeContainer1 = New Anime_Streamer.NanoThemeContainer()
        Me.Prog = New Anime_Streamer.HuraProgressBar()
        Me.Status_lbl = New Anime_Streamer.TagLabel()
        Me.NanoThemeContainer1.SuspendLayout()
        Me.SuspendLayout()
        '
        'NanoThemeContainer1
        '
        Me.NanoThemeContainer1.Controls.Add(Me.Prog)
        Me.NanoThemeContainer1.Controls.Add(Me.Status_lbl)
        Me.NanoThemeContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.NanoThemeContainer1.Location = New System.Drawing.Point(0, 0)
        Me.NanoThemeContainer1.Name = "NanoThemeContainer1"
        Me.NanoThemeContainer1.Padding = New System.Windows.Forms.Padding(1, 32, 1, 1)
        Me.NanoThemeContainer1.Size = New System.Drawing.Size(331, 97)
        Me.NanoThemeContainer1.TabIndex = 0
        '
        'Prog
        '
        Me.Prog.BaseColour = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.Prog.BorderColour = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.Prog.FontColour = System.Drawing.Color.FromArgb(CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer), CType(CType(50, Byte), Integer))
        Me.Prog.Location = New System.Drawing.Point(12, 64)
        Me.Prog.Maximum = 100
        Me.Prog.Name = "Prog"
        Me.Prog.ProgressColour = System.Drawing.Color.FromArgb(CType(CType(230, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.Prog.SecondColour = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.Prog.Size = New System.Drawing.Size(307, 23)
        Me.Prog.TabIndex = 1
        Me.Prog.Text = "HuraProgressBar1"
        Me.Prog.TwoColour = True
        Me.Prog.Value = 0
        '
        'Status_lbl
        '
        Me.Status_lbl.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.Status_lbl.Font = New System.Drawing.Font("Segoe UI", 10.0!)
        Me.Status_lbl.Location = New System.Drawing.Point(12, 35)
        Me.Status_lbl.Name = "Status_lbl"
        Me.Status_lbl.Size = New System.Drawing.Size(307, 23)
        Me.Status_lbl.TabIndex = 0
        Me.Status_lbl.Tag3D2 = True
        Me.Status_lbl.TagMColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.Status_lbl.TagMColor2 = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.Status_lbl.TagTColor = System.Drawing.Color.White
        Me.Status_lbl.Text = "Currently Loading:"
        '
        'Loading
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(331, 97)
        Me.Controls.Add(Me.NanoThemeContainer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Loading"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Loading"
        Me.NanoThemeContainer1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents NanoThemeContainer1 As Anime_Streamer.NanoThemeContainer
    Friend WithEvents Prog As Anime_Streamer.HuraProgressBar
    Friend WithEvents Status_lbl As Anime_Streamer.TagLabel
End Class
