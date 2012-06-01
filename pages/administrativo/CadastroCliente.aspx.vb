Imports Excecoes
Imports Camadas.Negocio
Imports Infraestrutura.Utils
Imports Camadas.Dominio.Administrativo

Partial Class pages_administrativo_CadastroCliente
    Inherits System.Web.UI.Page

    Private controller As IClienteController = New ClienteController
    Private controllerVendedor As IVendedorController = New VendedorController

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Not IsPostBack Then

            '--LISTAR VENDEDORES -----------
            drpVendedor.DataValueField = "EB06CODIGO"
            drpVendedor.DataTextField = "EB06NOME"
            drpVendedor.DataSource = controllerVendedor.listarVendedor
            drpVendedor.DataBind()
            drpVendedor.Items.Add(New ListItem("Selecione...", 0))
            drpVendedor.SelectedValue = 0
            '-------------------------------

            '--LISTAR ESTADOS --------------
            drpUF.DataValueField = "EB99CODIGO"
            drpUF.DataTextField = "EB99NOME"
            drpUF.DataSource = ListarEstados()
            drpUF.DataBind()
            drpUF.Items.Add(New ListItem("Selecione...", 0))
            drpUF.SelectedValue = 0

            drpCidade.Items.Add(New ListItem("Selecione o Estado...", 0))
            '-------------------------------

        End If

    End Sub

    Protected Sub rblPessoa_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles rblPessoa.SelectedIndexChanged

        Select Case rblPessoa.SelectedValue
            Case "Física"
                pnlFisica.Visible = True
                pnlJuridica.Visible = False
                pnlComum.Visible = True
                pnlOutras.Visible = True
            Case "Jurídica"
                pnlFisica.Visible = False
                pnlJuridica.Visible = True
                pnlComum.Visible = True
                pnlOutras.Visible = True
            Case Else

        End Select

    End Sub

    Protected Sub drpTipoCliente_SelectedIndexChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles drpTipoCliente.SelectedIndexChanged
        Select Case drpTipoCliente.SelectedValue
            Case "M"
                drpVendedor.Enabled = False
                drpVendedor.ToolTip = "Se o cliente é Master, então não é possível selecionar o vendedor."
            Case "C"
                drpVendedor.Enabled = True
                drpVendedor.ToolTip = "Como o cliente é Comum, então selecione o vendedor."
            Case Else
                drpVendedor.Enabled = False
                drpVendedor.ToolTip = "Selecione o tipo de cliente"
        End Select
    End Sub

    Protected Sub btnSalvar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnSalvar.Click
        Dim cliente As Camadas.Dominio.Administrativo.Cliente
        Dim pFisica As PessoaFisica = Nothing
        Dim pJuridica As PessoaJuridica = Nothing

        Try
            If rblPessoa.SelectedValue = String.Empty Then
                Throw New BusinessException("VOCÊ DEVE SELECIONAR UM TIPO DE PESSOA.")
            End If

            If drpTipoCliente.SelectedValue = "0" Then
                Throw New BusinessException("VOCÊ DEVE SELECIONAR UM TIPO DE CLIENTE.")
            End If

            Select Case rblPessoa.SelectedIndex
                Case 1
                    If txtNome.Text = String.Empty Then Throw New BusinessException("O CAMPO NOME É OBRIGATÓRIO.")
                    If txtCPF.Text = String.Empty Then Throw New BusinessException("O CAMPO CPF É OBRIGATÓRIO.")
                    pFisica = New PessoaFisica
                    pFisica.Nome = txtNome.Text
                    pFisica.Cpf = txtCPF.Text.Replace(".", "").Replace("-", "")
                    pFisica.Rg = txtRg.Text

                Case 0
                    If txtRazaoSocial.Text = String.Empty Then Throw New BusinessException("O CAMPO RAZÃO SOCIAL É OBRIGATÓRIO.")
                    If txtFantasia.Text = String.Empty Then Throw New BusinessException("O CAMPO FANTASIA É OBRIGATÓRIO.")
                    If txtCNPJ.Text = String.Empty Then Throw New BusinessException("O CAMPO CNPJ É OBRIGATÓRIO.")
                    pJuridica = New PessoaJuridica
                    pJuridica.RazaoSocial = txtRazaoSocial.Text
                    pJuridica.Fantasia = txtFantasia.Text
                    pJuridica.CNPJ = txtCNPJ.Text.Replace(".", "").Replace("-", "").Replace("/", "")
                    pJuridica.InscricaoEstadual = txtInscEstadual.Text

                Case Else
                    Throw New Exception("FALHA NA SELEÇÃO DE PESSOA. INFORME AO SUPORTE.")
            End Select

            Select Case drpTipoCliente.SelectedValue
                Case "C"
                    If drpVendedor.SelectedValue = 0 Then Throw New BusinessException("O CAMPO VENDEDOR É OBRIGATÓRIO.")
                Case Else
            End Select

            If chkAcesso.Checked AndAlso txtSenha.Text = String.Empty Then
                Throw New BusinessException("SE O CLIENTE FOR HABILITADO A TER ACESSO A WEB, ENTÃO DEVERÁ DIGITAR UMA SENHA.")
            End If

            cliente = New Camadas.Dominio.Administrativo.Cliente
            cliente.TipoPessoa = IIf(rblPessoa.SelectedValue = "Física", eTipoPessoa.Física, eTipoPessoa.Jurídica)
            cliente.TipoCliente = IIf(drpTipoCliente.SelectedValue = "M", eTipoCliente.Master, eTipoCliente.Comum)
            cliente.PessoaFisica = pFisica
            cliente.PessoaJuridica = pJuridica
            cliente.Endereco.Logradouro = txtEndereco.Text
            cliente.Endereco.Cidade.Codigo = drpCidade.SelectedValue
            cliente.Endereco.Cidade.Nome = drpCidade.SelectedItem.Text
            cliente.Endereco.Cidade.Estado.Codigo = drpUF.SelectedValue
            cliente.Endereco.Cidade.Estado.Nome = drpUF.SelectedItem.Text
            cliente.Endereco.Cep = txtCEP.Text
            cliente.Contato.FoneResidencial = txtTelefoneFixo.Text
            cliente.Contato.FoneCelular = txtCelular.Text
            cliente.Contato.Fax = txtFax.Text
            cliente.Contato.Email = txtEmail.Text
            cliente.Vendedor.Codigo = drpVendedor.SelectedValue
            cliente.isAcessoWeb = chkAcesso.Checked
            cliente.Senha = txtSenha.Text

            controller.cadastrarCliente(cliente)

            ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Mensagem", "Mensagem('CLIENTE CADASTRADO COM SUCESSO.');", True)

            Response.Redirect("~/pages/administrativo/ConsultarCliente.aspx")
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
End Class
