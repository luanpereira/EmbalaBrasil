Imports System.Data
Imports Camadas.DAO
'Imports Camadas.Dominio
Imports System.Security.Cryptography
Imports System.Text
Imports Excecoes
Imports System.Data.OleDb
Imports System.Collections.Generic
Imports MySql.Data.MySqlClient

'Imports MySql.Data.MySqlClient

Public Class Seguranca

    Private Shared conn As IDbConnection
    Private Shared cmd As IDbCommand
    Private Shared adpt As IDbDataAdapter
    Private Shared dr As IDataReader
    Private Shared strSql As String = ""

    Private session As HttpSessionState = HttpContext.Current.Session
    Private Usuario As Usuario = CType(session("usuario"), Usuario)


    Public Shared Sub ValidarPermissao(ByVal empresa As Int16, _
                                   ByVal usuario As String, _
                                   ByVal sistema As String, _
                                   ByVal modulo As String, _
                                   ByVal transacao As String)

        Throw New NotImplementedException

        'Dim c As New ClassesNet.Seguranca

        'If Not c.Acesso(empresa, usuario, sistema, modulo, transacao, "", "") Then
        '    Throw New UsuarioNaoAutorizadoException
        'End If
    End Sub

    Public Shared Sub GravarLog(ByVal u As Usuario, ByVal operacao As String, ByVal tabela As String, ByVal sql As String)

        strSql = "  INSERT INTO ac96log VALUES(NULL,"
        strSql += u.Codigo & ", '"
        strSql += operacao & "', '"
        strSql += tabela & "', '"
        strSql += sql.Replace("'", "") & "', CURRENT_TIMESTAMP())"

        Try


            cmd = DaoFactory.GetConnection.CreateCommand
            'cmd.Transaction = DaoFactory.GetCurrentTransaction
            cmd.CommandText = strSql
            cmd.ExecuteNonQuery()

        Catch ex As OleDbException
            Throw New DAOException(ex.Message)
        Catch ex As Exception
            Throw New DAOException(ex.Message)
        End Try

    End Sub

    Public Shared Sub EfetuarLogin(ByRef usuario As Usuario)

        Try

            'FUNCIONARIO
            'usuario.Senha = classesNet.Criptigrafar(usuario.Senha)
            'usuario.Senha = "202cb962ac59075b964b07152d234b70"
            ValidarAcesso(usuario)

        Catch ex As UsuarioPermissaoException
            Throw ex
        Catch ex As UsuarioInvalidoException
            Throw ex
            'Catch ex As MySqlException
            '    Throw New DAOException(ex.Message)
        Catch ex As OleDbException
            Throw New DAOException(ex.Message)
        Catch ex As Exception
            Throw New DAOException(ex.Message)
        Finally
            If conn.State = ConnectionState.Open Then
                conn.Close()
            End If
            DaoFactory.CloseConnection()
        End Try

    End Sub

    Private Shared Sub ValidarAcesso(ByRef usuario As Usuario)

        strSql = "SELECT * "
        strSql += "  from ac03usuario"
        strSql += " where AC03USUARIO = '" & usuario.Usuario & "' "
        strSql += "   and AC03SENHA = MD5('" & usuario.Senha & "')"
        'strSql += "   and FK0220CODEMP = " & usuario.Empresa

        Try
            conn = DaoFactory.GetConnection
            cmd = conn.CreateCommand
            cmd.CommandText = strSql
            dr = cmd.ExecuteReader

            If Not dr.Read Then
                dr.Close()
                Throw New UsuarioInvalidoException("USUÁRIO OU SENHA INVÁLIDOS!")
            Else
                usuario.Codigo = dr.Item("AC03CODIGO").ToString
                usuario.Nome = dr.Item("AC03NOMECOMPLETO").ToString
                If dr.Item("AC03ULTIMOACESSO").ToString <> "" Then usuario.UltimoAcesso = Format(Date.Parse(dr.Item("AC03ULTIMOACESSO").ToString), "dd/MM/yyyy")
                usuario.Ativo = dr.Item("AC03ATIVO").ToString

                If usuario.Ativo = "0" Then Throw New UsuarioPermissaoException("VOCÊ FOI DESATIVADO DO SISTEMA. ENTRE EM CONTATO COM O SUPORTE.")

                dr.Close()

                strSql = "  UPDATE ac03usuario SET AC03ULTIMOACESSO = CURRENT_TIMESTAMP() "
                strSql += " WHERE AC03CODIGO = " & usuario.Codigo

                cmd = conn.CreateCommand
                'cmd.Transaction = DaoFactory.GetCurrentTransaction
                cmd.CommandText = strSql
                cmd.ExecuteNonQuery()

                '===========LOG===========
                Seguranca.GravarLog(usuario, "U", "AC03", strSql)
                '=========================
            End If

        Catch ex As UsuarioPermissaoException
            Throw ex
        Catch ex As UsuarioInvalidoException
            Throw ex
        Catch ex As MySqlException
            Throw New DAOException(ex.Message)
        Catch ex As OleDbException
            Throw New DAOException(ex.Message)
        Catch ex As Exception
            Throw New DAOException(ex.Message)
        Finally
            conn.Close()
        End Try

    End Sub

    Public Sub ValidarAcesso(ByRef Funcao1 As Int32, Optional ByVal Funcao2 As Int32 = 0, Optional ByVal Funcao3 As Int32 = 0)

        Try
            If session("usuario") Is Nothing Then
                Throw New UsuarioPermissaoException("SEU LOGIN EXPIROU. FAÇA SEU LOGIN NOVAMENTE.")
            Else
                If Not (CType(session("usuario"), Usuario).Funcao = Funcao1 Or _
                    CType(session("usuario"), Usuario).Funcao = Funcao2 Or _
                    CType(session("usuario"), Usuario).Funcao = Funcao3) Then
                    Throw New UsuarioPermissaoException("ACESSO NEGADO. VOCÊ NÃO TEM PERMISSÃO PARA PROSEGUIR.")
                End If
            End If

        Catch ex As UsuarioPermissaoException
            Throw ex
        End Try

    End Sub

    Public Shared Function CriptografarMD5(ByVal s As String) As String

        Dim btyScr() As Byte = ASCIIEncoding.ASCII.GetBytes(s)
        Dim objMd5 As New MD5CryptoServiceProvider()
        Dim btyRes() As Byte = objMd5.ComputeHash(btyScr)
        Dim intTotal As Integer = (CInt(btyRes.Length * 2) + CInt((btyRes.Length / 8)))
        Dim strRes As StringBuilder = New StringBuilder(intTotal)
        Dim intI As Integer

        For intI = 0 To btyRes.Length - 1
            strRes.Append(BitConverter.ToString(btyRes, intI, 1))
        Next intI

        Return strRes.ToString().TrimEnd(New Char() {" "c}).ToLower

    End Function

End Class
