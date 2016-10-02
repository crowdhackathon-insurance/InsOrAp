Imports System.Data.SqlClient
Module MainModulevb
    Public ConStr As String = "server=@MyServer;MultipleActiveResultSets=true;Connection Timeout=180;database=Insorama;uid=sa;password=My@InsOrDB!777;"
    Public Con As SqlConnection = Nothing
    Public ColorEdit As Color = Color.LightGreen
    Public ColorView As Color = Color.White
    Public Function OpenConnection(ByRef Con As SqlConnection) As Boolean
        Try
            Con = New SqlConnection
            Con.ConnectionString = ConStr
            Con.Open()
            Return True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "InsOrApp")
            Return False
        End Try

    End Function
    Public Function CloseConnaection(ByRef Con As SqlConnection) As Boolean
        Try
            Con.Close()
            Con = Nothing
            Return True
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "InsOrApp")
            Return False
        End Try
    End Function
End Module
