Imports Microsoft.VisualBasic

Namespace Camadas.Dominio.Estoque
    Public Class Pedido
        Public Property Codigo() As Integer
        Public Property Itens() As List(Of ItemPedido)
        Public Property Data() As DateTime
        Public Property DataPagamento() As DateTime
        Public Property NotaFiscal() As String
        Public Property Situacao() As String
        Public Property FormaPagamento() As FormaPagamento
    End Class
End Namespace
