Imports System.Data
Imports Camadas.DAO
Imports Camadas.Dominio
Imports Excecoes
Imports System.Data.OleDb
Imports System.Collections.Generic
Imports Infraestrutura
Imports MySql.Data.MySqlClient

Namespace Infraestrutura

    Public Class Utils

        Private Shared strSql As String
        Private Shared cmd As IDbCommand
        Private Shared adpt As IDbDataAdapter
        Private Shared conn As IDbConnection
        Private Shared dr As IDataReader

        Public Enum TipoMsg
            'VALORES DA VARI¡VEL TIPO
            OK '0 - OK
            ERRO '1 - ERRO
            PERGUNTA '2 - PERGUNTA
        End Enum

        Public Enum eTipoPessoa
            JurÌdica
            FÌsica
        End Enum

        Public Enum eTipoCliente
            Master
            Comum
        End Enum

        Public Shared Function UrlPaginaErro(ByVal erro As Int32) As String
            Return "~/pages/principal/Pagina_Erro.aspx?e=" & erro
        End Function

        Public Shared Function UrlPaginaLoginComErro() As String
            Return "~/pages/Login.aspx?e=true"
        End Function



#Region "GERAL"

        Public Shared Sub Delay(ByVal DelaySeconds)

            Dim SecCount, Sec2, Sec1 As Integer
            SecCount = 0
            Sec2 = 0
            While SecCount < DelaySeconds + 1
                Sec1 = Second(DateTime.Now)
                If Sec1 <> Sec2 Then
                    Sec2 = Second(DateTime.Now)
                    SecCount = SecCount + 1
                End If
            End While

        End Sub


        Public Shared Function FormatarNome(ByVal s As String) As String

            Dim result As String = ""

            result = RemoverAcentos(s)
            result = RemoverCaracteresInvalidos(result)
            result = RemoverNumeros(result)
            result = RemoverEspacosDuplos(result)

            Return result.ToUpper

        End Function

        Public Shared Function FormatarDocumento(ByVal s As String) As String
            Return RemoverCaracteresInvalidos(s)
        End Function

        Public Shared Function FormatarEndereco(ByVal s As String) As String
            Return RemoverAcentos(s)
        End Function

        Public Shared Function FormatarLog(ByVal s As String) As String
            Return RemoverCaracteresDeAcento(s)
        End Function

        Private Shared Function RemoverAcentos(ByVal s As String) As String

            Dim result As String = ""
            Dim aux As String
            Dim count As Int32
            Dim a As String = "‡¿·¡„√‰ƒ‚¬"
            Dim e As String = "Ë»È…ÎÀÍ "
            Dim i As String = "ÏÃÌÕÔœÓŒ"
            Dim o As String = "Ú“Û”ˆ÷ı’Ù‘"
            Dim u As String = "˘Ÿ˙⁄¸‹˚€"
            Dim c As String = "Á«"

            For count = 0 To s.Length - 1

                aux = s.Substring(count, 1)

                If a.IndexOf(aux) <> -1 Then
                    aux = "A"
                End If

                If e.IndexOf(aux) <> -1 Then
                    aux = "E"
                End If

                If i.IndexOf(aux) <> -1 Then
                    aux = "I"
                End If

                If o.IndexOf(aux) <> -1 Then
                    aux = "O"
                End If

                If u.IndexOf(aux) <> -1 Then
                    aux = "U"
                End If

                If c.IndexOf(aux) <> -1 Then
                    aux = "C"
                End If

                result += aux

            Next

            Return result.ToUpper

        End Function

        Private Shared Function RemoverCaracteresDeAcento(ByVal s As String) As String

            Dim caracteres As String = "'"
            Dim i As Integer
            Dim t As Integer
            Dim aux As String
            Dim r As String = ""

            t = s.Length

            For i = 0 To t - 1

                aux = s.Substring(i, 1)

                If caracteres.IndexOf(aux) <> -1 Then
                    aux = ""
                End If

                r += aux

            Next

            Return r.ToUpper

        End Function

        Private Shared Function RemoverCaracteresInvalidos(ByVal s As String) As String

            Dim caracteres As String = "¥`'~,.;!/\?<>+=-*&()%$#@[]{}^~|_"
            Dim i As Integer
            Dim t As Integer
            Dim aux As String
            Dim r As String = ""

            t = s.Length

            For i = 0 To t - 1

                aux = s.Substring(i, 1)

                If caracteres.IndexOf(aux) <> -1 Then
                    aux = ""
                End If

                r += aux

            Next

            Return r.ToUpper

        End Function

        Private Shared Function RemoverNumeros(ByVal s As String) As String

            Dim numeros As String = "0123456789"
            Dim i As Integer
            Dim t As Integer
            Dim aux As String
            Dim r As String = ""

            t = s.Length

            For i = 0 To t - 1

                aux = s.Substring(i, 1)

                If numeros.IndexOf(aux) <> -1 Then
                    aux = ""
                End If

                r += aux

            Next

            Return r.ToUpper

        End Function

        Private Shared Function RemoverEspacosDuplos(ByVal s As String) As String

            Dim espaco As String = "  "
            Dim i As Integer
            Dim t As Integer
            Dim aux As String
            Dim r As String = ""

            t = s.Length

            For i = 0 To t - 1

                If i = (t - 1) Then
                    aux = s.Substring(i, 1)
                Else
                    aux = s.Substring(i, 2)
                End If

                If espaco.IndexOf(aux) <> -1 Then
                    aux = " "
                    i += 1
                End If

                r += aux.Substring(0, 1)

            Next

            Return r.ToUpper

        End Function

        Public Shared Sub SomenteNumeros(ByVal Campo As TextBox, ByVal Pagina As Page)

            Dim strMontaMensagem As String
            Try
                If (Not Pagina.ClientScript.IsClientScriptBlockRegistered("SomenteNumeros")) Then
                    strMontaMensagem = "<script language='JavaScript'> "
                    strMontaMensagem &= "function SomenteNumeros()"
                    strMontaMensagem &= "{ "
                    strMontaMensagem &= "if (window.event.keyCode < 48 || window.event.keyCode > 57)"
                    strMontaMensagem &= "{ "
                    strMontaMensagem &= "if (window.event.keyCode != 44)"
                    strMontaMensagem &= "{ "
                    strMontaMensagem &= "window.event.keyCode = 0; "
                    strMontaMensagem &= "} "
                    strMontaMensagem &= "} "
                    strMontaMensagem &= "} "
                    strMontaMensagem &= "</script>"
                    Pagina.ClientScript.RegisterClientScriptBlock(GetType(String), "SomenteNumeros", strMontaMensagem)
                End If
                Campo.Attributes("onKeyPress") = "javascript:SomenteNumeros()"
            Catch ex As Exception
                Throw New Exception(ex.ToString)
            End Try
        End Sub

        Public Shared Sub CampoObrigatorio(ByRef oObjeto1 As Object, Optional ByRef oObjeto2 As Object = Nothing, _
                                    Optional ByRef oObjeto3 As Object = Nothing, Optional ByRef oObjeto4 As Object = Nothing, _
                                    Optional ByRef oObjeto5 As Object = Nothing, Optional ByRef oObjeto6 As Object = Nothing, _
                                    Optional ByRef oObjeto7 As Object = Nothing, Optional ByRef oObjeto8 As Object = Nothing, _
                                    Optional ByRef oObjeto9 As Object = Nothing, Optional ByRef oObjeto10 As Object = Nothing, _
                                    Optional ByRef oObjeto11 As Object = Nothing, Optional ByRef oObjeto12 As Object = Nothing, _
                                    Optional ByRef oObjeto13 As Object = Nothing, Optional ByRef oObjeto14 As Object = Nothing, _
                                    Optional ByRef oObjeto15 As Object = Nothing)
            'Recebe os objetos da tela e testa se os que ele passou foram digitados,
            'caso contrario faz critica e cai o focu nele
            'COPIADO E ADAPTADO DO PEDAGOGICO - LUAN

            Dim oCorrente As Object, yLaco As Byte

            Try
                'CampoObrigatorio = False
                yLaco = 1

                Do While yLaco <= 15
                    Select Case yLaco
                        Case 1
                            oCorrente = oObjeto1
                        Case 2
                            oCorrente = oObjeto2
                        Case 3
                            oCorrente = oObjeto3
                        Case 4
                            oCorrente = oObjeto4
                        Case 5
                            oCorrente = oObjeto5
                        Case 6
                            oCorrente = oObjeto6
                        Case 7
                            oCorrente = oObjeto7
                        Case 8
                            oCorrente = oObjeto8
                        Case 9
                            oCorrente = oObjeto9
                        Case 10
                            oCorrente = oObjeto10
                        Case 11
                            oCorrente = oObjeto11
                        Case 12
                            oCorrente = oObjeto12
                        Case 13
                            oCorrente = oObjeto13
                        Case 14
                            oCorrente = oObjeto14
                        Case 15
                            oCorrente = oObjeto15
                    End Select

                    If oCorrente Is Nothing Then Exit Sub

                    If TypeOf oCorrente Is RadioButton Then
                        If oCorrente.Value = -1 Then
                            oCorrente.cssClass = "obrigatorio UpperCase"
                            Throw New CampoObrigatorioException("O campo " & oCorrente.ToolTip & " È obrigatÛrio!")
                        Else
                            oCorrente.cssClass = ""
                        End If
                    ElseIf TypeOf oCorrente Is ListBox Then
                        If oCorrente.Items.Count = 0 Xor oCorrente.SelectedIndex = -1 Then
                            oCorrente.cssClass = "obrigatorio UpperCase"
                            Throw New CampoObrigatorioException("O campo " & oCorrente.ToolTip & " È obrigatÛrio!")
                        Else
                            oCorrente.cssClass = ""
                        End If
                    ElseIf TypeOf oCorrente Is DropDownList Then
                        If oCorrente.SelectedValue = 0 Then
                            oCorrente.cssClass = "obrigatorio UpperCase"
                            Throw New CampoObrigatorioException("O campo " & oCorrente.ToolTip & " È obrigatÛrio!")
                        Else
                            oCorrente.cssClass = ""
                        End If
                    Else
                        If Trim(oCorrente.Text) = "" Then
                            oCorrente.cssClass = "obrigatorio UpperCase"
                            Throw New CampoObrigatorioException("O campo " & oCorrente.ToolTip & " È obrigatÛrio!")
                        Else
                            oCorrente.cssClass = ""
                        End If
                    End If

                    yLaco = yLaco + 1
                Loop

            Catch ex As CampoObrigatorioException
                Throw ex
            Catch ex As Exception
                Throw New Exception(ex.ToString)
            End Try
        End Sub

        Public Shared Function ListarEstados() As DataTable

            Dim ds As New DataSet
            strSql = "SELECT * FROM EB99ESTADO ORDER BY EB99SIGLA"

            Try

                adpt = DaoFactory.GetDataAdapter
                cmd = DaoFactory.GetConnection.CreateCommand
                cmd.CommandText = strSql
                adpt.SelectCommand = cmd
                adpt.Fill(ds)

                Return ds.Tables(0)

            Catch ex As OleDbException
                Throw New DAOException(ex.Message)
            End Try

        End Function

        Public Shared Function ListarCidades(ByVal UF As Int16) As DataTable

            Dim ds As New DataSet
            strSql = "SELECT * FROM EB98CIDADE WHERE FK9899ESTADO = " & UF
            strSql += " ORDER BY EB98NOME "

            Try

                adpt = DaoFactory.GetDataAdapter
                cmd = DaoFactory.GetConnection.CreateCommand
                cmd.CommandText = strSql
                adpt.SelectCommand = cmd
                adpt.Fill(ds)

                Return ds.Tables(0)

            Catch ex As OleDbException
                Throw New DAOException(ex.Message)
            End Try

        End Function

        Public Shared Sub CarregarEstados(ByRef ComboUF As DropDownList)

            Dim ds As New DataSet
            strSql = "  SELECT * FROM EC14ESTADOS "
            strSql += " ORDER BY EC14SIGLA"

            Try

                'adpt = DaoFactory.GetDataAdapter
                cmd = DaoFactory.GetConnection.CreateCommand
                cmd.CommandText = strSql
                adpt.SelectCommand = cmd
                adpt.Fill(ds)

                ComboUF.DataSource = ds.Tables(0)
                ComboUF.DataTextField = "EC14SIGLA"
                ComboUF.DataValueField = "EC14ID"
                ComboUF.DataBind()

            Catch ex As MySqlException
                Throw New DAOException(ex.Message)
            End Try

        End Sub

        Public Shared Sub CarregarCidades(ByRef ComboCID As DropDownList, ByVal CODUF As Integer)

            Dim ds As New DataSet
            strSql = "  SELECT * FROM EC15CIDADE "
            strSql += "  WHERE FK1514UF = " & CODUF
            strSql += "  ORDER BY EC15NOMECID "

            Try

                'adpt = DaoFactory.GetDataAdapter
                cmd = DaoFactory.GetConnection.CreateCommand
                cmd.CommandText = strSql
                adpt.SelectCommand = cmd
                adpt.Fill(ds)

                ComboCID.DataSource = ds.Tables(0)
                ComboCID.DataTextField = "EC15NOMECID"
                ComboCID.DataValueField = "EC15CODIGO"
                ComboCID.DataBind()

            Catch ex As MySqlException
                Throw New DAOException(ex.Message)
            End Try

        End Sub

        Public Shared Function listarBancos() As DataTable
            Dim ds As New DataSet

            strSql = "  SELECT *, CONCAT(AC04CODBANCO,' - ', AC04NOME) COMPLETO"
            strSql += "   FROM ac04banco "
            strSql += "        ORDER BY AC04NOME "

            Try
                adpt = DaoFactory.GetDataAdapter
                cmd = DaoFactory.GetConnection.CreateCommand
                cmd.CommandText = strSql
                adpt.SelectCommand = cmd
                adpt.Fill(ds)

                Return ds.Tables(0)

            Catch ex As MySqlException
                Throw New DAOException(ex.Message)
            End Try

        End Function

        Public Shared Function ListarConstante(ByVal Tabela As String, ByVal Item As Integer) As Constante
            Dim c As Constante

            strSql = "  SELECT * FROM AC99CONST "
            strSql += "  WHERE 2=2 "
            strSql += "    AND AC99TABELA LIKE '" & Tabela & "' "
            strSql += "    AND AC99ITEM = " & Item

            Try
                adpt = DaoFactory.GetDataAdapter
                cmd = DaoFactory.GetConnection.CreateCommand
                cmd.CommandText = strSql
                dr = cmd.ExecuteReader

                c = New Constante
                While dr.Read
                    c.Item = dr.Item("AC99ITEM").ToString
                    c.ItemDescricao = dr.Item("CL92ITEMDESC").ToString
                    c.ItemComentario = dr.Item("CL92ITEMCOMENT").ToString

                End While

                dr.Close()

                Return c
            Catch ex As OleDbException
                Throw New DAOException(ex.Message)
            Catch ex As Exception
                Throw ex
            End Try

        End Function

        Public Shared Function ListarConstante(ByVal Tabela As String) As List(Of Constante)
            Dim C As Constante
            Dim lC As New List(Of Constante)

            strSql = "  SELECT * FROM AC99CONST "
            strSql += "  WHERE 2=2 "
            strSql += "    AND AC99TABELA LIKE '" & Tabela & "' "

            Try
                adpt = DaoFactory.GetDataAdapter
                cmd = DaoFactory.GetConnection.CreateCommand
                cmd.CommandText = strSql
                dr = cmd.ExecuteReader

                While dr.Read
                    C = New Constante
                    C.Item = dr.Item("AC99ITEM").ToString
                    C.ItemDescricao = dr.Item("AC99ITEMDESC").ToString
                    C.ItemComentario = dr.Item("AC99COMPLE").ToString

                    lC.Add(C)
                End While

                dr.Close()

                Return lC
            Catch ex As OleDbException
                Throw New DAOException(ex.Message)
            Catch ex As Exception
                Throw ex
            End Try

        End Function

