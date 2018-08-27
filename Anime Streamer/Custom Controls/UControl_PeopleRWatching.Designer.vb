<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UControl_PeopleRWatching
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
        Me.Picture_PB = New System.Windows.Forms.PictureBox()
        Me.Name_RTB = New System.Windows.Forms.RichTextBox()
        Me.Tmr_out = New System.Windows.Forms.Timer(Me.components)
        Me.Tmr_in = New System.Windows.Forms.Timer(Me.components)
        Me.Tmr_Check = New System.Windows.Forms.Timer(Me.components)
        Me.Watch_bt = New Anime_Streamer.TagLabel()
        Me.TagLabel1 = New Anime_Streamer.TagLabel()
        CType(Me.Picture_PB, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Picture_PB
        '
        Me.Picture_PB.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Picture_PB.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.Picture_PB.ErrorImage = Global.Anime_Streamer.My.Resources.Resources.Logo_TopBar
        Me.Picture_PB.Image = Global.Anime_Streamer.My.Resources.Resources.Home_UnSel
        Me.Picture_PB.Location = New System.Drawing.Point(3, 3)
        Me.Picture_PB.Name = "Picture_PB"
        Me.Picture_PB.Size = New System.Drawing.Size(71, 111)
        Me.Picture_PB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom
        Me.Picture_PB.TabIndex = 1
        Me.Picture_PB.TabStop = False
        '
        'Name_RTB
        '
        Me.Name_RTB.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Name_RTB.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.Name_RTB.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.Name_RTB.Cursor = System.Windows.Forms.Cursors.Arrow
        Me.Name_RTB.ForeColor = System.Drawing.Color.White
        Me.Name_RTB.Location = New System.Drawing.Point(80, 3)
        Me.Name_RTB.Name = "Name_RTB"
        Me.Name_RTB.ReadOnly = True
        Me.Name_RTB.Size = New System.Drawing.Size(82, 86)
        Me.Name_RTB.TabIndex = 2
        Me.Name_RTB.Text = "Anime Name #Kawaii"
        '
        'Tmr_out
        '
        Me.Tmr_out.Interval = 1
        '
        'Tmr_in
        '
        Me.Tmr_in.Interval = 1
        '
        'Tmr_Check
        '
        Me.Tmr_Check.Interval = 500
        '
        'Watch_bt
        '
        Me.Watch_bt.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Watch_bt.BackColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.Watch_bt.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Watch_bt.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.Watch_bt.Location = New System.Drawing.Point(80, 65)
        Me.Watch_bt.Name = "Watch_bt"
        Me.Watch_bt.Size = New System.Drawing.Size(82, 49)
        Me.Watch_bt.TabIndex = 3
        Me.Watch_bt.Tag3D2 = False
        Me.Watch_bt.TagMColor = System.Drawing.Color.White
        Me.Watch_bt.TagMColor2 = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.Watch_bt.TagTColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.Watch_bt.Text = "Watch"
        '
        'TagLabel1
        '
        Me.TagLabel1.BackColor = System.Drawing.Color.White
        Me.TagLabel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TagLabel1.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.TagLabel1.Location = New System.Drawing.Point(0, 0)
        Me.TagLabel1.Name = "TagLabel1"
        Me.TagLabel1.Size = New System.Drawing.Size(77, 117)
        Me.TagLabel1.TabIndex = 0
        Me.TagLabel1.Tag3D2 = False
        Me.TagLabel1.TagMColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.TagLabel1.TagMColor2 = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.TagLabel1.TagTColor = System.Drawing.Color.White
        '
        'UControl_PeopleRWatching
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.Transparent
        Me.Controls.Add(Me.Watch_bt)
        Me.Controls.Add(Me.Name_RTB)
        Me.Controls.Add(Me.Picture_PB)
        Me.Controls.Add(Me.TagLabel1)
        Me.Name = "UControl_PeopleRWatching"
        Me.Size = New System.Drawing.Size(77, 117)
        CType(Me.Picture_PB, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Picture_PB As System.Windows.Forms.PictureBox
    Friend WithEvents Name_RTB As System.Windows.Forms.RichTextBox
    Friend WithEvents Watch_bt As Anime_Streamer.TagLabel
    Friend WithEvents Tmr_out As System.Windows.Forms.Timer
    Friend WithEvents Tmr_in As System.Windows.Forms.Timer
    Friend WithEvents Tmr_Check As System.Windows.Forms.Timer
    Friend WithEvents TagLabel1 As Anime_Streamer.TagLabel

End Class
