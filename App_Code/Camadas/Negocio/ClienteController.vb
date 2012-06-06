Imports Microsoft.VisualBasic
Imports Camadas.DAO
Imports Camadas.Dominio.Administrativo
Imports Excecoes
Imports Infraestrutura.Utils
Imports System.Data

Namespace Camadas.Negocio

    Public Class ClienteController
        Implements IClienteController

        Public Sub cadastrarCliente(ByVal cliente As Cliente) Implements IClienteController.cadastrarCliente
            Dim dao As IClienteDAO
            Dim idCliente As Integer = 0
            Dim u As Usuario

            Try

                DaoFactory.BeginTransaction()
                '--------------------------

                dao = DaoFactory.GetClienteDAO

                Select Case cliente.TipoPessoa
                    Case eTipoPessoa.Física
                        If cliente.Codigo = 0 Then '-- SE FOR IGUAL A ZERO, É PORQUE É UM NOVO CLIENTE
                            idCliente = dao.cadastrarClientePessoaFisica(cliente)
                        Else '-- CASO CONTRÁRIO ATUALIZA
                            dao.atualizarClientePessoaFisica(cliente)
                        End If

                        u = New Usuario
                        u.Nome = cliente.PessoaFisica.Nome
                        u.Usuario = cliente.PessoaFisica.Cpf

                    Case eTipoPessoa.Jurídica
                        If cliente.Codigo = 0 Then '-- SE FOR IGUAL A ZERO, É PORQUE É UM NOVO CLIENTE
                            idCliente = dao.cadastrarClientePessoaJuridica(cliente)
                        Else '-- CASO CONTRÁRIO ATUALIZA
                            dao.atualizarClientePessoaJuridica(cliente)
                        End If

                        u = New Usuario
                        u.Nome = cliente.PessoaJuridica.Fantasia
                        u.Usuario = cliente.PessoaJuridica.CNPJ

                    Case Else
                        Throw New Exception("O TIPO DE PESSOA NÃO FOI DEFINIDO.")
                End Select

                u.Cliente.Codigo = idCliente
                u.AcessoWeb = cliente.isAcessoWeb
                u.Senha = IIf(cliente.Senha.Trim = String.Empty, "", Seguranca.CriptografarMD5(cliente.Senha))

                If cliente.Codigo = 0 Then '-- SE FOR IGUAL A ZERO, É PORQUE É UM NOVO USUARIO
                    Seguranca.criarUsuario(u)
                Else '-- CASO CONTRÁRIO ATUALIZA
                    u.Codigo = cliente.CodigoUsuario
                    Seguranca.atualizarDados(u)
                    If Not u.Senha = String.Empty Then Seguranca.alterarSenha(u) '-- SE INFORMOU A SENHA, ENTAO DEVERÁ MUDÁ-LA
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
        End Sub


        Public Function listarCliente() As DataTable Implements IClienteController.listarCliente
            Dim dao As IClienteDAO

            Try

                dao = DaoFactory.GetClienteDAO
                Return dao.listarCliente()

            Catch ex As Exception
                Throw ex
            Finally
                dao = Nothing
                DaoFactory.CloseConnection()
            End Try
        End Function

        Public Function listarCliente(ByVal c As Cliente) As DataTable Implements IClienteController.listarCliente
            Dim dao As IClienteDAO

            Try

                dao = DaoFactory.GetClienteDAO
                Return dao.listarCliente(c)

            Catch ex As Exception
                Throw ex
            Finally
                dao = Nothing
                DaoFactory.CloseConnection()
            End Try
        End Function
    End Class

End Namespace