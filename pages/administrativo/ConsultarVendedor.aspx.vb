Imports System.Data
Imports Camadas.Negocio
Imports Camadas.Dominio.Administrativo

Partial Class pages_administrativo_ConsultarCliente
    Inherits System.Web.UI.Page

    Private controller As IVendedorController = New VendedorController

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim v As Camadas.Dominio.Administrativo.Vendedor

        If Not IsPostBack Then
            Me.txtNome.Attributes.Add("onkeypress", "return ValidarEntrada(event, '3')")

            v = New Camadas.Dominio.Administrativo.Vendedor
            gvVendedor.DataSource = controller.listarVendedor(v)
            gvVendedor.DataBind()

        End If

    End Sub

    Protected Sub btnPesquisar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPesquisar.Click
        Dim vendedor As Camadas.Dominio.Administrativo.Vendedor
        Dim pF As PessoaFisica

        Try
            vendedor = New Camadas.Dominio.Administrativo.Vendedor
            pF = New PessoaFisica
            pF.Nome = txtNome.Text
            pF.Cpf = txtCPF.Text

            vendedor.PessoaFisica = pF

            gvVendedor.DataSource = controller.listarVendedor(vendedor)
            gvVendedor.DataBind()

        Catch ex As Exception
            ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Mensagem", "Mensagem('" & ex.Message.Replace("'", "") & "');", True)
        End Try


        'Dim dtb As DataTable
        'Dim row As DataRow

        'dtb = New DataTable
        'dtb.Columns.Add("CODIGO")
        'dtb.Columns.Add("NOME")
        'dtb.Columns.Add("CPFCNPJ")
        'dtb.Columns.Add("VENDEDOR")
        'dtb.Columns.Add("TELEFONE")

        'row = dtb.NewRow
        'row.Item("CODIGO") = "1"
        'row.Item("NOME") = "SUPERMERCADO CARONE"
        'row.Item("CPFCNPJ") = "87425835007115"
        'row.Item("VENDEDOR") = "EMANUEL"
        'row.Item("TELEFONE") = "9832212345 9888235212"
        'dtb.Rows.Add(row)

        'gvCliente.DataSource = dtb
        'gvCliente.DataBind()
    End Sub

    Protected Sub btnAddCliente_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnAddCliente.Click
        Response.Redirect("~/pages/administrativo/CadastroVendedor.aspx")
    End Sub

    Protected Sub gvVendedor_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvVendedor.RowCommand
        Dim id As Integer

        If e.CommandName = "Pesquisar" Then
            id = gvVendedor.DataKeys.Item(e.CommandArgument).Value
            If id > 0 Then Response.Redirect("~/pages/administrativo/CadastroVendedor.aspx?id=" & id)
        End If

    End Sub

End Class
