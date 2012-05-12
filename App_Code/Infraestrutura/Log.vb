Public Class Log

    Private _usuario As Usuario
    Private _tabela As String
    Private _operacao As String
    Private _tela As String
    Private _descricao As String
    Private _data As String

    Public Property Usuario() As Usuario
        Get
            Return _usuario
        End Get
        Set(ByVal value As Usuario)
            _usuario = value
        End Set
    End Property

    Public Property Tabela() As String
        Get
            Return _tabela
        End Get
        Set(ByVal value As String)
            _tabela = value
        End Set
    End Property

    Public Property Operacao() As String
        Get
            Return _operacao
        End Get
        Set(ByVal value As String)
            _operacao = value
        End Set
    End Property

    Public Property Tela() As String
        Get
            Return _tela
        End Get
        Set(ByVal value As String)
            _tela = value
        End Set
    End Property

    Public Property Descricao() As String
        Get
            Return _descricao
        End Get
        Set(ByVal value As String)
            _descricao = value
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

End Class
