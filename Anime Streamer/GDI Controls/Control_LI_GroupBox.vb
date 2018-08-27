Imports System.Drawing.Drawing2D
Imports System.ComponentModel
Imports System.Runtime.InteropServices
'.::VibeLander Theme::.
'Author:   UnReLaTeDScript
'Credits:  Aeonhack [Themebase]
'Version:  1.0

Class GroupPanelBox
    Inherits ThemeContainerControl
    Private _Checked As Boolean
    Sub New()
        AllowTransparent()
    End Sub
    Overrides Sub PaintHook()
        Me.Padding = New Padding(1, 32, 1, 1)
        Me.Font = New Font("Tahoma", 10)
        Me.ForeColor = Color.FromArgb(40, 40, 40)
        G.SmoothingMode = SmoothingMode.AntiAlias
        G.Clear(Color.FromArgb(245, 245, 245))
        G.FillRectangle(New SolidBrush(Color.FromArgb(231, 231, 231)), New Rectangle(0, 0, Width, 30))
        G.DrawLine(New Pen(Color.FromArgb(233, 238, 240)), 1, 1, Width - 2, 1)
        G.DrawRectangle(New Pen(Color.FromArgb(214, 214, 214)), 0, 0, Width - 1, Height - 1)
        G.DrawRectangle(New Pen(Color.FromArgb(214, 214, 214)), 0, 0, Width - 1, 30)
        G.DrawString(Text, Font, New SolidBrush(Me.ForeColor), 7, 6)
    End Sub
End Class
