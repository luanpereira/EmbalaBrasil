Imports Excecoes
Imports Microsoft.VisualBasic
Imports MySql.Data.MySqlClient
Imports System.Data
Imports Camadas.DAO
Imports System.Data.OleDb

Public Class EstoqueDAO
    Implements IEstoqueDAO

    Private conn As MySqlConnection
    Private Cmd As MySqlCommand
    Private StrSql As String
    Private Adpt As IDbDataAdapter

    'OBTÉM O USUÁRIO QUE ESTÁ NA SESSÃO
    Private session As HttpSessionState = HttpContext.Current.Session
    Private usuario As Usuario = CType(session("usuario"), Usuario)

    Public Sub New(ByVal _conn As IDbConnection)
        conn = _conn
    End Sub

    Public Sub autalizarProduto(ByVal p As Camadas.Dominio.Estoque.Produto) Implements IEstoqueDAO.autalizarProduto

    End Sub

    Public Function cadastrarProduto(ByVal p As Camadas.Dominio.Estoque.Produto) As Integer Implements IEstoqueDAO.cadastrarProduto
        StrSql = " INSERT INTO eb08produto (EB08NOME,EB08SIGLA,EB08ESPECIFICACA,EB08ESTOQUEMINIMO,FK0815UNIDADE,EB08PRECO) "
        StrSql += " VALUES('" & p.Nome & "','" & p.Sigla & "','" & p.Especficicao & "'," & p.EstoqueMinimo & "," & p.Unidade.Codigo & "," & p.Preco & ")"

        Try
            cmd = conn.CreateCommand
            cmd.Transaction = DaoFactory.GetCurrentTransaction
            cmd.CommandText = strSql
            Cmd.ExecuteNonQuery()
            Dim result As Integer = Cmd.LastInsertedId

            '===========LOG===========
            Seguranca.GravarLog(usuario, "I", "EB08", StrSql)
            '=========================

            Return result
        Catch ex As OleDbException
            Throw New DAOException(ex.Message)
        Catch ex As Exception
            Throw New DAOException(ex.Message)
        End Try
    End Function

    Public Function listarProduto(ByVal p As Camadas.Dominio.Estoque.Produto) As System.Data.DataTable Implements IEstoqueDAO.listarProduto
        Dim ds As New DataSet

        StrSql = "  SELECT *, "
        StrSql += "        (SELECT EB15NOME FROM EB15UNIDADE WHERE EB15CODIGO=FK0815UNIDADE) UNIDADE "
        StrSql += "   FROM EB08PRODUTO "
        StrSql += "  WHERE 1=1 "

        If p.Codigo > 0 Then StrSql += "    AND EB08CODIGO = " & p.Codigo

        StrSql += "  ORDER BY EB08NOME,EB08ESPECIFICACAO "

        Try
            Adpt = DaoFactory.GetDataAdapter
            Cmd = conn.CreateCommand
            Cmd.CommandText = StrSql
            Adpt.SelectCommand = Cmd
            Adpt.Fill(ds)

            Return ds.Tables(0)
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Function listarUnidade() As System.Data.DataTable Implements IEstoqueDAO.listarUnidade
        Dim ds As New DataSet

        strSql = "  SELECT * "
        strSql += "   FROM EB15UNIDADE "
        strSql += "  ORDER BY EB15NOME,EB15DESCRICAO "

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
