Public Class UControl_VideoOptions
    Dim inner As Boolean = False
    Private Sub VideoOptions_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Location = New Point(113 + 207, 0)
    End Sub

    Private Sub FullScreen_Click(sender As Object, e As EventArgs) Handles FullScreen.Click
        Try
            ' Main.AxVLCPlugin21.video.toggleFullscreen()
            'Main.AxWindowsMediaPlayer1.uiMode = "full"
            'Main.AxWindowsMediaPlayer1.Refresh()
            'Main.AxWindowsMediaPlayer1.fullScreen = True

        Catch ex As Exception

        End Try
    End Sub

    Private Sub PrevEp_Click(sender As Object, e As EventArgs) Handles PrevEp.Click
        If Not Globals.PreviousEpisodeLink = "None" Then
            If Globals.NextNPrevService = "GoodAnime" Then
                Globals.EpisodeLink = Globals.PreviousEpisodeLink
                Dim namme As String
                Try
                    namme = Globals.PreviousEpisodeLink.Split("/"c).Last()
                    History.AddHistory(namme, Globals.PreviousEpisodeLink)
                Catch ex As Exception
                    History.AddHistory(Globals.EpisodeName, Globals.PreviousEpisodeLink)
                End Try
                Subbed.GoodAnimeParse()
            ElseIf Globals.NextNPrevService = "AnimeToon" Then
                Globals.EpisodeLink = Globals.PreviousEpisodeLink
                Dim namme As String
                Try
                    namme = Globals.PreviousEpisodeLink.Split("/"c).Last()
                    History.AddHistory(namme, Globals.PreviousEpisodeLink)
                Catch ex As Exception
                    History.AddHistory(Globals.EpisodeName, Globals.PreviousEpisodeLink)
                End Try
                Dubbed.AnimeToonParse()
            End If
        End If
    End Sub

    Private Sub NextEp_Click(sender As Object, e As EventArgs) Handles NextEp.Click
        If Not Globals.NextEpisodeLink = "None" Then
            If Globals.NextNPrevService = "GoodAnime" Then
                Globals.EpisodeLink = Globals.NextEpisodeLink
                Dim namme As String
                Try
                    namme = Globals.NextEpisodeLink.Split("/"c).Last()
                    History.AddHistory(namme, Globals.NextEpisodeLink)
                Catch ex As Exception
                    History.AddHistory(Globals.EpisodeName, Globals.NextEpisodeLink)
                End Try
                Subbed.GoodAnimeParse()
            ElseIf Globals.NextNPrevService = "AnimeToon" Then
                Globals.EpisodeLink = Globals.NextEpisodeLink
                Dim namme As String
                Try
                    namme = Globals.NextEpisodeLink.Split("/"c).Last()
                    History.AddHistory(namme, Globals.NextEpisodeLink)
                Catch ex As Exception
                    History.AddHistory(Globals.EpisodeName, Globals.NextEpisodeLink)
                End Try
                Dubbed.AnimeToonParse()
            End If
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Main.FormBorderStyle = FormBorderStyle.None And Main.Height = 270 Then
            If inner = True Then
                Me.Location = New Point(0, 0)
            Else
                Me.Location = New Point(0, Me.Height - Me.Height * 2 + 6)
            End If
        End If
            If Globals.NextEpisodeLink = "None" Or Globals.NextEpisodeLink = "" Then
                NextEp.Visible = False
                NextEp.Width = 0
            Else
                NextEp.Visible = True
                NextEp.Width = 30
            End If
            If Globals.PreviousEpisodeLink = "None" Or Globals.PreviousEpisodeLink = "" Then
                PrevEp.Visible = False
                PrevEp.Width = 0
            Else
                PrevEp.Visible = True
                PrevEp.Width = 30
            End If
            If Not ParserCore.VideoLink1 = "" Then
                Refresh_Button.Visible = True
                Refresh_Button.Width = 23
                Globe_button.Visible = True
                Globe_button.Width = 23
                FullScreen.Visible = True
                FullScreen.Width = 23
                Down_but.Visible = True
                Down_but.Width = 23
            Else
                Refresh_Button.Visible = False
                Refresh_Button.Width = 0
                Globe_button.Visible = False
                Globe_button.Width = 0
                FullScreen.Visible = False
                FullScreen.Width = 0
                Down_but.Visible = False
                Down_but.Width = 0
            End If

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Globe_button.Click
        Try
            Process.Start(Globals.StreamLink)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub Refresh_Button_Click(sender As Object, e As EventArgs) Handles Refresh_Button.Click
        Try
            Evulate.ClearVLs()
            Evulate.VideoLink1()
            Evulate.VL1 = True
        Catch ex As Exception

        End Try
    End Sub

    Private Sub Down_but_Click(sender As Object, e As EventArgs) Handles Down_but.Click
        Dim cms = New ContextMenuStrip
        Dim MousePosition As Point
        cms.BackColor = Color.FromArgb(28, 28, 28, 28)

        MousePosition = Cursor.Position
        Dim item1 = cms.Items.Add("Try Videolink 1")
        item1.BackColor = Color.FromArgb(28, 28, 28)
        item1.ForeColor = Color.White
        item1.Tag = 1
        Dim item2 = cms.Items.Add("Try Videolink 2")
        item2.Tag = 2
        item2.BackColor = Color.FromArgb(28, 28, 28)
        item2.ForeColor = Color.White
        Dim item3 = cms.Items.Add("Try Videolink 3")
        item3.Tag = 3
        item3.BackColor = Color.FromArgb(28, 28, 28)
        item3.ForeColor = Color.White
        Dim item4 = cms.Items.Add("Try Videolink 4")
        item4.Tag = 4
        item4.BackColor = Color.FromArgb(28, 28, 28)
        item4.ForeColor = Color.White
        Dim item5 = cms.Items.Add("MiniView")
        item5.Tag = 5
        item5.BackColor = Color.FromArgb(28, 28, 28)
        item5.ForeColor = Color.White
        Dim dropdownitem5 = DirectCast(cms.Items(4), ToolStripMenuItem).DropDownItems.Add("Normal")
        dropdownitem5.Tag = 10
        dropdownitem5.BackColor = Color.FromArgb(28, 28, 28)
        dropdownitem5.ForeColor = Color.White
        Dim dropdownitem = DirectCast(cms.Items(4), ToolStripMenuItem).DropDownItems.Add("Top Left")
        dropdownitem.Tag = 6
        dropdownitem.BackColor = Color.FromArgb(28, 28, 28)
        dropdownitem.ForeColor = Color.White
        Dim dropdownitem2 = DirectCast(cms.Items(4), ToolStripMenuItem).DropDownItems.Add("Top Right")
        dropdownitem2.Tag = 7
        dropdownitem2.BackColor = Color.FromArgb(28, 28, 28)
        dropdownitem2.ForeColor = Color.White
        Dim dropdownitem3 = DirectCast(cms.Items(4), ToolStripMenuItem).DropDownItems.Add("Bottom Left")
        dropdownitem3.Tag = 8
        dropdownitem3.BackColor = Color.FromArgb(28, 28, 28)
        dropdownitem3.ForeColor = Color.White
        Dim dropdownitem4 = DirectCast(cms.Items(4), ToolStripMenuItem).DropDownItems.Add("Bottom Right")
        dropdownitem4.Tag = 9
        dropdownitem4.BackColor = Color.FromArgb(28, 28, 28)
        dropdownitem4.ForeColor = Color.White
        Dim item6 = cms.Items.Add("Player")
        item6.Tag = 11
        item6.BackColor = Color.FromArgb(28, 28, 28)
        item6.ForeColor = Color.White
        Dim dropdownitem6 = DirectCast(cms.Items(5), ToolStripMenuItem).DropDownItems.Add("Default GUI")
        dropdownitem6.Tag = 12
        dropdownitem6.BackColor = Color.FromArgb(28, 28, 28)
        dropdownitem6.ForeColor = Color.White
        Dim dropdownitem7 = DirectCast(cms.Items(5), ToolStripMenuItem).DropDownItems.Add("Custom GUI")
        dropdownitem7.Tag = 13
        dropdownitem7.BackColor = Color.FromArgb(28, 28, 28)
        dropdownitem7.ForeColor = Color.White
        Dim dropdownitem8 = DirectCast(cms.Items(5), ToolStripMenuItem).DropDownItems.Add("Custom VideoLink")
        dropdownitem8.Tag = 14
        dropdownitem8.BackColor = Color.FromArgb(28, 28, 28)
        dropdownitem8.ForeColor = Color.White
        AddHandler item1.Click, AddressOf menuChoice
        AddHandler item2.Click, AddressOf menuChoice
        AddHandler item3.Click, AddressOf menuChoice
        AddHandler item4.Click, AddressOf menuChoice
        AddHandler item5.Click, AddressOf menuChoice
        AddHandler item6.Click, AddressOf menuChoice
        AddHandler dropdownitem.Click, AddressOf menuChoice
        AddHandler dropdownitem2.Click, AddressOf menuChoice
        AddHandler dropdownitem3.Click, AddressOf menuChoice
        AddHandler dropdownitem4.Click, AddressOf menuChoice
        AddHandler dropdownitem5.Click, AddressOf menuChoice
        AddHandler dropdownitem6.Click, AddressOf menuChoice
        AddHandler dropdownitem7.Click, AddressOf menuChoice
        AddHandler dropdownitem8.Click, AddressOf menuChoice
        'dropdownitem
        cms.Show(Me, MousePosition)
    End Sub

    Private Sub menuChoice(sender As Object, e As EventArgs)
        Dim item = CType(sender, ToolStripMenuItem)
        Dim selection = CInt(item.Tag)
        If selection = 14 Then
            Try
                ParserCore.SetStream(InputBox("DIRECT LINK!"))
            Catch ex As Exception
                MsgBox("Sorry the link failed to Stream!", MsgBoxStyle.Exclamation, "Sorry")
            End Try
        End If
        If selection = 13 Then
            Try
                Main.Player1.Visible = True
                Main.Player1.Height = 84
                ' Main.AxVLCPlugin21.Toolbar = False
                ' Main.AxVLCPlugin21.Refresh()
                'Main.AxWindowsMediaPlayer1.uiMode = "none"
                '  Main.AxWindowsMediaPlayer1.Refresh()
            Catch ex As Exception
            End Try
        End If
        If selection = 12 Then
            Try
                Main.Player1.Visible = False
                Main.Player1.Height = 0
                'Main.AxVLCPlugin21.Toolbar = True
                'Main.AxVLCPlugin21.Refresh()
                '  Main.AxWindowsMediaPlayer1.uiMode = "full"
                '  Main.AxWindowsMediaPlayer1.Refresh()
            Catch ex As Exception
            End Try
        End If
        If selection = 10 Then
            Try
                ConsoleCore.CheckCommand("miniview = normal", Main.Console_box)
            Catch ex As Exception
            End Try
        End If
        If selection = 9 Then
            Try
                ConsoleCore.CheckCommand("miniview = br", Main.Console_box)
            Catch ex As Exception
            End Try
        End If
        If selection = 8 Then
            Try
                ConsoleCore.CheckCommand("miniview = bl", Main.Console_box)
            Catch ex As Exception
            End Try
        End If
        If selection = 7 Then
            Try
                ConsoleCore.CheckCommand("miniview = tr", Main.Console_box)
            Catch ex As Exception
            End Try
        End If
        If selection = 6 Then
            Try
                ConsoleCore.CheckCommand("miniview = tl", Main.Console_box)
            Catch ex As Exception
            End Try
        End If
        If selection = 4 Then
            Try
                Evulate.VideoLink4()
            Catch ex As Exception
            End Try
        End If
        If selection = 3 Then
            Try
                Evulate.VideoLink3()
            Catch ex As Exception
            End Try
        End If
        If selection = 2 Then
            Try
                Evulate.VideoLink2()
            Catch ex As Exception
            End Try
        End If
        If selection = 1 Then
            Try
                Evulate.VideoLink1()
            Catch ex As Exception
            End Try
        End If
    End Sub

    
   
    Private Sub WaveForm1_MouseEnter(sender As Object, e As EventArgs) Handles WaveForm1.MouseEnter
        inner = True
    End Sub

    Private Sub WaveForm1_MouseLeave(sender As Object, e As EventArgs) Handles WaveForm1.MouseLeave
        inner = False
    End Sub

    Private Sub FullScreen_MouseEnter(sender As Object, e As EventArgs) Handles FullScreen.MouseEnter
        inner = True
    End Sub

    Private Sub NextEp_MouseEnter(sender As Object, e As EventArgs) Handles NextEp.MouseEnter
        inner = True
    End Sub

    Private Sub PrevEp_MouseEnter(sender As Object, e As EventArgs) Handles PrevEp.MouseEnter
        inner = True
    End Sub

    Private Sub Globe_button_MouseEnter(sender As Object, e As EventArgs) Handles Globe_button.MouseEnter
        inner = True
    End Sub

    Private Sub Down_but_MouseEnter(sender As Object, e As EventArgs) Handles Down_but.MouseEnter
        inner = True
    End Sub

    Private Sub Refresh_Button_MouseEnter(sender As Object, e As EventArgs) Handles Refresh_Button.MouseEnter
        inner = True
    End Sub
End Class
