Imports System.IO
Imports System.Net

Public Class History
    Public Shared Histdict As New Dictionary(Of String, String)()
    Public Shared Sub LoadHistory()
        If File.Exists(My.Computer.FileSystem.SpecialDirectories.Temp & "\AnimeStreamer\hist") Then
            Dim objreader As New StreamReader(My.Computer.FileSystem.SpecialDirectories.Temp & "\AnimeStreamer\hist")
            Do While objreader.Peek() <> -1
                Try
                    Dim line As String

                    line = objreader.ReadLine() & vbNewLine

                    If line.Contains("~^~") Then
                        Dim namme = line.Split("~^~").First
                        Dim link = line.Split("~^~").Last
                        If Filter.CheckForAlphaCharacters(namme) Then
                            Histdict.Add(namme, link)
                        Else
                            namme = link.Split("/"c).Last()
                            Histdict.Add(namme, link)
                        End If
                    End If
                Catch ex As Exception
                End Try
            Loop
            For Each key As String In Histdict.Keys
                Main.History_LB.Items.Add(key)
            Next
        Else
            File.Create(My.Computer.FileSystem.SpecialDirectories.Temp & "\AnimeStreamer\hist")
        End If
    End Sub
    Public Shared Sub AddHistory(EpName As String, EpLink As String)
        ConsoleCore.Report(Main.Console_box, "Adding " & EpName & " to the history list.", Color.Yellow)
        Try
            Histdict.Add(EpName, EpLink)
            SaveHist()
        Catch ex As Exception
            ConsoleCore.Report(Main.Console_box, "Failed to add " & EpName & " to History list.", Color.Red)
        End Try
    End Sub
   
    Public Shared Sub SaveHist()
        ConsoleCore.Report(Main.Console_box, "Saving History to file.", Color.Yellow)
        If File.Exists(My.Computer.FileSystem.SpecialDirectories.Temp & "\AnimeStreamer\hist") = True Then
            Dim myfile As String = My.Computer.FileSystem.SpecialDirectories.Temp & "\AnimeStreamer\hist"
            Dim mywriter As New IO.StreamWriter(myfile)
            For Each key As String In Histdict.Keys
                key = key.Replace(ControlChars.Lf, "")
                key = key.Replace(ControlChars.CrLf, "")
                key = key.Replace(ControlChars.Tab, "")
                key = key.Replace(vbNewLine, "")
                key.Replace("      ", "")
                mywriter.WriteLine(key & "~^~" & Histdict(key))
            Next

            mywriter.Close()
        End If

    End Sub
End Class
