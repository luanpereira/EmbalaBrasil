
Partial Class pages_principal_Default
    Inherits System.Web.UI.Page

    Private seguranca As Seguranca

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        'seguranca = New Seguranca

        'Try
        '    seguranca.ValidarAcesso(1)
        'Catch ex As Exception
        '    ScriptManager.RegisterClientScriptBlock(Me.Page, Me.GetType, "Mensagem", "Mensagem('" & ex.Message.Replace("'", "") & "');", True)
        'End Try


        'If Not IsPostBack Then

        'End If
    End Sub
End Class
