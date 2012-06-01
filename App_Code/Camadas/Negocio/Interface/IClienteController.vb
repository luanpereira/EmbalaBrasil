Imports Microsoft.VisualBasic
Imports Camadas.Dominio.Administrativo
Imports System.Data

Public Interface IClienteController
    Sub cadastrarCliente(ByVal cliente As Cliente)
    Function listarCliente() As DataTable
    Function listarCliente(ByVal c As Cliente) As DataTable
End Interface
