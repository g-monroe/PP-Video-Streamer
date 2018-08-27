Public Class Parser_yucache
#Region "WebClients"
    '\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    'yucache Source Request Parse
    '\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    Public Shared yucacheVideoSource As String
    Public Shared webb4 As New WebBrowser
    Public Shared Sub yucacheSourceRequest(VidLink As String)
        ConsoleCore.Report(Main.Console_box, "Trying yucache!", Color.Orange)
        webb4 = New WebBrowser
        webb4.ScriptErrorsSuppressed = True
        AddHandler webb4.DocumentCompleted, AddressOf webb4_DocCom
        'MsgBox(VidLink)
        webb4.Navigate(VidLink)
        'Return True
    End Sub
    Public Shared Sub webb4_DocCom(sender As Object, e As WebBrowserDocumentCompletedEventArgs)
        ConsoleCore.Report(Main.Console_box, "(yucache) Got Source!", Color.Orange)
        Try
            yucacheVideoSource = webb4.Document.Body.InnerHtml
            yucacheParsing()
        Catch ex As Exception
            Try
                If Not Evulate.VL1 = True Then
                    ConsoleCore.Report(Main.Console_box, "(yucache){After got source} Failed Trying Another = VL1!", Color.Red)
                    Evulate.VideoLink1()
                    Evulate.VL1 = True
                ElseIf Not Evulate.VL2 = True Then
                    ConsoleCore.Report(Main.Console_box, "(yucache){After got source} Failed Trying Another = VL2!", Color.Red)
                    Evulate.VideoLink2()
                    Evulate.VL2 = True
                ElseIf Not Evulate.VL3 = True Then
                    ConsoleCore.Report(Main.Console_box, "(yucache){After got source} Failed Trying Another = VL3!", Color.Red)
                    Evulate.VideoLink3()
                    Evulate.VL3 = True
                ElseIf Not Evulate.VL4 = True Then
                    ConsoleCore.Report(Main.Console_box, "(yucache){After got source} Failed Trying Another = VL4!", Color.Red)
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
    'yucache Parsing
    '////////////////////////////////////////////////
    Public Shared Sub yucacheParsing()
        ConsoleCore.Report(Main.Console_box, "(yucache) Got Source, and now parsing", Color.Orange)
        Try
            Globals.StreamLink = Filter.getBetween(yucacheVideoSource, "http://stream.", ",")
            Globals.StreamLink = Globals.StreamLink.Split(" />").First
            Globals.StreamLink = "http://stream." & Globals.StreamLink
            Globals.StreamLink = Globals.StreamLink.Replace(Globals.StreamLink.Split("?client_file_id=").Last, "")
            Globals.StreamLink = Globals.StreamLink.Replace("?", "")
            Globals.StreamLink = Globals.StreamLink.Replace(Chr(34), "")
            Globals.StreamLink = Globals.StreamLink.Replace("%3A", ":")
            Globals.StreamLink = Globals.StreamLink.Replace("%2F", "/")
            Globals.StreamLink = Globals.StreamLink.Replace("%3F", "?")
            Globals.StreamLink = Globals.StreamLink.Replace("%3D", "=")
            Globals.StreamLink = Globals.StreamLink.Replace("%26", "&")
            ConsoleCore.Report(Main.Console_box, "(yucache) Got link, and now streaming.", Color.Orange)

           ParserCore.SetStream(Globals.StreamLink)

            webb4.Dispose()
        Catch ex As Exception
            If Not Evulate.VL1 = True Then
                ConsoleCore.Report(Main.Console_box, "(yucache){After got source, and paring} Failed Trying Another = VL1!", Color.Red)
                Evulate.VideoLink1()
                Evulate.VL1 = True
            ElseIf Not Evulate.VL2 = True Then
                ConsoleCore.Report(Main.Console_box, "(yucache){After got source, and paring} Failed Trying Another = VL2!", Color.Red)
                Evulate.VideoLink2()
                Evulate.VL2 = True
            ElseIf Not Evulate.VL3 = True Then
                ConsoleCore.Report(Main.Console_box, "(yucache){After got source, and paring} Failed Trying Another = VL3!", Color.Red)
                Evulate.VideoLink3()
                Evulate.VL3 = True
            ElseIf Not Evulate.VL4 = True Then
                ConsoleCore.Report(Main.Console_box, "(yucache){After got source, and paring} Failed Trying Another = VL4!", Color.Red)
                Evulate.VideoLink4()
                Evulate.VL4 = True
            End If
        End Try
        'Return True
    End Sub
End Class
