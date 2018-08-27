Public Class UControl_Recommendation
    Public link As String
    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click
        Encycl.GetDetails(link)
    End Sub

    Private Sub TextBox1_Click(sender As Object, e As EventArgs) Handles TextBox1.Click
        Encycl.GetDetails(link)
    End Sub

    Private Sub TextBox2_Click(sender As Object, e As EventArgs) Handles TextBox2.Click
        Encycl.GetDetails(link)
    End Sub

    Private Sub GroupBox1_Click(sender As Object, e As EventArgs) Handles GroupBox1.Click
        Encycl.GetDetails(link)
    End Sub

    Private Sub TextBox2_TextChanged(sender As Object, e As EventArgs) Handles TextBox2.TextChanged

    End Sub
End Class
