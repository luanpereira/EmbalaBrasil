Imports Microsoft.VisualBasic

Namespace Camadas.Dominio.Estoque
    Public Class Estoque
        Public Property Codigo() As Integer
        Public Property Data() As DateTime
        Public Property Operacao() As String
        Public Property Valor() As Double
        Public Property Produto() As Produto
        Public Property Pedido() As Pedido

        Public Sub New()
            _Produto = New Produto
            _Pedido = New Pedido
        End Sub
    End Class
End Namespace