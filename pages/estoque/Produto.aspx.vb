Imports Camadas.Negocio
Imports Camadas.Dominio.Estoque
Imports Excecoes
Imports System.Data

Partial Class pages_estoque_Produto
    Inherits System.Web.UI.Page

    Private controller As IEstoqueController = New EstoqueController

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim p As Produto

        If Not IsPostBack Then
            ViewState("idProduto") = 0

            Me.txtNome.Attributes.Add("onkeypress", "return ValidarEntrada(event, '3')")
            Me.txtSigla.Attributes.Add("onkeypress", "return ValidarEntrada(event, '3')")
            Me.txtEspecificacao.Attributes.Add("onkeypress", "return ValidarEntrada(event, '9')")
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

        Else
            Try
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
            If Me.drpUnidade.SelectedValue = 0 Then Throw New BusinessException("O CAMPO UNIDADE É OBRIGATÓRIO.")
            If Me.txtEspecificacao.Text.Trim = String.Empty Then Throw New BusinessException("O CAMPO ESPECIFICAÇÃO É OBRIGATÓRIO.")
            If Me.txtEstoqueMinimo.Text.Trim = String.Empty Then Throw New BusinessException("O CAMPO ESTOQUE MÍNIMO É OBRIGATÓRIO.")

            p = New Produto
            p.Codigo = ViewState("idProduto")
            p.Nome = Me.txtNome.Text.Trim.ToUpper
            p.Sigla = Me.txtSigla.Text.Trim.ToUpper
            p.Preco = Double.Parse(Me.txtPreco.Text)
            p.Unidade.Codigo = Me.drpUnidade.SelectedValue
            p.Especificacao = Me.txtEspecificacao.Text.Trim.ToUpper
            p.EstoqueMinimo = Double.Parse(Me.txtEstoqueMinimo.Text)

            controller.cadastrarProduto(p)

            ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Mensagem", "Mensagem('PRODUTO ATUALIZADO COM SUCESSO.');window.top.location.reload();", True)
        Catch ex As BusinessException
            ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Mensagem", "Mensagem('" & ex.Message.Replace("'", "") & "');", True)
        Catch ex As Exception
            ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Mensagem", "Mensagem('" & ex.Message.Replace("'", "") & "');", True)
        End Try
    End Sub

    Protected Sub gvProduto_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvProduto.RowCommand
        Dim id As Integer
        Dim p As Produto
        Dim dtb As DataTable

        ViewState("idProduto") = 0

        If e.CommandName = "Pesquisar" Then
            id = gvProduto.DataKeys.Item(e.CommandArgument).Value
            p = New Produto
            p.Codigo = id
            dtb = controller.listarProduto(p)

            ViewState("idProduto") = id
            Me.txtNome.Text = dtb.Rows(0).Item("EB08NOME").ToString
            Me.txtSigla.Text = dtb.Rows(0).Item("EB08SIGLA").ToString
            Me.txtPreco.Text = dtb.Rows(0).Item("EB08PRECO").ToString
            Me.drpUnidade.SelectedValue = dtb.Rows(0).Item("FK0815UNIDADE")
            Me.txtEspecificacao.Text = dtb.Rows(0).Item("EB08ESPECIFICACAO").ToString
            Me.txtEstoqueMinimo.Text = dtb.Rows(0).Item("EB08ESTOQUEMINIMO").ToString

        End If
    End Sub

    Protected Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Response.Redirect("~/pages/principal")
    End Sub

    Protected Sub btnNovo_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNovo.Click
        Response.Redirect("~/pages/estoque/Produto.aspx")
    End Sub
End Class
