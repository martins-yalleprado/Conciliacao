Imports System.Collections.Generic

Namespace Models
	' Models returned by AccountController actions.

	Public Class ExternalLoginViewModel
		Public Property Name() As String
			Get
				Return m_Name
			End Get
			Set
				m_Name = Value
			End Set
		End Property
		Private m_Name As String

		Public Property Url() As String
			Get
				Return m_Url
			End Get
			Set
				m_Url = Value
			End Set
		End Property
		Private m_Url As String

		Public Property State() As String
			Get
				Return m_State
			End Get
			Set
				m_State = Value
			End Set
		End Property
		Private m_State As String
	End Class

	Public Class ManageInfoViewModel
		Public Property LocalLoginProvider() As String
			Get
				Return m_LocalLoginProvider
			End Get
			Set
				m_LocalLoginProvider = Value
			End Set
		End Property
		Private m_LocalLoginProvider As String

		Public Property Email() As String
			Get
				Return m_Email
			End Get
			Set
				m_Email = Value
			End Set
		End Property
		Private m_Email As String

		Public Property Logins() As IEnumerable(Of UserLoginInfoViewModel)
			Get
				Return m_Logins
			End Get
			Set
				m_Logins = Value
			End Set
		End Property
		Private m_Logins As IEnumerable(Of UserLoginInfoViewModel)

		Public Property ExternalLoginProviders() As IEnumerable(Of ExternalLoginViewModel)
			Get
				Return m_ExternalLoginProviders
			End Get
			Set
				m_ExternalLoginProviders = Value
			End Set
		End Property
		Private m_ExternalLoginProviders As IEnumerable(Of ExternalLoginViewModel)
	End Class

	Public Class UserInfoViewModel
		Public Property Email() As String
			Get
				Return m_Email
			End Get
			Set
				m_Email = Value
			End Set
		End Property
		Private m_Email As String

		Public Property HasRegistered() As Boolean
			Get
				Return m_HasRegistered
			End Get
			Set
				m_HasRegistered = Value
			End Set
		End Property
		Private m_HasRegistered As Boolean

		Public Property LoginProvider() As String
			Get
				Return m_LoginProvider
			End Get
			Set
				m_LoginProvider = Value
			End Set
		End Property
		Private m_LoginProvider As String
	End Class

	Public Class UserLoginInfoViewModel
		Public Property LoginProvider() As String
			Get
				Return m_LoginProvider
			End Get
			Set
				m_LoginProvider = Value
			End Set
		End Property
		Private m_LoginProvider As String

		Public Property ProviderKey() As String
			Get
				Return m_ProviderKey
			End Get
			Set
				m_ProviderKey = Value
			End Set
		End Property
		Private m_ProviderKey As String
	End Class
End Namespace
