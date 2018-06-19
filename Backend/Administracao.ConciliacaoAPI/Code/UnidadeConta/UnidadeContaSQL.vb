Namespace Code.UnidadeConta
    Public Class UnidadeContaSQL
        Public Function SelectUnidadeConta() As String
            Dim stringBuilder As New StringBuilder()
            stringBuilder.Append(" Select  UC.CODEMP ")
            stringBuilder.Append("      ,UC.FLGSTAATV ")
            stringBuilder.Append("      ,U.CODEMP ")
            stringBuilder.Append("      ,U.CODUNDNGC ")
            stringBuilder.Append("      ,U.DESUNDNGC ")
            stringBuilder.Append("      ,U.CODFILCENADM ")
            stringBuilder.Append("      ,U.CODFILTITPGT ")
            stringBuilder.Append("      ,U.DATCAD ")
            stringBuilder.Append("      ,U.DATDST ")
            stringBuilder.Append("      ,U.CODLIVCTB ")
            stringBuilder.Append("      ,U.CODUNDOPE ")
            stringBuilder.Append("      ,C.CODCNTCTB ")
            stringBuilder.Append("      ,C.NUMGRACNTCTB ")
            stringBuilder.Append("      ,C.DESCNTCTB ")
            stringBuilder.Append("      ,C.DATCAD ")
            stringBuilder.Append("      ,C.DATDST ")
            stringBuilder.Append("      ,C.FLGATVCLOCOB  ")
            stringBuilder.Append("  from MRT.RLCEMPCNTCLO UC  ")
            stringBuilder.Append("  Inner Join MRT.T0123469 U On U.CODUNDNGC=UC.CODUNDNGC ")
            stringBuilder.Append("  Inner Join MRT.T0123566 C On UC.CODCNTCTB=C.CODCNTCTB ")

            Return stringBuilder.ToString()
        End Function

        Public Function SelectUnidadeContaPorId() As String
            Dim stringBuilder As New StringBuilder()
            stringBuilder.Append(" Select  UC.CODEMP ")
            stringBuilder.Append("      ,UC.FLGSTAATV ")
            stringBuilder.Append("      ,U.CODEMP ")
            stringBuilder.Append("      ,U.CODUNDNGC ")
            stringBuilder.Append("      ,U.DESUNDNGC ")
            stringBuilder.Append("      ,U.CODFILCENADM ")
            stringBuilder.Append("      ,U.CODFILTITPGT ")
            stringBuilder.Append("      ,U.DATCAD ")
            stringBuilder.Append("      ,U.DATDST ")
            stringBuilder.Append("      ,U.CODLIVCTB ")
            stringBuilder.Append("      ,U.CODUNDOPE ")
            stringBuilder.Append("      ,C.CODCNTCTB ")
            stringBuilder.Append("      ,c.NUMGRACNTCTB ")
            stringBuilder.Append("      ,c.DESCNTCTB ")
            stringBuilder.Append("      ,c.DATCAD ")
            stringBuilder.Append("      ,c.DATDST ")
            stringBuilder.Append("      ,c.FLGATVCLOCOB  ")
            stringBuilder.Append(" from MRT.RLCEMPCNTCLO UC  ")
            stringBuilder.Append(" Inner Join MRT.T0123469 U On U.CODUNDNGC=Uc.CODUNDNGC ")
            stringBuilder.Append(" Inner Join MRT.T0123566 C On UC.CODCNTCTB=C.CODCNTCTB ")
            stringBuilder.Append(" Where C.CODCNTCTB=Nvl(:CODCNTCTB,C.CODCNTCTB) and U.CODUNDNGC=Nvl(:CODUNDNGC,U.CODUNDNGC) ")
            Return stringBuilder.ToString()
        End Function

        Public Function AtivarInativarUnidadeConta() As String
            Dim stringBuilder As New StringBuilder()
            stringBuilder.Append("UPDATE MRT.RLCEMPCNTCLO   SET FLGSTAATV =     CASE  WHEN (FLGSTAATV = '1')  THEN '0'  
                                                                                WHEN (FLGSTAATV = '0') THEN '1'      
                                                                                ELSE  FLGSTAATV END
                                                                                WHERE CODCNTCTB = :codConta AND CODUNDNGC = :codUnidade AND CODEMP = :codEmpresa")
            Return stringBuilder.ToString()
        End Function

        Public Function InsertUnidadeConta() As String
            Dim stringBuilder As New StringBuilder()
            stringBuilder.Append("  insert into MRT.RLCEMPCNTCLO  (CODCNTCTB,CODUNDNGC,CODEMP,FLGSTAATV) values (:codConta,:codUnidade,:codEmpresa,'1') ")
            Return stringBuilder.ToString()
        End Function

    End Class
End Namespace
