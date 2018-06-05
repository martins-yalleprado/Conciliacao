Public Class LogSQL
    Public Function InsertLog() As String
        Return "INSERT INTO MRT.CADLOGSISCLO
                (NUMSEQLOGCLO, CODFNC, DATHRAGRCLOG, VLSTATEMENT)
              values
                (NUMSEQLOGCLO_SEQUENCE.nextval, :CODFNC, CURRENT_TIMESTAMP, :VLSTATEMENT)"
    End Function
End Class
