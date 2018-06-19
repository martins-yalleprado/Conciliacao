Public Class ErroModel
  Private m_ErroMensagem As String
  Private m_sucesso As Boolean

  Public Sub New(Mensagem As String, Optional sucesso As Boolean = False)

    m_ErroMensagem = Mensagem
    m_sucesso = sucesso
  End Sub
  Public Sub New(Mensagem As String)

    m_ErroMensagem = Mensagem
  End Sub
  Public Property ErroMensagem As String
    Get
      Return m_ErroMensagem
    End Get
    Set(value As String)
      m_ErroMensagem = value
    End Set
  End Property

  Public Property Sucesso As Boolean
    Get
      Return m_sucesso
    End Get
    Set(value As Boolean)
      m_sucesso = value
    End Set
  End Property
End Class
