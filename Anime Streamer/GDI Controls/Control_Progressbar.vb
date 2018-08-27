Imports System.Drawing.Drawing2D
Imports System.ComponentModel
Imports System.Drawing.Text

Public Class HuraProgressBar
    Inherits Control

#Region "Declarations"
    Private _ProgressColour As Color = Color.FromArgb(0, 170, 220)
    Private _BorderColour As Color = Color.FromArgb(190, 190, 190)
    Private _BaseColour As Color = Color.FromArgb(255, 255, 255)
    Private _FontColour As Color = Color.FromArgb(50, 50, 50)
    Private _SecondColour As Color = Color.FromArgb(0, 170, 250)
    Private _Value As Integer = 0
    Private _Maximum As Integer = 100
    Private _TwoColour As Boolean = True
#End Region

#Region "Properties"

    Public Property SecondColour As Color
        Get
            Return _SecondColour
        End Get
        Set(value As Color)
            _SecondColour = value
        End Set
    End Property

    <Category("Control")>
    Public Property TwoColour As Boolean
        Get
            Return _TwoColour
        End Get
        Set(value As Boolean)
            _TwoColour = value
        End Set
    End Property

    <Category("Control")>
    Public Property Maximum() As Integer
        Get
            Return _Maximum
        End Get
        Set(V As Integer)
            Select Case V
                Case Is < _Value
                    _Value = V
            End Select
            _Maximum = V
            Invalidate()
        End Set
    End Property

    <Category("Control")>
    Public Property Value() As Integer
        Get
            Select Case _Value
                Case 0
                    Return 0
                    Invalidate()
                Case Else
                    Return _Value
                    Invalidate()
            End Select
        End Get
        Set(V As Integer)
            Select Case V
                Case Is > _Maximum
                    V = _Maximum
                    Invalidate()
            End Select
            _Value = V
            Invalidate()
        End Set
    End Property

    <Category("Colours")>
    Public Property ProgressColour As Color
        Get
            Return _ProgressColour
        End Get
        Set(value As Color)
            _ProgressColour = value
        End Set
    End Property

    <Category("Colours")>
    Public Property BaseColour As Color
        Get
            Return _BaseColour
        End Get
        Set(value As Color)
            _BaseColour = value
        End Set
    End Property

    <Category("Colours")>
    Public Property BorderColour As Color
        Get
            Return _BorderColour
        End Get
        Set(value As Color)
            _BorderColour = value
        End Set
    End Property

    <Category("Colours")>
    Public Property FontColour As Color
        Get
            Return _FontColour
        End Get
        Set(value As Color)
            _FontColour = value
        End Set
    End Property

#End Region

#Region "Events"

    Public Sub Increment(ByVal Amount As Integer)
        Value += Amount
    End Sub

#End Region

#Region "Draw Control"
    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or _
                 ControlStyles.ResizeRedraw Or ControlStyles.OptimizedDoubleBuffer, True)
        DoubleBuffered = True
    End Sub

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        Dim G = e.Graphics
        Dim Base As New Rectangle(0, 0, Width, Height)
        With G
            .TextRenderingHint = TextRenderingHint.ClearTypeGridFit
            .SmoothingMode = SmoothingMode.HighQuality
            .PixelOffsetMode = PixelOffsetMode.HighQuality
            .Clear(BackColor)
            Dim ProgVal As Integer = CInt(_Value / _Maximum * Width)
            Select Case Value
                Case 0
                    .FillRectangle(New SolidBrush(_BaseColour), Base)
                    .FillRectangle(New SolidBrush(_ProgressColour), New Rectangle(0, 0, ProgVal - 1, Height))
                    .DrawRectangle(New Pen(_BorderColour, 2), Base)
                Case _Maximum
                    .FillRectangle(New SolidBrush(_BaseColour), Base)
                    .FillRectangle(New SolidBrush(_ProgressColour), New Rectangle(0, 0, ProgVal - 1, Height))
                    If _TwoColour Then
                        For i = 0 To (Width - 1) * _Maximum / _Value Step 25
                            G.DrawLine(New Pen(New SolidBrush(_SecondColour), 7), New Point(CInt(i), 0), New Point(CInt(i - 15), Height))
                        Next
                        G.ResetClip()
                    Else
                    End If
                    .DrawRectangle(New Pen(_BorderColour, 2), Base)
                Case Else
                    .FillRectangle(New SolidBrush(_BaseColour), Base)
                    .FillRectangle(New SolidBrush(_ProgressColour), New Rectangle(0, 0, ProgVal - 1, Height))
                    If _TwoColour Then
                        .SetClip(New Rectangle(0, 0, CInt(Width * _Value / _Maximum - 1), Height - 1))
                        For i = 0 To (Width - 1) * _Maximum / _Value Step 25
                            .DrawLine(New Pen(New SolidBrush(_SecondColour), 7), New Point(CInt(i), 0), New Point(CInt(i - 10), Height))
                        Next
                        .ResetClip()
                    Else
                    End If
                    .DrawRectangle(New Pen(_BorderColour, 2), Base)
            End Select
            .InterpolationMode = CType(7, InterpolationMode)
        End With
    End Sub

#End Region

End Class