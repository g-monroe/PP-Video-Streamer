Imports System.Net

Public Class Home_OGS
    Public Shared AnimeToonHomeSource As String
    Public Shared Done As Boolean = False
    Public Shared Sub AnimeToonHomePage()
        Dim wb As New WebClient
        AddHandler wb.DownloadStringCompleted, AddressOf wb2_DSC4
        wb.DownloadStringAsync(New Uri("http://www.animetoon.tv/"))
        'Dim request As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create("http://www.animetoon.tv/")
        'Dim response As System.Net.HttpWebResponse = request.GetResponse()
        'Dim sr As System.IO.StreamReader = New System.IO.StreamReader(response.GetResponseStream())
        'GetSource.AnimeToonHomeSource = sr.ReadToEnd()
        'Return True
    End Sub

    Private Shared Sub wb2_DSC4(sender As Object, e As DownloadStringCompletedEventArgs)
        Try
            AnimeToonHomeSource = e.Result
            OngoingItems()
        Catch ex As Exception
        End Try
    End Sub
    Public Shared Sub OngoingItems()
        Dim temphtml As String = Filter.getBetween(AnimeToonHomeSource, "<div id=" & Chr(34) & "popular_series" & Chr(34) & ">", "<div id=" & Chr(34) & "home_sidebar" & Chr(34) & ">")
        Dim lines As String() = temphtml.Split(New String() {"<li>"}, StringSplitOptions.None)
        Dim i As String = 0
        For Each word In lines
            If word.Contains("<div class=" & Chr(34) & "slink" & Chr(34) & ">") Then
                Home.Home_i += 1
                Dim pic As String = Filter.getBetween(word, "src=", " width")
                pic = pic.Replace(Chr(34), "")
                Dim namnlink As String = Filter.getBetween(word, "<div class=" & Chr(34) & "slink" & Chr(34) & ">", "</a>")
                namnlink = namnlink.Replace("<a href=", "")
                namnlink = namnlink.Replace(Chr(34), "")
                Dim nam As String = namnlink.Split(">").Last
                Dim lin As String = namnlink.Split(">").First
                lin = lin.Replace(Chr(34), "")
                Dim ong As New DictClass.Item
                ong.URL_LINK = pic
                ong.Text = nam
                ong.Showlink = lin
                ong.OrderNumber = Home.Home_i
                ong.Type = "Ongoing Series"
                Home.Dict.Items.Add(ong)
            End If
        Next
        Done = True
        Loading.Refresh()
        LoadingClass.Loading_OGS = True
        LoadingClass.CheckIfDone()

        'Dim lbl As New TagLabel
        '  lbl.Text = "Ongoing Series"
        ' lbl.Dock = DockStyle.Top
        ' Main.OnGoingTabcontrol.TabPages(0).Controls.Add(lbl)
        'Return True
    End Sub
    Public Shared Sub ClearOGS()
    End Sub
End Class
