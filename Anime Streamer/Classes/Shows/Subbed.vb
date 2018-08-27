Imports System.Text
Imports System.Net

Public Class Subbed
#Region "WebClients"
    Public Shared GoodAnimeDetailsSource As String
    Public Shared Sub GoodAnimeDetails()

        Dim wb As New WebClient
        AddHandler wb.DownloadStringCompleted, AddressOf wb_DSC2
        wb.DownloadStringAsync(New Uri(Globals.ShowLink))
        ' Return True
    End Sub
    Private Shared Sub wb_DSC2(sender As Object, e As DownloadStringCompletedEventArgs)
        GoodAnimeDetailsSource = e.Result
        GoodAnimeDoAll()

    End Sub
    '\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    'Good Anime Parse
    '\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    Public Shared GoodAnimeParseSource As String
    Public Shared wb As New WebClient
    Public Shared Sub GoodAnimeParse()
        wb = New WebClient
        AddHandler wb.DownloadStringCompleted, AddressOf wb_DSC3
        wb.DownloadStringAsync(New Uri(Globals.EpisodeLink))
        'Return True
    End Sub
    Private Shared Sub wb_DSC3(sender As Object, e As DownloadStringCompletedEventArgs)
        GoodAnimeParseSource = e.Result
        wb.Dispose()
        ' MsgBox(e.Result)
        ParserCore.GoodAnimeGetStreamDetails()
    End Sub
  
