Imports System.Collections.Generic
Imports System.Linq
Imports System.Web

Namespace Model
	Public Class GrupoModel
		Public Property idGrupo() As String
			Get
				Return m_idGrupo
			End Get
			Set
				m_idGrupo = Value
			End Set
		End Property
		Private m_idGrupo As String
		Public Property dsGrupo() As String
			Get
				Return m_dsGrupo
			End Get
			Set
				m_dsGrupo = Value
			End Set
		End Property
		Private m_dsGrupo As String
	End Class
End Namespace
