<%@ Page Language="VB" MasterPageFile ="~/EMBALA.master" AutoEventWireup="false" CodeFile="EntradaEstoque.aspx.vb" Inherits="pages_estoque_EntradaEstoque" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div id="formulario">
        <div id="FormCliente" class="boxes">            
            <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
            </asp:ToolkitScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                <h2>Registro de Entrada de Mercadorias</h2>
                <fieldset>
                    <legend>Informações</legend>
                    <p>
                        <asp:Label ID="label6" runat="server" CssClass="lbl" Text="Produto" 
                            ForeColor="#FC0000"></asp:Label>
                        <asp:DropDownList ID="drpProduto" runat="server" AutoPostBack="True" ></asp:DropDownList>
                    </p>  
                    <p>
                        <asp:Label ID="label4" runat="server" CssClass="lbl" Text="Quantidade" 
                            ForeColor="#FC0000"></asp:Label>
                        <asp:TextBox ID="txtQuantidade" runat="server" CssClass="texto" MaxLength="100" 
                            Width="60px"></asp:TextBox>
                    </p>
                    <p>
                        <asp:Label ID="label1" runat="server" CssClass="lbl" Text="Nota Fiscal"></asp:Label>
                        <asp:TextBox ID="txtNotaFiscal" runat="server" CssClass="texto" MaxLength="45" 
                            Width="200px"></asp:TextBox>
                    </p>
                    <p>
                        <asp:Label ID="label2" runat="server" CssClass="lbl" Text="Data Pagamento"></asp:Label>
                        <asp:TextBox ID="txtDataPg" runat="server" CssClass="texto" MaxLength="10" 
                            Width="120px"></asp:TextBox>
                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="calendario"
                            Format="dd/MM/yyyy" TargetControlID="txtDataPg" PopupPosition="BottomRight">
                        </asp:CalendarExtender>                        
                    </p>
                    <p>
                        <asp:Label ID="label3" runat="server" CssClass="lbl" Text="Observação"></asp:Label>
                        <asp:TextBox ID="txtObs" runat="server" CssClass="texto" TextMode="MultiLine" 
                            Height="99px" Width="488px" ></asp:TextBox>
                    </p>
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