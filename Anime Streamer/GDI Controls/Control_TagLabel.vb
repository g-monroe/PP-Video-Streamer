Imports System.ComponentModel
Imports System.Drawing.Drawing2D

Public Class TagLabel
    Inherits Control

    Private TagColor As Color = Color.FromArgb(231, 82, 150)

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint, True)
        SetStyle(ControlStyles.OptimizedDoubleBuffer, True)
        ' SetStyle(ControlStyles.SupportsTransparentBackColor, True)
        SetStyle(ControlStyles.UserPaint, True)
        BackColor = Color.Gainsboro
        Font = New Font("Segoe UI", 12)
    End Sub
    Public TagMainColor As Color = Color.FromArgb(251, 83, 150)

    <PropertyTab("TagMainColor")> _
    <DisplayName("TagMainColor")> _
    Public Property TagMColor() As Color
        Get
            Return TagMainColor
        End Get
        Set(value As Color)
            TagMainColor = value
        End Set
    End Property
    Public TagMainColor2 As Color = Color.FromArgb(231, 63, 130)

    <PropertyTab("TagMainColor2")> _
    <DisplayName("TagMainColor2")> _
    Public Property TagMColor2() As Color
        Get
            Return TagMainColor2
        End Get
        Set(value As Color)
            TagMainColor2 = value
        End Set
    End Property
    Public Tag3D As Boolean = False

    <PropertyTab("Tag3D")> _
    <DisplayName("Tag3D")> _
    Public Property Tag3D2() As Boolean
        Get
            Return Tag3D
        End Get
        Set(value As Boolean)
            Tag3D = value
        End Set
    End Property
    Public TagTextColor As Color = Color.White

    <PropertyTab("TagTextColor")> _
    <DisplayName("TagTextColor")> _
    Public Property TagTColor() As Color
        Get
            Return TagTextColor
        End Get
        Set(value As Color)
            TagTextColor = value
        End Set
    End Property
    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        MyBase.OnPaint(e)

        Dim G As Graphics = e.Graphics

        With G
            .Clear(BackColor)
            .SmoothingMode = Drawing2D.SmoothingMode.HighQuality
            .InterpolationMode = Drawing2D.InterpolationMode.HighQualityBicubic
            .TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit
        End With

        If Tag3D = False Then
            Dim Path As GraphicsPath = RoundRec(0, 0, Width - 1, Height - 1, 12)
            G.FillPath(New SolidBrush(TagMainColor), Path)
            G.DrawPath(New Pen(TagMainColor), Path)
            Path.Dispose()
        Else
            Dim Path2 As GraphicsPath = RoundRec(0, 0, Width - 1, Height - 1, 12)
            G.FillPath(New SolidBrush(TagMainColor2), Path2)
            G.DrawPath(New Pen(TagMainColor2), Path2)
            Dim Path As GraphicsPath = RoundRec(0, 0, Width - 1, Height - 5, 12)
            G.FillPath(New SolidBrush(TagMainColor), Path)
            G.DrawPath(New Pen(TagMainColor), Path)

            Path.Dispose()
        End If

        Dim textformat As New StringFormat
        With textformat
            .Alignment = StringAlignment.Center
            .LineAlignment = StringAlignment.Center
        End With

        G.DrawString(Text, Font, New SolidBrush(TagTextColor), ClientRectangle, textformat)



    End Sub

    Public Function RoundRec(ByVal X As Integer, ByVal Y As Integer, _
       ByVal Width As Integer, ByVal Height As Integer, ByVal diameter As Integer) As System.Drawing.Drawing2D.GraphicsPath

        ''the 'diameter' parameter changes the size of the rounded region

        Dim graphics_path As New System.Drawing.Drawing2D.GraphicsPath

        Dim BaseRect As New RectangleF(X, Y, Width, Height)
        Dim ArcRect As New RectangleF(BaseRect.Location, New SizeF(diameter, diameter))

        'top left Arc
        graphics_path.AddArc(ArcRect, 180, 90)
        graphics_path.AddLine(X + CInt(diameter / 2), _
        Y, X + Width - CInt(diameter / 2), Y)

        ' top right arc
        ArcRect.X = BaseRect.Right - diameter
        graphics_path.AddArc(ArcRect, 270, 90)
        graphics_path.AddLine(X + Width, _
        Y + CInt(diameter / 2), X + Width, _
                         Y + Height - CInt(diameter / 2))

        ' bottom right arc
        ArcRect.Y = BaseRect.Bottom - diameter
        graphics_path.AddArc(ArcRect, 0, 90)
        graphics_path.AddLine(X + CInt(diameter / 2), _
        Y + Height, X + Width - CInt(diameter / 2), _
                         Y + Height)

        ' bottom left arc
        ArcRect.X = BaseRect.Left
        graphics_path.AddArc(ArcRect, 90, 90)
        graphics_path.AddLine(X, Y + CInt(diameter / 2), _
        X, Y + Height - CInt(diameter / 2))

        Return graphics_path

    End Function

End Class