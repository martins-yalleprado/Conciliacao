Imports Martins.Conciliacao.Model

Namespace Code.GestaoCarga
  Public Class GestaoCargaBLL
    Public Function selectGestaoCargaPorId(id As Integer) As GestaoCargaModel
      Try
        Dim DAL As New GestaoCargaDAL()
        Return DAL.selectGestaoCargaPorId(id)
      Catch e As Exception
        Throw e
      End Try
    End Function
    Public Function selectGestaoCarga(dataRef As DateTime, tipo As [String]) As List(Of GestaoCargaModel)
      Try
        Dim DAL As New GestaoCargaDAL()
        Dim list As List(Of GestaoCargaModel) = DAL.selectGestaoCarga(dataRef, tipo)
        Return list
      Catch e As Exception
        Throw e
      End Try
    End Function


    Public Sub deleteGestaoCarga(id As Integer)
      Try
        Dim DAL As New GestaoCargaDAL()

        DAL.deleteGestaoCarga(id)
      Catch e As Exception
        Throw e
      End Try
    End Sub

    Public Sub updateGestaoCarga(gestaoCargaModel As GestaoCargaModel)
      Dim DAL As New GestaoCargaDAL()
      DAL.atualizarVersao(gestaoCargaModel)
    End Sub

    Public Sub insertGestaoCarga(dataRef As DateTime, tipo As String, codUnidade As Integer)
      Try
        Dim DAL As New GestaoCargaDAL()

        DAL.insertGestaoCarga(dataRef, tipo, codUnidade)
      Catch e As Exception
        Throw e
      End Try
    End Sub
  End Class

End Namespace

