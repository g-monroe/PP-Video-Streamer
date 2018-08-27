Public Class Home
    Public Shared Dict As New DictClass
    Public Shared Home_i As Integer
    Public Shared Row As Integer = 8
    Public Shared Col As Integer = 1000
    Public Shared Sub LoadHome()
        Try

            ' Me.Size = New Size(151, 201)
            Dim i As Integer = 0
            Dim NewLoc As New Point 'Location of Each New Block
            Dim Newsize As Size = New Size(151, 201)
            For CurrCol As Integer = 0 To Col
                For CurrRow As Integer = 0 To Row
                    i += 1
                    For Each itm As DictClass.Item In Dict.Items
                        If itm.OrderNumber = i Then
                            NewLoc.X = 20 + CurrRow * 164  'Height Of Block
                            NewLoc.Y = 20 + CurrCol * 211 'Width Of Block
                            Dim itm2 As New HomeItem
                            itm2.Location = NewLoc
                            itm2.Width = 151
                            itm2.Height = 201
                            itm2.URL = itm.URL_LINK
                            itm2._text = itm.Text
                            itm2.Showlink = itm.ShowLink
                            itm2.Type = itm.Type
                            AddHandler itm2.Clicked, AddressOf itm2_clickef
                            ' itm2.Text = CurrRow.ToString() & "_" & CurrCol.ToString
                            Main.Control_Base1.Controls.Add(itm2)
                        Else
                        End If
                    Next
                Next
            Next

        Catch ex As Exception

        End Try

    End Sub

    Private Shared Sub itm2_clickef(obj As String)
        Dim link As String = obj.Split("|").First
        Dim nam As String = obj.Split("|").Last
        If link.Contains("goodanime") Then
            Globals.ShowLink = link
            Globals.RecommendType = "Subbed"
            Main.Main_TabControl.SelectedIndex = 2
            Main.GroupRecommendations_GB.Visible = False
            Main.prog.Visible = False
            Main.progtext.Visible = False
            Main.TabSelector1.Refresh()
            Main.Name_lbl.Text = nam
            Main.Name_lbl.Refresh()
            Main.Type_lbl.Text = "Subbed"
            Main.Type_lbl.Refresh()
            Subbed.GoodAnimeDetails()
            Main.PanelBox3.Visible = True
        ElseIf link.Contains("animetoon") Then
            Globals.ShowLink = link
            Main.Name_lbl.Text = nam
            Main.Name_lbl.Refresh()
            Main.Type_lbl.Text = "Dubbed"
            Main.Type_lbl.Refresh()
            Main.Main_TabControl.SelectedIndex = 2
            Main.GroupRecommendations_GB.Visible = False
            Main.prog.Visible = False
            Main.progtext.Visible = False
            Main.TabSelector1.Refresh()
            Dubbed.AnimeToonShowPage()
            Main.PanelBox3.Visible = True
        End If
    End Sub
    Public Shared Sub MeasureandSetCol()
        Dim ScreenSizex As Integer = My.Computer.Screen.WorkingArea.Width.ToString
        Dim Itemwidth As Integer = 201
        Dim Wholnum As Double = ScreenSizex / Itemwidth
        Row = Filter.Roundnum(Wholnum)
    End Sub
    Public Shared Sub ClearControls()
        For CurrCol As Integer = 0 To Col
            For Each itm As HomeItem In Main.Main_TabControl.TabPages(0).Controls.OfType(Of HomeItem)()
                itm.Dispose()
            Next
        Next
    End Sub
End Class
