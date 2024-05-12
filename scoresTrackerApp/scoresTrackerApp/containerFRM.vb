Public Class containerFRM
    Private Sub containerFRM_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        homepageFRM.MdiParent = Me
        welcomeFRM.MdiParent = Me
        individualsDataFRM.MdiParent = Me
        teamDataFRM.MdiParent = Me
        welcomeFRM.Show()

    End Sub
End Class
