Imports Microsoft.VisualBasic
Imports Camadas.Dominio.Administrativo

Namespace Camadas.Dominio.Estoque
    Public Class PedidoClienteMaster
        Inherits Pedido

        Public Property Cliente() As Cliente
    End Class
End Namespace