
Imports System.Collections.Generic
Imports Camadas.Dominio
Imports Seguranca

Public Class Usuario

    Private _codigo As Integer
    Private _matricula As String
    Private _senha As String
    Private _usuario As String
    Private _nome As String
    Private _data As String
    Private _funcao As Int32
    Private _ativo As String
    Private _ultimoacesso As String

    Public Property Codigo() As Integer
        Get
            Return _codigo
        End Get
        Set(ByVal value As Integer)
            _codigo = value
        End Set
    End Property

    Public Property Usuario() As String
        Get
            Return _usuario
        End Get
        Set(ByVal value As String)
            _usuario = value
        End Set
    End Property

    Public Property Matricula() As String
        Get
            Return _matricula
        End Get
        Set(ByVal value As String)
            _matricula = value
        End Set
    End Property

    Public Property Senha() As String
        Get
            Return _senha
        End Get
        Set(ByVal value As String)
            '_senha = CriptografarMD5(value)
            _senha = value
        End Set
    End Property

    Public Property Nome() As String
        Get
            Return _nome
        End Get
        Set(ByVal value As String)
            _nome = value
        End Set
    End Property

    Public Property Data() As String
        Get
            Return _data
        End Get
        Set(ByVal value As String)
            _data = value
        End Set
    End Property

    Public Property Funcao() As Int32
        Get
            Return _funcao
        End Get
        Set(ByVal value As Int32)
            _funcao = value
        End Set
    End Property

    Public Property Ativo() As String
        Get
            Return _ativo
        End Get
        Set(ByVal value As String)
            _ativo = value
        End Set
    End Property

    Public Property UltimoAcesso() As String
        Get
            Return _ultimoacesso
        End Get
        Set(ByVal value As String)
            _ultimoacesso = value
        End Set
    End Property

End Class
