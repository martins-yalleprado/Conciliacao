Imports System.Collections.Generic
Imports System.Linq
Imports System.Web

Namespace Model
	Public Class PermissaoModel
		Public Property CODACSCLO() As Long
			Get
				Return m_CODACSCLO
			End Get
			Set
				m_CODACSCLO = Value
			End Set
		End Property
		Private m_CODACSCLO As Long
		Public Property CODACSFUN() As Long
			Get
				Return m_CODACSFUN
			End Get
			Set
				m_CODACSFUN = Value
			End Set
		End Property
		Private m_CODACSFUN As Long
    Public Property DESACSFUN() As String
      Get
        Return m_DESACSFUN
      End Get
      Set
        m_DESACSFUN = Value
      End Set
    End Property
    Private m_DESACSFUN As String
    Public Property CODFNC() As Long
      Get
        Return m_CODFNC
      End Get
      Set
        m_CODFNC = Value
      End Set
    End Property
    Private m_CODFNC As Long
	End Class
End Namespace
