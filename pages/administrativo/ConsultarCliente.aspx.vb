Imports System.Data
Imports Camadas.Negocio
Imports Camadas.Dominio.Administrativo

Partial Class pages_administrativo_ConsultarCliente
    Inherits System.Web.UI.Page

    Private controller As IClienteController = New ClienteController

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then
            gvCliente.DataSource = controller.listarCliente
            gvCliente.DataBind()

        End If

    End Sub

    Protected Sub btnPesquisar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnPesquisar.Click
        Dim cliente As Camadas.Dominio.Administrativo.Cliente
        Dim pF As PessoaFisica
        Dim pJ As PessoaJuridica

        Try
            cliente = New Camadas.Dominio.Administrativo.Cliente
            pF = New PessoaFisica
            pF.Nome = txtNome.Text
            pF.Cpf = txtCPF.Text

            pJ = New PessoaJuridica
            pJ.Fantasia = txtNome.Text
            pJ.RazaoSocial = txtNome.Text
            pJ.CNPJ = txtCPF.Text

            cliente.PessoaFisica = pF
            cliente.PessoaJuridica = pJ

            gvCliente.DataSource = controller.listarCliente(cliente)
            gvCliente.DataBind()

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
        Response.Redirect("~/pages/administrativo/CadastroCliente.aspx")
    End Sub

    Protected Sub gvCliente_RowCommand(ByVal sender As Object, ByVal e As System.Web.UI.WebControls.GridViewCommandEventArgs) Handles gvCliente.RowCommand
        Dim id As Integer

        If e.CommandName = "Pesquisar" Then
            id = gvCliente.DataKeys.Item(e.CommandArgument).Value
        End If

    End Sub

End Class
