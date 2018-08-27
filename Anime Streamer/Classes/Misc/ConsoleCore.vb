Imports System.Threading


Public Class ConsoleCore
    Public Shared Debug As Boolean = False
    Public Shared LastCommand As String = ""
    Public Shared Sub AppendText(ByVal box As RichTextBox, ByVal text As String, ByVal color As Color)
        box.SelectionStart = box.TextLength
        box.SelectionLength = 0
        box.SelectionColor = color
        box.AppendText(text)
        box.SelectionColor = box.ForeColor
    End Sub
    Public Shared Function GetPingMs(ByRef hostNameOrAddress As String)
        Dim ping As New System.Net.NetworkInformation.Ping
        Return ping.Send(hostNameOrAddress).RoundtripTime
    End Function
    Public Shared Sub Report(ByVal box As RichTextBox, Txt As String, Colr As Color)
        If Debug = True Then
            box.Text += vbNewLine
            ConsoleCore.AppendText(box, TimeOfDay.TimeOfDay.ToString, Color.FromArgb(53, 175, 176))
            ConsoleCore.AppendText(box, ">:", Color.FromArgb(87, 166, 74))
            AppendText(box, Txt, Colr)
        End If
    End Sub
    Public Shared Sub CheckCommand(Command As String, box As RichTextBox)
        Try
            LastCommand = Command
            Command = Command.ToLower
        Catch ex As Exception
        End Try
        Select Case Command
            Case "help"
                AppendText(box, Command, Color.FromArgb(220, 220, 220))
                AppendText(box, vbNewLine & "          " & "home.prw.load = Loads in People are watching items on the home tabpage.", Color.FromArgb(220, 220, 220))
                AppendText(box, vbNewLine & "          " & "home.pop.load (2-90) = Loads in Popular items on the home tabpage. (ex: home.pop.load 2)", Color.FromArgb(220, 220, 220))
                AppendText(box, vbNewLine & "          " & "home.ncs.load (2-20) = Loads in Coming Soon items on the home tabpage. (ex: home.ncs.load 2)", Color.FromArgb(220, 220, 220))
                AppendText(box, vbNewLine & "          " & "animeselector.show = Shows the Anime Selector in the Shows tabpage.", Color.FromArgb(220, 220, 220))
                AppendText(box, vbNewLine & "          " & "animeselector.hide = Hides the Anime Selector in the Shows tabpage.", Color.FromArgb(220, 220, 220))
                AppendText(box, vbNewLine & "          " & "v(1-4).oib = ex: v1.oib open in stream link 1 your browser, etc", Color.FromArgb(220, 220, 220))
                AppendText(box, vbNewLine & "          " & "v(1-4).clear = ex: v1.clear will clear streamlink 1, etc", Color.FromArgb(220, 220, 220))
                AppendText(box, vbNewLine & "          " & "v(1-4).tostring = ex: v1.tostring will show streamlink 1, etc", Color.FromArgb(220, 220, 220))
                AppendText(box, vbNewLine & "          " & "v(1-4).try = ex: v1.try will try to stream link 1, etc", Color.FromArgb(220, 220, 220))
                AppendText(box, vbNewLine & "          " & "v(1-4).ping = ex: v1.ping will try to ping streamlink 1, etc", Color.FromArgb(220, 220, 220))
                AppendText(box, vbNewLine & "          " & "stream.links.tostring = Will show all streamlinks.", Color.FromArgb(220, 220, 220))
                AppendText(box, vbNewLine & "          " & "stream.links.ping = Will ping all streamlinks.", Color.FromArgb(220, 220, 220))
                AppendText(box, vbNewLine & "          " & "stream.clearlinks = Will clear all streamlinks.", Color.FromArgb(220, 220, 220))
                AppendText(box, vbNewLine & "          " & "history.clear = Clears your history.", Color.FromArgb(220, 220, 220))
                AppendText(box, vbNewLine & "          " & "favorites.clear = Clears your favorites.", Color.FromArgb(220, 220, 220))
                AppendText(box, vbNewLine & "          " & "encyclopedia.on = Turns on Encyclopedia Mode.", Color.FromArgb(220, 220, 220))
                AppendText(box, vbNewLine & "          " & "encyclopedia.off = Turns on Encyclopedia Mode.", Color.FromArgb(220, 220, 220))
                AppendText(box, vbNewLine & "          " & "home = Goes to the Home tabpage.", Color.FromArgb(220, 220, 220))
                AppendText(box, vbNewLine & "          " & "player = Goes to the Player tabpage.", Color.FromArgb(220, 220, 220))
                AppendText(box, vbNewLine & "          " & "shows = Goes to the Shows tabpage.", Color.FromArgb(220, 220, 220))
                AppendText(box, vbNewLine & "          " & "misc = Goes to the Misc tabpage.", Color.FromArgb(220, 220, 220))
                AppendText(box, vbNewLine & "          " & "animelist = Lists all 3000+ anime.", Color.FromArgb(220, 220, 220))
                AppendText(box, vbNewLine & "          " & "animelist.subbed = Lists all subbed anime.", Color.FromArgb(220, 220, 220))
                AppendText(box, vbNewLine & "          " & "animelist.dubbed = Lists all dubbed anime.", Color.FromArgb(220, 220, 220))
                AppendText(box, vbNewLine & "          " & "clear = Clear console.", Color.FromArgb(220, 220, 220))
                AppendText(box, vbNewLine & "          " & "fullscreen = Go into fullscreen mode.", Color.FromArgb(220, 220, 220))
                AppendText(box, vbNewLine & "          " & "normal = Go into normal mode.", Color.FromArgb(220, 220, 220))
                AppendText(box, vbNewLine & "          " & "restart = Restarts the application.", Color.FromArgb(220, 220, 220))
                AppendText(box, vbNewLine & "          " & "settings.loadhome = (false or true) : Loading Home page when the app starts.", Color.FromArgb(220, 220, 220))
                AppendText(box, vbNewLine & "          " & "settings.loadhistory = (false or true): Loading History when the app starts.", Color.FromArgb(220, 220, 220))
                AppendText(box, vbNewLine & "          " & "settings.loadfavorites = (false or true) : Loading Favorites when the app starts.", Color.FromArgb(220, 220, 220))
                AppendText(box, vbNewLine & "          " & "settings.loadwatching = (false or true) : Loading Watching items when the app starts.", Color.FromArgb(220, 220, 220))
                AppendText(box, vbNewLine & "          " & "settings.lite = (false or true) : Lite version of Anime Streamer.(History and Favorites)", Color.FromArgb(220, 220, 220))
                AppendText(box, vbNewLine & "          " & "settings.notifactions = (false, true, annoyed, regular, or more) : Load Notifactions to on, off, annoyed, regular, or more!", Color.FromArgb(220, 220, 220))
                AppendText(box, vbNewLine & "          " & "settings.liverecommends = (false or true) : Live Recommended Notifactions on or off!", Color.FromArgb(220, 220, 220))
                AppendText(box, vbNewLine & "          " & "settings.showtimeevents = (false or true) : Show Time Event Notifactions on or off!", Color.FromArgb(220, 220, 220))
                AppendText(box, vbNewLine & "          " & "settings.default = Default version of Anime Streamer.", Color.FromArgb(220, 220, 220))
                AppendText(box, vbNewLine & "          " & "debug = (true or false) Turns on or off debug reports, and sends it to the console.", Color.FromArgb(220, 220, 220))
                AppendText(box, vbNewLine & "          " & "topmost = (true or false) Makes Anime Streamer always on top depending on True or False.", Color.FromArgb(220, 220, 220))
                AppendText(box, vbNewLine & "          " & "miniview = (br, tr, bl, tl, or normal) Application goes into a mode where it can be viewed while working on other things.", Color.FromArgb(220, 220, 220))
                AppendText(box, vbNewLine & "          " & "donate = Donate to the developer.", Color.FromArgb(220, 220, 220))
                AppendText(box, vbNewLine & "          " & "console.popout = Puts the console in another window!", Color.FromArgb(220, 220, 220))
                AppendText(box, vbNewLine & "          " & "recommend = Recommends an anime, using your watched anime, if none then gets from PRW.", Color.FromArgb(220, 220, 220))

            Case "home.prw.load"
                AppendText(box, Command, Color.FromArgb(220, 220, 220))
                Home.ClearControls()
                Home_PRW.Done = False
                Home_PRW.LoadInPopularItems()
         
            Case "clear"
                Try
                    box.Clear()
                    ConsoleCore.AppendText(box, TimeOfDay.TimeOfDay.ToString, Color.FromArgb(53, 175, 176))
                    ConsoleCore.AppendText(box, ">:", Color.FromArgb(87, 166, 74))
                    ConsoleCore.AppendText(box, "Welcome to Anime Streamer's Console, type ", Color.FromArgb(220, 220, 220))
                    ConsoleCore.AppendText(box, Chr(34) & "help" & Chr(34), Color.FromArgb(214, 157, 133))
                    ConsoleCore.AppendText(box, " to display the commands!", Color.FromArgb(220, 220, 220))
                Catch ex As Exception
                    AppendText(box, vbNewLine & "          " & "Failed to clear Console.", Color.FromArgb(216, 80, 80))
                End Try
            Case "animeselector.show"
                AppendText(box, Command, Color.FromArgb(220, 220, 220))
                Main.PanelBox3.Visible = False
            Case "animeselector.hide"
                AppendText(box, Command, Color.FromArgb(220, 220, 220))
                Main.PanelBox3.Visible = True
            Case "v1.oib"
                AppendText(box, Command, Color.FromArgb(220, 220, 220))
                Try
                    Process.Start(ParserCore.VideoLink1)
                Catch ex As Exception
                    AppendText(box, vbNewLine & "          " & "Failed to open in browser.", Color.FromArgb(216, 80, 80))
                End Try
            Case "v2.oib"
                AppendText(box, Command, Color.FromArgb(220, 220, 220))
                Try
                    Process.Start(ParserCore.VideoLink2)
                Catch ex As Exception
                    AppendText(box, vbNewLine & "          " & "Failed to open in browser.", Color.FromArgb(216, 80, 80))
                End Try
            Case "v3.oib"
                AppendText(box, Command, Color.FromArgb(220, 220, 220))
                Try
                    Process.Start(ParserCore.VideoLink3)
                Catch ex As Exception
                    AppendText(box, vbNewLine & "          " & "Failed to open in browser.", Color.FromArgb(216, 80, 80))
                End Try
            Case "v4.oib"
                AppendText(box, Command, Color.FromArgb(220, 220, 220))
                Try
                    Process.Start(ParserCore.VideoLink4)
                Catch ex As Exception
                    AppendText(box, vbNewLine & "          " & "Failed to open in browser.", Color.FromArgb(216, 80, 80))
                End Try
            Case "v1.clear"
                AppendText(box, Command, Color.FromArgb(220, 220, 220))
                ParserCore.VideoLink1 = ""
                AppendText(box, vbNewLine & "          " & "Video Link 1 is cleared.", Color.FromArgb(220, 220, 220))
            Case "v2.clear"
                AppendText(box, Command, Color.FromArgb(220, 220, 220))
                ParserCore.VideoLink2 = ""
                AppendText(box, vbNewLine & "          " & "Video Link 2 is cleared.", Color.FromArgb(220, 220, 220))
            Case "v3.clear"
                AppendText(box, Command, Color.FromArgb(220, 220, 220))
                ParserCore.VideoLink3 = ""
                AppendText(box, vbNewLine & "          " & "Video Link 3 is cleared.", Color.FromArgb(220, 220, 220))
            Case "v4.clear"
                AppendText(box, Command, Color.FromArgb(220, 220, 220))
                ParserCore.VideoLink4 = ""
                AppendText(box, vbNewLine & "          " & "Video Link 4 is cleared.", Color.FromArgb(220, 220, 220))
            Case "v1.tostring"
                AppendText(box, Command, Color.FromArgb(220, 220, 220))
                Try
                    AppendText(box, vbNewLine & "          v1: " & ParserCore.VideoLink1.ToString, Color.FromArgb(220, 220, 220))
                Catch ex As Exception
                    AppendText(box, vbNewLine & "          " & "Failed to get link.", Color.FromArgb(216, 80, 80))
                End Try
            Case "v2.tostring"
                AppendText(box, Command, Color.FromArgb(220, 220, 220))
                Try
                    AppendText(box, vbNewLine & "          v2: " & ParserCore.VideoLink2.ToString, Color.FromArgb(220, 220, 220))
                Catch ex As Exception
                    AppendText(box, vbNewLine & "          " & "Failed to get link.", Color.FromArgb(216, 80, 80))
                End Try
            Case "v3.tostring"
                AppendText(box, Command, Color.FromArgb(220, 220, 220))
                Try
                    AppendText(box, vbNewLine & "          v3: " & ParserCore.VideoLink3.ToString, Color.FromArgb(220, 220, 220))
                Catch ex As Exception
                    AppendText(box, vbNewLine & "          " & "Failed to get link.", Color.FromArgb(216, 80, 80))
                End Try
            Case "v4.tostring"
                AppendText(box, Command, Color.FromArgb(220, 220, 220))
                Try
                    AppendText(box, vbNewLine & "          v4: " & ParserCore.VideoLink4.ToString, Color.FromArgb(220, 220, 220))
                Catch ex As Exception
                    AppendText(box, vbNewLine & "          " & "Failed to get link.", Color.FromArgb(216, 80, 80))
                End Try
            Case "v1.try"
                AppendText(box, Command, Color.FromArgb(220, 220, 220))
                Try
                    AppendText(box, vbNewLine & "          " & "Trying v1: " & ParserCore.VideoLink1.ToString, Color.FromArgb(220, 220, 220))
                    Evulate.VideoLink1()
                Catch ex As Exception
                    AppendText(box, vbNewLine & "          " & "Failed to stream.", Color.FromArgb(216, 80, 80))
                End Try
            Case "v2.try"
                AppendText(box, Command, Color.FromArgb(220, 220, 220))
                Try
                    AppendText(box, vbNewLine & "          " & "Trying v2: " & ParserCore.VideoLink2.ToString, Color.FromArgb(220, 220, 220))
                    Evulate.VideoLink2()
                Catch ex As Exception
                    AppendText(box, vbNewLine & "          " & "Failed to stream.", Color.FromArgb(216, 80, 80))
                End Try
            Case "v3.try"
                AppendText(box, Command, Color.FromArgb(220, 220, 220))
                Try
                    AppendText(box, vbNewLine & "          " & "Trying v3: " & ParserCore.VideoLink3.ToString, Color.FromArgb(220, 220, 220))
                    Evulate.VideoLink3()
                Catch ex As Exception
                    AppendText(box, vbNewLine & "          " & "Failed to stream.", Color.FromArgb(216, 80, 80))
                End Try
            Case "v4.try"
                AppendText(box, Command, Color.FromArgb(220, 220, 220))
                Try
                    AppendText(box, vbNewLine & "          " & "Trying v4: " & ParserCore.VideoLink4.ToString, Color.FromArgb(220, 220, 220))
                    Evulate.VideoLink4()
                Catch ex As Exception
                    AppendText(box, vbNewLine & "          " & "Failed to stream.", Color.FromArgb(216, 80, 80))
                End Try
            Case "v1.ping"
                AppendText(box, Command, Color.FromArgb(220, 220, 220))
                Try
                    AppendText(box, vbNewLine & "          v1: " & GetPingMs(ParserCore.VideoLink1.ToString), Color.FromArgb(216, 80, 80))
                Catch ex As Exception
                    AppendText(box, vbNewLine & "          " & "Failed to ping.", Color.FromArgb(216, 80, 80))
                End Try
            Case "v2.ping"
                AppendText(box, Command, Color.FromArgb(220, 220, 220))
                Try
                    Dim ping As New System.Net.NetworkInformation.Ping
                    Dim ms = ping.Send(ParserCore.VideoLink2.ToString).RoundtripTime()
                    AppendText(box, vbNewLine & "          v2: " & ms.ToString, Color.FromArgb(216, 80, 80))
                Catch ex As Exception
                    AppendText(box, vbNewLine & "          " & "Failed to ping.", Color.FromArgb(216, 80, 80))
                End Try
            Case "v3.ping"
                AppendText(box, Command, Color.FromArgb(220, 220, 220))
                Try
                    Dim ping As New System.Net.NetworkInformation.Ping
                    Dim ms = ping.Send(ParserCore.VideoLink3.ToString).RoundtripTime()
                    AppendText(box, vbNewLine & "          v3: " & ms.ToString, Color.FromArgb(216, 80, 80))
                Catch ex As Exception
                    AppendText(box, vbNewLine & "          " & "Failed to ping.", Color.FromArgb(216, 80, 80))
                End Try
            Case "v4.ping"
                AppendText(box, Command, Color.FromArgb(220, 220, 220))
                Try
                    Dim ping As New System.Net.NetworkInformation.Ping
                    Dim ms = ping.Send(ParserCore.VideoLink4.ToString).RoundtripTime()
                    AppendText(box, vbNewLine & "          v4: " & ms.ToString, Color.FromArgb(216, 80, 80))
                Catch ex As Exception
                    AppendText(box, vbNewLine & "          " & "Failed to ping.", Color.FromArgb(216, 80, 80))
                End Try
            Case "stream.links.ping"
                AppendText(box, Command, Color.FromArgb(220, 220, 220))
                Try
                    Dim ping As New System.Net.NetworkInformation.Ping
                    Dim ms = ping.Send(ParserCore.VideoLink1.ToString).RoundtripTime()
                    AppendText(box, vbNewLine & "          v1: " & ms.ToString, Color.FromArgb(216, 80, 80))
                Catch ex As Exception
                    AppendText(box, vbNewLine & "          " & "Failed to ping.", Color.FromArgb(216, 80, 80))
                End Try
                Try
                    Dim ping As New System.Net.NetworkInformation.Ping
                    Dim ms = ping.Send(ParserCore.VideoLink2.ToString).RoundtripTime()
                    AppendText(box, vbNewLine & "          v2: " & ms.ToString, Color.FromArgb(216, 80, 80))
                Catch ex As Exception
                    AppendText(box, vbNewLine & "          " & "Failed to ping.", Color.FromArgb(216, 80, 80))
                End Try
                Try
                    Dim ping As New System.Net.NetworkInformation.Ping
                    Dim ms = ping.Send(ParserCore.VideoLink3.ToString).RoundtripTime()
                    AppendText(box, vbNewLine & "          v3: " & ms.ToString, Color.FromArgb(216, 80, 80))
                Catch ex As Exception
                    AppendText(box, vbNewLine & "          " & "Failed to ping.", Color.FromArgb(216, 80, 80))
                End Try
                Try
                    Dim ping As New System.Net.NetworkInformation.Ping
                    Dim ms = ping.Send(ParserCore.VideoLink4.ToString).RoundtripTime()
                    AppendText(box, vbNewLine & "          v4: " & ms.ToString, Color.FromArgb(216, 80, 80))
                Catch ex As Exception
                    AppendText(box, vbNewLine & "          " & "Failed to ping.", Color.FromArgb(216, 80, 80))
                End Try
            Case "stream.links.tostring"
                Try
                    AppendText(box, Command, Color.FromArgb(220, 220, 220))
                    AppendText(box, vbNewLine & "          v1: " & ParserCore.VideoLink1.ToString, Color.FromArgb(220, 220, 220))
                    AppendText(box, vbNewLine & "          v2: " & ParserCore.VideoLink2.ToString, Color.FromArgb(220, 220, 220))
                    AppendText(box, vbNewLine & "          v3: " & ParserCore.VideoLink3.ToString, Color.FromArgb(220, 220, 220))
                    AppendText(box, vbNewLine & "          v4: " & ParserCore.VideoLink4.ToString, Color.FromArgb(220, 220, 220))
                Catch ex As Exception
                    AppendText(box, vbNewLine & "          " & "Failed to get links.", Color.FromArgb(216, 80, 80))
                End Try
            Case "stream.clearlinks"
                AppendText(box, Command, Color.FromArgb(220, 220, 220))
                ParserCore.VideoLink1 = ""
                AppendText(box, vbNewLine & "          " & "Video Link 1 is cleared.", Color.FromArgb(220, 220, 220))
                ParserCore.VideoLink2 = ""
                AppendText(box, vbNewLine & "          " & "Video Link 2 is cleared.", Color.FromArgb(220, 220, 220))
                ParserCore.VideoLink3 = ""
                AppendText(box, vbNewLine & "          " & "Video Link 3 is cleared.", Color.FromArgb(220, 220, 220))
                ParserCore.VideoLink4 = ""
                AppendText(box, vbNewLine & "          " & "Video Link 4 is cleared.", Color.FromArgb(220, 220, 220))
            Case "history.clear"
                AppendText(box, Command, Color.FromArgb(220, 220, 220))
                Try
                    History.Histdict.Clear()
                    History.SaveHist()
                    Main.History_LB.Items.Clear()
                Catch ex As Exception
                    AppendText(box, vbNewLine & "          " & "Failed to clear history.", Color.FromArgb(216, 80, 80))
                End Try
            Case "favorites.clear"
                AppendText(box, Command, Color.FromArgb(220, 220, 220))
                Try
                    Favorites.Favdict.Clear()
                    Favorites.SaveFav()
                    Main.Favorites_LB.Items.Clear()
                Catch ex As Exception
                    AppendText(box, vbNewLine & "          " & "Failed to clear favorites.", Color.FromArgb(216, 80, 80))
                End Try
            Case "encyclopedia.on"
                AppendText(box, Command, Color.FromArgb(220, 220, 220))
                Main.GroupRecommendations_GB.Visible = True
                Main.prog.Visible = True
                Main.progtext.Visible = True
            Case "encyclopedia.off"
                AppendText(box, Command, Color.FromArgb(220, 220, 220))
                Main.GroupRecommendations_GB.Visible = False
                Main.prog.Visible = False
                Main.progtext.Visible = False
            Case "home"
                AppendText(box, [String].Format(Command), Color.FromArgb(220, 220, 220))
                Main.Main_TabControl.SelectedIndex = 0
            Case "player"
                AppendText(box, Command, Color.FromArgb(220, 220, 220))
                Main.Main_TabControl.SelectedIndex = 1
            Case "shows"
                AppendText(box, Command, Color.FromArgb(220, 220, 220))
                Main.Main_TabControl.SelectedIndex = 2
            Case "misc"
                AppendText(box, Command, Color.FromArgb(220, 220, 220))
                Main.Main_TabControl.SelectedIndex = 3
            Case "animelist"
                AppendText(box, Command, Color.FromArgb(220, 220, 220))
                Dim i As Integer = 0
                For Each key In Listings.ATdict.Keys
                    i += 1
                    AppendText(box, vbNewLine & "          " & key, Color.FromArgb(220, 220, 220))
                Next
                For Each key In Listings.GAdict.Keys
                    i += 1
                    AppendText(box, vbNewLine & "          " & key, Color.FromArgb(220, 220, 220))
                Next
                AppendText(box, vbNewLine & "          " & "Total = " & i, Color.FromArgb(220, 220, 220))
            Case "animelist.subbed"
                AppendText(box, Command, Color.FromArgb(220, 220, 220))
                Dim i As Integer = 0
                For Each key In Listings.GAdict.Keys
                    i += 1
                    AppendText(box, vbNewLine & "          " & key, Color.FromArgb(220, 220, 220))
                Next
                AppendText(box, vbNewLine & "          " & "Total = " & i, Color.FromArgb(220, 220, 220))
            Case "animelist.dubbed"
                AppendText(box, Command, Color.FromArgb(220, 220, 220))
                Dim i As Integer = 0
                For Each key In Listings.ATdict.Keys
                    i += 1
                    AppendText(box, vbNewLine & "          " & key, Color.FromArgb(220, 220, 220))
                Next
                AppendText(box, vbNewLine & "          " & "Total = " & i, Color.FromArgb(220, 220, 220))
            Case "fullscreen"
                Try
                    Main.WindowState = FormWindowState.Normal
                Catch ex As Exception
                End Try
                AppendText(box, "Type ", Color.FromArgb(220, 220, 220))
                AppendText(box, Chr(34) & "normal" & Chr(34), Color.FromArgb(216, 80, 80))
                AppendText(box, " to go back normal.", Color.FromArgb(220, 220, 220))
                Main.FormBorderStyle = Windows.Forms.FormBorderStyle.None
                Main.Location = New Point(0, 70)
                Main.WindowState = FormWindowState.Maximized
                Main.TopMost = True
            Case "normal"
                AppendText(box, Command, Color.FromArgb(220, 220, 220))
                Main.FormBorderStyle = FormBorderStyle.Sizable
                Main.WindowState = FormWindowState.Normal
                Main.TopMost = False
            Case "settings.loadhome = false"
                AppendText(box, Command, Color.FromArgb(220, 220, 220))
                Settings.SaveSettings("LoadHome", False)
            Case "settings.loadhome = true"
                AppendText(box, Command, Color.FromArgb(220, 220, 220))
                Settings.SaveSettings("LoadHome", True)
            Case "settings.loadfavorites = false"
                AppendText(box, Command, Color.FromArgb(220, 220, 220))
                Settings.SaveSettings("LoadFavorites", False)
            Case "settings.loadfavorites = true"
                AppendText(box, Command, Color.FromArgb(220, 220, 220))
                Settings.SaveSettings("LoadFavorites", True)
            Case "settings.loadhistory = false"
                AppendText(box, Command, Color.FromArgb(220, 220, 220))
                Settings.SaveSettings("LoadHistory", False)
            Case "settings.loadhistory = true"
                AppendText(box, Command, Color.FromArgb(220, 220, 220))
                Settings.SaveSettings("LoadHistory", True)
            Case "settings.notifactions = true"
                AppendText(box, Command, Color.FromArgb(220, 220, 220))
                Settings.SaveSettings("Notifactions", True)
            Case "settings.notifactions = false"
                AppendText(box, Command, Color.FromArgb(220, 220, 220))
                Settings.SaveSettings("Notifactions", False)
            Case "settings.notifactions = more"
                AppendText(box, Command, Color.FromArgb(220, 220, 220))
                Recommendations.Max = 3
            Case "settings.notifactions = regular"
                AppendText(box, Command, Color.FromArgb(220, 220, 220))
                Recommendations.Max = 5
            Case "settings.notifactions = annoyed"
                AppendText(box, Command, Color.FromArgb(220, 220, 220))
                Recommendations.Max = 15
            Case "settings.liverecommends = true"
                AppendText(box, Command, Color.FromArgb(220, 220, 220))
                Settings.SaveSettings("LiveRecommends", True)
            Case "settings.liverecommends = false"
                AppendText(box, Command, Color.FromArgb(220, 220, 220))
                Settings.SaveSettings("LiveRecommends", False)
            Case "settings.showtimeevents = true"
                AppendText(box, Command, Color.FromArgb(220, 220, 220))
                Settings.SaveSettings("ShowTimeEvents", True)
            Case "recommend"
                AppendText(box, Command, Color.FromArgb(220, 220, 220))
                Recommendations.FindWatchedAnime()
            Case "settings.showtimeevents = false"
                AppendText(box, Command, Color.FromArgb(220, 220, 220))
                Settings.SaveSettings("ShowTimeEvents", False)
            Case "settings.lite = true"
                AppendText(box, Command, Color.FromArgb(220, 220, 220))
                Settings.SaveSettings("LoadHome", False)
                Settings.SaveSettings("LoadHistory", True)
                Settings.SaveSettings("LoadFavorites", True)
                Settings.SaveSettings("LoadWatching", True)
            Case "settings.lite = false"
                AppendText(box, Command, Color.FromArgb(220, 220, 220))
                Settings.SaveSettings("LoadHome", True)
            Case "settings.default"
                AppendText(box, Command, Color.FromArgb(220, 220, 220))
                Settings.SaveSettings("LoadHome", True)
                Settings.SaveSettings("LoadHistory", True)
                Settings.SaveSettings("LoadFavorites", True)
                Settings.SaveSettings("LoadWatching", True)
                Settings.SaveSettings("Notifactions", True)
                Settings.SaveSettings("ShowTimeEvents", True)
                Settings.SaveSettings("LiveRecommends", True)
            Case "settings.loadwatching = true"
                AppendText(box, Command, Color.FromArgb(220, 220, 220))
                Settings.SaveSettings("LoadWatching", True)
            Case "settings.loadwatching = false"
                AppendText(box, Command, Color.FromArgb(220, 220, 220))
                Settings.SaveSettings("LoadWatching", False)
            Case "debug = true"
                AppendText(box, Command, Color.FromArgb(220, 220, 220))
                Debug = True
            Case "debug = false"
                AppendText(box, Command, Color.FromArgb(220, 220, 220))
                Debug = False
            Case "topmost = true"
                AppendText(box, Command, Color.FromArgb(220, 220, 220))
                Try
                    Main.TopMost = True
                Catch ex As Exception
                End Try
            Case "topmost = false"
                AppendText(box, Command, Color.FromArgb(220, 220, 220))
                Try
                    Main.TopMost = False
                Catch ex As Exception
                End Try
            Case "restart"
                AppendText(box, Command, Color.FromArgb(220, 220, 220))
                Application.Restart()
            Case "miniview = tl"
                AppendText(box, "Type ", Color.FromArgb(220, 220, 220))
                AppendText(box, Chr(34) & "topview = normal" & Chr(34), Color.FromArgb(216, 80, 80))
                AppendText(box, " to go back normal.", Color.FromArgb(220, 220, 220))
                Try
                    Main.SoundCloudTopBar1.Visible = False
                    For Each vo As UControl_VideoOptions In Main.Controls.OfType(Of UControl_VideoOptions)()
                        vo.Location = New Point(0, vo.Height - vo.Height * 2 + 6)
                    Next
                    Main.TopMost = True
                    Main.WindowState = FormWindowState.Normal
                    Main.FormBorderStyle = FormBorderStyle.None
                    Main.Width = 380
                    Main.Height = 270
                    'Main.AxWindowsMediaPlayer1.uiMode = "full"
                    ' Main.AxVLCPlugin21.Toolbar = True
                    Main.Player1.Visible = False
                    Dim x As Integer
                    Dim y As Integer
                    y = 0
                    x = 0
                    Main.Location = New Point(x, y)
                Catch ex As Exception
                End Try
            Case "miniview = tr"
                AppendText(box, "Type ", Color.FromArgb(220, 220, 220))
                AppendText(box, Chr(34) & "topview = normal" & Chr(34), Color.FromArgb(216, 80, 80))
                AppendText(box, " to go back normal.", Color.FromArgb(220, 220, 220))
                Try
                    Main.TopMost = True
                    Main.SoundCloudTopBar1.Visible = False
                    For Each vo As UControl_VideoOptions In Main.Controls.OfType(Of UControl_VideoOptions)()
                        vo.Location = New Point(0, vo.Height - vo.Height * 2 + 6)
                    Next
                    Main.WindowState = FormWindowState.Normal
                    Main.FormBorderStyle = FormBorderStyle.None
                    Main.Width = 380
                    Main.Height = 270
                    'Main.AxWindowsMediaPlayer1.uiMode = "full"
                    'Main.AxVLCPlugin21.Toolbar = True
                    Main.Player1.Visible = False
                    Dim x As Integer
                    Dim y As Integer
                    y = 0
                    x = Screen.PrimaryScreen.WorkingArea.Width - Main.Width
                    Main.Location = New Point(x, y)
                Catch ex As Exception
                End Try
            Case "miniview = br"
                AppendText(box, "Type ", Color.FromArgb(220, 220, 220))
                AppendText(box, Chr(34) & "topview = normal" & Chr(34), Color.FromArgb(216, 80, 80))
                AppendText(box, " to go back normal.", Color.FromArgb(220, 220, 220))
                Try
                    Main.TopMost = True
                    Main.SoundCloudTopBar1.Visible = False
                    For Each vo As UControl_VideoOptions In Main.Controls.OfType(Of UControl_VideoOptions)()
                        vo.Location = New Point(0, vo.Height - vo.Height * 2 + 6)
                    Next
                    Main.WindowState = FormWindowState.Normal
                    Main.FormBorderStyle = FormBorderStyle.None
                    Main.Width = 380
                    Main.Height = 270
                    'Main.AxWindowsMediaPlayer1.uiMode = "full"
                    'Main.AxVLCPlugin21.Toolbar = True
                    Main.Player1.Visible = False
                    Dim x As Integer
                    Dim y As Integer
                    y = Screen.PrimaryScreen.WorkingArea.Height - Main.Height
                    x = Screen.PrimaryScreen.WorkingArea.Width - Main.Width
                    Main.Location = New Point(x, y)
                Catch ex As Exception
                End Try
            Case "miniview = bl"
                AppendText(box, "Type ", Color.FromArgb(220, 220, 220))
                AppendText(box, Chr(34) & "topview = normal" & Chr(34), Color.FromArgb(216, 80, 80))
                AppendText(box, " to go back normal.", Color.FromArgb(220, 220, 220))
                Try
                    Main.TopMost = True
                    Main.SoundCloudTopBar1.Visible = False
                    For Each vo As UControl_VideoOptions In Main.Controls.OfType(Of UControl_VideoOptions)()
                        vo.Location = New Point(0, vo.Height - vo.Height * 2 + 6)
                    Next
                    Main.WindowState = FormWindowState.Normal
                    Main.FormBorderStyle = FormBorderStyle.None
                    Main.Width = 380
                    Main.Height = 270
                    'Main.AxWindowsMediaPlayer1.uiMode = "full"
                    'Main.AxVLCPlugin21.Toolbar = True
                    Main.Player1.Visible = False
                    Dim x As Integer
                    Dim y As Integer
                    y = Screen.PrimaryScreen.WorkingArea.Height - Main.Height
                    x = 0
                    Main.Location = New Point(x, y)
                Catch ex As Exception
                End Try
            Case "miniview = normal"
                AppendText(box, Command, Color.FromArgb(220, 220, 220))
                Main.TopMost = False
                Main.SoundCloudTopBar1.Visible = True
                For Each vo As UControl_VideoOptions In Main.Controls.OfType(Of UControl_VideoOptions)()
                    vo.Location = New Point(113 + 207, 0)
                Next
                Main.WindowState = FormWindowState.Maximized
                Main.FormBorderStyle = FormBorderStyle.Sizable
                'Main.AxWindowsMediaPlayer1.uiMode = "none"
                'Main.AxVLCPlugin21.Toolbar = False
                Main.Player1.Visible = True
            Case "donate"
                AppendText(box, "You can go to ", Color.FromArgb(220, 220, 220))
                AppendText(box, Chr(34) & "www.paypal.com" & Chr(34), Color.FromArgb(216, 80, 80))
                AppendText(box, " and you can send any amount of money to netrosly@gmail.com, any money recieved will be greatly appreciated!", Color.FromArgb(220, 220, 220))
            Case "console.popout"
                AppendText(box, "For the console to be ", Color.FromArgb(220, 220, 220))
                AppendText(box, Chr(34) & "normal" & Chr(34), Color.FromArgb(216, 80, 80))
                AppendText(box, " again it close button on the Mini Console window.", Color.FromArgb(220, 220, 220))
                frm.Size = New Size(720, 480)
                frm.FormBorderStyle = FormBorderStyle.Sizable
                frm.Icon = Main.Icon
                frm.Text = "Mini Console"
                AddHandler frm.Load, AddressOf frm_load
                AddHandler frm.FormClosing, AddressOf frm_close
                Try
                    frm.Show()
                Catch ex As Exception
                End Try
            Case Command
                If Command.Contains("home.ncs.load") Then
                    If Command.Contains(" ") Then
                        Try
                            Dim temp As String = Command.Split(" ").Last()
                            AppendText(box, Command, Color.FromArgb(220, 220, 220))
                            Home.ClearControls()
                            Home_NRS.Done = False
                            Home_NRS.GetNRSSource("http://www.goodanime.net/category/new-release/page/" & temp)


                        Catch ex As Exception
                            AppendText(box, vbNewLine & "          " & "Failed to load in.", Color.FromArgb(216, 80, 80))
                        End Try
                    Else
                        AppendText(box, Command, Color.FromArgb(220, 220, 220))
                        Home_NRS.Done = False
                        Home.ClearControls()
                        Home_NRS.GetNRSSource("http://www.goodanime.net/category/new-release")

                    End If
                End If
                If Command.Contains("home.pop.load") Then
                    If Command.Contains(" ") Then
                        Try
                            Dim temp As String = Command.Split(" ").Last()
                            AppendText(box, Command, Color.FromArgb(220, 220, 220))
                            Home_POP.Done = False
                            Home.ClearControls()
                            Home_POP.AnimeToonPopPage("http://www.animetoon.tv/popular-list/" & temp)

                        Catch ex As Exception
                            AppendText(box, vbNewLine & "          " & "Failed to load in.", Color.FromArgb(216, 80, 80))
                        End Try
                    Else
                        AppendText(box, Command, Color.FromArgb(220, 220, 220))
                        Home_POP.Done = False
                        Home.ClearControls()
                        Home_POP.AnimeToonPopPage("http://www.animetoon.tv/popular-list/2")
                    End If
                End If
            Case Else
                AppendText(box, "Looks like ", Color.FromArgb(220, 220, 220))
                AppendText(box, Chr(34) & Command & ".... " & Chr(34), Color.FromArgb(214, 157, 133))
                AppendText(box, " isn't a command.", Color.FromArgb(220, 220, 220))
        End Select
        Try
            box.ScrollToCaret()
        Catch ex As Exception
        End Try
    End Sub
    Public Shared frm As New Form
    Public Shared Sub frm_load(sender As Object, e As EventArgs)
        frm.Controls.Add(Main.Console_box)
        frm.Controls.Add(Main.TextBox1)
        Main.KoboTabControlS2.TabPages.Remove(Main.KoboTabControlS2.TabPages(3))
    End Sub

    Private Shared Sub frm_close(sender As Object, e As FormClosingEventArgs)
        Main.KoboTabControlS2.TabPages.Add("Console")
        For Each Cot As Control In frm.Controls.OfType(Of Control)()
            Main.KoboTabControlS2.TabPages(3).Controls.Add(Cot)
        Next
        For Each cot As TextBox In frm.Controls.OfType(Of TextBox)()
            Main.KoboTabControlS2.TabPages(3).Controls.Add(cot)
        Next
    End Sub

End Class
