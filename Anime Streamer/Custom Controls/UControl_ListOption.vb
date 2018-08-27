Public Class UControl_ListOption

    Private Sub Add_Button_Click(sender As Object, e As EventArgs) Handles Add_Button.Click
        Dim cms = New ContextMenuStrip
        Dim MousePosition As Point
        cms.BackColor = Color.FromArgb(28, 28, 28, 28)
        MousePosition = Cursor.Position
        Dim item1 = cms.Items.Add("Watching (Quick Add)")
        item1.Tag = 1
        item1.BackColor = Color.FromArgb(28, 28, 28)
        item1.ForeColor = Color.White
        Dim item2 = cms.Items.Add("History Add All")
        item2.Tag = 9
        item2.BackColor = Color.FromArgb(28, 28, 28)
        item2.ForeColor = Color.White
        Dim item3 = cms.Items.Add("Favorites Add All")
        item3.Tag = 10
        item3.BackColor = Color.FromArgb(28, 28, 28)
        item3.ForeColor = Color.White
        Dim dropdownitem = DirectCast(cms.Items(0), ToolStripMenuItem).DropDownItems.Add("Monday")
        dropdownitem.Tag = 2
        dropdownitem.BackColor = Color.FromArgb(28, 28, 28)
        dropdownitem.ForeColor = Color.White
        Dim dropdownitem2 = DirectCast(cms.Items(0), ToolStripMenuItem).DropDownItems.Add("Tuesday")
        dropdownitem2.Tag = 3
        dropdownitem2.BackColor = Color.FromArgb(28, 28, 28)
        dropdownitem2.ForeColor = Color.White
        Dim dropdownitem3 = DirectCast(cms.Items(0), ToolStripMenuItem).DropDownItems.Add("Wednesday")
        dropdownitem3.Tag = 4
        dropdownitem3.BackColor = Color.FromArgb(28, 28, 28)
        dropdownitem3.ForeColor = Color.White
        Dim dropdownitem4 = DirectCast(cms.Items(0), ToolStripMenuItem).DropDownItems.Add("Thursday")
        dropdownitem4.Tag = 5
        dropdownitem4.BackColor = Color.FromArgb(28, 28, 28)
        dropdownitem4.ForeColor = Color.White
        Dim dropdownitem5 = DirectCast(cms.Items(0), ToolStripMenuItem).DropDownItems.Add("Friday")
        dropdownitem5.Tag = 6
        dropdownitem5.BackColor = Color.FromArgb(28, 28, 28)
        dropdownitem5.ForeColor = Color.White
        Dim dropdownitem6 = DirectCast(cms.Items(0), ToolStripMenuItem).DropDownItems.Add("Saturday")
        dropdownitem6.Tag = 7
        dropdownitem6.BackColor = Color.FromArgb(28, 28, 28)
        dropdownitem6.ForeColor = Color.White
        Dim dropdownitem7 = DirectCast(cms.Items(0), ToolStripMenuItem).DropDownItems.Add("Sunday")
        dropdownitem7.Tag = 8
        dropdownitem7.BackColor = Color.FromArgb(28, 28, 28)
        dropdownitem7.ForeColor = Color.White
        AddHandler item1.Click, AddressOf menuChoice
        AddHandler item2.Click, AddressOf menuChoice
        AddHandler item3.Click, AddressOf menuChoice
        AddHandler dropdownitem.Click, AddressOf menuChoice
        AddHandler dropdownitem2.Click, AddressOf menuChoice
        AddHandler dropdownitem3.Click, AddressOf menuChoice
        AddHandler dropdownitem4.Click, AddressOf menuChoice
        AddHandler dropdownitem5.Click, AddressOf menuChoice
        AddHandler dropdownitem6.Click, AddressOf menuChoice
        AddHandler dropdownitem7.Click, AddressOf menuChoice
        cms.Show(Me, MousePosition)
    End Sub

    Private Sub menuChoice(sender As Object, e As EventArgs)
        Dim item = CType(sender, ToolStripMenuItem)
        Dim selection = CInt(item.Tag)
        If selection = 1 Then
            Watching.AddWat(Main.Name_lbl.Text, Globals.ShowLink, "QuickAdded")
        End If
        If selection = 2 Then
            Watching.AddWat(Main.Name_lbl.Text, Globals.ShowLink, "Monday")
        End If
        If selection = 3 Then
            Watching.AddWat(Main.Name_lbl.Text, Globals.ShowLink, "Tuesday")
        End If
        If selection = 4 Then
            Watching.AddWat(Main.Name_lbl.Text, Globals.ShowLink, "Wednesday")
        End If
        If selection = 5 Then
            Watching.AddWat(Main.Name_lbl.Text, Globals.ShowLink, "Thursday")
        End If
        If selection = 6 Then
            Watching.AddWat(Main.Name_lbl.Text, Globals.ShowLink, "Friday")
        End If
        If selection = 7 Then
            Watching.AddWat(Main.Name_lbl.Text, Globals.ShowLink, "Saturday")
        End If
        If selection = 8 Then
            Watching.AddWat(Main.Name_lbl.Text, Globals.ShowLink, "Sunday")
        End If
        If selection = 9 Then
            For Each itm As NSListView.NSListViewItem In Main.NsListView1.Items
                If itm.Watched = False Then
                    itm.Watched = True
                    Main.NsListView1.Refresh()
                End If
            Next
            Main.NsListView1.Refresh()
        End If
        If selection = 10 Then
            For Each itm As NSListView.NSListViewItem In Main.NsListView1.Items
                If itm.Favorited = False Then
                    itm.Favorited = True
                    Main.NsListView1.Refresh()
                End If
            Next
            Main.NsListView1.Refresh()
        End If
    End Sub

    Private Sub UControl_ListOption_Load(sender As Object, e As EventArgs) Handles Me.Load
        Location = New Point(113 + 207, 0)
    End Sub

    Private Sub Remove_Button_Click(sender As Object, e As EventArgs) Handles Remove_Button.Click
        Watching.RemoveWat(Main.Name_lbl.Text, Globals.ShowLink, "Remove")
    End Sub
    
End Class
