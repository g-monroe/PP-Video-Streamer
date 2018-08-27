<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UControl_Player
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
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Player1 = New Anime_Streamer.Player()
        Me.VolumeSlider1 = New Anime_Streamer.VolumeSlider()
        Me.AresioTrackBar1 = New Anime_Streamer.AresioTrackBar()
        Me.Player1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Timer1
        '
        Me.Timer1.Interval = 750
        '
        'Player1
        '
        Me.Player1.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Player1.Controls.Add(Me.VolumeSlider1)
        Me.Player1.Controls.Add(Me.AresioTrackBar1)
        Me.Player1.Destination = 0
        Me.Player1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Player1.Icons = "00:00"
        Me.Player1.Icons2 = "00:00"
        Me.Player1.Location = New System.Drawing.Point(0, 0)
        Me.Player1.Maxnumber = 100
        Me.Player1.Name = "Player1"
        Me.Player1.Onoff = False
        Me.Player1.Size = New System.Drawing.Size(628, 90)
        Me.Player1.StatusStr = "IDLE"
        Me.Player1.TabIndex = 3
        Me.Player1.Text = "Player1"
        '
        'VolumeSlider1
        '
        Me.VolumeSlider1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.VolumeSlider1.BackColor = System.Drawing.Color.Transparent
        Me.VolumeSlider1.Icons = "0"
        Me.VolumeSlider1.Location = New System.Drawing.Point(463, 51)
        Me.VolumeSlider1.Name = "VolumeSlider1"
        Me.VolumeSlider1.Onoff = False
        Me.VolumeSlider1.Size = New System.Drawing.Size(152, 23)
        Me.VolumeSlider1.TabIndex = 4
        Me.VolumeSlider1.Text = "VolumeSlider1"
        Me.VolumeSlider1.Volume = 50
        '
        'AresioTrackBar1
        '
        Me.AresioTrackBar1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.AresioTrackBar1.At = "00:00"
        Me.AresioTrackBar1.BackColor = System.Drawing.Color.Transparent
        Me.AresioTrackBar1.Endd = "00:00"
        Me.AresioTrackBar1.inner = False
        Me.AresioTrackBar1.Location = New System.Drawing.Point(3, 3)
        Me.AresioTrackBar1.Maximum = 10
        Me.AresioTrackBar1.Name = "AresioTrackBar1"
        Me.AresioTrackBar1.Size = New System.Drawing.Size(622, 42)
        Me.AresioTrackBar1.TabIndex = 5
        Me.AresioTrackBar1.Value = 0
        '
        'UControl_Player
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.Controls.Add(Me.Player1)
        Me.Name = "UControl_Player"
        Me.Size = New System.Drawing.Size(628, 90)
        Me.Player1.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents VolumeSlider1 As Anime_Streamer.VolumeSlider
    Friend WithEvents Player1 As Anime_Streamer.Player
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents AresioTrackBar1 As Anime_Streamer.AresioTrackBar

End Class
