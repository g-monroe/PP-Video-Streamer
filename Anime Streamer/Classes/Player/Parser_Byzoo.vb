Public Class Parser_Byzoo
#Region "WebClients"
    '////////////////////////////////////////////////
    'Byzoo Parsing
    '////////////////////////////////////////////////
    '  Public Shared webb5 As New WebBrowser
    Public Shared ByzooVideoSource As String
    Public Shared WithEvents BackgroundWorker1 As New System.ComponentModel.BackgroundWorker
    Public Shared Sub ByzooSourceRequest(vidlink As String)
        ConsoleCore.Report(Main.Console_box, "Trying Byzoo!", Color.Orange)
        'webb5.ScriptErrorsSuppressed = True
        'AddHandler webb5.DocumentCompleted, AddressOf webb5_DocCom
        If vidlink.Contains("w=718&#038;h=438&#038;") Then
            vidlink = vidlink.Replace("w=718&#038;h=438&#038;", "")
        End If
        ' MsgBox(vidlink)
        'webb5.Navigate(vidlink)
        'Return True
        Dim GSMObject As New GetSourcee
            GSMObject.Typ = GetSourcee.Type.WebRequest
        GSMObject.Vidlin = vidlink
        If (BackgroundWorker1.IsBusy = True) Then
            Try
                BackgroundWorker1.CancelAsync()
                BackgroundWorker1.RunWorkerAsync(GSMObject)
            Catch ex As Exception
            End Try
        Else
            BackgroundWorker1.RunWorkerAsync(GSMObject)
        End If
    End Sub

    Public Shared Sub BackgroundWorker1_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim GetSourcee2 As GetSourcee = CType(e.Argument, GetSourcee)
        e.Result = GetSourcee.GetSource(GetSourcee2.Vidlin, GetSourcee2.Typ)
    End Sub
    Public Shared Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Try
            ConsoleCore.Report(Main.Console_box, "Got The Source!", Color.Orange)
            ByzooVideoSource = e.Result()
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
            '   webb5.Dispose()
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
