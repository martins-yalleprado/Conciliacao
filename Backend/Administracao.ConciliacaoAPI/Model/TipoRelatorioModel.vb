Namespace Model
    Public Class TipoRelatorioModel
        Private m_CodtipoRelatorio As Integer
        Private m_DestipoRelatorio As String
        Private m_NomTipoRelatorio As String

        Public Property CodtipoRelatorio As Integer
            Get
                Return m_CodtipoRelatorio
            End Get
            Set(value As Integer)
                m_CodtipoRelatorio = value
            End Set
        End Property

        Public Property DestipoRelatorio As String
            Get
                Return m_DestipoRelatorio
            End Get
            Set(value As String)
                m_DestipoRelatorio = value
            End Set
        End Property

        Public Property NomTipoRelatorio As String
            Get
                Return m_NomTipoRelatorio
            End Get
            Set(value As String)
                m_NomTipoRelatorio = value
            End Set
        End Property
    End Class
End Namespace