Public Class UControl_Player
    Public Shared once As Boolean = False
    

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        'Try
        '    If Not Main.AxWindowsMediaPlayer1.fullScreen = True Then
        '        Main.AxWindowsMediaPlayer1.settings.volume = VolumeSlider1.Volume
        '    End If
        'Catch ex As Exception
        'End Try
        'If Main.AxWindowsMediaPlayer1.playState = WMPLib.WMPPlayState.wmppsPlaying Then
        '    AresioTrackBar1.Value = Main.AxWindowsMediaPlayer1.Ctlcontrols.currentPosition
        '    AresioTrackBar1.At = Main.AxWindowsMediaPlayer1.Ctlcontrols.currentPositionString
        '    AresioTrackBar1.Endd = Main.AxWindowsMediaPlayer1.currentMedia.durationString.ToString
        '    Player1.Destination = Main.AxWindowsMediaPlayer1.Ctlcontrols.currentPosition
        '    Player1.VolString = Main.AxWindowsMediaPlayer1.Ctlcontrols.currentPositionString
        '    If Player1.Destination >= Player1.Maxnum - 100 Then
        '        If once = False Then
        '            If Notifaction.Onoff = True Then
        '                Notifaction.Add("You finished the episode, Senpai notices you!", NotificationBox.Type.Success, Notifaction.Kind.BottomRight)
        '            End If
        '            once = True
        '        End If
        '    Else
        '        once = False
        '    End If
        '    Try
        '        Player1.VolString2 = Main.AxWindowsMediaPlayer1.currentMedia.durationString.ToString

        '    Catch ex As Exception

        '    End Try
        'End If
        'If Main.AxWindowsMediaPlayer1.fullScreen = False Then
        '    Try
        '        If Player1.Visible = True Then
        '            Main.AxWindowsMediaPlayer1.uiMode = "none"
        '        End If
        '    Catch ex As Exception
        '    End Try
        'End If
    End Sub

    Private Sub ThemeContainer1_FastForward(sender As Object) Handles Player1.FastForward
        'If Main.AxWindowsMediaPlayer1.Ctlcontrols.isAvailable("fastForward") Then
        '    Main.AxWindowsMediaPlayer1.Ctlcontrols.fastForward()
        'End If
    End Sub

    Private Sub ThemeContainer1_PlaystateChanged(sender As Object) Handles Player1.PlaystateChanged
        If Player1.PlayState2 = True Then
            '    Main.AxWindowsMediaPlayer1.Ctlcontrols.pause()
            'Else
            '    Main.AxWindowsMediaPlayer1.Ctlcontrols.play()
        End If
    End Sub



    Private Sub AresioTrackBar1_ClickedForward() Handles AresioTrackBar1.ClickedForward
        '  Main.AxWindowsMediaPlayer1.Ctlcontrols.currentPosition = AresioTrackBar1.Value
    End Sub

    Private Sub SoundCloudVolumeSlider1_VolumeChanged2(sender As Object) Handles VolumeSlider1.VolumeChanged2
        'Main.AxWindowsMediaPlayer1.settings.volume = VolumeSlider1.Volume
    End Sub

    Private Sub ThemeContainer1_Revious(sender As Object) Handles Player1.Revious
        ' If Main.AxWindowsMediaPlayer1.Ctlcontrols.isAvailable("fastReverse") Then

        'Main.AxWindowsMediaPlayer1.Ctlcontrols.fastReverse()

        ' End If
    End Sub
    '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    '\\\\\\\\\\\\\VLC Section\\\\\\\\\\\\\
    '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    'Private Enum InputState
    '    IDLE = 0
    '    OPENING = 1
    '    BUFFERING = 2
    '    PLAYING = 3
    '    PAUSED = 4
    '    STOPPING = 5
    '    ENDED = 6
    '    ERRORSTATE = 7
    'End Enum

    'Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
    '    Dim state As InputState = DirectCast(Main.AxVLCPlugin21.input.state, InputState)
    '    Try
    '        If Not Main.AxVLCPlugin21.video.fullscreen = True Then
    '            Main.AxVLCPlugin21.Volume = VolumeSlider1.Volume
    '        End If
    '    Catch ex As Exception
    '    End Try
    '    Select Case state
    '        Case InputState.IDLE, InputState.OPENING, InputState.BUFFERING
    '            Player1.StringStatus = state.ToString()
    '            Player1.PlayState2 = False
    '            Player1.Refresh()
    '            Exit Select
    '        Case InputState.PLAYING
    '            Dim title As String = System.IO.Path.GetFileName(Main.AxVLCPlugin21.mediaDescription.title)
    '            Dim current As TimeSpan = TimeSpan.FromMilliseconds(Main.AxVLCPlugin21.input.Time)
    '            Dim total As TimeSpan = TimeSpan.FromMilliseconds(Main.AxVLCPlugin21.input.Length)
    '            Dim pos As Double = Main.AxVLCPlugin21.input.Position
    '            Player1.StringStatus = String.Format("{0} {1} {2}:{3:D2}/{4}:{5:D2} {6:P}", state, title(0), current.Minutes, current.Seconds, total.Minutes, total.Seconds, pos)
    '            Player1.PlayState2 = True
    '            Player1.VolString = String.Format("{0}:{1:D2}", current.Minutes, current.Seconds)
    '            Player1.VolString2 = String.Format("{0}:{1:D2}", total.Minutes, total.Seconds)
    '            AresioTrackBar1.Maximum = total.Minutes * 60 + total.Seconds
    '            AresioTrackBar1.Value = current.Minutes * 60 + current.Seconds
    '            Player1.Destination = current.Minutes * 60 + current.Seconds
    '            AresioTrackBar1.At = String.Format("{0}:{1:D2}", current.Minutes, current.Seconds)
    '            AresioTrackBar1.Endd = String.Format("{0}:{1:D2}", total.Minutes, total.Seconds)
    '            Player1.Refresh()
    '            Dim amount As Integer = total.Minutes * 60 + total.Seconds
    '            If Player1.Destination >= amount - 100 Then
    '                If once = False Then
    '                    If Notifaction.Onoff = True Then
    '                        Notifaction.Add("You finished the episode, Senpai notices you!", NotificationBox.Type.Success, Notifaction.Kind.BottomRight)
    '                    End If
    '                    once = True
    '                End If
    '            Else
    '                once = False
    '            End If
    '            Exit Select
    '        Case InputState.PAUSED
    '            Player1.StringStatus = state.ToString()
    '            Player1.PlayState2 = False
    '            Player1.Refresh()
    '            Exit Select
    '        Case InputState.STOPPING, InputState.ENDED
    '            Player1.StringStatus = state.ToString()
    '            Player1.PlayState2 = False
    '            Player1.Refresh()

    '            Exit Select
    '        Case InputState.ERRORSTATE
    '            Player1.StringStatus = state.ToString()
    '            Player1.PlayState2 = False
    '            Player1.Refresh()
    '            Exit Select
    '        Case Else
    '            Player1.StringStatus = state.ToString()
    '            Exit Select
    '    End Select
    'End Sub
    'Dim rate As Integer = 1
    'Private Sub AresioTrackBar1_ClickedForward() Handles AresioTrackBar1.ClickedForward
    '    Main.AxVLCPlugin21.input.Time = AresioTrackBar1.Value & "000"
    'End Sub
    'Private Sub Player1_FastForward(sender As Object) Handles Player1.FastForward
    '    rate += 1
    '    Main.AxVLCPlugin21.input.rate = rate
    '    Main.AxVLCPlugin21.playlist.play()
    'End Sub

    'Private Sub Player11_MousDestinationChanged(sender As Object) Handles Player1.MousDestinationChanged
    '    Main.AxVLCPlugin21.playlist.pause()
    '    Main.AxVLCPlugin21.input.Time = Player1.Destination
    'End Sub

    'Private Sub Player1_PlaystateChanged(sender As Object) Handles Player1.PlaystateChanged
    '    rate = 1
    '    Main.AxVLCPlugin21.input.rate = rate
    '    If Player1.PlayState2 = True Then
    '        Main.AxVLCPlugin21.playlist.play()
    '    Else
    '        Main.AxVLCPlugin21.playlist.pause()
    '    End If
    'End Sub


    'Private Sub VolumeSlider1_VolumeChanged2(sender As Object) Handles VolumeSlider1.VolumeChanged2
    '    Main.AxVLCPlugin21.Volume = VolumeSlider1.Volume
    'End Sub


    'Private Sub ThemeContainer1_VolumeChanged2(sender As Object)

    'End Sub
End Class
