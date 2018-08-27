Imports System.Net
Public Class Home_NRS
    Public Shared GoodAnime_NRS_Source As String
    Public Shared Done As Boolean = False
    Public Shared Sub GetNRSSource(VidLink As String)
        Dim Wb As New WebClient
        AddHandler Wb.DownloadStringCompleted, AddressOf wb_DSC
        Wb.DownloadStringAsync(New Uri(VidLink))
    End Sub

    Private Shared Sub wb_DSC(sender As Object, e As DownloadStringCompletedEventArgs)
        GoodAnime_NRS_Source = e.Result
        LoadInNRSItems()
    End Sub
    Public Shared Sub LoadInNRSItems()
        Dim temp As String = Filter.getBetween(GoodAnime_NRS_Source, "<div id=" & Chr(34) & "content" & Chr(34) & ">", "<div class=" & Chr(34) & "paddingnavi" & Chr(34) & ">")
        Dim lines As String() = temp.Split(New String() {"<div class=" & Chr(34) & "entry" & Chr(34) & ">"}, StringSplitOptions.None)
        For Each line In lines
            If line.Contains("imagelist") Then
                Home.Home_i += 1
                Dim temp2 As String = Filter.getBetween(line, "<div class=" & Chr(34) & "picture" & Chr(34) & ">", "th=")
                Dim link As String = Filter.getBetween(temp2, " href=" & Chr(34), Chr(34) & " title=")
                Dim title As String = Filter.getBetween(temp2, Chr(34) & " title=" & Chr(34), Chr(34) & "><img src=")
                title = title.Split(Chr(34)).First
                Dim pic As String = Filter.getBetween(temp2, "src=" & Chr(34), Chr(34) & " wid")
                Dim NRI As New DictClass.Item
                NRI.Text = title
                NRI.URL_LINK = pic
                NRI.OrderNumber = Home.Home_i
                NRI.ShowLink = link
                NRI.Type = "Coming Soon..."
                Home.Dict.Items.Add(NRI)
            End If
        Next
        Done = True
        Loading.Refresh()
        LoadingClass.Loading_NRS = True
        LoadingClass.CheckIfDone()
    End Sub
    Public Shared Sub NRSClear()

    End Sub
End Class
