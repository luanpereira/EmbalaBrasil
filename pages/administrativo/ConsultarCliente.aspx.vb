Imports System.Data

Partial Class pages_administrativo_ConsultarCliente
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Protected Sub btnPesquisar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPesquisar.Click
        Dim dtb As DataTable
        Dim row As DataRow

        dtb = New DataTable
        dtb.Columns.Add("CODIGO")
        dtb.Columns.Add("NOME")
        dtb.Columns.Add("CPFCNPJ")
        dtb.Columns.Add("VENDEDOR")
        dtb.Columns.Add("TELEFONE")

        row = dtb.NewRow
        row.Item("CODIGO") = "1"
        row.Item("NOME") = "SUPERMERCADO CARONE"
        row.Item("CPFCNPJ") = "87425835007115"
        row.Item("VENDEDOR") = "EMANUEL"
        row.Item("TELEFONE") = "9832212345 9888235212"
        dtb.Rows.Add(row)

        row = dtb.NewRow
        row.Item("CODIGO") = "2"
        row.Item("NOME") = "SUPERMERCADO MATEUS"
        row.Item("CPFCNPJ") = "82736515008765"
        row.Item("VENDEDOR") = DBNull.Value
        row.Item("TELEFONE") = "9888235212"
        dtb.Rows.Add(row)

        row = dtb.NewRow
        row.Item("CODIGO") = "3"
        row.Item("NOME") = "FRANCISCO DE SOUSA JUNIOR"
        row.Item("CPFCNPJ") = "12345678900"
        row.Item("VENDEDOR") = "NEY"
        row.Item("TELEFONE") = "9832212345 9881142131"
        dtb.Rows.Add(row)

        row = dtb.NewRow
        row.Item("CODIGO") = "4"
        row.Item("NOME") = "GUAJAJARAS FRUTARIA"
        row.Item("CPFCNPJ") = "92837465000001"
        row.Item("VENDEDOR") = "SAMUEL"
        row.Item("TELEFONE") = ""
        dtb.Rows.Add(row)

        gvCliente.DataSource = dtb
        gvCliente.DataBind()
    End Sub

    Protected Sub btnAddCliente_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddCliente.Click
        Response.Redirect("~/pages/administrativo/CadastroCliente.aspx")
    End Sub
End Class
