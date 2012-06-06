Imports Microsoft.VisualBasic
Imports Camadas.Dominio.Administrativo
Imports System.Data

Public Interface IClienteDAO
    Function cadastrarClientePessoaFisica(ByVal cliente As Cliente) As Integer
    Sub atualizarClientePessoaFisica(ByVal cliente As Cliente)
    Function cadastrarClientePessoaJuridica(ByVal cliente As Cliente) As Integer
    Sub atualizarClientePessoaJuridica(ByVal cliente As Cliente)
    Function listarCliente() As DataTable
    Function listarCliente(ByVal cliente As Cliente) As DataTable
End Interface
