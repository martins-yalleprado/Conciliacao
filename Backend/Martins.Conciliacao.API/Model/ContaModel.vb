Imports System.Collections.Generic
Imports System.Linq
Imports System.Web

Namespace Model
	Public Class ContaModel
		Public Property codConta() As Integer
			Get
				Return m_codConta
			End Get
			Set
				m_codConta = Value
			End Set
		End Property
		Private m_codConta As Integer
		Public Property nomConta() As String
			Get
				Return m_nomConta
			End Get
			Set
				m_nomConta = Value
			End Set
		End Property
		Private m_nomConta As String
		Public Property desConta() As String
			Get
				Return m_desConta
			End Get
			Set
				m_desConta = Value
			End Set
		End Property
		Private m_desConta As String
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
