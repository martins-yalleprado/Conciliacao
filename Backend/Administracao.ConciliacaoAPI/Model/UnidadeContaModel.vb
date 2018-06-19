Imports System.Collections.Generic
Imports System.Linq
Imports System.Web

Namespace Model
	Public Class UnidadeContaModel
    Private m_CodEmpresa As Integer
    Private m_FLAG As String
    Private m_FlagLabel As String
    Private m_UnidadeModel As UnidadeModel
    Private m_ContaModel As ContaModel
    Public Property FLAG As String
      Get
        Return m_FLAG
      End Get
      Set(value As String)
        m_FLAG = value
      End Set
    End Property

    Public Property FlagLabel As String
      Get
        Return m_FlagLabel
      End Get
      Set(value As String)
        m_FlagLabel = value
      End Set
    End Property

    Public Property UnidadeModel As UnidadeModel
      Get
        Return m_UnidadeModel
      End Get
      Set(value As UnidadeModel)
        m_UnidadeModel = value
      End Set
    End Property

    Public Property ContaModel As ContaModel
      Get
        Return m_ContaModel
      End Get
      Set(value As ContaModel)
        m_ContaModel = value
      End Set
    End Property

    Public Property CodEmpresa As Integer
      Get
        Return m_CodEmpresa
      End Get
      Set(value As Integer)
        m_CodEmpresa = value
      End Set
    End Property
  End Class
End Namespace
