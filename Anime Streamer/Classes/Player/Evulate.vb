Public Class Evulate
    Public Shared VL1 As Boolean
    Public Shared VL2 As Boolean
    Public Shared VL3 As Boolean
    Public Shared VL4 As Boolean
    Public Shared Sub ClearVLs()
        VL1 = False
        VL2 = False
        VL3 = False
        VL4 = False
        'Return True
    End Sub
    Public Shared Sub VideoLink1()
        If Not ParserCore.VideoLink1 = "" Then
            If ParserCore.VideoLink1.Contains("videofun.me") Then
                Parser_VideoFun.VideoFunSourceRequest(ParserCore.VideoLink1)
            ElseIf ParserCore.VideoLink1.Contains("play44.net") Then
                Parser_Play44.Playy44SourceRequest(ParserCore.VideoLink1)
            ElseIf ParserCore.VideoLink1.Contains("www.video44.net") Then
                Parser_Video44.Video44SourceRequest(ParserCore.VideoLink1)
            ElseIf ParserCore.VideoLink1.Contains("yucache.net") Then
                Parser_yucache.yucacheSourceRequest(ParserCore.VideoLink1)
            ElseIf ParserCore.VideoLink1.Contains("byzoo.org") Then
                Parser_Byzoo.ByzooSourceRequest(ParserCore.VideoLink1)
            ElseIf ParserCore.VideoLink1.Contains("playpanda.net") Then
                Parser_PlayPanada.PlayPanadaSourceRequest(ParserCore.VideoLink1)
            ElseIf ParserCore.VideoLink1.Contains("videoweed") Then
                Parser_VideoWeed.GetSource(ParserCore.VideoLink1)
            ElseIf ParserCore.VideoLink1.Contains("easyvideo.me") Then
                Parser_EasyVideo.GetSource(ParserCore.VideoLink1)
            ElseIf ParserCore.VideoLink1.Contains("videozoo.me") Then
                Parser_VideoZoo.GetSource(ParserCore.VideoLink1)
            ElseIf ParserCore.VideoLink1.Contains("videowing.me") Then
                Parser_VideoWing.GetSource(ParserCore.VideoLink1)
            ElseIf ParserCore.VideoLink1.Contains("playbb.me") Then
                Parser_Playbb.GetSource(ParserCore.VideoLink1)
            Else
                Evulate.VideoLink2()
            End If
        Else
            Evulate.VideoLink2()
        End If
        'Return True
    End Sub
    Public Shared Sub VideoLink2()
        If Not ParserCore.VideoLink2 = "" Then
            If ParserCore.VideoLink2.Contains("videofun.me") Then
                Parser_VideoFun.VideoFunSourceRequest(ParserCore.VideoLink2)
            ElseIf ParserCore.VideoLink2.Contains("play44.net") Then
                Parser_Play44.Playy44SourceRequest(ParserCore.VideoLink2)
            ElseIf ParserCore.VideoLink2.Contains("www.video44.net") Then
                Parser_Video44.Video44SourceRequest(ParserCore.VideoLink2)
            ElseIf ParserCore.VideoLink2.Contains("yucache.net") Then
                Parser_yucache.yucacheSourceRequest(ParserCore.VideoLink2)
            ElseIf ParserCore.VideoLink2.Contains("byzoo.org") Then
                Parser_Byzoo.ByzooSourceRequest(ParserCore.VideoLink2)
            ElseIf ParserCore.VideoLink2.Contains("playpanda.net") Then
                Parser_PlayPanada.PlayPanadaSourceRequest(ParserCore.VideoLink2)
            ElseIf ParserCore.VideoLink2.Contains("videoweed") Then
                Parser_VideoWeed.GetSource(ParserCore.VideoLink2)
            ElseIf ParserCore.VideoLink2.Contains("easyvideo.me") Then
                Parser_EasyVideo.GetSource(ParserCore.VideoLink2)
            ElseIf ParserCore.VideoLink2.Contains("videozoo.me") Then
                Parser_VideoZoo.GetSource(ParserCore.VideoLink2)
            ElseIf ParserCore.VideoLink2.Contains("videowing.me") Then
                Parser_VideoWing.GetSource(ParserCore.VideoLink2)
            ElseIf ParserCore.VideoLink2.Contains("playbb.me") Then
                Parser_Playbb.GetSource(ParserCore.VideoLink2)
            Else
                Evulate.VideoLink3()
            End If
        Else
            Evulate.VideoLink3()
        End If
        'Return True
    End Sub
    Public Shared Sub VideoLink3()
        If Not ParserCore.VideoLink3 = "" Then
            If ParserCore.VideoLink3.Contains("videofun.me") Then
                Parser_VideoFun.VideoFunSourceRequest(ParserCore.VideoLink3)
            ElseIf ParserCore.VideoLink3.Contains("play44.net") Then
                Parser_Play44.Playy44SourceRequest(ParserCore.VideoLink3)
            ElseIf ParserCore.VideoLink3.Contains("www.video44.net") Then
                Parser_Video44.Video44SourceRequest(ParserCore.VideoLink3)
            ElseIf ParserCore.VideoLink3.Contains("yucache.net") Then
                Parser_yucache.yucacheSourceRequest(ParserCore.VideoLink3)
            ElseIf ParserCore.VideoLink3.Contains("byzoo.org") Then
                Parser_Byzoo.ByzooSourceRequest(ParserCore.VideoLink3)
            ElseIf ParserCore.VideoLink3.Contains("playpanda.net") Then
                Parser_PlayPanada.PlayPanadaSourceRequest(ParserCore.VideoLink3)
            ElseIf ParserCore.VideoLink3.Contains("videoweed") Then
                Parser_VideoWeed.GetSource(ParserCore.VideoLink3)
            ElseIf ParserCore.VideoLink3.Contains("easyvideo.me") Then
                Parser_EasyVideo.GetSource(ParserCore.VideoLink3)
            ElseIf ParserCore.VideoLink3.Contains("videozoo.me") Then
                Parser_VideoZoo.GetSource(ParserCore.VideoLink3)
            ElseIf ParserCore.VideoLink3.Contains("videowing.me") Then
                Parser_VideoWing.GetSource(ParserCore.VideoLink3)
            ElseIf ParserCore.VideoLink3.Contains("playbb.me") Then
                Parser_Playbb.GetSource(ParserCore.VideoLink3)
            Else
                Evulate.VideoLink4()
            End If
        Else
            Evulate.VideoLink4()
        End If
        'Return True
    End Sub
    Public Shared Sub VideoLink4()
        If Not ParserCore.VideoLink4 = "" Then
            If ParserCore.VideoLink4.Contains("videofun.me") Then
                Parser_VideoFun.VideoFunSourceRequest(ParserCore.VideoLink4)
            ElseIf ParserCore.VideoLink4.Contains("play44.net") Then
                Parser_Play44.Playy44SourceRequest(ParserCore.VideoLink4)
            ElseIf ParserCore.VideoLink4.Contains("www.video44.net") Then
                Parser_Video44.Video44SourceRequest(ParserCore.VideoLink4)
            ElseIf ParserCore.VideoLink4.Contains("yucache.net") Then
                Parser_yucache.yucacheSourceRequest(ParserCore.VideoLink4)
            ElseIf ParserCore.VideoLink4.Contains("byzoo.org") Then
                Parser_Byzoo.ByzooSourceRequest(ParserCore.VideoLink4)
            ElseIf ParserCore.VideoLink4.Contains("playpanda.net") Then
                Parser_PlayPanada.PlayPanadaSourceRequest(ParserCore.VideoLink4)
            ElseIf ParserCore.VideoLink4.Contains("videoweed") Then
                Parser_VideoWeed.GetSource(ParserCore.VideoLink4)
            ElseIf ParserCore.VideoLink4.Contains("easyvideo.me") Then
                Parser_EasyVideo.GetSource(ParserCore.VideoLink4)
            ElseIf ParserCore.VideoLink4.Contains("videozoo.me") Then
                Parser_VideoZoo.GetSource(ParserCore.VideoLink4)
            ElseIf ParserCore.VideoLink4.Contains("videowing.me") Then
                Parser_VideoWing.GetSource(ParserCore.VideoLink4)
            ElseIf ParserCore.VideoLink4.Contains("playbb.me") Then
                Parser_Playbb.GetSource(ParserCore.VideoLink4)
            Else
                '   MsgBox("Client Side: No  ParserCore Configurations for Streaming Link.", MsgBoxStyle.Exclamation, "We Are Sorry...")
            End If
        Else
            ' MsgBox("Server Side: No streaming links avaible.", MsgBoxStyle.Exclamation, "We Are Sorry...")
        End If
        'Return True
    End Sub
End Class
