Imports System.Drawing.Drawing2D
Imports System.IO
Imports System.ComponentModel

Partial Public Class Wow
    Inherits Panel
    Public Txt As String = "Friday"
    <PropertyTab("Text")> _
 <DisplayName("Text")> _
    Public Property MC() As String
        Get
            Return Txt
        End Get
        Set(value As String)
            Txt = value
        End Set
    End Property
    Public Sub New()
        Me.SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint, True)
        DoubleBuffered = True
        Me.Padding = New Padding(1, 36, 1, 1)
    End Sub
    Dim x, y As Integer
    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        Dim bm As New Bitmap(Me.Width, Me.Height)
        Dim g As Graphics = Graphics.FromImage(bm)
        ' Dim rect As New Rectangle(0, 0, Me.Width, (Me.Height - 35))
        ' Dim brush As New LinearGradientBrush(rect, Color.FromArgb(250, 250, 250), Color.FromArgb(206, 206, 206), 90.0!)
        'Begin
        'Form
        g.DrawRectangle(New Pen(Color.FromArgb(242, 242, 242)), 0, 0, Me.Width, Me.Height)
        g.FillRectangle(New SolidBrush(Color.FromArgb(242, 242, 242)), 0, 0, Me.Width, Me.Height)
        'Splitter
        g.DrawRectangle(New Pen(Color.FromArgb(229, 229, 229)), 0, 0, Me.Width, 36)
        g.FillRectangle(New SolidBrush(Color.FromArgb(229, 229, 229)), 0, 0, Me.Width, 36)
        'Top
        Dim rect = New Rectangle(0, 0, Me.Width, 35)
        g.DrawRectangle(New Pen(Color.FromArgb(255, 255, 255)), 0, 0, Me.Width, 35)
        g.FillRectangle(New SolidBrush(Color.FromArgb(255, 255, 255)), 0, 0, Me.Width, 35)
        'String
        g.DrawString(Txt, New Font("Arial", 12.5, FontStyle.Regular), New SolidBrush(Color.FromArgb(130, 130, 130)), 14, rect.Height / 2 - 6)
        'Buttons
        '//Close button
        'If New Rectangle(Width - 40, 10, 24, 24).Contains(New Point(mouseX, mouseY)) Then
        '    g.SmoothingMode = SmoothingMode.HighQuality
        '    g.FillRectangle(New SolidBrush(Color.FromArgb(237, 237, 237)), New Rectangle(Width - 40, 10, 24, 24))
        '    g.DrawString("+", New Font("Arials", 14), New SolidBrush(Color.FromArgb(130, 130, 130)), New Point(Width - 40, 10))
        'Else
        '    g.SmoothingMode = SmoothingMode.HighQuality
        '    ' g.FillRectangle(New SolidBrush(Color.FromArgb(237, 237, 237)), New Rectangle(Width - 40, 10, 24, 24))
        '    g.DrawString("+", New Font("Arials", 14), New SolidBrush(Color.FromArgb(130, 130, 130)), New Point(Width - 40, 10))
        'End If
        'End
        e.Graphics.DrawImage(DirectCast(bm.Clone(), Bitmap), 0, 0)
        g.Dispose()
        bm.Dispose()
        MyBase.OnPaint(e)

    End Sub
#Region "ThemeDraggable"



    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)

        Dim clickRect As New Rectangle(Width - 40, 10, 24, 24)
        'If clickRect.Contains(New Point(e.X, e.Y)) Then
        '    Environment.[Exit](0)
        'End If

        '
        MyBase.OnMouseDown(e)
    End Sub

    Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
        MyBase.OnMouseUp(e)
    End Sub

    Private mouseX As Integer
    Private mouseY As Integer
    Protected Overrides Sub OnMouseMove(e As MouseEventArgs)

        mouseX = e.X
        mouseY = e.Y
        If New Rectangle(Width - 40, 10, 24, 24).Contains(New Point(x, y)) Then
            FindForm.Close()
        End If

        MyBase.OnMouseMove(e)
        Invalidate()
    End Sub

#End Region
    Public Function Base64ToImage(base64String As String) As Image
        'I did not write this Function
        ' Convert Base64 String to byte[]
        Dim imageBytes As Byte() = Convert.FromBase64String(base64String)
        Dim ms As New MemoryStream(imageBytes, 0, imageBytes.Length)

        ' Convert byte[] to Image
        ms.Write(imageBytes, 0, imageBytes.Length)
        Dim image__1 As Image = Image.FromStream(ms, True)
        Return image__1
    End Function
End Class