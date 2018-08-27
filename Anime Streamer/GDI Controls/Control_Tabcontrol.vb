Imports System.Drawing.Drawing2D
Class KoboTabControlS
    Inherits TabControl

#Region "Properties | TabControl"
    Private _BGColor As Color = Color.White
    Public Property BGColor() As Color
        Get
            Return _BGColor
        End Get
        Set(ByVal v As Color)
            _BGColor = v
            Invalidate()
        End Set
    End Property
#End Region

#Region "Variables | Colors"
    Private TC As Color = Color.FromArgb(64, 64, 64) 'TEXT COLOR
    Private AC As Color = Color.FromArgb(251, 83, 150) 'ACTIVE COLOR
#End Region

#Region "Functions | Create round"
    Private Function CreateRound(ByVal r As Rectangle, ByVal slope As Integer) As GraphicsPath
        Dim CreateRoundPath As GraphicsPath

        CreateRoundPath = New GraphicsPath(FillMode.Winding)
        CreateRoundPath.AddArc(r.X, r.Y, slope, slope, 180.0F, 90.0F)
        CreateRoundPath.AddArc(r.Right - slope, r.Y, slope, slope, 270.0F, 90.0F)
        CreateRoundPath.AddArc(r.Right - slope, r.Bottom - slope, slope, slope, 0.0F, 90.0F)
        CreateRoundPath.AddArc(r.X, r.Bottom - slope, slope, slope, 90.0F, 90.0F)
        CreateRoundPath.CloseFigure()
        Return CreateRoundPath
    End Function
#End Region

    Protected Overrides Sub CreateHandle()
        MyBase.CreateHandle()
        Alignment = TabAlignment.Top
    End Sub

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or _
         ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer, True)
        DoubleBuffered = True

        Dock = DockStyle.Top

        BGColor = Color.FromArgb(38, 38, 38)
        Font = New Font("Segoe UI", 9)
        SizeMode = TabSizeMode.FillToRight
        ItemSize = New Size(120, 30)
    End Sub
    Function NoiseBrush(colors As Color()) As TextureBrush
        Dim B As New Bitmap(128, 128)
        Dim R As New Random(128)

        For X As Integer = 0 To B.Width - 1
            For Y As Integer = 0 To B.Height - 1
                B.SetPixel(X, Y, colors(R.Next(colors.Length)))
            Next
        Next

        Dim T As New TextureBrush(B)
        B.Dispose()

        Return T
    End Function
    Dim TopTexture As TextureBrush = NoiseBrush({Color.FromArgb(29, 25, 21), Color.FromArgb(31, 27, 23), Color.FromArgb(27, 23, 29)})
    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)

        Dim B As New Bitmap(Width, Height)
        Dim G As Graphics = Graphics.FromImage(B)
        G.Clear(Color.FromArgb(38, 38, 38))

        G.SmoothingMode = SmoothingMode.HighQuality

        Dim BR As New LinearGradientBrush(New Rectangle(-1, 0, Width, 5), Color.FromArgb(251, 83, 150), Color.FromArgb(38, 38, 38), 90S)
        G.FillRectangle(BR, New Rectangle(-1, ItemSize.Height - 5, Width, 5))

        For i = 0 To TabCount - 1

            Dim Base As Rectangle = GetTabRect(i)
            Dim Custom As Rectangle = Base

            Custom.Y -= 2
            Custom.Height -= 12

            If i = SelectedIndex Then
                Dim GP As New GraphicsPath
                GP = CreateRound(Custom, 10)
                G.FillPath(New SolidBrush(AC), GP)

            Else
                G.FillRectangle(New SolidBrush(Color.FromArgb(38, 38, 38)), Custom)

            End If

            G.DrawString(TabPages(i).Text.ToUpper, Font, New SolidBrush(Color.White), Custom, New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
        Next

        e.Graphics.DrawImage(B.Clone, 0, 0)
        G.Dispose()
        B.Dispose()
        MyBase.OnPaint(e)
    End Sub

End Class

