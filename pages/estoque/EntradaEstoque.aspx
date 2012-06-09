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
                </fieldset> 
                </ContentTemplate> 
            </asp:UpdatePanel> 
        </div> 
    </div> 
</asp:Content>