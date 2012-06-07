Imports Microsoft.VisualBasic
Imports Camadas.Dominio.Administrativo
Imports System.Data

Public Interface IVendedorDAO
    Function cadastrarVendedor(ByVal vendedor As Vendedor) As Integer
    Sub atualizarVendedor(ByVal vendedor As Vendedor)

    Function listarVendedor(ByVal vendedor As Vendedor) As DataTable
End Interface
