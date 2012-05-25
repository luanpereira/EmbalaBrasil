Imports Microsoft.VisualBasic
Imports Camadas.DAO
Imports Camadas.Dominio.Administrativo
Imports System.Data

Namespace Camadas.Negocio

    Public Class VendedorController
        Implements IVendedorController


        Public Function listarVendedor() As DataTable Implements IVendedorController.listarVendedor
            Dim dao As IVendedorDAO

            Try

                dao = DaoFactory.GetVendedorDAO
                Return dao.listarVendedor

            Catch ex As Exception
                Throw ex
            End Try
        End Function

    End Class

End Namespace