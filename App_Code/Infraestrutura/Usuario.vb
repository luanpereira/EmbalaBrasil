
Imports System.Collections.Generic
Imports Camadas.Dominio
Imports Seguranca
Imports Camadas.Dominio.Administrativo
Imports Infraestrutura.Utils

Public Class Usuario

    Public Property Codigo() As Integer
    Public Property Usuario() As String
    Public Property Senha() As String
    Public Property Nome() As String
    Public Property Vendedor() As New Vendedor
    Public Property Cliente() As New Cliente
    Public Property AcessoWeb() As Boolean
    Public Property NivelAcesso() As String
    Public Property UltimoAcesso() As String
    Public Property Tipo() As eTipo


End Class
