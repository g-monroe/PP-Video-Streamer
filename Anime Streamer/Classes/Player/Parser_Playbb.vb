Public Class Parser_Playbb
    Public Shared Source As String
    Public Shared WithEvents BackgroundWorker1 As New System.ComponentModel.BackgroundWorker
    Public Shared Sub GetSource(vidlink As String)
        If vidlink.Contains("w=718&#038;h=438&#038;") Then
            Dim temp As String = vidlink.Replace("w=718&#038;h=438&#038;", "")
            temp = temp.Replace("w=718&amp;h=438&amp;", "")
            temp = temp.Replace("&amp;", "")
            Dim GSMObject As New GetSourcee
            GSMObject.Typ = GetSourcee.Type.WebRequest
            GSMObject.Vidlin = temp
            If (BackgroundWorker1.IsBusy = True) Then
                Try
                    BackgroundWorker1.CancelAsync()
                    BackgroundWorker1.RunWorkerAsync(GSMObject)
                Catch ex As Exception
                End Try
            Else
                BackgroundWorker1.RunWorkerAsync(GSMObject)
            End If
        Else
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
        End If

    End Sub
    Public Shared Sub BackgroundWorker1_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs) Handles BackgroundWorker1.DoWork
        Dim GetSourcee2 As GetSourcee = CType(e.Argument, GetSourcee)
        e.Result = GetSourcee.GetSource(GetSourcee2.Vidlin, GetSourcee2.Typ)
    End Sub
    Public Shared Sub BackgroundWorker1_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs) Handles BackgroundWorker1.RunWorkerCompleted
        Try
            Source = e.Result
            ' MsgBox(Source)
            Dim temp As String = Filter.getBetween(Source, "_url = ", Chr(34) & ";")
            ' MsgBox(temp)
            temp = temp.Replace(Chr(34), "")
            temp = temp.Replace("%3A", ":")
            temp = temp.Replace("%2F", "/")
            temp = temp.Replace("%3F", "?")
            temp = temp.Replace("%3D", "=")
            temp = temp.Replace("%26", "&")
            ' temp = temp.Split("?"c).First
            Globals.StreamLink = temp
            ParserCore.SetStream(Globals.StreamLink)
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
