Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Diagnostics
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Runtime.CompilerServices
Imports System.Windows.Forms

Namespace SoundcloudPlayer
    Friend Class WaveForm
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
            MyBase.OnPaint(e)
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

        Public Property WaveForm As Bitmap
            Get
                Return Me._WaveForm
            End Get
            Set(ByVal value As Bitmap)
                Dim bitmap As Bitmap = Nothing
                If Not Information.IsNothing(value) Then
                    bitmap = New Bitmap(value.Width, CInt(Math.Round(CDbl((CDbl(value.Height) / 2)))))
                    Dim num3 As Integer = (value.Width - 1)
                    Dim i As Integer = 0
                    Do While (i <= num3)
                        Dim num4 As Integer = (CInt(Math.Round(CDbl((CDbl(value.Height) / 2)))) - 1)
                        Dim j As Integer = 0
                        Do While (j <= num4)
                            If (value.GetPixel(i, j) = Color.FromArgb(&HFF, &HEF, &HEF, &HEF)) Then
                                bitmap.SetPixel(i, j, Color.FromArgb(&H2D, &H2D, &H2D))
                            Else
                                bitmap.SetPixel(i, j, Color.Transparent)
                            End If
                            j += 1
                        Loop
                        i += 1
                    Loop
                End If
                Me._WaveForm = bitmap
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

