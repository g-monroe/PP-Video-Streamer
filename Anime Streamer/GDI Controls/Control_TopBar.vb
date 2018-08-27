Imports System
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms
Imports System.ComponentModel

Namespace SoundcloudPlayer
    Friend Class SoundCloudTopBar
        Inherits Panel
        ' Methods
        Public Sub New()
            'SoundCloudTopBar.__ENCAddToList(Me)
            Me._EmptyMode = False
            Me._Account = "Anime"
            Me.DoubleBuffered = True
            Me.SetStyle((ControlStyles.OptimizedDoubleBuffer Or ControlStyles.ResizeRedraw), True)
            Me.Dock = DockStyle.Top
            Me.Height = &H2F
        End Sub

        '<DebuggerNonUserCode> _
        'Private Shared Sub __ENCAddToList(ByVal value As Object)
        '    Dim list As List(Of WeakReference) = SoundCloudTopBar.__ENCList
        '    SyncLock list
        '        If (SoundCloudTopBar.__ENCList.Count = SoundCloudTopBar.__ENCList.Capacity) Then
        '            Dim index As Integer = 0
        '            Dim num3 As Integer = (SoundCloudTopBar.__ENCList.Count - 1)
        '            Dim i As Integer = 0
        '            Do While (i <= num3)
        '                Dim reference As WeakReference = SoundCloudTopBar.__ENCList.Item(i)
        '                If reference.IsAlive Then
        '                    If (i <> index) Then
        '                        SoundCloudTopBar.__ENCList.Item(index) = SoundCloudTopBar.__ENCList.Item(i)
        '                    End If
        '                    index += 1
        '                End If
        '                i += 1
        '            Loop
        '            SoundCloudTopBar.__ENCList.RemoveRange(index, (SoundCloudTopBar.__ENCList.Count - index))
        '            SoundCloudTopBar.__ENCList.Capacity = SoundCloudTopBar.__ENCList.Count
        '        End If
        '        SoundCloudTopBar.__ENCList.Add(New WeakReference(RuntimeHelpers.GetObjectValue(value)))
        '    End SyncLock
        'End Sub
        Private Color1 As Color = Color.FromArgb(231, 82, 150)
        Private Color2 As Color = Color.FromArgb(233, 57, 137)
        <PropertyTab("Color1")> _
        <DisplayName("Color1")> _
        Public Property Color1p() As Color
            Get
                Return Color1
            End Get
            Set(value As Color)
                Color1 = value
            End Set
        End Property
        <PropertyTab("Color2")> _
      <DisplayName("Color2")> _
        Public Property Color2p() As Color
            Get
                Return Color2
            End Get
            Set(value As Color)
                Color2 = value
            End Set
        End Property
        Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
            Dim rect As New Rectangle(0, 0, Me.Width, (Me.Height - 5))
            Dim brush As New LinearGradientBrush(rect, Color.FromArgb(&H38, &H38, &H38), Color.FromArgb(&H23, &H23, &H23), 90.0!)
            e.Graphics.FillRectangle(brush, brush.Rectangle)
            rect = New Rectangle(0, (Me.Height - 5), Me.Width, 5)
            brush = New LinearGradientBrush(rect, Color.FromArgb(38, 38, 38), Color.FromArgb(38, 38, 38), 90.0!)
            e.Graphics.FillRectangle(brush, brush.Rectangle)
            Dim point As New Point(0, (Me.Height - 5))
            Dim point2 As New Point(Me.Width, (Me.Height - 5))
            e.Graphics.DrawLine(Pens.Black, point, point2)
            If Me.EmptyMode Then
                MyBase.OnPaint(e)
            Else
                rect = New Rectangle(&H19, 0, 80, (Me.Height - 5))
                brush = New LinearGradientBrush(rect, Color1, Color2, 90.0!)
                e.Graphics.FillRectangle(brush, brush.Rectangle)
                point2 = New Point(&H18, 0)
                point = New Point(&H18, (Me.Height - 6))
                e.Graphics.DrawLine(Pens.Black, point2, point)
                point2 = New Point(&H19, 0)
                point = New Point(&H19, (Me.Height - 6))
                e.Graphics.DrawLine(New Pen(Color2), point2, point)
                point2 = New Point(&H68, 0)
                point = New Point(&H68, (Me.Height - 6))
                e.Graphics.DrawLine(New Pen(Color2), point2, point)
                point2 = New Point(&H69, 0)
                point = New Point(&H69, (Me.Height - 6))
                e.Graphics.DrawLine(Pens.Black, point2, point)
                point2 = New Point(&H19, (Me.Height - 5))
                point = New Point(&H68, (Me.Height - 5))
                e.Graphics.DrawLine(New Pen(Color2), point2, point)
                point2 = New Point(&H20, 6)
                e.Graphics.SmoothingMode = SmoothingMode.HighQuality
                e.Graphics.DrawImage(My.Resources.Logo_TopBar, New Rectangle(&H20, -1, 68, 46))
                point2 = New Point((Me.Width - 190), 0)
                point = New Point((Me.Width - 190), (Me.Height - 6))
                e.Graphics.DrawLine(Pens.Black, point2, point)
                point2 = New Point((Me.Width - &HBD), 0)
                point = New Point((Me.Width - &HBD), (Me.Height - 6))
                e.Graphics.DrawLine(New Pen(Color.FromArgb(&H3F, &H3F, &H3F)), point2, point)
                rect = New Rectangle((Me.Width - &HB6), 4, &H91, 20)
                Dim format As New StringFormat With { _
                    .Alignment = StringAlignment.Near, _
                    .LineAlignment = StringAlignment.Center, _
                    .Trimming = StringTrimming.EllipsisCharacter _
                }
                e.Graphics.DrawString(Me._Account, New Font("Segoe UI", 12.0!), Brushes.Gainsboro, rect, format)
                rect = New Rectangle((Me.Width - 180), &H17, &H91, 15)
                format = New StringFormat With { _
                    .Alignment = StringAlignment.Near, _
                    .LineAlignment = StringAlignment.Center, _
                    .Trimming = StringTrimming.EllipsisCharacter _
                }
                e.Graphics.DrawString(Me.Text, New Font("Segoe UI", 8.0!), Brushes.Gainsboro, rect, format)
               
                MyBase.OnPaint(e)
            End If
        End Sub

        Protected Overrides Sub OnTextChanged(ByVal e As EventArgs)
            Me.Invalidate()
            MyBase.OnTextChanged(e)
        End Sub


        ' Properties
        Public Property EmptyMode As Boolean
            Get
                Return Me._EmptyMode
            End Get
            Set(ByVal value As Boolean)
                Me._EmptyMode = value
                Me.Invalidate()
            End Set
        End Property

        Public Property UserName As String
            Get
                Return Me._Account
            End Get
            Set(ByVal value As String)
                Me._Account = value
                Me.Invalidate()
            End Set
        End Property


        ' Fields
        ' Private Shared __ENCList As List(Of WeakReference) = New List(Of WeakReference)
        Private _Account As String
        Private _EmptyMode As Boolean
    End Class
End Namespace

