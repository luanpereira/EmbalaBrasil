Imports Microsoft.VisualBasic
Imports Camadas.Dominio.Estoque

Namespace Camadas.Dominio.Financeiro
    Public Class Pagamento
        Public Property Codigo() As Integer
        Public Property Pedido() As Pedido
        Public Property NumeroParcela() As Integer
        Public Property DataVencimento() As DateTime
        Public Property Valor() As Double
        Public Property DataPagamento() As DateTime
        Public Property Situacao() As String
        Public Property Boleto() As String
    End Class
End Namespace