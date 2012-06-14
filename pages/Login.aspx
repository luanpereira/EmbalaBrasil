<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Login.aspx.vb" Inherits="pages_Login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>Login -> Embala Brasil - Sistema de Gestão Empresarial</title>
    
    <script type="text/javascript" src="../recursos/Scripts/jquery-1.4.2.js" ></script>
    <script type="text/javascript" src="../recursos/Scripts/jfuncoes.js" ></script>
    
    <link rel="stylesheet" type="text/css" href="~/recursos/Styles/StyleSheet.css" />
    <link rel="stylesheet" type="text/css" href="~/recursos/Styles/tab/google-analytic/tabs.css" />
    <%--<link rel="shortcut icon" type="mage/x-icon" href="recursos/Images/favicon.ico">--%>

</head>
<body>
    <div id="main">
        <div id="corpo">
            <div id="cabecalho">
    	        <a href="#"><div id="logo"></div></a>
    	        <div id="tituloSite">Embala Brasil - Sistema de Gestão Empresarial</div>
    	        <%--<a href="http://www.br" target="_blank"><div id=""></div></a>
    	        <a href="http://www..br" target="_blank"><div id=""></div></a>
    	        <a href="http://www..br" target="_blank"><div id=""></div></a>--%>
            </div>
            <div id="div_menu_login" style="background-color:darkOliveGreen  ">
            </div>

            <form id="form1" runat="server">
                <div id="login">
                    <h3>Login - Área Restrita</h3>
                    <p>
                        <asp:Label ID="label" runat="server" Text="CPF ou CNPJ" CssClass="lbl"></asp:Label>
                        <asp:TextBox ID="txtUsuario" runat="server" Width="180px" style="text-transform:none" CssClass="texto"></asp:TextBox>
                    </p>                    
                    <p>
                        <asp:Label ID="label1" runat="server" Text="Senha" CssClass="lbl"></asp:Label>
                        <asp:TextBox ID="txtSenha" runat="server" TextMode="Password" style="text-transform:none" Width="100px" CssClass="texto"></asp:TextBox>
                    </p>
                    <p>
                        <asp:Button ID="btnEntrar" runat="server" CssClass="botaoForm " Text="Entrar" />
                    </p>
                </div>
            </form>
        </div>
        <div class="footer">© Embala Brasil <% Response.Write(Date.Now.Year)%>. Todos os direitos Reservados.</div>
        <div class="footer">Desenvolvido por, <a href="http://www.luanpereira.com" target="_blank">LuanPereira.com</a></div>
    </div>
</body>
</html>
