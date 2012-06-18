<%@ Page Language="VB" MasterPageFile="~/EMBALA.master" AutoEventWireup="false" CodeFile="Pedido.aspx.vb" Inherits="pages_estoque_Pedido" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div id="formulario">
        <div id="FormCliente" class="boxes">            
            <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
            </asp:ToolkitScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                    <h2>Novo Pedido</h2>
                    <fieldset>
                        <legend>Identificação do Cliente</legend>
                        <p>
                            <asp:ImageButton ID="btnCliente" runat="server" ImageUrl="~/recursos/Images/search.png" ToolTip="Clique para pesquisar o cliemte." />
                            <asp:Label ID="label3" runat="server" CssClass="lbl" Text="CNPJ/CPF"></asp:Label>
                            <asp:TextBox ID="txtCNPJCPF" runat="server" CssClass="texto" MaxLength="11" Width="120px"></asp:TextBox>
                        </p>
                        <p>
                            <asp:Label ID="label1" runat="server" CssClass="lbl" Text="Nome: "></asp:Label>
                            <asp:Label ID="lblNome" runat="server" CssClass="" Text="-"></asp:Label>
                        </p>
                        <p>
                            <asp:Label ID="label4" runat="server" CssClass="lbl" Text="RG/INSC.EST.: "></asp:Label>
                            <asp:Label ID="lblRGInscEstadual" runat="server" CssClass="" Text="-"></asp:Label>
                        </p>
                        <p>
                            <asp:Label ID="label6" runat="server" CssClass="lbl" Text="Endereço: "></asp:Label>
                            <asp:Label ID="lblEndereco" runat="server" CssClass="" Text="-"></asp:Label>
                        </p>
                        <p>
                            <asp:Label ID="label8" runat="server" CssClass="lbl" Text="Total Dispensadores: "></asp:Label>
                            <asp:Label ID="lblDispensadores" runat="server" CssClass="" Text="-"></asp:Label>
                        </p>
                    </fieldset> 
                    <fieldset>
                        <legend>Dados do Pedido</legend>
                        <p>
                            <asp:Label ID="label2" runat="server" CssClass="lbl" Text="Vendedor"></asp:Label>
                            <asp:DropDownList ID="drpVendedor" runat="server"></asp:DropDownList>                            
                        </p>
                        <p>
                            <asp:Label ID="label5" runat="server" CssClass="lbl" Text="Produto: "></asp:Label>&nbsp;&nbsp;&nbsp;
                            <asp:ImageButton ID="btnProduto" runat="server" ImageUrl="~/recursos/Images/search.png" ToolTip="Clique para pesquisar o produto." />
                        </p>
                        <p>
                            <asp:Label ID="Label15" runat="server" CssClass="lbl" Text="Quantidade: "></asp:Label>
                            <asp:TextBox ID="txtQuantidade" runat="server" CssClass="texto" MaxLength="11" Width="60px"></asp:TextBox>
                        </p>
                        <p>
                            <asp:GridView ID="gvPedido" runat="server" AutoGenerateColumns="False" 
                                CellPadding="4" ForeColor="#333333" GridLines="None" ShowFooter="True" 
                                Width="936px" DataKeyNames="EB04CODIGO" >
                                <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                                <Columns>
                                    <asp:ButtonField ButtonType="Image" CommandName="Pesquisar" 
                                        DataTextField="EB04CODIGO" ImageUrl="~/recursos/Images/search.png">
                                    <ItemStyle Width="10px" />
                                    </asp:ButtonField>
                                    <asp:BoundField DataField="NOME" HeaderText="Nome" >
                                    <HeaderStyle HorizontalAlign="Left" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="CPF_CNPJ" HeaderText="CPF/CNPJ" >
                                    <HeaderStyle HorizontalAlign="Left" />
                                    <ItemStyle Width="80px" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="VENDEDOR" HeaderText="Vendedor" 
                                        NullDisplayText="- Cliente Master -" >
                                    <HeaderStyle HorizontalAlign="Left" />
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

                    </fieldset> 
                </ContentTemplate> 
            </asp:UpdatePanel> 
        </div> 
    </div> 
</asp:Content> 