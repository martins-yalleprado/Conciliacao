Namespace Model
  Public Class MovimentoContabilModel
    Private m_CodContaContabil As Integer
    Private m_CodEventoContabil As Integer
    Private m_NomSistemaInformacao As String
    Private m_CodFatoContabil As Integer
    Private m_CodUnidadeNegocio As Integer
    Private m_CodIdentidadeContabil As Integer
    Private m_DesEventoContabil As String
    Private m_DesFatoContabil As String

    Public Property CodContaContabil As Integer
      Get
        Return m_CodContaContabil
      End Get
      Set(value As Integer)
        m_CodContaContabil = value
      End Set
    End Property

    Public Property CodEventoContabil As Integer
      Get
        Return m_CodEventoContabil
      End Get
      Set(value As Integer)
        m_CodEventoContabil = value
      End Set
    End Property

    Public Property NomSistemaInformacao As String
      Get
        Return m_NomSistemaInformacao
      End Get
      Set(value As String)
        m_NomSistemaInformacao = value
      End Set
    End Property

    Public Property CodFatoContabil As Integer
      Get
        Return m_CodFatoContabil
      End Get
      Set(value As Integer)
        m_CodFatoContabil = value
      End Set
    End Property

    Public Property CodUnidadeNegocio As Integer
      Get
        Return m_CodUnidadeNegocio
      End Get
      Set(value As Integer)
        m_CodUnidadeNegocio = value
      End Set
    End Property

    Public Property CodIdentidadeContabil As Integer
      Get
        Return m_CodIdentidadeContabil
      End Get
      Set(value As Integer)
        m_CodIdentidadeContabil = value
      End Set
    End Property

    Public Property DesEventoContabil As String
      Get
        Return m_DesEventoContabil
      End Get
      Set(value As String)
        m_DesEventoContabil = value
      End Set
    End Property
    Public Property DesFatoContabil As String
      Get
        Return m_DesFatoContabil
      End Get
      Set(value As String)
        m_DesFatoContabil = value
      End Set
    End Property
  End Class
End Namespace
