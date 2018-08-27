Imports System.Drawing.Drawing2D
Imports System.ComponentModel
Imports System.Drawing.Text

Public Class ElegantThemeTextBox
    Inherits Control
    Public Function RoundRectangle(ByVal Rectangle As Rectangle, ByVal Curve As Integer) As GraphicsPath
        Dim P As GraphicsPath = New GraphicsPath()
        Dim ArcRectangleWidth As Integer = Curve * 2
        P.AddArc(New Rectangle(Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -180, 90)
        P.AddArc(New Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -90, 90)
        P.AddArc(New Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 0, 90)
        P.AddArc(New Rectangle(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 90, 90)
        P.AddLine(New Point(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y), New Point(Rectangle.X, Curve + Rectangle.Y))
        Return P
    End Function
#Region "Declarations"
    Private _BaseColour As Color = Color.FromArgb(255, 255, 255)
    Private _BorderColour As Color = Color.FromArgb(163, 190, 146)
    Private _LineColour As Color = Color.FromArgb(221, 221, 221)
    Private _TextColour As Color = Color.FromArgb(163, 163, 163)
    Private _LeftPolygonColour As Color = Color.FromArgb(248, 250, 249)
    Public WithEvents TB As TextBox
    Public WithEvents CB As ThirteenComboBox
    Private _TextAlign As HorizontalAlignment = HorizontalAlignment.Left
    Private _MaxLength As Integer = 32767
    Private _ReadOnly As Boolean
    Private _UseSystemPasswordChar As Boolean
    Private _Multiline As Boolean
    Private State As MouseState = MouseState.None
    Private _Pictures As Pictures = Pictures.Username
#End Region

#Region "Properties & Events"

    Public Sub SelectAll()
        TB.Focus()
        TB.SelectAll()
        Invalidate()
    End Sub

    <Category("Control")>
    Public Property BaseColour As Color
        Get
            Return _BaseColour
        End Get
        Set(value As Color)
            _BaseColour = value
        End Set
    End Property

    <Category("Control")>
    Public Property BorderColour As Color
        Get
            Return _BorderColour
        End Get
        Set(value As Color)
            _BorderColour = value
        End Set
    End Property

    <Category("Control")>
    Public Property LineColour As Color
        Get
            Return _LineColour
        End Get
        Set(value As Color)
            _LineColour = value
        End Set
    End Property

    <Category("Control")>
    Public Property TextColour As Color
        Get
            Return _TextColour
        End Get
        Set(value As Color)
            _TextColour = value
        End Set
    End Property

    <Category("Control")>
    Public Property LeftPolygonColour As Color
        Get
            Return _LeftPolygonColour
        End Get
        Set(value As Color)
            _LeftPolygonColour = value
        End Set
    End Property

    Public Property Picture As Pictures
        Get
            Return _Pictures
        End Get
        Set(value As Pictures)
            _Pictures = value
        End Set
    End Property

    <Category("Control")>
    Enum Pictures
        Username
        Password
        None
    End Enum

    <Category("Control")>
    Property TextAlign() As HorizontalAlignment
        Get
            Return _TextAlign
        End Get
        Set(ByVal value As HorizontalAlignment)
            _TextAlign = value
            If TB IsNot Nothing Then
                TB.TextAlign = value
            End If
        End Set
    End Property

    <Category("Control")>
    Property MaxLength() As Integer
        Get
            Return _MaxLength
        End Get
        Set(ByVal value As Integer)
            _MaxLength = value
            If TB IsNot Nothing Then
                TB.MaxLength = value
            End If
        End Set
    End Property

    <Category("Control")>
    Property [ReadOnly]() As Boolean
        Get
            Return _ReadOnly
        End Get
        Set(ByVal value As Boolean)
            _ReadOnly = value
            If TB IsNot Nothing Then
                TB.ReadOnly = value
            End If
        End Set
    End Property

    <Category("Control")>
    Property UseSystemPasswordChar() As Boolean
        Get
            Return _UseSystemPasswordChar
        End Get
        Set(ByVal value As Boolean)
            _UseSystemPasswordChar = value
            If TB IsNot Nothing Then
                TB.UseSystemPasswordChar = value
            End If
        End Set
    End Property

    <Category("Control")>
    Property Multiline() As Boolean
        Get
            Return _Multiline
        End Get
        Set(ByVal value As Boolean)
            _Multiline = value
            If TB IsNot Nothing Then
                TB.Multiline = value

                If value Then
                    TB.Height = Height - 11
                Else
                    Height = TB.Height + 11
                End If

            End If
        End Set
    End Property

    <Category("Control")>
    Overrides Property Text As String
        Get
            Return MyBase.Text
        End Get
        Set(ByVal value As String)
            MyBase.Text = value
            If TB IsNot Nothing Then
                TB.Text = value
            End If
        End Set
    End Property

    <Category("Control")>
    Overrides Property Font As Font
        Get
            Return MyBase.Font
        End Get
        Set(ByVal value As Font)
            MyBase.Font = value
            If TB IsNot Nothing Then
                TB.Font = value
                TB.Location = New Point(3, 5)
                TB.Width = Width - 6

                If Not _Multiline Then
                    Height = TB.Height + 11
                End If
            End If
        End Set
    End Property

    Protected Overrides Sub OnCreateControl()
        MyBase.OnCreateControl()
        If Not Controls.Contains(TB) Then
            Controls.Add(TB)
            Controls.Add(CB)
            CB.BringToFront()
        End If
    End Sub

    Private Sub OnBaseTextChanged(ByVal s As Object, ByVal e As EventArgs)
        Text = TB.Text
    End Sub

    Private Sub OnBaseKeyDown(ByVal s As Object, ByVal e As KeyEventArgs)
        If e.Control AndAlso e.KeyCode = Keys.A Then
            TB.SelectAll()
            e.SuppressKeyPress = True
        End If
        If e.Control AndAlso e.KeyCode = Keys.C Then
            TB.Copy()
            e.SuppressKeyPress = True
        End If
    End Sub

    Protected Overrides Sub OnResize(ByVal e As EventArgs)
        If _Pictures = Pictures.Password Or _Pictures = Pictures.Username Then
            TB.Location = New Point(40, 6)
            TB.Width = Width - 45
        Else
            TB.Location = New Point(5, 6)
            TB.Width = Width - 10
        End If
        If _Multiline Then
            TB.Height = Height - 11
        Else
            Height = TB.Height + 11
        End If
        MyBase.OnResize(e)
    End Sub

#End Region

#Region "Mouse States"
    Friend Enum MouseState As Byte
        ' Fields
        Block = 3
        Down = 2
        None = 0
        Over = 1
    End Enum
    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        State = MouseState.Down
        Invalidate()
    End Sub
    Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
        MyBase.OnMouseUp(e)
        State = MouseState.Over
        Invalidate()
    End Sub
    Protected Overrides Sub OnMouseLeave(e As EventArgs)
        MyBase.OnMouseLeave(e)
        State = MouseState.None : Invalidate()
    End Sub

#End Region
    Event SelectedItemChanged(ByVal e As String)
#Region "Draw Control"

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or _
               ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer Or _
               ControlStyles.SupportsTransparentBackColor, True)
        DoubleBuffered = True
        BackColor = Color.Transparent
        CB = New ThirteenComboBox

        TB = New Windows.Forms.TextBox
        TB.BackColor = _BaseColour
        TB.Height = 190
        TB.Font = New Font("Segoe UI", 9)
        TB.Text = Text
        TB.BackColor = _BaseColour
        TB.ForeColor = _TextColour
        TB.MaxLength = _MaxLength
        TB.Multiline = False
        TB.ReadOnly = _ReadOnly
        TB.UseSystemPasswordChar = _UseSystemPasswordChar
        TB.BorderStyle = BorderStyle.None
        TB.Location = New Point(40, 6)
        TB.Width = Width - 45
        CB.Location = New Point(Width - 150, 1)
        CB.Width = 150
        CB.Items.Add("Any")
        CB.Items.Add("Subbed")
        CB.Items.Add("Dubbed")
       

        CB.SelectedIndex = "0"
        AddHandler TB.TextChanged, AddressOf OnBaseTextChanged
        AddHandler CB.SelectedIndexChanged, AddressOf CB_SelectedChanged
        AddHandler TB.KeyDown, AddressOf OnBaseKeyDown
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        Dim B As New Bitmap(Width, Height)
        Dim G = Graphics.FromImage(B)
        Dim GP As GraphicsPath
        Dim Base As New Rectangle(0, 0, Width, Height)
        With G
            .TextRenderingHint = TextRenderingHint.ClearTypeGridFit
            .SmoothingMode = SmoothingMode.HighQuality
            .PixelOffsetMode = PixelOffsetMode.HighQuality
            .Clear(BackColor)
            Dim P() As Point = {New Point(0, 0), New Point(28, 0), New Point(28, Height / 2 - 6), New Point(34, Height / 2), _
                               New Point(28, Height / 2 + 6), New Point(28, Height), New Point(0, Height)}
            Dim P1() As Point = {New Point(28, 0), New Point(28, Height / 2 - 6), New Point(34, Height / 2), _
                               New Point(28, Height / 2 + 6), New Point(28, Height)}
            GP = RoundRectangle(Base, 1)
            If _Pictures = Pictures.Username Then
                CB.ShowGenreText = True
                TB.BackColor = _BaseColour
                TB.ForeColor = _TextColour
                TB.Location = New Point(40, 6)
                TB.Width = Width - 200
                CB.Location = New Point(Width - 150, 1)
                CB.Width = 148

                .FillPath(New SolidBrush(_BaseColour), GP)
                .FillPolygon(New SolidBrush(_LeftPolygonColour), P)
                .DrawLines(New Pen(_LineColour, 1), P1)
                .DrawPath(New Pen((_BorderColour), 2), GP)
                .DrawImage(My.Resources.mag, New Rectangle(5, 3, 20, 20))
                e.Graphics.DrawLine(New Pen(Color.FromArgb(163, 190, 146)), New Point(Width - 170, 0), New Point(Width - 170, Me.Height - 1))
                '.FillEllipse(New SolidBrush(_TextColour), New Rectangle(10, 5, 10, 10))
                '.DrawLine(New Pen(_TextColour), New Point(15, 15), New Point(20, 25))
                'Dim P2() As Point = {New Point(5, 22), New Point(9, 17)}
                'Dim SecondLine() As Point = {New Point(19, 17), New Point(23, 22)}
                '.DrawLines(New Pen(_TextColour), P2)
                '.DrawLines(New Pen(_TextColour), SecondLine)
                'Dim CurvePoints() As PointF = {New Point(9, 17), New Point(14, 19), New Point(19, 17)}
                '.DrawCurve(New Pen(_TextColour), CurvePoints)
            ElseIf _Pictures = Pictures.Password Then
                TB.BackColor = _BaseColour
                TB.ForeColor = _TextColour
                TB.Location = New Point(40, 6)
                TB.Width = Width - 45
                .FillPath(New SolidBrush(_BaseColour), GP)
                .FillPolygon(New SolidBrush(_LeftPolygonColour), P)
                .DrawLines(New Pen(_LineColour, 1), P1)
                .DrawPath(New Pen((_BorderColour), 2), GP)
                .FillEllipse(New SolidBrush(_TextColour), New Rectangle(14, 5, 9, 9))
                .FillEllipse(New SolidBrush(_LeftPolygonColour), New Rectangle(18, 7, 3, 3))
                Dim BaseKey() As Point = {New Point(18, 7), New Point(6, 18), New Point(6, 21), New Point(9, 21), _
                                          New Point(9, 18), New Point(11, 19), New Point(10, 18), New Point(12, 18), _
                                          New Point(11, 17), New Point(13, 17), New Point(12, 16), New Point(14, 16), _
                                          New Point(13, 15), New Point(15, 15), New Point(15, 14), New Point(16, 14), _
                                          New Point(15, 13)}
                .DrawLines(New Pen(_TextColour), BaseKey)
            Else
                .FillPath(New SolidBrush(_BaseColour), GP)
                .DrawPath(New Pen((_BorderColour), 2), GP)
                TB.Location = New Point(5, 6)
                TB.Width = Width - 10
            End If
        End With
        MyBase.OnPaint(e)
        G.Dispose()
        e.Graphics.InterpolationMode = 7
        e.Graphics.DrawImageUnscaled(B, 0, 0)
        B.Dispose()
    End Sub

#End Region

    Private Sub CB_SelectedChanged(sender As Object, e As EventArgs) Handles CB.SelectedIndexChanged
        RaiseEvent SelectedItemChanged(CB.SelectedItem.ToString)
    End Sub

End Class
Public Class ThirteenComboBox : Inherits ComboBox
#Region " Control Help - Properties & Flicker Control "
    Property ShowGenreText As Boolean = False
    Enum ColorSchemes
        Light
        Dark
    End Enum
    Private _ColorScheme As ColorSchemes
    Public Property ColorScheme() As ColorSchemes
        Get
            Return _ColorScheme
        End Get
        Set(ByVal value As ColorSchemes)
            _ColorScheme = value
            Invalidate()
        End Set
    End Property

    Private _AccentColor As Color
    Public Property AccentColor() As Color
        Get
            Return _AccentColor
        End Get
        Set(ByVal value As Color)
            _AccentColor = value
            Invalidate()
        End Set
    End Property

    Private _StartIndex As Integer = 0
    Private Property StartIndex As Integer
        Get
            Return _StartIndex
        End Get
        Set(ByVal value As Integer)
            _StartIndex = value
            Try
                MyBase.SelectedIndex = value
            Catch
            End Try
            Invalidate()
        End Set
    End Property
    Sub ReplaceItem(ByVal sender As System.Object, ByVal e As System.Windows.Forms.DrawItemEventArgs) Handles Me.DrawItem
        e.DrawBackground()
        Try
            If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
                e.Graphics.FillRectangle(New SolidBrush(_AccentColor), e.Bounds)
            Else
                Select Case ColorScheme
                    Case ColorSchemes.Dark
                        e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(22, 23, 27)), e.Bounds)
                    Case ColorSchemes.Light
                        e.Graphics.FillRectangle(New SolidBrush(Color.White), e.Bounds)
                End Select
            End If
            Select Case ColorScheme
                Case ColorSchemes.Dark
                    e.Graphics.DrawString(MyBase.GetItemText(MyBase.Items(e.Index)), e.Font, Brushes.White, e.Bounds)
                Case ColorSchemes.Light
                    e.Graphics.DrawString(MyBase.GetItemText(MyBase.Items(e.Index)), e.Font, Brushes.Black, e.Bounds)
            End Select
        Catch
        End Try
    End Sub
    Protected Sub DrawTriangle(ByVal Clr As Color, ByVal FirstPoint As Point, ByVal SecondPoint As Point, ByVal ThirdPoint As Point, ByVal G As Graphics)
        Dim points As New List(Of Point)()
        points.Add(FirstPoint)
        points.Add(SecondPoint)
        points.Add(ThirdPoint)
        G.FillPolygon(New SolidBrush(Clr), points.ToArray())
    End Sub

