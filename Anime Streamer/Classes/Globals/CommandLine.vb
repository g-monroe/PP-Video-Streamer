'Imports IWshRuntimeLibrary
'Imports System.IO
'Imports Microsoft.WindowsAPICodePack.Shell
'Imports Microsoft.WindowsAPICodePack.Taskbar
'Imports System.Reflection

'Public Class CommandLine
'    Public Shared Sub Reader()
'        If Command$() <> "" Then
'            Dim com As String = Command$()
'            com = com.Replace("- ", "")
'            If com.Contains("goodanime") Then
'                Globals.EpisodeLink = com
'                'MsgBox(Globals.EpisodeLink)
'                Subbed.GoodAnimeParse()
'                Main.KoboTabControlS1.SelectedIndex = 0
'                Main.Main_TabControl.SelectedIndex = 1
'                Main.TabSelector1.Tab2_Sel = True
'                Main.TabSelector1.Tab1_Sel = False
'                Main.TabSelector1.Tab3_Sel = False
'                Main.TabSelector1.Tab4_Sel = False
'                Main.TabSelector1.Refresh()
'            ElseIf com.Contains("animetoon") Then
'                Globals.EpisodeLink = com
'                'MsgBox(Globals.EpisodeLink)
'                Dubbed.AnimeToonParse()
'                Main.KoboTabControlS1.SelectedIndex = 0
'                Main.Main_TabControl.SelectedIndex = 1
'                Main.TabSelector1.Tab2_Sel = True
'                Main.TabSelector1.Tab1_Sel = False
'                Main.TabSelector1.Tab3_Sel = False
'                Main.TabSelector1.Tab4_Sel = False
'                Main.TabSelector1.Refresh()
'            End If
'        End If
'    End Sub
'    Public Shared Sub Clear()
'        Dim files() As String = IO.Directory.GetFiles(My.Computer.FileSystem.SpecialDirectories.Temp & "\AnimeStreamer\")
'        For Each file As String In files
'            If file.Contains(".lnk") Then
'                IO.File.Delete(file)
'            End If
'        Next
'    End Sub
'    Public Shared Arrylist As New Dictionary(Of String, String)
'    Public Shared Sub Save()
'        Clear()
'        Dim i As String = 0
'        For Each key As String In History.Histdict.Keys
'            i += 1
'        Next
'        If i > 5 Then
'            Try
'                Dim tempi1 As String = i - 5
'                Dim tempi2 As String = i - 4
'                Dim tempi3 As String = i - 3
'                Dim tempi4 As String = i - 2
'                Dim tempi5 As String = i + 1
'                Dim i2 As String = 0
'                For Each key As String In History.Histdict.Keys
'                    i2 += 1
'                    If tempi1 = i2 Then
'                        Arrylist.Add(History.Histdict(key), key)
'                    End If
'                    If tempi2 = i2 Then
'                        Arrylist.Add(History.Histdict(key), key)
'                    End If
'                    If tempi3 = i2 Then
'                        Arrylist.Add(History.Histdict(key), key)
'                    End If
'                    If tempi4 = i2 Then
'                        Arrylist.Add(History.Histdict(key), key)
'                    End If
'                    If tempi5 = i2 Then
'                        Arrylist.Add(History.Histdict(key), key)
'                    End If
'                Next
'                SaveJumpList()
'            Catch ex As Exception

'            End Try
'        End If
'    End Sub
'    Public Shared Sub SaveJumpList()

'        Dim jplst As JumpList = JumpList.CreateJumpList()
'        jplst.ClearAllUserTasks()

'        Dim myapppath As String = System.Reflection.Assembly.GetExecutingAssembly().GetName().CodeBase
'        myapppath = myapppath.Replace("file:///", "")
'        myapppath = myapppath.Replace("/", "\")
'        myapppath = myapppath.Replace(".EXE", ".exe")
'        Dim category As JumpListCustomCategory = New JumpListCustomCategory("History")
'        jplst.AddCustomCategories(category)
'        Try

'            For Each key As String In Arrylist.Keys

'                Dim myshortcut As IWshShortcut
'                Dim wsh As New WshShell
'                myshortcut = CType(wsh.CreateShortcut(My.Computer.FileSystem.SpecialDirectories.Temp & "\AnimeStreamer\" & Arrylist(key) & ".lnk"), IWshShortcut)
'                With myshortcut
'                    .TargetPath = myapppath
'                    .Arguments = key
'                    .WindowStyle = 1
'                    .Description = Arrylist(key)
'                    .IconLocation = myapppath
'                    .Save()
'                End With
'                Dim TaskLink As JumpListLink = New JumpListLink(My.Computer.FileSystem.SpecialDirectories.Temp & "\AnimeStreamer\" & Arrylist(key) & ".lnk", Arrylist(key))
'                TaskLink.IconReference = New IconReference(myapppath, 0)
'                category.AddJumpListItems(TaskLink)

'                jplst.Refresh()
'            Next
'        Catch ex As Exception
'            MsgBox(ex.ToString)
'        End Try

'    End Sub
'End Class
