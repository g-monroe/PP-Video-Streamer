Imports System.Net

Public Class Parser_VideoFun
#Region "WebClients"
    '///////////////////////////////////////////////////////////////
    'VideoFun.me Soucre Request Parse
    '///////////////////////////////////////////////////////////////
    Public Shared VideoFunVideoSource As String
    'Public Shared webb As New WebBrowser
    'Public Shared wbVF As New WebClient
    Public Shared WithEvents BackgroundWorker1 As New System.ComponentModel.BackgroundWorker
    Public Shared Sub VideoFunSourceRequest(VidLink As String)
        ConsoleCore.Report(Main.Console_box, "Trying VideoFun", Color.Orange)
        Try
            Dim GSMObject As New GetSourcee
            GSMObject.Typ = GetSourcee.Type.WebRequest
            GSMObject.Vidlin = VidLink
            If (BackgroundWorker1.IsBusy = True) Then
                Try
                    BackgroundWorker1.CancelAsync()
                    BackgroundWorker1.RunWorkerAsync(GSMObject)
                Catch ex As Exception
                End Try
            Else
                BackgroundWorker1.RunWorkerAsync(GSMObject)
            End If
        Catch ex As Exception
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
        'Return True
    End Sub
    Public Shared Sub BackgroundWorker1_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim GetSourcee2 As GetSourcee = CType(e.Argument, GetSourcee)
        e.Result = GetSourcee.GetSource(GetSourcee2.Vidlin, GetSourcee2.Typ)
    End Sub
    Public Shared Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
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
