Imports System.Collections.Generic
Imports System.Linq
Imports System.Web

Namespace Model
	Public Class UnidadeContaModel
		Public Property codUnidadeConta() As Integer
			Get
				Return m_codUnidadeConta
			End Get
			Set
				m_codUnidadeConta = Value
			End Set
		End Property
		Private m_codUnidadeConta As Integer
		Public Property codUnidade() As Integer
			Get
				Return m_codUnidade
			End Get
			Set
				m_codUnidade = Value
			End Set
		End Property
		Private m_codUnidade As Integer
		Public Property codConta() As Integer
			Get
				Return m_codConta
			End Get
			Set
				m_codConta = Value
			End Set
		End Property
		Private m_codConta As Integer
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
