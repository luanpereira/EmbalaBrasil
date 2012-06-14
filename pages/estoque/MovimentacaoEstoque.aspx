<%@ Page Language="VB" MasterPageFile="~/EMBALA.master" AutoEventWireup="false" CodeFile="MovimentacaoEstoque.aspx.vb" Inherits="pages_estoque_MovimentacaoEstoque" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<asp:Content ID="Content" runat="server" ContentPlaceHolderID="ContentPlaceHolder1">
    <div id="formulario">
        <div id="FormCliente" class="boxes">            
            <asp:ToolkitScriptManager ID="ToolkitScriptManager1" runat="server">
            </asp:ToolkitScriptManager>
            <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                <ContentTemplate>
                <h2>Movimentação de Estoque</h2>
                <fieldset>
                    <legend>Informações</legend>
                    <p>
                        <asp:Label ID="label2" runat="server" CssClass="lbl" Text="Data Inicial" 
                            ForeColor="#FC0000"></asp:Label>
                        <asp:TextBox ID="txtDataInicial" runat="server" CssClass="texto" MaxLength="10" 
                            Width="120px"></asp:TextBox>
                        <asp:CalendarExtender ID="CalendarExtender1" runat="server" CssClass="calendario"
                            Format="dd/MM/yyyy" TargetControlID="txtDataInicial" PopupPosition="BottomRight">
                        </asp:CalendarExtender>                        
                    </p>
                    <p>
                        <asp:Label ID="label1" runat="server" CssClass="lbl" Text="Data Final" 
                            ForeColor="#FC0000"></asp:Label>
                        <asp:TextBox ID="txtDataFinal" runat="server" CssClass="texto" MaxLength="10" 
                            Width="120px"></asp:TextBox>
                        <asp:CalendarExtender ID="CalendarExtender2" runat="server" CssClass="calendario"
                            Format="dd/MM/yyyy" TargetControlID="txtDataFinal" PopupPosition="BottomRight">
                        </asp:CalendarExtender>                        
                    </p>
                    <p>
                        <asp:Label ID="label6" runat="server" CssClass="lbl" Text="Produto"></asp:Label>
                        <asp:DropDownList ID="drpProduto" runat="server" AutoPostBack="True" ></asp:DropDownList>
                        <asp:Button ID="btnPesquisar" runat="server" CssClass="botaoForm search" 
                            Text="Listar Movimentação" />    
                    </p> 

                
                                    
              
                </fieldset> 
                <fieldset>
                    <legend>Resultado da Pesquisa</legend>
                        <asp:GridView ID="gvMovimento" runat="server" AutoGenerateColumns="False" 
                            CellPadding="4" ForeColor="#333333" GridLines="None" ShowFooter="True" 
                            Width="936px" PageSize="30" >
                            <AlternatingRowStyle BackColor="White" ForeColor="#284775" />
                            <Columns>
                                <asp:BoundField DataField="EB12DATA" HeaderText="Data" >
                                <HeaderStyle HorizontalAlign="Left" Width="20px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CLIENTE" HeaderText="Cliente" >
                                <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="PRODUTO" HeaderText="Produto" >
                                <HeaderStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField DataField="OPERACAO" HeaderText="Operação" NullDisplayText="-">
                                <HeaderStyle HorizontalAlign="Left" Width="20px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="EB12VALOR" HeaderText="Valor">
                                <HeaderStyle Width="20px" />
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
                    <p>
                        <asp:Label ID="label3" runat="server" CssClass="lbl" Text="Saldo: "></asp:Label>
                        <asp:Label ID="lblSaldo" runat="server" CssClass="lbl" Text="-"></asp:Label>                      
                    </p>
                </fieldset> 
                </ContentTemplate> 
            </asp:UpdatePanel> 
        </div> 
    </div> 
</asp:Content>
