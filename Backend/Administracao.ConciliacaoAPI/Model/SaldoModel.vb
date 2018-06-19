Namespace Model
  Public Class SaldoModel
    Private m_CodConta As Integer
    Private m_CodUnidade As Integer
    Private m_DataMovimentacao As DateTime
    Private m_VlrSaldoContabil As Decimal
    Private m_VlrSaldoCobranca As Decimal
    Private m_VlrSaldoContabilInf As Decimal
    Private m_VlrSaldoCobrancaInf As Decimal

    Public Property CodConta As Integer
      Get
        Return m_CodConta
      End Get
      Set(value As Integer)
        m_CodConta = value
      End Set
    End Property

    Public Property CodUnidade As Integer
      Get
        Return m_CodUnidade
      End Get
      Set(value As Integer)
        m_CodUnidade = value
      End Set
    End Property

    Public Property DataMovimentacao As Date
      Get
        Return m_DataMovimentacao
      End Get
      Set(value As Date)
        m_DataMovimentacao = value
      End Set
    End Property

    Public Property VlrSaldoContabil As Decimal
      Get
        Return m_VlrSaldoContabil
      End Get
      Set(value As Decimal)
        m_VlrSaldoContabil = value
      End Set
    End Property

    Public Property VlrSaldoCobranca As Decimal
      Get
        Return m_VlrSaldoCobranca
      End Get
      Set(value As Decimal)
        m_VlrSaldoCobranca = value
      End Set
    End Property

    Public Property VlrSaldoContabilInf As Decimal
      Get
        Return m_VlrSaldoContabilInf
      End Get
      Set(value As Decimal)
        m_VlrSaldoContabilInf = value
      End Set
    End Property

    Public Property VlrSaldoCobrancaInf As Decimal
      Get
        Return m_VlrSaldoCobrancaInf
      End Get
      Set(value As Decimal)
        m_VlrSaldoCobrancaInf = value
      End Set
    End Property
  End Class
End Namespace
