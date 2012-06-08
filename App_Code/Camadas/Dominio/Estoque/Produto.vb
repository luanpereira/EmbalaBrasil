Imports Microsoft.VisualBasic

Namespace Camadas.Dominio.Estoque
    Public Class Produto
        Public Property Codigo() As Integer
        Public Property Nome() As String
        Public Property Sigla() As String
        Public Property Especficicao() As String
        Public Property EstoqueMinimo() As Double
        Public Property Unidade() As Unidade
        Public Property Preco() As Double

        Public Sub New()
            _Unidade = New Unidade
        End Sub
    End Class
End Namespace
