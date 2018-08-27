Imports System.Net

Public Class Parser_Play44
#Region "WebClients"
    '////////////////////////////////////////////////
    'Play44 Soucre Request Parse
    '////////////////////////////////////////////
    Public Shared Play44VideoSource As String
    Public Shared webb2 As New WebBrowser
    Public Shared Wb As New WebClient
    Public Shared Sub Playy44SourceRequest(VidLink As String)
        ConsoleCore.Report(Main.Console_box, "Trying Playy44.", Color.Orange)
        Try
            webb2 = New WebBrowser
            Wb = New WebClient
            webb2.ScriptErrorsSuppressed = True
            AddHandler webb2.DocumentCompleted, AddressOf webb2_DocCom
            'MsgBox(VidLink)
            '  webb2.Navigate(VidLink)
            AddHandler Wb.DownloadStringCompleted, AddressOf wb_dsc4
            Wb.DownloadStringAsync(New Uri(VidLink))
        Catch ex As Exception

            If Not Evulate.VL1 = True Then
                ConsoleCore.Report(Main.Console_box, "(playy44){before source.} Failed Trying Another = VL1!", Color.Red)
                Evulate.VideoLink1()
                Evulate.VL1 = True
            ElseIf Not Evulate.VL2 = True Then
                ConsoleCore.Report(Main.Console_box, "(playy44){before source.} Failed Trying Another = VL2!", Color.Red)
                Evulate.VideoLink2()
                Evulate.VL2 = True
            ElseIf Not Evulate.VL3 = True Then
                ConsoleCore.Report(Main.Console_box, "(playy44){before source.} Failed Trying Another = VL3!", Color.Red)
                Evulate.VideoLink3()
                Evulate.VL3 = True
            ElseIf Not Evulate.VL4 = True Then
                ConsoleCore.Report(Main.Console_box, "(playy44){before source.} Failed Trying Another = VL4!", Color.Red)
                Evulate.VideoLink4()
                Evulate.VL4 = True
            End If

        End Try
        'Return True
    End Sub

    Private Shared Sub wb_dsc4(sender As Object, e As DownloadStringCompletedEventArgs)
        ConsoleCore.Report(Main.Console_box, "(playy44) Got the Source", Color.Orange)
        Try
            Play44VideoSource = e.Result
            Play44Parsing()
        Catch ex As Exception
            If Not Evulate.VL1 = True Then
                ConsoleCore.Report(Main.Console_box, "(playy44){After got source.} Failed Trying Another = VL1!", Color.Red)
                Evulate.VideoLink1()
                Evulate.VL1 = True
            ElseIf Not Evulate.VL2 = True Then
                ConsoleCore.Report(Main.Console_box, "(playy44){After got source.} Failed Trying Another = VL2!", Color.Red)
                Evulate.VideoLink2()
                Evulate.VL2 = True
            ElseIf Not Evulate.VL3 = True Then
                ConsoleCore.Report(Main.Console_box, "(playy44){After got source.} Failed Trying Another = VL3!", Color.Red)
                Evulate.VideoLink3()
                Evulate.VL3 = True
            ElseIf Not Evulate.VL4 = True Then
                ConsoleCore.Report(Main.Console_box, "(playy44){After got source.} Failed Trying Another = VL4!", Color.Red)
                Evulate.VideoLink4()
                Evulate.VL4 = True
            End If
        End Try

    End Sub
    Public Shared Sub webb2_DocCom(sender As Object, e As WebBrowserDocumentCompletedEventArgs)
        ConsoleCore.Report(Main.Console_box, "(playy44) Got the Source", Color.Orange)
        Try
            Play44VideoSource = webb2.Document.Body.InnerHtml
            Play44Parsing()
        Catch ex As Exception
            Try
                If Not Evulate.VL1 = True Then
                    ConsoleCore.Report(Main.Console_box, "(playy44){After got source.} Failed Trying Another = VL1!", Color.Red)
                    Evulate.VideoLink1()
                    Evulate.VL1 = True
                ElseIf Not Evulate.VL2 = True Then
                    ConsoleCore.Report(Main.Console_box, "(playy44){After got source.} Failed Trying Another = VL2!", Color.Red)
                    Evulate.VideoLink2()
                    Evulate.VL2 = True
                ElseIf Not Evulate.VL3 = True Then
                    ConsoleCore.Report(Main.Console_box, "(playy44){After got source.} Failed Trying Another = VL3!", Color.Red)
                    Evulate.VideoLink3()
                    Evulate.VL3 = True
                ElseIf Not Evulate.VL4 = True Then
                    ConsoleCore.Report(Main.Console_box, "(playy44){After got source.} Failed Trying Another = VL4!", Color.Red)
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
    'Play44 Parsing
    '////////////////////////////////////////////
    Public Shared Sub Play44Parsing()
        ConsoleCore.Report(Main.Console_box, "(playy44) Parsing", Color.Orange)
        Try
            Globals.StreamLink = Filter.getBetween(Play44VideoSource, "_url = ", ";")
            Globals.StreamLink = Globals.StreamLink.Replace(Chr(34), "")
            Globals.StreamLink = Globals.StreamLink.Replace("%3A", ":")
            Globals.StreamLink = Globals.StreamLink.Replace("%2F", "/")
            Globals.StreamLink = Globals.StreamLink.Replace("%3F", "?")
            Globals.StreamLink = Globals.StreamLink.Replace("%3D", "=")
            Globals.StreamLink = Globals.StreamLink.Replace("%26", "&")
            ConsoleCore.Report(Main.Console_box, "(playy44) Got the link and setting it!", Color.Orange)

            ParserCore.SetStream(Globals.StreamLink)

            Main.Main_TabControl.SelectedIndex = 1
            webb2.Dispose()
            Wb.Dispose()
        Catch ex As Exception
            If Not Evulate.VL1 = True Then
                ConsoleCore.Report(Main.Console_box, "(playy44){After got source, and paring} Failed Trying Another = VL1!", Color.Red)
                Evulate.VideoLink1()
                Evulate.VL1 = True
            ElseIf Not Evulate.VL2 = True Then
                ConsoleCore.Report(Main.Console_box, "(playy44){After got source, and paring} Failed Trying Another = VL2!", Color.Red)
                Evulate.VideoLink2()
                Evulate.VL2 = True
            ElseIf Not Evulate.VL3 = True Then
                ConsoleCore.Report(Main.Console_box, "(playy44){After got source, and paring} Failed Trying Another = VL3!", Color.Red)
                Evulate.VideoLink3()
                Evulate.VL3 = True
            ElseIf Not Evulate.VL4 = True Then
                ConsoleCore.Report(Main.Console_box, "(playy44){After got source, and paring} Failed Trying Another = VL4!", Color.Red)
                Evulate.VideoLink4()
                Evulate.VideoLink4()
                Evulate.VL4 = True
            End If
        End Try
        'Return True
    End Sub
End Class
