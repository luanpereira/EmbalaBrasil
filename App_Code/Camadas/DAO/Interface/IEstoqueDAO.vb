Imports Microsoft.VisualBasic
Imports Camadas.Dominio.Estoque
Imports System.Data
Imports Camadas.Dominio.Financeiro

Public Interface IEstoqueDAO
    Function listarUnidade() As DataTable
    Function listarProduto(ByVal p As Produto) As DataTable
    Function cadastrarProduto(ByVal p As Produto) As Integer
    Sub autalizarProduto(ByVal p As Produto)

    Function cadastrarPedido(ByVal pedido As Pedido) As Long
    Sub cadastrarEntradaProduto(ByVal ep As EntradaProduto)

    Sub registrarCaixa(ByVal caixa As Caixa)
End Interface
