Imports Microsoft.VisualBasic

Namespace Camadas.Dominio.Estoque
    Public Class ItemPedido
        Public Property Codigo() As Integer
        Public Property Produto() As Produto
        Public Property Quantidade() As Double

        Public Sub New()
            _Produto = New Produto
        End Sub

        Public Sub New(ByVal _prod As Produto, ByVal _qtd As Double)
            _Produto = _prod
            _Quantidade = _qtd
        End Sub
    End Class
End Namespace