
Namespace Code.Permissao
    Public Class PermissaoSQL
        Public Function SelectPermissao(NOMGRPACS As String) As String
      Return String.Format("select DISTINCT p.CODACSFUN, p.DESACSFUN from MRT.CADGRPACSCLO g inner Join MRT.RLCGRPACS pg On g.CODIDTGRP=pg.CODIDTGRP inner Join MRT.CADACSSISCLO p On pg.CODACSCLO=p.CODACSCLO where g.NOMGRPACS In ({0})", NOMGRPACS)
    End Function
    End Class
End Namespace
