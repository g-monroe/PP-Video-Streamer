Imports System.Net

Public Class Parser_VideoFun
#Region "WebClients"
    '///////////////////////////////////////////////////////////////
    'VideoFun.me Soucre Request Parse
    '///////////////////////////////////////////////////////////////
    Public Shared VideoFunVideoSource As String
    Public Shared webb As New WebBrowser
    Public Shared wbVF As New WebClient
    Public Shared Sub VideoFunSourceRequest(VidLink As String)
        ConsoleCore.Report(Main.Console_box, "Trying VideoFun", Color.Orange)
        Try
            webb = New WebBrowser
            webb.ScriptErrorsSuppressed = True
            AddHandler webb.DocumentCompleted, AddressOf webb_DocCom
            'MsgBox(VidLink)
            webb.Navigate(VidLink)
        Catch ex As Exception
            Try
                wbVF = New WebClient
                AddHandler wbVF.DownloadStringCompleted, AddressOf wbvf_DSC
                ' MsgBox(VidLink)
                wbVF.DownloadStringAsync(New Uri(VidLink))
            Catch ex2 As Exception
                Try
                    If Not Evulate.VL1 = True Then
                        ConsoleCore.Report(Main.Console_box, "(VideoFun){before source.} Failed Trying Another = VL1!", Color.Red)
                        Evulate.VideoLink1()
                        Evulate.VL1 = True
                    ElseIf Not Evulate.VL2 = True Then
                        ConsoleCore.Report(Main.Console_box, "(VideoFun){before source.} Failed Trying Another = VL2!", Color.Red)
                        Evulate.VideoLink2()
                        Evulate.VL2 = True
                    ElseIf Not Evulate.VL3 = True Then
                        ConsoleCore.Report(Main.Console_box, "(VideoFun){before source.} Failed Trying Another = VL3!", Color.Red)
                        Evulate.VideoLink3()
                        Evulate.VL3 = True
                    ElseIf Not Evulate.VL4 = True Then
                        ConsoleCore.Report(Main.Console_box, "(VideoFun){before source.} Failed Trying Another = VL4!", Color.Red)
                        Evulate.VideoLink4()
                        Evulate.VL4 = True
                    End If
                Catch ex4 As Exception
                    Try

                    Catch ex3 As Exception
                    End Try
                End Try
            End Try

        End Try
        'Return True
    End Sub
    Public Shared Sub webb_DocCom(sender As Object, e As WebBrowserDocumentCompletedEventArgs)
        ConsoleCore.Report(Main.Console_box, "(VideoFun) Got Source", Color.Orange)
        Try
            VideoFunVideoSource = webb.Document.Body.InnerHtml
            VideoFunParsing()
        Catch ex As Exception
            Try
                If Not Evulate.VL1 = True Then
                    ConsoleCore.Report(Main.Console_box, "(VideoFun){After got source} Failed Trying Another = VL1!", Color.Red)
                    Evulate.VideoLink1()
                    Evulate.VL1 = True
                ElseIf Not Evulate.VL2 = True Then
                    ConsoleCore.Report(Main.Console_box, "(VideoFun){After got source} Failed Trying Another = VL2!", Color.Red)
                    Evulate.VideoLink2()
                    Evulate.VL2 = True
                ElseIf Not Evulate.VL3 = True Then
                    ConsoleCore.Report(Main.Console_box, "(VideoFun){After got source} Failed Trying Another = VL3!", Color.Red)
                    Evulate.VideoLink3()
                    Evulate.VL3 = True
                ElseIf Not Evulate.VL4 = True Then
                    ConsoleCore.Report(Main.Console_box, "(VideoFun){After got source} Failed Trying Another = VL4!", Color.Red)
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
    Private Shared Sub wbvf_DSC(sender As Object, e As DownloadStringCompletedEventArgs)
        ConsoleCore.Report(Main.Console_box, "(VideoFun) Got Source", Color.Orange)
        Try
            VideoFunVideoSource = e.Result
            VideoFunParsing()
        Catch ex As Exception
            Try
                If Not Evulate.VL1 = True Then
                    ConsoleCore.Report(Main.Console_box, "(VideoFun){After got source} Failed Trying Another = VL1!", Color.Red)
                    Evulate.VideoLink1()
                    Evulate.VL1 = True
                ElseIf Not Evulate.VL2 = True Then
                    ConsoleCore.Report(Main.Console_box, "(VideoFun){After got source} Failed Trying Another = VL2!", Color.Red)
                    Evulate.VideoLink2()
                    Evulate.VL2 = True
                ElseIf Not Evulate.VL3 = True Then
                    ConsoleCore.Report(Main.Console_box, "(VideoFun){After got source} Failed Trying Another = VL3!", Color.Red)
                    Evulate.VideoLink3()
                    Evulate.VL3 = True
                ElseIf Not Evulate.VL4 = True Then
                    ConsoleCore.Report(Main.Console_box, "(VideoFun){After got source} Failed Trying Another = VL4!", Color.Red)
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
    '///////////////////////////////////////////////////////////////
    'VideoFun.me Video Parsing....
    '///////////////////////////////////////////////////////////////

    Public Shared Sub VideoFunParsing()
        ConsoleCore.Report(Main.Console_box, "(VideoFun) Parsing.", Color.Orange)
        Try
            Globals.StreamLink = Filter.getBetween(VideoFunVideoSource, "{url: " & Chr(34) & "http://gateway", ", autoPlay: false,")
            Globals.StreamLink = Globals.StreamLink.Replace(Chr(34), "")
            Globals.StreamLink = Globals.StreamLink.Replace("%3A", ":")
            Globals.StreamLink = Globals.StreamLink.Replace("%2F", "/")
            Globals.StreamLink = Globals.StreamLink.Replace("%3F", "?")
            Globals.StreamLink = Globals.StreamLink.Replace("%3D", "=")
            Globals.StreamLink = Globals.StreamLink.Replace("%26", "&")
            Globals.StreamLink = "http://gateway" + Globals.StreamLink
            ConsoleCore.Report(Main.Console_box, "(VideoFun) Got Link and now setting.", Color.Orange)

            ParserCore.SetStream(Globals.StreamLink)

            Main.Main_TabControl.SelectedIndex = 1
            webb.Dispose()
            wbVF.Dispose()
        Catch ex As Exception
            If Not Evulate.VL1 = True Then
                ConsoleCore.Report(Main.Console_box, "(VideoFun){After got source, and paring} Failed Trying Another = VL1!", Color.Red)
                Evulate.VideoLink1()
                Evulate.VL1 = True
            ElseIf Not Evulate.VL2 = True Then
                ConsoleCore.Report(Main.Console_box, "(VideoFun){After got source, and paring} Failed Trying Another = VL2!", Color.Red)
                Evulate.VideoLink2()
                Evulate.VL2 = True
            ElseIf Not Evulate.VL3 = True Then
                ConsoleCore.Report(Main.Console_box, "(VideoFun){After got source, and paring} Failed Trying Another = VL3!", Color.Red)
                Evulate.VideoLink3()
                Evulate.VL3 = True
            ElseIf Not Evulate.VL4 = True Then
                ConsoleCore.Report(Main.Console_box, "(VideoFun){After got source, and paring} Failed Trying Another = VL4!", Color.Red)
                Evulate.VideoLink4()
                Evulate.VL4 = True
            End If
        End Try
        'Return True
    End Sub
End Class
