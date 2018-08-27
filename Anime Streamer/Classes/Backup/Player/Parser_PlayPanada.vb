Imports System.Net

Public Class Parser_PlayPanada
#Region "WebClient"
    '////////////////////////////////////////////////
    'PlayPanada Parsing
    '////////////////////////////////////////////////
    Public Shared webb6 As New WebClient
    Public Shared PlayPanadaVideoSource As String
    Public Shared Sub PlayPanadaSourceRequest(Vidlink As String)
        ConsoleCore.Report(Main.Console_box, "Trying PlayPanda", Color.Orange)
        webb6 = New WebClient
        AddHandler webb6.DownloadStringCompleted, AddressOf webb6_DSC
        ' MsgBox(Vidlink)
        Try
            Vidlink = Vidlink.Replace("w=718&#038;h=438&#038;", "")
        Catch ex As Exception
        End Try
        webb6.DownloadStringAsync(New Uri(Vidlink))
        'Return True
    End Sub
    Public Shared Sub webb6_DSC(sender As Object, e As DownloadStringCompletedEventArgs)
        ConsoleCore.Report(Main.Console_box, "(playpanda) Got The Source.", Color.Orange)
        Try
            PlayPanadaVideoSource = e.Result
            PlayPanadaParsing()
        Catch ex As Exception
            Try
                If Not Evulate.VL1 = True Then
                    ConsoleCore.Report(Main.Console_box, "(playpanda){After got source.} Failed Trying Another = VL2!", Color.Red)
                    Evulate.VideoLink1()
                    Evulate.VL1 = True
                ElseIf Not Evulate.VL2 = True Then
                    ConsoleCore.Report(Main.Console_box, "(playpanda){After got source.} Failed Trying Another = VL2!", Color.Red)
                    Evulate.VideoLink2()
                    Evulate.VL2 = True
                ElseIf Not Evulate.VL3 = True Then
                    ConsoleCore.Report(Main.Console_box, "(playpanda){After got source.} Failed Trying Another = VL3!", Color.Red)
                    Evulate.VideoLink3()
                    Evulate.VL3 = True
                ElseIf Not Evulate.VL4 = True Then
                    ConsoleCore.Report(Main.Console_box, "(playpanda){After got source.} Failed Trying Another = VL4!", Color.Red)
                    Evulate.VideoLink4()
                    Evulate.VL4 = True
                End If
            Catch ex2 As Exception
                Try

                Catch ex3 As Exception
                End Try
            End Try
        End Try

    End Sub
#End Region
    '////////////////////////////////////////////////
    'Byzoo Parsing
    '////////////////////////////////////////////////
    Public Shared Sub PlayPanadaParsing()
        ConsoleCore.Report(Main.Console_box, "(playpanda) Parsing now.", Color.Orange)
        Try
            Globals.StreamLink = Filter.getBetween(PlayPanadaVideoSource, "_url = ", ";")
            Globals.StreamLink = Globals.StreamLink.Replace(Chr(34), "")
            Globals.StreamLink = Globals.StreamLink.Replace("%3A", ":")
            Globals.StreamLink = Globals.StreamLink.Replace("%2F", "/")
            Globals.StreamLink = Globals.StreamLink.Replace("%3F", "?")
            Globals.StreamLink = Globals.StreamLink.Replace("%3D", "=")
            Globals.StreamLink = Globals.StreamLink.Replace("%26", "&")
            ConsoleCore.Report(Main.Console_box, "(playpanda) Got the link and now setting it!", Color.Orange)

            ParserCore.SetStream(Globals.StreamLink)

            Main.Main_TabControl.SelectedIndex = 1
            webb6.Dispose()
        Catch ex As Exception
            If Not Evulate.VL1 = True Then
                ConsoleCore.Report(Main.Console_box, "(playpanda){After got source, and paring} Failed Trying Another = VL1!", Color.Red)
                Evulate.VideoLink1()
                Evulate.VL1 = True
            ElseIf Not Evulate.VL2 = True Then
                ConsoleCore.Report(Main.Console_box, "(playpanda){After got source, and paring} Failed Trying Another = VL2!", Color.Red)
                Evulate.VideoLink2()
                Evulate.VL2 = True
            ElseIf Not Evulate.VL3 = True Then
                ConsoleCore.Report(Main.Console_box, "(playpanda){After got source, and paring} Failed Trying Another = VL3!", Color.Red)
                Evulate.VideoLink3()
                Evulate.VL3 = True
            ElseIf Not Evulate.VL4 = True Then
                ConsoleCore.Report(Main.Console_box, "(playpanda){After got source, and paring} Failed Trying Another = VL4!", Color.Red)
                Evulate.VideoLink4()
                Evulate.VL4 = True
            End If
        End Try
        'Return True
    End Sub
End Class
