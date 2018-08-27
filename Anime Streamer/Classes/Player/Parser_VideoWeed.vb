Imports System.Net

Public Class Parser_VideoWeed
#Region "WebClients"
    '////////////////////////////////////////////////
    'Byzoo Parsing
    '////////////////////////////////////////////////
    Public Shared WithEvents BackgroundWorker1 As New System.ComponentModel.BackgroundWorker
    Public Shared WithEvents BackgroundWorker2 As New System.ComponentModel.BackgroundWorker
    Public Shared str As String
    Public Shared ph1 As String
    Public Shared ph2 As String
    Public Shared ph3 As String
    Public Shared Sub GetSource(vidlink As String)
        ConsoleCore.Report(Main.Console_box, "Trying VideoWeed", Color.Orange)
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
    End Sub
    'Public Shared wb As New WebClient
    Public Shared Sub BackgroundWorker1_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim GetSourcee2 As GetSourcee = CType(e.Argument, GetSourcee)
        e.Result = GetSourcee.GetSource(GetSourcee2.Vidlin, GetSourcee2.Typ)
    End Sub
    Public Shared Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        ConsoleCore.Report(Main.Console_box, "(VideoWeed)Got Source.", Color.Orange)
        str = e.Result
        GetApiLink()
    End Sub
    Public Shared Sub GetApiLink()
        ConsoleCore.Report(Main.Console_box, "(VideoWeed)Getting api key!", Color.Orange)
        ph1 = Filter.getBetween(str, "var fkz=", ";")
        ph1 = ph1.Replace(Chr(34), "")
        ph2 = Filter.getBetween(str, "flashvars.file=", ";")
        ph2 = ph2.Replace(Chr(34), "")
        'http://www.videoweed.es/api/player.api.php?file=4f4d577ab141d&user=undefined&cid=undefined&pass=undefined&key=71%2E7%2E71%2E100-9a141827283298dcffd5eeca9a3e4829-&cid2=1004&cid3=undefined&numOfErrors=0
        ph3 = "http://www.videoweed.es/api/player.api.php?file=" & ph2 & "&user=undefined&cid=undefined&pass=undefined&key=" & ph1 & "&cid2=1004&cid3=undefined&numOfErrors=0"
        Dim GSMObject As New GetSourcee
        GSMObject.Typ = GetSourcee.Type.WebRequest
        GSMObject.Vidlin = ph3
        BackgroundWorker2.RunWorkerAsync(GSMObject)
    End Sub
    Public Shared Sub BackgroundWorker2_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker2.DoWork
        Dim GetSourcee2 As GetSourcee = CType(e.Argument, GetSourcee)
        e.Result = GetSourcee.GetSource(GetSourcee2.Vidlin, GetSourcee2.Typ)
    End Sub
    Public Shared Sub BackgroundWorker2_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker2.RunWorkerCompleted
        str = e.Result
        str = str.Replace("url=", "")
        str = Filter.getBetween(str, "http://", ".flv&title=")
        str = "http://" & str & ".flv"
        Globals.StreamLink = str
        ConsoleCore.Report(Main.Console_box, "Setting Video Stream Link!", Color.Orange)

        ParserCore.SetStream(Globals.StreamLink)
        Main.Main_TabControl.SelectedIndex = 1
    End Sub
   
#End Region
    
End Class
