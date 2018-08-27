Imports System.Drawing.Drawing2D
Imports System.ComponentModel

Module CustomFunctions
    Function ToBrush(ByVal A As Integer, ByVal R As Integer, ByVal G As Integer, ByVal B As Integer) As Brush
        Return New SolidBrush(Color.FromArgb(A, R, G, B))
    End Function
    Function ToBrush(ByVal R As Integer, ByVal G As Integer, ByVal B As Integer) As Brush
        Return New SolidBrush(Color.FromArgb(R, G, B))
    End Function
    Function ToBrush(ByVal A As Integer, ByVal C As Color) As Brush
        Return New SolidBrush(Color.FromArgb(A, C))
    End Function
    Function ToBrush(ByVal Pen As Pen) As Brush
        Return New SolidBrush(Pen.Color)
    End Function
    Function ToBrush(ByVal Color As Color) As Brush
        Return New SolidBrush(Color)
    End Function
    Function ToPen(ByVal A As Integer, ByVal R As Integer, ByVal G As Integer, ByVal B As Integer) As Pen
        Return New Pen(New SolidBrush(Color.FromArgb(A, R, G, B)))
    End Function
    Function ToPen(ByVal R As Integer, ByVal G As Integer, ByVal B As Integer) As Pen
        Return New Pen(New SolidBrush(Color.FromArgb(R, G, B)))
    End Function
    Function ToPen(ByVal A As Integer, ByVal C As Color) As Pen
        Return New Pen(New SolidBrush(Color.FromArgb(A, C)))
    End Function
    Function ToPen(ByVal Brush As SolidBrush) As Pen
        Return New Pen(Brush)
    End Function
    Function ToPen(ByVal Color As Color) As Pen
        Return New Pen(New SolidBrush(Color))
    End Function
    Public Function RoundRect(ByVal Rectangle As Rectangle, ByVal Curve As Integer) As GraphicsPath
        Dim P As GraphicsPath = New GraphicsPath()
        Dim ArcRectangleWidth As Integer = Curve * 2
        P.AddArc(New Rectangle(Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -180, 90)
        P.AddArc(New Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -90, 90)
        P.AddArc(New Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 0, 90)
        P.AddArc(New Rectangle(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 90, 90)
        P.AddLine(New Point(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y), New Point(Rectangle.X, Curve + Rectangle.Y))
        P.CloseAllFigures()
        Return P
    End Function
    Public Function RoundRect(ByVal X As Integer, ByVal Y As Integer, ByVal Width As Integer, ByVal Height As Integer, ByVal Curve As Integer) As GraphicsPath
        Dim Rectangle As Rectangle = New Rectangle(X, Y, Width, Height)
        Dim P As GraphicsPath = New GraphicsPath()
        Dim ArcRectangleWidth As Integer = Curve * 2
        P.AddArc(New Rectangle(Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -180, 90)
        P.AddArc(New Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), -90, 90)
        P.AddArc(New Rectangle(Rectangle.Width - ArcRectangleWidth + Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 0, 90)
        P.AddArc(New Rectangle(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y, ArcRectangleWidth, ArcRectangleWidth), 90, 90)
        P.AddLine(New Point(Rectangle.X, Rectangle.Height - ArcRectangleWidth + Rectangle.Y), New Point(Rectangle.X, Curve + Rectangle.Y))
        P.CloseAllFigures()
        Return P
    End Function
End Module
Class PlainTabControl
    Inherits TabControl

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or _
        ControlStyles.ResizeRedraw Or _
        ControlStyles.UserPaint Or _
        ControlStyles.DoubleBuffer, True)

    End Sub
    Protected Overrides Sub CreateHandle()
        MyBase.CreateHandle()
        SizeMode = TabSizeMode.Normal
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
    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim G As Graphics = e.Graphics
        G.Clear(Color.FromArgb(236, 237, 239))
        ' SelectedTab.BackColor = Color.FromArgb(29, 25, 21)
        Dim Rect = New Rectangle(0, 0, Me.Width, Me.Height)
        e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(38, 38, 38)), Rect)
    End Sub
    Private Color1 As Color = Color.FromArgb(231, 82, 150)
    Private Color2 As Color = Color.FromArgb(233, 57, 137)
    <PropertyTab("Color1")> _
    <DisplayName("Color1")> _
    Public Property Color1p() As Color
        Get
            Return Color1
        End Get
        Set(value As Color)
            Color1 = value
        End Set
    End Property
    <PropertyTab("Color2")> _
  <DisplayName("Color2")> _
    Public Property Color2p() As Color
        Get
            Return Color2
        End Get
        Set(value As Color)
            Color2 = value
        End Set
    End Property
End Class

