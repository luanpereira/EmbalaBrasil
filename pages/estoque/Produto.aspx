<%@ Page Language="VB" MasterPageFile="~/EMBALA.master" AutoEventWireup="false" CodeFile="Produto.aspx.vb" Inherits="pages_estoque_Produto" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div id="formulario">
        <div id="FormCliente" class="boxes">            
            <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
            </asp:ToolkitScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                <h2>Cadastro e Consulta de Produtos</h2>
                <fieldset>
                    <legend>Dados Gerais</legend>
                    <p>
                        <asp:Label ID="label" runat="server" Text="Nome" CssClass="lbl" 
                            ForeColor="#FC0000"></asp:Label>
                        <asp:TextBox ID="txtNome" runat="server" CssClass="texto" MaxLength="45"></asp:TextBox>
                    </p>
                    <p>
                        <asp:Label ID="label1" runat="server" Text="Sigla" CssClass="lbl" 
                            ForeColor="#FC0000"></asp:Label>
                        <asp:TextBox ID="txtSigla" runat="server" Width="50px" CssClass="texto" MaxLength="10"></asp:TextBox>
                    </p>
                    <p>
                        <asp:Label ID="label4" runat="server" Text="Preço Venda (R$)" CssClass="lbl" 
                            ForeColor="#FC0000"></asp:Label>
                        <asp:TextBox ID="txtPreco" runat="server" Width="90px" CssClass="texto" MaxLength="10"></asp:TextBox>
                    </p>
                    <p>
                        <asp:Label ID="label6" runat="server" CssClass="lbl" Text="Unidade" 
                            ForeColor="#FC0000"></asp:Label>
                        <asp:DropDownList ID="drpUnidade" runat="server" AutoPostBack="True" ></asp:DropDownList>
                    </p>    
                    <p>
                        <asp:Label ID="label2" runat="server" Text="Especificação" CssClass="lbl" 
                            ForeColor="#FC0000"></asp:Label>
                        <asp:TextBox ID="txtEspecificacao" runat="server" CssClass="texto" TextMode="MultiLine" 
                            Height="92px" Width="343px"></asp:TextBox>
                    </p>
                    <p>
                        <asp:Label ID="label3" runat="server" Text="Estoque Mínimo" CssClass="lbl" 
                            ForeColor="#FC0000"></asp:Label>
                        <asp:TextBox ID="txtEstoqueMinimo" runat="server" Width="50px" CssClass="texto" MaxLength="10">30</asp:TextBox>
                    </p>
                </fieldset> 
                
                <p style="float: right">
                
                    <asp:Button ID="btnSalvar" runat="server" CssClass="botaoForm save" 
                        Text="Salvar" />
                    <asp:Button ID="btnCancelar" runat="server" CssClass="botaoForm" 
                        Text="Cancelar" />
                            
                </p>

                    <asp:GridView ID="gvProduto" runat="server" AutoGenerateColumns="False" 
                        CellPadding="4" ForeColor="#333333" GridLines="None" ShowFooter="True" 
                        Width="936px" DataKeyNames="EB08CODIGO" Caption="PRODUTOS CADASTRADOS" >
                        <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                        <Columns>
                            <asp:ButtonField ButtonType="Image" CommandName="Pesquisar" 
                                DataTextField="EB08CODIGO" ImageUrl="~/recursos/Images/search.png">
                            <ItemStyle Width="10px" />
                            </asp:ButtonField>
                            <asp:BoundField DataField="EB08SIGLA" HeaderText="Sigla" >
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle Width="50px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="EB08NOME" HeaderText="Nome" >
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle Width="200px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="UNIDADE" HeaderText="UN" >
                            <HeaderStyle HorizontalAlign="Left" />
                            <ItemStyle Width="50px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="EB08ESPECIFICACAO" HeaderText="Especificação" 
                                NullDisplayText="-">
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
                </ContentTemplate> 
            </asp:UpdatePanel> 
        </div> 
    </div> 
</asp:Content>