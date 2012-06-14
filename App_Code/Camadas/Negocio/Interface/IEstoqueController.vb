Imports Microsoft.VisualBasic
Imports Camadas.Dominio.Estoque
Imports System.Data

Public Interface IEstoqueController
    Function listarUnidade() As DataTable
    Function listarProduto(ByVal p As Produto) As DataTable
    Function cadastrarProduto(ByVal p As Produto) As Integer

    Sub entradaProduto(ByVal ep As EntradaProduto)
    Function movimentoEstoque(ByVal dataIni As String, ByVal dataFin As String, Optional ByVal idProduto As Integer = 0) As DataTable
End Interface