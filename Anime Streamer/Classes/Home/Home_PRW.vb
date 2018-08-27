Imports System.Net
Imports System.Threading

Public Class Home_PRW
    Public Shared jo As Boolean = False
    Public Shared Done As Boolean = False
    Public Shared Sub LoadInPopularItems()
        Dim wb As New WebClient
        AddHandler wb.DownloadStringCompleted, AddressOf wb_DSC4
        wb.DownloadStringAsync(New Uri("http://www.animetoon.tv/"))
    End Sub
    Public Shared Sub wb_DSC4(sender As Object, e As DownloadStringCompletedEventArgs)
        Try
            If jo = False Then
                AnimeToonHomeSource = e.Result
                PopularItems()
            Else
                AnimeToonHomeSource = e.Result
                JustOne()
            End If
        Catch ex As Exception
            MsgBox(ex.ToString & " ::: Looks like we ran into a problem, something with the popular items on the home screen!", MsgBoxStyle.Critical)
        End Try
    End Sub

    Public Shared AnimeToonHomeSource As String
    Public Shared Sub AnimeToonHomePage()
        Dim wb As New WebClient
        AddHandler wb.DownloadStringCompleted, AddressOf wb2_DSC4
        wb.DownloadStringAsync(New Uri("http://www.animetoon.tv/"))
    End Sub
    Private Shared Sub wb2_DSC4(sender As Object, e As DownloadStringCompletedEventArgs)
        AnimeToonHomeSource = e.Result
    End Sub
    Public Shared Sub JustOne()
        Dim nam As String
        Dim temphtml As String = Filter.getBetween(AnimeToonHomeSource, "<div id=" & Chr(34) & "hup-container" & Chr(34) & ">", "<div class=" & Chr(34) & "clear" & Chr(34) & "></div>")
        Dim lines As String() = temphtml.Split(New String() {" <div class=" & Chr(34) & "hup-item-image" & Chr(34) & ">"}, StringSplitOptions.None)
        Dim i As String = 0
        For Each word In lines
            If word.Contains("<a href=") Then
                Dim namnlink As String = Filter.getBetween(word, "<h3><a href=", "</a></h3>")
                nam = namnlink.Split(">").Last
            End If
        Next
        Notifaction.Add("Looks like you haven't watched any anime yet, some people are watching " & Chr(34) & nam & Chr(34) & ".", NotificationBox.Type.Help, Notifaction.Kind.BottomRight)
        jo = False
    End Sub
    Public Shared Sub PopularItems()
        Dim temphtml As String = Filter.getBetween(AnimeToonHomeSource, "<div id=" & Chr(34) & "hup-container" & Chr(34) & ">", "<div class=" & Chr(34) & "clear" & Chr(34) & "></div>")
        Dim lines As String() = temphtml.Split(New String() {" <div class=" & Chr(34) & "hup-item-image" & Chr(34) & ">"}, StringSplitOptions.None)
        Dim i As String = 0
        For Each word In lines
            If word.Contains("<a href=") Then
                Home.Home_i += 1
                Dim pic As String = Filter.getBetween(word, "src=", " /></a>")
                pic = pic.Replace(Chr(34), "")
                Dim namnlink As String = Filter.getBetween(word, "<h3><a href=", "</a></h3>")
                Dim nam As String = namnlink.Split(">").Last
                Dim lin As String = namnlink.Split(">").First
                lin = lin.Replace(Chr(34), "")
                Dim pop As New DictClass.Item
                pop.URL_LINK = pic
                pop.ShowLink = lin
                pop.Text = nam
                pop.OrderNumber = Home.Home_i
                pop.Type = "People are Watching"
                Home.Dict.Items.Add(pop)
            End If
        Next

        Done = True
        Loading.Refresh()
        LoadingClass.Loading_PRW = True
        LoadingClass.CheckIfDone()
        'Return True
    End Sub
    Public Shared Sub ClearPRW()
    End Sub
End Class
