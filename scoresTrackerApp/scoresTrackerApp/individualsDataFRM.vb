Public Class individualsDataFRM

    Dim valuesList As String()

    Private Sub individualsDataFRM_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        reloadIndividualsData()
    End Sub


    Public Sub reloadIndividualsData()

        Dim outputVal As String() = homepageFRM.returnIndividualsInfo()
        Dim linesQuantity As Integer = outputVal.Length - 1
        valuesList = outputVal

        ListBox1.Items.Clear()

        For populateTextbox = 2 To linesQuantity

            Try
                Dim temp As String = outputVal(populateTextbox)
                If temp = "##INVALID-STRING-ERROR##" Then
                    Console.WriteLine("invalid data, this player was not added to overview list")
                Else
                    ListBox1.Items.Add(temp)
                End If

            Catch ex As Exception
                ListBox1.Items.Add("Error loading player")
            End Try

        Next

    End Sub

    Private Sub ListBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ListBox1.SelectedIndexChanged

        Dim nodeIndex As String = ListBox1.SelectedItem.ToString

        Dim temp() As String = Split(nodeIndex, " ")
        Dim tempListLength As Integer = temp.Length

        txtTeamScoreBig.Text = temp(0)
        txtTeamRankBig.Text = temp(tempListLength - 1)

    End Sub
End Class