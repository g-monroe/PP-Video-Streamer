Imports System.Net

Public Class Listings
    Public Shared Done As String = False
    Public Shared Done2 As String = False
    '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    '[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[Good Anime Filter]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]
    '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    Public Shared GAdict As New Dictionary(Of String, String)()
    Public Shared Sub GoodAnime()
        GoodAnimeListingSource = Filter.midReturn(GoodAnimeListingSource, "<ul class=" & Chr(34) & "cat_col" & Chr(34) & " id=" & Chr(34) & "cat-col-1" & Chr(34) & ">", "<div class=" & Chr(34) & "rsidebar" & Chr(34) & ">")
        Dim lines As String() = GoodAnimeListingSource.Split(New String() {"<li class="}, StringSplitOptions.None)
        Dim i As String = 0
        For Each word In lines
            If word.Contains("cat-item") Then
                Dim itemname As String = System.Net.WebUtility.HtmlDecode(Filter.getBetween(word, "View all posts filed under ", Chr(34) & ">"))
                '  Main.AS_Combobox.Items.Add(itemname)
                GAdict.Add(itemname, Filter.getBetween(word, "href=" & Chr(34), Chr(34) & " title="))
            End If
        Next
        Done = True
    End Sub
    '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    '[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[Anime Toon Filter]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]
    '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    Public Shared ATdict As New Dictionary(Of String, String)()
    Public Shared Sub AnimeToon()
        Dim lines As String() = AnimeToonListingsSource.Split(New String() {"<td>"}, StringSplitOptions.None)
        Dim i As String = 0
        For Each word In lines
            If word.Contains("href") Then
                Dim namme As String = Filter.getBetween(word, ">", "</a>")
                namme = namme.Replace("</a", "")
                Dim shwlink As String = Filter.getBetween(word, "href=" & Chr(34), Chr(34) & ">")
                If Not namme = "</tr" Then
                    '  Main.AD_Combobox.Items.Add(namme)
                    namme = System.Net.WebUtility.HtmlDecode(namme)
                    ATdict.Add(namme, shwlink)
                End If
            End If
        Next
        Done2 = True
    End Sub

    'Good Anime Listing
    Public Shared GoodAnimeListingSource As String
    Public Shared Sub GoodAnimeListing()
        Dim wb As New WebClient
        AddHandler wb.DownloadStringCompleted, AddressOf wb_DSC
        wb.DownloadStringAsync(New Uri("http://www.goodanime.net/new-anime-list"))
    End Sub
    Public Shared Sub wb_DSC(sender As Object, e As DownloadStringCompletedEventArgs)
        Try
            GoodAnimeListingSource = e.Result
            'MsgBox(e.Result)
            Listings.GoodAnime()
        Catch ex As Exception
            MsgBox("Anime Listings for Subbed did not load. The reason being is our subbed anime server seems to be down!", MsgBoxStyle.Exclamation, "Well....")
        End Try
    End Sub
    Public Shared AnimeToonListingsSource As String
    Public Shared Sub AnimeToonListings()
        Dim wb As New WebClient
        AddHandler wb.DownloadStringCompleted, AddressOf wb2_DSC
        wb.DownloadStringAsync(New Uri("http://www.animetoon.tv/dubbed-anime"))
    End Sub

    Private Shared Sub wb2_DSC(sender As Object, e As DownloadStringCompletedEventArgs)
        Try
            AnimeToonListingsSource = e.Result
            AnimeToonListingsSource = Filter.getBetween(AnimeToonListingsSource, "<h3 class=" & Chr(34) & "generic" & Chr(34) & ">#</h3>", "<hr class=" & Chr(34) & "separator" & Chr(34) & ">")
            Listings.AnimeToon()
        Catch ex As Exception
            MsgBox("Anime Listings for Dubbed did not load. The reason being is our dubbed anime server seems to be down!", MsgBoxStyle.Exclamation, "Well....")
        End Try
    End Sub
End Class