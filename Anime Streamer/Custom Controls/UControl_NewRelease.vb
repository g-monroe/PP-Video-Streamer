Public Class UControl_NewRelease
    Public ShowLink As String
    Public ShowPicture As String
    Public ShowName As String
    Private Sub Picture_PB_Click(sender As Object, e As EventArgs) Handles Picture_PB.Click
        Globals.ShowLink = ShowLink
        Globals.RecommendType = "Subbed"
        Main.Main_TabControl.SelectedIndex = 2
        Main.TabSelector1.Tab2_Sel = False
        Main.TabSelector1.Tab1_Sel = False
        Main.TabSelector1.Tab3_Sel = True
        Main.TabSelector1.Tab4_Sel = False
        Main.TabSelector1.Refresh()
        Main.Name_lbl.Text = ShowName
        Main.Name_lbl.Refresh()
        Main.Type_lbl.Text = "Subbed"
        Main.Type_lbl.Refresh()
        Subbed.GoodAnimeDetails()
        Main.PanelBox3.Visible = True
        For Each uc As UControl_AnimeSelector In Main.Controls.OfType(Of UControl_AnimeSelector)()
            uc.Toggle1.onoff = False
        Next
    End Sub
#Region "Round Rectangle Function"
    Private Function RoundedRec(ByVal X As Integer, ByVal Y As Integer, ByVal Width As Integer, ByVal Height As Integer) As System.Drawing.Drawing2D.GraphicsPath
        ' Make and Draw a path.
        Dim graphics_path As New System.Drawing.Drawing2D.GraphicsPath
        graphics_path.AddLine(X + 10, Y, X + Width, Y) 'add the Top line to the path

        'Top Right corner        
        Dim tr() As Point = { _
        New Point(X + Width, Y), _
        New Point((X + Width) + 4, Y + 2), _
        New Point((X + Width) + 8, Y + 6), _
        New Point((X + Width) + 10, Y + 10)}

        graphics_path.AddCurve(tr)  'Add the Top right curve to the path

        'Bottom right corner 
        Dim br() As Point = { _
        New Point((X + Width) + 10, Y + Height), _
        New Point((X + Width) + 8, (Y + Height) + 4), _
        New Point((X + Width) + 4, (Y + Height) + 8), _
        New Point(X + Width, (Y + Height) + 10)}

        graphics_path.AddCurve(br)  'Add the Bottom right curve to the path

        'Bottom left corner
        Dim bl() As Point = { _
        New Point(X + 10, (Y + Height) + 10), _
        New Point(X + 6, (Y + Height) + 8), _
        New Point(X + 2, (Y + Height) + 4), _
        New Point(X, Y + Height)}

        graphics_path.AddCurve(bl)  'Add the Bottom left curve to the path

        'Top left corner
        Dim tl() As Point = { _
        New Point(X, Y + 10), _
        New Point(X + 2, Y + 6), _
        New Point(X + 6, Y + 2), _
        New Point(X + 10, Y)}

        graphics_path.AddCurve(tl)  'add the Top left curve to the path

        Return graphics_path

    End Function
#End Region
    Private Sub Name_RTB_MouseClick(sender As Object, e As MouseEventArgs) Handles Name_RTB.MouseClick
        Globals.ShowLink = ShowLink
        Globals.RecommendType = "Subbed"
        Main.Main_TabControl.SelectedIndex = 2
        Main.Name_lbl.Text = ShowName
        Main.Name_lbl.Refresh()
        Main.Type_lbl.Text = "Subbed"
        Main.Type_lbl.Refresh()
        Subbed.GoodAnimeDetails()
        Main.PanelBox3.Visible = True
        Main.GroupRecommendations_GB.Visible = False
        Main.prog.Visible = False
        Main.progtext.Visible = False
        For Each uc As UControl_AnimeSelector In Main.Controls.OfType(Of UControl_AnimeSelector)()
            uc.Toggle1.onoff = False
        Next
    End Sub

    Private Sub Name_RTB_MouseEnter(sender As Object, e As EventArgs) Handles Name_RTB.MouseEnter
        Name_RTB.Font = New Font("Arial", 7, FontStyle.Underline)
    End Sub

    Private Sub Name_RTB_MouseLeave(sender As Object, e As EventArgs) Handles Name_RTB.MouseLeave
        Name_RTB.Font = New Font("Arial", 7, FontStyle.Regular)
    End Sub

    Private Sub Picture_PB_LoadCompleted(sender As Object, e As System.ComponentModel.AsyncCompletedEventArgs) Handles Picture_PB.LoadCompleted
        Picture_PB.Region = New Region(RoundedRec(0, 0, Picture_PB.Width - 10, Picture_PB.Height - 10))
    End Sub

    Private Sub Picture_PB_Resize(sender As Object, e As EventArgs) Handles Picture_PB.Resize
        Picture_PB.Region = New Region(RoundedRec(0, 0, Picture_PB.Width - 10, Picture_PB.Height - 10))
    End Sub
End Class
