Imports System.Collections.Generic
Imports System.Linq
Imports System.Web

Namespace Model
	Public Class IntervaloModel
		Public Property codIntervalo() As Integer
			Get
				Return m_codIntervalo
			End Get
			Set
				m_codIntervalo = Value
			End Set
		End Property
		Private m_codIntervalo As Integer
		Public Property inicio() As Integer
			Get
				Return m_inicio
			End Get
			Set
				m_inicio = Value
			End Set
		End Property
		Private m_inicio As Integer
		Public Property fim() As Integer
			Get
				Return m_fim
			End Get
			Set
				m_fim = Value
			End Set
		End Property
		Private m_fim As Integer
		Public Property situacao() As String
			Get
				Return m_situacao
			End Get
			Set
				m_situacao = Value
			End Set
		End Property
		Private m_situacao As String
		Public Property codPeriodo() As Integer
			Get
				Return m_codPeriodo
			End Get
			Set
				m_codPeriodo = Value
			End Set
		End Property
		Private m_codPeriodo As Integer
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
