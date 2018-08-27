Imports System.Net
Imports System.Text
Imports System.Threading

Public Class Home_POP
    Public Shared nt As Threading.Thread
    Public Shared PageNum As String = "2"
    Public Shared AnimeToonPopSource As String
    Public Shared Done As Boolean = False
    Public Shared Sub AnimeToonPopPage(Vidlink As String)
        Dim wb As New WebClient
        AddHandler wb.DownloadStringCompleted, AddressOf wb2_DSC5
        wb.DownloadStringAsync(New Uri(Vidlink))

        'Return True
    End Sub

    Private Shared Sub wb2_DSC5(sender As Object, e As DownloadStringCompletedEventArgs)
        Try
            AnimeToonPopSource = e.Result
            PopItems()
        Catch ex As Exception
        End Try
    End Sub
    Public Shared Sub Newpop()
        nt = New Thread(AddressOf PopItems)
        nt.SetApartmentState(ApartmentState.STA)
        nt.IsBackground = True
        nt.Start()
    End Sub
    Public Shared Sub PopItems()

        Dim temphtml As String = Filter.getBetween(AnimeToonPopSource, "<div class=" & Chr(34) & "series_list" & Chr(34) & ">", "</ul>")
        Dim lines As String() = temphtml.Split(New String() {"<li>"}, StringSplitOptions.None)
        Dim i As String = 0
        For Each word In lines
            If word.Contains("<div class=" & Chr(34) & "left_col" & Chr(34) & ">") Then
                Home.Home_i += 1
                Dim pic As String = Filter.getBetween(word, "src=", " width")
                pic = pic.Replace(Chr(34), "")
                Dim namnlink As String = Filter.getBetween(word, "<h3><a href=", "</a></h3>")
                Dim nam As String = namnlink.Split(">").Last
                Dim lin As String = namnlink.Split(">").First
                lin = lin.Replace(Chr(34), "")
                Dim AnType As String = Filter.getBetween(word, "<span class=" & Chr(34) & "type_indic" & Chr(34) & ">", "</span>")
                Dim Desc As String = Filter.getBetween(word, "<div class=" & Chr(34) & "descr" & Chr(34) & ">", "</div>")
                Desc = Desc.Split("[").First
                Dim getBytes = Encoding.Default.GetBytes(Desc)
                Dim getUTF8 = Encoding.UTF8.GetString(getBytes)
                Desc = getUTF8
                Dim upd As New DictClass.Item
                upd.URL_LINK = pic
                upd.Text = nam
                upd.ShowLink = lin
                upd.OrderNumber = Home.Home_i
                upd.Type = "Popular"
                If Not AnType.Contains("Movie") Then
                    Home.Dict.Items.Add(upd)
                End If

            End If
        Next
        Done = True
        Loading.Refresh()
        LoadingClass.Loading_POP = True
        LoadingClass.CheckIfDone()

        'Return True
    End Sub
End Class
