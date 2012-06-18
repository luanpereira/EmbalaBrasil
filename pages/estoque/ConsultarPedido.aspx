<%@ Page Language="VB" MasterPageFile="~/EMBALA.master" AutoEventWireup="false" CodeFile="ConsultarPedido.aspx.vb" Inherits="pages_estoque_ConsultarPedido" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div id="formulario">
        <div id="FormCliente" class="boxes">            
            <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
            </asp:ToolkitScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                <h2>Consultar Pedidos</h2>
                <fieldset>
                    <legend>Filtre a Pesquisa</legend>
                    <p>
                        <asp:Label ID="label2" runat="server" CssClass="lbl" Text="Data Inicial"></asp:Label>
                        <asp:TextBox ID="txtDataIni" runat="server" CssClass="texto" MaxLength="10" 
                            Width="120px"></asp:TextBox>
                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="calendario"
                            Format="dd/MM/yyyy" TargetControlID="txtDataIni" PopupPosition="BottomRight">
                        </asp:CalendarExtender>                        
                    </p>
                    <p>
                        <asp:Label ID="label1" runat="server" CssClass="lbl" Text="Data Final"></asp:Label>
                        <asp:TextBox ID="txtDataFinal" runat="server" CssClass="texto" MaxLength="10" 
                            Width="120px"></asp:TextBox>
                        <asp:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="calendario"
                            Format="dd/MM/yyyy" TargetControlID="txtDataFinal" PopupPosition="BottomRight">
                        </asp:CalendarExtender>                        
                    </p>
                    <p>
                        <asp:Label ID="label3" runat="server" CssClass="lbl" Text="Número do Pedido"></asp:Label>
                        <asp:TextBox ID="txtNumPedido" runat="server" CssClass="texto" MaxLength="10" Width="120px"></asp:TextBox>

                    </p>
                    <p style="float: left">
                        <asp:Button ID="btnPesquisar" runat="server" CssClass="botaoForm search" 
                            Text="Pesquisar Pedidos" />&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnNovoPedido" runat="server" CssClass="botaoForm article" 
                            Text="Novo Pedido" />
                    </p>
                </fieldset> 

                    <p>

                        <asp:GridView ID="gvCliente" runat="server" AutoGenerateColumns="False" 
                            CellPadding="4" ForeColor="#333333" GridLines="None" ShowFooter="True" 
                            Width="936px" DataKeyNames="EB04CODIGO" Caption="Resultado da Pesquisa" >
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:ButtonField ButtonType="Image" CommandName="Pesquisar" 
                                    DataTextField="EB04CODIGO" ImageUrl="~/recursos/Images/search.png">
                                <ItemStyle Width="10px" />
                                </asp:ButtonField>
                                <asp:BoundField DataField="CPF_CNPJ" HeaderText="Status" >
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle Width="80px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="EB07PEDIDO" HeaderText="Pedido" >
                                <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CPFCNPJ" HeaderText="CNPJ/CPF Cliente" >
                                <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="NOME" HeaderText="Nome Cliente" NullDisplayText="-">
                                <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="VALOR" HeaderText="Valor" />
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
                        </asp:GridView>

                    </p>
                </ContentTemplate> 
            </asp:UpdatePanel> 
        </div> 
    </div> 
</asp:Content> 
