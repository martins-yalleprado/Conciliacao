Public Class LogBLL
    Public Function InsertLogOperacao(ByVal CODFNC As String, ByVal VLSTATEMENT As String) As Boolean
        Try
            Return (New LogDAL()).InsertLog(CODFNC, VLSTATEMENT)
        Catch e As Exception
            Throw e
        End Try
    End Function
End Class
