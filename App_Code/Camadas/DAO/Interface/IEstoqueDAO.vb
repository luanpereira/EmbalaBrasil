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

    Sub registrarEstoque(ByVal estoque As Estoque)
    Function movimentoEstoque(ByVal dataIni As String, ByVal dataFin As String, Optional ByVal idProduto As Integer = 0) As DataTable
    Sub registrarCaixa(ByVal caixa As Caixa)
End Interface
