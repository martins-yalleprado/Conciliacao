Public Class RelatorioAgingModel

    Private m_de As String
    Public Property De As String
        Get
            Return m_de
        End Get
        Set(ByVal value As String)
            m_de = value
        End Set
    End Property
    Private m_ate As String
    Public Property Ate As String
        Get
            Return m_ate
        End Get
        Set(ByVal value As String)
            m_ate = value
        End Set
    End Property
    Private m_quantidade As String
    Public Property Quantidade As String
        Get
            Return m_quantidade
        End Get
        Set(ByVal value As String)
            m_quantidade = value
        End Set
    End Property
    Private m_valorAberto As String
    Public Property ValorAberto As String
        Get
            Return m_valorAberto
        End Get
        Set(ByVal value As String)
            m_valorAberto = value
        End Set
    End Property
    Private m_acumuladoVencido As String
    Public Property AcumuladoVencido As String
        Get
            Return m_acumuladoVencido
        End Get
        Set(ByVal value As String)
            m_acumuladoVencido = value
        End Set
    End Property
    Private m_acumuladoEsperado As String
    Public Property AcumuladoEsperado As String
        Get
            Return m_acumuladoEsperado
        End Get
        Set(ByVal value As String)
            m_acumuladoEsperado = value
        End Set
    End Property

End Class
