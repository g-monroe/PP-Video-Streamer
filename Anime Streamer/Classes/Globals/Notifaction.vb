Public Class Notifaction
    Public Shared Onoff As Boolean = True
    Public Enum Kind
        TopRight = 0
        TopLeft = 1
        BottomLeft = 2
        BottomRight = 3
    End Enum
    Public Shared frm As New Form
    Public Shared note As New NotificationBox
    Public Shared pos As Kind
    Public Shared tmr As New Timer
    Public Shared Sub Add(Txt As String, Type As NotificationBox.Type, Position As Kind)
        If Onoff = True Then
            frm = New Form
            frm.Name = "Note"
            frm.ShowInTaskbar = False
            frm.FormBorderStyle = FormBorderStyle.None
            note = New NotificationBox
            note.NotificationType = Type
            note.Text = Txt
            note.RoundedCorners = False
            note.Dock = DockStyle.Fill
            'AddHandler note.MouseHover, AddressOf note_MH
            'AddHandler note.MouseLeave, AddressOf note_ML
            'tmr = New Timer
            'tmr.Interval = 1000
            'tmr.Enabled = True
            'AddHandler tmr.Tick, AddressOf tmr_tick
            frm.Size = New Point(280, 80)
            pos = Position
            frm.Controls.Add(note)
            AddHandler frm.Load, AddressOf frm_load
            frm.Show()
            frm.TopMost = True

        End If
    End Sub

    Public Shared Sub frm_load(sender As Object, e As EventArgs)
        Dim x As Integer = 0
        Dim y As Integer = 0
        If pos = Kind.BottomLeft Then
            y = Screen.PrimaryScreen.WorkingArea.Height - frm.Height
            x = 0
            frm.Location = New Size(x, y)
        ElseIf pos = Kind.BottomRight Then
            y = Screen.PrimaryScreen.WorkingArea.Height - frm.Height
            x = Screen.PrimaryScreen.WorkingArea.Width - frm.Width
            frm.Location = New Point(x, y)
        ElseIf pos = Kind.TopLeft Then
            y = 0
            x = 0
            frm.Location = New Point(x, y)
        ElseIf pos = Kind.TopRight Then
            y = 0
            x = Screen.PrimaryScreen.WorkingArea.Width - frm.Width
            frm.Location = New Point(x, y)
        End If
    End Sub
    Public Shared Sub ShowTime()
        If Settings.ShowTimeEvents = True Then
            Dim thisCulture = Globalization.CultureInfo.CurrentCulture
            Dim dayOfWeek As DayOfWeek = thisCulture.Calendar.GetDayOfWeek(Date.Today)
            For Each key As String In Watching.Dict.Keys
                For Each key2 As String In Watching.SubDict.Keys
                    If Watching.Dict(key) = Watching.SubDict(key2) Then
                        If key2.Contains("Monday") Then
                            If dayOfWeek.ToString.Contains("Monday") Then
                                Notifaction.Add("An Episode of " & Chr(34) & key & Chr(34) & " premieres today!", NotificationBox.Type.Warning, Kind.BottomRight)
                            End If
                        End If
                        If key2.Contains("Tuesday") Then
                            If dayOfWeek.ToString.Contains("Tuesday") Then
                                Notifaction.Add("An Episode of " & Chr(34) & key & Chr(34) & " premieres today!", NotificationBox.Type.Warning, Kind.BottomRight)
                            End If
                        End If
                        If key2.Contains("Wednesday") Then
                            If dayOfWeek.ToString.Contains("Wednesday") Then
                                Notifaction.Add("An Episode of " & Chr(34) & key & Chr(34) & " premieres today!", NotificationBox.Type.Warning, Kind.BottomRight)
                            End If
                        End If
                        If key2.Contains("Thursday") Then
                            If dayOfWeek.ToString.Contains("Thursday") Then
                                Notifaction.Add("An Episode of " & Chr(34) & key & Chr(34) & " premieres today!", NotificationBox.Type.Warning, Kind.BottomRight)
                            End If
                        End If
                        If key2.Contains("Friday") Then
                            If dayOfWeek.ToString.Contains("Friday") Then
                                Notifaction.Add("An Episode of " & Chr(34) & key & Chr(34) & " premieres today!", NotificationBox.Type.Warning, Kind.BottomRight)
                            End If
                        End If
                        If key2.Contains("Saturday") Then
                            If dayOfWeek.ToString.Contains("Saturday") Then
                                Notifaction.Add("An Episode of " & Chr(34) & key & Chr(34) & " premieres today!", NotificationBox.Type.Warning, Kind.BottomRight)
                            End If
                        End If
                        If key2.Contains("Sunday") Then
                            If dayOfWeek.ToString.Contains("Sunday") Then
                                Notifaction.Add("An Episode of " & Chr(34) & key & Chr(34) & " premieres today!", NotificationBox.Type.Warning, Kind.BottomRight)
                            End If
                        End If
                    End If
                Next
            Next
        End If
    End Sub
    'Public Shared i59 As New Integer
    'Public Shared Sub tmr_tick(sender As Object, e As EventArgs)
    '    If i59 = 0 Then
    '        tmr.Interval = 100
    '        Try
    '            frm.Opacity -= 5
    '        Catch ex As Exception
    '            frm.Close()
    '        End Try
    '    Else
    '        i59 -= 1
    '        frm.Opacity = 100
    '    End If
    'End Sub

    'Private Shared Sub note_ML(sender As Object, e As EventArgs)
    '    tmr.Interval = 1000
    '    tmr.Start()
    '    i59 = 0
    '    frm.Opacity = 100
    'End Sub

    'Private Shared Sub note_MH(sender As Object, e As EventArgs)
    '    tmr.Stop()
    '    tmr.Interval = 1000
    '    i59 = 0
    '    frm.Opacity = 100
    'End Sub

End Class
