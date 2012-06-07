Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.OleDb
Imports Camadas.Dominio.Administrativo
Imports Camadas.DAO
Imports Excecoes
Imports MySql.Data.MySqlClient

Public Class VendedorDAO
    Implements IVendedorDAO

    Private conn As MySqlConnection
    Private cmd As MySqlCommand
    Private dr As IDataReader
    Private strSql As String
    Private adpt As IDbDataAdapter

    Private _paramSql As OleDbParameter

    'OBTÉM O USUÁRIO QUE ESTÁ NA SESSÃO
    Private session As HttpSessionState = HttpContext.Current.Session
    Private usuario As Usuario = CType(session("usuario"), Usuario)

    Public Sub New(ByVal _conn As IDbConnection)
        conn = _conn
    End Sub

    Public Sub atualizarVendedor(ByVal vendedor As Camadas.Dominio.Administrativo.Vendedor) Implements IVendedorDAO.atualizarVendedor
        strSql = "  UPDATE eb06vendedor SET EB06NOME='" & vendedor.PessoaFisica.Nome & "',EB06CPF='" & vendedor.PessoaFisica.Cpf & "',EB06RG='" & vendedor.PessoaFisica.Rg & "',"
        strSql += " EB06DATANASCIMENTO='" & vendedor.DataNascimento & "',EB06ENDERECO='" & vendedor.Endereco.Logradouro & "',FK0698CIDADEUF=" & IIf(vendedor.Endereco.Cidade.Codigo = 0, "NULL", vendedor.Endereco.Cidade.Codigo) & ","
        strSql += " EB06CEP='" & vendedor.Endereco.Cep & "',EB06EMAIL='" & vendedor.Contato.Email & "',EB06CELULAR='" & vendedor.Contato.FoneCelular & "',EB06FONEFIXO='" & vendedor.Contato.FoneResidencial & "',"
        strSql += " EB06FAX='" & vendedor.Contato.Fax & "' "
        strSql += " WHERE EB06CODIGO = " & vendedor.Codigo

        Try
            cmd = conn.CreateCommand
            cmd.Transaction = DaoFactory.GetCurrentTransaction
            cmd.CommandText = strSql
            cmd.ExecuteNonQuery()

            '===========LOG===========
            Seguranca.GravarLog(usuario, "U", "EB06", strSql)
            '=========================

        Catch ex As OleDbException
            Throw New DAOException(ex.Message)
        Catch ex As Exception
            Throw New DAOException(ex.Message)
        End Try
    End Sub

    Public Function cadastrarVendedor(ByVal vendedor As Camadas.Dominio.Administrativo.Vendedor) As Integer Implements IVendedorDAO.cadastrarVendedor
        Dim result As Integer

        strSql = " INSERT INTO eb06vendedor (EB06NOME,EB06CPF,EB06RG,EB06DATANASCIMENTO,EB06ENDERECO,FK0698CIDADEUF,EB06CEP,EB06EMAIL,EB06CELULAR,EB06FONEFIXO,EB06FAX) "
        strSql += " VALUES('" & vendedor.PessoaFisica.Nome & "','" & vendedor.PessoaFisica.Cpf & "','" & vendedor.PessoaFisica.Rg & "','" & vendedor.DataNascimento & "','" & vendedor.Endereco.Logradouro & "',"
        strSql += IIf(vendedor.Endereco.Cidade.Codigo = 0, "NULL", vendedor.Endereco.Cidade.Codigo) & ",'" & vendedor.Endereco.Cep & "','" & vendedor.Contato.Email & "','" & vendedor.Contato.FoneCelular & "','"
        strSql += vendedor.Contato.FoneResidencial & "','" & vendedor.Contato.Fax & "')"

        Try
            cmd = conn.CreateCommand
            cmd.Transaction = DaoFactory.GetCurrentTransaction
            cmd.CommandText = strSql
            cmd.ExecuteNonQuery()
            result = cmd.LastInsertedId

            '===========LOG===========
            Seguranca.GravarLog(usuario, "I", "EB06", strSql)
            '=========================

            Return result
        Catch ex As OleDbException
            Throw New DAOException(ex.Message)
        Catch ex As MySqlException
            If ex.Number = 1062 Then
                Throw New DAOException("VENDEDOR COM O CPF JÁ CADASTRADO NO SISTEMA!")
            Else
                Throw New DAOException(ex.Message)
            End If
        Catch ex As Exception
            Throw New DAOException(ex.Message)
        End Try
    End Function

    Public Function listarVendedor(ByVal v As Camadas.Dominio.Administrativo.Vendedor) As System.Data.DataTable Implements IVendedorDAO.listarVendedor
        Dim ds As New DataSet

        strSql = "  SELECT *, "
        strSql += "        CONCAT(EB06CELULAR,'/',EB06FONEFIXO,'/',EB06FAX) AS TELEFONE, "
        strSql += "        (SELECT EB99CODIGO FROM EB99ESTADO, EB98CIDADE WHERE FK9899ESTADO=EB99CODIGO AND EB98CODIGO=FK0698CIDADEUF) AS CODIGO_UF, "
        strSql += "        (SELECT EB99SIGLA FROM EB99ESTADO, EB98CIDADE WHERE FK9899ESTADO=EB99CODIGO AND EB98CODIGO=FK0698CIDADEUF) AS SIGLA_UF, "
        strSql += "        (SELECT EB98NOME FROM EB98CIDADE WHERE EB98CODIGO=FK0698CIDADEUF) AS CIDADE, "
        strSql += "        (SELECT EB96ACESSOWEB FROM EB96USUARIO WHERE FK9606VENDEDOR=EB06CODIGO) AS ACESSO, "
        strSql += "        (SELECT EB96CODIGO FROM EB96USUARIO WHERE FK9606VENDEDOR=EB06CODIGO) AS CODIGO_USUARIO "
        strSql += "    FROM eb06vendedor "

        If v.Codigo > 0 Then strSql += " WHERE EB06CODIGO = " & v.Codigo

        If Not v.PessoaFisica Is Nothing AndAlso Not v.PessoaFisica.Nome.Trim = String.Empty Then strSql += " WHERE EB06NOME LIKE '%" & v.PessoaFisica.Nome & "%' "

        If Not v.PessoaFisica Is Nothing AndAlso Not v.PessoaFisica.Cpf.Trim = String.Empty Then strSql += IIf(v.PessoaFisica.Nome.Trim = String.Empty, " WHERE EB06CPF LIKE '%" & v.PessoaFisica.Cpf & "%' ", " OR EB06CPF LIKE '%" & v.PessoaFisica.Cpf & "%' ")

        strSql += "  ORDER BY   EB06NOME "

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
