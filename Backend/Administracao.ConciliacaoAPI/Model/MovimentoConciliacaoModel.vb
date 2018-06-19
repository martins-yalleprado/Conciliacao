Namespace Model
  Public Class MovimentoConciliacaoModel
    Private m_CodEmitenteTitulo As String
    Private m_CodFormaPagamento As Integer
    Private m_CodSituacaoTituloOrgaoFiscal As String
    Private m_CodOrigemPedido As String
    Private m_CodProprietarioTitulo As String
    Private m_CodResponsavelRiscoCredito As String
    Private m_TipoCheque As String
    Private m_CodSituacaoTituloVendor As String
    Private m_CodSituacaoVencimentoTitulo As String
    Private m_CodTipoCobranca As String
    Private m_CodTipoMovimentacaoTituloReceber As Integer
    Private m_MarcacaoRegistroMovimentoConciliacao As String
    Private m_CodMovimentoConciliacao As Integer
    Private m_CodIdentidadeContabil As Integer
    Private m_DesFormaPagamento As String
    Private m_DesTipoMovimento As String
    Public Property CodSituacaoTituloOrgaoFiscal As String
      Get
        Return m_CodSituacaoTituloOrgaoFiscal
      End Get
      Set(value As String)
        m_CodSituacaoTituloOrgaoFiscal = value
      End Set
    End Property

    Public Property CodOrigemPedido As String
      Get
        Return m_CodOrigemPedido
      End Get
      Set(value As String)
        m_CodOrigemPedido = value
      End Set
    End Property

    Public Property CodProprietarioTitulo As String
      Get
        Return m_CodProprietarioTitulo
      End Get
      Set(value As String)
        m_CodProprietarioTitulo = value
      End Set
    End Property

    Public Property CodResponsavelRiscoCredito As String
      Get
        Return m_CodResponsavelRiscoCredito
      End Get
      Set(value As String)
        m_CodResponsavelRiscoCredito = value
      End Set
    End Property

    Public Property TipoCheque As String
      Get
        Return m_TipoCheque
      End Get
      Set(value As String)
        m_TipoCheque = value
      End Set
    End Property

    Public Property CodSituacaoTituloVendor As String
      Get
        Return m_CodSituacaoTituloVendor
      End Get
      Set(value As String)
        m_CodSituacaoTituloVendor = value
      End Set
    End Property

    Public Property CodSituacaoVencimentoTitulo As String
      Get
        Return m_CodSituacaoVencimentoTitulo
      End Get
      Set(value As String)
        m_CodSituacaoVencimentoTitulo = value
      End Set
    End Property

    Public Property CodTipoCobranca As String
      Get
        Return m_CodTipoCobranca
      End Get
      Set(value As String)
        m_CodTipoCobranca = value
      End Set
    End Property



    Public Property MarcacaoRegistroMovimentoConciliacao As String
      Get
        Return m_MarcacaoRegistroMovimentoConciliacao
      End Get
      Set(value As String)
        m_MarcacaoRegistroMovimentoConciliacao = value
      End Set
    End Property

    Public Property CodMovimentoConciliacao As Integer
      Get
        Return m_CodMovimentoConciliacao
      End Get
      Set(value As Integer)
        m_CodMovimentoConciliacao = value
      End Set
    End Property

    Public Property CodEmitenteTitulo As String
      Get
        Return m_CodEmitenteTitulo
      End Get
      Set(value As String)
        m_CodEmitenteTitulo = value
      End Set
    End Property

    Public Property CodFormaPagamento As Integer
      Get
        Return m_CodFormaPagamento
      End Get
      Set(value As Integer)
        m_CodFormaPagamento = value
      End Set
    End Property

    Public Property CodTipoMovimentacaoTituloReceber As Integer
      Get
        Return m_CodTipoMovimentacaoTituloReceber
      End Get
      Set(value As Integer)
        m_CodTipoMovimentacaoTituloReceber = value
      End Set
    End Property

    Public Property DesTipoMovimento As String
      Get
        Return m_DesTipoMovimento
      End Get
      Set(value As String)
        m_DesTipoMovimento = value
      End Set
    End Property

    Public Property DesFormaPagamento As String
      Get
        Return m_DesFormaPagamento
      End Get
      Set(value As String)
        m_DesFormaPagamento = value
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
  End Class
End Namespace
