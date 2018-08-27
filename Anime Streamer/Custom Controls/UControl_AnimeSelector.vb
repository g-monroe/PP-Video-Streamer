Public Class UControl_AnimeSelector
    Dim Hover As Boolean = False
 
   

    Private Sub Tmr_Checked_Tick(sender As Object, e As EventArgs) Handles Tmr_Checked.Tick
        If Settings.LoadHome = False Then
            For Each Tag As TagLabel In Main.Main_TabControl.TabPages(0).Controls.OfType(Of TagLabel)()
                Tag.Location = New Point(Main.Main_TabControl.TabPages(0).Width / 2 - Tag.Width / 2, Main.Main_TabControl.TabPages(0).Height / 2 - Tag.Height / 2)
            Next
        End If
        Me.Location = New Point(Main.Width / 2 - Me.Width / 2, Main.Height / 2 - Me.Height / 2)
        If Toggle1.onoff = False Then
            If Not Dubbed_CB.SelectedItem.ToString = "(none)" Then
                If Hover = False Then
                    TagLabel3.TagMainColor = Color.FromArgb(251, 82, 150)
                    TagLabel3.Tag3D = True
                    TagLabel3.Refresh()
                    Subbed_CB.SelectedIndex = 0
                    AnimeSearchtxtbox.Text = ""
                Else
                    TagLabel3.Cursor = Cursors.Hand
                    TagLabel3.Tag3D = False
                    TagLabel3.Refresh()

                End If
            End If
            If Not Subbed_CB.SelectedItem.ToString = "(none)" Then
                If Hover = False Then
                    TagLabel3.TagMainColor = Color.FromArgb(251, 82, 150)
                    TagLabel3.Tag3D = True
                    TagLabel3.Refresh()
                    Dubbed_CB.SelectedIndex = 0
                    AnimeSearchtxtbox.Text = ""
                Else
                    TagLabel3.Cursor = Cursors.Hand
                    TagLabel3.Tag3D = False
                    TagLabel3.Refresh()
                End If

            End If
            If Animelb.SelectedItems.Count > 0 Then
                If Hover = False Then
                    TagLabel3.TagMainColor = Color.FromArgb(251, 82, 150)
                    TagLabel3.Tag3D = True
                    TagLabel3.Refresh()
                    Subbed_CB.SelectedIndex = 0
                    Dubbed_CB.SelectedItem = 0
                Else
                    TagLabel3.Cursor = Cursors.Hand
                    TagLabel3.Tag3D = False
                    TagLabel3.Refresh()
                End If
            End If
            If Not Animelb.SelectedItems.Count > 0 Then
                If Dubbed_CB.SelectedItem.ToString = "(none)" Then
                    If Subbed_CB.SelectedItem.ToString = "(none)" Then
                        TagLabel3.Cursor = Cursors.Arrow
                        TagLabel3.Tag3D = False
                        TagLabel3.TagMainColor = Color.FromArgb(120, 120, 120)
                        TagLabel3.Refresh()
                    End If
                End If
            End If
        End If
        If Toggle1.onoff = True Then
            If Encyclo_LB.SelectedItems.Count > 0 Then
                If Hover = False Then
                    TagLabel3.TagMainColor = Color.FromArgb(251, 82, 150)
                    TagLabel3.Tag3D = True
                    TagLabel3.Refresh()
                    Subbed_CB.SelectedIndex = 0
                    Dubbed_CB.SelectedItem = 0
                Else
                    TagLabel3.Cursor = Cursors.Hand
                    TagLabel3.Tag3D = False
                    TagLabel3.Refresh()
                End If
            End If
            If Not encyclo_CB.SelectedItem.ToString = "(none)" Then
                If Hover = False Then
                    TagLabel3.TagMainColor = Color.FromArgb(251, 82, 150)
                    TagLabel3.Tag3D = True
                    TagLabel3.Refresh()
                    Dubbed_CB.SelectedIndex = 0
                    AnimeSearchtxtbox.Text = ""
                Else
                    TagLabel3.Cursor = Cursors.Hand
                    TagLabel3.Tag3D = False
                    TagLabel3.Refresh()
                End If
            End If
            If Not Encyclo_LB.SelectedItems.Count > 0 Then
                If encyclo_CB.SelectedItem.ToString = "(none)" Then
                    TagLabel3.Cursor = Cursors.Arrow
                    TagLabel3.Tag3D = False
                    TagLabel3.TagMainColor = Color.FromArgb(120, 120, 120)
                    TagLabel3.Refresh()
                End If
            End If
        End If
    End Sub

    Private Sub UControl_AnimeSelector_Load(sender As Object, e As EventArgs) Handles Me.Load
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Listings.Done = True AndAlso Listings.Done2 = True Then
            For Each key In Listings.GAdict.Keys
                Subbed_CB.Items.Add(key)
            Next
            For Each key In Listings.ATdict.Keys
                Dubbed_CB.Items.Add(key)
            Next
            For Each key In Encycl.dict.Keys
                encyclo_CB.Items.Add(key)
            Next
            CombineList()
            Subbed_CB.Refresh()
            Dubbed_CB.Refresh()
            Timer1.Enabled = False
        End If
    End Sub

    Private Sub TagLabel3_Click(sender As Object, e As EventArgs) Handles TagLabel3.Click
        If Not TagLabel3.TagMainColor = Color.FromArgb(120, 120, 120) Then
            If Toggle1.onoff = False Then
                Main.GroupRecommendations_GB.Visible = False
                Main.prog.Visible = False
                Main.progtext.Visible = False

                If Animelb.SelectedItems.Count > 0 Then
                    If Animelb.SelectedItem.ToString.Contains("[Dub]") Then
                        Dim temp As String = Animelb.SelectedItem.ToString
                        temp = temp.Replace("[Dub]", "")
                        For Each key In Listings.ATdict.Keys
                            If key = temp Then
                                Globals.ShowLink = Listings.ATdict(key)
                                Dubbed.AnimeToonShowPage()
                                Main.Name_lbl.Text = temp
                                Main.Name_lbl.Refresh()
                                Main.Type_lbl.Text = "Dubbed"
                                Main.Type_lbl.Refresh()
                                Main.PanelBox3.Visible = True
                            End If
                        Next
                    Else
                        Dim temp As String = Animelb.SelectedItem.ToString
                        temp = temp.Replace("[Sub]", "")
                        For Each key In Listings.GAdict.Keys
                            If key = temp Then
                                Globals.ShowLink = Listings.GAdict(key)
                                Subbed.GoodAnimeDetails()
                                Main.Name_lbl.Text = temp
                                Main.Name_lbl.Refresh()
                                Main.Type_lbl.Text = "Subbed"
                                Main.Type_lbl.Refresh()
                                Main.PanelBox3.Visible = True
                            End If
                        Next
                    End If
                End If
                If Not Dubbed_CB.SelectedItem.ToString = "(none)" Then
                    Main.PanelBox3.Visible = True
                    For Each key In Listings.ATdict.Keys
                        If key = Dubbed_CB.SelectedItem.ToString Then
                            Globals.ShowLink = Listings.ATdict(key)
                            Dubbed.AnimeToonShowPage()
                            Main.Name_lbl.Text = Dubbed_CB.SelectedItem.ToString
                            Main.Name_lbl.Refresh()
                            Main.Type_lbl.Text = "Dubbed"
                            Main.Type_lbl.Refresh()
                            Main.PanelBox3.Visible = True
                        End If
                    Next
                End If
                If Not Subbed_CB.SelectedItem.ToString = "(none)" Then
                    For Each key In Listings.GAdict.Keys
                        If key = Subbed_CB.SelectedItem.ToString Then
                            Globals.ShowLink = Listings.GAdict(key)
                            Subbed.GoodAnimeDetails()
                            Main.Name_lbl.Text = Subbed_CB.SelectedItem.ToString
                            Main.Name_lbl.Refresh()
                            Main.Type_lbl.Text = "Subbed"
                            Main.Type_lbl.Refresh()
                            Main.PanelBox3.Visible = True
                        End If
                    Next
                End If
            Else
                Main.GroupRecommendations_GB.Visible = True
                Main.prog.Visible = True
                Main.progtext.Visible = True
                Main.Type_lbl.Text = "Encyclopedia"
                Main.Type_lbl.Refresh()
                Try
                    Main.NsListView1.Items.Clear()
                Catch ex As Exception
                End Try
                If Encyclo_LB.SelectedItems.Count > 0 Then
                    For Each key In Encycl.dict.Keys
                        If key = Encyclo_LB.SelectedItem.ToString Then
                            Main.PanelBox3.Visible = True
                            Encycl.GetDetails(Encycl.dict(key))
                        End If
                    Next
                End If
                If Not encyclo_CB.SelectedItem.ToString = "(none)" Then
                    Dim temp As String = encyclo_CB.SelectedItem.ToString
                    For Each key In Encycl.dict.Keys
                        If key = temp Then
                            Main.PanelBox3.Visible = True
                            Encycl.GetDetails(Encycl.dict(key))
                        End If
                    Next
                End If
            End If
        End If
    End Sub

    Private Sub Subbed_CB_SelectedIndexChanged(sender As Object, e As EventArgs)
        TagLabel2.TagMainColor = Color.FromArgb(251, 82, 150)
        TagLabel2.Tag3D = True
        TagLabel2.Refresh()
        Dubbed_CB.SelectedIndex = 0
    End Sub

  
    Private Sub TagLabel3_MouseEnter(sender As Object, e As EventArgs) Handles TagLabel3.MouseEnter
        Hover = True
    End Sub

    Private Sub TagLabel3_MouseLeave(sender As Object, e As EventArgs) Handles TagLabel3.MouseLeave
        Hover = False
    End Sub
    Public dict As New Dictionary(Of String, String)()
    Public Sub CombineList()
        Try
            For Each key As String In Listings.GAdict.Keys
                dict.Add(key & "[Sub]", Listings.GAdict(key))
            Next
            For Each key As String In Listings.ATdict.Keys
                dict.Add(key & "[Dub]", Listings.ATdict(key))
            Next
        Catch ex As Exception
        End Try
        ''Return True
    End Sub
    Private Sub AnimeSearchtxtbox_TextChanged(sender As Object, e As EventArgs) Handles AnimeSearchtxtbox.TextChanged
        If Toggle1.onoff = False Then
            Animelb.Items.Clear()
            Dim input As String = AnimeSearchtxtbox.Text.ToLower()
            For Each key As String In dict.Keys
                If Not Animelb.Items.Contains(key) Then
                    If key.ToLower().StartsWith(input) Then
                        Animelb.Items.Add(key)
                    End If
                End If
            Next
            If AnimeSearchtxtbox.Text = "" Then
                Animelb.Items.Clear()
            End If
        End If

        If Toggle1.onoff = True Then
            Encyclo_LB.Items.Clear()
            Dim input As String = AnimeSearchtxtbox.Text.ToLower()
            For Each key As String In Encycl.dict.Keys
                If Not Encyclo_LB.Items.Contains(key) Then
                    If key.ToLower().StartsWith(input) Then
                        Encyclo_LB.Items.Add(key)
                    End If
                End If
            Next
            If AnimeSearchtxtbox.Text = "" Then
                Encyclo_LB.Items.Clear()
            End If
        End If
    End Sub

    Private Sub Animelb_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Animelb.SelectedIndexChanged
       
    End Sub

    Private Sub Toggle1_CheckedChanged(sender As Object) Handles Toggle1.CheckedChanged
        If Toggle1.onoff = True Then
            Label1.Visible = False
            Label2.Visible = False
            Dubbed_CB.Visible = False
            Subbed_CB.Visible = False
            Ency_lb.Visible = True
            encyclo_CB.Visible = True
            Encyclo_LB.Visible = True
            Animelb.Visible = False
        Else
            Label1.Visible = True
            Label2.Visible = True
            Dubbed_CB.Visible = True
            Subbed_CB.Visible = True
            Ency_lb.Visible = False
            encyclo_CB.Visible = False
            Encyclo_LB.Visible = False
            Animelb.Visible = True
        End If
    End Sub
End Class
