Imports Microsoft.VisualBasic
Imports Camadas.Dominio

Namespace Camadas.Dominio.Administrativo
    Public MustInherit Class Pessoa

        Public Property Codigo() As Integer
        Public Property Endereco() As Endereco
        Public Property Contato() As Contato
        Public Property Senha() As String
        Public Property DataNascimento() As String
        Public Property isAcessoWeb() As Boolean

    End Class
End Namespace