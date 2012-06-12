Imports Microsoft.VisualBasic
Imports Camadas.DAO
Imports Camadas.Dominio.Estoque
Imports Camadas.Dominio.Financeiro
Imports Excecoes

Namespace Camadas.Negocio

    Public Class EstoqueController
        Implements IEstoqueController

        Public Function cadastrarProduto(ByVal p As Dominio.Estoque.Produto) As Integer Implements IEstoqueController.cadastrarProduto
            Dim dao As IEstoqueDAO

            Try

                DaoFactory.BeginTransaction()
                '--------------------------

                dao = DaoFactory.GetEstoqueDAO

                If p.Codigo = 0 Then
                    dao.cadastrarProduto(p)
                Else
                    dao.autalizarProduto(p)
                End If

                '--------------------------
                DaoFactory.TransactionCommit()

            Catch ex As DAOException
                DaoFactory.TransactionRollback()
                Throw ex
            Catch ex As Exception
                DaoFactory.TransactionRollback()
                Throw New BusinessException(ex.Message)
            Finally
                dao = Nothing
                DaoFactory.CloseConnection()
            End Try
        End Function

        Public Function listarProduto(ByVal p As Dominio.Estoque.Produto) As System.Data.DataTable Implements IEstoqueController.listarProduto
            Dim dao As IEstoqueDAO

            Try
                dao = DaoFactory.GetEstoqueDAO
                Return dao.listarProduto(p)
            Catch ex As Exception
                Throw ex
            Finally
                dao = Nothing
                DaoFactory.CloseConnection()
            End Try
        End Function

        Public Function listarUnidade() As System.Data.DataTable Implements IEstoqueController.listarUnidade
            Dim dao As IEstoqueDAO

            Try
                dao = DaoFactory.GetEstoqueDAO
                Return dao.listarUnidade()
            Catch ex As Exception
                Throw ex
            Finally
                dao = Nothing
                DaoFactory.CloseConnection()
            End Try
        End Function

        Public Sub entradaProduto(ByVal ep As Dominio.Estoque.EntradaProduto) Implements IEstoqueController.entradaProduto
            Dim dao As IEstoqueDAO
            Dim pedido As Pedido
            Dim caixa As Caixa
            Dim estoque As Estoque

            Try

                DaoFactory.BeginTransaction()
                '--------------------------

                dao = DaoFactory.GetEstoqueDAO

                pedido = New EntradaProduto
                ep.Situacao = "F" 'FINALIZADO
                pedido = ep
                pedido.Codigo = dao.cadastrarPedido(pedido)

                ep.Codigo = pedido.Codigo
                dao.cadastrarEntradaProduto(ep)

                estoque = New Estoque
                estoque.Operacao = "E"
                estoque.Valor = ep.Itens(0).Quantidade
                estoque.Produto.Codigo = ep.Itens(0).Produto.Codigo
                estoque.Pedido.Codigo = pedido.Codigo
                dao.registrarEstoque(Estoque)

                caixa = New Caixa
                caixa.Operacao = "S" 'SAÍDA
                caixa.Pedido.Codigo = pedido.Codigo
                caixa.Valor = pedido.TotalReais
                dao.registrarCaixa(caixa)
                '--------------------------
                DaoFactory.TransactionCommit()

            Catch ex As DAOException
                DaoFactory.TransactionRollback()
                Throw ex
            Catch ex As Exception
                DaoFactory.TransactionRollback()
                Throw New BusinessException(ex.Message)
            Finally
                dao = Nothing
                DaoFactory.CloseConnection()
            End Try
        End Sub
    End Class

End Namespace

