Imports System.Net.Http
Imports Administracao.ConciliacaoAPI

Public Class ResultModel
  Private m_ErroModel As ErroModel
  Private m_Data As Object
  Public Sub New(ByVal data As Object, ByVal ErroModel As ErroModel)
    m_ErroModel = ErroModel
    m_Data = data
  End Sub
  Public Sub New(ByVal data As Object)
    m_Data = data
    m_ErroModel = New ErroModel("Operacao Concluida com sucesso", True)
  End Sub

  Public Property ErroModel As ErroModel
    Get
      Return m_ErroModel
    End Get
    Set(value As ErroModel)
      m_ErroModel = value
    End Set
  End Property

  Public Property Data As Object
    Get
      Return m_Data
    End Get
    Set(value As Object)
      m_Data = value
    End Set
  End Property

    Public Shared Widening Operator CType(v As ResultModel) As HttpResponseMessage
        Throw New NotImplementedException()
    End Operator
End Class
