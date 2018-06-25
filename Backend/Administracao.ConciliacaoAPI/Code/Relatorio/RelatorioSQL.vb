
Namespace Code.Relatorio
    Public Class RelatorioSQL
        Public Function selectRelatorio() As String
            Dim stringBuilder As New StringBuilder()
            stringBuilder.Append(" select rel.CODRELCLOCOB,rel.NOMARQRELCLOCOB,rel.DESRELCLOCOB,rel.DATHRACRCREL,tip.CODTIPRELCLOCOB,Tip.Nomtiprelclocob,Tip.Destiprelclocob ")
            stringBuilder.Append(" From MRT.HSTRELCLOCOB rel                                                                                                                 ")
            stringBuilder.Append(" inner Join MRT.CADTIPRELCLOCOB tip on Tip.Codtiprelclocob=Rel.Codtiprelclocob                                                             ")
            Return stringBuilder.ToString
        End Function

        Public Function selectRelatorioPorId() As String
            Dim stringBuilder As New StringBuilder()
            stringBuilder.Append(" select rel.CODRELCLOCOB,rel.NOMARQRELCLOCOB,rel.DESRELCLOCOB,rel.DATHRACRCREL,tip.CODTIPRELCLOCOB,Tip.Nomtiprelclocob,Tip.Destiprelclocob ")
            stringBuilder.Append(" From MRT.HSTRELCLOCOB rel                                                                                                                 ")
            stringBuilder.Append(" inner Join MRT.CADTIPRELCLOCOB tip on Tip.Codtiprelclocob=Rel.Codtiprelclocob                                                             ")
            stringBuilder.Append(" where rel.CODRELCLOCOB=codigo                                                                                                             ")
            Return stringBuilder.ToString
        End Function

        Public Function deleteRelatorio() As String
            Dim stringBuilder As New StringBuilder()
            stringBuilder.Append("  DELETE FROM  MRT.HSTRELCLOCOB WHERE CODRELCLOCOB = :codigo  ")
            Return stringBuilder.ToString
        End Function



        Public Function inserirRelatorio() As String
            Dim stringBuilder As New StringBuilder()
            stringBuilder.Append(" INSERT INTO MRT.HSTRELCLOCOB  (    CODRELCLOCOB,    NOMARQRELCLOCOB,    DESRELCLOCOB,    DATHRACRCREL,    CODTIPRELCLOCOB  ) ")
            stringBuilder.Append("  VALUES  (   NVL((select MAx(CODRELCLOCOB)+1 from MRT.HSTRELCLOCOB),1),    :NOMARQRELCLOCOB,    :DESRELCLOCOB,    Sysdate,    :CODTIPRELCLOCOB  ) ")
            stringBuilder.Append(" RETURNING CODRELCLOCOB INTO :CODRELCLOCOB ")
            stringBuilder.Append("  ")
            Return stringBuilder.ToString
        End Function

        Public Function updateRelatorio() As String
            Throw New NotImplementedException()
        End Function

        Friend Function selectRelatorioPorTipoData() As String
            Dim stringBuilder As New StringBuilder()
            stringBuilder.Append(" select rel.CODRELCLOCOB,rel.NOMARQRELCLOCOB,rel.DESRELCLOCOB,rel.DATHRACRCREL,tip.CODTIPRELCLOCOB,Tip.Nomtiprelclocob,Tip.Destiprelclocob ")
            stringBuilder.Append(" From MRT.HSTRELCLOCOB rel                                                                                                                 ")
            stringBuilder.Append(" inner Join MRT.CADTIPRELCLOCOB tip on Tip.Codtiprelclocob=Rel.Codtiprelclocob                                                             ")
            stringBuilder.Append(" where Tip.Codtiprelclocob=NVL(:tipo,Tip.Codtiprelclocob)      and    rel.DATHRACRCREL=NVL(:data,rel.DATHRACRCREL)                         ")
            Return stringBuilder.ToString
        End Function

        Friend Function selectArquivoRelatorio() As String
            Dim stringBuilder As New StringBuilder()
            stringBuilder.Append(" SELECT arq.CODCDORELCLOCOB,  arq.NOMEXNRELCLOCOB,  arq.CDORELCLOCOB,  arq.CODRELCLOCOB  ")
            stringBuilder.Append(" FROM HSTCDORELCLOCOB arq  ")
            stringBuilder.Append(" where arq.CODRELCLOCOB=:CodRelatorio  ")
            Return StringBuilder.ToString
        End Function

        Public Function deleteArquivos() As String
            Dim stringBuilder As New StringBuilder()
            stringBuilder.Append("  DELETE FROM MRT.HSTCDORELCLOCOB WHERE CODRELCLOCOB = :codigo  ")
            Return stringBuilder.ToString
        End Function

        Friend Function insertArquivo() As String
            Dim stringBuilder As New StringBuilder()
            stringBuilder.Append(" INSERT INTO MRT.HSTCDORELCLOCOB  (    CODCDORELCLOCOB,    NOMEXNRELCLOCOB,    CDORELCLOCOB,    CODRELCLOCOB  ) ")
            stringBuilder.Append("   VALUES  (    NVL((select max(CODCDORELCLOCOB)+1 from MRT.HSTCDORELCLOCOB  ),1),    :NOMEXNRELCLOCOB,    :CDORELCLOCOB,    :CODRELCLOCOB  ) ")
            stringBuilder.Append(" RETURNING CODCDORELCLOCOB INTO :CODCDORELCLOCOB ")
            Return stringBuilder.ToString
        End Function
    End Class
End Namespace

