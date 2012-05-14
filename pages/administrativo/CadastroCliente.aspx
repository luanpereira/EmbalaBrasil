<%@ Page Language="VB" MasterPageFile="~/EMBALA.master" AutoEventWireup="false" CodeFile="CadastroCliente.aspx.vb" Inherits="pages_administrativo_CadastroCliente" %>

<asp:Content ID="Content" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div id="formulario">
        <div id="Filtro" class="boxes">
            <h2>Cadastrar novo Cliente</h2>
                <fieldset>
                    <legend>Pessoa</legend>
                    <asp:RadioButtonList ID="rblPessoa" runat="server" AutoPostBack="True" 
                        RepeatDirection="Horizontal" Width="203px">
                        <asp:ListItem>Jurídica</asp:ListItem>
                        <asp:ListItem>Física</asp:ListItem>
                    </asp:RadioButtonList>
                </fieldset>
            </p>

            <p>
                <asp:Panel ID="pnlFisica" runat="server" Height="221px" Visible="False">
                    <asp:Panel ID="Panel1" runat="server" Height="96px" Width="470px" 
                        style="float:left;">
                        <p>
                            <asp:Label ID="label" runat="server" Text="Nome" CssClass="lbl"></asp:Label>
                            <asp:TextBox ID="txtNome" runat="server" CssClass="texto"></asp:TextBox>
                        </p>
                    </asp:Panel> 
                    <asp:Panel ID="Panel2" runat="server" Height="96px" Width="470px" 
                        style="float:right;">
                        <p>
                            <asp:Label ID="label2" runat="server" CssClass="lbl" Text="CPF/CNPJ"></asp:Label>
                            <asp:TextBox ID="txtCPF" runat="server" CssClass="texto" Width="150px"></asp:TextBox>
                        </p>
                        <p>
                            <asp:Label ID="label3" runat="server" CssClass="lbl" Text="RG"></asp:Label>
                            <asp:TextBox ID="TextBox2" runat="server" CssClass="texto" Width="150px"></asp:TextBox>
                        </p>                    
                    </asp:Panel> 
                </asp:Panel>                
            </p>

            <p>
                <asp:Panel ID="pnlJuridica" runat="server" Height="108px" Visible="False">
                    <asp:Label ID="label1" runat="server" Text="Razão Social" CssClass="lbl"></asp:Label>
                    <asp:TextBox ID="TextBox1" runat="server" CssClass="texto"></asp:TextBox>
                </asp:Panel>            
            </p>
        </div>
    </div>
</asp:Content>