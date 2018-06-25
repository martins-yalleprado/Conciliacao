Namespace Model
    Public Class ArquivoModel
        Private m_Arquivo As String
        Private m_CodArquivo As Integer
        Private m_extensao As String
        Private m_CodRelatorio As Integer

        Public Property Arquivo As String
            Get
                Return m_Arquivo
            End Get
            Set(value As String)
                m_Arquivo = value
            End Set
        End Property

        Public Property CodArquivo As Integer
            Get
                Return m_CodArquivo
            End Get
            Set(value As Integer)
                m_CodArquivo = value
            End Set
        End Property

        Public Property Extensao As String
            Get
                Return m_extensao
            End Get
            Set(value As String)
                m_extensao = value
            End Set
        End Property

        Public Property CodRelatorio As Integer
            Get
                Return m_CodRelatorio
            End Get
            Set(value As Integer)
                m_CodRelatorio = value
            End Set
        End Property
    End Class
End Namespace