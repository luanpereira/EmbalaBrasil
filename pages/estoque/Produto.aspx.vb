Imports Camadas.Negocio

Partial Class pages_estoque_Produto
    Inherits System.Web.UI.Page

    Private controller As IEstoqueController = New EstoqueController

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            Me.txtNome.Attributes.Add("onkeypress", "return ValidarEntrada(event, '3')")
            Me.txtSigla.Attributes.Add("onkeypress", "return ValidarEntrada(event, '3')")
            Me.txtEspecificacao.Attributes.Add("onkeypress", "return ValidarEntrada(event, '3')")
            Me.txtEstoqueMinimo.Attributes.Add("onkeypress", "return ValidarEntrada(event, '3')")

            Try
                '-- LISTAR UNIDADES ---------
                drpUnidade.DataSource = controller.listarUnidade()
                drpUnidade.DataTextField = "EB15NOME"
                drpUnidade.DataValueField = "EB15CODIGO"
                drpUnidade.DataBind()
                drpUnidade.Items.Add(New ListItem("...", 0))
                drpUnidade.SelectedValue = 0
                '----------------------------
            Catch ex As Exception
                ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Mensagem", "Mensagem('" & ex.Message.Replace("'", "") & "'); history.back()", True)
            End Try

        End If

    End Sub

    Protected Sub btnSalvar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalvar.Click

    End Sub

End Class
