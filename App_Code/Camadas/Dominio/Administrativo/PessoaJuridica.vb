Imports Microsoft.VisualBasic

Namespace Camadas.Dominio.Administrativo
    Public Class PessoaJuridica
        Public Property CNPJ() As String
        Public Property RazaoSocial() As String
        Public Property Fantasia() As String
        Public Property InscricaoEstadual() As String
        Public Property Responsavel() As PessoaFisica
    End Class
End Namespace