#End Region
    '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    '[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[Good Anime Filter]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]
    '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    Public Shared ShowdetailsHTML As String
    Public Shared ShowDesc As String
    Public Shared ShowGenre As String
    Public Shared ShowPic As String
    Public Shared Sub GoodAnimeDoAll()
        GoodAnimeSetDetailHTML()
        GoodAnimeGetNumberPages()
        GoodAnimeGenre()
        GoodAnimeDesc()
        GoodAnimePic()
        GoodAnimeItemsFavorites()
        GoodAnimeItemsHistorys()
    End Sub
    Public Shared Sub GoodAnimeSetDetailHTML()
        ' MsgBox(GoodAnimeDetailsSource)
        ShowdetailsHTML = Filter.midReturn(GoodAnimeDetailsSource, "<div id=" & Chr(34) & "content" & Chr(34) & ">", "<div class=" & Chr(34) & "rsidebar" & Chr(34) & ">")
        ' Return True
    End Sub

    Public Shared Sub GoodAnimeGenre()
        ShowGenre = Filter.midReturn(ShowdetailsHTML, "<p>Â </p>", "<!-- AddThis Button BEGIN -->")
        Try
            ShowGenre = ShowGenre.Replace(vbNewLine, "")
            ShowGenre = ShowGenre.Replace("<br>", "")
            ShowGenre = ShowGenre.Replace("<b>", "")
            ShowGenre = ShowGenre.Replace("</b>", "")
            ShowGenre = ShowGenre.Replace("</div>", "")
            ShowGenre = ShowGenre.Replace("Themes: ", " & Themes: ")
            Main.Genre_lbl.Text = ShowGenre
            ' Globals.ShowGenre = ShowGenre
        Catch ex As Exception
            Main.Genre_lbl.Text = "Genre: None was found."
        End Try
        ' Return True
    End Sub
    Public Shared Sub GoodAnimeDesc()
        Try
            ShowDesc = Filter.midReturn(ShowdetailsHTML, "<b>Plot Summary:</b>", "<p>Â </p>")
            ShowDesc = ShowDesc.Replace(vbNewLine, "")
            Main.Desc.Text = ShowDesc
        Catch ex As Exception
            Try
                ShowDesc = Filter.midReturn(ShowdetailsHTML, "<b>Plot Summary:</b>", "<!-- AddThis Button BEGIN -->")
                ShowDesc = ShowDesc.Replace("</div>", "")
                ShowDesc = ShowDesc.Replace(vbNewLine, "")
                Dim getBytes = Encoding.Default.GetBytes(ShowDesc)
                Dim getUTF8 = Encoding.UTF8.GetString(getBytes)
                ShowDesc = getUTF8
                Main.Desc.Text = ShowDesc
            Catch ex2 As Exception
                Main.Desc.Text = "No description can be found."
            End Try
        End Try
        'Return True
    End Sub
    Public Shared Sub GoodAnimePic()
        'MsgBox(Details.ShowdetailsHTML)
        Try
            ShowPic = Filter.midReturn(ShowdetailsHTML, "<img class=" & Chr(34) & "alignleft" & Chr(34) & " style=" & Chr(34) & "padding-right: 7px" & Chr(34) & " src=" & Chr(34), Chr(34) & " /><b>Plot Summary:</b>")
            'MsgBox(ShowPic)
            If ShowPic.StartsWith("/") Then
                Main.Pic_pb.LoadAsync("http://www.goodanime.net" & ShowPic)
            Else
                Main.Pic_pb.LoadAsync(ShowPic)
            End If

        Catch ex As Exception
            'Not Decided yet
        End Try

        'Return True
    End Sub
    Public Shared Sub GoodAnimeItemsFavorites()
        For Each item As NSListView.NSListViewItem In Main.NsListView1.Items
            For Each key In Favorites.Favdict.Keys
                If Favorites.Favdict(key) = item.SubItems(0).Text Or key = item.Text Then
                    item.Favorited = True
                End If
            Next
        Next
    End Sub
    Public Shared Sub GoodAnimeItemsHistorys()
        For Each item As NSListView.NSListViewItem In Main.NsListView1.Items
            For Each key In History.Histdict.Keys
                If History.Histdict(key) = item.SubItems(0).Text Or key = item.Text Then
                    item.Watched = True
                End If
            Next
        Next
    End Sub
    Public Shared maxnum As String
    Public Shared Sub GoodAnimeGetNumberPages()
        maxnum = 0
        Dim Navigation As String = Filter.midReturn(GoodAnimeDetailsSource, "<div class=" & Chr(34) & "wp-pagenavi" & Chr(34) & ">", "<div class=" & Chr(34) & "rsidebar" & Chr(34) & ">")
        If Not Navigation = "" Then
            If Navigation.Contains("class=" & Chr(34) & "last" & Chr(34)) Then
                Dim linearr2 As String() = Navigation.Split("<a href")
                For Each line As String In linearr2
                    If line.Contains("class=" & Chr(34) & "last" & Chr(34)) Then
                        maxnum = Filter.midReturn(line, "/page/", " class=")
                        maxnum = maxnum.Replace(Chr(34), "")
                    End If
                Next
                GoodAnimeMultiPagedEpisodes()
            Else
                Dim linearr2 As String() = Navigation.Split("<a href")
                For Each line As String In linearr2
                    If line.StartsWith("a href") Then
                        maxnum += 1
                    End If
                Next
                GoodAnimeMultiPagedEpisodes()
            End If
        Else
            GoodAnimeEpisodes()
        End If
        'Return True
    End Sub
    Public Shared Tempsource As String
    Public Shared Sub GoodAnimeMultiPagedEpisodes()
        Try
            Main.NsListView1.Items.Clear()
        Catch ex As Exception
        End Try
        For i As Integer = 1 To maxnum
            Dim wb As New WebClient
            If Not i = 1 Then
                Globals.ShowLink = Globals.ShowLink.Replace(" ", "")
                Dim link As String = Globals.ShowLink & "/page/" & i
                Tempsource = wb.DownloadString(link)
                ShowdetailsHTML = Filter.midReturn(Tempsource, "<iframe src=" & Chr(34) & "//www.facebook.com/plugins/like.php", "<div class=" & Chr(34) & "rsidebar" & Chr(34) & ">")
                Dim EpisodeList As String = Filter.midReturn(ShowdetailsHTML, "<!-- END GAO 120x100 -->", "<div class=" & Chr(34) & "paddingnavi" & Chr(34) & ">")
                Dim linearr2 As String() = EpisodeList.Split("<div class=" & Chr(34) & "postlist" & Chr(34) & ">")
                For Each line As String In linearr2
                    If line.StartsWith("a href") Then
                        Dim EpLink As String = Filter.midReturn(line, "a href=", " rel=")
                        EpLink = EpLink.Replace(Chr(34), "")
                        Dim EpName As String = Filter.midReturn(line, " title=", ">")
                        EpName = EpName.Replace(Chr(34), "")
                        Dim getBytes = Encoding.Default.GetBytes(EpName)
                        Dim getUTF8 = Encoding.UTF8.GetString(getBytes)
                        EpName = getUTF8
                        EpName = System.Net.WebUtility.HtmlDecode(EpName)
                        Main.NsListView1.AddItem(EpName, EpLink)
                    End If
                Next
            Else
                Dim EpisodeList As String = Filter.midReturn(ShowdetailsHTML, "<!-- END GAO 120x100 -->", "<div class=" & Chr(34) & "paddingnavi" & Chr(34) & ">")
                Dim linearr2 As String() = EpisodeList.Split("<div class=" & Chr(34) & "postlist" & Chr(34) & ">")
                For Each line As String In linearr2
                    If line.StartsWith("a href") Then
                        Dim EpLink As String = Filter.midReturn(line, "a href=", " rel=")
                        EpLink = EpLink.Replace(Chr(34), "")
                        Dim EpName As String = Filter.midReturn(line, " title=", ">")
                        EpName = EpName.Replace(Chr(34), "")
                        Dim getBytes = Encoding.Default.GetBytes(EpName)
                        Dim getUTF8 = Encoding.UTF8.GetString(getBytes)
                        EpName = getUTF8
                        EpName = System.Net.WebUtility.HtmlDecode(EpName)
                        Main.NsListView1.AddItem(EpName, EpLink)
                    End If
                Next
            End If

        Next
        ' Return True
    End Sub

    Public Shared Sub GoodAnimeEpisodes()
        Try
            Main.NsListView1.Items.Clear()
        Catch ex As Exception
        End Try
        Dim EpisodeList As String = Filter.getBetween(ShowdetailsHTML, "<!-- END GAO 120x100 -->", "<div class=" & Chr(34) & "paddingnavi" & Chr(34) & ">")
        '    MsgBox(ShowdetailsHTML)
        Dim linearr2 As String() = EpisodeList.Split("<div class=" & Chr(34) & "postlist" & Chr(34) & ">")
        For Each line As String In linearr2
            If line.StartsWith("a href") Then
                Dim EpLink As String = Filter.midReturn(line, "a href=", " rel=")
                EpLink = EpLink.Replace(Chr(34), "")
                Dim EpName As String = Filter.midReturn(line, " title=", ">")
                EpName = EpName.Replace(Chr(34), "")
                Dim getBytes = Encoding.Default.GetBytes(EpName)
                Dim getUTF8 = Encoding.UTF8.GetString(getBytes)
                EpName = getUTF8
                EpName = System.Net.WebUtility.HtmlDecode(EpName)
                Main.NsListView1.AddItem(EpName, EpLink)
            End If
        Next
        'Return True
    End Sub
    Public Shared Sub GoodAnimeNextNPrevEp()
        Try

        
        Dim namme As String = Filter.getBetween(GoodAnimeParseSource, "<div class=" & Chr(34) & "premiumdll" & Chr(34) & ">", "<strong>")
        Try
            Globals.EpisodeName = Filter.getBetween(namme, "<h1>", "</h1>")
            Globals.EpisodeNameEX = Globals.EpisodeName
            Globals.EpisodeName = Globals.EpisodeName.Split("episode").Last
            Globals.EpisodeName = "Episode" + Globals.EpisodeName
        Catch ex As Exception
            Globals.EpisodeName = ""
        End Try
        Globals.NextNPrevService = "GoodAnime"
        If ParserCore.ParsedHTMLDetails.Contains("alignleft") Then
            Dim temp As String = Filter.getBetween(ParserCore.ParsedHTMLDetails, "<div class=" & Chr(34) & "alignleft" & Chr(34) & ">", "</a></div>")
            Try
                Dim prev As String = Filter.getBetween(temp, "href=", ">")
                prev = prev.Replace(Chr(34), "")
                Globals.PreviousEpisodeLink = prev
            Catch ex As Exception
                Globals.PreviousEpisodeLink = "None"
            End Try
        Else
            Globals.PreviousEpisodeLink = "None"
        End If
        If ParserCore.ParsedHTMLDetails.Contains("alignright") Then
            Dim temp As String = Filter.getBetween(ParserCore.ParsedHTMLDetails, "<div class=" & Chr(34) & "alignright" & Chr(34) & ">", "</a></div>")
            Dim nextt As String
            Try
                nextt = Filter.getBetween(temp, "href=", ">")
                nextt = nextt.Replace(Chr(34), "")
                Globals.NextEpisodeLink = nextt
            Catch ex As Exception
                Globals.NextEpisodeLink = "None"
            End Try
        Else
            Globals.NextEpisodeLink = "None"
        End If
            Main.SoundCloudTopBar1.UserName = Globals.EpisodeName
        Catch ex As Exception

        End Try
    End Sub
End Class
