Imports System.Collections.Generic
Imports System.Linq
Imports System.Web

Namespace Model
  Public Class UnidadeModel
    Private m_CodEmpresa As Integer
    Private m_CodUnidade As Integer
    Private m_DesUnidade As String
    Private m_CodFilialCentroAdministrativo As Integer
    Private m_CodFilialTituloPagamento As Integer
    Private m_DataCadastro As DateTime
    Private m_DataDesativacao As DateTime
    Private m_CodLivroContabil As Integer
    Private m_CodNumericosMaiores As Integer

    Public Property CodEmpresa As Integer
      Get
        Return m_CodEmpresa
      End Get
      Set(value As Integer)
        m_CodEmpresa = value
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

    Public Property DesUnidade As String
      Get
        Return m_DesUnidade
      End Get
      Set(value As String)
        m_DesUnidade = value
      End Set
    End Property

    Public Property CodFilialCentroAdministrativo As Integer
      Get
        Return m_CodFilialCentroAdministrativo
      End Get
      Set(value As Integer)
        m_CodFilialCentroAdministrativo = value
      End Set
    End Property

    Public Property CodFilialTituloPagamento As Integer
      Get
        Return m_CodFilialTituloPagamento
      End Get
      Set(value As Integer)
        m_CodFilialTituloPagamento = value
      End Set
    End Property

    Public Property DataCadastro As Date
      Get
        Return m_DataCadastro
      End Get
      Set(value As Date)
        m_DataCadastro = value
      End Set
    End Property

    Public Property DataDesativacao As Date
      Get
        Return m_DataDesativacao
      End Get
      Set(value As Date)
        m_DataDesativacao = value
      End Set
    End Property

    Public Property CodLivroContabil As Integer
      Get
        Return m_CodLivroContabil
      End Get
      Set(value As Integer)
        m_CodLivroContabil = value
      End Set
    End Property

    Public Property CodNumericosMaiores As Integer
      Get
        Return m_CodNumericosMaiores
      End Get
      Set(value As Integer)
        m_CodNumericosMaiores = value
      End Set
    End Property
  End Class
End Namespace