#End Region

    Sub New()
        MyBase.New()
        SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        SetStyle(ControlStyles.ResizeRedraw, True)
        SetStyle(ControlStyles.UserPaint, True)
        SetStyle(ControlStyles.DoubleBuffer, True)
        SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        DrawMode = Windows.Forms.DrawMode.OwnerDrawFixed
        BackColor = Color.FromArgb(25, 25, 25)
        ForeColor = Color.White
        AccentColor = Color.DodgerBlue
        ColorScheme = ColorSchemes.Dark
        DropDownStyle = ComboBoxStyle.DropDownList
        Font = New Font("Segoe UI Semilight", 9.75F)
        StartIndex = 0
        DoubleBuffered = True
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim B As New Bitmap(Width, Height)
        Dim G As Graphics = Graphics.FromImage(B)
        Dim Curve As Integer = 2

        G.SmoothingMode = SmoothingMode.HighQuality
        If ShowGenreText = False Then
            Select Case ColorScheme
                Case ColorSchemes.Dark
                    G.Clear(Color.FromArgb(22, 23, 27))
                    G.DrawLine(New Pen(Color.White, 2), New Point(Width - 18, 10), New Point(Width - 14, 14))
                    G.DrawLine(New Pen(Color.White, 2), New Point(Width - 14, 14), New Point(Width - 10, 10))
                    G.DrawLine(New Pen(Color.White), New Point(Width - 14, 15), New Point(Width - 14, 14))

            End Select
            '    G.DrawRectangle(New Pen(Color.FromArgb(100, 100, 100)), New Rectangle(0, 0, Width - 1, Height - 1))


            Try
                Select Case ColorScheme
                    Case ColorSchemes.Dark
                        G.DrawString(Text, Font, Brushes.White, New Rectangle(7, 0, Width - 1, Height - 1), New StringFormat With {.LineAlignment = StringAlignment.Center, .Alignment = StringAlignment.Near})
                    Case ColorSchemes.Light
                        G.DrawString(Text, Font, Brushes.Black, New Rectangle(7, 0, Width - 1, Height - 1), New StringFormat With {.LineAlignment = StringAlignment.Center, .Alignment = StringAlignment.Near})
                End Select
            Catch
            End Try
        Else
            Select Case ColorScheme
                Case ColorSchemes.Dark
                    G.Clear(Color.FromArgb(22, 23, 27))
                    G.DrawLine(New Pen(Color.White, 2), New Point(Width - 18, 10), New Point(Width - 14, 14))
                    G.DrawLine(New Pen(Color.White, 2), New Point(Width - 14, 14), New Point(Width - 10, 10))
                    G.DrawLine(New Pen(Color.White), New Point(Width - 14, 15), New Point(Width - 14, 14))

            End Select
            '    G.DrawRectangle(New Pen(Color.FromArgb(100, 100, 100)), New Rectangle(0, 0, Width - 1, Height - 1))


            Try
                Select Case ColorScheme
                    Case ColorSchemes.Dark
                        G.DrawString("Genre: " + Text, Font, New SolidBrush(Color.FromArgb(163, 163, 163)), New Rectangle(7, 0, Width - 1, Height - 1), New StringFormat With {.LineAlignment = StringAlignment.Center, .Alignment = StringAlignment.Near})

                End Select
            Catch
            End Try
        End If
        e.Graphics.DrawImage(B.Clone(), 0, 0)
        G.Dispose() : B.Dispose()
    End Sub
End Class
