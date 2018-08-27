<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UControl_VideoOptions
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
        Me.components = New System.ComponentModel.Container()
        Me.WaveForm1 = New Anime_Streamer.SoundcloudPlayer.WaveForm()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Simple_Groupbox1 = New Anime_Streamer.Simple_Groupbox()
        Me.Down_but = New System.Windows.Forms.Button()
        Me.Globe_button = New System.Windows.Forms.Button()
        Me.NextEp = New System.Windows.Forms.Button()
        Me.PrevEp = New System.Windows.Forms.Button()
        Me.Refresh_Button = New System.Windows.Forms.Button()
        Me.FullScreen = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Simple_Groupbox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'WaveForm1
        '
        Me.WaveForm1.BackColor = System.Drawing.Color.Transparent
        Me.WaveForm1.ContentLength = CType(1, Long)
        Me.WaveForm1.CurrentPosition = CType(0, Long)
        Me.WaveForm1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WaveForm1.Location = New System.Drawing.Point(0, 0)
        Me.WaveForm1.Name = "WaveForm1"
        Me.WaveForm1.Size = New System.Drawing.Size(173, 41)
        Me.WaveForm1.TabIndex = 0
        Me.WaveForm1.Text = "WaveForm1"
        Me.WaveForm1.WaveForm = Nothing
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "Video Options:"
        '
        'Simple_Groupbox1
        '
        Me.Simple_Groupbox1.BackColor = System.Drawing.Color.White
        Me.Simple_Groupbox1.Controls.Add(Me.Down_but)
        Me.Simple_Groupbox1.Controls.Add(Me.Globe_button)
        Me.Simple_Groupbox1.Controls.Add(Me.NextEp)
        Me.Simple_Groupbox1.Controls.Add(Me.PrevEp)
        Me.Simple_Groupbox1.Controls.Add(Me.Refresh_Button)
        Me.Simple_Groupbox1.Controls.Add(Me.FullScreen)
        Me.Simple_Groupbox1.Location = New System.Drawing.Point(6, 15)
        Me.Simple_Groupbox1.Name = "Simple_Groupbox1"
        Me.Simple_Groupbox1.Size = New System.Drawing.Size(164, 23)
        Me.Simple_Groupbox1.TabIndex = 7
        Me.Simple_Groupbox1.Text = "Simple_Groupbox1"
        '
        'Down_but
        '
        Me.Down_but.BackColor = System.Drawing.Color.Transparent
        Me.Down_but.BackgroundImage = Global.Anime_Streamer.My.Resources.Resources.Down1
        Me.Down_but.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Down_but.Dock = System.Windows.Forms.DockStyle.Left
        Me.Down_but.FlatAppearance.BorderSize = 0
        Me.Down_but.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Down_but.Location = New System.Drawing.Point(140, 0)
        Me.Down_but.Name = "Down_but"
        Me.Down_but.Size = New System.Drawing.Size(24, 23)
        Me.Down_but.TabIndex = 5
        Me.Down_but.UseVisualStyleBackColor = False
        '
        'Globe_button
        '
        Me.Globe_button.BackColor = System.Drawing.Color.Transparent
        Me.Globe_button.BackgroundImage = Global.Anime_Streamer.My.Resources.Resources.Globe
        Me.Globe_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Globe_button.Dock = System.Windows.Forms.DockStyle.Left
        Me.Globe_button.FlatAppearance.BorderSize = 0
        Me.Globe_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Globe_button.Location = New System.Drawing.Point(112, 0)
        Me.Globe_button.Name = "Globe_button"
        Me.Globe_button.Size = New System.Drawing.Size(28, 23)
        Me.Globe_button.TabIndex = 4
        Me.Globe_button.UseVisualStyleBackColor = False
        '
        'NextEp
        '
        Me.NextEp.BackColor = System.Drawing.Color.Transparent
        Me.NextEp.BackgroundImage = Global.Anime_Streamer.My.Resources.Resources.right
        Me.NextEp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.NextEp.Dock = System.Windows.Forms.DockStyle.Left
        Me.NextEp.FlatAppearance.BorderSize = 0
        Me.NextEp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.NextEp.Location = New System.Drawing.Point(84, 0)
        Me.NextEp.Name = "NextEp"
        Me.NextEp.Size = New System.Drawing.Size(28, 23)
        Me.NextEp.TabIndex = 3
        Me.NextEp.UseVisualStyleBackColor = False
        '
        'PrevEp
        '
        Me.PrevEp.BackColor = System.Drawing.Color.Transparent
        Me.PrevEp.BackgroundImage = Global.Anime_Streamer.My.Resources.Resources.left
        Me.PrevEp.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PrevEp.Dock = System.Windows.Forms.DockStyle.Left
        Me.PrevEp.FlatAppearance.BorderSize = 0
        Me.PrevEp.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.PrevEp.Location = New System.Drawing.Point(56, 0)
        Me.PrevEp.Name = "PrevEp"
        Me.PrevEp.Size = New System.Drawing.Size(28, 23)
        Me.PrevEp.TabIndex = 2
        Me.PrevEp.UseVisualStyleBackColor = False
        '
        'Refresh_Button
        '
        Me.Refresh_Button.BackColor = System.Drawing.Color.Transparent
        Me.Refresh_Button.BackgroundImage = Global.Anime_Streamer.My.Resources.Resources.Refresh
        Me.Refresh_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Refresh_Button.Dock = System.Windows.Forms.DockStyle.Left
        Me.Refresh_Button.FlatAppearance.BorderSize = 0
        Me.Refresh_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Refresh_Button.Location = New System.Drawing.Point(28, 0)
        Me.Refresh_Button.Name = "Refresh_Button"
        Me.Refresh_Button.Size = New System.Drawing.Size(28, 23)
        Me.Refresh_Button.TabIndex = 1
        Me.Refresh_Button.UseVisualStyleBackColor = False
        '
        'FullScreen
        '
        Me.FullScreen.BackColor = System.Drawing.Color.Transparent
        Me.FullScreen.BackgroundImage = Global.Anime_Streamer.My.Resources.Resources.rezisss1
        Me.FullScreen.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.FullScreen.Dock = System.Windows.Forms.DockStyle.Left
        Me.FullScreen.FlatAppearance.BorderSize = 0
        Me.FullScreen.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.FullScreen.Location = New System.Drawing.Point(0, 0)
        Me.FullScreen.Name = "FullScreen"
        Me.FullScreen.Size = New System.Drawing.Size(28, 23)
        Me.FullScreen.TabIndex = 0
        Me.FullScreen.UseVisualStyleBackColor = False
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'UControl_VideoOptions
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.Controls.Add(Me.Simple_Groupbox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.WaveForm1)
        Me.Name = "UControl_VideoOptions"
        Me.Size = New System.Drawing.Size(173, 41)
        Me.Simple_Groupbox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents WaveForm1 As Anime_Streamer.SoundcloudPlayer.WaveForm
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Simple_Groupbox1 As Anime_Streamer.Simple_Groupbox
    Friend WithEvents Down_but As System.Windows.Forms.Button
    Friend WithEvents Globe_button As System.Windows.Forms.Button
    Friend WithEvents NextEp As System.Windows.Forms.Button
    Friend WithEvents PrevEp As System.Windows.Forms.Button
    Friend WithEvents Refresh_Button As System.Windows.Forms.Button
    Friend WithEvents FullScreen As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer

End Class
