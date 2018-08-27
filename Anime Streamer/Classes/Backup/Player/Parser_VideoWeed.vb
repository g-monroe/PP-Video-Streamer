Imports System.Net

Public Class Parser_VideoWeed
#Region "WebClients"
    '////////////////////////////////////////////////
    'Byzoo Parsing
    '////////////////////////////////////////////////
    Public Shared str As String
    Public Shared ph1 As String
    Public Shared ph2 As String
    Public Shared ph3 As String
    Public Shared Sub GetSource(link As String)
        ConsoleCore.Report(Main.Console_box, "Trying VideoWeed", Color.Orange)
        Dim wb As New WebClient
        AddHandler wb.DownloadStringCompleted, AddressOf wb_dsc
        wb.DownloadStringAsync(New Uri(link))
    End Sub
    Public Shared Sub wb_dsc(sender As Object, e As DownloadStringCompletedEventArgs)
        ConsoleCore.Report(Main.Console_box, "(VideoWeed)Got Source.", Color.Orange)
        str = e.Result
        GetApiLink()
    End Sub
    Public Shared wb As New WebClient
    Public Shared Sub GetApiLink()
        ConsoleCore.Report(Main.Console_box, "(VideoWeed)Getting api key!", Color.Orange)
        ph1 = Filter.getBetween(str, "var fkz=", ";")
        ph1 = ph1.Replace(Chr(34), "")
        ph2 = Filter.getBetween(str, "flashvars.file=", ";")
        ph2 = ph2.Replace(Chr(34), "")
        'http://www.videoweed.es/api/player.api.php?file=4f4d577ab141d&user=undefined&cid=undefined&pass=undefined&key=71%2E7%2E71%2E100-9a141827283298dcffd5eeca9a3e4829-&cid2=1004&cid3=undefined&numOfErrors=0
        ph3 = "http://www.videoweed.es/api/player.api.php?file=" & ph2 & "&user=undefined&cid=undefined&pass=undefined&key=" & ph1 & "&cid2=1004&cid3=undefined&numOfErrors=0"
        wb = New WebClient
        AddHandler wb.DownloadStringCompleted, AddressOf wb_dsc2
        wb.DownloadStringAsync(New Uri(ph3))
    End Sub
    Public Shared Sub wb_dsc2(sender As Object, e As DownloadStringCompletedEventArgs)
        str = e.Result
        str = str.Replace("url=", "")
        str = Filter.getBetween(str, "http://", ".flv&title=")
        str = "http://" & str & ".flv"
        Globals.StreamLink = str
        ConsoleCore.Report(Main.Console_box, "Setting Video Stream Link!", Color.Orange)

        ParserCore.SetStream(Globals.StreamLink)
        Main.Main_TabControl.SelectedIndex = 1
        wb.Dispose()
    End Sub
#End Region
    
End Class
