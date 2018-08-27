Public Class Parser_Byzoo
#Region "WebClients"
    '////////////////////////////////////////////////
    'Byzoo Parsing
    '////////////////////////////////////////////////
    Public Shared webb5 As New WebBrowser
    Public Shared ByzooVideoSource As String
    Public Shared Sub ByzooSourceRequest(vidlink As String)
        ConsoleCore.Report(Main.Console_box, "Trying Byzoo!", Color.Orange)
        webb5.ScriptErrorsSuppressed = True
        AddHandler webb5.DocumentCompleted, AddressOf webb5_DocCom
        If vidlink.Contains("w=718&#038;h=438&#038;") Then
            vidlink = vidlink.Replace("w=718&#038;h=438&#038;", "")
        End If
        ' MsgBox(vidlink)
        webb5.Navigate(vidlink)
        'Return True
    End Sub
    Public Shared Sub webb5_DocCom(sender As Object, e As WebBrowserDocumentCompletedEventArgs)
        Try
            ConsoleCore.Report(Main.Console_box, "Got The Source!", Color.Orange)
            ByzooVideoSource = webb5.Document.Body.InnerHtml
            ByzooParsing()
        Catch ex As Exception

            Try
                If Not Evulate.VL1 = True Then
                    ConsoleCore.Report(Main.Console_box, "(byzoo){After got source, before parsing.} Failed Trying Another = VL1!", Color.Red)
                    Evulate.VideoLink1()
                    Evulate.VL1 = True
                ElseIf Not Evulate.VL2 = True Then
                    ConsoleCore.Report(Main.Console_box, "(byzoo){After got source, before parsing.} Failed Trying Another = VL2!", Color.Red)
                    Evulate.VideoLink2()
                    Evulate.VL2 = True
                ElseIf Not Evulate.VL3 = True Then
                    ConsoleCore.Report(Main.Console_box, "(byzoo){After got source, before parsing.} Failed Trying Another = VL3!", Color.Red)
                    Evulate.VideoLink3()
                    Evulate.VL3 = True
                ElseIf Not Evulate.VL4 = True Then
                    ConsoleCore.Report(Main.Console_box, "(byzoo){After got source, before parsing.} Failed Trying Another = VL4!", Color.Red)
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
    Public Shared Sub ByzooParsing()
        Try
            Globals.StreamLink = Filter.getBetween(ByzooVideoSource, "_url = ", ";")
            Globals.StreamLink = Globals.StreamLink.Replace(Chr(34), "")
            Globals.StreamLink = Globals.StreamLink.Replace("%3A", ":")
            Globals.StreamLink = Globals.StreamLink.Replace("%2F", "/")
            Globals.StreamLink = Globals.StreamLink.Replace("%3F", "?")
            Globals.StreamLink = Globals.StreamLink.Replace("%3D", "=")
            Globals.StreamLink = Globals.StreamLink.Replace("%26", "&")
            ConsoleCore.Report(Main.Console_box, "Got and setting the link!", Color.Orange)

            ParserCore.SetStream(Globals.StreamLink)

            Main.Main_TabControl.SelectedIndex = 1
            webb5.Dispose()
        Catch ex As Exception
            If Not Evulate.VL1 = True Then
                ConsoleCore.Report(Main.Console_box, "(byzoo){After got source} Failed Trying Another = VL1!", Color.Red)
                Evulate.VideoLink1()
                Evulate.VL1 = True
            ElseIf Not Evulate.VL2 = True Then
                ConsoleCore.Report(Main.Console_box, "(byzoo){After got source} Failed Trying Another = VL2!", Color.Red)
                Evulate.VideoLink2()
                Evulate.VL2 = True
            ElseIf Not Evulate.VL3 = True Then
                ConsoleCore.Report(Main.Console_box, "(byzoo){After got source} Failed Trying Another = VL3!", Color.Red)
                Evulate.VideoLink3()
                Evulate.VL3 = True
            ElseIf Not Evulate.VL4 = True Then
                ConsoleCore.Report(Main.Console_box, "(byzoo){After got source} Failed Trying Another = VL4!", Color.Red)
                Evulate.VideoLink4()
                Evulate.VL4 = True
            End If
        End Try
        'Return True
    End Sub
End Class
