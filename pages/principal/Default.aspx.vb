
Partial Class pages_principal_Default
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim u As New Usuario

        u.Nome = "LUAN PERERA"
        u.Usuario = "luan"
        u.Codigo = 11

        Session("usuario") = u
        Session("empresa") = 1
    End Sub
End Class
