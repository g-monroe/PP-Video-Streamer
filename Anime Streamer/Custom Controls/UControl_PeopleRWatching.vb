Imports System.Threading

Public Class UControl_PeopleRWatching
    Public ShowLink As String
    Public ShowPicture As String
    Public ShowName As String
    Dim nt As Threading.Thread
    Public Sub NewThreadOut()
        nt = New Thread(AddressOf GoOut)
        nt.SetApartmentState(ApartmentState.STA)
        nt.IsBackground = True
        nt.Start()
    End Sub
#Region "Animation in/out"
    Public JustPic As Size = New Size(77, Me.Height)
    Public Details As Size = New Size(165, Me.Height)
    Private Sub Watch_MouseEnter(sender As Object, e As EventArgs) Handles Watch_bt.MouseEnter
        Check()
        Tmr_out.Start()
        Tmr_in.Stop()
    End Sub
    Public Sub GoOut()
        If Not Tmr_in.Enabled = True Then
            If Not Me.Size.Width >= Details.Width Then
                Me.Width = Me.Width + 3
                Me.Refresh()
            Else
                Tmr_out.Stop()
            End If
        End If
    End Sub
    Private Sub Tmr_out_Tick(sender As Object, e As EventArgs) Handles Tmr_out.Tick
        GoOut()
    End Sub
    Private Sub Picture_PB_MouseEnter(sender As Object, e As EventArgs) Handles Picture_PB.MouseEnter
        Check()
        Tmr_out.Start()
        Tmr_in.Stop()
    End Sub
    Private Sub TagLabel1_MouseLeave(sender As Object, e As EventArgs) Handles TagLabel1.MouseLeave
        Check()
        Tmr_in.Start()
        Tmr_out.Stop()
    End Sub
    Private Sub Tmr_in_Tick(sender As Object, e As EventArgs) Handles Tmr_in.Tick
        If Not Me.Size.Width <= JustPic.Width Then
            Me.Width = Me.Width - 3
            Me.Refresh()
        Else
            Tmr_in.Stop()
        End If
    End Sub

    Private Sub Name_RTB_MouseEnter(sender As Object, e As EventArgs) Handles Name_RTB.MouseEnter
        Check()
        Tmr_out.Start()
        Tmr_in.Stop()
    End Sub
#End Region
#Region "Round Rectangle Function"
    Private Function RoundedRec(ByVal X As Integer, ByVal Y As Integer, ByVal Width As Integer, ByVal Height As Integer) As System.Drawing.Drawing2D.GraphicsPath
        ' Make and Draw a path.
        Dim graphics_path As New System.Drawing.Drawing2D.GraphicsPath
        graphics_path.AddLine(X + 10, Y, X + Width, Y) 'add the Top line to the path

        'Top Right corner        
        Dim tr() As Point = { _
        New Point(X + Width, Y), _
        New Point((X + Width) + 4, Y + 2), _
        New Point((X + Width) + 8, Y + 6), _
        New Point((X + Width) + 10, Y + 10)}

        graphics_path.AddCurve(tr)  'Add the Top right curve to the path

        'Bottom right corner 
        Dim br() As Point = { _
        New Point((X + Width) + 10, Y + Height), _
        New Point((X + Width) + 8, (Y + Height) + 4), _
        New Point((X + Width) + 4, (Y + Height) + 8), _
        New Point(X + Width, (Y + Height) + 10)}

        graphics_path.AddCurve(br)  'Add the Bottom right curve to the path

        'Bottom left corner
        Dim bl() As Point = { _
        New Point(X + 10, (Y + Height) + 10), _
        New Point(X + 6, (Y + Height) + 8), _
        New Point(X + 2, (Y + Height) + 4), _
        New Point(X, Y + Height)}

        graphics_path.AddCurve(bl)  'Add the Bottom left curve to the path

        'Top left corner
        Dim tl() As Point = { _
        New Point(X, Y + 10), _
        New Point(X + 2, Y + 6), _
        New Point(X + 6, Y + 2), _
        New Point(X + 10, Y)}

        graphics_path.AddCurve(tl)  'add the Top left curve to the path

        Return graphics_path

    End Function
#End Region
    Private Sub Watch_bt_Click(sender As Object, e As EventArgs) Handles Watch_bt.Click
        Globals.ShowLink = ShowLink
        Dubbed.AnimeToonShowPage()
        Main.Main_TabControl.SelectedIndex = 2
             Main.GroupRecommendations_GB.Visible = False
        Main.prog.Visible = False
        Main.progtext.Visible = False
        Main.Name_lbl.Text = ShowName
        Main.Name_lbl.Refresh()
        Main.Type_lbl.Text = "Dubbed"
        Main.Type_lbl.Refresh()
        Main.PanelBox3.Visible = True
        For Each uc As UControl_AnimeSelector In Main.Controls.OfType(Of UControl_AnimeSelector)()
            uc.Toggle1.onoff = False
        Next
    End Sub

    Private Sub UControl_PeopleRWatching_Load(sender As Object, e As EventArgs) Handles Me.Load
        Picture_PB.Region = New Region(RoundedRec(0, 0, Picture_PB.Width - 10, Picture_PB.Height - 10))
    End Sub
    Public Sub Check()
        'For Each VI As UControl_PeopleRWatching In Main.PRW_TC.TabPages(0).Controls.OfType(Of UControl_PeopleRWatching)()
        '    If Not VI.ShowLink = ShowLink Then
        '        VI.Tmr_Check.Stop()
        '        If Not VI.Tmr_out.Enabled = False Then
        '            VI.Tmr_out.Stop()
        '        End If
        '        If Not VI.Tmr_in.Enabled = False Then
        '            VI.Tmr_in.Stop()
        '        End If
        '        If Not VI.Size = JustPic Then
        '            VI.Size = JustPic
        '        End If
        '    End If
        'Next
    End Sub
   
    Private Sub UControl_PeopleRWatching_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        Picture_PB.Region = New Region(RoundedRec(0, 0, Picture_PB.Width - 10, Picture_PB.Height - 10))
    End Sub
End Class
