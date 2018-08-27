Imports System.Net

Public Class Updater

    Private Sub TagLabel1_Click(sender As Object, e As EventArgs) Handles TagLabel1.Click
        If Not TagLabel1.TagMainColor = Color.FromArgb(120, 120, 120) Then
            If Not WMP.Checked = True Then
                If System.IO.File.Exists(My.Computer.FileSystem.SpecialDirectories.Temp & "\update.zip") Then
                    System.IO.File.Delete(My.Computer.FileSystem.SpecialDirectories.Temp & "\update.zip")
                    httpclient = New WebClient
                    AddHandler httpclient.DownloadFileCompleted, AddressOf DownloadedVLC
                    httpclient.DownloadFileAsync(New Uri("http://animestreamer.com.nu/VLC/update.zip"), (My.Computer.FileSystem.SpecialDirectories.Temp & "\update.zip"))
                Else
                    httpclient = New WebClient
                    AddHandler httpclient.DownloadFileCompleted, AddressOf DownloadedVLC
                    httpclient.DownloadFileAsync(New Uri("http://animestreamer.com.nu/VLC/update.zip"), (My.Computer.FileSystem.SpecialDirectories.Temp & "\update.zip"))
                End If
            Else
                If System.IO.File.Exists(My.Computer.FileSystem.SpecialDirectories.Temp & "\update.zip") Then
                    System.IO.File.Delete(My.Computer.FileSystem.SpecialDirectories.Temp & "\update.zip")
                    httpclient = New WebClient
                    AddHandler httpclient.DownloadFileCompleted, AddressOf DownloadedWMP
                    httpclient.DownloadFileAsync(New Uri("http://animestreamer.com.nu/WMP/update.zip"), (My.Computer.FileSystem.SpecialDirectories.Temp & "\update.zip"))
                Else
                    httpclient = New WebClient
                    AddHandler httpclient.DownloadFileCompleted, AddressOf DownloadedWMP
                    httpclient.DownloadFileAsync(New Uri("http://animestreamer.com.nu/WMP/update.zip"), (My.Computer.FileSystem.SpecialDirectories.Temp & "\update.zip"))
                End If
            End If
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If Not WMP.Checked = True Then
            If Not VLC.Checked = True Then
                TagLabel1.TagMainColor = Color.FromArgb(120, 120, 120)
                TagLabel1.Tag3D = False
                TagLabel1.Refresh()
            Else
                TagLabel1.TagMainColor = Color.FromArgb(251, 83, 150)
                TagLabel1.Tag3D = True
                TagLabel1.Refresh()
            End If
        Else
            TagLabel1.TagMainColor = Color.FromArgb(251, 83, 150)
            TagLabel1.Tag3D = True
            TagLabel1.Refresh()
        End If
    End Sub

    Private Sub Updater_Load(sender As Object, e As EventArgs) Handles Me.Load
        Dim wb As New WebClient
        AddHandler wb.DownloadStringCompleted, AddressOf Wb_DSC
        Try
            wb.DownloadStringAsync(New Uri("http://animestreamer.com.nu/updatename"))
        Catch ex As Exception
            Status_lbl.Text = "Update:1.0.0.0"
        End Try
        Dim wb2 As New WebClient
        AddHandler wb2.DownloadStringCompleted, AddressOf Wb2_DSC

        Try
            wb2.DownloadStringAsync(New Uri("http://animestreamer.com.nu/updatelog"))
        Catch ex As Exception
            RichTextBox1.Text = "- No Update Information"
        End Try
    End Sub
    Private Sub Wb_DSC(sender As Object, e As DownloadStringCompletedEventArgs)
        Status_lbl.Text = e.Result
        Me.Refresh()
    End Sub

    Private Sub Wb2_DSC(sender As Object, e As DownloadStringCompletedEventArgs)
        RichTextBox1.Text = e.Result
    End Sub

    Private WithEvents httpclient As WebClient

    Private Sub dpc(ByVal sender As Object, ByVal e As System.Net.DownloadProgressChangedEventArgs) Handles httpclient.downloadprogresschanged
        Prog.Value = e.ProgressPercentage
    End Sub

    Private Sub DownloadedVLC()
        If System.IO.File.Exists(My.Computer.FileSystem.SpecialDirectories.Temp & "\update.zip") = True Then
            Process.Start(My.Computer.FileSystem.SpecialDirectories.Temp & "\update.zip")
        Else

        End If
        Application.Exit()
    End Sub
    Private Sub DownloadedWMP()
        If System.IO.File.Exists(My.Computer.FileSystem.SpecialDirectories.Temp & "\update.zip") = True Then
            Process.Start(My.Computer.FileSystem.SpecialDirectories.Temp & "\update.zip")
        Else

        End If
        Application.Exit()
    End Sub

    Private Sub TagLabel2_Click(sender As Object, e As EventArgs) Handles TagLabel2.Click
        Loading.Close()
    End Sub
End Class