Imports Martins.Conciliacao.Model

Namespace Code.Intervalo
  Public Class IntervaloBLL

    Public Function selectIntervaloPorId(id As Integer) As IntervaloModel
      Try
        Dim DAL As New IntervaloDAL()
        Return DAL.selectIntervaloPorId(id)
      Catch e As Exception
        Throw e
      End Try
    End Function
    Public Function selectIntervalo(periodo As Integer) As List(Of IntervaloModel)
      Try
        Dim DAL As New IntervaloDAL()
        Dim list As List(Of IntervaloModel) = DAL.selectIntervalo(periodo)
        Return list
      Catch e As Exception
        Throw e
      End Try
    End Function


    Public Sub deleteIntervalo(id As Integer)
      Try
        Dim DAL As New IntervaloDAL()

        DAL.deleteIntervalo(id)
      Catch e As Exception
        Throw e
      End Try
    End Sub

    Public Sub updateIntervalo(intervalo As IntervaloModel)
      Try
        Dim DAL As New IntervaloDAL()

        DAL.updateIntervalo(intervalo)
      Catch e As Exception
        Throw e
      End Try
    End Sub

    Public Sub insertIntervalo(intervalo As IntervaloModel)
      Try
        Dim DAL As New IntervaloDAL()

        DAL.inserirIntervalo(intervalo)
      Catch e As Exception
        Throw e
      End Try

    End Sub
    Public Sub ativarDesativarIntervalo(Intervalo As IntervaloModel)
      Try
        Dim DAL As New IntervaloDAL()
        If Intervalo.situacao.Equals("0") Then
          DAL.ativarIntervalo(Intervalo.codIntervalo)
        Else
          DAL.desativarIntervalo(Intervalo.codIntervalo)
        End If
      Catch e As Exception
        Throw e
      End Try

    End Sub
  End Class
End Namespace
