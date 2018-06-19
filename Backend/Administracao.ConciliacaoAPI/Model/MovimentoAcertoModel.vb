Imports System.Collections.Generic
Imports System.Linq
Imports System.Web

Namespace Model
  Public Class MovimentoAcertoModel
    Private m_VlrMovimentoCobranca As Decimal
    Private m_CodIdentidadeContabil As Integer
    Private m_DataMovimento As DateTime
    Private m_NumSequenciaLancamento As Integer
    Private m_VlrMovimentoContabil As Decimal
    Private m_DesAcertoConciliacaoBancaria As String
    Private m_MovimentoContabilModel As MovimentoContabilModel

    Public Property VlrMovimentoCobranca As Decimal
      Get
        Return m_VlrMovimentoCobranca
      End Get
      Set(value As Decimal)
        m_VlrMovimentoCobranca = value
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

    Public Property DataMovimento As Date
      Get
        Return m_DataMovimento
      End Get
      Set(value As Date)
        m_DataMovimento = value
      End Set
    End Property

    Public Property NumSequenciaLancamento As Integer
      Get
        Return m_NumSequenciaLancamento
      End Get
      Set(value As Integer)
        m_NumSequenciaLancamento = value
      End Set
    End Property

    Public Property VlrMovimentoContabil As Decimal
      Get
        Return m_VlrMovimentoContabil
      End Get
      Set(value As Decimal)
        m_VlrMovimentoContabil = value
      End Set
    End Property

    Public Property DesAcertoConciliacaoBancaria As String
      Get
        Return m_DesAcertoConciliacaoBancaria
      End Get
      Set(value As String)
        m_DesAcertoConciliacaoBancaria = value
      End Set
    End Property


    Public Property MovimentoContabilModel As MovimentoContabilModel
      Get
        Return m_MovimentoContabilModel
      End Get
      Set(value As MovimentoContabilModel)
        m_MovimentoContabilModel = value
      End Set
    End Property
  End Class
End Namespace
