
Partial Class EMBALA
    Inherits System.Web.UI.MasterPage

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

            If Not Session("usuario") Is Nothing Then Me.lblUsuario.Text = CType(Session("usuario"), Usuario).Nome
        End If
    End Sub

    Protected Sub lnkSair_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles lnkSair.Click
        Session.RemoveAll()
        Response.Redirect("~/pages/Login.aspx")
    End Sub
End Class

