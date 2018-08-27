Imports System
Imports System.Windows.Forms
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports System.Drawing.Text
Imports System.ComponentModel
Imports System.Collections.Generic
Imports System.Text
Module ThemeModule

    Friend G As Graphics

    Sub New()
        TextBitmap = New Bitmap(1, 1)
        TextGraphics = Graphics.FromImage(TextBitmap)
    End Sub

    Private TextBitmap As Bitmap
    Private TextGraphics As Graphics

    Friend Function MeasureString(text As String, font As Font) As SizeF
        Return TextGraphics.MeasureString(text, font)
    End Function

    Friend Function MeasureString(text As String, font As Font, width As Integer) As SizeF
        Return TextGraphics.MeasureString(text, font, width, StringFormat.GenericTypographic)
    End Function

    Private CreateRoundPath As GraphicsPath
    Private CreateRoundRectangle As Rectangle

    Friend Function CreateRound(ByVal x As Integer, ByVal y As Integer, ByVal width As Integer, ByVal height As Integer, ByVal slope As Integer) As GraphicsPath
        CreateRoundRectangle = New Rectangle(x, y, width, height)
        Return CreateRound(CreateRoundRectangle, slope)
    End Function

    Friend Function CreateRound(ByVal r As Rectangle, ByVal slope As Integer) As GraphicsPath
        CreateRoundPath = New GraphicsPath(FillMode.Winding)
        CreateRoundPath.AddArc(r.X, r.Y, slope, slope, 180.0F, 90.0F)
        CreateRoundPath.AddArc(r.Right - slope, r.Y, slope, slope, 270.0F, 90.0F)
        CreateRoundPath.AddArc(r.Right - slope, r.Bottom - slope, slope, slope, 0.0F, 90.0F)
        CreateRoundPath.AddArc(r.X, r.Bottom - slope, slope, slope, 90.0F, 90.0F)
        CreateRoundPath.CloseFigure()
        Return CreateRoundPath
    End Function

End Module

