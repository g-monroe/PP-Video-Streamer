Public Class Parser_VideoWing
    Public Shared Source As String
    Public Shared Webb As New WebBrowser
    Public Shared Sub GetSource(vidlink As String)
        Webb = New WebBrowser
        Webb.ScriptErrorsSuppressed = True
        AddHandler Webb.DocumentCompleted, AddressOf webb_doccom
        If vidlink.Contains("w=") Then
            Dim temp As String = vidlink.Replace("w=718&#038;h=438&#038;", "")
            temp = temp.Replace("w=718&amp;h=438&amp;", "")
            temp = temp.Replace("&amp;", "")
            Webb.Navigate(temp)
        Else
            Webb.Navigate(vidlink)
        End If
    End Sub
    Public Shared Sub webb_doccom(sender As Object, e As WebBrowserDocumentCompletedEventArgs)
        Try
            Source = Webb.Document.Body.InnerHtml
            ' MsgBox(Source)
            Dim temp As String = Filter.getBetween(Source, "_url = ", Chr(34) & ";")
            ' MsgBox(temp)
            System.Threading.Thread.Sleep(25) '<- for some reason this stops it from opening the link in the browser.... don't know why... it is opening in the browser in the first place
            temp = temp.Replace(Chr(34), "")
            temp = temp.Replace("%3A", ":")
            temp = temp.Replace("%2F", "/")
            temp = temp.Replace("%3F", "?")
            temp = temp.Replace("%3D", "=")
            temp = temp.Replace("%26", "&")
            ' temp = temp.Split("?"c).First
            ' MsgBox(temp)
            Globals.StreamLink = temp
            ParserCore.SetStream(Globals.StreamLink)
            Webb.Dispose()
        Catch ex As Exception
            If Not Evulate.VL1 = True Then
                Evulate.VideoLink1()
                Evulate.VL1 = True
            ElseIf Not Evulate.VL2 = True Then
                Evulate.VideoLink2()
                Evulate.VL2 = True
            ElseIf Not Evulate.VL3 = True Then
                Evulate.VideoLink3()
                Evulate.VL3 = True
            ElseIf Not Evulate.VL4 = True Then
                Evulate.VideoLink4()
                Evulate.VL4 = True
            End If
        End Try
    End Sub
End Class
