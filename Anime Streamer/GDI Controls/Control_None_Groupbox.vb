Imports System.Drawing.Drawing2D

Class Simple_Groupbox
    Inherits ContainerControl

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.OptimizedDoubleBuffer Or _
                 ControlStyles.UserPaint Or ControlStyles.ResizeRedraw, True)
        BackColor = Color.White
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As System.Windows.Forms.PaintEventArgs)
        MyBase.OnPaint(e)

        Dim G As Graphics = e.Graphics

        G.SmoothingMode = SmoothingMode.HighQuality
        G.Clear(Parent.BackColor)

        Dim mainRect As New Rectangle(0, 0, Width - 1, Height - 1)
        G.FillRectangle(New SolidBrush(Color.FromArgb(45, 45, 45)), mainRect)
        G.DrawRectangle(New Pen(Color.FromArgb(45, 45, 45)), mainRect)
    End Sub
End Class