<DefaultEvent("Scroll")> _
Class NSVScrollBar
    Inherits Control

    Event Scroll(ByVal sender As Object)

    Private _Minimum As Integer
    Property Minimum() As Integer
        Get
            Return _Minimum
        End Get
        Set(ByVal value As Integer)
            If value < 0 Then
                Throw New Exception("Property value is not valid.")
            End If

            _Minimum = value
            If value > _Value Then _Value = value
            If value > _Maximum Then _Maximum = value

            InvalidateLayout()
        End Set
    End Property

    Private _Maximum As Integer = 100
    Property Maximum() As Integer
        Get
            Return _Maximum
        End Get
        Set(ByVal value As Integer)
            If value < 1 Then value = 1

            _Maximum = value
            If value < _Value Then _Value = value
            If value < _Minimum Then _Minimum = value

            InvalidateLayout()
        End Set
    End Property

    Private _Value As Integer
    Property Value() As Integer
        Get
            If Not ShowThumb Then Return _Minimum
            Return _Value
        End Get
        Set(ByVal value As Integer)
            If value = _Value Then Return

            If value > _Maximum OrElse value < _Minimum Then
                Throw New Exception("Property value is not valid.")
            End If

            _Value = value
            InvalidatePosition()

            RaiseEvent Scroll(Me)
        End Set
    End Property

    Property _Percent As Double
    Public ReadOnly Property Percent As Double
        Get
            If Not ShowThumb Then Return 0
            Return GetProgress()
        End Get
    End Property

    Private _SmallChange As Integer = 1
    Public Property SmallChange() As Integer
        Get
            Return _SmallChange
        End Get
        Set(ByVal value As Integer)
            If value < 1 Then
                Throw New Exception("Property value is not valid.")
            End If

            _SmallChange = value
        End Set
    End Property

    Private _LargeChange As Integer = 10
    Public Property LargeChange() As Integer
        Get
            Return _LargeChange
        End Get
        Set(ByVal value As Integer)
            If value < 1 Then
                Throw New Exception("Property value is not valid.")
            End If

            _LargeChange = value
        End Set
    End Property

    Private ButtonSize As Integer = 16
    Private ThumbSize As Integer = 24 ' 14 minimum

    Private TSA As Rectangle
    Private BSA As Rectangle
    Private Shaft As Rectangle
    Private Thumb As Rectangle

    Private ShowThumb As Boolean
    Private ThumbDown As Boolean

    Sub New()
        SetStyle(DirectCast(139286, ControlStyles), True)
        SetStyle(ControlStyles.Selectable, False)

        Width = 18

        B1 = New SolidBrush(Color.FromArgb(55, 55, 55))
        B2 = New SolidBrush(Color.FromArgb(35, 35, 35))

        P1 = New Pen(Color.FromArgb(35, 35, 35))
        P2 = New Pen(Color.FromArgb(65, 65, 65))
        P3 = New Pen(Color.FromArgb(55, 55, 55))
        P4 = New Pen(Color.FromArgb(40, 40, 40))
    End Sub

    Private GP1, GP2, GP3, GP4 As GraphicsPath

    Private P1, P2, P3, P4 As Pen
    Private B1, B2 As SolidBrush

    Dim I1 As Integer

    Protected Overrides Sub OnPaint(e As System.Windows.Forms.PaintEventArgs)
        G = e.Graphics
        G.Clear(Color.FromArgb(38, 38, 38))

        GP1 = DrawArrow(4, 6, False)
        GP2 = DrawArrow(5, 7, False)

        G.FillPath(B1, GP2)
        G.FillPath(B2, GP1)

        GP3 = DrawArrow(4, Height - 11, True)
        GP4 = DrawArrow(5, Height - 10, True)

        G.FillPath(B1, GP4)
        G.FillPath(B2, GP3)

        If ShowThumb Then
            G.FillRectangle(B1, Thumb)
            G.DrawRectangle(P1, Thumb)
            G.DrawRectangle(P2, Thumb.X + 1, Thumb.Y + 1, Thumb.Width - 2, Thumb.Height - 2)

            Dim Y As Integer
            Dim LY As Integer = Thumb.Y + (Thumb.Height \ 2) - 3

            For I As Integer = 0 To 2
                Y = LY + (I * 3)

                G.DrawLine(P1, Thumb.X + 5, Y, Thumb.Right - 5, Y)
                G.DrawLine(P2, Thumb.X + 5, Y + 1, Thumb.Right - 5, Y + 1)
            Next
        End If

        G.DrawRectangle(P3, 0, 0, Width - 1, Height - 1)
        G.DrawRectangle(P4, 1, 1, Width - 3, Height - 3)
    End Sub

    Private Function DrawArrow(x As Integer, y As Integer, flip As Boolean) As GraphicsPath
        Dim GP As New GraphicsPath()

        Dim W As Integer = 9
        Dim H As Integer = 5

        If flip Then
            GP.AddLine(x + 1, y, x + W + 1, y)
            GP.AddLine(x + W, y, x + H, y + H - 1)
        Else
            GP.AddLine(x, y + H, x + W, y + H)
            GP.AddLine(x + W, y + H, x + H, y)
        End If

        GP.CloseFigure()
        Return GP
    End Function

    Protected Overrides Sub OnSizeChanged(e As EventArgs)
        InvalidateLayout()
    End Sub

    Private Sub InvalidateLayout()
        TSA = New Rectangle(0, 0, Width, ButtonSize)
        BSA = New Rectangle(0, Height - ButtonSize, Width, ButtonSize)
        Shaft = New Rectangle(0, TSA.Bottom + 1, Width, Height - (ButtonSize * 2) - 1)

        ShowThumb = ((_Maximum - _Minimum) > Shaft.Height)

        If ShowThumb Then
            'ThumbSize = Math.Max(0, 14) 'TODO: Implement this.
            Thumb = New Rectangle(1, 0, Width - 3, ThumbSize)
        End If

        RaiseEvent Scroll(Me)
        InvalidatePosition()
    End Sub

    Private Sub InvalidatePosition()
        Thumb.Y = CInt(GetProgress() * (Shaft.Height - ThumbSize)) + TSA.Height
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Left AndAlso ShowThumb Then
            If TSA.Contains(e.Location) Then
                I1 = _Value - _SmallChange
            ElseIf BSA.Contains(e.Location) Then
                I1 = _Value + _SmallChange
            Else
                If Thumb.Contains(e.Location) Then
                    ThumbDown = True
                    MyBase.OnMouseDown(e)
                    Return
                Else
                    If e.Y < Thumb.Y Then
                        I1 = _Value - _LargeChange
                    Else
                        I1 = _Value + _LargeChange
                    End If
                End If
            End If

            Value = Math.Min(Math.Max(I1, _Minimum), _Maximum)
            InvalidatePosition()
        End If

        MyBase.OnMouseDown(e)
    End Sub

    Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)
        If ThumbDown AndAlso ShowThumb Then
            Dim ThumbPosition As Integer = e.Y - TSA.Height - (ThumbSize \ 2)
            Dim ThumbBounds As Integer = Shaft.Height - ThumbSize

            I1 = CInt((ThumbPosition / ThumbBounds) * (_Maximum - _Minimum)) + _Minimum

            Value = Math.Min(Math.Max(I1, _Minimum), _Maximum)
            InvalidatePosition()
        End If

        MyBase.OnMouseMove(e)
    End Sub

    Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
        ThumbDown = False
        MyBase.OnMouseUp(e)
    End Sub

    Private Function GetProgress() As Double
        Return (_Value - _Minimum) / (_Maximum - _Minimum)
    End Function

