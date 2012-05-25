Imports Microsoft.VisualBasic

Namespace Camadas.Dominio.Administrativo

    Public Class Cidade
        Public Property Codigo() As Integer
        Public Property Nome() As String
        Public Property Estado() As New Estado
    End Class

End Namespace
