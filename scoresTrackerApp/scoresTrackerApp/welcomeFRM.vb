
Public Class welcomeFRM

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click

        Dim incorrect As Boolean = False
        Dim usernameInput As String = txtUser.Text
        Dim passwordInput As String = txtPass.Text

        Dim correctUser As String = "admin"
        Dim correctUser2 As String = "Admin"
        Dim correctPass As String = "password"
        Dim correctPass2 As String = "Password"

        If usernameInput = correctUser Then

            If passwordInput = correctPass Then
                homepageFRM.Show()
                txtPass.Text = ""
                Me.Hide()

            ElseIf passwordInput = correctPass2 Then
                homepageFRM.Show()
                txtPass.Text = ""
                Me.Hide()

            Else
                incorrect = True
                txtPass.Text = ""
            End If

        ElseIf usernameInput = correctUser2 Then

            If passwordInput = correctPass Then
                homepageFRM.Show()
                txtPass.Text = ""
                Me.Hide()

            ElseIf passwordInput = correctPass2 Then
                homepageFRM.Show()
                txtPass.Text = ""
                Me.Hide()

            Else
                incorrect = True
                txtPass.Text = ""
            End If

        Else
            incorrect = True
            txtPass.Text = ""
        End If

        If incorrect = True Then
            MessageBox.Show("Incorrect Login Credentials!", "Error:", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End If

    End Sub

End Class



