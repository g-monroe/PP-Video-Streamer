Imports System.Drawing.Drawing2D

Partial Public Class NanoThemeContainer
    Inherits Panel
    Public Sub New()
        Me.SetStyle(ControlStyles.DoubleBuffer Or ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint, True)
        DoubleBuffered = True
    End Sub
    Protected Overrides Sub OnHandleCreated(e As EventArgs)
        FindForm().FormBorderStyle = FormBorderStyle.None
        Me.Dock = DockStyle.Fill
        MyBase.OnHandleCreated(e)
    End Sub
    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        Dim bm As New Bitmap(Me.Width, Me.Height)
        Dim g As Graphics = Graphics.FromImage(bm)
        Me.Padding = New Padding(1, 32, 1, 1)
        '  Dim rect As New Rectangle(0, 0, Me.Width, (Me.Height - 35))
        ' Dim brush As New LinearGradientBrush(rect, Color.FromArgb(250, 250, 250), Color.FromArgb(206, 206, 206), 90.0!)
        'Begin
        '//back
        g.FillRectangle(New SolidBrush(Color.FromArgb(28, 28, 28)), New Rectangle(0, 0, Me.Width, Me.Height))
        '//Border
        g.DrawRectangle(New Pen(Color.FromArgb(4, 14, 19)), New Rectangle(0, 0, Me.Width - 1, Me.Height - 1))
        '//Left Top Linear Gradient Splitter
        Dim rect As New Rectangle(1, 1, Me.Width / 2 - 1, 1)
        Dim brush As New LinearGradientBrush(rect, Color.FromArgb(28, 28, 28), Color.FromArgb(250, 250, 250), 360.0!)
        g.FillRectangle(brush, rect)
        '//Right Top Linear Gradient Splitter
        rect = New Rectangle(Me.Width / 2 - 1, 1, Me.Width / 2, 1)
        brush = New LinearGradientBrush(rect, Color.FromArgb(28, 28, 28), Color.FromArgb(250, 250, 250), 180.0!)
        g.FillRectangle(brush, rect)
        '//Middle Placement 
        g.FillRectangle(New SolidBrush(Color.FromArgb(250, 250, 250)), New Rectangle(Me.Width / 2 - 1, 1, 1, 1))

        '//Text
        g.DrawString(Me.FindForm.Text, New Font("Arial", 10, FontStyle.Regular), New SolidBrush(Color.White), New Rectangle(24, 13, Me.Width, Me.Height))
        '//Image
        g.DrawIcon(Me.FindForm.Icon, New Rectangle(7, 12, 16, 16))

        'Line
        '//Middle Left Linear Gradient Splitter
        rect = New Rectangle(1, 30, Me.Width / 2 - 1, 2)
        brush = New LinearGradientBrush(rect, Color.FromArgb(28, 28, 28), Color.FromArgb(231, 63, 130), 360.0!)
        g.FillRectangle(brush, rect)
        '//Middle Right Linear Gradient Splitter
        rect = New Rectangle(Me.Width / 2 - 1, 30, Me.Width / 2, 2)
        brush = New LinearGradientBrush(rect, Color.FromArgb(28, 28, 28), Color.FromArgb(231, 63, 130), 180.0!)
        g.FillRectangle(brush, rect)
        '//Middle Middle Placement 
        g.FillRectangle(New SolidBrush(Color.FromArgb(231, 63, 130)), New Rectangle(Me.Width / 2 - 1, 30, 1, 2))





        '//Left Bottom Linear Gradient Splitter
        rect = New Rectangle(1, Me.Height - 3, Me.Width / 2 - 1, 1)
        brush = New LinearGradientBrush(rect, Color.FromArgb(28, 28, 28), Color.FromArgb(250, 250, 250), 360.0!)
        g.FillRectangle(brush, rect)
        '//Right Bottom Linear Gradient Splitter
        rect = New Rectangle(Me.Width / 2 - 1, Me.Height - 3, Me.Width / 2, 1)
        brush = New LinearGradientBrush(rect, Color.FromArgb(28, 28, 28), Color.FromArgb(250, 250, 250), 180.0!)
        g.FillRectangle(brush, rect)
        '//Middle Placement
        g.FillRectangle(New SolidBrush(Color.FromArgb(250, 250, 250)), New Rectangle(Me.Width / 2 - 4, Me.Height - 3, 5, 1))
        'end 
        e.Graphics.DrawImage(DirectCast(bm.Clone(), Bitmap), 0, 0)
        g.Dispose()
        bm.Dispose()
        MyBase.OnPaint(e)
    End Sub
    Dim x, y As Integer
#Region "ThemeDraggable"

    Private savePoint As New Point(0, 0)
    Private isDragging As Boolean = False

    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        Dim dragRect As New Rectangle(0, 0, Me.Width, 30)
        If dragRect.Contains(New Point(e.X, e.Y)) Then
            isDragging = True
            savePoint = New Point(e.X, e.Y)
        End If
        Dim clickRect As New Rectangle(Me.Width - 24, 10, 13, 12)
        If clickRect.Contains(New Point(e.X, e.Y)) Then
            Environment.[Exit](0)
        End If
        MyBase.OnMouseDown(e)
    End Sub

    Protected Overrides Sub OnMouseUp(e As MouseEventArgs)
        isDragging = False
        MyBase.OnMouseUp(e)
    End Sub

    Private mouseX As Integer
    Private mouseY As Integer
    Protected Overrides Sub OnMouseMove(e As MouseEventArgs)
        mouseX = e.X
        mouseY = e.Y
        If New Rectangle(Width - 22, 5, 15, 15).Contains(New Point(x, y)) Then
            FindForm.Close()
        End If
        If isDragging Then
            Dim screenPoint As Point = PointToScreen(e.Location)

            FindForm().Location = New Point(screenPoint.X - Me.savePoint.X, screenPoint.Y - Me.savePoint.Y)
        End If
        MyBase.OnMouseMove(e)
        Invalidate()
    End Sub

#End Region
    Private Sub Theme_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Me.Refresh()
    End Sub
End Class