Imports System.IO

Public Class Favorites
    Public Shared Favdict As New Dictionary(Of String, String)()
    Public Shared Sub LoadFav()
        If File.Exists(My.Computer.FileSystem.SpecialDirectories.Temp & "\AnimeStreamer\Fav") Then
            Dim objreader As New StreamReader(My.Computer.FileSystem.SpecialDirectories.Temp & "\AnimeStreamer\Fav")
            Do While objreader.Peek() <> -1
                Try
                    Dim line As String

                    line = objreader.ReadLine() & vbNewLine
                    'MsgBox(line)
                    Dim namme = line.Split("~^~").First
                    Dim link = line.Split("~^~").Last
                    Favdict.Add(namme, link)
                Catch ex As Exception
                End Try
            Loop
            For Each key As String In Favdict.Keys
                Main.Favorites_LB.Items.Add(key)
            Next
        Else
            File.Create(My.Computer.FileSystem.SpecialDirectories.Temp & "\AnimeStreamer\Fav")
        End If
    End Sub
    Public Shared Sub AddFav(EpName As String, EpLink As String)
        Try
            ConsoleCore.Report(Main.Console_box, "Adding " & EpName & " to the favorites list.", Color.Yellow)
            Favdict.Add(EpName, EpLink)
            SaveFav()
        Catch ex As Exception
            ConsoleCore.Report(Main.Console_box, "Failed to add " & EpName & " to History list.", Color.Red)
        End Try
    End Sub
    Public Shared Sub SaveFav()
        ConsoleCore.Report(Main.Console_box, "Saving Favorites to file.", Color.Yellow)
        If File.Exists(My.Computer.FileSystem.SpecialDirectories.Temp & "\AnimeStreamer\Fav") = True Then
            Dim myfile As String = My.Computer.FileSystem.SpecialDirectories.Temp & "\AnimeStreamer\Fav"
            Dim mywriter As New IO.StreamWriter(myfile)
            For Each key As String In Favdict.Keys
                mywriter.WriteLine(key & "~^~" & Favdict(key))
            Next
            mywriter.Close()
        End If
    End Sub
End Class
