Imports System.Threading
Imports System.Net
Imports System.Reflection
Imports PluginLib
Public Class Main
#Region "TabPage Selection"
    Private Sub TabSelector1_Tab1_Clicked(sender As Object) Handles TabSelector1.Tab1_Clicked
        Main_TabControl.SelectedIndex = 0
    End Sub

    Private Sub TabSelector1_Tab2_Clicked(sender As Object) Handles TabSelector1.Tab2_Clicked
        Main_TabControl.SelectedIndex = 1
    End Sub

    Private Sub TabSelector1_Tab3_Clicked(sender As Object) Handles TabSelector1.Tab3_Clicked
        Main_TabControl.SelectedIndex = 2
    End Sub

    Private Sub TabSelector1_Tab4_Clicked(sender As Object) Handles TabSelector1.Tab4_Clicked
        Main_TabControl.SelectedIndex = 3
    End Sub
#End Region
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

    Private Sub Main_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        Loading.Close()
    End Sub
    Private Sub Main_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Pic_pb.Region = New Region(RoundedRec(0, 0, Pic_pb.Width - 10, Pic_pb.Height - 10))
        'CommandLine.Reader()
        Home.MeasureandSetCol()
        If Settings.LoadWatching = True Then
            Watching.LoadWat()
        End If
        LoadingClass.SetStatus("Currently Loading: " & "Anime Dubbed Listings...", 8)
        Listings.AnimeToonListings()
        LoadingClass.SetStatus("Currently Loading: " & "Anime Subbed Listings...", 16)
        Listings.GoodAnimeListing()
        LoadingClass.SetStatus("Currently Loading: " & "Encyclopedia Listings...", 24)
        Encycl.GetSource()
        LoadingClass.SetStatus("Currently Loading: " & "Genre Listings...", 32)
        Encycl.Additemstodict()
        If Settings.LoadFavorites = True Then
            LoadingClass.SetStatus("Currently Loading: " & "Favroites...", 40)
            Favorites.LoadFav()
        Else
            LoadingClass.SetStatus("Currently Loading: " & "Favroites...", 40)
            KoboTabControlS2.TabPages.Remove(KoboTabControlS2.TabPages(1))
        End If
        If Settings.LoadHistory = True Then
            LoadingClass.SetStatus("Currently Loading: " & "History...", 48)
            History.LoadHistory()
            ' CommandLine.Save()
        Else
            LoadingClass.SetStatus("Currently Loading: " & "History...", 48)
            KoboTabControlS2.TabPages.Remove(KoboTabControlS2.TabPages(0))
        End If

        If Settings.LoadHome = True Then
            LoadingClass.SetStatus("Currently Loading: " & "PRW Items 1/4...", 54)
            Home_PRW.LoadInPopularItems()
            LoadingClass.SetStatus("Currently Loading: " & "PRW Items 2/4...", 64)
            Home_PRW.LoadInPopularItems()
            LoadingClass.SetStatus("Currently Loading: " & "PRW Items 3/4...", 72)
            Home_PRW.LoadInPopularItems()
            LoadingClass.SetStatus("Currently Loading: " & "PRW Items 4/4...", 80)
            Home_PRW.LoadInPopularItems()

            LoadingClass.SetStatus("Currently Loading: " & "Popular Items...", 88)
            Home_POP.AnimeToonPopPage("http://www.animetoon.tv/popular-list/2")
            LoadingClass.SetStatus("Currently Loading: " & "Ongoing Items...", 96)
            Home_OGS.AnimeToonHomePage()
            LoadingClass.SetStatus("Currently Loading: " & "Coming Soon Items...", 100)
            Home_NRS.GetNRSSource("http://www.goodanime.net/category/new-release")

            'NRS_TC.Visible = False
            'CS_Taglbl.Visible = False
            Loading.CheckifDone()

        Else
            LoadingClass.SetStatus("Currently Loading: " & "Coming Soon Items...", 100)
            Loading.CheckifDone()
            Dim tag As New TagLabel
            tag.Height = 25
            tag.Width = 950
            tag.Location = New Point(Main_TabControl.TabPages(0).Width / 2 - tag.Width / 2, Main_TabControl.TabPages(0).Height / 2 - tag.Height / 2)
            tag.Tag3D = True
            tag.BackColor = Color.FromArgb(45, 45, 45)
            tag.Text = "Home is turned off in Your settings. To turn it back on go into your settings and type " & Chr(34) & "settings.loadhome = true" & Chr(34) & "!"
            Main_TabControl.TabPages(0).Controls.Add(tag)
        End If
        If Settings.Notifactions = True Then
            Notifaction.Onoff = True
        Else
            Notifaction.Onoff = False
        End If
        Notifaction.ShowTime()
        'Anime Selector
        Dim oo As New UControl_AnimeSelector
        Main_TabControl.TabPages(2).Controls.Add(oo)
        'WMP
        'Me.AxWindowsMediaPlayer1.uiMode = "none"
        For Each item In Genre_CB.Items
            Searchbox_Main.CB.Items.Add(item)
        Next
        'Console
        ConsoleCore.AppendText(Console_box, TimeOfDay.TimeOfDay.ToString, Color.FromArgb(53, 175, 176))
        ConsoleCore.AppendText(Console_box, ">:", Color.FromArgb(87, 166, 74))
        ConsoleCore.AppendText(Console_box, "Welcome to Anime Streamer's Console, type ", Color.FromArgb(220, 220, 220))
        ConsoleCore.AppendText(Console_box, Chr(34) & "help" & Chr(34), Color.FromArgb(214, 157, 133))
        ConsoleCore.AppendText(Console_box, " to display the commands!", Color.FromArgb(220, 220, 220))
        Recommendations.FindWatchedAnime()
    End Sub
    Private Sub NextPage_Pop_Click(sender As Object, e As EventArgs)
        'For Each Vi As UControl_PopularItem In Me.Pop_TC.TabPages(0).Controls.OfType(Of UControl_PopularItem)()
        '    Vi.Dispose()
        'Next
        Home_POP.PageNum += 1
        Home_POP.AnimeToonPopPage("http://www.animetoon.tv/popular-list/" & Home_POP.PageNum)
    End Sub

    Private Sub Prev_Pop_Click(sender As Object, e As EventArgs)
        'For Each Vi As UControl_PopularItem In Me.Pop_TC.TabPages(0).Controls.OfType(Of UControl_PopularItem)()
        '    Vi.Dispose()
        'Next
        If Home_POP.PageNum < 1 Then
            Home_POP.PageNum -= 1
        End If
        Home_POP.AnimeToonPopPage("http://www.animetoon.tv/popular-list/" & Home_POP.PageNum)
    End Sub


    Private Sub NsListView1_AddedFavorited(sender As Object, Num As NSListView.NSListViewItem)
        Try
            If Num.Favorited = False Then
                Favorites.AddFav(Num.Text, Num.SubItems(0).Text)
            Else
                For Each key As KeyValuePair(Of String, String) In Favorites.Favdict
                    If Favorites.Favdict(key.Key) = Num.SubItems(0).Text Then
                        Favorites.Favdict.Remove(key.Key)
                    End If
                Next
            End If
        Catch ex As Exception
        End Try
    End Sub


    Private Sub TagLabel5_Click(sender As Object, e As EventArgs)
        PanelBox3.Visible = False
    End Sub

    Private Sub TagLabel5_MouseEnter(sender As Object, e As EventArgs)
        TagLabel5.Tag3D = False
    End Sub

    Private Sub TagLabel5_MouseLeave(sender As Object, e As EventArgs)
        TagLabel5.Tag3D = True
    End Sub


    'Public Sub Search_TB_TextChanged(sender As Object, e As EventArgs)
    '    Search_LB.Items.Clear()
    '    Dim input As String = Search_TB.Text.ToLower()
    '    For Each animes As UControl_AnimeSelector In Me.KoboTabControlS1.TabPages(0).Controls.OfType(Of UControl_AnimeSelector)()
    '        For Each key As String In animes.dict.Keys
    '            If Not Search_LB.Items.Contains(key) Then
    '                If key.ToLower().StartsWith(input) Then
    '                    Search_LB.Items.Add(key)
    '                End If
    '            End If
    '        Next
    '    Next
    '    If Search_TB.Text = "" Then
    '        Search_LB.Items.Clear()
    '    End If
    'End Sub

    Private Sub Genre_CB_MouseClick(sender As Object, e As MouseEventArgs)
        Genre_CB.Refresh()
    End Sub

    Private Sub Genre_CB_SelectedIndexChanged(sender As Object, e As EventArgs)
        For Each key In Encycl.GenDict.Keys
            If key = Genre_CB.SelectedItem.ToString Then
                Dim wb As New WebClient
                AddHandler wb.DownloadStringCompleted, AddressOf Wb_DSC4
                ' MsgBox(Encly.GenDict(key))
                wb.DownloadStringAsync(New Uri(Encycl.GenDict(key)))
            End If
        Next
    End Sub
    Public Shared genlistdict As New Dictionary(Of String, String)
    Public Sub Wb_DSC4(sender As Object, e As DownloadStringCompletedEventArgs)

        Try
            genlistdict.Clear()
        Catch ex As Exception

        End Try
        Try
            Genre_CB.Items.Clear()
        Catch ex As Exception

        End Try
        Dim str3 As String = e.Result
        Dim temp As String = Filter.getBetween(str3, "<div class=" & Chr(34) & "content_bloc" & Chr(34) & ">", "<iframe")
        Dim lines As String() = temp.Split("<li>")
        For Each line In lines

            If line.StartsWith("a href=" & Chr(34) & "/") AndAlso Not line.Contains("/categories") Then
                ' MsgBox(line)
                line = line.Replace("a href=" & Chr(34), "")
                line = line.Replace(Chr(34), "")
                Dim namme As String = line.Split(">").Last
                Dim link As String = "http://www.animeseason.com" + line.Split(">").First

                Genre_CB.Items.Add(namme)

                Try
                    genlistdict.Add(namme, link)
                Catch ex As Exception
                End Try


            End If
        Next
    End Sub

    Private Sub Genre_CB_SelectedItemChanged(sender As Object)

    End Sub

    Private Sub Favorites_TB_TextChanged(sender As Object, e As EventArgs) Handles Favorites_TB.TextChanged
        Favorites_LB.Items.Clear()
        Dim input As String = Favorites_TB.Text.ToLower()
        For Each key As String In Favorites.Favdict.Keys
            If Not Favorites_LB.Items.Contains(key) Then
                If key.ToLower().StartsWith(input) Then
                    Favorites_LB.Items.Add(key)
                End If
            End If
        Next
    End Sub

    Private Sub Favorites_LB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Favorites_LB.SelectedIndexChanged
        If Favorites_LB.SelectedItems.Count > 0 Then
            Dim temp As String = Favorites.Favdict(Favorites_LB.SelectedItem.ToString)
            If temp.Contains("goodanime") Then
                Globals.EpisodeLink = temp
                'MsgBox(Globals.EpisodeLink)
                Subbed.GoodAnimeParse()
                Main_TabControl.SelectedIndex = 1
                TabSelector1.Tab2_Sel = True
                TabSelector1.Tab1_Sel = False
                TabSelector1.Tab3_Sel = False
                TabSelector1.Tab4_Sel = False
                Me.TabSelector1.Refresh()
            ElseIf temp.Contains("animetoon") Then
                Globals.EpisodeLink = temp
                'MsgBox(Globals.EpisodeLink)
                Dubbed.AnimeToonParse()
                Main_TabControl.SelectedIndex = 1
                TabSelector1.Tab2_Sel = True
                TabSelector1.Tab1_Sel = False
                TabSelector1.Tab3_Sel = False
                TabSelector1.Tab4_Sel = False
                Me.TabSelector1.Refresh()
            End If
        End If
    End Sub

    Private Sub History_LB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles History_LB.SelectedIndexChanged
        If History_LB.SelectedItems.Count > 0 Then
            Dim temp As String = History.Histdict(History_LB.SelectedItem.ToString)
            If temp.Contains("goodanime") Then
                Globals.EpisodeLink = temp
                'MsgBox(Globals.EpisodeLink)
                Subbed.GoodAnimeParse()
                Main_TabControl.SelectedIndex = 1
            ElseIf temp.Contains("animetoon") Then
                Globals.EpisodeLink = temp
                'MsgBox(Globals.EpisodeLink)
                Dubbed.AnimeToonParse()
                Main_TabControl.SelectedIndex = 1
            End If
        End If
    End Sub

    Private Sub History_TB_TextChanged(sender As Object, e As EventArgs) Handles History_TB.TextChanged
        History_LB.Items.Clear()
        Dim input As String = History_TB.Text.ToLower()
        For Each key As String In History.Histdict.Keys
            If Not History_LB.Items.Contains(key) Then
                If key.ToLower().StartsWith(input) Then
                    History_LB.Items.Add(key)
                End If
            End If
        Next
    End Sub

    'Private Sub Search_LB_SelectedIndexChanged(sender As Object, e As EventArgs)
    '    If Search_LB.SelectedItems.Count > 0 Then
    '        For Each uc As UControl_AnimeSelector In Main.Controls.OfType(Of UControl_AnimeSelector)()
    '            uc.Toggle1.onoff = False

    '            Dim temp As String = uc.dict(Search_LB.SelectedItem.ToString)
    '            If temp.Contains("goodanime") Then
    '                Globals.ShowLink = temp
    '                Globals.RecommendType = "Subbed"
    '                Main_TabControl.SelectedIndex = 2
    '                GroupRecommendations_GB.Visible = False
    '                prog.Visible = False
    '                progtext.Visible = False
    '                Me.TabSelector1.Refresh()
    '                Me.Name_lbl.Text = Search_LB.SelectedItem.ToString
    '                Me.Name_lbl.Refresh()
    '                Me.Type_lbl.Text = "Subbed"
    '                Me.Type_lbl.Refresh()
    '                Subbed.GoodAnimeDetails()
    '                PanelBox3.Visible = True
    '            ElseIf temp.Contains("animetoon") Then
    '                Globals.ShowLink = temp
    '                Me.Name_lbl.Text = Search_LB.SelectedItem.ToString
    '                Me.Name_lbl.Refresh()
    '                Me.Type_lbl.Text = "Dubbed"
    '                Me.Type_lbl.Refresh()
    '                KoboTabControlS1.SelectedIndex = 0
    '                Main_TabControl.SelectedIndex = 2
    '                GroupRecommendations_GB.Visible = False
    '                prog.Visible = False
    '                progtext.Visible = False
    '                Me.TabSelector1.Refresh()
    '                Dubbed.AnimeToonShowPage()
    '                PanelBox3.Visible = True
    '            End If
    '        Next
    '    End If
    'End Sub

    'Private Sub Genre_LB_SelectedIndexChanged(sender As Object, e As EventArgs)
    '    For Each key In genlistdict.Keys
    '        If key = Genre_LB.SelectedItem.ToString Then
    '            Try
    '                NsListView1.Items.Clear()
    '            Catch ex As Exception
    '            End Try
    '            Encycl.GetDetails(genlistdict(key))
    '            Me.Name_lbl.Text = Genre_LB.SelectedItem.ToString
    '            Me.Name_lbl.Refresh()
    '            Me.Type_lbl.Text = "Encyclopedia"
    '            Me.Type_lbl.Refresh()
    '            For Each uc As UControl_AnimeSelector In KoboTabControlS1.TabPages(0).Controls.OfType(Of UControl_AnimeSelector)()
    '                uc.Toggle1.onoff = True
    '            Next
    '            GroupRecommendations_GB.Visible = True
    '            prog.Visible = True
    '            progtext.Visible = True
    '            KoboTabControlS1.SelectedIndex = 0
    '            Main_TabControl.SelectedIndex = 2
    '            TabSelector1.Tab2_Sel = False
    '            TabSelector1.Tab1_Sel = False
    '            TabSelector1.Tab3_Sel = True
    '            TabSelector1.Tab4_Sel = False
    '            Me.TabSelector1.Refresh()
    '            PanelBox3.Visible = True
    '        End If
    '    Next
    'End Sub

    Private Sub NsListView1_DoubleClick(sender As Object, e As EventArgs)
        If NsListView1.SelectedItems.Count > 0 Then
            If NsListView1.SelectedItems(0).SubItems(0).Text.Contains("goodanime") Then
                Globals.EpisodeLink = NsListView1.SelectedItems(0).SubItems(0).Text
                Subbed.GoodAnimeParse()
                History.AddHistory(NsListView1.SelectedItems(0).Text, NsListView1.SelectedItems(0).SubItems(0).Text)
            Else
                Globals.EpisodeLink = NsListView1.SelectedItems(0).SubItems(0).Text
                Dubbed.AnimeToonParse()
                History.AddHistory(NsListView1.SelectedItems(0).Text, NsListView1.SelectedItems(0).SubItems(0).Text)
            End If
        End If
    End Sub

    Private Sub Main_TabControl_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Main_TabControl.SelectedIndexChanged
        If Me.Main_TabControl.SelectedIndex = 1 Then
            Me.TabSelector1.Tab1_Sel = False
            Me.TabSelector1.Tab2_Sel = True
            Me.TabSelector1.Tab3_Sel = False
            Me.TabSelector1.Tab4_Sel = False
            Me.TabSelector1.Refresh()
            Dim vo As New UControl_VideoOptions
            Me.Controls.Add(vo)
            vo.BringToFront()
        Else
            For Each nw As UControl_VideoOptions In Me.Controls.OfType(Of UControl_VideoOptions)()
                nw.Dispose()
            Next
        End If
        If Me.Main_TabControl.SelectedIndex = 0 Then
            Me.TabSelector1.Tab1_Sel = True
            Me.TabSelector1.Tab2_Sel = False
            Me.TabSelector1.Tab3_Sel = False
            Me.TabSelector1.Tab4_Sel = False
            Me.TabSelector1.Refresh()
            If Settings.LoadHome = True Then

            End If
        Else
        End If
        If Me.Main_TabControl.SelectedIndex = 2 Then
            Me.TabSelector1.Tab1_Sel = False
            Me.TabSelector1.Tab2_Sel = False
            Me.TabSelector1.Tab3_Sel = True
            Me.TabSelector1.Tab4_Sel = False
            Me.TabSelector1.Refresh()
            Dim vo As New UControl_ListOption
            Me.Controls.Add(vo)
            vo.BringToFront()
            Recommendations.FindWatchedAnime()
        Else
            For Each nw As UControl_ListOption In Me.Controls.OfType(Of UControl_ListOption)()
                nw.Dispose()
            Next
        End If
        If Me.Main_TabControl.SelectedIndex = 3 Then
            Me.TabSelector1.Tab1_Sel = False
            Me.TabSelector1.Tab2_Sel = False
            Me.TabSelector1.Tab3_Sel = False
            Me.TabSelector1.Tab4_Sel = True
            Me.TabSelector1.Refresh()
        End If
    End Sub

    Private Sub NsListView1_Click(sender As Object, e As EventArgs)

    End Sub

    Private Sub NsListView1_WatchedChanged(sender As Object, Num As NSListView.NSListViewItem)
        Try
            If Num.Watched = False Then
                History.AddHistory(Num.Text, Num.SubItems(0).Text)
            Else
                For Each key As KeyValuePair(Of String, String) In History.Histdict
                    If History.Histdict(key.Key) = Num.SubItems(0).Text Or key.Key = Num.Text Then
                        History.Histdict.Remove(key.Key)
                    End If
                Next
            End If
        Catch ex As Exception
        End Try

    End Sub
    '///////////
    'WMP Player
    '//////////
    'Private Sub AxWindowsMediaPlayer1_PlayStateChange(sender As Object, e As AxWMPLib._WMPOCXEvents_PlayStateChangeEvent) Handles AxWindowsMediaPlayer1.PlayStateChange
    '    If AxWindowsMediaPlayer1.playState = WMPLib.WMPPlayState.wmppsBuffering Or AxWindowsMediaPlayer1.playState = WMPLib.WMPPlayState.wmppsPlaying Then
    '        ' set trackbar1 min and maximum values
    '        ConsoleCore.Report(Me.Console_box, "Setting Player duration!" & "{Duration: " & AxWindowsMediaPlayer1.currentMedia.duration.ToString & " }", Color.Green)
    '        Player1.AresioTrackBar1.Maximum = AxWindowsMediaPlayer1.currentMedia.duration
    '        ConsoleCore.Report(Me.Console_box, "Starting Player Timer.", Color.Green)
    '        Player1.Timer1.Start()
    '    ElseIf AxWindowsMediaPlayer1.playState = WMPLib.WMPPlayState.wmppsMediaEnded Or AxWindowsMediaPlayer1.playState = WMPLib.WMPPlayState.wmppsStopped Or AxWindowsMediaPlayer1.playState = WMPLib.WMPPlayState.wmppsReady Then
    '        ConsoleCore.Report(Me.Console_box, "Stopping Player Timer.", Color.Yellow)
    '        Player1.Timer1.Stop()
    '    End If
    '    Select Case e.newState
    '        Case 0 ' Undefined
    '            ConsoleCore.Report(Me.Console_box, "Player playstate = Undefined.", Color.White)
    '            Player1.Player1.StringStatus = "Unknown"
    '        Case 1 ' Stopped
    '            ConsoleCore.Report(Me.Console_box, "Player playstate = Stopped.", Color.White)
    '            Player1.Player1.StringStatus = "Stopped"
    '            ConsoleCore.Report(Me.Console_box, "Player gui pause/play icon changed to paused.", Color.Yellow)
    '            Player1.Player1.PlayState2 = False
    '            Player1.Refresh()
    '        Case 2 ' Paused
    '            ConsoleCore.Report(Me.Console_box, "Player playstate = Paused.", Color.White)
    '            Player1.Player1.StringStatus = "Paused"
    '            Player1.Player1.PlayState2 = True
    '            Player1.Player1.Refresh()
    '        Case 3 ' Playing
    '            ConsoleCore.Report(Me.Console_box, "Player playstate = Playing.", Color.White)
    '            Player1.Player1.StringStatus = "Playing"
    '            ConsoleCore.Report(Me.Console_box, "Player gui pause/play icon changed to playing.", Color.Yellow)
    '            Player1.Player1.PlayState2 = True
    '            Player1.Player1.Refresh()
    '        Case 4 ' ScanForward
    '            ConsoleCore.Report(Me.Console_box, "Player playstate = ScanForward.", Color.White)
    '            Player1.Player1.StringStatus = "ScanForward"
    '        Case 5 ' ScanReverse
    '            ConsoleCore.Report(Me.Console_box, "Player playstate = ScanReverse.", Color.White)
    '            Player1.Player1.StringStatus = "ScanReverse"
    '        Case 6 ' Buffering
    '            ConsoleCore.Report(Me.Console_box, "Player playstate = Buffering.", Color.White)
    '            Player1.Player1.StringStatus = "Buffering"
    '            Player1.Player1.PlayState2 = False
    '            Player1.Player1.Refresh()
    '        Case 7 ' Waiting
    '            ConsoleCore.Report(Me.Console_box, "Player playstate = Waiting.", Color.White)
    '            Player1.Player1.StringStatus = "Waiting"
    '        Case 8 ' MediaEnded
    '            ConsoleCore.Report(Me.Console_box, "Player playstate = MediaEnding.", Color.White)
    '            Player1.Player1.StringStatus = "Ended"
    '            ConsoleCore.Report(Me.Console_box, "Player gui pause/play icon changed to paused.", Color.Yellow)
    '            Player1.Player1.PlayState2 = False
    '            Player1.Refresh()
    '        Case 9 ' Transitioning
    '            ConsoleCore.Report(Me.Console_box, "Player playstate = Connecting.", Color.White)
    '            Player1.Player1.StringStatus = "Connecting"
    '            ConsoleCore.Report(Me.Console_box, "Player gui pause/play icon changed to paused.", Color.Yellow)
    '            Player1.Player1.PlayState2 = False
    '            Player1.Refresh()
    '        Case 10 ' Ready
    '            ConsoleCore.Report(Me.Console_box, "Player playstate = Ready - Failed.", Color.White)
    '            Player1.Player1.StringStatus = "Ready - Failed"
    '            ConsoleCore.Report(Me.Console_box, "Player gui pause/play icon changed to paused.", Color.Yellow)
    '            Player1.Player1.PlayState2 = False
    '            Player1.Refresh()
    '        Case 11 ' Reconnecting
    '            ConsoleCore.Report(Me.Console_box, "Player playstate = Reconnecting.", Color.White)
    '            Player1.Player1.StringStatus = "Reconnecting"
    '        Case 12 ' Last
    '            ConsoleCore.Report(Me.Console_box, "Player playstate = Last.", Color.White)
    '            Player1.Player1.StringStatus = "Last"
    '            ConsoleCore.Report(Me.Console_box, "Player gui pause/play icon changed to paused.", Color.Yellow)
    '            Player1.Player1.PlayState2 = False
    '            Player1.Refresh()
    '        Case Else
    '            ConsoleCore.Report(Me.Console_box, "Player playstate = Unkown.", Color.White)
    '            Player1.Player1.StringStatus = "Unknown"
    '            ConsoleCore.Report(Me.Console_box, "Player gui pause/play icon changed to paused.", Color.Yellow)
    '            Player1.Player1.PlayState2 = False
    '            Player1.Refresh()
    '    End Select
    'End Sub

    Private Sub TextBox1_KeyDown(sender As Object, e As KeyEventArgs) Handles TextBox1.KeyDown
        Select Case e.KeyCode
            Case Keys.Enter

                Console_box.Text += vbNewLine
                ConsoleCore.AppendText(Console_box, TimeOfDay.TimeOfDay.ToString, Color.FromArgb(53, 175, 176))
                ConsoleCore.AppendText(Console_box, ">:", Color.FromArgb(87, 166, 74))
                ConsoleCore.CheckCommand(TextBox1.Text, Console_box)
                TextBox1.Text = ""
            Case Keys.Up
                TextBox1.Text = ConsoleCore.LastCommand
            Case Keys.Down
                TextBox1.Text = ConsoleCore.LastCommand
        End Select
    End Sub

    Private Sub Monday_LB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Monday_LB.SelectedIndexChanged
        Watching.SelectItemFilter(Monday_LB)
    End Sub

    Private Sub Tuesday_LB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Tuesday_LB.SelectedIndexChanged
        Watching.SelectItemFilter(Tuesday_LB)
    End Sub

    Private Sub Wednesday_LB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Wednesday_LB.SelectedIndexChanged
        Watching.SelectItemFilter(Wednesday_LB)
    End Sub

    Private Sub Thursday_LB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Thursday_LB.SelectedIndexChanged
        Watching.SelectItemFilter(Thursday_LB)
    End Sub

    Private Sub Friday_LB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Friday_LB.SelectedIndexChanged
        Watching.SelectItemFilter(Friday_LB)
    End Sub

    Private Sub Saturday_LB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Saturday_LB.SelectedIndexChanged
        Watching.SelectItemFilter(Saturday_LB)
    End Sub

    Private Sub Sunday_LB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles Sunday_LB.SelectedIndexChanged
        Watching.SelectItemFilter(Sunday_LB)
    End Sub

    Private Sub QuickAdded_LB_SelectedIndexChanged(sender As Object, e As EventArgs) Handles QuickAdded_LB.SelectedIndexChanged
        Watching.SelectItemFilter(QuickAdded_LB)
    End Sub
    '///////////////////////////////////
    '||||||||Plugin System||||||||||||||
    '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    ' Dim Connector As Connector
    ' Public Plugs As New Dictionary(Of String, IPlugin)
    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click
        '  Connector = New Connector(Me)
    End Sub

    Private Sub Button6_Click(sender As Object, e As EventArgs) Handles Button6.Click

    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        'Dim ofd As New OpenFileDialog
        'If ofd.ShowDialog = Windows.Forms.DialogResult.OK Then
        '    Try
        '        'load the assembly
        '        Dim pluginassembly As Assembly = Assembly.LoadFile(ofd.FileName)
        '        'get the StartOfPlugin class by using GetType("<typename>")
        '        Dim pluginclass As IPlugin = CType(Activator.CreateInstance(pluginassembly.GetType(pluginassembly.GetName.Name & ".PluginStart")), IPlugin)
        '        Plugs.Add(pluginassembly.GetName.Name, CType(Activator.CreateInstance(pluginassembly.GetType(pluginassembly.GetName.Name & ".PluginStart")), IPlugin))
        '        ListBox1.Items.Add(pluginassembly.GetName.Name)
        '    Catch ex As Exception
        '        MsgBox("Failed to open plugin! Error:  " & ex.ToString, MsgBoxStyle.Critical, "Error")
        '    End Try


        '  End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        'Try
        '    Plugs(ListBox1.SelectedItem.ToString).StartPlugIn(Connector)
        'Catch ex As Exception
        '    MsgBox("Failed to run plugin!", MsgBoxStyle.Critical, "Error")
        'End Try
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        Try
            'Connector.Disconnect(ListBox1.SelectedItem.ToString)
            ListBox1.Items.Remove(ListBox1.SelectedItem)
        Catch ex As Exception
            MsgBox("Failed to run plugin!", MsgBoxStyle.Critical, "Error")
        End Try
    End Sub

    Private Sub Searchbox_Main_SelectedItemChanged(e As String) Handles Searchbox_Main.SelectedItemChanged

    End Sub
    Private Sub Searchbox_Main_TextChanged(sender As Object, e As EventArgs) Handles Searchbox_Main.TextChanged
        Dim menustr As New ContextMenuStrip
        menustr.Items.Clear()
        menustr.Show()
        Dim input As String = Searchbox_Main.Text.ToLower()
        For Each animes As UControl_AnimeSelector In Me.Controls.OfType(Of UControl_AnimeSelector)()
            For Each key As String In animes.dict.Keys
                '   If Not menustr.Items.Contains Then
                If key.ToLower().StartsWith(input) Then
                    menustr.Items.Add(key)
                End If
                '  End If
            Next
        Next
        'If Search_TB.Text = "" Then
        '    Search_LB.Items.Clear()
        'End If
    End Sub


