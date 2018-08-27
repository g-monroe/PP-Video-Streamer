Imports Microsoft.VisualBasic.CompilerServices
Imports System
Imports System.Drawing
Imports System.Runtime.InteropServices

<StructLayout(LayoutKind.Sequential)> _
Friend Structure Bloom
    Public _Name As String
    Private _Value As Color
    Public ReadOnly Property Name As String
        Get
            Return Me._Name
        End Get
    End Property

    Public Property Value As Color
        Get
            Return Me._Value
        End Get
        Set(ByVal value As Color)
            Me._Value = value
        End Set
    End Property

    Public Property ValueHex As String
        Get
            Dim introduced4 As String = Me._Value.R.ToString("X2", Nothing)
            Dim introduced5 As String = Me._Value.G.ToString("X2", Nothing)
            Return ("#" & introduced4 & introduced5 & Me._Value.B.ToString("X2", Nothing))
        End Get
        Set(ByVal value As String)
            Try
                Me._Value = ColorTranslator.FromHtml(value)
            Catch exception1 As Exception
                ProjectData.SetProjectError(exception1)
                ProjectData.ClearProjectError()
                Return
                ProjectData.ClearProjectError()
            End Try
        End Set
    End Property

    Public Sub New(ByVal name As String, ByVal value As Color)
        ' = New Bloom
        Me._Name = name
        Me._Value = value
    End Sub
End Structure


