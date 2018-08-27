Imports System.Net

Public Class Recommendations
    Public Shared watched As String
    Public Shared once As Boolean = False
    Public Shared Max As Integer = 5
    Public Shared IndexC As Integer = 0
    Public Shared Sub GetDetails(link As String)
        Dim wb As New WebClient
        AddHandler wb.DownloadStringCompleted, AddressOf Wb_DSC2
        wb.DownloadStringAsync(New Uri(link))
    End Sub
    Public Shared Sub FindWatchedAnime()
        If IndexC = Max Then
            If Settings.LiveRecommends = True Then
                Dim i As Integer = 0
                Dim rnd As New Random
                For Each key As String In History.Histdict.Keys
                    i += 1
                Next
                Dim i2 As Integer = rnd.Next(0, i + 1)
                Dim i3 As Integer = 0
                For Each key As String In History.Histdict.Keys
                    i3 += 1
                    If i2 = i3 Then
                        Dim nam As String
                        nam = key.ToLower
                        nam = nam.Replace("-", " ")
                        Dim lines As String() = nam.Split(New String() {" "}, StringSplitOptions.None)
                        For Each line In lines
                            If once = False Then
                                For Each key2 As String In Encycl.dict.Keys
                                    If key2.ToLower.Contains(line) Then
                                        If once = False Then
                                            watched = key
                                            GetDetails(Encycl.dict(key2))
                                            once = True
                                        End If
                                    End If
                                Next
                            End If
                        Next
                        'nam = key.ToLower
                        'nam = nam.Replace("-", "")
                        'nam = nam.Split("episode").First
                        ' Notifaction.Add("You watched " & Chr(34) & key & Chr(34) & ". " & nam, NotificationBox.Type.Help, Notifaction.Kind.BottomRight)
                    End If
                Next
                If i = 0 Then
                    Home_PRW.jo = True
                    Home_PRW.LoadInPopularItems()
                End If
            End If
            IndexC = 0
        Else
            IndexC += 1
        End If
    End Sub
    Public Shared tempdict As New Dictionary(Of String, Integer)
    Public Shared Sub Wb_DSC2(sender As Object, e As DownloadStringCompletedEventArgs)
        Try
            tempdict.Clear()
        Catch ex As Exception
        End Try
        Dim str2 As String = e.Result
        str2 = Filter.getBetween(str2, "<div id=" & Chr(34) & "content" & Chr(34) & ">", "<iframe")
        Try
            Dim rec As String = Filter.getBetween(str2, "<div id=" & Chr(34) & "rec_scroll" & Chr(34) & ">", "<div id=" & Chr(34) & "rec_container" & Chr(34) & ">")
            Dim words = rec.Split({"<tr><td>", "<tr class=" & Chr(34) & "even" & Chr(34) & ">"}, StringSplitOptions.None)
            Dim words2 = rec.Split({"<tr class="}, StringSplitOptions.None)
            For Each line2 In words
                If line2.StartsWith("<img") Then
                    Dim pic2 As String = Filter.getBetween(line2, "<img src=" & Chr(34), Chr(34) & " alt=")
                    Dim namme As String = Filter.getBetween(line2, " alt=" & Chr(34), Chr(34) & " /></td>")
                    Dim type As String = Filter.getBetween(line2, "</td><td class=" & Chr(34) & "text_center" & Chr(34) & ">", "</td></tr>")
                    Dim votes As String = line2.Replace("<td class=" & Chr(34) & "text_center" & Chr(34) & ">" & type, "")
                    votes = Filter.getBetween(votes, "<td class=" & Chr(34) & "text_center" & Chr(34) & ">", "</td></tr>")

                    Dim link As String = Filter.getBetween(line2, "<a href=" & Chr(34), Chr(34) & ">")
                    ' MsgBox(pic2 & "::" & namme & "::" & votes & "::" & link)
                    tempdict.Add(namme, votes)
                End If
            Next
        Catch ex As Exception

        End Try
        Dim i As Integer = 0
        Dim rnd As New Random
        For Each key As String In tempdict.Keys
            i += 1
        Next
        Dim i2 As Integer = rnd.Next(0, i + 1)
        Dim i3 As Integer = 0
        For Each key As String In tempdict.Keys
            i3 += 1
            If i2 = i3 Then
                Notifaction.Add("You watched " & Chr(34) & watched & Chr(34) & ". How about watching " & Chr(34) & key & Chr(34) & ".", NotificationBox.Type.Notice, Notifaction.Kind.BottomRight)
            End If
        Next
        once = False
    End Sub


End Class
