

Namespace Code.MovimentoConciliacao
    Public Class MovimentoConciliacaoSQL
        Public Function UpdateMovimentoConciliacao() As String
            Dim stringBuilder As New StringBuilder()
            stringBuilder.Append(" update  MRT.MOVIDTCLO set ")
            stringBuilder.Append("   CODEMTTIT =:CODEMTTIT ")
            stringBuilder.Append(" , CODFRMPGT =:CODFRMPGT ")
            stringBuilder.Append(" , CODSITENVORGFSC =:CODSITENVORGFSC ")
            stringBuilder.Append(" , CODORIPED =:CODORIPED ")
            stringBuilder.Append(" , CODPTATIT =:CODPTATIT ")
            stringBuilder.Append(" , CODRPNRSCCRD =:CODRPNRSCCRD ")
            stringBuilder.Append(" , TIPCHQ =:TIPCHQ ")
            stringBuilder.Append(" , CODSITTITVDR =:CODSITTITVDR ")
            stringBuilder.Append(" , CODSITVNCTIT =:CODSITVNCTIT ")
            stringBuilder.Append(" , CODTIPCOB =:CODTIPCOB ")
            stringBuilder.Append(" , CODTIPMOVTIT =:CODTIPMOVTIT ")
            stringBuilder.Append(" , FLGRGTMOV =:FLGRGTMOV ")
            stringBuilder.Append(" , CODIDTCTB =:CODIDTCTB ")
            stringBuilder.Append(" where CODIDTMOV=:CODIDTMOV ")
            Return stringBuilder.ToString()

        End Function

        Public Function InsertMovimentoConciliacao() As String
            Dim stringBuilder As New StringBuilder()
            stringBuilder.Append("INSERT INTO MRT.MOVIDTCLO(CODEMTTIT, CODFRMPGT, CODSITENVORGFSC, CODORIPED, CODPTATIT, CODRPNRSCCRD, TIPCHQ, CODSITTITVDR, CODSITVNCTIT, CODTIPCOB, CODTIPMOVTIT, FLGRGTMOV, CODIDTMOV, CODIDTCTB) ")
            stringBuilder.Append("VALUES (:CODEMTTIT, :CODFRMPGT, :CODSITENVORGFSC, :CODORIPED, :CODPTATIT, :CODRPNRSCCRD, :TIPCHQ, :CODSITTITVDR, :CODSITVNCTIT, :CODTIPCOB, :CODTIPMOVTIT, :FLGRGTMOV, Nvl((SELECT Max(CODIDTMOV)+1 FROM MRT.MOVIDTCLO),1), :CODIDTCTB)")
            Return stringBuilder.ToString()
        End Function

        Public Function SelectMovimentoConciliacao() As String
            Dim stringBuilder As New StringBuilder()
            stringBuilder.Append(" SELECT CODEMTTIT, CODFRMPGT  ,CODSITENVORGFSC  ,CODORIPED  ,CODPTATIT  ,CODRPNRSCCRD  ,TIPCHQ  ,CODSITTITVDR  ,CODSITVNCTIT  ,CODTIPCOB  ,CODTIPMOVTIT  ,FLGRGTMOV  ,CODIDTMOV,CODIDTCTB ")
            stringBuilder.Append(" FROM   MRT.MOVIDTCLO  ")
            stringBuilder.Append(" Where  FLGRGTMOV = :FLGRGTMOV ")
            stringBuilder.Append(" Order By CODPTATIT, CODTIPMOVTIT, CODFRMPGT ")
            Return stringBuilder.ToString()
        End Function

        Public Function DeleteMovimentoConciliacao() As String
            Dim stringBuilder As New StringBuilder()
            stringBuilder.Append(" DELETE MRT.MOVIDTCLO ")
            stringBuilder.Append(" Where  CODIDTMOV=:codigo  ")
            Return stringBuilder.ToString()
        End Function

        Public Function SelectMovimentoConciliacaoPorId() As String
            Dim stringBuilder As New StringBuilder()
            stringBuilder.Append(" SELECT con.CODEMTTIT, con.CODFRMPGT  ,con.CODSITENVORGFSC  ,con.CODORIPED  ,con.CODPTATIT  ,con.CODRPNRSCCRD  ,con.TIPCHQ  ,con.CODSITTITVDR  ,con.CODSITVNCTIT  ,con.CODTIPCOB  ,con.CODTIPMOVTIT  ,con.FLGRGTMOV  ,con.CODIDTMOV,con.CODIDTCTB ")
            stringBuilder.Append(" FROM  MRT.MOVIDTCLO con ")
            stringBuilder.Append(" Where  CODIDTMOV=:codigo  ")
            Return stringBuilder.ToString()
        End Function

        Public Function SelectMovimentoConciliacaoPorMovimentoContabil() As String
            Dim stringBuilder As New StringBuilder()
            stringBuilder.Append(" SELECT con.CODEMTTIT, con.CODFRMPGT  ,con.CODSITENVORGFSC  ,con.CODORIPED  ,con.CODPTATIT  ,con.CODRPNRSCCRD  ,con.TIPCHQ  ,con.CODSITTITVDR  ,con.CODSITVNCTIT  ,con.CODTIPCOB  ,con.CODTIPMOVTIT  ,con.FLGRGTMOV  ,con.CODIDTMOV,con.CODIDTCTB ")
            stringBuilder.Append(" FROM  MRT.MOVIDTCLO con ")
            stringBuilder.Append(" Where  con.CODIDTCTB=:CODIDTCTB  ")
            Return stringBuilder.ToString()
        End Function
    End Class
End Namespace
