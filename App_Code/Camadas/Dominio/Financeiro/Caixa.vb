Imports Microsoft.VisualBasic
Imports Camadas.Dominio.Estoque

Namespace Camadas.DominioFinanceiro
    Public Class Caixa
        Public Property Codigo() As Integer
        Public Property Data() As DateTime
        Public Property Operacao() As String
        Public Property Valor() As Double
        Public Property Pedido() As Pedido
    End Class
End Namespace