#End Region

#Region "MASCARAS"

        Public Enum FormatoData
            DDMMAAAA = 0
            DDMMAA = 1
            'todo: Criar Mascaras para outros formatos de datas e horas
            'MMAAAA = 2
            'DDMMAAAA_HHMMSS = 3
            'DDMMAAAA_HHMM = 4
            'HHMMSS = 5
            'HHMM = 6
        End Enum

        Public Shared Sub MascaraData(ByVal Formato As FormatoData, ByVal Campo As TextBox, ByVal Pagina As Page)

            Dim strMontaMensagem
            Try
                If (Not Pagina.ClientScript.IsClientScriptBlockRegistered("Mascara" & Campo.ID)) Then
                    strMontaMensagem = "<script language='JavaScript'> "
                    strMontaMensagem &= "function MascaraData" & Formato.ToString & "(objeto)"
                    strMontaMensagem &= "{ "
                    strMontaMensagem &= "campo = eval (objeto); "
                    strMontaMensagem &= "conjunto1 = 2; "
                    strMontaMensagem &= "separador = '/'; "
                    Select Case Formato
                        Case FormatoData.DDMMAA
                            strMontaMensagem &= "conjunto2 = 1; "
                            strMontaMensagem &= "maximo = 8; "
                        Case FormatoData.DDMMAAAA
                            strMontaMensagem &= "conjunto2 = 2; "
                            strMontaMensagem &= "maximo = 10; "
                    End Select

                    strMontaMensagem &= "conjunto2 = 5; "
                    strMontaMensagem &= "if (window.event.keyCode >= 48 && window.event.keyCode <= 57 && campo.value.length < maximo) "
                    strMontaMensagem &= "{ "
                    strMontaMensagem &= "if (campo.value.length == conjunto1) "
                    strMontaMensagem &= "{ "
                    strMontaMensagem &= "  campo.value = campo.value + separador; "
                    strMontaMensagem &= "} "
                    strMontaMensagem &= "if (campo.value.length == conjunto2) "
                    strMontaMensagem &= "{ "
                    strMontaMensagem &= "  campo.value = campo.value + separador; "
                    strMontaMensagem &= "} "
                    strMontaMensagem &= "} "
                    strMontaMensagem &= "else "
                    strMontaMensagem &= "{ "
                    strMontaMensagem &= "window.event.keyCode = 0; "
                    strMontaMensagem &= "} "
                    strMontaMensagem &= "} "
                    strMontaMensagem &= "</script>"
                    Pagina.ClientScript.RegisterClientScriptBlock(GetType(String), "Mascara" & Campo.ID, strMontaMensagem)
                    Campo.Attributes("onKeyPress") = "javascript:MascaraData" & Formato.ToString & "(this)"
                End If
            Catch ex As Exception
                Throw New Exception(ex.ToString)
            End Try
        End Sub

        Public Shared Sub MascaraTelefone(ByVal Campo As TextBox, ByVal Pagina As Page)

            Dim strMontaMensagem As String
            Try
                If (Not Pagina.ClientScript.IsClientScriptBlockRegistered("Mascara" & Campo.ID)) Then
                    strMontaMensagem = "<script language='JavaScript'> "
                    strMontaMensagem &= "function MascaraTelefone(objeto)"
                    strMontaMensagem &= "{ "
                    strMontaMensagem &= "campo = eval (objeto); "
                    strMontaMensagem &= "conjunto1 = 1; "
                    strMontaMensagem &= "conjunto2 = 3; "
                    strMontaMensagem &= "conjunto3 = 8; "
                    strMontaMensagem &= "separador1 = '('; "
                    strMontaMensagem &= "separador2 = ')'; "
                    strMontaMensagem &= "separador3 = '-'; "
                    strMontaMensagem &= "maximo = 13; "
                    strMontaMensagem &= "if (window.event.keyCode >= 48 && window.event.keyCode <= 57 && campo.value.length < maximo) "
                    strMontaMensagem &= "{ "
                    strMontaMensagem &= "if (campo.value.length == conjunto1) "
                    strMontaMensagem &= "{ "
                    strMontaMensagem &= "  campo.value = separador1 + campo.value "
                    strMontaMensagem &= "} "
                    strMontaMensagem &= "if (campo.value.length == conjunto2) "
                    strMontaMensagem &= "{ "
                    strMontaMensagem &= "  campo.value = campo.value + separador2; "
                    strMontaMensagem &= "} "
                    strMontaMensagem &= "if (campo.value.length == conjunto3) "
                    strMontaMensagem &= "{ "
                    strMontaMensagem &= "  campo.value = campo.value + separador3; "
                    strMontaMensagem &= "} "
                    strMontaMensagem &= "} "
                    strMontaMensagem &= "else "
                    strMontaMensagem &= "{ "
                    strMontaMensagem &= "window.event.keyCode = 0; "
                    strMontaMensagem &= "} "
                    strMontaMensagem &= "} "
                    strMontaMensagem &= "</script>"
                    Pagina.ClientScript.RegisterClientScriptBlock(GetType(String), "Mascara" & Campo.ID, strMontaMensagem)
                    Campo.Attributes("onKeyPress") = "javascript:MascaraTelefone(this)"
                End If
            Catch ex As Exception
                Throw New Exception(ex.ToString)
            End Try
        End Sub

        Public Shared Sub MascaraCPF(ByVal Campo As TextBox, ByVal Pagina As Page)

            Dim strMontaMensagem As String

            Try
                If (Not Pagina.ClientScript.IsClientScriptBlockRegistered("Mascara" & Campo.ID)) Then
                    strMontaMensagem = "<script language='JavaScript'> "
                    strMontaMensagem += " function FormataCpf(campo){"
                    strMontaMensagem += " var tecla = window.event.keyCode;"
                    strMontaMensagem += " var vr = new String(campo.value);"
                    strMontaMensagem += " vr = vr.replace('.', '');"
                    strMontaMensagem += " vr = vr.replace(' / ', '');"
                    strMontaMensagem += " vr = vr.replace(' - ', '');"
                    strMontaMensagem += " tam = vr.length + 1;"
                    strMontaMensagem += " if (tecla != 14){"
                    strMontaMensagem += " if (tam == 4) "
                    strMontaMensagem += " campo.value = vr.substr(0, 3) + '.'; else "
                    strMontaMensagem += " if (tam == 7) "
                    strMontaMensagem += " campo.value = vr.substr(0, 3) + '.' + vr.substr(3, 6) + '.'; else "
                    strMontaMensagem += " if (tam == 11) "
                    strMontaMensagem += " campo.value = vr.substr(0, 3) + '.' + vr.substr(3, 3) + '.' + vr.substr(7, 3) + '-' + vr.substr(11, 2); else "
                    strMontaMensagem += " if (tam >= 14) "
                    strMontaMensagem += " window.event.keyCode=0;} }"
                    strMontaMensagem &= "</script>"
                    Pagina.ClientScript.RegisterClientScriptBlock(GetType(String), "Mascara" & Campo.ID, strMontaMensagem)
                    Campo.Attributes("onKeyPress") = "javascript:FormataCpf(this)"
                End If
            Catch ex As Exception
                Throw New Exception(ex.ToString)
            End Try

        End Sub

        Public Shared Sub MascaraCEP(ByVal Campo As TextBox, ByVal Pagina As Page)

            Dim strMontaMensagem As String
            Try
                If (Not Pagina.ClientScript.IsClientScriptBlockRegistered("Mascara" & Campo.ID)) Then
                    strMontaMensagem = "<script language='JavaScript'> "
                    strMontaMensagem &= "function MascaraCEP(objeto)"
                    strMontaMensagem &= "{ "
                    strMontaMensagem &= "campo = eval (objeto); "
                    strMontaMensagem &= "conjunto1 = 5; "
                    strMontaMensagem &= "separador = '-'; "
                    strMontaMensagem &= "maximo = 9; "
                    strMontaMensagem &= "if (window.event.keyCode >= 48 && window.event.keyCode <= 57 && campo.value.length < maximo) "
                    strMontaMensagem &= "{ "
                    strMontaMensagem &= "if (campo.value.length == conjunto1) "
                    strMontaMensagem &= "{ "
                    strMontaMensagem &= "  campo.value = campo.value + separador"
                    strMontaMensagem &= "} "
                    strMontaMensagem &= "} "
                    strMontaMensagem &= "else "
                    strMontaMensagem &= "{ "
                    strMontaMensagem &= "window.event.keyCode = 0; "
                    strMontaMensagem &= "} "
                    strMontaMensagem &= "} "
                    strMontaMensagem &= "</script>"
                    Pagina.ClientScript.RegisterClientScriptBlock(GetType(String), "Mascara" & Campo.ID, strMontaMensagem)
                    Campo.Attributes("onKeyPress") = "javascript:MascaraCEP(this)"
                End If
            Catch ex As Exception
                Throw New Exception(ex.ToString)
            End Try
        End Sub

#End Region

    End Class

End Namespace