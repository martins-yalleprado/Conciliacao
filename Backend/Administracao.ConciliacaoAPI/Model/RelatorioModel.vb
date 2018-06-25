Namespace Model
    Public Class RelatorioModel
        Private m_CodRelatorio As Integer
        Private m_NomArquivo As String
        Private m_desRelatório As String
        Private m_DataCriacao As DateTime
        Private m_TipoRelatorio As TipoRelatorioModel
        Sub New()
            m_Arquivos = New List(Of ArquivoModel)
        End Sub
        Private m_Arquivos As List(Of ArquivoModel)
        Public Property CodRelatorio As Integer
            Get
                Return m_CodRelatorio
            End Get
            Set(value As Integer)
                m_CodRelatorio = value
            End Set
        End Property

        Public Property Arquivos As List(Of ArquivoModel)
            Get
                Return m_Arquivos
            End Get
            Set(value As List(Of ArquivoModel))
                m_Arquivos = value
            End Set
        End Property

        Public Property TipoRelatorio As TipoRelatorioModel
            Get
                Return m_TipoRelatorio
            End Get
            Set(value As TipoRelatorioModel)
                m_TipoRelatorio = value
            End Set
        End Property

        Public Property DataCriacao As Date
            Get
                Return m_DataCriacao
            End Get
            Set(value As Date)
                m_DataCriacao = value
            End Set
        End Property

        Public Property DesRelatório As String
            Get
                Return m_desRelatório
            End Get
            Set(value As String)
                m_desRelatório = value
            End Set
        End Property

        Public Property NomArquivo As String
            Get
                Return m_NomArquivo
            End Get
            Set(value As String)
                m_NomArquivo = value
            End Set
        End Property
    End Class
End Namespace