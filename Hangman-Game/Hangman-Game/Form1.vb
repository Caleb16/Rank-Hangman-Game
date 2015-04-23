Public Class Form1

    Dim strSecret As String = InputBox("Enter the Secret Word").ToLower
    Dim strGuess As String = ""

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click

        For intC As Integer = 0 To strSecret.Length - 1
            strGuess = strGuess.Insert(0, "-")
        Next

        Me.lblSecret.Text = strGuess
        Dim strLetter As String

        Do
            strLetter = InputBox("Guess A Letter").ToLower

            For intC As Integer = 0 To strSecret.Length - 1
                If strLetter = strSecret.Chars(intC) Then
                    strGuess = strGuess.Remove(intC, 1)
                    strGuess = strGuess.Insert(intC, strLetter)
                    Me.lblSecret.Text = strGuess
                End If
            Next

        Loop Until strGuess = strSecret Or strLetter = "*"

        If strGuess = strSecret Then
            MsgBox("Congradulations, You Guessed The Word: " & ChrW(34) & strGuess & ChrW(34))
        Else
            MsgBox("The Game Has Been Cancelled.")
        End If

    End Sub
End Class
