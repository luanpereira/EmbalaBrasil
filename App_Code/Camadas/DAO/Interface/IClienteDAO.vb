Imports Microsoft.VisualBasic
Imports Camadas.Dominio.Administrativo
Imports System.Data

Public Interface IClienteDAO
    Function cadastrarClientePessoaFisica(ByVal cliente As Cliente) As Integer
    Function cadastrarClientePessoaJuridica(ByVal cliente As Cliente) As Integer
    Function listarCliente() As DataTable
    Function listarCliente(ByVal cliente As Cliente) As DataTable
End Interface
