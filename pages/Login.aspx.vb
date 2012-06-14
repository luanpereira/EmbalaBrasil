
Partial Class pages_Login
    Inherits System.Web.UI.Page

 
    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not Session("usuario") Is Nothing Then Response.Redirect("~/pages/principal")

        If Not IsPostBack Then
            'Me.txtUsuario.Attributes.Add("onkeypress", "return ValidarEntrada(event, '1')")
        End If
    End Sub

    Protected Sub btnEntrar_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles btnEntrar.Click
        Dim u As Usuario

        If Me.txtUsuario.Text.ToLower = "embalabrasil" And Me.txtSenha.Text = "7534" Then
            u = New Usuario

            u.Nome = "Priscila - Embala Brasil"
            u.Usuario = "embalabrasil"
            u.Codigo = 9

            Session("usuario") = u
            Session("empresa") = 2

            Response.Redirect("~/pages/principal")
        Else
            ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Mensagem", "Mensagem('USUÁRIO OU SENHA INCORRETOS!');", True)
        End If
    End Sub
End Class
