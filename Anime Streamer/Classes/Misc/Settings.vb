Imports System.IO

Public Class Settings
    Public Shared LoadHome As Boolean = True
    Public Shared LoadFavorites As Boolean = True
    Public Shared LoadHistory As Boolean = True
    Public Shared LoadWatching As Boolean = True
    Public Shared Notifactions As Boolean = True
    Public Shared LiveRecommends As Boolean = True
    Public Shared ShowTimeEvents As Boolean = True
    Public Shared Sub LoadSettings()
        If File.Exists(My.Computer.FileSystem.SpecialDirectories.Temp & "\AnimeStreamer\set") Then
            Dim objreader As New StreamReader(My.Computer.FileSystem.SpecialDirectories.Temp & "\AnimeStreamer\set")
            Dim lines As String() = objreader.ReadToEnd.ToString.Split(vbNewLine)
            For Each line In lines
                If line.Contains("=") Then
                    If line.Contains("LoadHome") Then
                        Dim temp As String = line.Split("=").Last
                        If temp = "True" Then
                            LoadHome = True
                        Else
                            LoadHome = False
                            Home.ClearControls()
                        End If
                    End If
                    If line.Contains("LoadFavorites") Then
                        Dim temp As String = line.Split("=").Last
                        If temp = "True" Then
                            LoadFavorites = True
                        Else
                            LoadFavorites = False
                        End If
                    End If
                    If line.Contains("LiveRecommends") Then
                        Dim temp As String = line.Split("=").Last
                        If temp = "True" Then
                            LiveRecommends = True
                        Else
                            LiveRecommends = False
                        End If
                    End If
                    If line.Contains("ShowTimeEvents") Then
                        Dim temp As String = line.Split("=").Last
                        If temp = "True" Then
                            ShowTimeEvents = True
                        Else
                            ShowTimeEvents = False
                        End If
                    End If
                    If line.Contains("LoadHistory") Then
                        Dim temp As String = line.Split("=").Last
                        If temp = "True" Then
                            LoadHistory = True
                        Else
                            LoadHistory = False
                        End If
                    End If
                    If line.Contains("Notifactions") Then
                        Dim temp As String = line.Split("=").Last
                        If temp = "True" Then
                            Notifactions = True
                        Else
                            Notifactions = False
                        End If
                    End If
                    If line.Contains("LoadWatching") Then
                        Dim temp As String = line.Split("=").Last
                        If temp = "True" Then
                            LoadWatching = True
                        Else
                            LoadWatching = False
                            For Each Con As Simple_Groupbox In Main.KoboTabControlS2.TabPages(2).Controls.OfType(Of Simple_Groupbox)()
                                Con.Visible = False
                                Con.Dispose()
                            Next
                            For Each Con As Simple_Groupbox In Main.KoboTabControlS2.TabPages(2).Controls.OfType(Of Simple_Groupbox)()
                                Con.Visible = False
                                Con.Dispose()
                            Next
                            Try
                                Main.KoboTabControlS2.TabPages.Remove(Main.KoboTabControlS2.TabPages(2))
                            Catch ex As Exception
                            End Try
                        End If
                    End If
                End If
            Next
        Else
            '  File.Create(My.Computer.FileSystem.SpecialDirectories.Temp & "\AnimeStreamer"\set")
            Dim objwriter As New StreamWriter(My.Computer.FileSystem.SpecialDirectories.Temp & "\AnimeStreamer\set")
            objwriter.Write("LoadHome=True" & vbNewLine)
            objwriter.Write("LoadFavorites=True" & vbNewLine)
            objwriter.Write("LoadHistory=True" & vbNewLine)
            objwriter.Write("LoadWatching=True" & vbNewLine)
            objwriter.Write("Notifactions=" & Notifactions.ToString & vbNewLine)
            objwriter.Write("LiveRecommends=" & LiveRecommends.ToString & vbNewLine)
            objwriter.Write("ShowTimeEvents=" & ShowTimeEvents.ToString & vbNewLine)
            objwriter.Close()
        End If
    End Sub
    Public Shared Sub SaveSettings(Sett As String, Onoff As Boolean)
        If Sett = "LoadHome" Then
            If Onoff = True Then
                LoadHome = True
            Else
                LoadHome = False
            End If
        End If
        If Sett = "LoadFavorites" Then
            If Onoff = True Then
                LoadFavorites = True
            Else
                LoadFavorites = False
            End If
        End If
        If Sett = "LiveRecommends" Then
            If Onoff = True Then
                LiveRecommends = True
            Else
                LiveRecommends = False
            End If
        End If
        If Sett = "ShowTimeEvents" Then
            If Onoff = True Then
                ShowTimeEvents = True
            Else
                ShowTimeEvents = False
            End If
        End If
        If Sett = "LoadHistory" Then
            If Onoff = True Then
                LoadHistory = True
            Else
                LoadHistory = False
            End If
        End If
        If Sett = "LoadWatching" Then
            If Onoff = True Then
                LoadWatching = True
            Else
                LoadWatching = False
            End If
        End If
        If Sett = "Notifactions" Then
            If Onoff = True Then
                Notifactions = True
            Else
                Notifactions = False
            End If
        End If
        Try
            If File.Exists(My.Computer.FileSystem.SpecialDirectories.Temp & "\AnimeStreamer\set") Then
                ConsoleCore.Report(Main.Console_box, "Writing to Settings file!", Color.Yellow)
                File.Delete(My.Computer.FileSystem.SpecialDirectories.Temp & "\AnimeStreamer\set")
                Dim objwriter As New StreamWriter(My.Computer.FileSystem.SpecialDirectories.Temp & "\AnimeStreamer\set")
                objwriter.Write("LoadHome=" & LoadHome.ToString & vbNewLine)
                objwriter.Write("LoadFavorites=" & LoadFavorites.ToString & vbNewLine)
                objwriter.Write("LoadHistory=" & LoadHistory.ToString & vbNewLine)
                objwriter.Write("LoadWatching=" & LoadWatching.ToString & vbNewLine)
                objwriter.Write("Notifactions=" & Notifactions.ToString & vbNewLine)
                objwriter.Write("LiveRecommends=" & LiveRecommends.ToString & vbNewLine)
                objwriter.Write("ShowTimeEvents=" & ShowTimeEvents.ToString & vbNewLine)
                objwriter.Close()
            Else
                Try
                    ConsoleCore.Report(Main.Console_box, "Deletings Settings file to refresh the settings!", Color.Yellow)
                    File.Delete(My.Computer.FileSystem.SpecialDirectories.Temp & "\AnimeStreamer\set")
                Catch ex As Exception
                    ConsoleCore.Report(Main.Console_box, "Failed to delete settings!", Color.Red)
                End Try
                ConsoleCore.Report(Main.Console_box, "Writing to Settings file!", Color.Yellow)
                Dim objwriter As New StreamWriter(My.Computer.FileSystem.SpecialDirectories.Temp & "\AnimeStreamer\set")
                objwriter.Write("LoadHome=" & LoadHome.ToString & vbNewLine)
                objwriter.Write("LoadFavorites=" & LoadFavorites.ToString & vbNewLine)
                objwriter.Write("LoadHistory=" & LoadHistory.ToString & vbNewLine)
                objwriter.Write("LoadWatching=" & LoadWatching.ToString & vbNewLine)
                objwriter.Write("Notifactions=" & Notifactions.ToString & vbNewLine)
                objwriter.Write("LiveRecommends=" & LiveRecommends.ToString & vbNewLine)
                objwriter.Write("ShowTimeEvents=" & ShowTimeEvents.ToString & vbNewLine)
                objwriter.Close()
            End If
        Catch ex As Exception
            ConsoleCore.Report(Main.Console_box, "Failed to save to settings!", Color.Red)
        End Try
    End Sub
    

End Class
