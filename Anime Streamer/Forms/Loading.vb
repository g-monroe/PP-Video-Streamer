Public Class Loading
    Sub Checkversion()
        Try
            Dim request As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create("http://animestreamer.com.nu/version.txt")
            Dim response As System.Net.HttpWebResponse = request.GetResponse()

            Dim sr As System.IO.StreamReader = New System.IO.StreamReader(response.GetResponseStream())

            Dim newestversion As String = sr.ReadToEnd()
            Dim currentversion As String = Application.ProductVersion

            If newestversion.Contains(currentversion) Then
                Main.Opacity = 0
                Main.ShowInTaskbar = False
                Main.Show()
                Me.ShowInTaskbar = False
            Else
                Updater.Show()
                Me.Opacity = 0
                Me.ShowInTaskbar = False
            End If
        Catch ex As Exception
            Main.Opacity = 0
            Main.ShowInTaskbar = False
            Main.Show()
            Me.ShowInTaskbar = False
        End Try
    End Sub
    Public Sub CheckifDone()
        Home.LoadHome()
        Me.Refresh()
        Main.Opacity = 100
        Main.ShowInTaskbar = True
        Me.Opacity = 0
        Me.ShowInTaskbar = False
        Main.TopMost = True
        Main.TopMost = False
    End Sub

    Private Sub Loading_Load(sender As Object, e As EventArgs) Handles Me.Load
        Try
            System.IO.Directory.CreateDirectory(My.Computer.FileSystem.SpecialDirectories.Temp & "\AnimeStreamer")
        Catch ex As Exception

        End Try
        Settings.LoadSettings()
        Me.Status_lbl.Text = "Currently Loading: " & "Checking Internet"
        Status_lbl.Refresh()
        Prog.Value = 1
        Me.Refresh()
        If Not My.Computer.Network.IsAvailable = False Then
            Me.Status_lbl.Text = "Currently Loading: " & "Checking for update."
            Status_lbl.Refresh()
            Prog.Value = 2
            Me.Refresh()
            Checkversion()
        Else
            MsgBox("Sorry, but Internet is required to use this application!", MsgBoxStyle.Exclamation, "Sorry!")
            Environment.Exit(0)
        End If


    End Sub

End Class