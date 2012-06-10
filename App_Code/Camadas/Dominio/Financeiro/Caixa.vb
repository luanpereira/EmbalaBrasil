Imports Microsoft.VisualBasic
Imports Camadas.Dominio.Estoque

Namespace Camadas.Dominio.Financeiro
    Public Class Caixa
        Public Property Codigo() As Integer
        Public Property Data() As DateTime
        Public Property Operacao() As String
        Public Property Valor() As Double
        Public Property Pedido() As Pedido

        Public Sub New()
            _Pedido = New Pedido
        End Sub
    End Class
End Namespace