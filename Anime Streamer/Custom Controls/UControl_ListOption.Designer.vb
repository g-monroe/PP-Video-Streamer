<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UControl_ListOption
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Simple_Groupbox1 = New Anime_Streamer.Simple_Groupbox()
        Me.Remove_Button = New System.Windows.Forms.Button()
        Me.Add_Button = New System.Windows.Forms.Button()
        Me.WaveForm1 = New Anime_Streamer.SoundcloudPlayer.WaveForm()
        Me.Simple_Groupbox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(3, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(76, 13)
        Me.Label1.TabIndex = 9
        Me.Label1.Text = "Show Options:"
        '
        'Simple_Groupbox1
        '
        Me.Simple_Groupbox1.BackColor = System.Drawing.Color.White
        Me.Simple_Groupbox1.Controls.Add(Me.Remove_Button)
        Me.Simple_Groupbox1.Controls.Add(Me.Add_Button)
        Me.Simple_Groupbox1.Location = New System.Drawing.Point(6, 15)
        Me.Simple_Groupbox1.Name = "Simple_Groupbox1"
        Me.Simple_Groupbox1.Size = New System.Drawing.Size(164, 23)
        Me.Simple_Groupbox1.TabIndex = 10
        Me.Simple_Groupbox1.Text = "Simple_Groupbox1"
        '
        'Remove_Button
        '
        Me.Remove_Button.BackColor = System.Drawing.Color.Transparent
        Me.Remove_Button.BackgroundImage = Global.Anime_Streamer.My.Resources.Resources.ng
        Me.Remove_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Remove_Button.Dock = System.Windows.Forms.DockStyle.Left
        Me.Remove_Button.FlatAppearance.BorderSize = 0
        Me.Remove_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Remove_Button.Location = New System.Drawing.Point(28, 0)
        Me.Remove_Button.Name = "Remove_Button"
        Me.Remove_Button.Size = New System.Drawing.Size(28, 23)
        Me.Remove_Button.TabIndex = 1
        Me.Remove_Button.UseVisualStyleBackColor = False
        '
        'Add_Button
        '
        Me.Add_Button.BackColor = System.Drawing.Color.Transparent
        Me.Add_Button.BackgroundImage = Global.Anime_Streamer.My.Resources.Resources.pos
        Me.Add_Button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.Add_Button.Dock = System.Windows.Forms.DockStyle.Left
        Me.Add_Button.FlatAppearance.BorderSize = 0
        Me.Add_Button.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Add_Button.Location = New System.Drawing.Point(0, 0)
        Me.Add_Button.Name = "Add_Button"
        Me.Add_Button.Size = New System.Drawing.Size(28, 23)
        Me.Add_Button.TabIndex = 0
        Me.Add_Button.UseVisualStyleBackColor = False
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
        Me.WaveForm1.TabIndex = 8
        Me.WaveForm1.Text = "WaveForm1"
        Me.WaveForm1.WaveForm = Nothing
        '
        'UControl_ListOption
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer), CType(CType(45, Byte), Integer))
        Me.Controls.Add(Me.Simple_Groupbox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.WaveForm1)
        Me.Name = "UControl_ListOption"
        Me.Size = New System.Drawing.Size(173, 41)
        Me.Simple_Groupbox1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Simple_Groupbox1 As Anime_Streamer.Simple_Groupbox
    Friend WithEvents Remove_Button As System.Windows.Forms.Button
    Friend WithEvents Add_Button As System.Windows.Forms.Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents WaveForm1 As Anime_Streamer.SoundcloudPlayer.WaveForm

End Class
