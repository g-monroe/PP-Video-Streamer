'By Only3 <- on hackforums
'Modified by Nettro
Public Class NotificationBox
    Inherits Control

    Private Image As Image
    Private BorderColor As Color
    Private IsOverClose As Boolean
    Private NotificationText As String
    Public Property ShowNotificationBox As Boolean = True
    Public Property ShowNotificationBoxButton1 As Boolean = True
    Public Property RoundedCorners As Boolean = True
    Public Property ShowCloseButton As Boolean = True
    Public Property NotificationType As Type = Type.Notice

    Dim Comment = "iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAAEvSURBVDjLY/j//z8DJZiBagZEtO8QAuKlQPwTiP/jwbuAWAWbARtXHrz1//efv//xgS0n74MMuQ3EbHADgBweIP7z99+//x++/fv/8tO//88+/vv/5P2//w/f/ft/782//7df/f1/5xXE8OoFx0GGmCEbIJcz9QBY8gVQ47MP//4/Bmp+8Pbf/7tQzddf/P1/9RnEgM5VZ0EGeGM14ClQ86N3UM2v//2/9RKi+QpQ88UnuA2AewHk/PtAW++8/vv/JlDzted//18Gar7wBGTAH7ABtYtOgAywxBqIIEOQAcg1Fx7/BRuMFoicuKLxDyzK5u64Cjfo/ecfYD5Q/DLWaMSGgQrvPH/3FabxOxDXEp0SgYp7Z267AtL4BYgLSUrKQA1KQHwPiFPolxcGzAAA94sPIr7iagsAAAAASUVORK5CYII="
    Dim [Error] = "iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAAIsSURBVDjLpVNLSJQBEP7+h6uu62vLVAJDW1KQTMrINQ1vPQzq1GOpa9EppGOHLh0kCEKL7JBEhVCHihAsESyJiE4FWShGRmauu7KYiv6Pma+DGoFrBQ7MzGFmPr5vmDFIYj1mr1WYfrHPovA9VVOqbC7e/1rS9ZlrAVDYHig5WB0oPtBI0TNrUiC5yhP9jeF4X8NPcWfopoY48XT39PjjXeF0vWkZqOjd7LJYrmGasHPCCJbHwhS9/F8M4s8baid764Xi0Ilfp5voorpJfn2wwx/r3l77TwZUvR+qajXVn8PnvocYfXYH6k2ioOaCpaIdf11ivDcayyiMVudsOYqFb60gARJYHG9DbqQFmSVNjaO3K2NpAeK90ZCqtgcrjkP9aUCXp0moetDFEeRXnYCKXhm+uTW0CkBFu4JlxzZkFlbASz4CQGQVBFeEwZm8geyiMuRVntzsL3oXV+YMkvjRsydC1U+lhwZsWXgHb+oWVAEzIwvzyVlk5igsi7DymmHlHsFQR50rjl+981Jy1Fw6Gu0ObTtnU+cgs28AKgDiy+Awpj5OACBAhZ/qh2HOo6i+NeA73jUAML4/qWux8mt6NjW1w599CS9xb0mSEqQBEDAtwqALUmBaG5FV3oYPnTHMjAwetlWksyByaukxQg2wQ9FlccaK/OXA3/uAEUDp3rNIDQ1ctSk6kHh1/jRFoaL4M4snEMeD73gQx4M4PsT1IZ5AfYH68tZY7zv/ApRMY9mnuVMvAAAAAElFTkSuQmCC"
    Dim Exclamation = "iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAAJPSURBVDjLpZPLS5RhFMYfv9QJlelTQZwRb2OKlKuINuHGLlBEBEOLxAu46oL0F0QQFdWizUCrWnjBaDHgThCMoiKkhUONTqmjmDp2GZ0UnWbmfc/ztrC+GbM2dXbv4ZzfeQ7vefKMMfifyP89IbevNNCYdkN2kawkCZKfSPZTOGTf6Y/m1uflKlC3LvsNTWArr9BT2LAf+W73dn5jHclIBFZyfYWU3or7T4K7AJmbl/yG7EtX1BQXNTVCYgtgbAEAYHlqYHlrsTEVQWr63RZFuqsfDAcdQPrGRR/JF5nKGm9xUxMyr0YBAEXXHgIANq/3ADQobD2J9fAkNiMTMSFb9z8ambMAQER3JC1XttkYGGZXoyZEGyTHRuBuPgBTUu7VSnUAgAUAWutOV2MjZGkehgYUA6O5A0AlkAyRnotiX3MLlFKduYCqAtuGXpyH0XQmOj+TIURt51OzURTYZdBKV2UBSsOIcRp/TVTT4ewK6idECAihtUKOArWcjq/B8tQ6UkUR31+OYXP4sTOdisivrkMyHodWejlXwcC38Fvs8dY5xaIId89VlJy7ACpCNCFCuOp8+BJ6A631gANQSg1mVmOxxGQYRW2nHMha4B5WA3chsv22T5/B13AIicWZmNZ6cMchTXUe81Okzz54pLi0uQWp+TmkZqMwxsBV74Or3od4OISPr0e3SHa3PX0f3HXKofNH/UIG9pZ5PeUth+CyS2EMkEqs4fPEOBJLsyske48/+xD8oxcAYPzs4QaS7RR2kbLTTOTQieczfzfTv8QPldGvTGoF6/8AAAAASUVORK5CYII="
    Dim Accept = "iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAAKfSURBVDjLpZPrS1NhHMf9O3bOdmwDCWREIYKEUHsVJBI7mg3FvCxL09290jZj2EyLMnJexkgpLbPUanNOberU5taUMnHZUULMvelCtWF0sW/n7MVMEiN64AsPD8/n83uucQDi/id/DBT4Dolypw/qsz0pTMbj/WHpiDgsdSUyUmeiPt2+V7SrIM+bSss8ySGdR4abQQv6lrui6VxsRonrGCS9VEjSQ9E7CtiqdOZ4UuTqnBHO1X7YXl6Daa4yGq7vWO1D40wVDtj4kWQbn94myPGkCDPdSesczE2sCZShwl8CzcwZ6NiUs6n2nYX99T1cnKqA2EKui6+TwphA5k4yqMayopU5mANV3lNQTBdCMVUA9VQh3GuDMHiVcLCS3J4jSLhCGmKCjBEx0xlshjXYhApfMZRP5CyYD+UkG08+xt+4wLVQZA1tzxthm2tEfD3JxARH7QkbD1ZuozaggdZbxK5kAIsf5qGaKMTY2lAU/rH5HW3PLsEwUYy+YCcERmIjJpDcpzb6l7th9KtQ69fi09ePUej9l7cx2DJbD7UrG3r3afQHOyCo+V3QQzE35pvQvnAZukk5zL5qRL59jsKbPzdheXoBZc4saFhBS6AO7V4zqCpiawuptwQG+UAa7Ct3UT0hh9p9EnXT5Vh6t4C22QaUDh6HwnECOmcO7K+6kW49DKqS2DrEZCtfuI+9GrNHg4fMHVSO5kE7nAPVkAxKBxcOzsajpS4Yh4ohUPPWKTUh3PaQEptIOr6BiJjcZXCwktaAGfrRIpwblqOV3YKdhfXOIvBLeREWpnd8ynsaSJoyESFphwTtfjN6X1jRO2+FxWtCWksqBApeiFIR9K6fiTpPiigDoadqCEag5YUFKl6Yrciw0VOlhOivv/Ff8wtn0KzlebrUYwAAAABJRU5ErkJggg=="
    Dim Help = "iVBORw0KGgoAAAANSUhEUgAAABAAAAAQCAYAAAAf8/9hAAAABGdBTUEAAK/INwWK6QAAABl0RVh0U29mdHdhcmUAQWRvYmUgSW1hZ2VSZWFkeXHJZTwAAAKkSURBVDjLpZPdT5JhGMb9W+BPaK3matVqndXWOOigA6fmJ9DUcrUMlrN0mNMsKTUznQpq6pyKAm8CIogmypcg8GIiX8rHRHjhVbPt6o01nMvZWge/k3vP9duuZ/edAyDnf/hjoCMP2Vr3gUDj3CdV6zT1xZ6iFDaKnLEkBFOmPfaZArWT5sw60iFP+BAbOzTcQSqDZzsNRyCNkcVoaGghzDlVQKylOHJrMrUZ2Yf52y6kc36IxpyoH1lHF7EBgyMKV4jCJ5U/1UVscU4IZOYEa3I1HtwI01hwxlDLhDoJD/wxGr5YGmOLAdRIrVCuhmD3JdA6SQabx12srGB0KSpc86ew4olDOGjH4x4z0gdHDD9+c4TaQQtq+k2Yt0egXYugTmoVZgV9cyHSxXTtJjZR3WNCVfcK/NE0ppYDUNu2QTMCtS0IbrsOrVMOWL27eNJtJLOCDoWXdgeTEEosqPxoBK/TwDzWY9rowy51gJ1dGr2zLpS2aVH5QQ+Hbw88sZ7OClrGXbQrkMTTAQu4HXqUv9eh7J0OSfo7tiIU+GItilpUuM/AF2tg98eR36Q+FryQ2kjbVhximQu8dgPKxPMoeTuH4tfqDIWvCBQ2KlDQKEe9dBlGTwR36+THFZg+QoUxAL0jgsoOQzYYS+wjskcjTzSToVAkA7Hqg4Spc6tm4vgT+eIFVvmb+eCSMwLlih/cNg0KmpRoGzdl+BXOb5jAsMYNjSWAm9VjwesPR1knFilPNMu510CkdPZtqK1BvJQsoaRZjqLGaTzv1UNp9EJl9uNqxefU5QdDnFNX+Y5Qxrn9bDLUR6zjqzsMizeWYdG5gy6ZDbk8aehiuYRz5jHdeDTKvlY1IrhSMUxe4g9SuVwpdaFsgDxf2i84V9zH/us1/is/AdevBaK9Tb3EAAAAAElFTkSuQmCC"

    Public Enum Type
        Notice
        Success
        Warning
        [Error]
        Help
    End Enum

    Protected Overrides Sub OnMouseMove(ByVal e As MouseEventArgs)
        MyBase.OnMouseMove(e)
        If e.X >= Width - 20 AndAlso e.X <= Width - 10 AndAlso e.Y > 4 AndAlso e.Y < 16 Then
            IsOverClose = True
        Else
            IsOverClose = False
        End If
        Invalidate()
    End Sub

    Protected Overrides Sub OnMouseDown(ByVal e As MouseEventArgs)
        MyBase.OnMouseDown(e)
        If ShowCloseButton Then If IsOverClose Then FindForm.Close() 'Hide()
        Invalidate()
    End Sub

    Private Function RoundRect(ByVal Rect As Rectangle, ByVal Slope As Integer) As Drawing2D.GraphicsPath
        RoundRect = New Drawing2D.GraphicsPath
        RoundRect.AddArc(New Rectangle(Rect.X, Rect.Y, Slope * 2, Slope * 2), -180, 90)
        RoundRect.AddArc(New Rectangle(Rect.Width - Slope * 2 + Rect.X, Rect.Y, Slope * 2, Slope * 2), -90, 90)
        RoundRect.AddArc(New Rectangle(Rect.Width - Slope * 2 + Rect.X, Rect.Height - Slope * 2 + Rect.Y, Slope * 2, Slope * 2), 0, 90)
        RoundRect.AddArc(New Rectangle(Rect.X, Rect.Height - Slope * 2 + Rect.Y, Slope * 2, Slope * 2), 90, 90)
        RoundRect.CloseAllFigures()
        Return RoundRect
    End Function

    Sub New()
        SetStyle(ControlStyles.AllPaintingInWmPaint Or ControlStyles.UserPaint Or ControlStyles.OptimizedDoubleBuffer Or ControlStyles.ResizeRedraw, True)

        Size = New Size(170, 50)
        ForeColor = Color.DimGray
        Font = New Font("Tahoma", 9)
    End Sub

    Protected Overrides Sub OnPaint(ByVal e As PaintEventArgs)
        MyBase.OnPaint(e)

        Dim G As Graphics = e.Graphics
        Dim Rectangle As New Rectangle(0, 0, Width - 1, Height - 1)

        G.SmoothingMode = Drawing2D.SmoothingMode.HighQuality
        G.TextRenderingHint = Drawing.Text.TextRenderingHint.ClearTypeGridFit
        G.Clear(Parent.BackColor)

        Select Case NotificationType
            Case Type.Notice : NotificationText = "NOTICE"
            Case Type.Success : NotificationText = "SUCCESS"
            Case Type.Warning : NotificationText = "WARNING"
            Case Type.Error : NotificationText = "ERROR"
            Case Type.Help : NotificationText = "HELP"
        End Select

        Select Case NotificationType
            Case Type.Notice
                BackColor = Color.FromArgb(227, 247, 252) : BorderColor = Color.FromArgb(142, 217, 246)
                Image = Image.FromStream(New IO.MemoryStream(Convert.FromBase64String(Comment)))
            Case Type.Success
                BackColor = Color.FromArgb(233, 255, 217) : BorderColor = Color.FromArgb(166, 202, 138)
                Image = Image.FromStream(New IO.MemoryStream(Convert.FromBase64String(Accept)))
            Case Type.Warning
                BackColor = Color.FromArgb(255, 248, 196) : BorderColor = Color.FromArgb(242, 199, 121)
                Image = Image.FromStream(New IO.MemoryStream(Convert.FromBase64String(Exclamation)))
            Case Type.Error
                BackColor = Color.FromArgb(255, 236, 236) : BorderColor = Color.FromArgb(245, 172, 166)
                Image = Image.FromStream(New IO.MemoryStream(Convert.FromBase64String([Error])))
            Case Type.Help
                BackColor = Color.FromArgb(230, 230, 230) : BorderColor = Color.FromArgb(180, 180, 180)
                Image = Image.FromStream(New IO.MemoryStream(Convert.FromBase64String(Help)))
        End Select

        If RoundedCorners Then
            G.FillPath(New SolidBrush(BackColor), RoundRect(Rectangle, 8))
            G.DrawPath(New Pen(BorderColor), RoundRect(Rectangle, 8))
        Else
            G.FillRectangle(New SolidBrush(BackColor), Rectangle)
            G.DrawRectangle(New Pen(BorderColor), Rectangle)
        End If

        If Image Is Nothing Then
            G.DrawString(NotificationText, New Font(Font.FontFamily, Font.Size, FontStyle.Bold), New SolidBrush(ForeColor), New Point(10, 5))
            G.DrawString(Text, Font, New SolidBrush(ForeColor), New Rectangle(10, 21, Width - 17, Height - 5))
        Else
            G.DrawImage(Image, 12, 4, 16, 16)
            G.DrawString(NotificationText, New Font(Font.FontFamily, Font.Size, FontStyle.Bold), New SolidBrush(ForeColor), New Point(30, 5))
            G.DrawString(Text, Font, New SolidBrush(ForeColor), New Rectangle(10, 21, Width - 17, Height - 5))
        End If
        If ShowCloseButton Then
            If IsOverClose Then
                G.FillEllipse(New SolidBrush(BorderColor), New Rectangle(Width - 23, 2, 17, 17))
            End If
            G.DrawString("r", New Font("Marlett", 7, FontStyle.Bold), New SolidBrush(ForeColor), New Rectangle(Width - 20, 7, Width, Height))
        End If
    End Sub
End Class