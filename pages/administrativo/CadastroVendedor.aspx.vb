Imports Excecoes
Imports Camadas.Negocio
Imports Infraestrutura.Utils
Imports Camadas.Dominio.Administrativo
Imports System.Data

Partial Class pages_administrativo_CadastroCliente
    Inherits System.Web.UI.Page

    Private controller As IVendedorController = New VendedorController

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim id As Integer

        If Not IsPostBack Then
            Me.txtNome.Attributes.Add("onkeypress", "return ValidarEntrada(event, '3')")
            Me.txtEndereco.Attributes.Add("onkeypress", "return ValidarEntrada(event, '3')")
            Me.txtCPF.Attributes.Add("onblur", "return ValidaCPF(this);")

            '--LISTAR ESTADOS --------------
            drpUF.DataValueField = "EB99CODIGO"
            drpUF.DataTextField = "EB99NOME"
            drpUF.DataSource = ListarEstados()
            drpUF.DataBind()
            drpUF.Items.Add(New ListItem("Selecione...", 0))
            drpUF.SelectedValue = 0

            drpCidade.Items.Add(New ListItem("Selecione o Estado...", 0))
            '-------------------------------

            ViewState("idUsuario") = 0

            Try
                id = Integer.Parse(Request.QueryString("id"))
                If id > 0 Then
                    ViewState("idVendedor") = id
                    Me.listarDadosVendedor(id)
                Else
                    ViewState("idVendedor") = 0
                End If

            Catch ex As Exception
                ViewState("idVendedor") = 0
                ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Mensagem", "Mensagem('ERRO NO ID. " & ex.Message.Replace("'", "") & "'); history.back()", True)
            End Try

        End If

    End Sub

    Private Sub listarDadosVendedor(ByVal id As Integer)
        Dim v As Camadas.Dominio.Administrativo.Vendedor
        Dim dtb As DataTable

        Try
            v = New Camadas.Dominio.Administrativo.Vendedor
            v.Codigo = id

            dtb = controller.listarVendedor(v)

            txtNome.Text = dtb.Rows(0).Item("EB06NOME").ToString
            txtCPF.Text = dtb.Rows(0).Item("EB06CPF").ToString
            txtRg.Text = dtb.Rows(0).Item("EB06RG").ToString
            txtEndereco.Text = dtb.Rows(0).Item("EB06ENDERECO").ToString
            drpUF.SelectedValue = dtb.Rows(0).Item("CODIGO_UF").ToString
            drpUF_SelectedIndexChanged(Nothing, Nothing)
            drpCidade.SelectedValue = dtb.Rows(0).Item("FK0698CIDADEUF").ToString
            txtCEP.Text = dtb.Rows(0).Item("EB06CEP").ToString
            txtDataNascimento.Text = dtb.Rows(0).Item("EB06DATANASCIMENTO").ToString
            txtTelefoneFixo.Text = dtb.Rows(0).Item("EB06FONEFIXO").ToString
            txtCelular.Text = dtb.Rows(0).Item("EB06CELULAR").ToString
            txtFax.Text = dtb.Rows(0).Item("EB06FAX").ToString
            txtEmail.Text = dtb.Rows(0).Item("EB06EMAIL").ToString
            txtDataNascimento.Text = Format(DateTime.Parse(dtb.Rows(0).Item("EB06DATANASCIMENTO").ToString), "dd/MM/yyyy")
            chkAcesso.Checked = IIf(dtb.Rows(0).Item("ACESSO").ToString = "1", True, False)
            ViewState("idUsuario") = dtb.Rows(0).Item("CODIGO_USUARIO").ToString

        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub btnSalvar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalvar.Click
        Dim vendedor As Camadas.Dominio.Administrativo.Vendedor
        Dim pFisica As PessoaFisica = Nothing

        Try

            If txtDataNascimento.Text = String.Empty Then Throw New BusinessException("O CAMPO DATA DE NASCIMENTO É OBRIGATÓRIO")
            If txtNome.Text = String.Empty Then Throw New BusinessException("O CAMPO NOME É OBRIGATÓRIO.")
            If txtCPF.Text = String.Empty Then Throw New BusinessException("O CAMPO CPF É OBRIGATÓRIO.")
            If Not IsNumeric(ViewState("idUsuario")) Then Throw New BusinessException("VENDEDOR SEM USUÁRIO. ENTRE EM CONTATO COM O SUPORTE.")

            pFisica = New PessoaFisica
            pFisica.Nome = txtNome.Text.ToUpper
            pFisica.Cpf = txtCPF.Text.Replace(".", "").Replace("-", "")
            pFisica.Rg = txtRg.Text

            If chkAcesso.Checked AndAlso txtSenha.Text = String.Empty AndAlso ViewState("idVendedor") = 0 Then
                Throw New BusinessException("SE O VENDEDOR FOR HABILITADO A TER ACESSO A WEB, ENTÃO DEVERÁ DIGITAR UMA SENHA.")
            End If

            vendedor = New Camadas.Dominio.Administrativo.Vendedor
            vendedor.Codigo = ViewState("idVendedor")
            vendedor.PessoaFisica = pFisica
            vendedor.Endereco.Logradouro = txtEndereco.Text.ToUpper
            vendedor.Endereco.Cidade.Codigo = drpCidade.SelectedValue
            vendedor.Endereco.Cidade.Nome = drpCidade.SelectedItem.Text
            vendedor.Endereco.Cidade.Estado.Codigo = drpUF.SelectedValue
            vendedor.Endereco.Cidade.Estado.Nome = drpUF.SelectedItem.Text
            vendedor.Endereco.Cep = txtCEP.Text
            vendedor.Contato.FoneResidencial = txtTelefoneFixo.Text.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "")
            vendedor.Contato.FoneCelular = txtCelular.Text.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "")
            vendedor.Contato.Fax = txtFax.Text.Replace("(", "").Replace(")", "").Replace("-", "").Replace(" ", "")
            vendedor.Contato.Email = txtEmail.Text.ToLower
            vendedor.isAcessoWeb = chkAcesso.Checked
            vendedor.Senha = txtSenha.Text
            vendedor.DataNascimento = Format(DateTime.Parse(txtDataNascimento.Text), "yyyy-MM-dd")
            vendedor.CodigoUsuario = ViewState("idUsuario")
            vendedor.ToString.ToUpper()

            controller.cadastrarVendedor(vendedor)

            ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Mensagem", "Mensagem('VENDEDOR ATUALIZADO COM SUCESSO.'); history.back();", True)
        Catch ex As BusinessException
            ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Mensagem", "Mensagem('" & ex.Message.Replace("'", "") & "');", True)
        Catch ex As Exception
            ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Mensagem", "Mensagem('" & ex.Message.Replace("'", "") & "');", True)
        End Try

    End Sub

    Protected Sub drpUF_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles drpUF.SelectedIndexChanged
        Try
            drpCidade.Items.Clear()
            drpCidade.DataValueField = "EB98CODIGO"
            drpCidade.DataTextField = "EB98NOME"
            drpCidade.DataSource = ListarCidades(drpUF.SelectedValue)
            drpCidade.DataBind()
            drpCidade.Items.Add(New ListItem("Selecione a Cidade...", 0))
            drpCidade.SelectedValue = 0
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Protected Sub chkAcesso_CheckedChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles chkAcesso.CheckedChanged

    End Sub

    Protected Sub btnCancelar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnCancelar.Click
        Response.Redirect("~/pages/administrativo/ConsultarVendedor.aspx")
    End Sub
End Class
