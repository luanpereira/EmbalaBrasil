Imports Camadas.Dominio
Imports Microsoft.VisualBasic
Imports Infraestrutura.Utils

Namespace Camadas.Dominio.Administrativo

    Public Class Cliente
        Inherits Pessoa

        Public Property QuantidadeDispensadores() As Integer
        Public Property Vendedor() As New Vendedor
        Public Property TipoPessoa() As eTipoPessoa
        Public Property PessoaJuridica() As PessoaJuridica
        Public Property PessoaFisica() As PessoaFisica
        Public Property TipoCliente() As eTipoCliente

    End Class

End Namespace