End Class

<DefaultEvent("Scroll")> _
Class NSHScrollBar
    Inherits Control

    Event Scroll(ByVal sender As Object)

    Private _Minimum As Integer
    Property Minimum() As Integer
        Get
            Return _Minimum
        End Get
        Set(ByVal value As Integer)
            If value < 0 Then
                Throw New Exception("Property value is not valid.")
            End If

            _Minimum = value
            If value > _Value Then _Value = value
            If value > _Maximum Then _Maximum = value

            InvalidateLayout()
        End Set
    End Property

    Private _Maximum As Integer = 100
    Property Maximum() As Integer
        Get
            Return _Maximum
        End Get
        Set(ByVal value As Integer)
            If value < 0 Then
                Throw New Exception("Property value is not valid.")
            End If

            _Maximum = value
            If value < _Value Then _Value = value
            If value < _Minimum Then _Minimum = value

            InvalidateLayout()
        End Set
    End Property

    Private _Value As Integer
    Property Value() As Integer
        Get
            If Not ShowThumb Then Return _Minimum
            Return _Value
        End Get
        Set(ByVal value As Integer)
            If value = _Value Then Return

            If value > _Maximum OrElse value < _Minimum Then
                Throw New Exception("Property value is not valid.")
            End If

            _Value = value
            InvalidatePosition()

            RaiseEvent Scroll(Me)
        End Set
    End Property

    Private _SmallChange As Integer = 1
    Public Property SmallChange() As Integer
        Get
            Return _SmallChange
        End Get
        Set(ByVal value As Integer)
            If value < 1 Then
                Throw New Exception("Property value is not valid.")
            End If

            _SmallChange = value
        End Set
    End Property

    Private _LargeChange As Integer = 10
    Public Property LargeChange() As Integer
        Get
            Return _LargeChange
        End Get
        Set(ByVal value As Integer)
            If value < 1 Then
                Throw New Exception("Property value is not valid.")
            End If

            _LargeChange = value
        End Set
    End Property

    Private ButtonSize As Integer = 16
    Private ThumbSize As Integer = 24 ' 14 minimum

    Private LSA As Rectangle
    Private RSA As Rectangle
    Private Shaft As Rectangle
    Private Thumb As Rectangle

    Private ShowThumb As Boolean
    Private ThumbDown As Boolean

    Sub New()
        SetStyle(DirectCast(139286, ControlStyles), True)
        SetStyle(ControlStyles.Selectable, False)

        Height = 18

        B1 = New SolidBrush(Color.FromArgb(55, 55, 55))
        B2 = New SolidBrush(Color.FromArgb(35, 35, 35))

        P1 = New Pen(Color.FromArgb(35, 35, 35))
        P2 = New Pen(Color.FromArgb(65, 65, 65))
        P3 = New Pen(Color.FromArgb(55, 55, 55))
        P4 = New Pen(Color.FromArgb(40, 40, 40))
    End Sub

    Private GP1, GP2, GP3, GP4 As GraphicsPath

    Private P1, P2, P3, P4 As Pen
    Private B1, B2 As SolidBrush

    Dim I1 As Integer

    Protected Overrides Sub OnPaint(e As System.Windows.Forms.PaintEventArgs)
        G = e.Graphics
        G.Clear(BackColor)

        GP1 = DrawArrow(6, 4, False)
        GP2 = DrawArrow(7, 5, False)

        G.FillPath(B1, GP2)
        G.FillPath(B2, GP1)

        GP3 = DrawArrow(Width - 11, 4, True)
        GP4 = DrawArrow(Width - 10, 5, True)

        G.FillPath(B1, GP4)
        G.FillPath(B2, GP3)

        If ShowThumb Then
            G.FillRectangle(B1, Thumb)
            G.DrawRectangle(P1, Thumb)
            G.DrawRectangle(P2, Thumb.X + 1, Thumb.Y + 1, Thumb.Width - 2, Thumb.Height - 2)

            Dim X As Integer
            Dim LX As Integer = Thumb.X + (Thumb.Width \ 2) - 3

            For I As Integer = 0 To 2
                X = LX + (I * 3)

                G.DrawLine(P1, X, Thumb.Y + 5, X, Thumb.Bottom - 5)
                G.DrawLine(P2, X + 1, Thumb.Y + 5, X + 1, Thumb.Bottom - 5)
            Next
        End If

        G.DrawRectangle(P3, 0, 0, Width - 1, Height - 1)
        G.DrawRectangle(P4, 1, 1, Width - 3, Height - 3)
    End Sub

    Private Function DrawArrow(x As Integer, y As Integer, flip As Boolean) As GraphicsPath
        Dim GP As New GraphicsPath()

        Dim W As Integer = 5
        Dim H As Integer = 9

        If flip Then
            GP.AddLine(x, y + 1, x, y + H + 1)
            GP.AddLine(x, y + H, x + W - 1, y + W)
        Else
            GP.AddLine(x + W, y, x + W, y + H)
            GP.AddLine(x + W, y + H, x + 1, y + W)
        End If

        GP.CloseFigure()
        Return GP
    End Function

    Protected Overrides Sub OnSizeChanged(e As EventArgs)
        InvalidateLayout()
    End Sub

    Private Sub InvalidateLayout()
        LSA = New Rectangle(0, 0, ButtonSize, Height)
        RSA = New Rectangle(Width - ButtonSize, 0, ButtonSize, Height)
        Shaft = New Rectangle(LSA.Right + 1, 0, Width - (ButtonSize * 2) - 1, Height)

        ShowThumb = ((_Maximum - _Minimum) > Shaft.Width)

        If ShowThumb Then
            'ThumbSize = Math.Max(0, 14) 'TODO: Implement this.
            Thumb = New Rectangle(0, 1, ThumbSize, Height - 3)
        End If

        RaiseEvent Scroll(Me)
        InvalidatePosition()
    End Sub

    Private Sub InvalidatePosition()
        Thumb.X = CInt(GetProgress() * (Shaft.Width - ThumbSize)) + LSA.Width
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        If e.Button = Windows.Forms.MouseButtons.Left AndAlso ShowThumb Then
            If LSA.Contains(e.Location) Then
                I1 = _Value - _SmallChange
            ElseIf RSA.Contains(e.Location) Then
                I1 = _Value + _SmallChange
            Else
                If Thumb.Contains(e.Location) Then
                    ThumbDown = True
                    MyBase.OnMouseDown(e)
                    Return
                Else
                    If e.X < Thumb.X Then
                        I1 = _Value - _LargeChange
                    Else
                        I1 = _Value + _LargeChange
                    End If
                End If
            End If

            Value = Math.Min(Math.Max(I1, _Minimum), _Maximum)
            InvalidatePosition()
        End If

        MyBase.OnMouseDown(e)
    End Sub

    Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)
        If ThumbDown AndAlso ShowThumb Then
            Dim ThumbPosition As Integer = e.X - LSA.Width - (ThumbSize \ 2)
            Dim ThumbBounds As Integer = Shaft.Width - ThumbSize

            I1 = CInt((ThumbPosition / ThumbBounds) * (_Maximum - _Minimum)) + _Minimum

            Value = Math.Min(Math.Max(I1, _Minimum), _Maximum)
            InvalidatePosition()
        End If

        MyBase.OnMouseMove(e)
    End Sub

    Protected Overrides Sub OnMouseUp(ByVal e As MouseEventArgs)
        ThumbDown = False
        MyBase.OnMouseUp(e)
    End Sub

    Private Function GetProgress() As Double
        Return (_Value - _Minimum) / (_Maximum - _Minimum)
    End Function

