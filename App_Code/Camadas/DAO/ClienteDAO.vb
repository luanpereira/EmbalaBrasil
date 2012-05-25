Imports Microsoft.VisualBasic
Imports Camadas.Dominio.Administrativo
Imports System.Data
Imports System.Data.OleDb
Imports Infraestrutura.Utils
Imports Excecoes
Imports MySql.Data.MySqlClient

Namespace Camadas.DAO

    Public Class ClienteDAO
        Implements IClienteDAO

        Private conn As MySqlConnection
        Private cmd As MySqlCommand
        Private dr As IDataReader
        Private strSql As String
        Private adpt As IDbDataAdapter

        Private _paramSql As MySqlParameter

        'OBTÉM O USUÁRIO QUE ESTÁ NA SESSÃO
        Private session As HttpSessionState = HttpContext.Current.Session
        Private usuario As Usuario = CType(session("usuario"), Usuario)

        Public Sub New(ByVal _conn As IDbConnection)
            conn = _conn
        End Sub

        Public Sub cadastrarClientePessoaFisica(ByVal cliente As Cliente) Implements IClienteDAO.cadastrarClientePessoaFisica
            Dim result As Integer

            strSql = " INSERT INTO eb04cliente (EB04NOME,EB04CPF,EB04RG,EB04ENDERECO,FK0498CIDADEUF,EB04CEP,EB04EMAIL,EB04CELULAR,EB04FONEFIXO,EB04FAX,FK0406VENDEDOR,EB04TIPOPESSOA,EB04TIPOCLIENTE) "
            strSql += " VALUES('" & cliente.PessoaFisica.Nome & "','" & cliente.PessoaFisica.Cpf & "','" & cliente.PessoaFisica.Rg & "','" & cliente.Endereco.Logradouro & "',"
            strSql += cliente.Endereco.Cidade.Codigo & ",'" & cliente.Endereco.Cep & "','" & cliente.Contato.Email & "','" & cliente.Contato.FoneCelular & "','"
            strSql += cliente.Contato.FoneResidencial & "','" & cliente.Contato.Fax & "'," & cliente.Vendedor.Codigo & ",'" & IIf(cliente.TipoPessoa = eTipoPessoa.Física, "F", "J") & "','"
            strSql += IIf(cliente.TipoCliente = eTipoCliente.Comum, "C", "M") & "') "

            Try
                cmd = conn.CreateCommand
                cmd.Transaction = DaoFactory.GetCurrentTransaction
                cmd.CommandText = strSql
                result = cmd.ExecuteNonQuery

                '===========LOG===========
                Seguranca.GravarLog(usuario, "I", "EB04", strSql)
                '=========================
            Catch ex As OleDbException
                Throw New DAOException(ex.Message)
            Catch ex As MySqlException
                If ex.Number = 1062 Then
                    Throw New DAOException("CLIENTE COM O CPF/CNPJ JÁ CADASTRADO NO SISTEMA!")
                Else
                    Throw New DAOException(ex.Message)
                End If
            Catch ex As Exception
                Throw New DAOException(ex.Message)
            End Try
        End Sub

    End Class

End Namespace