Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.AllowDrop = True
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        RichTextBox1.Text = "Hello, World!"
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        RichTextBox1.Text = ""
    End Sub

    Private Sub RichTextBox1_MouseHover(sender As Object, e As EventArgs) Handles RichTextBox1.MouseHover
        RichTextBox1.BackColor = Color.Red
    End Sub
    Private Sub RichTextBox1_MouseLeave(sender As Object, e As EventArgs) Handles RichTextBox1.MouseLeave
        RichTextBox1.BackColor = Color.Empty
    End Sub
    Private Sub RichTextBox1_DragDrop(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles RichTextBox1.DragDrop
        Dim files() As String = e.Data.GetData(DataFormats.FileDrop)
        For Each path In files
            RichTextBox1.Text = path
        Next
    End Sub

    Private Sub RichTextBox1_DragEnter(sender As System.Object, e As System.Windows.Forms.DragEventArgs) Handles RichTextBox1.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then
            e.Effect = DragDropEffects.Copy
        End If
    End Sub
End Class
