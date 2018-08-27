Imports System.IO

Public Class Watching
    Public Shared Dict As New Dictionary(Of String, String)
    Public Shared SubDict As New Dictionary(Of String, String)
    Public Shared Sub SelectItemFilter(ctrl As PositronListBox)
        If ctrl.SelectedItems.Count > 0 Then
            For Each uc As UControl_AnimeSelector In Main.Controls.OfType(Of UControl_AnimeSelector)()
                uc.Toggle1.onoff = False
                Dim temp As String = Dict(ctrl.SelectedItem.ToString)
                If temp.Contains("goodanime") Then
                    Globals.ShowLink = temp
                    Globals.RecommendType = "Subbed"
                    Main.Main_TabControl.SelectedIndex = 2
                    Main.GroupRecommendations_GB.Visible = False
                    Main.prog.Visible = False
                    Main.progtext.Visible = False
                    Main.TabSelector1.Refresh()
                    Main.Name_lbl.Text = ctrl.SelectedItem.ToString
                    Main.Name_lbl.Refresh()
                    Main.Type_lbl.Text = "Subbed"
                    Main.Type_lbl.Refresh()
                    Subbed.GoodAnimeDetails()
                    Main.PanelBox3.Visible = True
                ElseIf temp.Contains("animetoon") Then
                    Globals.ShowLink = temp
                    Main.Name_lbl.Text = ctrl.SelectedItem.ToString
                    Main.Name_lbl.Refresh()
                    Main.Type_lbl.Text = "Dubbed"
                    Main.Type_lbl.Refresh()
                    Main.Main_TabControl.SelectedIndex = 2
                    Main.GroupRecommendations_GB.Visible = False
                    Main.prog.Visible = False
                    Main.progtext.Visible = False
                    Main.TabSelector1.Refresh()
                    Dubbed.AnimeToonShowPage()
                    Main.PanelBox3.Visible = True
                End If
            Next
        End If
    End Sub
    Public Shared Sub LoadWat()
        RemoveListitems()
        If File.Exists(My.Computer.FileSystem.SpecialDirectories.Temp & "\AnimeStreamer\wat") Then
            Dim objreader As New StreamReader(My.Computer.FileSystem.SpecialDirectories.Temp & "\AnimeStreamer\wat")
            Do While objreader.Peek() <> -1
                Try
                    Dim line As String

                    line = objreader.ReadLine() & vbNewLine

                    If line.Contains("~^~") Then
                        Dim lines As String() = line.Split("~^~")
                        Dim i As Integer = 0
                        Dim namme As String = ""
                        Dim link As String = ""
                        Dim Type As String = ""
                        For Each liness As String In lines
                            If Not liness.Contains("^") Or liness Is Nothing Then
                                i += 1
                                If i = 1 Then
                                    namme = liness
                                End If
                                If i = 2 Then
                                    link = liness
                                End If
                                If i = 3 Then
                                    Type = liness
                                End If
                            End If
                        Next
                        Dict.Add(namme, link)
                        Try
                            SubDict.Add(Type, link)
                        Catch ex As Exception
                            Dim rnd As New Random
                            SubDict.Add(Type & rnd.Next(1, 99999999), link)
                        End Try
                    End If
                Catch ex As Exception
                    RefreshLists()
                End Try
            Loop
            For Each key As String In Dict.Keys
                For Each key2 As String In SubDict.Keys
                    If Dict(key) = SubDict(key2) Then
                        If key2.Contains("Monday") Then
                            Main.Monday_LB.Items.Add(key)
                            Main.Monday_LB.Refresh()
                        End If
                        If key2.Contains("Tuesday") Then
                            Main.Tuesday_LB.Items.Add(key)
                            Main.Tuesday_LB.Refresh()
                        End If
                        If key2.Contains("Wednesday") Then
                            Main.Wednesday_LB.Items.Add(key)
                            Main.Wednesday_LB.Refresh()
                        End If
                        If key2.Contains("Thursday") Then
                            Main.Thursday_LB.Items.Add(key)
                            Main.Thursday_LB.Refresh()
                        End If
                        If key2.Contains("Friday") Then
                            Main.Friday_LB.Items.Add(key)
                            Main.Friday_LB.Refresh()
                        End If
                        If key2.Contains("Saturday") Then
                            Main.Saturday_LB.Items.Add(key)
                            Main.Saturday_LB.Refresh()
                        End If
                        If key2.Contains("Sunday") Then
                            Main.Sunday_LB.Items.Add(key)
                            Main.Sunday_LB.Refresh()
                        End If
                        If key2.Contains("QuickAdded") Then
                            Main.QuickAdded_LB.Items.Add(key)
                            Main.QuickAdded_LB.Refresh()
                        End If
                    End If
                Next
            Next
        Else
            File.Create(My.Computer.FileSystem.SpecialDirectories.Temp & "\AnimeStreamer\wat")
        End If
    End Sub
    Public Shared Sub AddWat(namme As String, link As String, Type As String)
        ConsoleCore.Report(Main.Console_box, "Adding " & namme & " to the Watching list.", Color.Yellow)
        Try
            If Not Main.prog.Visible = True Then
                Dict.Add(namme, link)
                Try
                    SubDict.Add(Type, link)
                Catch ex As Exception
                    Dim rnd As New Random
                    SubDict.Add(Type & rnd.Next(1, 99999999), link)
                End Try
                Savewat()
                LoadWat()
                RefreshLists()
            End If
        Catch ex As Exception
            ConsoleCore.Report(Main.Console_box, "Failed to add " & namme & " to Watching list.", Color.Red)
        End Try
    End Sub
    Public Shared Sub RemoveWat(namme As String, link As String, Type As String)
        ConsoleCore.Report(Main.Console_box, "Removing " & namme & " from the Watching list.", Color.Yellow)
        Try
            For Each key As KeyValuePair(Of String, String) In Dict
                If Dict(key.Key) = link Then
                    Dict.Remove(key.Key)
                End If
            Next
        Catch ex As Exception
        End Try
        Try
            For Each key As KeyValuePair(Of String, String) In SubDict
                If SubDict(key.Key) = link Then
                    SubDict.Remove(key.Key)
                End If
            Next
        Catch ex As Exception
        End Try
        'Here
        Savewat()
        LoadWat()
        RefreshLists()
        ' Catch ex As Exception
        '   ConsoleCore.Report(Main.Console_box, "Failed to remove " & namme & " from Watching list.", Color.Red)
        '  End Try
    End Sub
    Public Shared Sub RefreshLists()
        Main.Monday_LB.Refresh()
        Main.Tuesday_LB.Refresh()
        Main.Wednesday_LB.Refresh()
        Main.Thursday_LB.Refresh()
        Main.Friday_LB.Refresh()
        Main.Saturday_LB.Refresh()
        Main.Sunday_LB.Refresh()
        Main.QuickAdded_LB.Refresh()
    End Sub
    Public Shared Sub RemoveListitems()
        Try
            Main.Monday_LB.Items.Clear()
        Catch ex As Exception
        End Try
        Try
            Main.Tuesday_LB.Items.Clear()
        Catch ex As Exception
        End Try
        Try
            Main.Wednesday_LB.Items.Clear()
        Catch ex As Exception
        End Try
        Try
            Main.Thursday_LB.Items.Clear()
        Catch ex As Exception
        End Try
        Try
            Main.Friday_LB.Items.Clear()
        Catch ex As Exception
        End Try
        Try
            Main.Saturday_LB.Items.Clear()
        Catch ex As Exception
        End Try
        Try
            Main.Sunday_LB.Items.Clear()
        Catch ex As Exception
        End Try
        Try
            Main.QuickAdded_LB.Items.Clear()
        Catch ex As Exception
        End Try
    End Sub
    Public Shared Sub Savewat()
        ConsoleCore.Report(Main.Console_box, "Saving Watching to file.", Color.Yellow)
        If File.Exists(My.Computer.FileSystem.SpecialDirectories.Temp & "\AnimeStreamer\wat") = True Then
            Dim myfile As String = My.Computer.FileSystem.SpecialDirectories.Temp & "\AnimeStreamer\wat"
            File.Delete(myfile)
            Dim mywriter As New IO.StreamWriter(myfile)
            For Each key As String In Dict.Keys
                For Each key2 As String In SubDict.Keys
                    If Dict(key) = SubDict(key2) Then
                        key2 = key2.Replace(ControlChars.Lf, "")
                        key2 = key2.Replace(ControlChars.CrLf, "")
                        key2 = key2.Replace(ControlChars.Tab, "")
                        key2 = key2.Replace(vbNewLine, "")
                        key2.Replace("      ", "")
                        mywriter.WriteLine(key & "~^~" & Dict(key) & "~^~" & key2)
                    End If
                Next
            Next
            mywriter.Close()

        End If
    End Sub
End Class
