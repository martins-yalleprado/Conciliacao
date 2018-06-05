Imports System.Collections.Generic
Imports System.Linq
Imports System.Web

Namespace Model
	Public Class UnidadeModel
		Public Property codUnidade() As Integer
			Get
				Return m_codUnidade
			End Get
			Set
				m_codUnidade = Value
			End Set
		End Property
		Private m_codUnidade As Integer
		Public Property nomUnidade() As String
			Get
				Return m_nomUnidade
			End Get
			Set
				m_nomUnidade = Value
			End Set
		End Property
		Private m_nomUnidade As String
		Public Property desUnidade() As String
			Get
				Return m_desUnidade
			End Get
			Set
				m_desUnidade = Value
			End Set
		End Property
		Private m_desUnidade As String
		Public Property situacao() As String
			Get
				Return m_situacao
			End Get
			Set
				m_situacao = Value
			End Set
		End Property
		Private m_situacao As String
		Public Property codFuncionario() As Integer
			Get
				Return m_codFuncionario
			End Get
			Set
				m_codFuncionario = Value
			End Set
		End Property
		Private m_codFuncionario As Integer
		Public Property situacaoLabel() As String
			Get
				Return m_situacaoLabel
			End Get
			Set
				m_situacaoLabel = Value
			End Set
		End Property
		Private m_situacaoLabel As String
	End Class
End Namespace
