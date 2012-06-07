Imports Microsoft.VisualBasic
Imports Camadas.Dominio.Administrativo
Imports System.Data

Public Interface IVendedorController
    Sub cadastrarVendedor(ByVal vendedor As Vendedor)
    Function listarVendedor(ByVal v As Vendedor) As DataTable
End Interface
