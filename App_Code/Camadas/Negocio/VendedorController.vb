Imports Microsoft.VisualBasic
Imports Camadas.DAO
Imports Camadas.Dominio.Administrativo
Imports System.Data
Imports Excecoes
Imports Infraestrutura.Utils

Namespace Camadas.Negocio

    Public Class VendedorController
        Implements IVendedorController


        Public Sub cadastrarVendedor(ByVal vendedor As Dominio.Administrativo.Vendedor) Implements IVendedorController.cadastrarVendedor
            Dim dao As IVendedorDAO
            Dim idVendedor As Integer = 0
            Dim u As Usuario

            Try

                DaoFactory.BeginTransaction()
                '--------------------------

                dao = DaoFactory.GetVendedorDAO

                If vendedor.Codigo = 0 Then '-- SE FOR IGUAL A ZERO, É PORQUE É UM NOVO VENDEDOR
                    idVendedor = dao.cadastrarVendedor(vendedor)
                Else '-- CASO CONTRÁRIO ATUALIZA
                    dao.atualizarVendedor(vendedor)
                End If

                u = New Usuario
                u.Tipo = eTipo.Vendedor
                u.Nome = vendedor.PessoaFisica.Nome
                u.Usuario = vendedor.PessoaFisica.Cpf
                u.Vendedor.Codigo = idVendedor
                u.AcessoWeb = vendedor.isAcessoWeb
                u.Senha = IIf(vendedor.Senha.Trim = String.Empty, "", Seguranca.CriptografarMD5(vendedor.Senha))

                If vendedor.Codigo = 0 Then '-- SE FOR IGUAL A ZERO, É PORQUE É UM NOVO USUARIO
                    Seguranca.criarUsuario(u)
                Else '-- CASO CONTRÁRIO ATUALIZA
                    If vendedor.CodigoUsuario = 0 Then Throw New BusinessException("CÓDIGO DE USUÁRIO INVÁLIDO. ENTRAR EM CONTATO COM O SUPORTE.")
                    u.Codigo = vendedor.CodigoUsuario
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

        Public Function listarVendedor(ByVal v As Dominio.Administrativo.Vendedor) As System.Data.DataTable Implements IVendedorController.listarVendedor
            Dim dao As IVendedorDAO

            Try

                dao = DaoFactory.GetVendedorDAO
                Return dao.listarVendedor(v)

            Catch ex As Exception
                Throw ex
            Finally
                dao = Nothing
                DaoFactory.CloseConnection()
            End Try
        End Function
    End Class

End Namespace