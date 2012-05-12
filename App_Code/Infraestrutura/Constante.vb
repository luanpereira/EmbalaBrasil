Imports Microsoft.VisualBasic

Namespace Camadas.Dominio

    ''' <summary>
    ''' Classe que representa os dados da tabela constante na base de dados.
    ''' </summary>
    ''' 
    Public Class Constante
        Private _tabela As String
        Private _item As Integer
        Private _itemDescricao As String
        Private _itemComentario As String
        'Private _observacao As String
        'Private _complemento As String

        ''' <summary>
        ''' Nome da constante.
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Tabela() As String
            Get
                Return _tabela
            End Get
            Set(ByVal value As String)
                _tabela = value
            End Set
        End Property

        ''' <summary>
        ''' Código do item da constante.
        ''' </summary>
        ''' <remarks></remarks>
        Public Property Item() As Integer
            Get
                Return _item
            End Get
            Set(ByVal value As Integer)
                _item = value
            End Set
        End Property

        ''' <summary>
        ''' Descrição do item.
        ''' </summary>
        ''' <remarks></remarks>
        Public Property ItemDescricao() As String
            Get
                Return _itemDescricao
            End Get
            Set(ByVal value As String)
                _itemDescricao = value
            End Set
        End Property

        ''' <summary>
        ''' Campo para demais informações 1.
        ''' </summary>
        ''' <remarks></remarks>
        Public Property ItemComentario() As String
            Get
                Return _itemComentario
            End Get
            Set(ByVal value As String)
                _itemComentario = value
            End Set
        End Property

        '''' <summary>
        '''' Campo para demais informações 2.
        '''' </summary>
        '''' <remarks></remarks>
        'Public Property Observacao() As String
        '    Get
        '        Return _observacao
        '    End Get
        '    Set(ByVal value As String)
        '        _observacao = value
        '    End Set
        'End Property

        '''' <summary>
        '''' Campo para demais informações 3.
        '''' </summary>
        '''' <remarks></remarks>
        'Public Property Complemento() As String
        '    Get
        '        Return _complemento
        '    End Get
        '    Set(ByVal value As String)
        '        _complemento = value
        '    End Set
        'End Property
    End Class

End Namespace