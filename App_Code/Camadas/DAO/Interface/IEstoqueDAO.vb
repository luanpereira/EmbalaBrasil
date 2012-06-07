Imports Microsoft.VisualBasic
Imports Camadas.Dominio.Estoque
Imports System.Data

Public Interface IEstoqueDAO
    Function listarUnidade() As DataTable
    Function listarProduto(ByVal p As Produto) As DataTable
    Function cadastrarProduto(ByVal p As Produto) As Integer
    Sub autalizarProduto(ByVal p As Produto)
End Interface
