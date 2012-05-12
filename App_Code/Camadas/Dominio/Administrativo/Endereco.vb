Namespace Camadas.Dominio.Administrativo

    Public Class Endereco

        Public Property Cep() As String

        Public Property Logradouro() As String

        Public Property Bairro() As String

        Public Property Uf() As Short

        Public Property Cidade() As Integer

        Public ReadOnly Property Completo() As String
            Get
                Return _Logradouro & ", " & _Bairro & " " & _Cidade & " " & _Cidade & ", CEP:" & _Cep
            End Get
        End Property


    End Class

End Namespace