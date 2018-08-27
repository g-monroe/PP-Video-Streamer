Imports System.Net
Imports System.Text

Public Class Encycl
    Public Shared dict As New Dictionary(Of String, String)
    Public Shared Function getBetween(input As String, before As String, after As String) As String
        Return System.Text.RegularExpressions.Regex.Split(System.Text.RegularExpressions.Regex.Split(input, before)(1), after)(0)
    End Function
    Public Shared Sub GetSource()
        Dim wb As New WebClient
        AddHandler wb.DownloadStringCompleted, AddressOf Wb_DSC
        wb.DownloadStringAsync(New Uri("http://www.animeseason.com/anime-list/"))
    End Sub
    Public Shared str As String
    Public Shared Sub Wb_DSC(sender As Object, e As DownloadStringCompletedEventArgs)
        Try
            str = e.Result
            Filter()
        Catch ex As Exception
        End Try
    End Sub
    Public Shared Sub Filter()
        Dim temp As String = getBetween(str, "<div class=" & Chr(34) & "content_bloc" & Chr(34) & ">", "<iframe")
        Dim lines As String() = temp.Split("<li>")
        For Each line In lines
            If line.StartsWith("a href=" & Chr(34) & "/") Then
                line = line.Replace("a href=" & Chr(34), "")
                line = line.Replace(Chr(34), "")
                Dim namme As String = line.Split(">").Last
                Dim link As String = "http://www.animeseason.com" + line.Split(">").First
                '  Main.FA_Combobox.Items.Add(namme)
                Try
                    dict.Add(namme, link)
                Catch ex As Exception
                End Try
            End If
        Next
    End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs)
        Filter()
    End Sub

    Public Shared Sub GetDetails(link As String)
        Dim wb As New WebClient
        AddHandler wb.DownloadStringCompleted, AddressOf Wb_DSC2
        wb.DownloadStringAsync(New Uri(link))
    End Sub

    Public Shared Sub Wb_DSC2(sender As Object, e As DownloadStringCompletedEventArgs)
        '//Filter
        Dim str2 As String = e.Result
        str2 = getBetween(str2, "<div id=" & Chr(34) & "content" & Chr(34) & ">", "<iframe")


        '//Prec
        Dim prec As String = getBetween(str2, "<div id=" & Chr(34) & "avg_rating" & Chr(34) & " title=", "%")
        Try
            prec = prec.Replace(Chr(34), "")
        Catch ex As Exception
        End Try
        Try
            Main.prog.Value = prec
            Main.progtext.Text = "Like:" + prec + "%"
            Main.progtext.Refresh()
        Catch ex As Exception
        End Try
        '//Desc
        Dim desc As String = getBetween(str2, "<p class=" & Chr(34) & "has_layout" & Chr(34) & ">", "</p>")
        Dim getBytes = Encoding.Default.GetBytes(desc)
        Dim getUTF8 = Encoding.UTF8.GetString(getBytes)
        Main.Desc.Text = getUTF8
        '//Pic
        Dim Pic As String = getBetween(str2, "<img src=" & Chr(34), Chr(34) & " id=" & Chr(34) & "poster" & Chr(34))
        Main.Pic_pb.LoadAsync(Pic)
        '//Genre
        Try
            Dim Gen As String = getBetween(str2, "<dd class=" & Chr(34) & "cat has_layout" & Chr(34) & ">", "</dd>")
            Dim lines As String() = Gen.Split("<a href=")
            Main.Genre_lbl.Text = ""
            For Each line In lines
                If line.Contains(Chr(34) & "/") Then
                    line = line.Replace("a href=" & Chr(34), "")
                    line = line.Replace(Chr(34), "")
                    Dim namme As String = line.Split(">").Last + ", "
                    Main.Genre_lbl.Text += namme
                End If
            Next
            Main.Genre_lbl.Text = Main.Genre_lbl.Text.Substring(0, Main.Genre_lbl.Text.Length - 2)
        Catch ex As Exception
            Main.Genre_lbl.Text = "Failed To Load."
        End Try
        '//Episodes
        Try
            '     ListView1.Items.Clear()
        Catch ex As Exception
        End Try
        Dim itms As String = getBetween(str2, "<div id=" & Chr(34) & "ratings" & Chr(34) & " class=" & Chr(34) & "feature_box display_block" & Chr(34) & ">", "<h3>Recent Must Watch Episodes</h3>")
        Dim temp As String = getBetween(itms, "<p class=" & Chr(34) & "nospace" & Chr(34) & ">", "<table>")
        itms = itms.Replace(temp, "")
        Dim lines2 As String() = itms.Split("<tr ")
        For Each line In lines2
            If line.Contains("a href=" & Chr(34) & "/") Then
                Dim txt As String = line.Split(">").Last
                Dim num As String
                If Not Char.IsNumber(txt) = True Then
                    line = line.Replace("a href=" & Chr(34), "")
                    line = line.Replace(Chr(34), "")
                    Dim namme As String = line.Split(">").Last
                    Dim link As String = "http://www.animeseason.com" + line.Split(">").First
                    Try
                        ' Dim objitm As ListViewItem = ListView1.Items.Add(num)
                        ' objitm.SubItems.Add(namme)
                        ' objitm.SubItems.Add(link)
                    Catch ex As Exception
                        '  Dim objitm As ListViewItem = ListView1.Items.Add("N/A")
                        '  objitm.SubItems.Add(namme)
                        ' objitm.SubItems.Add(link)
                    End Try
                Else
                    num = line.Split(">").Last
                End If
            End If
        Next
        '//Name
        Dim namme2 As String = getBetween(str2, "<dt>Title:</dt>", "</dd>")
        namme2 = namme2.Replace("<dd class=" & Chr(34) & "has_layout" & Chr(34) & ">", "")
        Main.Name_lbl.Text = namme2
        Main.Name_lbl.Refresh()
        'For Each item In Main.FA_Combobox.Items
        '    If item.ToString = namme2 Then
        '        Main.FA_Combobox.SelectedItem = item
        '    End If
        'Next
        ''//recommendations
        For Each con As UControl_Recommendation In Main.GroupRecommendations_GB.Controls.OfType(Of UControl_Recommendation)()
            con.Dispose()
        Next
        Try
            Dim rec As String = getBetween(str2, "<div id=" & Chr(34) & "rec_scroll" & Chr(34) & ">", "<div id=" & Chr(34) & "rec_container" & Chr(34) & ">")
            Dim words = rec.Split({"<tr><td>", "<tr class=" & Chr(34) & "even" & Chr(34) & ">"}, StringSplitOptions.None)
            Dim words2 = rec.Split({"<tr class="}, StringSplitOptions.None)
            For Each line2 In words
                If line2.StartsWith("<img") Then
                    Dim pic2 As String = getBetween(line2, "<img src=" & Chr(34), Chr(34) & " alt=")
                    Dim namme As String = getBetween(line2, " alt=" & Chr(34), Chr(34) & " /></td>")
                    Dim type As String = getBetween(line2, "</td><td class=" & Chr(34) & "text_center" & Chr(34) & ">", "</td></tr>")
                    Dim votes As String = line2.Replace("<td class=" & Chr(34) & "text_center" & Chr(34) & ">" & type, "")
                    votes = getBetween(votes, "<td class=" & Chr(34) & "text_center" & Chr(34) & ">", "</td></tr>")

                    Dim link As String = getBetween(line2, "<a href=" & Chr(34), Chr(34) & ">")
                    ' MsgBox(pic2 & "::" & namme & "::" & votes & "::" & link)
                    Dim con As New UControl_Recommendation
                    con.Dock = DockStyle.Top
                    con.PictureBox1.LoadAsync(pic2)
                    con.TextBox1.Text = namme
                    con.TextBox2.Text = type + vbNewLine + votes
                    con.link = "http://www.animeseason.com" + link
                    Main.GroupRecommendations_GB.Controls.Add(con)
                End If
            Next
        Catch ex As Exception

        End Try



        'Dim frm As New Form
        'frm.Size = New Size(200, 200)
        'Dim txtbox As New TextBox
        'txtbox.Text = temp
        'frm.Controls.Add(txtbox)
        'txtbox.Dock = DockStyle.Fill
        'txtbox.Multiline = True
        'frm.ShowDialog()
    End Sub

    Sub getplayersource(link As String)
        Dim wb As New WebClient
        AddHandler wb.DownloadStringCompleted, AddressOf Wb_DSC3
        wb.DownloadStringAsync(New Uri(link))
    End Sub

    Private Sub Wb_DSC3(sender As Object, e As DownloadStringCompletedEventArgs)
        Dim txt As String = e.Result
    End Sub
    Public Shared GenDict As New Dictionary(Of String, String)
    Public Shared Sub Additemstodict()
        Try
            GenDict.Clear()
            Main.Genre_CB.Items.Clear()
        Catch ex As Exception
        End Try
        GenDict.Add("Action", "http://www.animeseason.com/anime-list/categories/adventure/")
        GenDict.Add("Adventure", "http://www.animeseason.com/anime-list/categories/action/")
        GenDict.Add("Bishounen", "http://www.animeseason.com/anime-list/categories/bishounen/")
        GenDict.Add("Comedy", "http://www.animeseason.com/anime-list/categories/comedy/")
        GenDict.Add("Demons", "http://www.animeseason.com/anime-list/categories/demons/")
        GenDict.Add("Drama", "http://www.animeseason.com/anime-list/categories/drama/")
        GenDict.Add("Ecchi", "http://www.animeseason.com/anime-list/categories/ecchi/")
        GenDict.Add("Fantasy", "http://www.animeseason.com/anime-list/categories/fantasy/")
        GenDict.Add("Harem", "http://www.animeseason.com/anime-list/categories/harem/")
        GenDict.Add("Horror", "http://www.animeseason.com/anime-list/categories/horror/")
        GenDict.Add("Josei", "http://www.animeseason.com/anime-list/categories/josei/")
        GenDict.Add("Magic", "http://www.animeseason.com/anime-list/categories/magic/")
        GenDict.Add("Mahou Shoujo", "http://www.animeseason.com/anime-list/categories/mahou-shoujo/")
        GenDict.Add("Martial Arts", "http://www.animeseason.com/anime-list/categories/martial-arts/")
        GenDict.Add("Mecha", "http://www.animeseason.com/anime-list/categories/mecha/")
        GenDict.Add("Music", "http://www.animeseason.com/anime-list/categories/music/")
        GenDict.Add("Mystery", "http://www.animeseason.com/anime-list/categories/mystery/")
        GenDict.Add("Ninja", "http://www.animeseason.com/anime-list/categories/ninja/")
        GenDict.Add("Parody", "http://www.animeseason.com/anime-list/categories/parody/")
        GenDict.Add("Psychological", "http://www.animeseason.com/anime-list/categories/psychological/")
        GenDict.Add("Reverse Harem", "http://www.animeseason.com/anime-list/categories/reverse-harem/")
        GenDict.Add("Romance", "http://www.animeseason.com/anime-list/categories/romance/")
        GenDict.Add("Samurai", "http://www.animeseason.com/anime-list/categories/samurai/")
        GenDict.Add("School Life", "http://www.animeseason.com/anime-list/categories/school-life/")
        GenDict.Add("Science Fiction", "http://www.animeseason.com/anime-list/categories/science-fiction/")
        GenDict.Add("Seinen", "http://www.animeseason.com/anime-list/categories/seinen/")
        GenDict.Add("Shoujo", "http://www.animeseason.com/anime-list/categories/shoujo/")
        GenDict.Add("Shoujo Ai", "http://www.animeseason.com/anime-list/categories/shoujo-ai/")
        GenDict.Add("Shounen", "http://www.animeseason.com/anime-list/categories/shounen/")
        GenDict.Add("Shounen Ai", "http://www.animeseason.com/anime-list/categories/shounen-ai/")
        GenDict.Add("Slapstick", "http://www.animeseason.com/anime-list/categories/slapstick/")
        GenDict.Add("Slice of Life", "http://www.animeseason.com/anime-list/categories/slice-of-life/")
        GenDict.Add("Sports", "http://www.animeseason.com/anime-list/categories/sports/")
        GenDict.Add("Supernatural", "http://www.animeseason.com/anime-list/categories/supernatural/")
        GenDict.Add("Thriller", "http://www.animeseason.com/anime-list/categories/thriller/")
        GenDict.Add("Tragedy", "http://www.animeseason.com/anime-list/categories/tragedy/")
        GenDict.Add("Vampire", "http://www.animeseason.com/anime-list/categories/vampire/")
        For Each key In GenDict.Keys
            Main.Genre_CB.Items.Add(key)
        Next
    End Sub
End Class
