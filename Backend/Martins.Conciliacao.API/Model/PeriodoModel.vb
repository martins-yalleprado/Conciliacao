Imports System.Collections.Generic
Imports System.Linq
Imports System.Web

Namespace Model
	Public Class PeriodoModel
		Public Property codPeriodo() As Integer
			Get
				Return m_codPeriodo
			End Get
			Set
				m_codPeriodo = Value
			End Set
		End Property
		Private m_codPeriodo As Integer
		Public Property nome() As String
			Get
				Return m_nome
			End Get
			Set
				m_nome = Value
			End Set
		End Property
		Private m_nome As String
		Public Property situacao() As String
			Get
				Return m_situacao
			End Get
			Set
				m_situacao = Value
			End Set
		End Property
		Private m_situacao As String
		Public Property situacaoLabel() As String
			Get
				Return m_situacaoLabel
			End Get
			Set
				m_situacaoLabel = Value
			End Set
		End Property
		Private m_situacaoLabel As String

		Public Sub New()
		End Sub
	End Class
End Namespace
