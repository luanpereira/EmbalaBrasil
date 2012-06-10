Imports Microsoft.VisualBasic

Namespace Camadas.Dominio.Estoque
    Public Class Pedido
        Public Property Codigo() As Integer
        Public Property Itens() As List(Of ItemPedido)
        Public Property Data() As DateTime
        Public Property DataPagamento() As String
        Public Property NotaFiscal() As String
        Public Property Situacao() As String
        Public Property FormaPagamento() As FormaPagamento

        Public Sub New()
            _Itens = New List(Of ItemPedido)
            _FormaPagamento = New FormaPagamento
        End Sub

        Public ReadOnly Property TotalReais() As Double
            Get
                Dim tot As Double = 0

                For i As Integer = 0 To _Itens.Count - 1
                    tot += _Itens.Item(i).Produto.Preco * _Itens.Item(i).Quantidade
                Next

                Return tot
            End Get
        End Property

    End Class
End Namespace
