
Partial Class pages_administrativo_CadastroCliente
    Inherits System.Web.UI.Page

    Protected Sub rblPessoa_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rblPessoa.SelectedIndexChanged

        Select Case rblPessoa.SelectedValue
            Case "Física"
                pnlFisica.Visible = True
                pnlJuridica.Visible = False
            Case "Jurídica"
                pnlFisica.Visible = False
                pnlJuridica.Visible = True
            Case Else

        End Select

    End Sub
End Class
