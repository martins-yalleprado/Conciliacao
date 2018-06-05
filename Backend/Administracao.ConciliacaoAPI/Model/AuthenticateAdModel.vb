Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.Http.Results

Namespace Model
	Public Class AuthenticateAdModel
		Public Property UserAD() As UserAD
			Get
				Return m_UserAD
			End Get
			Set
				m_UserAD = Value
			End Set
		End Property
		Private m_UserAD As UserAD
		Public Property Code() As Integer
			Get
				Return m_Code
			End Get
			Set
				m_Code = Value
			End Set
		End Property
		Private m_Code As Integer
		Public Property Message() As String
			Get
				Return m_Message
			End Get
			Set
				m_Message = Value
			End Set
		End Property
		Private m_Message As String

    Public Shared Narrowing Operator CType(v As AuthenticateAdModel) As OkNegotiatedContentResult(Of Object)
      Throw New NotImplementedException()
    End Operator
  End Class

	Public Class GroupAD
		Public Property Code() As Integer
			Get
				Return m_Code
			End Get
			Set
				m_Code = Value
			End Set
		End Property
		Private m_Code As Integer
		Public Property Name() As String
			Get
				Return m_Name
			End Get
			Set
				m_Name = Value
			End Set
		End Property
		Private m_Name As String
		Public Property Email() As String
			Get
				Return m_Email
			End Get
			Set
				m_Email = Value
			End Set
		End Property
		Private m_Email As String
	End Class

	Public Class UserAD
		Public Property Code() As String
			Get
				Return m_Code
			End Get
			Set
				m_Code = Value
			End Set
		End Property
		Private m_Code As String
		Public Property Name() As String
			Get
				Return m_Name
			End Get
			Set
				m_Name = Value
			End Set
		End Property
		Private m_Name As String
		Public Property sAMAccountName() As Integer
			Get
				Return m_sAMAccountName
			End Get
			Set
				m_sAMAccountName = Value
			End Set
		End Property
		Private m_sAMAccountName As Integer
		Public Property Mail() As String
			Get
				Return m_Mail
			End Get
			Set
				m_Mail = Value
			End Set
		End Property
		Private m_Mail As String
		Public Property Description() As String
			Get
				Return m_Description
			End Get
			Set
				m_Description = Value
			End Set
		End Property
		Private m_Description As String
		Public Property ObjectCategory() As String
			Get
				Return m_ObjectCategory
			End Get
			Set
				m_ObjectCategory = Value
			End Set
		End Property
		Private m_ObjectCategory As String
		Public Property PasswordLastSet() As DateTime
			Get
				Return m_PasswordLastSet
			End Get
			Set
				m_PasswordLastSet = Value
			End Set
		End Property
		Private m_PasswordLastSet As DateTime
		Public Property Dn() As String
			Get
				Return m_Dn
			End Get
			Set
				m_Dn = Value
			End Set
		End Property
		Private m_Dn As String
		Public Property Groups() As String
			Get
				Return m_Groups
			End Get
			Set
				m_Groups = Value
			End Set
		End Property
		Private m_Groups As String
		Public Property lstGroupAD() As List(Of GroupAD)
			Get
				Return m_lstGroupAD
			End Get
			Set
				m_lstGroupAD = Value
			End Set
		End Property
		Private m_lstGroupAD As List(Of GroupAD)
	End Class
End Namespace
