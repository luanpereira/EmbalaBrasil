
Partial Class pages_estoque_ConsultarPedido
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnNovoPedido_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnNovoPedido.Click
        Response.Redirect("~/pages/estoque/Pedido.aspx")
    End Sub

End Class
