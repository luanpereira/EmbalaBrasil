<%@ Page Language="VB" MasterPageFile="~/EMBALA.master" AutoEventWireup="false" CodeFile="CadastroCliente.aspx.vb" Inherits="pages_administrativo_CadastroCliente" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div id="formulario">
        <div id="FormCliente" class="boxes">            
            <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
            </asp:ToolkitScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                <h2>Cadastrar novo Cliente</h2>
                <fieldset>
                    <legend>Qual Tipo de Pessoa?</legend>
                    <asp:RadioButtonList ID="rblPessoa" runat="server" AutoPostBack="True" 
                        RepeatDirection="Horizontal" Width="203px">
                        <asp:ListItem>Jurídica</asp:ListItem>
                        <asp:ListItem>Física</asp:ListItem>
                    </asp:RadioButtonList>
                    <p>
                        <asp:Label ID="label17" runat="server" CssClass="lbl" Text="Tipo do Cliente" 
                            ForeColor="#FC0000"></asp:Label>
                        <asp:DropDownList ID="drpTipoCliente" runat="server" AutoPostBack="True" >
                            <asp:ListItem Value="0">Selecione...</asp:ListItem>
                            <asp:ListItem Value="M">Cliente Master - Compra direto da empresa</asp:ListItem>
                            <asp:ListItem Value="C">Cliente Comum - Compra por meio de um vendedor.</asp:ListItem>
                        </asp:DropDownList>
                    </p>
                </fieldset>

                <fieldset>
                    <legend>Dados Pessoais</legend>
                    <asp:Panel ID="pnlFisica" runat="server" Height="124px" Visible="False">
                        <p>
                            <asp:Label ID="label" runat="server" Text="Nome" CssClass="lbl" 
                                ForeColor="#FC0000"></asp:Label>
                            <asp:TextBox ID="txtNome" runat="server" CssClass="texto" MaxLength="45"></asp:TextBox>
                        </p>
                        <p>
                            <asp:Label ID="label2" runat="server" CssClass="lbl" Text="CPF" 
                                ForeColor="#FC0000"></asp:Label>
                            <asp:TextBox ID="txtCPF" runat="server" CssClass="texto" Width="150px" 
                                MaxLength="14"></asp:TextBox>
                        </p>
                            <asp:MaskedEditExtender ID="MaskedEditExtender7" runat="server" CultureAMPMPlaceholder=""
                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                Enabled="True" ErrorTooltipEnabled="True" InputDirection="LeftToRight" Mask="999,999,999-99"
                                MaskType="None" TargetControlID="txtCPF">
                            </asp:MaskedEditExtender>     
                        <p>
                            <asp:Label ID="label3" runat="server" CssClass="lbl" Text="RG"></asp:Label>
                            <asp:TextBox ID="txtRg" runat="server" CssClass="texto" Width="150px" 
                                MaxLength="20"></asp:TextBox>
                        </p>                    
                    </asp:Panel>                
            
                    <asp:Panel ID="pnlJuridica" runat="server" Height="168px" Visible="False">
                        <p>
                            <asp:Label ID="label1" runat="server" Text="Razão Social" CssClass="lbl" 
                                ForeColor="#FC0000"></asp:Label>
                            <asp:TextBox ID="txtRazaoSocial" runat="server" CssClass="texto" MaxLength="45"></asp:TextBox>
                        </p>
                        <p>
                            <asp:Label ID="label8" runat="server" Text="Fantasia" CssClass="lbl" 
                                ForeColor="#FC0000"></asp:Label>
                            <asp:TextBox ID="txtFantasia" runat="server" CssClass="texto" MaxLength="45"></asp:TextBox>
                        </p>
                        <p>
                            <asp:Label ID="label7" runat="server" CssClass="lbl" Text="CNPJ" 
                                ForeColor="#FC0000"></asp:Label>
                            <asp:TextBox ID="txtCNPJ" runat="server" CssClass="texto" Width="150px" 
                                MaxLength="18"></asp:TextBox>
                        </p>
                            <asp:MaskedEditExtender ID="MaskedEditExtender6" runat="server" CultureAMPMPlaceholder=""
                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                Enabled="True" ErrorTooltipEnabled="True" InputDirection="LeftToRight" Mask="99,999,999/9999-99"
                                MaskType="None" TargetControlID="txtCNPJ">
                            </asp:MaskedEditExtender>     
                        <p>
                            <asp:Label ID="label9" runat="server" CssClass="lbl" Text="Inscrição Estadual"></asp:Label>
                            <asp:TextBox ID="txtInscEstadual" runat="server" CssClass="texto" Width="150px" 
                                MaxLength="20"></asp:TextBox>
                        </p>
                    </asp:Panel>            
            
                    <asp:Panel ID="pnlComum" runat="server" Height="220px" Width="943px" 
                        Visible="False">
                        <asp:Panel ID="pnlComum2" runat="server" Height="210px" Width="494px" 
                            style="float:left;">
                            <p>
                                <asp:Label ID="label4" runat="server" CssClass="lbl" Text="Endereço"></asp:Label>
                                <asp:TextBox ID="txtEndereco" runat="server" CssClass="texto" MaxLength="100"></asp:TextBox>
                            </p>
                            <p>
                                <asp:Label ID="label5" runat="server" CssClass="lbl" Text="UF"></asp:Label>
                                <asp:DropDownList ID="drpUF" runat="server" AutoPostBack="True" ></asp:DropDownList>
                            </p>                    
                            <p>
                                <asp:Label ID="label6" runat="server" CssClass="lbl" Text="Cidade"></asp:Label>
                                <asp:DropDownList ID="drpCidade" runat="server" AutoPostBack="True" ></asp:DropDownList>
                            </p>    
                            <p>
                                <asp:Label ID="label10" runat="server" CssClass="lbl" Text="CEP"></asp:Label>
                                <asp:TextBox ID="txtCEP" runat="server" CssClass="texto" Width="150px" 
                                    MaxLength="9"></asp:TextBox>
                            </p>     
                            <asp:MaskedEditExtender ID="MaskedEditExtender5" runat="server" CultureAMPMPlaceholder=""
                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                Enabled="True" ErrorTooltipEnabled="True" InputDirection="LeftToRight" Mask="99999-999"
                                MaskType="None" TargetControlID="txtCEP">
                            </asp:MaskedEditExtender>                                   
                            <p>
                                <asp:Label ID="label19" runat="server" CssClass="lbl" Text="Data Nascimento" 
                                    ForeColor="#FC0000"></asp:Label>
                                <asp:TextBox ID="txtDataNascimento" runat="server" CssClass="texto" Width="115px" 
                                    MaxLength="9"></asp:TextBox>
                            </p>    
                            <asp:MaskedEditExtender ID="MaskedEditExtender1" runat="server" CultureAMPMPlaceholder=""
                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                Enabled="True" ErrorTooltipEnabled="True" InputDirection="LeftToRight" Mask="99/99/9999"
                                MaskType="Date" TargetControlID="txtDataNascimento">
                            </asp:MaskedEditExtender>                                                                                              
                        </asp:Panel>   

                        <asp:Panel ID="Panel1" runat="server" Height="210px" Width="397px" 
                            style="float:right;">
                            <p>
                                <asp:Label ID="label12" runat="server" CssClass="lbl" Text="Telefone Fixo"></asp:Label>
                                <asp:TextBox ID="txtTelefoneFixo" runat="server" CssClass="texto" Width="150px" 
                                    MaxLength="14"></asp:TextBox>
                            </p>                                
                            <asp:MaskedEditExtender ID="MaskedEditExtender2" runat="server" CultureAMPMPlaceholder=""
                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                Enabled="True" ErrorTooltipEnabled="True" InputDirection="LeftToRight" Mask="(99) 9999-9999"
                                MaskType="None" TargetControlID="txtTelefoneFixo">
                            </asp:MaskedEditExtender>    
                            <p>
                                <asp:Label ID="label13" runat="server" CssClass="lbl" Text="Celular"></asp:Label>
                                <asp:TextBox ID="txtCelular" runat="server" CssClass="texto" Width="150px" 
                                    MaxLength="14"></asp:TextBox>
                            </p>                 
                            <asp:MaskedEditExtender ID="MaskedEditExtender3" runat="server" CultureAMPMPlaceholder=""
                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                Enabled="True" ErrorTooltipEnabled="True" InputDirection="LeftToRight" Mask="(99) 9999-9999"
                                MaskType="None" TargetControlID="txtCelular">
                            </asp:MaskedEditExtender>                                          
                            <p>
                                <asp:Label ID="label14" runat="server" CssClass="lbl" Text="FAX"></asp:Label>
                                <asp:TextBox ID="txtFax" runat="server" CssClass="texto" Width="150px" 
                                    MaxLength="14"></asp:TextBox>
                            </p>  
                            <asp:MaskedEditExtender ID="MaskedEditExtender4" runat="server" CultureAMPMPlaceholder=""
                                CultureCurrencySymbolPlaceholder="" CultureDateFormat="" CultureDatePlaceholder=""
                                CultureDecimalPlaceholder="" CultureThousandsPlaceholder="" CultureTimePlaceholder=""
                                Enabled="True" ErrorTooltipEnabled="True" InputDirection="LeftToRight" Mask="(99) 9999-9999"
                                MaskType="None" TargetControlID="txtFax">
                            </asp:MaskedEditExtender>    
                            <p>
                                <asp:Label ID="label11" runat="server" CssClass="lbl" Text="E-mail"></asp:Label>
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="texto" style="text-transform: lowercase;" Width="150px" 
                                    MaxLength="45"></asp:TextBox>
                            </p>                                               
                        </asp:Panel> 
                    </asp:Panel>           
                </fieldset>
                <fieldset>
                    <legend>Outras Informaçõesões</legend>
                    <asp:Panel ID="pnlOutras" runat="server" Height="168px" Visible="False">
                        <p>
                            <asp:Label ID="label18" runat="server" CssClass="lbl" Text="Vendedor" 
                                ForeColor="#FC0000"></asp:Label>
                            <asp:DropDownList ID="drpVendedor" runat="server" AutoPostBack="True" 
                                Enabled="False"></asp:DropDownList>
                        </p>    
                        <p>
                            <asp:Label ID="label15" runat="server" CssClass="lbl" Text="Acesso WEB"></asp:Label>
                            <asp:CheckBox ID="chkAcesso" runat="server" />
                        </p>                
                        <p>
                            <asp:Label ID="label16" runat="server" CssClass="lbl" Text="Senha WEB"></asp:Label>
                            <asp:TextBox ID="txtSenha" runat="server" CssClass="texto" TextMode="Password" 
                                Width="150px" MaxLength="10"></asp:TextBox>
                        </p>  
                    </asp:Panel> 
                </fieldset> 
                <p style="float: right">
                
                    <asp:Button ID="btnSalvar" runat="server" CssClass="botaoForm save" 
                        Text="Salvar" />
                    <asp:Button ID="btnCancelar" runat="server" CssClass="botaoForm" 
                        Text="Cancelar" />
                            
                </p>
                </ContentTemplate> 
            </asp:UpdatePanel>
        </div>
    </div>
</asp:Content>