Imports System.Collections.Generic


Namespace Model
  Public Class GestaoCargaModel
    Public Property codGestaoCarga() As Integer
      Get
        Return m_codGestaoCarga
      End Get
      Set
        m_codGestaoCarga = Value
      End Set
    End Property
    Private m_codGestaoCarga As Integer
    Public Property data() As DateTime
      Get
        Return m_data
      End Get
      Set
        m_data = Value
      End Set
    End Property
    Private m_data As DateTime
    Public Property dataMovimentacao() As DateTime
      Get
        Return m_dataMovimentacao
      End Get
      Set
        m_dataMovimentacao = Value
      End Set
    End Property
    Private m_dataMovimentacao As DateTime
    Public Property tipo() As String
      Get
        Return m_tipo
      End Get
      Set
        m_tipo = Value
      End Set
    End Property
    Private m_tipo As String
    Public Property versao() As Integer
      Get
        Return m_versao
      End Get
      Set
        m_versao = Value
      End Set
    End Property
    Private m_versao As Integer
    Public Property versaoOficial() As String
      Get
        Return m_versaoOficial
      End Get
      Set
        m_versaoOficial = Value
      End Set
    End Property
    Private m_versaoOficial As String
    Public Property valor() As Single
      Get
        Return m_valor
      End Get
      Set
        m_valor = Value
      End Set
    End Property
    Private m_valor As Single
    Public Property versaoOficialLabel() As String
      Get
        Return m_versaoOficialLabel
      End Get
      Set
        m_versaoOficialLabel = Value
      End Set
    End Property
    Private m_versaoOficialLabel As String
    Public Property quantidade() As Integer
      Get
        Return m_Quantidade
      End Get
      Set
        m_Quantidade = Value
      End Set
    End Property
    Private m_Quantidade As Integer
    Public Property codUnidade() As Integer
      Get
        Return m_codUnidade
      End Get
      Set
        m_codUnidade = Value
      End Set
    End Property
    Private m_codUnidade As Integer
  End Class
End Namespace
