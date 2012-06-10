Imports Camadas.Negocio
Imports Camadas.Dominio.Estoque

Partial Class pages_estoque_EntradaEstoque
    Inherits System.Web.UI.Page

    Private controller As IEstoqueController = New EstoqueController

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim p As Produto

        If Not IsPostBack Then
            Try
                p = New Produto

                drpProduto.DataSource = controller.listarProduto(p)
                drpProduto.DataTextField = "NOMECOMPLETO"
                drpProduto.DataValueField = "CODIGOPRECO"
                drpProduto.DataBind()
                drpProduto.Items.Add(New ListItem("Selecione um Produto...", 0))
                drpProduto.SelectedValue = 0
            Catch ex As Exception
                ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Mensagem", "Mensagem('" & ex.Message.Replace("'", "") & "'); history.back()", True)
            End Try
 
        End If
    End Sub

    Protected Sub btnSalvar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalvar.Click
        Dim ep As EntradaProduto
        Dim i As ItemPedido
        Dim array As String()

        Try
            ep = New EntradaProduto
            i = New ItemPedido

            array = drpProduto.SelectedValue.Split(";")
            i.Produto.Codigo = array(0)
            i.Produto.Preco = array(1)
            i.Quantidade = txtQuantidade.Text

            ep.Itens.Add(i)
            ep.FormaPagamento.Codigo = 0
            ep.NotaFiscal = txtNotaFiscal.Text
            ep.DataPagamento = Format(DateTime.Parse(txtDataPg.Text), "yyyy-MM-dd")
            ep.Observacao = txtObs.Text

            controller.entradaProduto(ep)

            ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Mensagem", "Mensagem('ENTRADA DE PRODUTO CADASTRADA COM SUCESSO.');window.top.location.reload();", True)
        Catch ex As Exception
            ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Mensagem", "Mensagem('" & ex.Message.Replace("'", "") & "');", True)
        End Try
    End Sub
End Class
