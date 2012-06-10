﻿Imports Excecoes
Imports Microsoft.VisualBasic
Imports MySql.Data.MySqlClient
Imports System.Data
Imports Camadas.DAO
Imports Camadas.Dominio.Estoque
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
        Dim preco As String = ""

        StrSql = "  UPDATE eb08produto SET EB08NOME='" & p.Nome & "',EB08SIGLA='" & p.Sigla & "',EB08ESPECIFICACAO='" & p.Especificacao & "',"
        StrSql += " EB08ESTOQUEMINIMO=" & p.EstoqueMinimo & ",FK0815UNIDADE=" & p.Unidade.Codigo & ","
        StrSql += " EB08PRECO="
        preco = p.Preco & " "
        StrSql += preco.Replace(",", ".")
        StrSql += " WHERE EB08CODIGO = " & p.Codigo

        Try
            Cmd = conn.CreateCommand
            Cmd.Transaction = DaoFactory.GetCurrentTransaction
            Cmd.CommandText = StrSql
            Cmd.ExecuteNonQuery()
            Dim result As Integer = Cmd.LastInsertedId

            '===========LOG===========
            Seguranca.GravarLog(usuario, "U", "EB08", StrSql)
            '=========================

        Catch ex As OleDbException
            Throw New DAOException("atualizaProduto >> " & ex.Message)
        Catch ex As MySqlException
            If ex.Number = 1062 Then
                Throw New DAOException("SIGLA JÁ EXISTENTE NA BASE DE DADOS. TENTE OUTRA.")
            Else
                Throw New DAOException("atualizaProduto >> " & ex.Message)
            End If
        Catch ex As Exception
            Throw New DAOException("atualizaProduto >> " & ex.Message)
        End Try
    End Sub

    Public Function cadastrarProduto(ByVal p As Camadas.Dominio.Estoque.Produto) As Integer Implements IEstoqueDAO.cadastrarProduto
        Dim preco As String = ""

        StrSql = " INSERT INTO eb08produto (EB08NOME,EB08SIGLA,EB08ESPECIFICACAO,EB08ESTOQUEMINIMO,FK0815UNIDADE,EB08PRECO) "
        StrSql += " VALUES('" & p.Nome & "','" & p.Sigla & "','" & p.Especificacao & "'," & p.EstoqueMinimo & "," & p.Unidade.Codigo & ","
        preco = p.Preco & ")"
        StrSql += preco.Replace(",", ".")

        Try
            Cmd = conn.CreateCommand
            Cmd.Transaction = DaoFactory.GetCurrentTransaction
            Cmd.CommandText = StrSql
            Cmd.ExecuteNonQuery()
            Dim result As Integer = Cmd.LastInsertedId

            '===========LOG===========
            Seguranca.GravarLog(usuario, "I", "EB08", StrSql)
            '=========================

            Return result
        Catch ex As OleDbException
            Throw New DAOException("cadastroProduto >> " & ex.Message)
        Catch ex As MySqlException
            If ex.Number = 1062 Then
                Throw New DAOException("SIGLA JÁ EXISTENTE NA BASE DE DADOS. TENTE OUTRA.")
            Else
                Throw New DAOException("cadastroProduto >> " & ex.Message)
            End If
        Catch ex As Exception
            Throw New DAOException("cadastroProduto >> " & ex.Message)
        End Try
    End Function

    Public Function listarProduto(ByVal p As Camadas.Dominio.Estoque.Produto) As System.Data.DataTable Implements IEstoqueDAO.listarProduto
        Dim ds As New DataSet

        StrSql = "  SELECT *, "
        StrSql += "        CONCAT((SELECT EB15NOME FROM EB15UNIDADE WHERE EB15CODIGO=FK0815UNIDADE),' >> ',EB08NOME,' - ',LEFT(EB08ESPECIFICACAO,60)) NOMECOMPLETO, "
        StrSql += "        (SELECT EB15NOME FROM EB15UNIDADE WHERE EB15CODIGO=FK0815UNIDADE) UNIDADE, "
        StrSql += "        CONCAT(CAST(EB08CODIGO AS CHAR),';',CAST(EB08PRECO AS CHAR)) CODIGOPRECO"
        StrSql += "   FROM EB08PRODUTO "
        StrSql += "  WHERE 1=1 "

        If p.Codigo > 0 Then StrSql += "    AND EB08CODIGO = " & p.Codigo

        StrSql += "  ORDER BY EB08NOME,UNIDADE,EB08ESPECIFICACAO "

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

        StrSql = "  SELECT * "
        StrSql += "   FROM EB15UNIDADE "
        StrSql += "  ORDER BY EB15NOME,EB15DESCRICAO "

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

    Public Function cadastrarPedido(ByVal pedido As Camadas.Dominio.Estoque.Pedido) As Long Implements IEstoqueDAO.cadastrarPedido
        Dim result As Long

        StrSql = " INSERT INTO eb07pedido (FK0711FORMAPG,EB07DATAPAGAMENTO,EB07DATA,EB07NOTAFISCAL,FK0705EMPRESA,EB07SITUACAO) VALUES( "
        StrSql += IIf(pedido.FormaPagamento.Codigo = 0, "NULL", pedido.FormaPagamento.Codigo) & ","
        StrSql += IIf(pedido.DataPagamento.Trim = String.Empty, "NULL", "'" & pedido.DataPagamento.Trim & "'") & ",NOW(),"
        StrSql += IIf(pedido.NotaFiscal.Trim = String.Empty, "NULL", "'" & pedido.NotaFiscal.Trim & "'") & ","
        StrSql += session("empresa") & ","
        StrSql += "'" & pedido.Situacao.ToUpper & "')"

        Try
            Cmd = conn.CreateCommand
            Cmd.Transaction = DaoFactory.GetCurrentTransaction
            Cmd.CommandText = StrSql
            Cmd.ExecuteNonQuery()
            result = Cmd.LastInsertedId

            '===========LOG===========
            Seguranca.GravarLog(usuario, "I", "EB07", StrSql)
            '=========================

            Me.cadastrarItemPedido(result, pedido.Itens)

            Return result
        Catch ex As OleDbException
            Throw New DAOException("cadastrarPedido >> " & ex.Message)
        Catch ex As Exception
            Throw New DAOException("cadastrarPedido >> " & ex.Message)
        End Try
    End Function

    Private Sub cadastrarItemPedido(ByVal idPedido As Long, ByVal itemPedido As List(Of ItemPedido))
        Dim sqlLog As String = ""
        Dim valor As String = ""

        Try
            Cmd = conn.CreateCommand
            Cmd.Transaction = DaoFactory.GetCurrentTransaction

            For i As Integer = 0 To itemPedido.Count - 1
                StrSql = "  INSERT INTO eb09itempedido (FK0907PEDIDO,FK0908PRODUTO,EB09QTD) VALUES("
                StrSql += idPedido & ", "
                StrSql += itemPedido.Item(i).Produto.Codigo & ", "
                valor = itemPedido.Item(i).Quantidade & ""
                StrSql += valor.Replace(",", ".") & ")"

                Cmd.CommandText = StrSql
                Cmd.ExecuteNonQuery()

                sqlLog += StrSql & " | "
            Next

            '=========== LOG ===========
            Seguranca.GravarLog(usuario, "I", "EB09", sqlLog)
            '=========================

        Catch ex As OleDbException
            Throw New DAOException("cadastrarItemPedido >> " & ex.Message)
        Catch ex As Exception
            Throw New DAOException("cadastrarItemPedido >> " & ex.Message)
        End Try
    End Sub

    Public Sub cadastrarEntradaProduto(ByVal ep As Camadas.Dominio.Estoque.EntradaProduto) Implements IEstoqueDAO.cadastrarEntradaProduto

        StrSql = " INSERT INTO eb16entradaproduto (FK1607PEDIDO,EB16OBS) VALUES( "
        StrSql += ep.Codigo & ","
        StrSql += "'" & ep.Observacao & "')"

        Try
            Cmd = conn.CreateCommand
            Cmd.Transaction = DaoFactory.GetCurrentTransaction
            Cmd.CommandText = StrSql
            Cmd.ExecuteNonQuery()

            '===========LOG===========
            Seguranca.GravarLog(usuario, "I", "EB16", StrSql)
            '=========================

        Catch ex As OleDbException
            Throw New DAOException("cadastrarEntradaProduto >> " & ex.Message)
        Catch ex As Exception
            Throw New DAOException("cadastrarEntradaProduto >> " & ex.Message)
        End Try
    End Sub

    Public Sub registrarCaixa(ByVal caixa As Camadas.Dominio.Financeiro.Caixa) Implements IEstoqueDAO.registrarCaixa
        Dim valor As String = ""

        StrSql = " INSERT INTO eb13caixa (EB13DATA,EB13OPERACAO,EB13VALOR,FK1307PEDIDO) VALUES(NOW(),"
        StrSql += "'" & caixa.Operacao & "',"
        valor = caixa.Valor & ""
        StrSql += valor.Replace(",", ".") & ","
        StrSql += caixa.Pedido.Codigo & ")"

        Try
            Cmd = conn.CreateCommand
            Cmd.Transaction = DaoFactory.GetCurrentTransaction
            Cmd.CommandText = StrSql
            Cmd.ExecuteNonQuery()

            '===========LOG===========
            Seguranca.GravarLog(usuario, "I", "EB13", StrSql)
            '=========================

        Catch ex As OleDbException
            Throw New DAOException("registrarCaixa >> " & ex.Message)
        Catch ex As Exception
            Throw New DAOException("registrarCaixa >> " & ex.Message)
        End Try
    End Sub
End Class
