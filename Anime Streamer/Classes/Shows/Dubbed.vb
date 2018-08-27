Imports System.Text
Imports System.Net

Public Class Dubbed
#Region "WebClients"
    'Anime Toon Detail/ Show Page
    Public Shared AnimeToonDetailSource As String
    Public Shared Sub AnimeToonShowPage()
        Dim wb As New WebClient
        AddHandler wb.DownloadStringCompleted, AddressOf wb2_DSC2
        wb.DownloadStringAsync(New Uri(Globals.ShowLink))
        'Return True
    End Sub

    Private Shared Sub wb2_DSC2(sender As Object, e As DownloadStringCompletedEventArgs)
        AnimeToonDetailSource = e.Result
        AnimeToonDoAll()
    End Sub
    'Anime Toon Episodes/Next Page
    Public Shared AnimeToonEpisodesSource As String
    Public Shared Sub AnimeToonEpisodePage()
        Dim wb As New WebClient
        AddHandler wb.DownloadStringCompleted, AddressOf wb2_DSC3
        wb.DownloadStringAsync(New Uri(AT_NextPageLk))
        'Return True
    End Sub

    Private Shared Sub wb2_DSC3(sender As Object, e As DownloadStringCompletedEventArgs)
        AnimeToonEpisodesSource = e.Result
        AnimeToonNxPgShowDetaiksHtml()
        AnimeToonEpisodes()
    End Sub
    '\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    'Anime Toon Parse
    '\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    Public Shared AnimeToonParseSource As String
    Public Shared Sub AnimeToonParse()
        Dim wb As New WebClient
        AddHandler wb.DownloadStringCompleted, AddressOf wb_DSC5
        wb.DownloadStringAsync(New Uri(Globals.EpisodeLink))
        'Return True
    End Sub
    Private Shared Sub wb_DSC5(sender As Object, e As DownloadStringCompletedEventArgs)
        AnimeToonParseSource = e.Result
        ParserCore.AnimeToonGetVideoLinks()
    End Sub
