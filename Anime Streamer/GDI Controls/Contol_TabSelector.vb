Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms

Namespace SoundcloudPlayer
    Friend Class Tabselector
        Inherits Control
        ' Methods
        Public Sub New()
            'SoundCloudWaveForm.__ENCAddToList(Me)
            Me._CurrentPosition = 0
            Me._ContentLength = 1
            Me.X = -1
            Me.DoubleBuffered = True
            Me.SetStyle((ControlStyles.OptimizedDoubleBuffer Or (ControlStyles.SupportsTransparentBackColor Or ControlStyles.UserPaint)), True)
            Me.BackColor = Color.Transparent
        End Sub
        Public Event Tab1_Clicked(ByVal sender As Object)
        Public Event Tab2_Clicked(ByVal sender As Object)
        Public Event Tab3_Clicked(ByVal sender As Object)
        Public Event Tab4_Clicked(ByVal sender As Object)
        '<DebuggerNonUserCode> _
        'Private Shared Sub __ENCAddToList(ByVal value As Object)
        '    Dim list As List(Of WeakReference) = SoundCloudWaveForm.__ENCList
        '    SyncLock list
        '        If (SoundCloudWaveForm.__ENCList.Count = SoundCloudWaveForm.__ENCList.Capacity) Then
        '            Dim index As Integer = 0
        '            Dim num3 As Integer = (SoundCloudWaveForm.__ENCList.Count - 1)
        '            Dim i As Integer = 0
        '            Do While (i <= num3)
        '                Dim reference As WeakReference = SoundCloudWaveForm.__ENCList.Item(i)
        '                If reference.IsAlive Then
        '                    If (i <> index) Then
        '                        SoundCloudWaveForm.__ENCList.Item(index) = SoundCloudWaveForm.__ENCList.Item(i)
        '                    End If
        '                    index += 1
        '                End If
        '                i += 1
        '            Loop
        '            SoundCloudWaveForm.__ENCList.RemoveRange(index, (SoundCloudWaveForm.__ENCList.Count - index))
        '            SoundCloudWaveForm.__ENCList.Capacity = SoundCloudWaveForm.__ENCList.Count
        '        End If
        '        SoundCloudWaveForm.__ENCList.Add(New WeakReference(RuntimeHelpers.GetObjectValue(value)))
        '    End SyncLock
        'End Sub

        Protected Overrides Sub OnMouseLeave(ByVal e As EventArgs)
            Me.X = -1
            Me.Invalidate()
            MyBase.OnMouseLeave(e)
        End Sub

        Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)
            Me.X = e.Location.X
            Me.Invalidate()
            MyBase.OnMouseMove(e)
        End Sub
        Public Tab1_Sel As Boolean = True
        Public Tab2_Sel As Boolean = False
        Public Tab3_Sel As Boolean = False
        Public Tab4_Sel As Boolean = False
        Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
            e.Graphics.InterpolationMode = InterpolationMode.NearestNeighbor
            Dim rect As New Rectangle(2, 0, (Me.Width - 5), (Me.Height - 1))
            e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(&H2D, &H2D, &H2D)), rect)
            rect = New Rectangle(0, 0, Me.Width, 8)
            Dim brush As New LinearGradientBrush(rect, Color.FromArgb(40, Color.Black), Color.Transparent, 90.0!)
            e.Graphics.FillRectangle(brush, brush.Rectangle)
            rect = New Rectangle(0, (Me.Height - 8), Me.Width, 8)
            brush = New LinearGradientBrush(rect, Color.Transparent, Color.FromArgb(40, Color.Black), 90.0!)
            e.Graphics.FillRectangle(brush, brush.Rectangle)
            rect = New Rectangle(1, -1, (Me.Width - 3), (Me.Height + 1))
            e.Graphics.DrawRectangle(Pens.Black, rect)
            rect = New Rectangle(0, -1, (Me.Width - 1), (Me.Height + 1))
            e.Graphics.DrawRectangle(New Pen(Color.FromArgb(&H3F, &H3F, &H3F)), rect)
            If Tab1_Sel = True Then
                e.Graphics.DrawImage(My.Resources.Home_Sel, New Rectangle(Me.Width / 2 - 65, 4, 24, 24))
                e.Graphics.DrawString("Home", Font, Brushes.White, New Rectangle(Width / 2 - 65, 28, 62, 32))
            Else
                e.Graphics.DrawImage(My.Resources.Home_UnSel, New Rectangle(Me.Width / 2 - 65, 4, 24, 24))
            End If
            If Tab2_Sel = True Then
                e.Graphics.DrawImage(My.Resources.Player_Sel, New Rectangle(Me.Width / 2 - 30, 4, 24, 24))
                e.Graphics.DrawString("Player", Font, Brushes.White, New Rectangle(Width / 2 - 30, 28, 82, 32))
            Else
                e.Graphics.DrawImage(My.Resources.Player_UnSel, New Rectangle(Me.Width / 2 - 30, 4, 24, 24))
            End If
            If Tab3_Sel = True Then
                e.Graphics.DrawImage(My.Resources.Shows_Sel, New Rectangle(Me.Width / 2 + 5, 4, 24, 24))
                e.Graphics.DrawString("Shows", Font, Brushes.White, New Rectangle(Width / 2, 28, 82, 32))
            Else
                e.Graphics.DrawImage(My.Resources.Shows_UnSel, New Rectangle(Me.Width / 2 + 5, 4, 24, 24))
            End If
            If Tab4_Sel = True Then
                e.Graphics.DrawImage(My.Resources.Profile_Sel, New Rectangle(Me.Width / 2 + 42, 4, 24, 24))
                e.Graphics.DrawString("Misc", Font, Brushes.White, New Rectangle(Width / 2 + 42, 28, 82, 32))
            Else
                e.Graphics.DrawImage(My.Resources.Profile_UnSel, New Rectangle(Me.Width / 2 + 42, 4, 24, 24))
            End If
            MyBase.OnPaint(e)
        End Sub
        Protected Overrides Sub OnMouseDown(e As MouseEventArgs)

            Dim clickRect3 As New Rectangle(Me.Width / 2 - 30, 4, 24, 24)
            If clickRect3.Contains(New Point(e.X, e.Y)) Then
                If Tab2_Sel = False Then
                    Tab2_Sel = True
                    Tab1_Sel = False
                    Tab3_Sel = False
                    Tab4_Sel = False
                    RaiseEvent Tab2_Clicked(Me)
                End If
            End If
            Dim clickRect1 As New Rectangle(Me.Width / 2 - 65, 4, 24, 24)
            If clickRect1.Contains(New Point(e.X, e.Y)) Then
                If Tab1_Sel = False Then
                    Tab1_Sel = True
                    Tab2_Sel = False
                    Tab3_Sel = False
                    Tab4_Sel = False
                    RaiseEvent Tab1_Clicked(Me)
                End If
            End If
            Dim clickRect2 As New Rectangle(Me.Width / 2 + 5, 4, 24, 24)
            If clickRect2.Contains(New Point(e.X, e.Y)) Then
                If Tab3_Sel = False Then
                    Tab3_Sel = True
                    Tab2_Sel = False
                    Tab1_Sel = False
                    Tab4_Sel = False
                    RaiseEvent Tab3_Clicked(Me)
                End If
            End If
            Dim clickRect4 As New Rectangle(Me.Width / 2 + 42, 4, 24, 24)
            If clickRect4.Contains(New Point(e.X, e.Y)) Then
                If Tab4_Sel = False Then
                    Tab4_Sel = True
                    Tab2_Sel = False
                    Tab1_Sel = False
                    Tab3_Sel = False
                    RaiseEvent Tab4_Clicked(Me)
                End If
            End If
            MyBase.OnMouseDown(e)
        End Sub

        ' Properties
        Public Property ContentLength As Long
            Get
                Return Me._ContentLength
            End Get
            Set(ByVal value As Long)
                Me._ContentLength = value
                Me.Invalidate()
            End Set
        End Property

        Public Property CurrentPosition As Long
            Get
                Return Me._CurrentPosition
            End Get
            Set(ByVal value As Long)
                Me._CurrentPosition = value
                Me.Invalidate()
            End Set
        End Property




        ' Fields
        'Private Shared __ENCList As List(Of WeakReference) = New List(Of WeakReference)
        Private _ContentLength As Long
        Private _CurrentPosition As Long
        Private _WaveForm As Bitmap
        Private X As Integer
    End Class
End Namespace

