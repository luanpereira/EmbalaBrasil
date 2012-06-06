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

        Public Function cadastrarClientePessoaFisica(ByVal cliente As Cliente) As Integer Implements IClienteDAO.cadastrarClientePessoaFisica
            Dim result As Integer

            strSql = " INSERT INTO eb04cliente (EB04NOME,EB04CPF,EB04RG,EB04DATANASCIMENTO,EB04ENDERECO,FK0498CIDADEUF,EB04CEP,EB04EMAIL,EB04CELULAR,EB04FONEFIXO,EB04FAX,FK0406VENDEDOR,EB04TIPOPESSOA,EB04TIPOCLIENTE) "
            strSql += " VALUES('" & cliente.PessoaFisica.Nome & "','" & cliente.PessoaFisica.Cpf & "','" & cliente.PessoaFisica.Rg & "','" & cliente.DataNascimento & "','" & cliente.Endereco.Logradouro & "',"
            strSql += IIf(cliente.Endereco.Cidade.Codigo = 0, "NULL", cliente.Endereco.Cidade.Codigo) & ",'" & cliente.Endereco.Cep & "','" & cliente.Contato.Email & "','" & cliente.Contato.FoneCelular & "','"
            strSql += cliente.Contato.FoneResidencial & "','" & cliente.Contato.Fax & "'," & IIf(cliente.Vendedor.Codigo = 0, "NULL", cliente.Vendedor.Codigo) & ",'F','"
            strSql += IIf(cliente.TipoCliente = eTipoCliente.Comum, "C", "M") & "')"

            Try
                cmd = conn.CreateCommand
                cmd.Transaction = DaoFactory.GetCurrentTransaction
                cmd.CommandText = strSql
                cmd.ExecuteNonQuery()
                result = cmd.LastInsertedId

                '===========LOG===========
                Seguranca.GravarLog(usuario, "I", "EB04", strSql)
                '=========================

                Return result
            Catch ex As OleDbException
                Throw New DAOException(ex.Message)
            Catch ex As MySqlException
                If ex.Number = 1062 Then
                    Throw New DAOException("CLIENTE COM O CPF JÁ CADASTRADO NO SISTEMA!")
                Else
                    Throw New DAOException(ex.Message)
                End If
            Catch ex As Exception
                Throw New DAOException(ex.Message)
            End Try
        End Function

        Public Function cadastrarClientePessoaJuridica(ByVal cliente As Cliente) As Integer Implements IClienteDAO.cadastrarClientePessoaJuridica
            Dim result As Integer

            strSql = " INSERT INTO eb04cliente (EB04DATANASCIMENTO,EB04CNPJ,EB04RAZAOSOCIAL,EB04FANTASIA,EB04INSCRICAOESTADUAL,EB04ENDERECO,FK0498CIDADEUF,EB04CEP,EB04EMAIL,EB04CELULAR,EB04FONEFIXO,EB04FAX,FK0406VENDEDOR,EB04TIPOPESSOA,EB04TIPOCLIENTE) "
            strSql += " VALUES('" & cliente.DataNascimento & "','" & cliente.PessoaJuridica.CNPJ & "','" & cliente.PessoaJuridica.RazaoSocial & "','" & cliente.PessoaJuridica.Fantasia & "','" & cliente.PessoaJuridica.InscricaoEstadual & "','" & cliente.Endereco.Logradouro & "',"
            strSql += IIf(cliente.Endereco.Cidade.Codigo = 0, "NULL", cliente.Endereco.Cidade.Codigo) & ",'" & cliente.Endereco.Cep & "','" & cliente.Contato.Email & "','" & cliente.Contato.FoneCelular & "','"
            strSql += cliente.Contato.FoneResidencial & "','" & cliente.Contato.Fax & "'," & IIf(cliente.Vendedor.Codigo = 0, "NULL", cliente.Vendedor.Codigo) & ",'J','"
            strSql += IIf(cliente.TipoCliente = eTipoCliente.Comum, "C", "M") & "')"

            Try
                cmd = conn.CreateCommand
                cmd.Transaction = DaoFactory.GetCurrentTransaction
                cmd.CommandText = strSql
                cmd.ExecuteNonQuery()
                result = cmd.LastInsertedId

                '===========LOG===========
                Seguranca.GravarLog(usuario, "I", "EB04", strSql)
                '=========================

                Return result
            Catch ex As OleDbException
                Throw New DAOException(ex.Message)
            Catch ex As MySqlException
                If ex.Number = 1062 Then
                    Throw New DAOException("CLIENTE COM O CNPJ JÁ CADASTRADO NO SISTEMA!")
                Else
                    Throw New DAOException(ex.Message)
                End If
            Catch ex As Exception
                Throw New DAOException(ex.Message)
            End Try
        End Function

        Public Function listarCliente() As DataTable Implements IClienteDAO.listarCliente
            Dim ds As New DataSet

            strSql = "  SELECT *, "
            strSql += "        CASE WHEN EB04NOME IS NULL THEN "
            strSql += "          EB04RAZAOSOCIAL "
            strSql += "        ELSE "
            strSql += "          EB04NOME "
            strSql += "        END AS NOME, "
            strSql += "        CASE WHEN EB04CPF IS NULL THEN "
            strSql += "          EB04CNPJ "
            strSql += "        ELSE "
            strSql += "          EB04CPF "
            strSql += "        END AS CPF_CNPJ, "
            strSql += "        (SELECT EB06NOME FROM EB06VENDEDOR WHERE EB06CODIGO=FK0406VENDEDOR) AS VENDEDOR, "
            strSql += "        CONCAT(EB04CELULAR,'/',EB04FONEFIXO,'/',EB04FAX) AS TELEFONE, "
            strSql += "        (SELECT EB99CODIGO FROM EB99ESTADO, EB98CIDADE WHERE FK9899ESTADO=EB99CODIGO AND EB98CODIGO=FK0498CIDADEUF) AS CODIGO_UF, "
            strSql += "        (SELECT EB99SIGLA FROM EB99ESTADO, EB98CIDADE WHERE FK9899ESTADO=EB99CODIGO AND EB98CODIGO=FK0498CIDADEUF) AS SIGLA_UF, "
            strSql += "        (SELECT EB98NOME FROM EB98CIDADE WHERE EB98CODIGO=FK0498CIDADEUF) AS CIDADE, "
            strSql += "        (SELECT EB96ACESSOWEB FROM EB96USUARIO WHERE FK9604CLIENTE=EB04CODIGO) AS ACESSO "
            strSql += "   FROM EB04CLIENTE "
            strSql += "  ORDER BY NOME,VENDEDOR "

            Try
                adpt = DaoFactory.GetDataAdapter
                cmd = conn.CreateCommand
                cmd.CommandText = strSql
                adpt.SelectCommand = cmd
                adpt.Fill(ds)

                Return ds.Tables(0)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

        Public Function listarCliente(ByVal c As Cliente) As DataTable Implements IClienteDAO.listarCliente
            Dim ds As New DataSet

            strSql = "  SELECT *, "
            strSql += "        CASE WHEN EB04NOME IS NULL THEN "
            strSql += "          EB04RAZAOSOCIAL "
            strSql += "        ELSE "
            strSql += "          EB04NOME "
            strSql += "        END AS NOME, "
            strSql += "        CASE WHEN EB04CPF IS NULL THEN "
            strSql += "          EB04CNPJ "
            strSql += "        ELSE "
            strSql += "          EB04CPF "
            strSql += "        END AS CPF_CNPJ, "
            strSql += "        (SELECT EB06NOME FROM EB06VENDEDOR WHERE EB06CODIGO=FK0406VENDEDOR) AS VENDEDOR, "
            strSql += "        CONCAT(EB04CELULAR,'/',EB04FONEFIXO,'/',EB04FAX) AS TELEFONE, "
            strSql += "        (SELECT EB99CODIGO FROM EB99ESTADO, EB98CIDADE WHERE FK9899ESTADO=EB99CODIGO AND EB98CODIGO=FK0498CIDADEUF) AS CODIGO_UF, "
            strSql += "        (SELECT EB99SIGLA FROM EB99ESTADO, EB98CIDADE WHERE FK9899ESTADO=EB99CODIGO AND EB98CODIGO=FK0498CIDADEUF) AS SIGLA_UF, "
            strSql += "        (SELECT EB98NOME FROM EB98CIDADE WHERE EB98CODIGO=FK0498CIDADEUF) AS CIDADE, "
            strSql += "        (SELECT EB96ACESSOWEB FROM EB96USUARIO WHERE FK9604CLIENTE=EB04CODIGO) AS ACESSO "
            strSql += "    FROM EB04CLIENTE "

            If c.Codigo > 0 Then strSql += " WHERE EB04CODIGO = " & c.Codigo

            If Not c.PessoaFisica Is Nothing AndAlso Not c.PessoaFisica.Nome.Trim = String.Empty Then strSql += " WHERE EB04NOME LIKE '%" & c.PessoaFisica.Nome & "%' "
            If Not c.PessoaJuridica Is Nothing AndAlso Not c.PessoaJuridica.RazaoSocial.Trim = String.Empty Then strSql += " OR EB04RAZAOSOCIAL LIKE '%" & c.PessoaJuridica.RazaoSocial & "%' "
            If Not c.PessoaJuridica Is Nothing AndAlso Not c.PessoaJuridica.Fantasia.Trim = String.Empty Then strSql += " OR EB04FANTASIA LIKE '%" & c.PessoaJuridica.Fantasia & "%' "

            If Not c.PessoaFisica Is Nothing AndAlso Not c.PessoaFisica.Cpf.Trim = String.Empty Then strSql += IIf(c.PessoaFisica.Nome.Trim = String.Empty, " WHERE EB04CPF LIKE '%" & c.PessoaFisica.Cpf & "%' ", " OR EB04CPF LIKE '%" & c.PessoaFisica.Cpf & "%' ")
            If Not c.PessoaJuridica Is Nothing AndAlso Not c.PessoaJuridica.CNPJ.Trim = String.Empty Then strSql += " OR EB04CNPJ LIKE '%" & c.PessoaJuridica.CNPJ & "%' "

            strSql += "  ORDER BY NOME,VENDEDOR "

            Try
                adpt = DaoFactory.GetDataAdapter
                cmd = conn.CreateCommand
                cmd.CommandText = strSql
                adpt.SelectCommand = cmd
                adpt.Fill(ds)

                Return ds.Tables(0)
            Catch ex As Exception
                Throw ex
            End Try
        End Function

    End Class

End Namespace