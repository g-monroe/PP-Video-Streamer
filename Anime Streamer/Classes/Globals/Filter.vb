Imports System.Text.RegularExpressions
Imports System.Net

Public Class Filter
    '\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\
    '[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[[Mid Return Function Get the Middle of a String]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]]
    '////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    Public Shared Function midReturn(ByVal total As String, ByVal first As String, ByVal last As String)
        If last.Length < 1 Then
            midReturn = total.Substring(total.IndexOf(first))
        End If
        If first.Length < 1 Then
            midReturn = total.Substring(0, (total.IndexOf(last)))
        End If
        Try
            midReturn =
                ((total.Substring(total.IndexOf(first), (total.IndexOf(last) - total.IndexOf(first)))).Replace(first, "")) _
                    .Replace(last, "")

        Catch ArgumentOutOfRangeException As Exception
            '   midReturn = "ERROR"
        End Try

    End Function

    Public Shared Function getBetween(input As String, before As String, after As String) As String
        Try
            Return Regex.Split(Regex.Split(input, before)(1), after)(0)
        Catch ex As Exception
        End Try
    End Function
    Public Shared Function CheckForAlphaCharacters(ByVal StringToCheck As String)
        For i = 0 To StringToCheck.Length - 1
            If Char.IsLetter(StringToCheck.Chars(i)) Then
                Return True
            End If
        Next
        Return False
    End Function
    Public Shared Function Roundnum(obj As Integer)
        Return Math.Sign(obj) * Math.Floor(Math.Abs(obj) * 100) / 100.0
    End Function
 


End Class
Public Class GetSourcee
    Public Vidlin As String
    Public Typ As Type
    Enum Type
        WebRequest
        Webclient
    End Enum
    Public Shared Function GetSource(Vidlink As String, Type As Type)
        If Type = Type.WebRequest Then
            Dim request As System.Net.HttpWebRequest = System.Net.HttpWebRequest.Create(Vidlink)
            Using response As System.Net.HttpWebResponse = request.GetResponse
                Dim sr As System.IO.StreamReader = New System.IO.StreamReader(response.GetResponseStream())
                Return sr.ReadToEnd
            End Using
        ElseIf Type = Type.Webclient Then
            Using web As New WebClient
                Return web.DownloadString(New Uri(Vidlink))
            End Using
        End If
    End Function

End Class