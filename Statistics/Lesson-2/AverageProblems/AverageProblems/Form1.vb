Public Class Form1
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.numbers.Clear()

        Me.numbers.Add(123.346346436363)
        Me.numbers.Add(-123.34534625245)
        Me.RichTextBox1.Clear()
        Me.RichTextBox1.Text = "Input:" & Environment.NewLine
        For Each i In numbers
            Me.RichTextBox1.AppendText(i.ToString() & Environment.NewLine)
        Next

    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        numbers.Clear()

        numbers.Add(20202.346346436363)
        numbers.Add(-20202.345346252449)
        Me.RichTextBox1.Clear()
        Me.RichTextBox1.Text = "Input:" & Environment.NewLine
        For Each i In numbers
            Me.RichTextBox1.AppendText(i.ToString() & Environment.NewLine)
        Next
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        numbers.Clear()

        numbers.Add(1341.3985724529573)
        numbers.Add(-1341.398572452958)
        Me.RichTextBox1.Clear()
        Me.RichTextBox1.Text = "Input:" & Environment.NewLine
        For Each i In numbers
            Me.RichTextBox1.AppendText(i.ToString() & Environment.NewLine)
        Next
    End Sub

    Private Sub Button4_Click(sender As Object, e As EventArgs) Handles Button4.Click
        numbers.Clear()

        numbers.Add(134.24524636363634)
        numbers.Add(-134.24524636363631)
        Me.RichTextBox1.Clear()
        Me.RichTextBox1.Text = "Input:" & Environment.NewLine
        For Each i In numbers
            Me.RichTextBox1.AppendText(i.ToString() & Environment.NewLine)
        Next
    End Sub

    Private Sub Button5_Click(sender As Object, e As EventArgs) Handles Button5.Click

        Dim NaiveSum As Double
        Dim NaiveCount As Integer
        For Each i In numbers
            NaiveSum += i
            NaiveCount += 1
        Next
        Dim NaiveMean As Double = NaiveSum / NaiveCount

        Dim KahanMean As Double
        Dim Index As Integer
        For Each i In numbers
            Index += 1
            KahanMean = KahanMean + (i - KahanMean) / Index
        Next

        Me.RichTextBox2.Clear()
        Me.RichTextBox2.AppendText("Naive Mean: " & NaiveMean & Environment.NewLine)
        Me.RichTextBox2.AppendText("Kahan Mean: " & KahanMean & Environment.NewLine)

    End Sub
End Class
