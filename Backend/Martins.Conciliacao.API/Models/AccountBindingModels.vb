Imports System.ComponentModel.DataAnnotations
Imports Newtonsoft.Json

Namespace Models
	' Models used as parameters to AccountController actions.

	Public Class AddExternalLoginBindingModel
		<Required> _
		<Display(Name := "External access token")> _
		Public Property ExternalAccessToken() As String
			Get
				Return m_ExternalAccessToken
			End Get
			Set
				m_ExternalAccessToken = Value
			End Set
		End Property
		Private m_ExternalAccessToken As String
	End Class

	Public Class ChangePasswordBindingModel
		<Required> _
		<DataType(DataType.Password)> _
		<Display(Name := "Current password")> _
		Public Property OldPassword() As String
			Get
				Return m_OldPassword
			End Get
			Set
				m_OldPassword = Value
			End Set
		End Property
		Private m_OldPassword As String

		<Required> _
		<StringLength(100, ErrorMessage := "The {0} must be at least {2} characters long.", MinimumLength := 6)> _
		<DataType(DataType.Password)> _
		<Display(Name := "New password")> _
		Public Property NewPassword() As String
			Get
				Return m_NewPassword
			End Get
			Set
				m_NewPassword = Value
			End Set
		End Property
		Private m_NewPassword As String

		<DataType(DataType.Password)> _
		<Display(Name := "Confirm new password")> _
		<Compare("NewPassword", ErrorMessage := "The new password and confirmation password do not match.")> _
		Public Property ConfirmPassword() As String
			Get
				Return m_ConfirmPassword
			End Get
			Set
				m_ConfirmPassword = Value
			End Set
		End Property
		Private m_ConfirmPassword As String
	End Class

	Public Class RegisterBindingModel
		<Required> _
		<Display(Name := "Email")> _
		Public Property Email() As String
			Get
				Return m_Email
			End Get
			Set
				m_Email = Value
			End Set
		End Property
		Private m_Email As String

		<Required> _
		<StringLength(100, ErrorMessage := "The {0} must be at least {2} characters long.", MinimumLength := 6)> _
		<DataType(DataType.Password)> _
		<Display(Name := "Password")> _
		Public Property Password() As String
			Get
				Return m_Password
			End Get
			Set
				m_Password = Value
			End Set
		End Property
		Private m_Password As String

		<DataType(DataType.Password)> _
		<Display(Name := "Confirm password")> _
		<Compare("Password", ErrorMessage := "The password and confirmation password do not match.")> _
		Public Property ConfirmPassword() As String
			Get
				Return m_ConfirmPassword
			End Get
			Set
				m_ConfirmPassword = Value
			End Set
		End Property
		Private m_ConfirmPassword As String
	End Class

	Public Class RegisterExternalBindingModel
		<Required> _
		<Display(Name := "Email")> _
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

	Public Class RemoveLoginBindingModel
		<Required> _
		<Display(Name := "Login provider")> _
		Public Property LoginProvider() As String
			Get
				Return m_LoginProvider
			End Get
			Set
				m_LoginProvider = Value
			End Set
		End Property
		Private m_LoginProvider As String

		<Required> _
		<Display(Name := "Provider key")> _
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

	Public Class SetPasswordBindingModel
		<Required> _
		<StringLength(100, ErrorMessage := "The {0} must be at least {2} characters long.", MinimumLength := 6)> _
		<DataType(DataType.Password)> _
		<Display(Name := "New password")> _
		Public Property NewPassword() As String
			Get
				Return m_NewPassword
			End Get
			Set
				m_NewPassword = Value
			End Set
		End Property
		Private m_NewPassword As String

		<DataType(DataType.Password)> _
		<Display(Name := "Confirm new password")> _
		<Compare("NewPassword", ErrorMessage := "The new password and confirmation password do not match.")> _
		Public Property ConfirmPassword() As String
			Get
				Return m_ConfirmPassword
			End Get
			Set
				m_ConfirmPassword = Value
			End Set
		End Property
		Private m_ConfirmPassword As String
	End Class
End Namespace
