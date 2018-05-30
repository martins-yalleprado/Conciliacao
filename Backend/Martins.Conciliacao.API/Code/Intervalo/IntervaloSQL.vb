
Namespace Code.Intervalo
	Public Class IntervaloSQL
		Public Function selectIntervaloPorId() As String
			Dim stringBuilder As New StringBuilder()
            stringBuilder.Append("Select CODIVLPODAGI,NUMINIIVLPODAGI,NUMFIMIVLPODAGI,IDTSITIVLPODAGI,CODPODAGI from MRT.CADIVLPODAGI where CODIVLPODAGI =:codigo")
            Return stringBuilder.ToString()
		End Function
		Public Function selectIntervalo() As String
			Dim stringBuilder As New StringBuilder()
            stringBuilder.Append("Select CODIVLPODAGI,NUMINIIVLPODAGI,NUMFIMIVLPODAGI,IDTSITIVLPODAGI,CODPODAGI from MRT.CADIVLPODAGI where CODPODAGI=:periodo ")
            Return stringBuilder.ToString()
		End Function
		Public Function deleteIntervalo() As String
			Dim stringBuilder As New StringBuilder()
            stringBuilder.Append("delete MRT.CADIVLPODAGI where CODIVLPODAGI =:codigo")
            Return stringBuilder.ToString()
		End Function
		Public Function updateIntervalo() As String
			Dim stringBuilder As New StringBuilder()
            stringBuilder.Append("update MRT.CADIVLPODAGI set NUMINIIVLPODAGI= :inicio,NUMFIMIVLPODAGI=:fim,CODPODAGI =:periodo where CODIVLPODAGI=:codigo")
            Return stringBuilder.ToString()
		End Function
		Public Function ativarIntervalo() As String
			Dim stringBuilder As New StringBuilder()
            stringBuilder.Append("update MRT.CADIVLPODAGI set IDTSITPODAGI='1' where CODIVLPODAGI =:codigo")
            Return stringBuilder.ToString()
		End Function
		Public Function desativarIntervalo() As String
			Dim stringBuilder As New StringBuilder()
            stringBuilder.Append("update MRT.CADIVLPODAGI set IDTSITPODAGI='0' where CODIVLPODAGI =:codigo")
            Return stringBuilder.ToString()
		End Function
		Public Function inserirIntervalo() As String
			Dim stringBuilder As New StringBuilder()
            stringBuilder.Append(" Insert into MRT.CADIVLPODAGI (CODIVLPODAGI,NUMINIIVLPODAGI,NUMFIMIVLPODAGI,IDTSITIVLPODAGI,CODPODAGI) values (Nvl((select MAX(CODIVLPODAGI)+1 from MRT.CADIVLPODAGI),1),:inicio,:fim ,'1',:periodo)")
            Return stringBuilder.ToString()
		End Function
	End Class
End Namespace

