Namespace Code.Unidade
  Public Class UnidadeSQL

    Public Function SelectUnidade() As String
      Dim stringBuilder As New StringBuilder()
            stringBuilder.Append(" Select CODEMP,CODUNDNGC,DESUNDNGC,CODFILCENADM,CODFILTITPGT,DATCAD,DATDST,CODLIVCTB,CODUNDOPE from MRT.T0123469  ")
            Return stringBuilder.ToString()
    End Function
    Public Function SelectUnidadePorId() As String
      Dim stringBuilder As New StringBuilder()
      stringBuilder.Append(" Select CODEMP,CODUNDNGC,DESUNDNGC,CODFILCENADM,CODFILTITPGT,DATCAD,DATDST,CODLIVCTB,CODUNDOPE from MRT.T0123469  where CODUNDNGC=:CODUNDNGC  ")
      Return stringBuilder.ToString()
    End Function
    Public Function AtivarUnidade() As String
      Dim stringBuilder As New StringBuilder()
      stringBuilder.Append(" update  ")
      Return stringBuilder.ToString()
    End Function
    Public Function InativarUnidade() As String
      Dim stringBuilder As New StringBuilder()
      stringBuilder.Append("update ")
      Return stringBuilder.ToString()
    End Function
    Public Function InsertUnidade() As String
      Dim stringBuilder As New StringBuilder()
      stringBuilder.Append(" insert into MRT.T0123469( CODEMP,CODUNDNGC,DESUNDNGC,CODFILCENADM,CODFILTITPGT,DATCAD,DATDST,CODLIVCTB,CODUNDOPE) ")
      stringBuilder.Append(" values(: CodEmpresa,: CodUnidade,: DesUnidade,: CodFilialCentroAdministrativo,: CodFilialTituloPagamento,: DataCadastro,: DataDesativacao,: CodLivroContabil,: CodNumericosMaiores) ")
      Return stringBuilder.ToString()
    End Function
  End Class
End Namespace

