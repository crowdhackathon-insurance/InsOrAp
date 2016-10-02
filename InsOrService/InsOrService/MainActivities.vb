Imports System.Net.Mail


Public Class MainActivities
    Public Shared LogAction As String
    Public Shared LogFileDate As String

    Public Shared Sub Write2LogFile()
        If LogFileDate <> Format(Now, "yyyy_MM_dd") Then
            file.Close()
            MainActivities.LogFileDate = Format(Now, "yyyy_MM_dd")
            file = My.Computer.FileSystem.OpenTextFileWriter(My.Application.Info.DirectoryPath & "\Logs\InsOrService_LogFile_" & MainActivities.LogFileDate & ".log", True)
        End If
        file.WriteLine(Format(Now, "yyyy-MM-dd HH:mm:ss") & ": " & MainActivities.LogAction)
        file.Flush()
    End Sub
    Public Shared Sub MySendEmail(Recepient As String, Title As String, Subject As String, MyBody As String)
        Dim mail As New MailMessage()
        Dim SmtpServer As New SmtpClient()
        SmtpServer.Credentials = New Net.NetworkCredential(My.Settings.EmailAddressSender, "ZEYS123..")
        SmtpServer.Port = My.Settings.EmailServerPort
        SmtpServer.Host = My.Settings.EmailSMTPServer
        SmtpServer.EnableSsl = My.Settings.EmailServerSSL
        mail = New MailMessage()
        Try
            mail.From = New MailAddress(My.Settings.EmailAddressSender, Title, System.Text.Encoding.UTF8)
            mail.To.Add(Recepient)
            mail.Subject = Subject
            mail.IsBodyHtml = True
            mail.Body = MyBody
            SmtpServer.Send(mail)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
