Public Class LoadingClass
    Public Shared Sub SetStatus(text As String, Precentage As Integer)
        Loading.Prog.Value = Precentage
        Loading.Status_lbl.Text = text
        Loading.Refresh()
        Loading.Status_lbl.Refresh()
    End Sub

    Public Shared Loading_PRW As Boolean = False
    Public Shared Loading_POP As Boolean = False
    Public Shared Loading_NRS As Boolean = False
    Public Shared Loading_OGS As Boolean = False
    Public Shared Sub CheckIfDone()
                        If Home_NRS.Done = True Then
                            If Home_OGS.Done = True Then
                                If Home_POP.Done = True Then
                                    If Home_PRW.Done = True Then
                                        Loading.CheckifDone()
                                    End If
                                End If
                            End If
                        End If
    End Sub
End Class
