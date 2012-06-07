<%@ Page Language="VB" MasterPageFile="~/EMBALA.master" AutoEventWireup="false" CodeFile="ConsultarVendedor.aspx.vb" Inherits="pages_administrativo_ConsultarCliente" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>
<asp:Content ID="Content" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div id="formulario">
        <div id="Filtro" class="boxes">
            <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
            </asp:ToolkitScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <asp:UpdateProgress ID="UpdateProgress1" runat="server">
                        <ProgressTemplate>
                            
                            <asp:Panel ID="Panel1" runat="server" CssClass="loading">
                            </asp:Panel>
                            
                        </ProgressTemplate>
                    </asp:UpdateProgress>
                    <h2>Consulta de Vendedores</h2>
                    <p>
                        <asp:Label ID="label" runat="server" Text="Nome" CssClass="lbl"></asp:Label>
                        <asp:TextBox ID="txtNome" runat="server" CssClass="texto"></asp:TextBox>
                    </p>
                    <p>
                        <asp:Label ID="label1" runat="server" Text="CPF" CssClass="lbl"></asp:Label>
                        <asp:TextBox ID="txtCPF" runat="server" CssClass="texto" Width="150px"></asp:TextBox>
                        <asp:Label ID="Label2" runat="server" Font-Italic="True" Font-Size="8pt" ForeColor="#C00000" Text="(somente números)"></asp:Label>
                    </p>
                    <p>
                
                        <asp:Button ID="btnPesquisar" runat="server" CssClass="botaoForm search" 
                            Text="Pesquisar" />
        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Button ID="btnAddCliente" runat="server" CssClass="botaoForm article" 
                            Text="Adicionar novo Vendedor" />
                
                    </p>
            
                    <p>

                        <asp:GridView ID="gvVendedor" runat="server" AutoGenerateColumns="False" 
                            CellPadding="4" ForeColor="#333333" GridLines="None" ShowFooter="True" 
                            Width="936px" DataKeyNames="EB06CODIGO" >
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:ButtonField ButtonType="Image" CommandName="Pesquisar" 
                                    DataTextField="EB06CODIGO" ImageUrl="~/recursos/Images/search.png">
                                <ItemStyle Width="10px" />
                                </asp:ButtonField>
                                <asp:BoundField DataField="EB06NOME" HeaderText="Nome" >
                                <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="EB06CPF" HeaderText="CPF" >
                                <HeaderStyle HorizontalAlign="Left" />
                                <ItemStyle Width="80px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="TELEFONE" HeaderText="Telefones" NullDisplayText="-">
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
                        </asp:GridView>

                    </p>
                </ContentTemplate> 
            </asp:UpdatePanel> 
        </div>
    </div>
</asp:Content>