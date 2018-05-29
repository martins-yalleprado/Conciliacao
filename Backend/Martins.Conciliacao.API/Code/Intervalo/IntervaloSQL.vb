
Namespace Code.Intervalo
	Public Class IntervaloSQL
		Public Function selectIntervaloPorId() As String
			Dim stringBuilder As New StringBuilder()
			stringBuilder.Append("Select CODIVLPODAGN,NUMINIIVLPODAGN,NUMFIMIVLPODAGN,IDTSITIVLPODAGN,CODPODAGN from CADIVLPODAGN where CODIVLPODAGN =:codigo")
			Return stringBuilder.ToString()
		End Function
		Public Function selectIntervalo() As String
			Dim stringBuilder As New StringBuilder()
			stringBuilder.Append("Select CODIVLPODAGN,NUMINIIVLPODAGN,NUMFIMIVLPODAGN,IDTSITIVLPODAGN,CODPODAGN from CADIVLPODAGN where CODPODAGN=:periodo ")
			Return stringBuilder.ToString()
		End Function
		Public Function deleteIntervalo() As String
			Dim stringBuilder As New StringBuilder()
			stringBuilder.Append("delete CADIVLPODAGN where CODIVLPODAGN =:codigo")
			Return stringBuilder.ToString()
		End Function
		Public Function updateIntervalo() As String
			Dim stringBuilder As New StringBuilder()
			stringBuilder.Append("update CADIVLPODAGN set NUMINIIVLPODAGN= :inicio,NUMFIMIVLPODAGN=:fim,CODPODAGN =:periodo where CODIVLPODAGN=:codigo")
			Return stringBuilder.ToString()
		End Function
		Public Function ativarIntervalo() As String
			Dim stringBuilder As New StringBuilder()
			stringBuilder.Append("update CADIVLPODAGN set IDTSITPODAGN='1' where CODIVLPODAGN =:codigo")
			Return stringBuilder.ToString()
		End Function
		Public Function desativarIntervalo() As String
			Dim stringBuilder As New StringBuilder()
			stringBuilder.Append("update CADIVLPODAGN set IDTSITPODAGN='0' where CODIVLPODAGN =:codigo")
			Return stringBuilder.ToString()
		End Function
		Public Function inserirIntervalo() As String
			Dim stringBuilder As New StringBuilder()
			stringBuilder.Append(" Insert into CADIVLPODAGN (CODIVLPODAGN,NUMINIIVLPODAGN,NUMFIMIVLPODAGN,IDTSITIVLPODAGN,CODPODAGN) values (Nvl((select MAX(CODIVLPODAGN)+1 from CADIVLPODAGN),1),:inicio,:fim ,'1',:periodo)")
			Return stringBuilder.ToString()
		End Function
	End Class
End Namespace

