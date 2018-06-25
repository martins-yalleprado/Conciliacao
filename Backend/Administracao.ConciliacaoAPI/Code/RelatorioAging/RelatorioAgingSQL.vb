Public Class RelatorioAgingSQL

    Public Function selectRelatorioAgingSintetico1() As String
        Dim stringBuilder As New StringBuilder()
        'tem que acrescentar a questão do período
        stringBuilder.Append("   Select SUM(VLRSLDTIT)                         ")
        stringBuilder.Append("  From MOVAGICLOSISCOB Where DATREF=:data                    ")
        stringBuilder.Append("  And QDEDIAVNC < 0           ")
        Return stringBuilder.ToString
    End Function

    Public Function selectRelatorioAgingSintetico2() As String
        Dim stringBuilder As New StringBuilder()
        'tem que acrescentar a questão do período
        stringBuilder.Append("        Select QDEDIAVNC, VLRSLDTIT, QDETIT         ")
        stringBuilder.Append("          From MOVAGICLOSISCOB Where DATREF=:data          ")
        stringBuilder.Append("         Order By QDEDIAVNC             ")
        Return stringBuilder.ToString
    End Function
End Class
