Public Class Form1

    Dim strSecret As String = InputBox("Enter the Secret Word").ToLower
    Dim strGuess As String = ""

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click
        'great game setup
        For intC As Integer = 0 To strSecret.Length - 1
            strGuess = strGuess.Insert(0, "-")
        Next

        Me.lblSecret.Text = strGuess
        Dim strLetter As String

        Do
            strLetter = InputBox("Guess A Letter").ToLower

            For intC As Integer = 0 To strSecret.Length - 1
                'this IF statement is logically great. However, it doesnt provide the user any feedback and almost appears "glitchy" to a user as they dont know that a guess is wrong, just that nothing happens
                'how could you change that?
                If strLetter = strSecret.Chars(intC) Then
                    strGuess = strGuess.Remove(intC, 1)
                    strGuess = strGuess.Insert(intC, strLetter)
                    Me.lblSecret.Text = strGuess
                End If
            Next

        Loop Until strGuess = strSecret Or strLetter = "*"

        'what about an ability to guess the entire word?

        If strGuess = strSecret Then
            MsgBox("Congradulations, You Guessed The Word: " & ChrW(34) & strGuess & ChrW(34))
        Else
            MsgBox("The Game Has Been Cancelled.")
        End If

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'This is where you fill global variables with values. Move the InputBox code for strSecret here
    End Sub
End Class
