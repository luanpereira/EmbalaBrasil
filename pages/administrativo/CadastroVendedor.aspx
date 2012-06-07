<%@ Page Language="VB" MasterPageFile="~/EMBALA.master" AutoEventWireup="false" CodeFile="CadastroVendedor.aspx.vb" Inherits="pages_administrativo_CadastroCliente" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div id="formulario">
        <div id="FormCliente" class="boxes">            
            <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
            </asp:ToolkitScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                <h2>Cadastrar novo Vendedor</h2>
                &nbsp;<fieldset>
                    <legend>Dados Pessoais</legend>
                    <asp:Panel ID="pnlFisica" runat="server" Height="124px">
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
            
                    <asp:Panel ID="pnlComum" runat="server" Height="220px" Width="943px">
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
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="texto" Width="150px" 
                                    MaxLength="45"></asp:TextBox>
                            </p>                                               
                        </asp:Panel> 
                    </asp:Panel>           
                </fieldset>
                <fieldset>
                    <legend>Outras Informações</legend>
                    <asp:Panel ID="pnlOutras" runat="server" Height="168px">
                        <p>
                            <asp:Label ID="label15" runat="server" CssClass="lbl" Text="Acesso WEB"></asp:Label>
                            <asp:CheckBox ID="chkAcesso" runat="server" />
                        </p>                
                        <p>
                            <asp:Label ID="label16" runat="server" CssClass="lbl" Text="Senha WEB"></asp:Label>
                            <asp:TextBox ID="txtSenha" runat="server" CssClass="texto" TextMode="Password" 
                                Width="150px" MaxLength="10"></asp:TextBox>
                        </p>  
                        <%--<fieldset>
                            <legend>Rota - Cidades de Atendimento</legend>
                            <p>
                                <asp:Label ID="label1" runat="server" CssClass="lbl" Text="UF"></asp:Label>
                                <asp:DropDownList ID="drpUfRota" runat="server" AutoPostBack="True" ></asp:DropDownList>
                            </p>                    
                            <p>
                                <asp:Label ID="label7" runat="server" CssClass="lbl" Text="Cidade"></asp:Label>
                                <asp:DropDownList ID="drpCidadeRota" runat="server" AutoPostBack="True" ></asp:DropDownList>
                                <asp:Button ID="btnAddRota" runat="server" CssClass="botaoForm add" Text="Adicionar" />
                            </p>   
                            <p>
                                <asp:GridView ID="gvRota" runat="server" AutoGenerateColumns="False" 
                                    CellPadding="4" ForeColor="#333333" GridLines="None" ShowFooter="True" 
                                    Width="563px" DataKeyNames="EB10CODIGO" >
                                    <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                    <Columns>
                                        <asp:ButtonField ButtonType="Image" CommandName="Excluir" 
                                            DataTextField="EB10CODIGO" ImageUrl="~/recursos/Images/cancel.png">
                                        <ItemStyle Width="10px" />
                                        </asp:ButtonField>
                                        <asp:BoundField DataField="EB99SIGLA" HeaderText="Estado" >
                                        <HeaderStyle HorizontalAlign="Left" />
                                            <ItemStyle Width="50px" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="EB98NOME" HeaderText="Cidade" >
                                        <HeaderStyle HorizontalAlign="Left" />
                                        </asp:BoundField>
                                    </Columns>
                                    <EditRowStyle BackColor="#999999" />
                                    <FooterStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <HeaderStyle BackColor="#5D7B9D" Font-Bold="True" ForeColor="White" />
                                    <PagerStyle BackColor="#284775" ForeColor="White" HorizontalAlign="Center" />
                                    <RowStyle BackColor="#F7F6F3" ForeColor="#333333" />
                                    <SelectedRowStyle BackColor="#E2DED6" Font-Bold="True" ForeColor="#333333" />
                                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                    <SortedAscendingCellStyle BackColor="#E9E7E2" />
                                    <SortedAscendingHeaderStyle BackColor="#506C8C" />
                                    <SortedDescendingCellStyle BackColor="#FFFDF8" />
                                    <SortedDescendingHeaderStyle BackColor="#6F8DAE" />
                                </asp:GridView>
                            </p>
                        </fieldset> --%>
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