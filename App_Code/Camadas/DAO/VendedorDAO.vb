Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.OleDb
Imports Camadas.Dominio.Administrativo
Imports Camadas.DAO

Public Class VendedorDAO
    Implements IVendedorDAO

    Private conn As IDbConnection
    Private cmd As IDbCommand
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

    Public Function listarVendedor() As DataTable Implements IVendedorDAO.listarVendedor
        Dim ds As New DataSet
        'Dim vendedor As Vendedor
        'Dim pessoaFisica As PessoaFisica
        'Dim listVendedor As New List(Of Vendedor)

        strSql = "  SELECT * "
        strSql += "   FROM eb06vendedor "
        strSql += " ORDER BY EB06NOME "

        Try

            adpt = DaoFactory.GetDataAdapter
            cmd = conn.CreateCommand
            cmd.CommandText = strSql
            adpt.SelectCommand = cmd
            adpt.Fill(ds)

            Return ds.Tables(0)

            'cmd = conn.CreateCommand
            'cmd.CommandText = strSql
            'dr = cmd.ExecuteReader

            'While dr.Read
            '    vendedor = New Vendedor
            '    pessoaFisica = New PessoaFisica

            '    vendedor.Codigo = dr.Item("EB06CODIGO")
            '    pessoaFisica.Nome = dr.Item("EB06NOME").ToString
            '    pessoaFisica.Cpf = dr.Item("EB06CPF").ToString
            '    pessoaFisica.Rg = dr.Item("EB06RG").ToString
            '    vendedor.PessoaFisica = pessoaFisica
            '    vendedor.Endereco.Logradouro = dr.Item("EB06ENDERECO").ToString
            '    vendedor.Endereco.Cidade.Codigo = dr.Item("FK0698CIDADEUF").ToString
            '    vendedor.Contato.FoneCelular = dr.Item("EB06CELULAR").ToString
            '    vendedor.Contato.FoneResidencial = dr.Item("EB06FONEFIXO").ToString
            '    vendedor.Contato.Fax = dr.Item("EB06FAX").ToString
            '    vendedor.Contato.Email = dr.Item("EB06EMAIL").ToString

            '    listVendedor.Add(vendedor)
            'End While

            'dr.Close()

            'Return listVendedor
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
