Imports System.Net
Imports System.IO
Imports System.ComponentModel
Imports System.Threading
Imports System.Drawing.Drawing2D

Public Class HomeItem
    Inherits Panel
    Public Shared Once As Boolean = False
    Public Inner As Boolean = False
    Public Event Clicked As Action(Of String)
    Sub New()
        Me.Size = New Size(151, 201)
        Me.BackColor = Color.FromArgb(25, 25, 25)
    End Sub
    Protected Overrides Sub OnCreateControl()

        MyBase.OnCreateControl()
    End Sub
    Public URL As String = "http://www.goodanime.net/images/donten_ni_warau.jpg"
    Public Type As String = "None"
    Property Showlink As String = "Random"
    <PropertyTab("Image")> _
   <DisplayName("Image")> _
    Public Property BM() As String
        Get
            Return URL
        End Get
        Set(value As String)
            URL = value
        End Set
    End Property
    Public _text As String = "None Your Damn Bussiness"
    <PropertyTab("name")> _
   <DisplayName("name")> _
    Public Property NM() As String
        Get
            Return _text
        End Get
        Set(value As String)
            _text = value
        End Set
    End Property
    Public Shared myimage As Image
    Dim pictureb As New PictureBox

    Private Sub Items_MouseEnter(sender As Object, e As EventArgs)
        Inner = True
        Cursor = Cursors.Hand
        Me.Refresh()
    End Sub

    Private Sub Items_MouseLeave(sender As Object, e As System.EventArgs)
        Inner = False
        Cursor = Cursors.Hand
        Me.Refresh()
    End Sub

    Private Sub Items_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Dim i As Integer = 0
        Try
            For Each con As PictureBox In Controls.OfType(Of PictureBox)()
                i += 1
            Next
            If i = 0 Then
                pictureb.LoadAsync(URL)
                pictureb.Location = New Point(2, 2)
                pictureb.SizeMode = PictureBoxSizeMode.StretchImage
                AddHandler pictureb.Paint, AddressOf pcb_paint
                AddHandler pictureb.Click, AddressOf pcb_click
                AddHandler pictureb.MouseLeave, AddressOf Items_MouseLeave
                AddHandler pictureb.MouseEnter, AddressOf Items_MouseEnter
                pictureb.Width = Me.Width - 4
                pictureb.Height = Me.Height - 4
                Me.Controls.Add(pictureb)
            End If
            '   e.Graphics.DrawImage(DownloadImage(URL), New Rectangle(2, 2, Me.Width - 4, Me.Height - 4))

            Once = True
        Catch ex As Exception
            
        End Try


    End Sub
    Private Shared Function CheckLength(input As String, length As Integer) As String
        If input.Length > length Then
            Dim output As String = String.Empty
            Dim len As Integer = 0
            For Each chr As Char In input
                len += 1
                If len < (length + 1) Then
                    If Char.IsUpper(chr) Then
                        output += Char.ToUpper(chr)
                    Else
                        output += chr.ToString()
                    End If
                End If
            Next
            Return output & Convert.ToString("..")
        End If
        Return input
    End Function
    Private Sub pcb_paint(sender As Object, e As PaintEventArgs)
        e.Graphics.SmoothingMode = SmoothingMode.HighQuality
        If Inner = True Then
            e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(140, 25, 25, 25)), New Rectangle(Me.Width - 28, Me.Height - 28, 27, 27))
            e.Graphics.DrawRectangle(New Pen(Color.FromArgb(25, 25, 25)), New Rectangle(Me.Width - 28, Me.Height - 28, 27, 27))
            e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(140, 25, 25, 25)), New Rectangle(8, 8, Me.Width - 16, Me.Height / 2 - 65))
            e.Graphics.DrawRectangle(New Pen(Color.FromArgb(25, 25, 25)), New Rectangle(8, 8, Me.Width - 16, Me.Height / 2 - 65))
            e.Graphics.DrawRectangle(New Pen(Color.FromArgb(25, 25, 25)), New Rectangle(2, Me.Height - 18, Me.Width - 50, 17))
            e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(150, 25, 25, 25)), New Rectangle(2, Me.Height - 18, Me.Width - 50, 17))
            e.Graphics.DrawString(CheckLength(Type, 19), New Font("Arial", 7, FontStyle.Regular), Brushes.White, New Rectangle(2, Me.Height - 18, Me.Width - 50, 17), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
            e.Graphics.DrawString(_text, New Font("Arial", 8, FontStyle.Regular), Brushes.White, New Rectangle(8, 8, Me.Width - 16, Me.Height / 2 - 65), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
            e.Graphics.DrawString("4", New Font("Webdings", 16, FontStyle.Regular), Brushes.White, New Rectangle(Me.Width - 29, Me.Height - 27, 27, 27), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
        Else
            e.Graphics.FillRectangle(New SolidBrush(Color.FromArgb(140, 25, 25, 25)), New Rectangle(8, 8, Me.Width - 16, Me.Height / 2 - 65))
            e.Graphics.DrawRectangle(New Pen(Color.FromArgb(25, 25, 25)), New Rectangle(8, 8, Me.Width - 16, Me.Height / 2 - 65))
            e.Graphics.DrawString(_text, New Font("Arial", 8, FontStyle.Regular), Brushes.White, New Rectangle(8, 8, Me.Width - 16, Me.Height / 2 - 65), New StringFormat With {.Alignment = StringAlignment.Center, .LineAlignment = StringAlignment.Center})
        End If
    End Sub

    Private Sub pcb_click(sender As Object, e As EventArgs)
        RaiseEvent Clicked(Showlink & "|" & _text)
    End Sub



End Class
Public Class DictClass
    Public Class ItemCollection
        Inherits List(Of Item)
        Private Parent As DictClass
        Public Sub New(Parent As DictClass)
            Me.Parent = Parent
        End Sub
        Public Shadows Sub Add(Item As Item)
            MyBase.Add(Item)
        End Sub
        Public Shadows Sub AddRange(Range As List(Of Item))
            MyBase.AddRange(Range)
        End Sub
        Public Shadows Sub Clear()
            MyBase.Clear()
        End Sub
        Public Shadows Sub Remove(Item As Item)
            MyBase.Remove(Item)
        End Sub
        Public Shadows Sub RemoveAt(Index As Integer)
            MyBase.RemoveAt(Index)
        End Sub
        Public Shadows Sub RemoveAll(Predicate As System.Predicate(Of Item))
            MyBase.RemoveAll(Predicate)
        End Sub
        Public Shadows Sub RemoveRange(Index As Integer, Count As Integer)
            MyBase.RemoveRange(Index, Count)
        End Sub

    End Class
    Public Class Item
        Property Text As String
        Property OrderNumber As Integer
        Public Type As String = "None"
        Property PictureLink As Boolean = False
        Property URL_LINK As String = "http://i.imgur.com/blkrqBo.gif"
        Property ShowLink As String = "None"
        Protected UniqueId As Guid
        Sub New()
            UniqueId = Guid.NewGuid()
        End Sub
        Public Overrides Function ToString() As String
            Return Text
        End Function

        Public Overrides Function Equals(obj As Object) As Boolean
            If TypeOf obj Is Item Then
                Return (DirectCast(obj, Item).UniqueId = UniqueId)
            End If
            Return False
        End Function

    End Class
    Public _Items As New ItemCollection(Me)
    <DesignerSerializationVisibility(DesignerSerializationVisibility.Content)> _
    Public Property Items As ItemCollection
        Get
            Return _Items
        End Get
        Set(ByVal value As ItemCollection)
            _Items = value
        End Set
    End Property
End Class
