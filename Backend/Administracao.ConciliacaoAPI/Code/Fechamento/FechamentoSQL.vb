Namespace Code.Fechamento
    Public Class FechamentoSQL

        Public Function SelectFechamento() As String
            Dim stringBuilder As New StringBuilder()
            stringBuilder.Append(" Select CODFCHCLOCOB,DATINIFCHPODCLOCOB,DATFIMFCHPODCLOCOB,DATHRAISRCLOCOB,IDTTIPFCHCLOCOB,CODUSRISRFCHCLOCOB,SLDFCHCLOCOB,IDTSITFCHCLOCOB,CODUNDNGC,CODCNTCTB from MRT.MOVMESFCHCLOCOB  ")
            Return stringBuilder.ToString()
        End Function
        Public Function SelectFechamentoPorTipo() As String
            Dim stringBuilder As New StringBuilder()
            stringBuilder.Append(" Select CODFCHCLOCOB,DATINIFCHPODCLOCOB,DATFIMFCHPODCLOCOB,DATHRAISRCLOCOB,IDTTIPFCHCLOCOB,CODUSRISRFCHCLOCOB,SLDFCHCLOCOB,IDTSITFCHCLOCOB,CODUNDNGC,CODCNTCTB from MRT.MOVMESFCHCLOCOB where IDTTIPFCHCLOCOB=NVL(:TipoFechamento ,IDTTIPFCHCLOCOB) and  CODFCHCLOCOB=NVL(:CodFechamento ,CODFCHCLOCOB) and  CODUNDNGC=NVL(:CODUNDNGC ,CODUNDNGC) and  CODCNTCTB=NVL(:CODCNTCTB ,CODCNTCTB) and  IDTSITFCHCLOCOB='1' ")
            Return stringBuilder.ToString()
        End Function
        Public Function AtivarFechamento() As String
            Dim stringBuilder As New StringBuilder()
            stringBuilder.Append(" update  MRT.MOVMESFCHCLOCOB ")
            stringBuilder.Append(" set  IDTSITFCHCLOCOB='1' ")
            stringBuilder.Append(" where   CODFCHCLOCOB=:CodFechamento ")
            Return stringBuilder.ToString()
        End Function
        Public Function InativarFechamento() As String
            Dim stringBuilder As New StringBuilder()
            stringBuilder.Append(" update  MRT.MOVMESFCHCLOCOB ")
            stringBuilder.Append(" set  IDTSITFCHCLOCOB='0' ")
            stringBuilder.Append(" where   CODFCHCLOCOB=:CodFechamento ")
            Return stringBuilder.ToString()
        End Function
        Public Function InsertFechamento() As String
            Dim stringBuilder As New StringBuilder()
            stringBuilder.Append(" insert Into  MRT.MOVMESFCHCLOCOB( CODFCHCLOCOB,DATINIFCHPODCLOCOB,DATFIMFCHPODCLOCOB,DATHRAISRCLOCOB,IDTTIPFCHCLOCOB,CODUSRISRFCHCLOCOB,SLDFCHCLOCOB,IDTSITFCHCLOCOB,CODUNDNGC,CODCNTCTB)")
            stringBuilder.Append(" values (  nvl((select max(CODFCHCLOCOB)+1 from  MRT.MOVMESFCHCLOCOB),1), :DataInicioPeriodo, :DataFimPeriodo, :DataInclusao, :TipoFechamento, :usuario, :SaldoFechamento, :StatusFechamento, :CODUNDNGC, :CODCNTCTB )  ")
            Return stringBuilder.ToString()
        End Function
    End Class



End Namespace

