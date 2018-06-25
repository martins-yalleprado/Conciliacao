Imports System.Collections.Generic
Imports System.Linq
Imports System.Web

Namespace Model
    Public Class MovimentoTituloModel
        Public Property numSeqCarga() As Integer
            Get
                Return m_numSeqCarga
            End Get
            Set
                m_numSeqCarga = Value
            End Set
        End Property
        Private m_numSeqCarga As Integer

        Public Property codUndNgc() As Integer
            Get
                Return m_codUndNgc
            End Get
            Set
                m_codUndNgc = Value
            End Set
        End Property
        Private m_codUndNgc As Integer

        Public Property dataMovimentacao() As Date
            Get
                Return m_dataMovimentacao
            End Get
            Set
                m_dataMovimentacao = Value
            End Set
        End Property
        Private m_dataMovimentacao As Date

        Public Property codTipoMovTitulo() As Integer
            Get
                Return m_codTipoMovTitulo
            End Get
            Set
                m_codTipoMovTitulo = Value
            End Set
        End Property
        Private m_codTipoMovTitulo As Integer

        Public Property codFormaPagamento() As Integer
            Get
                Return m_codFormaPagamento
            End Get
            Set
                m_codFormaPagamento = Value
            End Set
        End Property
        Private m_codFormaPagamento As Integer

        Public Property codPropTitulo() As Char
            Get
                Return m_codPropTitulo
            End Get
            Set
                m_codPropTitulo = Value
            End Set
        End Property
        Private m_codPropTitulo As Char

        Public Property codResponsavelRisco() As Char
            Get
                Return m_codResponsavelRisco
            End Get
            Set
                m_codResponsavelRisco = Value
            End Set
        End Property
        Private m_codResponsavelRisco As Char

        Public Property codOrigemPedido() As Char
            Get
                Return m_codOrigemPedido
            End Get
            Set
                m_codOrigemPedido = Value
            End Set
        End Property
        Private m_codOrigemPedido As Char

        Public Property codEmitenteTitulo() As Char
            Get
                Return m_codEmitenteTitulo
            End Get
            Set
                m_codEmitenteTitulo = Value
            End Set
        End Property
        Private m_codEmitenteTitulo As Char

        Public Property tipoCheque() As Char
            Get
                Return m_tipoCheque
            End Get
            Set
                m_tipoCheque = Value
            End Set
        End Property
        Private m_tipoCheque As Char

        Public Property codSituacaoVendor() As Char
            Get
                Return m_codSituacaoVendor
            End Get
            Set
                m_codSituacaoVendor = Value
            End Set
        End Property
        Private m_codSituacaoVendor As Char

        Public Property codSituacaoVencimento() As Char
            Get
                Return m_codSituacaoVencimento
            End Get
            Set
                m_codSituacaoVencimento = Value
            End Set
        End Property
        Private m_codSituacaoVencimento As Char

        Public Property codOrgaoFiscal() As Char
            Get
                Return m_codOrgaoFiscal
            End Get
            Set
                m_codOrgaoFiscal = Value
            End Set
        End Property
        Private m_codOrgaoFiscal As Char

        Public Property valorMov() As Decimal
            Get
                Return m_valorMov
            End Get
            Set
                m_valorMov = Value
            End Set
        End Property
        Private m_valorMov As Decimal

        Public Property dataGeracaoMovimento() As DateTime
            Get
                Return m_dataGeracaoMovimento
            End Get
            Set
                m_dataGeracaoMovimento = Value
            End Set
        End Property
        Private m_dataGeracaoMovimento As DateTime

        Public Property flagAtivo() As Char
            Get
                Return m_flagAtivo
            End Get
            Set
                m_flagAtivo = Value
            End Set
        End Property
        Private m_flagAtivo As Char

        Public Property codTipoCobranca() As Char
            Get
                Return m_codTipoCobranca
            End Get
            Set
                m_codTipoCobranca = Value
            End Set
        End Property
        Private m_codTipoCobranca As Char

        Public Property flagAtivoLabel() As String
            Get
                Return m_flagAtivoLabel
            End Get
            Set
                m_flagAtivoLabel = Value
            End Set
        End Property
        Private m_flagAtivoLabel As String
    End Class
End Namespace
