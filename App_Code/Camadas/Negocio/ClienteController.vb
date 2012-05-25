Imports Microsoft.VisualBasic
Imports Camadas.DAO
Imports Camadas.Dominio.Administrativo
Imports Excecoes

Namespace Camadas.Negocio

    Public Class ClienteController
        Implements IClienteController

        Public Sub cadastrarCliente(ByVal cliente As Cliente) Implements IClienteController.cadastrarCliente
            Dim dao As IClienteDAO

            Try

                DaoFactory.BeginTransaction()
                '--------------------------

                dao = DaoFactory.GetClienteDAO
                dao.cadastrarClientePessoaFisica(cliente)

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