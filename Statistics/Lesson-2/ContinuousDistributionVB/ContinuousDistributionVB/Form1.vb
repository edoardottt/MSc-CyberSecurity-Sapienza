Public Class Form1

    Public Exams As New List(Of Exam)
    Public R As New Random
    Public values As Integer
    Public Mean As Double
    Public Index As Integer

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        
        Me.Timer1.Start()

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        values += 1
        Dim MaxGrade As Decimal = 30
        Dim RandomGrade As Decimal = Math.Round(MaxGrade * R.NextDouble, 2)
        Dim exam As New Exam
        exam.Grade = RandomGrade
        Exams.Add(exam)
        Index += 1
        Mean = Mean + (RandomGrade - Mean) / Index
        Me.RichTextBox1.Text = values & " values scanned" & Environment.NewLine & "Online Arithmetic mean: " & Mean & Environment.NewLine

    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click

        Me.RichTextBox2.Clear()

        Dim ListOfIntervals As New List(Of Interval)
        Dim IntervalSize As Double = 3
        Dim StartingEndPoint As Double = 0

        Dim Intervallo As New Interval
        Intervallo.LowerEnd = StartingEndPoint
        Intervallo.UpperEnd = Intervallo.LowerEnd + IntervalSize
        ListOfIntervals.Add(Intervallo)
        For Each exam As Exam In Exams
            Dim ExamAllocated As Boolean = False
            For Each interval In ListOfIntervals
                If exam.Grade > interval.LowerEnd AndAlso exam.Grade <= interval.UpperEnd Then
                    interval.Count += 1
                    ExamAllocated = True
                    Exit For
                End If
            Next
            If ExamAllocated Then Continue For

            If exam.Grade <= ListOfIntervals(0).LowerEnd Then
                Do
                    Dim NewLeftInterval As New Interval
                    NewLeftInterval.UpperEnd = ListOfIntervals(0).LowerEnd
                    NewLeftInterval.LowerEnd = NewLeftInterval.UpperEnd - IntervalSize
                    ListOfIntervals.Insert(0, NewLeftInterval)
                    If exam.Grade > NewLeftInterval.LowerEnd AndAlso exam.Grade <= NewLeftInterval.UpperEnd Then
                        NewLeftInterval.Count += 1
                        Exit Do
                    End If
                Loop
            ElseIf exam.Grade > ListOfIntervals(ListOfIntervals.Count - 1).UpperEnd Then

                Do
                    Dim NewRightInterval As New Interval
                    NewRightInterval.LowerEnd = ListOfIntervals(ListOfIntervals.Count - 1).UpperEnd
                    NewRightInterval.UpperEnd = NewRightInterval.LowerEnd + IntervalSize
                    ListOfIntervals.Add(NewRightInterval)
                    If exam.Grade > NewRightInterval.LowerEnd AndAlso exam.Grade <= NewRightInterval.UpperEnd Then
                        NewRightInterval.Count += 1
                        Exit Do
                    End If
                Loop
            Else
                Throw New Exception("[===== ERROR =====]")
            End If
        Next

        Me.RichTextBox2.AppendText(("Grade Interval").PadRight(20) & "Count" & Environment.NewLine)
        Me.RichTextBox2.AppendText("-----------------------------------------" & Environment.NewLine)
        For Each Interval As Interval In ListOfIntervals
            Me.RichTextBox2.AppendText(("(" & Interval.LowerEnd & " - " & Interval.UpperEnd & ")").PadRight(20) & Interval.Count & "/" & values & Environment.NewLine)

        Next

    End Sub
    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Me.Timer1.Stop()
    End Sub

    Public Class Exam
        Public Grade As Double
    End Class

    Public Class Interval
        Public LowerEnd As Double
        Public UpperEnd As Double
        Public Count As Integer
        Public RelativeFrequency As Double
        Public Percentage As Double
    End Class

End Class
