Public Class Form1

    Dim count As Integer = 0
    Dim dict As New Dictionary(Of String, Integer)

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Me.Timer1.Start()
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Timer1.Stop()
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Dim grade As Integer = GetRandom(18, 31)
        count += 1

        If dict.ContainsKey(grade) Then
            dict(grade) += 1
        Else
            dict.Add(grade, 1)
        End If

        Me.RichTextBox1.Text = "Distribution:" & vbCrLf

        For Each kv As KeyValuePair(Of String, Integer) In dict
            Me.RichTextBox1.Text += String.Format("Grade {0}: {1} / {2}" & vbCrLf, kv.Key, kv.Value, count)
        Next

    End Sub

    Public Function GetRandom(ByVal Min As Integer, ByVal Max As Integer) As Integer
        Dim Generator As System.Random = New System.Random()
        Return Generator.Next(Min, Max)
    End Function

End Class
