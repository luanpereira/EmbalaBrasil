Imports Microsoft.VisualBasic

Namespace Camadas.Dominio.Estoque
    Public Class Produto
        Public Property Codigo() As Integer
        Public Property Nome() As String
        Public Property Sigla() As String
        Public Property Especificacao() As String
        Public Property EstoqueMinimo() As Double
        Public Property Unidade() As Unidade
        Public Property Preco() As Double

        Public Sub New()
            _Unidade = New Unidade
        End Sub

        Public Sub New(ByVal nome As String, ByVal sigla As String, ByVal especificacao As String, ByVal estoqMinimo As Double, ByVal unidade As Unidade, ByVal preco As Double)
            _Nome = nome
            _Sigla = sigla
            _Especificacao = especificacao
            _EstoqueMinimo = estoqMinimo
            _Unidade = unidade
            _Preco = preco
        End Sub
    End Class
End Namespace
