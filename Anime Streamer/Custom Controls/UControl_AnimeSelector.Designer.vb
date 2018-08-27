<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class UControl_AnimeSelector
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
        Me.Tmr_Checked = New System.Windows.Forms.Timer(Me.components)
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.PanelBox1 = New Anime_Streamer.PanelBox()
        Me.encyclo_CB = New Anime_Streamer.RecuperareIIComboBox()
        Me.Ency_lb = New System.Windows.Forms.Label()
        Me.Encyclo_LB = New Anime_Streamer.PositronListBox()
        Me.Toggle1 = New Anime_Streamer.Toggle()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.AnimeSearchtxtbox = New System.Windows.Forms.TextBox()
        Me.Animelb = New Anime_Streamer.PositronListBox()
        Me.Dubbed_CB = New Anime_Streamer.RecuperareIIComboBox()
        Me.Subbed_CB = New Anime_Streamer.RecuperareIIComboBox()
        Me.TagLabel3 = New Anime_Streamer.TagLabel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.TagLabel2 = New Anime_Streamer.TagLabel()
        Me.TagLabel1 = New Anime_Streamer.TagLabel()
        Me.PanelBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Tmr_Checked
        '
        Me.Tmr_Checked.Enabled = True
        Me.Tmr_Checked.Interval = 10
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'PanelBox1
        '
        Me.PanelBox1.Controls.Add(Me.encyclo_CB)
        Me.PanelBox1.Controls.Add(Me.Ency_lb)
        Me.PanelBox1.Controls.Add(Me.Encyclo_LB)
        Me.PanelBox1.Controls.Add(Me.Toggle1)
        Me.PanelBox1.Controls.Add(Me.Label4)
        Me.PanelBox1.Controls.Add(Me.Label3)
        Me.PanelBox1.Controls.Add(Me.AnimeSearchtxtbox)
        Me.PanelBox1.Controls.Add(Me.Animelb)
        Me.PanelBox1.Controls.Add(Me.Dubbed_CB)
        Me.PanelBox1.Controls.Add(Me.Subbed_CB)
        Me.PanelBox1.Controls.Add(Me.TagLabel3)
        Me.PanelBox1.Controls.Add(Me.Label2)
        Me.PanelBox1.Controls.Add(Me.Label1)
        Me.PanelBox1.Controls.Add(Me.TagLabel2)
        Me.PanelBox1.Controls.Add(Me.TagLabel1)
        Me.PanelBox1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PanelBox1.Font = New System.Drawing.Font("Tahoma", 10.0!)
        Me.PanelBox1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer), CType(CType(40, Byte), Integer))
        Me.PanelBox1.Location = New System.Drawing.Point(0, 0)
        Me.PanelBox1.Name = "PanelBox1"
        Me.PanelBox1.NoRounding = False
        Me.PanelBox1.Size = New System.Drawing.Size(404, 383)
        Me.PanelBox1.TabIndex = 0
        Me.PanelBox1.Text = "PanelBox1"
        '
        'encyclo_CB
        '
        Me.encyclo_CB.BackColor = System.Drawing.Color.Transparent
        Me.encyclo_CB.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.encyclo_CB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.encyclo_CB.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Bold)
        Me.encyclo_CB.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(137, Byte), Integer))
        Me.encyclo_CB.FormattingEnabled = True
        Me.encyclo_CB.ItemHeight = 16
        Me.encyclo_CB.ItemHighlightColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.encyclo_CB.Items.AddRange(New Object() {"(none)"})
        Me.encyclo_CB.Location = New System.Drawing.Point(4, 81)
        Me.encyclo_CB.Name = "encyclo_CB"
        Me.encyclo_CB.Size = New System.Drawing.Size(394, 22)
        Me.encyclo_CB.StartIndex = 0
        Me.encyclo_CB.TabIndex = 16
        Me.encyclo_CB.Visible = False
        '
        'Ency_lb
        '
        Me.Ency_lb.AutoSize = True
        Me.Ency_lb.BackColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.Ency_lb.ForeColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.Ency_lb.Location = New System.Drawing.Point(25, 60)
        Me.Ency_lb.Name = "Ency_lb"
        Me.Ency_lb.Size = New System.Drawing.Size(133, 17)
        Me.Ency_lb.TabIndex = 15
        Me.Ency_lb.Text = "Select an Anime or..."
        Me.Ency_lb.Visible = False
        '
        'Encyclo_LB
        '
        Me.Encyclo_LB.BackColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.Encyclo_LB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Encyclo_LB.Color1p = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.Encyclo_LB.Color2p = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(137, Byte), Integer))
        Me.Encyclo_LB.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Encyclo_LB.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.Encyclo_LB.ForeColor = System.Drawing.Color.Black
        Me.Encyclo_LB.FormattingEnabled = True
        Me.Encyclo_LB.IntegralHeight = False
        Me.Encyclo_LB.ItemHeight = 16
        Me.Encyclo_LB.Location = New System.Drawing.Point(4, 208)
        Me.Encyclo_LB.Name = "Encyclo_LB"
        Me.Encyclo_LB.ShowScrollbar = True
        Me.Encyclo_LB.Size = New System.Drawing.Size(393, 164)
        Me.Encyclo_LB.TabIndex = 14
        Me.Encyclo_LB.Visible = False
        '
        'Toggle1
        '
        Me.Toggle1.Checked = False
        Me.Toggle1.Icons = False
        Me.Toggle1.Location = New System.Drawing.Point(131, 158)
        Me.Toggle1.Name = "Toggle1"
        Me.Toggle1.Size = New System.Drawing.Size(44, 18)
        Me.Toggle1.TabIndex = 13
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.BackColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.Label4.ForeColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.Label4.Location = New System.Drawing.Point(3, 158)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(130, 17)
        Me.Label4.TabIndex = 12
        Me.Label4.Text = "Encyclopedia Mode:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.ForeColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.Label3.Location = New System.Drawing.Point(25, 134)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(148, 17)
        Me.Label3.TabIndex = 11
        Me.Label3.Text = "if you prefer searching."
        '
        'AnimeSearchtxtbox
        '
        Me.AnimeSearchtxtbox.Location = New System.Drawing.Point(4, 178)
        Me.AnimeSearchtxtbox.Name = "AnimeSearchtxtbox"
        Me.AnimeSearchtxtbox.Size = New System.Drawing.Size(393, 24)
        Me.AnimeSearchtxtbox.TabIndex = 10
        '
        'Animelb
        '
        Me.Animelb.BackColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.Animelb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Animelb.Color1p = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(82, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.Animelb.Color2p = System.Drawing.Color.FromArgb(CType(CType(233, Byte), Integer), CType(CType(57, Byte), Integer), CType(CType(137, Byte), Integer))
        Me.Animelb.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Animelb.Font = New System.Drawing.Font("Verdana", 8.0!)
        Me.Animelb.ForeColor = System.Drawing.Color.Black
        Me.Animelb.FormattingEnabled = True
        Me.Animelb.IntegralHeight = False
        Me.Animelb.ItemHeight = 16
        Me.Animelb.Location = New System.Drawing.Point(4, 208)
        Me.Animelb.Name = "Animelb"
        Me.Animelb.ShowScrollbar = True
        Me.Animelb.Size = New System.Drawing.Size(393, 164)
        Me.Animelb.TabIndex = 9
        '
        'Dubbed_CB
        '
        Me.Dubbed_CB.BackColor = System.Drawing.Color.Transparent
        Me.Dubbed_CB.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Dubbed_CB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Dubbed_CB.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Bold)
        Me.Dubbed_CB.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(137, Byte), Integer))
        Me.Dubbed_CB.FormattingEnabled = True
        Me.Dubbed_CB.ItemHeight = 16
        Me.Dubbed_CB.ItemHighlightColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.Dubbed_CB.Items.AddRange(New Object() {"(none)"})
        Me.Dubbed_CB.Location = New System.Drawing.Point(3, 107)
        Me.Dubbed_CB.Name = "Dubbed_CB"
        Me.Dubbed_CB.Size = New System.Drawing.Size(394, 22)
        Me.Dubbed_CB.StartIndex = 0
        Me.Dubbed_CB.TabIndex = 8
        '
        'Subbed_CB
        '
        Me.Subbed_CB.BackColor = System.Drawing.Color.Transparent
        Me.Subbed_CB.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        Me.Subbed_CB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.Subbed_CB.Font = New System.Drawing.Font("Verdana", 6.75!, System.Drawing.FontStyle.Bold)
        Me.Subbed_CB.ForeColor = System.Drawing.Color.FromArgb(CType(CType(27, Byte), Integer), CType(CType(94, Byte), Integer), CType(CType(137, Byte), Integer))
        Me.Subbed_CB.FormattingEnabled = True
        Me.Subbed_CB.ItemHeight = 16
        Me.Subbed_CB.ItemHighlightColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.Subbed_CB.Items.AddRange(New Object() {"(none)"})
        Me.Subbed_CB.Location = New System.Drawing.Point(4, 62)
        Me.Subbed_CB.Name = "Subbed_CB"
        Me.Subbed_CB.Size = New System.Drawing.Size(394, 22)
        Me.Subbed_CB.StartIndex = 0
        Me.Subbed_CB.TabIndex = 7
        '
        'TagLabel3
        '
        Me.TagLabel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.TagLabel3.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.TagLabel3.Location = New System.Drawing.Point(295, 134)
        Me.TagLabel3.Name = "TagLabel3"
        Me.TagLabel3.Size = New System.Drawing.Size(102, 36)
        Me.TagLabel3.TabIndex = 6
        Me.TagLabel3.Tag3D2 = False
        Me.TagLabel3.TagMColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.TagLabel3.TagMColor2 = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.TagLabel3.TagTColor = System.Drawing.Color.White
        Me.TagLabel3.Text = "Continue"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.ForeColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(25, 86)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(184, 17)
        Me.Label2.TabIndex = 5
        Me.Label2.Text = "select a Dubbed Anime or ...."
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer), CType(CType(80, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(25, 41)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(176, 17)
        Me.Label1.TabIndex = 3
        Me.Label1.Text = "Select a Subbed Anime or..."
        '
        'TagLabel2
        '
        Me.TagLabel2.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.TagLabel2.BackColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.TagLabel2.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.TagLabel2.Location = New System.Drawing.Point(295, 399)
        Me.TagLabel2.Name = "TagLabel2"
        Me.TagLabel2.Size = New System.Drawing.Size(100, 33)
        Me.TagLabel2.TabIndex = 1
        Me.TagLabel2.Tag3D2 = False
        Me.TagLabel2.TagMColor = System.Drawing.Color.FromArgb(CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer), CType(CType(120, Byte), Integer))
        Me.TagLabel2.TagMColor2 = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.TagLabel2.TagTColor = System.Drawing.Color.White
        Me.TagLabel2.Text = "Continue"
        '
        'TagLabel1
        '
        Me.TagLabel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.TagLabel1.Font = New System.Drawing.Font("Segoe UI", 12.0!)
        Me.TagLabel1.Location = New System.Drawing.Point(4, 4)
        Me.TagLabel1.Name = "TagLabel1"
        Me.TagLabel1.Size = New System.Drawing.Size(397, 33)
        Me.TagLabel1.TabIndex = 0
        Me.TagLabel1.Tag3D2 = True
        Me.TagLabel1.TagMColor = System.Drawing.Color.FromArgb(CType(CType(251, Byte), Integer), CType(CType(83, Byte), Integer), CType(CType(150, Byte), Integer))
        Me.TagLabel1.TagMColor2 = System.Drawing.Color.FromArgb(CType(CType(231, Byte), Integer), CType(CType(63, Byte), Integer), CType(CType(130, Byte), Integer))
        Me.TagLabel1.TagTColor = System.Drawing.Color.White
        Me.TagLabel1.Text = "Select a Subbed or Dubbed Anime before continuing."
        '
        'UControl_AnimeSelector
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.White
        Me.Controls.Add(Me.PanelBox1)
        Me.Name = "UControl_AnimeSelector"
        Me.Size = New System.Drawing.Size(404, 383)
        Me.PanelBox1.ResumeLayout(False)
        Me.PanelBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents PanelBox1 As Anime_Streamer.PanelBox
    Friend WithEvents TagLabel1 As Anime_Streamer.TagLabel
    Friend WithEvents TagLabel2 As Anime_Streamer.TagLabel
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Tmr_Checked As System.Windows.Forms.Timer
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents TagLabel3 As Anime_Streamer.TagLabel
    Friend WithEvents Dubbed_CB As Anime_Streamer.RecuperareIIComboBox
    Friend WithEvents Subbed_CB As Anime_Streamer.RecuperareIIComboBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents AnimeSearchtxtbox As System.Windows.Forms.TextBox
    Friend WithEvents Animelb As Anime_Streamer.PositronListBox
    Friend WithEvents Toggle1 As Anime_Streamer.Toggle
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents encyclo_CB As Anime_Streamer.RecuperareIIComboBox
    Friend WithEvents Ency_lb As System.Windows.Forms.Label
    Friend WithEvents Encyclo_LB As Anime_Streamer.PositronListBox

End Class
