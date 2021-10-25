Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks

Namespace Lesson1CS
    Class Ball
        Private width As Integer
        Private height As Integer
        Private x As Integer
        Private y As Integer
        Private stepx As Integer
        Private stepy As Integer

        Public Sub New(ByVal w As Integer, ByVal h As Integer, ByVal xVar As Integer, ByVal yVar As Integer, ByVal stepxVar As Integer, ByVal stepyVar As Integer)
            width = w
            height = h
            x = xVar
            y = yVar
            stepx = stepxVar
            stepy = stepyVar
        End Sub

        Public Function GetWidth() As Integer
            Return width
        End Function

        Public Function GetHeight() As Integer
            Return height
        End Function

        Public Function GetX() As Integer
            Return x
        End Function

        Public Function GetY() As Integer
            Return y
        End Function

        Public Function GetStepX() As Integer
            Return stepx
        End Function

        Public Function GetStepY() As Integer
            Return stepy
        End Function

        Public Sub SetWidth(ByVal w As Integer)
            width = w
        End Sub

        Public Sub SetHeight(ByVal h As Integer)
            height = h
        End Sub

        Public Sub SetX(ByVal xVar As Integer)
            x = xVar
        End Sub

        Public Sub SetY(ByVal yVar As Integer)
            y = yVar
        End Sub

        Public Sub SetStepX(ByVal stepxVar As Integer)
            stepx = stepxVar
        End Sub

        Public Sub SetStepY(ByVal stepyVar As Integer)
            stepy = stepyVar
        End Sub
    End Class
End Namespace
