Imports System.Drawing.Drawing2D
Imports System.ComponentModel

Public Class PositronListBox
    Inherits ListBox
    Private mShowScroll As Boolean
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
    Protected Overrides ReadOnly Property CreateParams() As System.Windows.Forms.CreateParams
        Get
            Dim cp As CreateParams = MyBase.CreateParams
            If Not mShowScroll Then
                cp.Style = cp.Style And Not &H200000
            End If
            Return cp
        End Get
    End Property
    <Description("Indicates whether the vertical scrollbar appears or not.")> _
    Public Property ShowScrollbar() As Boolean
        Get
            Return mShowScroll
        End Get
        Set(value As Boolean)
            If value = mShowScroll Then
                Return
            End If
            mShowScroll = value
            If Handle <> IntPtr.Zero Then
                RecreateHandle()
            End If
        End Set
    End Property

    Public Sub New()
        SetStyle(ControlStyles.DoubleBuffer, True)
        BorderStyle = System.Windows.Forms.BorderStyle.None
        DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed
        ItemHeight = 16
        ForeColor = Color.Black
        BackColor = Color.FromArgb(240, 240, 240)
        IntegralHeight = False
        Font = New Font("Verdana", 8)
        ScrollAlwaysVisible = False
    End Sub
    Protected Sub DrawBorders(p1 As Pen)
        DrawBorders(p1, 0, 0, Width, Height)
    End Sub
    Protected Sub DrawBorders(p1 As Pen, offset As Integer)
        DrawBorders(p1, 0, 0, Width, Height, offset)
    End Sub
    Protected Sub DrawBorders(p1 As Pen, x As Integer, y As Integer, width As Integer, height As Integer)
        CreateGraphics().DrawRectangle(p1, x, y, width - 1, height - 1)
    End Sub
    Protected Sub DrawBorders(p1 As Pen, x As Integer, y As Integer, width As Integer, height As Integer, offset As Integer)
        DrawBorders(p1, x + offset, y + offset, width - (offset * 2), height - (offset * 2))
    End Sub
    Protected Overrides Sub OnDrawItem(e As System.Windows.Forms.DrawItemEventArgs)
        If (e.Index >= 0) Then
            Dim ItemBounds As Rectangle = e.Bounds
            e.Graphics.FillRectangle(New SolidBrush(BackColor), ItemBounds)

            If ((e.State.ToString().IndexOf("Selected,") + 1) > 0) Then
                Dim LGB1 As New LinearGradientBrush(ItemBounds, Color1, Color2, 90)
                Dim HB1 As New HatchBrush(HatchStyle.DarkUpwardDiagonal, Color.FromArgb(10, Color.White), Color.Transparent)
                e.Graphics.FillRectangle(LGB1, ItemBounds)
                e.Graphics.FillRectangle(HB1, ItemBounds)
                e.Graphics.DrawString(Items(e.Index).ToString(), Font, New SolidBrush(Color.FromArgb(255, 255, 255)), 5, Convert.ToInt32((e.Bounds.Y + ((e.Bounds.Height / 2) - 7))))
            Else
                Try
                    e.Graphics.DrawString(Items(e.Index).ToString(), Font, New SolidBrush(Color.FromArgb(100, 100, 100)), 5, Convert.ToInt32((e.Bounds.Y + ((e.Bounds.Height / 2) - 7))))
                Catch
                End Try
            End If
        End If
        'DrawBorders(new Pen(new SolidBrush(Color.FromArgb(200, 200, 200))), 1);
        'DrawBorders(new Pen(new SolidBrush(Color.FromArgb(240, 240, 240))), 1);
        MyBase.OnDrawItem(e)
    End Sub
    Public Sub CustomPaint()
        CreateGraphics().DrawRectangle(New Pen(Color.FromArgb(210, 210, 210)), New Rectangle(0, 0, Width - 1, Height - 1))
    End Sub
End Class
