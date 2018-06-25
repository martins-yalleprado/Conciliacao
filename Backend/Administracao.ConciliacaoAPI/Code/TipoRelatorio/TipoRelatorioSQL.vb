
Namespace Code.TipoRelatorio
    Public Class TipoRelatorioSQL
        Public Function selectTipoRelatorio() As String
            Dim stringBuilder As New StringBuilder()
            stringBuilder.Append(" select tip.CODTIPRELCLOCOB,Tip.Nomtiprelclocob,Tip.Destiprelclocob ")
            stringBuilder.Append(" From MRT.CADTIPRELCLOCOB tip                                       ")
            Return stringBuilder.ToString
        End Function

        Public Function selectTipoRelatorioPorId() As String
            Dim stringBuilder As New StringBuilder()
            stringBuilder.Append(" select tip.CODTIPRELCLOCOB,Tip.Nomtiprelclocob,Tip.Destiprelclocob ")
            stringBuilder.Append(" From MRT.CADTIPRELCLOCOB tip                                       ")
            stringBuilder.Append(" where tip.CODTIPRELCLOCOB=codigo                                   ")
            Return stringBuilder.ToString
        End Function

        Public Function deleteTipoRelatorio() As String
            Throw New NotImplementedException()
        End Function

        Public Function inserirTipoRelatorio() As String
            Dim stringBuilder As New StringBuilder()
            stringBuilder.Append(" INSERT INTO CADTIPRELCLOCOB  (    CODTIPRELCLOCOB, DESTIPRELCLOCOB, NOMTIPRELCLOCOB  )  ")
            stringBuilder.Append(" VALUES(    NVL((select Max(CODTIPRELCLOCOB)+1 from CADTIPRELCLOCOB),1),    :DESTIPRELCLOCOB,    :NOMTIPRELCLOCOB  )             ")
            stringBuilder.Append("  RETURNING CODTIPRELCLOCOB into :CODTIPRELCLOCOB  ")
            Return stringBuilder.ToString
        End Function

        Public Function updateTipoRelatorio() As String
            Throw New NotImplementedException()
        End Function


    End Class
End Namespace

