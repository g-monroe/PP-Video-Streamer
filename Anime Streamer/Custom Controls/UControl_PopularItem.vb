Public Class UControl_PopularItem
    Public ShowPict As String
    Public ShowInfo As String
    Public ShowDesc As String
    Public ShowName As String
    Public ShowLink As String
    Private Sub TagLabel2_Click(sender As Object, e As EventArgs) Handles TagLabel2.Click
        Globals.ShowLink = ShowLink
        Dubbed.AnimeToonShowPage()
        Main.Main_TabControl.SelectedIndex = 2
         Main.GroupRecommendations_GB.Visible = False
        Main.prog.Visible = False
        Main.progtext.Visible = False
        Main.Name_lbl.Text = ShowName
        Main.Name_lbl.Refresh()
        Main.Type_lbl.Text = "Dubbed"
        Main.Type_lbl.Refresh()
        Main.PanelBox3.Visible = True
        For Each uc As UControl_AnimeSelector In Main.Controls.OfType(Of UControl_AnimeSelector)()
            uc.Toggle1.onoff = False
        Next
    End Sub
    Private Sub UControl_PopularItem_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub UControl_PopularItem_Resize(sender As Object, e As EventArgs) Handles Me.Resize

        Desc2.Width = Width - 80
    End Sub
End Class
