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
            strLetter = InputBox("Guess A Letter").ToLower

            For intC As Integer = 0 To strSecret.Length - 1
                
                If strLetter = strSecret.Chars(intC) Then
                    strGuess = strGuess.Remove(intC, 1)
                    strGuess = strGuess.Insert(intC, strLetter)
                    Me.lblSecret.Text = strGuess
                End If

                'Here is the area of code that is telling the user if their guess is right or wrong.
                'However, I can't seem to get it to work. It keeps popping up with one the MsgBoxes in every char charecter.
                'I know that the problem is in the IfThen statement but I can't figure out how to get it to only show up once.
                If strLetter = strGuess.Chars(intC) Then
                    MsgBox("You have guessed correctly: " & ChrW(34) & strLetter & ChrW(34) & " is in the secret word.")
                ElseIf strLetter <> strGuess.Chars(intC) And strLetter <> "*" Then
                    MsgBox("Your guess is incorrect: " & ChrW(34) & strLetter & ChrW(34) & " is not in the secret word.")
                End If
            Next

            'Here is a short line of code that allows for the user to input the entire word and see if they are correct.
            strFinalGuess = InputBox("Can You Guess the Word? If Not, Press Enter").ToLower

            If strFinalGuess <> strSecret Then
                MsgBox("Sorry, That Is Not The Secret Word. Try Again.")
            End If

        Loop Until strGuess = strSecret Or strLetter = "*" Or strFinalGuess = strSecret

        If strGuess = strSecret Or strFinalGuess = strSecret Then
            MsgBox("Congradulations, You Guessed The Word: " & ChrW(34) & strSecret & ChrW(34))
            Me.lblSecret.Text = strSecret
        Else
            MsgBox("The Game Has Been Cancelled.")
            strGuess = strGuess.Insert(0, "-")
            Me.lblSecret.Text = strGuess
        End If

    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        'This is where you fill global variables with values. Move the InputBox code for strSecret here

        'I tried putting the secret word inputbox here but it messed up the code and wouldn't run smoothly.
    End Sub
End Class
