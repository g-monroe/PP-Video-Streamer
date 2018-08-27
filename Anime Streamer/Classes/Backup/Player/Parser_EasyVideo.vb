Imports System.Net

Public Class Parser_EasyVideo
    Public Shared webb5 As New WebBrowser
    Public Shared EasyVideoSource As String
    Sub New()

    End Sub
    Public Shared Sub GetSource(vidlink As String)
        webb5 = New WebBrowser
        EasyVideoSource = ""
        ConsoleCore.Report(Main.Console_box, "Getting Source from Stream Service EasyVideo.", Color.Orange)
        If vidlink.Contains("#038;") Then
            vidlink = vidlink.Replace("#038;", "")
        End If
        ConsoleCore.Report(Main.Console_box, "Link: " & vidlink, Color.Orange)

        webb5.ScriptErrorsSuppressed = True
        AddHandler webb5.DocumentCompleted, AddressOf webb5_DocCom

        webb5.Navigate(vidlink)
    End Sub


    Private Shared Sub webb5_DocCom(sender As Object, e As WebBrowserDocumentCompletedEventArgs)
        Try
            ConsoleCore.Report(Main.Console_box, "Got Source from Stream Service EasyVideo.", Color.Orange)
            EasyVideoSource = webb5.Document.Body.InnerHtml
            Globals.StreamLink = Filter.midReturn(EasyVideoSource, "url: '", "',")
            Globals.StreamLink = Globals.StreamLink.Replace(Chr(34), "")
            Globals.StreamLink = Globals.StreamLink.Replace("%3A", ":")
            Globals.StreamLink = Globals.StreamLink.Replace("%2F", "/")
            Globals.StreamLink = Globals.StreamLink.Replace("%3F", "?")
            Globals.StreamLink = Globals.StreamLink.Replace("%3D", "=")
            Globals.StreamLink = Globals.StreamLink.Replace("%26", "&")
            ConsoleCore.Report(Main.Console_box, "Link: " & Globals.StreamLink, Color.Orange)
            ConsoleCore.Report(Main.Console_box, "Got and setting the link!", Color.Orange)

            ParserCore.SetStream(Globals.StreamLink)
            Main.Main_TabControl.SelectedIndex = 1
            webb5.Dispose()
        Catch ex As Exception
            Try
                If Not Evulate.VL1 = True Then
                    ConsoleCore.Report(Main.Console_box, "(EasyVideo){After got source, before parsing.} Failed Trying Another = VL1!", Color.Red)
                    Evulate.VideoLink1()
                    Evulate.VL1 = True
                ElseIf Not Evulate.VL2 = True Then
                    ConsoleCore.Report(Main.Console_box, "(EasyVideo){After got source, before parsing.} Failed Trying Another = VL2!", Color.Red)
                    Evulate.VideoLink2()
                    Evulate.VL2 = True
                ElseIf Not Evulate.VL3 = True Then
                    ConsoleCore.Report(Main.Console_box, "(EasyVideo){After got source, before parsing.} Failed Trying Another = VL3!", Color.Red)
                    Evulate.VideoLink3()
                    Evulate.VL3 = True
                ElseIf Not Evulate.VL4 = True Then
                    ConsoleCore.Report(Main.Console_box, "(EasyVideo){After got source, before parsing.} Failed Trying Another = VL4!", Color.Red)
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

End Class
