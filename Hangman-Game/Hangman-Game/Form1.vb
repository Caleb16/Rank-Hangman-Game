Public Class Form1

    Dim strSecret As String = InputBox("Enter the Secret Word").ToLower
    Dim strGuess As String = ""

    Private Sub btnStart_Click(sender As Object, e As EventArgs) Handles btnStart.Click

        For intC As Integer = 0 To strSecret.Length - 1
            strGuess = strGuess.Insert(0, "-")
        Next

        Me.lblSecret.Text = strGuess
        Dim strLetter As String
        Dim strFinalGuess As String

        
        Do
            Dim blnLetterinWord As Boolean = False

            strLetter = InputBox("Guess A Letter").ToLower

            For intC As Integer = 0 To strSecret.Length - 1

                If strLetter = strSecret.Chars(intC) Then
                    strGuess = strGuess.Remove(intC, 1)
                    strGuess = strGuess.Insert(intC, strLetter)
                    Me.lblSecret.Text = strGuess
                End If

                If strLetter = strGuess.Chars(intC) Then
                    blnLetterinWord = True
                End If
            Next

            If blnLetterinWord = True Then
                MsgBox("You have guessed correctly: " & ChrW(34) & strLetter & ChrW(34) & " is in the secret word.")
            ElseIf blnLetterinWord = False And strLetter <> "*" Then
                MsgBox("Your guess is incorrect: " & ChrW(34) & strLetter & ChrW(34) & " is not in the secret word.")
            End If

            'Here is a short line of code that allows for the user to input the entire word and see if they are correct.
            If strLetter <> "*" Then
                strFinalGuess = InputBox("Can You Guess the Word? If Not, Press Enter").ToLower
            End If

            If strFinalGuess <> strSecret And strLetter <> "*" And strFinalGuess <> "" Then
                MsgBox("Sorry, That Is Not The Secret Word. Try Again.")
            ElseIf strFinalGuess = "" And strLetter <> "*" Then
                MsgBox("Secret Word Not Known.")
            End If

        Loop Until strGuess = strSecret Or strLetter = "*" Or strFinalGuess = strSecret

        If strGuess = strSecret Or strFinalGuess = strSecret Then
            MsgBox("Congradulations, You Guessed The Word: " & ChrW(34) & strSecret & ChrW(34))
            Me.lblSecret.Text = strSecret
        Else
            MsgBox("The Game Has Been Cancelled.")
            strGuess = strGuess.Insert(0, "-")
            Me.lblSecret.Text = ""
        End If

    End Sub
End Class
