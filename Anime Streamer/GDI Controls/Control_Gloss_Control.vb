Imports System, System.IO, System.Collections.Generic, System.Runtime.InteropServices, System.ComponentModel
Imports System.Drawing, System.Drawing.Drawing2D, System.Drawing.Imaging, System.Windows.Forms

Public Class RecuperareIIComboBox : Inherits ComboBox
#Region " Control Help - Properties & Flicker Control "
    Private _StartIndex As Integer = 0
    Public Event SelectedItemChanged(ByVal sender As Object)
    Public Property StartIndex As Integer
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

        Try
            If (e.State And DrawItemState.Selected) = DrawItemState.Selected Then
                e.Graphics.FillRectangle(New SolidBrush(_highlightColor), e.Bounds)
                Dim gloss As New LinearGradientBrush(e.Bounds, Color.FromArgb(15, Color.White), Color.FromArgb(0, Color.White), 90S)
                e.Graphics.FillRectangle(gloss, New Rectangle(New Point(e.Bounds.X, e.Bounds.Y), New Size(e.Bounds.Width, e.Bounds.Height)))
                e.Graphics.DrawRectangle(New Pen(Color.FromArgb(50, Color.Black)) With {.DashStyle = DashStyle.Dot}, New Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width - 1, e.Bounds.Height - 1))
                ' RaiseEvent SelectedItemChanged(Me)
            Else
                e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(255, 255, 255, 255)), e.Bounds)
            End If
            Using b As New SolidBrush(Color.Black)
                e.Graphics.DrawString(MyBase.GetItemText(MyBase.Items(e.Index)), e.Font, b, New Rectangle(e.Bounds.X + 2, e.Bounds.Y, e.Bounds.Width - 4, e.Bounds.Height))
            End Using
        Catch
        End Try
        e.DrawFocusRectangle()
    End Sub
    Protected Sub DrawTriangle(ByVal Clr As Color, ByVal FirstPoint As Point, ByVal SecondPoint As Point, ByVal ThirdPoint As Point, ByVal G As Graphics)
        Dim points As New List(Of Point)()
        points.Add(FirstPoint)
        points.Add(SecondPoint)
        points.Add(ThirdPoint)
        G.FillPolygon(New SolidBrush(Clr), points.ToArray)
    End Sub
    Private _highlightColor As Color = Color.FromArgb(251, 83, 150)
    Public Property ItemHighlightColor() As Color
        Get
            Return _highlightColor
        End Get
        Set(ByVal v As Color)
            _highlightColor = v
            Invalidate()
        End Set
    End Property
#End Region

    Sub New()
        MyBase.New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or _
        ControlStyles.ResizeRedraw Or _
        ControlStyles.UserPaint Or _
        ControlStyles.DoubleBuffer Or _
        ControlStyles.SupportsTransparentBackColor, True)
        DrawMode = Windows.Forms.DrawMode.OwnerDrawFixed
        BackColor = Color.Transparent
        ForeColor = Color.FromArgb(27, 94, 137)
        Font = New Font("Verdana", 6.75F, FontStyle.Bold)
        DropDownStyle = ComboBoxStyle.DropDownList
        DoubleBuffered = True
        Size = New Size(Width, 21)
        ItemHeight = 16
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        Dim B As New Bitmap(Width, Height)
        Dim G As Graphics = Graphics.FromImage(B)
        G.SmoothingMode = SmoothingMode.HighQuality


        G.Clear(BackColor)
        Dim bodyGradNone As New LinearGradientBrush(New Rectangle(0, 0, Width - 1, Height - 2), Color.FromArgb(245, 245, 245), Color.FromArgb(230, 230, 230), 90S)
        G.FillRectangle(bodyGradNone, bodyGradNone.Rectangle)
        Dim bodyInBorderNone As New LinearGradientBrush(New Rectangle(0, 0, Width - 1, Height - 3), Color.FromArgb(252, 252, 252), Color.FromArgb(249, 249, 249), 90S)
        G.DrawRectangle(New Pen(bodyInBorderNone), New Rectangle(1, 1, Width - 3, Height - 4))
        G.DrawRectangle(New Pen(Color.FromArgb(189, 189, 189)), New Rectangle(0, 0, Width - 1, Height - 2))
        G.DrawLine(New Pen(Color.FromArgb(200, 168, 168, 168)), New Point(1, Height - 1), New Point(Width - 2, Height - 1))
        DrawTriangle(Color.FromArgb(251, 83, 150), New Point(Width - 14, 8), New Point(Width - 7, 8), New Point(Width - 11, 12), G)
        G.DrawLine(New Pen(Color.FromArgb(231, 63, 130)), New Point(Width - 14, 8), New Point(Width - 8, 8))

        'Draw Separator line
        G.DrawLine(New Pen(Color.White), New Point(Width - 22, 1), New Point(Width - 22, Height - 3))
        G.DrawLine(New Pen(Color.FromArgb(189, 189, 189)), New Point(Width - 21, 1), New Point(Width - 21, Height - 3))
        G.DrawLine(New Pen(Color.White), New Point(Width - 20, 1), New Point(Width - 20, Height - 3))
        Try
            G.DrawString(Text, Font, New SolidBrush(Color.FromArgb(251, 83, 150)), New Rectangle(5, -1, Width - 20, Height), New StringFormat With {.LineAlignment = StringAlignment.Center, .Alignment = StringAlignment.Near})
        Catch
        End Try

        e.Graphics.DrawImage(B.Clone(), 0, 0)
        G.Dispose() : B.Dispose()
    End Sub
End Class



