Namespace Code.MovimentoTitulo
    Public Class MovimentoTituloSQL
        Public Function selectDatasTitulosPorCarga() As String
            Dim stringBuilder As New StringBuilder()
            stringBuilder.Append("select distinct(DATMOV) from MRT.MOVTITCLOSISCOB where NUMSEQCRGTAB = :codigoCarga")
            Return stringBuilder.ToString()
        End Function
    End Class
End Namespace
