Imports Camadas.Negocio
Imports Camadas.Dominio.Estoque
Imports Excecoes

Partial Class pages_estoque_Produto
    Inherits System.Web.UI.Page

    Private controller As IEstoqueController = New EstoqueController

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim p As Produto

        If Not IsPostBack Then
            Me.txtNome.Attributes.Add("onkeypress", "return ValidarEntrada(event, '3')")
            Me.txtSigla.Attributes.Add("onkeypress", "return ValidarEntrada(event, '3')")
            Me.txtEspecificacao.Attributes.Add("onkeypress", "return ValidarEntrada(event, '3')")
            Me.txtEstoqueMinimo.Attributes.Add("onkeypress", "return ValidarEntrada(event, '1')")
            Me.txtPreco.Attributes.Add("onkeypress", "return ValidarEntrada(event, '4')")

            Try
                '-- LISTAR UNIDADES ---------
                drpUnidade.DataSource = controller.listarUnidade()
                drpUnidade.DataTextField = "EB15NOME"
                drpUnidade.DataValueField = "EB15CODIGO"
                drpUnidade.DataBind()
                drpUnidade.Items.Add(New ListItem("...", 0))
                drpUnidade.SelectedValue = 0
                '----------------------------

                '-- LISTAR PRODUTOS ---------
                p = New Produto
                gvProduto.DataSource = controller.listarProduto(p)
                gvProduto.DataBind()
                '----------------------------
            Catch ex As Exception
                ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Mensagem", "Mensagem('" & ex.Message.Replace("'", "") & "'); history.back()", True)
            End Try

        End If

    End Sub

    Protected Sub btnSalvar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalvar.Click
        Dim p As Produto

        Try
            If Me.txtNome.Text.Trim = String.Empty Then Throw New BusinessException("O CAMPO NOME É OBRIGATÓRIO.")
            If Me.txtSigla.Text.Trim = String.Empty Then Throw New BusinessException("O CAMPO SIGLA É OBRIGATÓRIO.")
            If Me.txtPreco.Text.Trim = String.Empty Then Throw New BusinessException("O PREÇO NOME É OBRIGATÓRIO.")
            If Me.drpUnidade.SelectedValue > 0 Then Throw New BusinessException("O CAMPO UNIDADE É OBRIGATÓRIO.")
            If Me.txtEspecificacao.Text.Trim = String.Empty Then Throw New BusinessException("O CAMPO ESPECIFICAÇÃO É OBRIGATÓRIO.")
            If Me.txtEstoqueMinimo.Text.Trim = String.Empty Then Throw New BusinessException("O CAMPO ESTOQUE MÍNIMO É OBRIGATÓRIO.")

            p = New Produto
            p.Nome = Me.txtNome.Text.Trim.ToUpper
            p.Sigla = Me.txtSigla.Text.Trim.ToUpper
            p.Preco = Double.Parse(Me.txtPreco.Text)
            p.Unidade.Codigo = Me.drpUnidade.SelectedValue
            p.Especficicao = Me.txtEspecificacao.Text.Trim.ToUpper
            p.EstoqueMinimo = Double.Parse(Me.txtEstoqueMinimo.Text)

            controller.cadastrarProduto(p)

            ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Mensagem", "Mensagem('PRODUTO ATUALIZADO COM SUCESSO.');", True)
        Catch ex As Exception
            ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Mensagem", "Mensagem('" & ex.Message.Replace("'", "") & "'); history.back()", True)
        End Try
    End Sub

End Class