End Class
'If you have made it this far it's not too late to turn back, you must not continue on! If you are trying to fullfill some 
'sick act of masochism by studying the source of the ListView then, may god have mercy on your soul.
Class NSListView
    Inherits Control
    Event UnFavorited(ByVal sender As Object)
    Event FavoritedChanged(ByVal sender As Object, Num As NSListView.NSListViewItem)
    Event WatchedChanged(ByVal sender As Object, Num As NSListView.NSListViewItem)
    Class NSListViewCollection
        Inherits List(Of NSListViewItem)
        Private Parent As NSListView
        Public Sub New(Parent As NSListView)
            Me.Parent = Parent
        End Sub
        Public Shadows Sub Add(Item As NSListViewItem)
            MyBase.Add(Item)
            Parent.InvalidateScroll()
        End Sub
        Public Shadows Sub AddRange(Range As List(Of NSListViewItem))
            MyBase.AddRange(Range)
            Parent.InvalidateScroll()
        End Sub
        Public Shadows Sub Clear()
            MyBase.Clear()
            Parent.InvalidateScroll()
        End Sub
        Public Shadows Sub Remove(Item As NSListViewItem)
            MyBase.Remove(Item)
            Parent.InvalidateScroll()
        End Sub
        Public Shadows Sub RemoveAt(Index As Integer)
            MyBase.RemoveAt(Index)
            Parent.InvalidateScroll()
        End Sub
        Public Shadows Sub RemoveAll(Predicate As System.Predicate(Of NSListViewItem))
            MyBase.RemoveAll(Predicate)
            Parent.InvalidateScroll()
        End Sub
        Public Shadows Sub RemoveRange(Index As Integer, Count As Integer)
            MyBase.RemoveRange(Index, Count)
            Parent.InvalidateScroll()
        End Sub
    End Class

    Class NSListViewItem
        Property Text As String
        Property Favorited As Boolean = False
        Property Watched As Boolean = False
        Property LocX As Integer = 0
        Property LocY As Integer = 0
        <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
        Property SubItems As New List(Of NSListViewSubItem)

        Protected UniqueId As Guid

        Sub New()
            UniqueId = Guid.NewGuid()
        End Sub

        Public Overrides Function ToString() As String
            Return Text
        End Function


        Public Function ToFavorited() As Boolean
            Return Favorited
        End Function
        Public Overrides Function Equals(obj As Object) As Boolean
            If TypeOf obj Is NSListViewItem Then
                Return (DirectCast(obj, NSListViewItem).UniqueId = UniqueId)
            End If

            Return False
        End Function

    End Class

    Class NSListViewSubItem
        Property Text As String

        Public Overrides Function ToString() As String
            Return Text
        End Function
    End Class

    Class NSListViewColumnHeader
        Property Text As String
        Property Width As Integer = 60

        Public Overrides Function ToString() As String
            Return Text
        End Function
    End Class

    Private _Items As New NSListViewCollection(Me)
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
    Public Property Items As NSListViewCollection
        Get
            Return _Items
        End Get
        Set(ByVal value As NSListViewCollection)
            _Items = value
            InvalidateScroll()
        End Set
    End Property

    Private _SelectedItems As New List(Of NSListViewItem)
    Public ReadOnly Property SelectedItems() As NSListViewItem()
        Get
            Return _SelectedItems.ToArray()
        End Get
    End Property

    Private _Columns As New List(Of NSListViewColumnHeader)
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
    Public Property Columns() As NSListViewColumnHeader()
        Get
            Return _Columns.ToArray()
        End Get
        Set(ByVal value As NSListViewColumnHeader())
            _Columns = New List(Of NSListViewColumnHeader)(value)
            InvalidateColumns()
        End Set
    End Property

    Private _MultiSelect As Boolean = True
    Public Property MultiSelect() As Boolean
        Get
            Return _MultiSelect
        End Get
        Set(ByVal value As Boolean)
            _MultiSelect = value

            If _SelectedItems.Count > 1 Then
                _SelectedItems.RemoveRange(1, _SelectedItems.Count - 1)
            End If

            Invalidate()
        End Set
    End Property

    Private ItemHeight As Integer = 24
    Public Overrides Property Font As Font
        Get
            Return MyBase.Font
        End Get
        Set(value As Font)
            ItemHeight = CInt(Graphics.FromHwnd(Handle).MeasureString("@", Font).Height) + 6

            If VS IsNot Nothing Then
                VS.SmallChange = ItemHeight
                VS.LargeChange = ItemHeight
            End If

            MyBase.Font = value
            InvalidateLayout()
        End Set
    End Property

