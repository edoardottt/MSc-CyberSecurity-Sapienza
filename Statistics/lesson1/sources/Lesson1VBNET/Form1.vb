Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms

Namespace Lesson1CS
    Public Partial Class Lesson1
        Inherits Form

        Public Sub New()
            InitializeComponent()
        End Sub

        Private running As Boolean = False
        Private populated As Boolean = False
        Private timer As Timer = New Timer()
        Private balls As List(Of Ball) = New List(Of Ball)()
        Private ball1 As Ball = New Ball(20, 20, 0, 0, 24, 24)
        Private ball2 As Ball = New Ball(30, 30, 10, 10, 20, 20)
        Private ball3 As Ball = New Ball(40, 40, 20, 20, 16, 16)
        Private ball4 As Ball = New Ball(50, 50, 30, 30, 12, 12)
        Private ball5 As Ball = New Ball(60, 60, 40, 40, 8, 8)

        Private Sub populateBalls()
            pictureBox1.BackColor = Color.White
            balls.Add(ball1)
            balls.Add(ball2)
            balls.Add(ball3)
            balls.Add(ball4)
            balls.Add(ball5)
        End Sub

        Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs)
            richTextBox1.Text = "Hello World! Click the button below to animate the balls, click again to stop them."
            richTextBox1.SelectionStart = 0
            richTextBox1.SelectionLength = richTextBox1.Text.Length
            richTextBox1.SelectionFont = New Font("Maiandra GD", 13)
        End Sub

        Private Sub button2_Click(ByVal sender As Object, ByVal e As EventArgs)
            If Not populated Then
                populateBalls()
                populated = True
            End If

            If Not running Then
                running = True
                AddHandler timer.Tick, New EventHandler(AddressOf timer_Tick)
                timer.Interval = 10
                timer.Start()
            Else
                timer.[Stop]()
                running = False
            End If
        End Sub

        Private Sub timer_Tick(ByVal sender As Object, ByVal e As EventArgs)
            For i As Integer = 0 To balls.Count - 1
                updateBall(sender, e, balls(i))
            Next

            pictureBox1.Paint += New PaintEventHandler(AddressOf DrawCircles)
        End Sub

        Private Sub updateBall(ByVal sender As Object, ByVal e As EventArgs, ByVal b As Ball)
            Dim width As Integer = b.GetWidth()
            Dim height As Integer = b.GetHeight()
            Dim x As Integer = b.GetX()
            Dim y As Integer = b.GetY()
            Dim stepx As Integer = b.GetStepX()
            Dim stepy As Integer = b.GetStepY()
            x += stepx

            If x + width > pictureBox1.Width OrElse x < 0 Then
                stepx = -stepx
            End If

            y += stepy

            If y + height > pictureBox1.Height OrElse y < 0 Then
                stepy = -stepy
            End If

            b.SetWidth(width)
            b.SetHeight(height)
            b.SetX(x)
            b.SetY(y)
            b.SetStepX(stepx)
            b.SetStepY(stepy)
            pictureBox1.Refresh()
        End Sub

        Private Sub DrawCircles(ByVal sender As Object, ByVal e As PaintEventArgs)
            e.Graphics.Clear(BackColor)
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias

            For i As Integer = 0 To balls.Count - 1
                Dim width As Integer = balls(i).GetWidth()
                Dim height As Integer = balls(i).GetHeight()
                Dim x As Integer = balls(i).GetX()
                Dim y As Integer = balls(i).GetY()
                e.Graphics.FillEllipse(Brushes.Yellow, x, y, width, height)
                e.Graphics.DrawEllipse(Pens.Black, x, y, width, height)
            Next
        End Sub
    End Class
End Namespace
