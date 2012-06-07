Imports Microsoft.VisualBasic
Imports Camadas.DAO

Namespace Camadas.Negocio

    Public Class EstoqueController
        Implements IEstoqueController

        Public Function cadastrarProduto(ByVal p As Dominio.Estoque.Produto) As Integer Implements IEstoqueController.cadastrarProduto

        End Function

        Public Function listarProduto(ByVal p As Dominio.Estoque.Produto) As System.Data.DataTable Implements IEstoqueController.listarProduto

        End Function

        Public Function listarUnidade() As System.Data.DataTable Implements IEstoqueController.listarUnidade
            Dim dao As IEstoqueDAO

            Try
                dao = DaoFactory.GetEstoqueDAO
                Return dao.listarUnidade()
            Catch ex As Exception
                Throw ex
            End Try
        End Function
    End Class

End Namespace