#Region " Item Helper Methods "

    'Ok, you've seen everything of importance at this point; I am begging you to spare yourself. You must not read any further!

    Public Sub AddItem(text As String, ParamArray subItems As String())
        Dim Items As New List(Of NSListViewSubItem)
        For Each I As String In subItems
            Dim SubItem As New NSListViewSubItem()
            SubItem.Text = I
            Items.Add(SubItem)
        Next

        Dim Item As New NSListViewItem()
        Item.Text = text
        Item.SubItems = Items

        _Items.Add(Item)
        InvalidateScroll()
    End Sub

    Public Sub RemoveItemAt(index As Integer)
        _Items.RemoveAt(index)
        InvalidateScroll()
    End Sub

    Public Sub RemoveItem(item As NSListViewItem)
        _Items.Remove(item)
        InvalidateScroll()
    End Sub

    Public Sub RemoveItems(items As NSListViewItem())
        For Each I As NSListViewItem In items
            _Items.Remove(I)
        Next

        InvalidateScroll()
    End Sub

#End Region

    Private VS As NSVScrollBar

    Sub New()
        SetStyle(DirectCast(139286, ControlStyles), True)
        SetStyle(ControlStyles.Selectable, True)

        P1 = New Pen(Color.FromArgb(55, 55, 55))
        P2 = New Pen(Color.FromArgb(35, 35, 35))
        P3 = New Pen(Color.FromArgb(65, 65, 65))

        B1 = New SolidBrush(Color1)
        B2 = New SolidBrush(Color3)
        B3 = New SolidBrush(Color3) 'Want Color.FromArgb(251, 83, 150), Color.FromArgb(225, 53, 126)
        B4 = New SolidBrush(Color2) ' want

        VS = New NSVScrollBar
        VS.SmallChange = ItemHeight
        VS.LargeChange = ItemHeight

        AddHandler VS.Scroll, AddressOf HandleScroll
        AddHandler VS.MouseDown, AddressOf VS_MouseDown
        Controls.Add(VS)

        InvalidateLayout()
    End Sub
    Private Color1 As Color = Color.FromArgb(231, 82, 150)
    Private Color2 As Color = Color.FromArgb(233, 57, 137)
    Private Color3 As Color = Color.FromArgb(251, 93, 160)
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
    <PropertyTab("Color3")> _
  <DisplayName("Color3")> _
    Public Property Color3p() As Color
        Get
            Return Color3
        End Get
        Set(value As Color)
            Color3 = value
        End Set
    End Property
    Protected Overrides Sub OnSizeChanged(e As EventArgs)
        InvalidateLayout()
        MyBase.OnSizeChanged(e)
    End Sub

    Private Sub HandleScroll(sender As Object)
        Invalidate()
    End Sub

    Private Sub InvalidateScroll()
        VS.Maximum = (_Items.Count * ItemHeight)
        Invalidate()
    End Sub

    Private Sub InvalidateLayout()
        VS.Location = New Point(Width - VS.Width - 1, 1)
        VS.Size = New Size(18, Height - 2)

        Invalidate()
    End Sub

    Private ColumnOffsets As Integer()
    Private Sub InvalidateColumns()
        Dim Width As Integer = 3
        ColumnOffsets = New Integer(_Columns.Count - 1) {}

        For I As Integer = 0 To _Columns.Count - 1
            ColumnOffsets(I) = Width
            Width += Columns(I).Width
        Next

        Invalidate()
    End Sub

    Private Sub VS_MouseDown(sender As Object, e As MouseEventArgs)
        Focus()
    End Sub

    Protected Overrides Sub OnMouseDown(e As MouseEventArgs)
        Focus()

        If e.Button = Windows.Forms.MouseButtons.Left Then
           
            Dim Offset As Integer = CInt(VS.Percent * (VS.Maximum - (Height - (ItemHeight * 2))))
            Dim Index As Integer = ((e.Y + Offset - ItemHeight) \ ItemHeight)
            Try
                If New Rectangle(_Items(Index).LocY + 7, _Items(Index).LocX + 5, 16, 32).Contains(e.Location) Then

                    RaiseEvent FavoritedChanged(Me, _Items(Index))
                    _Items(Index).Favorited = Not _Items(Index).Favorited

                End If
            Catch ex As Exception
            End Try
            Try
                If New Rectangle(_Items(Index).LocY + 23, _Items(Index).LocX + 5, 16, 32).Contains(e.Location) Then

                    RaiseEvent WatchedChanged(Me, _Items(Index))
                    _Items(Index).Watched = Not _Items(Index).Watched
                End If
            Catch ex As Exception
            End Try
            If Index > _Items.Count - 1 Then Index = -1

            If Not Index = -1 Then
                'TODO: Handle Shift key

                If ModifierKeys = Keys.Control AndAlso _MultiSelect Then
                    If _SelectedItems.Contains(_Items(Index)) Then
                        _SelectedItems.Remove(_Items(Index))
                    Else
                        _SelectedItems.Add(_Items(Index))
                    End If
                Else
                    _SelectedItems.Clear()
                    _SelectedItems.Add(_Items(Index))
                End If
            End If

            Invalidate()
        End If

        MyBase.OnMouseDown(e)
    End Sub

    Private P1, P2, P3 As Pen
    Private B1, B2, B3, B4 As SolidBrush
    Private GB1 As LinearGradientBrush

    'I am so sorry you have to witness this. I tried warning you. ;.;

    Protected Overrides Sub OnPaint(e As PaintEventArgs)
        G = e.Graphics
        G.TextRenderingHint = TextRenderingHint.ClearTypeGridFit

        G.Clear(Color.FromArgb(38, 38, 38))

        Dim X, Y As Integer
        Dim H As Single

        G.DrawRectangle(P1, 1, 1, Width - 3, Height - 3)

        Dim R1 As Rectangle
        Dim CI As NSListViewItem

        Dim Offset As Integer = CInt(VS.Percent * (VS.Maximum - (Height - (ItemHeight * 2))))

        Dim StartIndex As Integer
        If Offset = 0 Then StartIndex = 0 Else StartIndex = (Offset \ ItemHeight)

        Dim EndIndex As Integer = Math.Min(StartIndex + (Height \ ItemHeight), _Items.Count - 1)

        For I As Integer = StartIndex To EndIndex
            CI = Items(I)

            R1 = New Rectangle(0, ItemHeight + (I * ItemHeight) + 1 - Offset, Width, ItemHeight - 1)

            H = G.MeasureString(CI.Text, Font).Height
            Y = R1.Y + CInt((ItemHeight / 2) - (H / 2))

            If _SelectedItems.Contains(CI) Then
                If I Mod 2 = 0 Then
                    CI.LocX = H
                    CI.LocX = Y
                    G.FillRectangle(B1, R1)
                Else
                    CI.LocX = H
                    CI.LocX = Y
                    G.FillRectangle(B2, R1)
                End If
            Else
                If I Mod 2 = 0 Then
                    CI.LocX = H
                    CI.LocX = Y
                    G.FillRectangle(B3, R1)
                Else
                    CI.LocX = H
                    CI.LocX = Y
                    G.FillRectangle(B4, R1)
                End If
            End If

            G.DrawLine(P2, 0, R1.Bottom, Width, R1.Bottom)

            If Columns.Length > 0 Then
                R1.Width = Columns(0).Width
                G.SetClip(R1)
            End If

            'TODO: Ellipse text that overhangs seperators.
            If CI.Favorited = False Then
                G.SmoothingMode = SmoothingMode.HighQuality
                G.DrawImage(My.Resources.Fav_UnSel, New Rectangle(7, Y + 1, 16, 16))
            Else
                G.SmoothingMode = SmoothingMode.HighQuality
                G.DrawImage(My.Resources.Fav_Sel, New Rectangle(7, Y + 1, 16, 16))
            End If
            If CI.Watched = False Then
                G.SmoothingMode = SmoothingMode.HighQuality
                G.DrawImage(My.Resources.Clock_UnSel, New Rectangle(23, Y + 1, 16, 16))
            Else
                G.SmoothingMode = SmoothingMode.HighQuality
                G.DrawImage(My.Resources.Clock, New Rectangle(23, Y + 1, 16, 16))
            End If
            G.DrawString(CI.Text, Font, Brushes.Black, 10 + 34, Y + 1)
            G.DrawString(CI.Text, Font, Brushes.White, 9 + 34, Y)

            If CI.SubItems IsNot Nothing Then
                For I2 As Integer = 0 To Math.Min(CI.SubItems.Count, _Columns.Count) - 1
                    X = ColumnOffsets(I2 + 1) + 4

                    R1.X = X
                    R1.Width = Columns(I2).Width
                    G.SetClip(R1)

                    G.DrawString(CI.SubItems(I2).Text, Font, Brushes.Black, X + 1, Y + 1)
                    G.DrawString(CI.SubItems(I2).Text, Font, Brushes.White, X, Y)
                Next
            End If

            G.ResetClip()
        Next

        R1 = New Rectangle(0, 0, Width, ItemHeight)

        GB1 = New LinearGradientBrush(R1, Color.FromArgb(60, 60, 60), Color.FromArgb(55, 55, 55), 90.0F)
        G.FillRectangle(GB1, R1)
        G.DrawRectangle(P3, 1, 1, Width - 22, ItemHeight - 2)
        Dim LH As Integer = Math.Min(VS.Maximum + ItemHeight - Offset, Height)

        Dim CC As NSListViewColumnHeader
        For I As Integer = 0 To _Columns.Count - 1
            CC = Columns(I)

            H = G.MeasureString(CC.Text, Font).Height
            Y = CInt((ItemHeight / 2) - (H / 2))
            X = ColumnOffsets(I)

            G.DrawString(CC.Text, Font, Brushes.Black, X + 1, Y + 1)
            G.DrawString(CC.Text, Font, Brushes.White, X, Y)

            G.DrawLine(P2, X - 3, 0, X - 3, LH)
            G.DrawLine(P3, X - 2, 0, X - 2, ItemHeight)
        Next

        G.DrawRectangle(P2, 0, 0, Width - 1, Height - 1)

        G.DrawLine(P2, 0, ItemHeight, Width, ItemHeight)
        G.DrawLine(P2, VS.Location.X - 1, 0, VS.Location.X - 1, Height)
    End Sub

    Protected Overrides Sub OnMouseWheel(e As MouseEventArgs)
        Dim Move As Integer = -((e.Delta * SystemInformation.MouseWheelScrollLines \ 120) * (ItemHeight \ 2))

        Dim Value As Integer = Math.Max(Math.Min(VS.Value + Move, VS.Maximum), VS.Minimum)
        VS.Value = Value

        MyBase.OnMouseWheel(e)
    End Sub

End Class

