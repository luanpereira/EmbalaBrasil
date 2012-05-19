
Partial Class pages_administrativo_CadastroCliente
    Inherits System.Web.UI.Page

    Protected Sub rblPessoa_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rblPessoa.SelectedIndexChanged

        Select Case rblPessoa.SelectedValue
            Case "Física"
                pnlFisica.Visible = True
                pnlJuridica.Visible = False
                pnlComum.Visible = True
                pnlOutras.Visible = True
            Case "Jurídica"
                pnlFisica.Visible = False
                pnlJuridica.Visible = True
                pnlComum.Visible = True
                pnlOutras.Visible = True
            Case Else

        End Select

    End Sub

    Protected Sub drpTipoCliente_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles drpTipoCliente.SelectedIndexChanged
        Select Case drpTipoCliente.SelectedValue
            Case "M"
                drpVendedor.Enabled = False
                drpVendedor.ToolTip = "Se o cliente é Master, então não é possível selecionar o vendedor."
            Case "C"
                drpVendedor.Enabled = True
                drpVendedor.ToolTip = "Como o cliente é Comum, então selecione o vendedor."
            Case Else
                drpVendedor.Enabled = False
                drpVendedor.ToolTip = "Selecione o tipo de cliente"
        End Select
    End Sub
End Class