#End Region
    '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    '[[[[[[[[[[[[[[Anime Toon DETIALS]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]
    '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    '/////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    Public Shared AT_ShowdetailsHTML As String
    Public Shared AT_ShowDesc As String
    Public Shared AT_ShowGenre As String
    Public Shared AT_ShowPic As String
    Public Shared AT_NextPageLk As String
    Public Shared Sub AnimeToonDoAll()
        ConsoleCore.Report(Main.Console_box, "(Subbed Anime.) Do All", Color.Pink)
        Try
            Main.NsListView1.Items.Clear()
        Catch ex As Exception
        End Try
        AnimeToonSetDetailHTML()
        AnimeToonGenres()
        AnimeToonDesc()
        AnimeToonpic()
        AnimeToonEpisodes()
        AnimeToonItemsFavorites()
        AnimeToonItemsHistory()
        'Return True
    End Sub
    Public Shared Sub AnimeToonSetDetailHTML()
        ConsoleCore.Report(Main.Console_box, "(Subbed Anime.)Setting AnimeSetDetails", Color.Pink)
        AT_ShowdetailsHTML = Filter.getBetween(AnimeToonDetailSource, "<div id=" & Chr(34) & "series_info" & Chr(34) & ">", "<div id=" & Chr(34) & "comments" & Chr(34) & ">")
        'Testing.RichTextBox2.Text = AT_ShowdetailsHTML
        ' Return True
    End Sub
    Public Shared Sub AnimeToonItemsFavorites()
        ConsoleCore.Report(Main.Console_box, "(Subbed Anime.)Anime Favorvites", Color.Pink)
        For Each item As NSListView.NSListViewItem In Main.NsListView1.Items
            For Each key In Favorites.Favdict.Keys
                If Favorites.Favdict(key) = item.SubItems(0).Text Or key = item.Text Then
                    item.Favorited = True
                End If
            Next
        Next
    End Sub
    Public Shared Sub AnimeToonItemsHistory()
        ConsoleCore.Report(Main.Console_box, "(Subbed Anime.)Anime History", Color.Pink)
        For Each item As NSListView.NSListViewItem In Main.NsListView1.Items
            For Each key In History.Histdict.Keys
                If History.Histdict(key) = item.SubItems(0).Text Or key = item.Text Then
                    item.Watched = True
                End If
            Next
        Next
    End Sub

    Public Shared Sub AnimeToonGenres()
        AT_ShowGenre = "Genre: "
        ConsoleCore.Report(Main.Console_box, "(Subbed Anime.)Anime Genre", Color.Pink)
        Dim Tempplace As String = Filter.getBetween(AT_ShowdetailsHTML, "<span>Genres:</span>", "</div>")
        Dim linearr2 As String() = Tempplace.Split("<a href")
        For Each line As String In linearr2
            If line.StartsWith("a href") Then
                Dim tempRe As String = Filter.getBetween(line, "a href=", ">")
                AT_ShowGenre += line.Replace(tempRe, "")
            End If
        Next
        AT_ShowGenre = AT_ShowGenre.Replace("a href=>", ",")
        AT_ShowGenre = AT_ShowGenre.Replace(" ,", " ")
        Main.Genre_lbl.Text = AT_ShowGenre
        ' Globals.ShowGenre = ShowGenre
        ' Return True
    End Sub
    Public Shared Sub AnimeToonDesc()
        Try
            AT_ShowDesc = Filter.getBetween(AT_ShowdetailsHTML, "<span>Description:</span>", "</div>")
            AT_ShowDesc = AT_ShowDesc.Replace("<div>", "")
            AT_ShowDesc = Filter.getBetween(AT_ShowDesc, "<span id=" & Chr(34) & "full_notes" & Chr(34) & ">", " <a href=" & Chr(34) & "#" & Chr(34) & ">less</a></span>")
            Dim getBytes = Encoding.Default.GetBytes(AT_ShowDesc)
            Dim getUTF8 = Encoding.UTF8.GetString(getBytes)
            AT_ShowDesc = getUTF8
            Main.Desc.Text = AT_ShowDesc
        Catch ex As Exception
            ConsoleCore.Report(Main.Console_box, "(Subbed Anime.)Anime Description failed to set or get.", Color.Pink)
            Main.Desc.Text = "Description Couldn't be Found."
        End Try
        '  Return True
    End Sub
    Public Shared Sub AnimeToonpic()
        AT_ShowPic = Filter.getBetween(AT_ShowdetailsHTML, "http://www.animetoon.tv/images/", Chr(34) & " id=")
        Main.Pic_pb.LoadAsync("http://www.animetoon.tv/images/" & AT_ShowPic)
        ' Return True
    End Sub
    Public Shared Sub AnimeToonNxPgShowDetaiksHtml()
        AT_ShowdetailsHTML = Filter.getBetween(AnimeToonEpisodesSource, "<div id=" & Chr(34) & "series_info" & Chr(34) & ">", "<div id=" & Chr(34) & "comments" & Chr(34) & ">")
        '  Testing.RichTextBox2.Text = AT_ShowdetailsHTML
        '  Return True
    End Sub
    Public Shared Sub AnimeToonNxPgEp()
        Try
            Dim temp As String = Filter.getBetween(AT_ShowdetailsHTML, "<li><a href=" & Chr(34), Chr(34) & ">Prev</a></li>")
            If Not temp.Contains(">Next</a></li>") Then
                ' MsgBox(temp)
                AT_ShowdetailsHTML = AT_ShowdetailsHTML.Replace("<li><a href=" & Chr(34) & temp & Chr(34) & ">Prev</a></li>", "")
            End If
        Catch ex As Exception
        End Try
        AT_NextPageLk = Filter.getBetween(AT_ShowdetailsHTML, "<li><a href=" & Chr(34), Chr(34) & ">Next</a></li>")
        ' MsgBox(AT_NextPageLk)
        ' Return True
    End Sub

    Public Shared Sub AnimeToonEpisodes()
        If AT_ShowdetailsHTML.Contains(">Next</a></li>") Then
            AnimeToonNxPgEp()
            'Testing.RichTextBox2.Text = AT_NextPageLk
            Dim At_EpisodesHTML As String = Filter.getBetween(AT_ShowdetailsHTML, "<ul>", "</ul>")
            Dim linearr2 As String() = At_EpisodesHTML.Split("<li>")
            For Each line As String In linearr2
                If line.StartsWith("a href") Then
                    line = line.Replace("a href=", "")
                    line = line.Replace(Chr(34), "")
                    Dim link As String = line.Split(">").First
                    Dim namme As String = line.Split(">").Last
                    namme = System.Net.WebUtility.HtmlDecode(namme)
                    Main.NsListView1.AddItem(namme, link)
                End If
            Next
            AnimeToonEpisodePage()
        Else
            Dim At_EpisodesHTML As String = Filter.getBetween(AT_ShowdetailsHTML, "<ul>", "</ul>")
            Dim linearr2 As String() = At_EpisodesHTML.Split("<li>")
            For Each line As String In linearr2
                If line.StartsWith("a href") Then
                    line = line.Replace("a href=", "")
                    line = line.Replace(Chr(34), "")
                    Dim link As String = line.Split(">").First
                    Dim namme As String = line.Split(">").Last
                    namme = System.Net.WebUtility.HtmlDecode(namme)
                    Main.NsListView1.AddItem(namme, link)
                End If
            Next
        End If
        'Return True
    End Sub
    Public Shared Sub AnimeToonNextNPrevEp()
        Globals.NextNPrevService = "AnimeToon"
        Try
            Dim temp As String = Filter.getBetween(AnimeToonParseSource, "<h1 class=" & Chr(34) & "generic" & Chr(34) & ">", "</h1>")
            Globals.EpisodeNameEX = Globals.EpisodeName
            temp = temp.Split("Episode").Last
            temp = temp.Replace("pisode", "")
            Globals.EpisodeName = "Episode" + temp
            Globals.EpisodeName = Globals.EpisodeName.Replace(ControlChars.Lf, "")
            Globals.EpisodeName = Globals.EpisodeName.Replace(ControlChars.CrLf, "")
            Globals.EpisodeName = Globals.EpisodeName.Replace(ControlChars.Tab, "")
            Globals.EpisodeName = Globals.EpisodeName.Replace(vbNewLine, "")
        Catch ex As Exception
            Globals.EpisodeName = ""
        End Try
        If ParserCore.NNPEP.Contains("class=" & Chr(34) & "left") Then
            Dim prev As String = Filter.getBetween(ParserCore.NNPEP, "a href=", " class=" & Chr(34) & "left")
            prev = prev.Replace(Chr(34), "")
            Globals.PreviousEpisodeLink = prev
        Else
            Globals.PreviousEpisodeLink = "None"
        End If
        If ParserCore.NNPEP.Contains("class=" & Chr(34) & "right") Then
            If ParserCore.NNPEP.Contains("class=" & Chr(34) & "left") Then
                Dim temp As String = Filter.getBetween(ParserCore.NNPEP, "class=" & Chr(34) & "left", "right" & Chr(34) & ">")
                Dim nexxt As String = Filter.getBetween(temp, "a href=", " class=")
                nexxt = nexxt.Replace(Chr(34), "")
                Globals.NextEpisodeLink = nexxt
            Else
                Dim nexxt As String = Filter.getBetween(ParserCore.NNPEP, "a href=", " class=" & Chr(34) & "right")
                nexxt = nexxt.Replace(Chr(34), "")
                Globals.NextEpisodeLink = nexxt
            End If
        Else
            Globals.NextEpisodeLink = "None"
        End If
        Main.SoundCloudTopBar1.UserName = Globals.EpisodeName

    End Sub
End Class
