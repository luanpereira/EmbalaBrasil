Imports Microsoft.VisualBasic

Namespace Camadas.Dominio.Estoque
    Public Class PedidoClienteComum
        Inherits Pedido

        Public Property Cliente() As Cliente
        Public Property Vendedor() As Vendedor
    End Class
End Namespace