Imports Camadas.Dominio.Estoque
Imports Camadas.Negocio
Imports System.Drawing

Partial Class pages_estoque_MovimentacaoEstoque
    Inherits System.Web.UI.Page

    Private controller As IEstoqueController = New EstoqueController
    Private saldo As Double = 0

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim p As Produto

        If Not IsPostBack Then
            'Me.txtQuantidade.Attributes.Add("onkeypress", "return ValidarEntrada(event, '1')")

            Try
                p = New Produto

                drpProduto.DataSource = controller.listarProduto(p)
                drpProduto.DataTextField = "NOMECOMPLETO"
                drpProduto.DataValueField = "EB08CODIGO"
                drpProduto.DataBind()
                drpProduto.Items.Add(New ListItem("TODOS...", 0))
                drpProduto.SelectedValue = 0
            Catch ex As Exception
                ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Mensagem", "Mensagem('" & ex.Message.Replace("'", "") & "'); history.back()", True)
            End Try

        End If
    End Sub

    Protected Sub btnPesquisar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPesquisar.Click
        Dim dataIni, dataFin As String

        Try
            dataIni = Format(DateTime.Parse(Me.txtDataInicial.Text), "yyyy-MM-dd")
            dataFin = Format(DateTime.Parse(Me.txtDataFinal.Text), "yyyy-MM-dd")
            gvMovimento.DataSource = controller.movimentoEstoque(dataIni, dataFin, Me.drpProduto.SelectedValue)
            gvMovimento.DataBind()

            Me.lblSaldo.Text = saldo
        Catch ex As Exception
            ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Mensagem", "Mensagem('" & ex.Message.Replace("'", "") & "'); history.back()", True)
        End Try
    End Sub

    Protected Sub gvMovimento_RowDataBound(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewRowEventArgs) Handles gvMovimento.RowDataBound
        If Not e.Row.DataItem Is Nothing Then
            If e.Row.DataItem("OPERACAO") = "SAÍDA" Then
                e.Row.BackColor = ColorTranslator.FromHtml("#EE8262")
                e.Row.ForeColor = Color.White

                saldo -= Double.Parse(e.Row.DataItem("EB12VALOR"))
            Else
                saldo += Double.Parse(e.Row.DataItem("EB12VALOR"))
            End If
        End If
    End Sub

End Class