End Class
'Public Class Connector
'    Implements IConnector
'    Dim T As New Dictionary(Of String, TabPage)
'    Dim frm As New Main

'    Public Sub New(ByVal frm As Main)
'        Me.frm = frm
'    End Sub

'    Public Sub CreateTabPage(text As String, frmtab As Object) Implements IConnector.CreateTabPage
'        Dim TP As New TabPage
'        TP.Text = text
'        frm.TabControl1.TabPages.Add(TP)
'        T.Add(text, TP)
'        frmtab.TopLevel = False
'        frmtab.Parent = frm.TabControl1.TabPages(frm.TabControl1.TabPages.Count - 1)
'        frmtab.Show()
'    End Sub
'    Public Sub SendLinkToPlayer(link As String) Implements IConnector.SendLinkToPlayer
'        ParserCore.SetStream(link)

'    End Sub
'    Public Sub SendEpisodeName(namme As String) Implements IConnector.SendEpisodeName


'    End Sub
'    Public Sub SendNextEpi(namme As String) Implements IConnector.SendNextEpisode


'    End Sub
'    Public Sub SendPrevEpi(namme As String) Implements IConnector.SendPrevEpisode


'    End Sub
'    Public Sub DeleteTabPage(ByVal text As String, frmtab As Object) Implements IConnector.DeleteTabPage
'        frmtab.parent = Nothing


'        frm.TabControl1.TabPages.Remove(T(text))
'        frmtab.close()
'        frmtab.dispose()
'    End Sub

'    Public Sub Disconnect(ByVal name As String) Implements IConnector.Disconnect
'        Try
'            frm.TabControl1.TabPages.Remove(T(name))
'            T.Remove(name)
'            frm.Plugs.Remove(name)
'        Catch : End Try
'    End Sub

'    Public Sub ShowMessagebox(text As String, title As String) Implements IConnector.ShowMessagebox
'        MessageBox.Show(text, title)
'    End Sub

'End Class