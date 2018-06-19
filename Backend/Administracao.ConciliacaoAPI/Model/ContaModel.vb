Imports System.Collections.Generic
Imports System.Linq
Imports System.Net.Http
Imports System.Web

Namespace Model
    Public Class ContaModel
        Private m_CodContaContabil As Integer
        Private m_NumGrauContaContabil As Integer
        Private m_DescricaoDaContaContabil As String
        Private m_DataCadastro As DateTime
        Private m_DataDesativacao As Nullable(Of DateTime)
        Private m_Flag As String
        Private m_Flaglabel As String

        Public Property CodContaContabil As Integer
            Get
                Return m_CodContaContabil
            End Get
            Set(value As Integer)
                m_CodContaContabil = value
            End Set
        End Property

        Public Property NumGrauContaContabil As Integer
            Get
                Return m_NumGrauContaContabil
            End Get
            Set(value As Integer)
                m_NumGrauContaContabil = value
            End Set
        End Property

        Public Property DescricaoDaContaContabil As String
            Get
                Return m_DescricaoDaContaContabil
            End Get
            Set(value As String)
                m_DescricaoDaContaContabil = value
            End Set
        End Property

        Public Property DataCadastro As Date
            Get
                Return m_DataCadastro
            End Get
            Set(value As Date)
                m_DataCadastro = value
            End Set
        End Property

        Public Property DataDesativacao As Nullable(Of DateTime)
            Get
                Return m_DataDesativacao
            End Get
            Set(value As Nullable(Of DateTime))
                m_DataDesativacao = value
            End Set
        End Property

        Public Property Flag As String
            Get
                Return m_Flag
            End Get
            Set(value As String)
                m_Flag = value
            End Set
        End Property

        Public Property Flaglabel As String
            Get
                Return m_Flaglabel
            End Get
            Set(value As String)
                m_Flaglabel = value
            End Set
        End Property


    End Class
End Namespace
