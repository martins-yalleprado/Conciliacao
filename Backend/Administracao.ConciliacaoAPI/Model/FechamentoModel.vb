Namespace Model
    Public Class FechamentoModel
        Private m_CodFechamento As Integer
        Private m_DataInicioPeriodo As DateTime
        Private m_DataFimPeriodo As DateTime
        Private m_DataInclusao As DateTime
        Private m_TipoFechamento As String
        Private m_Usuario As String
        Private m_SaldoFechamento As Decimal
        Private m_StatusFechamento As String
        Private m_LabelStatusFechamento As String
        Private m_CodUnidade As Integer
        Private m_CodConta As Integer
        Public Property CodFechamento As Integer
            Get
                Return m_CodFechamento
            End Get
            Set(value As Integer)
                m_CodFechamento = value
            End Set
        End Property

        Public Property DataInicioPeriodo As Date
            Get
                Return m_DataInicioPeriodo
            End Get
            Set(value As Date)
                m_DataInicioPeriodo = value
            End Set
        End Property

        Public Property DataInclusao As Date
            Get
                Return m_DataInclusao
            End Get
            Set(value As Date)
                m_DataInclusao = value
            End Set
        End Property

        Public Property DataFimPeriodo As Date
            Get
                Return m_DataFimPeriodo
            End Get
            Set(value As Date)
                m_DataFimPeriodo = value
            End Set
        End Property

        Public Property TipoFechamento As String
            Get
                Return m_TipoFechamento
            End Get
            Set(value As String)
                m_TipoFechamento = value
            End Set
        End Property

        Public Property Usuario As String
            Get
                Return m_Usuario
            End Get
            Set(value As String)
                m_Usuario = value
            End Set
        End Property

        Public Property SaldoFechamento As Decimal
            Get
                Return m_SaldoFechamento
            End Get
            Set(value As Decimal)
                m_SaldoFechamento = value
            End Set
        End Property

        Public Property StatusFechamento As String
            Get
                Return m_StatusFechamento
            End Get
            Set(value As String)
                m_StatusFechamento = value
            End Set
        End Property

        Public Property LabelStatusFechamento As String
            Get
                Return m_LabelStatusFechamento
            End Get
            Set(value As String)
                m_LabelStatusFechamento = value
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

        Public Property CodConta As Integer
            Get
                Return m_CodConta
            End Get
            Set(value As Integer)
                m_CodConta = value
            End Set
        End Property
    End Class
End Namespace
