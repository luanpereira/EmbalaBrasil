Namespace Camadas.Dominio.Administrativo

    Public Class Endereco

        Public Property Cep() As String

        Public Property Logradouro() As String

        Public Property Bairro() As String

        Public Property Cidade() As New Cidade

        Public ReadOnly Property Completo() As String
            Get
                Return _Logradouro & ", " & _Bairro & " " & _Cidade.Nome & " " & _Cidade.Estado.Nome & ", CEP:" & _Cep
            End Get
        End Property


    End Class

End Namespace