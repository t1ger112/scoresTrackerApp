Public Class teamDataFRM
    Private Sub teamDataFRM_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        reloadTeamsData()

    End Sub

    Public Sub reloadTeamsData()

        Dim outputVal As String() = homepageFRM.returnIndividualsInfo()
        Dim linesQuantity As Integer = outputVal.Length

        For populateTextbox = 2 To linesQuantity
            'ListBox1.Items.Add(outputVal(populateTextbox))
        Next

    End Sub

End Class