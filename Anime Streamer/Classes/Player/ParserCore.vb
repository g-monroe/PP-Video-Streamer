Public Class ParserCore

    Public Shared ParsedHTMLDetails As String
    Public Shared VideoLink1 As String
    Public Shared VideoLink2 As String
    Public Shared VideoLink3 As String
    Public Shared VideoLink4 As String
    '////////////////////////////////////////////////
    '////////////////////////////////////////////////
    '////////////////////////////////////////////////
    '////////////////////////////////////////////////
    'GOOOOOD ANIME 
    '////////////////////////////////////////////////
    '////////////////////////////////////////////////
    '////////////////////////////////////////////////
    '////////////////////////////////////////////////
    Public Shared Sub GoodAnimeGetStreamDetails()
        ConsoleCore.Report(Main.Console_box, "(Subbed Anime.) Got Link, Now Clearing Parsers, and getting Links.", Color.Orange)
        ParserCore.VideoLink1 = ""
        ParserCore.VideoLink2 = ""
        ParserCore.VideoLink3 = ""
        ParserCore.VideoLink4 = ""
        ParsedHTMLDetails = Filter.getBetween(Subbed.GoodAnimeParseSource, "class=" & Chr(34) & "post" & Chr(34), "<p>&nbsp;</p>")
        ' MsgBox(ParsedHTMLDetails)
        Subbed.GoodAnimeNextNPrevEp()
        If Not ParsedHTMLDetails = "" Or Not ParsedHTMLDetails Is Nothing Then
            Dim linearr2 As String() = ParsedHTMLDetails.Split("<p><iframe src")
            Dim i As Integer = 0
            For Each line As String In linearr2
                If line.StartsWith("iframe") Then

                    Dim Vidlink As String
                    Try
                        Vidlink = Filter.getBetween(line, "src", Chr(34) & " ")
                        Vidlink = Vidlink.Replace("=" & Chr(34), "")
                    Catch ex As Exception
                        Vidlink = ""
                    End Try
                    i += 1
                    If i = 3 Then
                        ConsoleCore.Report(Main.Console_box, "(Subbed Anime.) Setting VL1.", Color.Yellow)
                        VideoLink1 = Vidlink
                        If VideoLink1.Contains("w=718&#038;h=438&#038;") Then
                            VideoLink1 = VideoLink1.Replace("w=718&#038;h=438&#038;", "")
                        End If
                        '  MsgBox(VideoLink1)
                    ElseIf i = 4 Then
                        ConsoleCore.Report(Main.Console_box, "(Subbed Anime.) Setting VL2.", Color.YellowGreen)
                        VideoLink2 = Vidlink
                        If VideoLink2.Contains("w=718&#038;h=438&#038;") Then
                            VideoLink2 = VideoLink2.Replace("w=718&#038;h=438&#038;", "")
                        End If
                        '  MsgBox(VideoLink2)
                    ElseIf i = 5 Then
                        ConsoleCore.Report(Main.Console_box, "(Subbed Anime.) Setting VL3.", Color.LightGreen)
                        VideoLink3 = Vidlink
                        If VideoLink3.Contains("w=718&#038;h=438&#038;") Then
                            VideoLink3 = VideoLink3.Replace("w=718&#038;h=438&#038;", "")
                        End If
                        '  MsgBox(VideoLink3)
                    ElseIf i = 6 Then
                        ConsoleCore.Report(Main.Console_box, "(Subbed Anime.) Setting VL4.", Color.Green)
                        VideoLink4 = Vidlink
                        If VideoLink4.Contains("w=718&#038;h=438&#038;") Then
                            VideoLink4 = VideoLink4.Replace("w=718&#038;h=438&#038;", "")
                        End If
                        ' MsgBox(VideoLink4)
                        'Dim pont As Point = New Point(150, 150)
                        'CMsgbox.SourceStr = Vidlink
                        'CMsgbox.Source("l", "l", pont)
                    End If
                End If
            Next
        End If
        ConsoleCore.Report(Main.Console_box, "(Subbed Anime.) Clearing VL Booleans.", Color.Yellow)
        Evulate.ClearVLs()
        ConsoleCore.Report(Main.Console_box, "(Subbed Anime.) Tesing Link VL1!", Color.Orange)
        Evulate.VideoLink1()
        Evulate.VL1 = True
        'Return True
    End Sub
    '////////////////////////////////////////////////
    '////////////////////////////////////////////////
    '////////////////////////////////////////////////
    '////////////////////////////////////////////////
    ' ANIME TOON
    '////////////////////////////////////////////////
    '////////////////////////////////////////////////
    '////////////////////////////////////////////////
    '////////////////////////////////////////////////
    Public Shared NNPEP As String

    Public Shared Sub AnimeToonGetVideoLinks()
        ConsoleCore.Report(Main.Console_box, "(Dubbed Anime.) Got Link, Now Clearing Parsers, and getting Links.", Color.Orange)
        ParserCore.VideoLink1 = ""
        ParserCore.VideoLink2 = ""
        ParserCore.VideoLink3 = ""
        ParserCore.VideoLink4 = ""
        ParsedHTMLDetails = Filter.midReturn(Dubbed.AnimeToonParseSource, "<div id=" & Chr(34) & "streams" & Chr(34) & ">", "<!-- AnimeToon - 120x100")
        NNPEP = Filter.getBetween(Dubbed.AnimeToonParseSource, "<div id=" & Chr(34) & "elinks" & Chr(34) & ">", "</div>")
        Dubbed.AnimeToonNextNPrevEp()
        Dim linearr2 As String() = ParsedHTMLDetails.Split("<div class=" & Chr(34) & "vmargin")
        Dim i As Integer = 0
        For Each line As String In linearr2
            ' MsgBox(line)
            If line.StartsWith("iframe") Then
                Dim Vidlink As String = Filter.getBetween(line, "iframe src", Chr(34) & " ")
                Vidlink = Vidlink.Replace("=" & Chr(34), "")
                i += 1
                If i = 1 Then
                    ConsoleCore.Report(Main.Console_box, "(Dubbed Anime.) Setting VL1.", Color.Yellow)
                    VideoLink1 = Vidlink
                    'MsgBox(VideoLink1)
                ElseIf i = 2 Then
                    ConsoleCore.Report(Main.Console_box, "(Dubbed Anime.) Setting VL2.", Color.YellowGreen)
                    VideoLink2 = Vidlink
                    '  MsgBox(VideoLink2)
                ElseIf i = 3 Then
                    ConsoleCore.Report(Main.Console_box, "(Dubbed Anime.) Setting VL3.", Color.LightGreen)
                    VideoLink3 = Vidlink
                    '  MsgBox(VideoLink3)
                ElseIf i = 4 Then
                    ConsoleCore.Report(Main.Console_box, "(Dubbed Anime.) Setting VL4.", Color.Green)
                    VideoLink4 = Vidlink
                    '  MsgBox(VideoLink4)
                End If
            End If
        Next
        ConsoleCore.Report(Main.Console_box, "(Dubbed Anime.) Clearing VL Booleans.", Color.Yellow)
        Evulate.ClearVLs()
        ConsoleCore.Report(Main.Console_box, "(Dubbed Anime.) Testing first Link VL1!", Color.Orange)
        Evulate.VideoLink1()
        Evulate.VL1 = True
        'Return True
    End Sub
    'Set Stream
    Public Shared Sub SetStream(Vidlink As String)
        Main.Main_TabControl.SelectedIndex = 1
        'VLC

        'Main.AxVLCPlugin21.playlist.items.clear()
        'Main.AxVLCPlugin21.playlist.add(Vidlink)
        'Main.AxVLCPlugin21.playlist.play()

        'WMP
        'Main.AxWindowsMediaPlayer1.stretchToFit = True
        'Main.AxWindowsMediaPlayer1.URL = Vidlink

    End Sub
End Class
