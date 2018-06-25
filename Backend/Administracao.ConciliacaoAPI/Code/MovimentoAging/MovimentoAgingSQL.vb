Namespace Code.MovimentoAging
    Public Class MovimentoAgingSQL
        Public Function selectDatasAgingPorCarga() As String
            Dim stringBuilder As New StringBuilder()
            stringBuilder.Append("select distinct(DATREFCTB) from MRT.MOVAGICLOSISCOB where NUMSEQCRGTAB = :codigoCarga")
            Return stringBuilder.ToString()
        End Function
    End Class
End Namespace
