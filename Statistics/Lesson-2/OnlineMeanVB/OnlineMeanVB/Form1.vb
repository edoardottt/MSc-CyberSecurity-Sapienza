Public Class Form1

    Public RandomNum As New Random

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Me.Timer1.Start()

    End Sub

    Public CurrentMean As Double = 0

    Public count As Integer

    Public Sub Timer1_Tick(sender As System.Object, e As System.EventArgs) Handles Timer1.Tick

        count = count + 1

        Dim Exam = "Exam" & count

        Dim Grade As Integer = Me.RandomNum.Next(18, 31)

        CurrentMean = CurrentMean + (Grade - CurrentMean) / count

        Me.RichTextBox1.AppendText(Exam.PadRight(11) & Grade &
                                   " ===> Current Mean:" & CurrentMean & vbCrLf)

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

        Me.Timer1.Stop()


    End Sub

End Class
