Imports System.Data.SqlClient
Imports System.Threading
Imports System
Imports System.Timers
Public Class Service
    Private CommandReader As SqlCommand = Nothing
    Private CommandWriter As SqlCommand = Nothing
    Private Reader As SqlDataReader = Nothing
    Private NonStop As Boolean = True
    Private MyThread As Thread
    Protected Overrides Sub OnStart(ByVal args() As String)
        MainActivities.LogFileDate = Format(Now, "yyyy_MM_dd")
        Call InitConStr()
        file = My.Computer.FileSystem.OpenTextFileWriter(My.Application.Info.DirectoryPath & "\Logs\InsOrService_LogFile_" & MainActivities.LogFileDate & ".log", True)
        MainActivities.LogAction = "Start Service"
        file.WriteLine(Format(Now, "yyyy-MM-dd HH:mm:ss") & ": " & MainActivities.LogAction)
        file.Flush()
        If OpenConnection(Con) = False Then
            MainActivities.LogAction = "Error Oppening Connection With Database"
            Call MainActivities.Write2LogFile()
            Exit Sub
        End If
        MainActivities.LogAction = "Succesfull Open Connection With Database"
        Call MainActivities.Write2LogFile()
        MyThread = New Thread(AddressOf MainProcedure)
        MyThread.IsBackground = True
        MyThread.Start()
    End Sub
    Private Sub MainProcedure()
        Do While NonStop = True
            Try
                MainActivities.LogAction = "Start Procees Get_SYMVAN"
                Call MainActivities.Write2LogFile()
                Call Get_SYMVAN()
            Catch ex As Exception
                MainActivities.LogAction = "Error Get_SYMVAN with Error: " & ex.Message
                Call MainActivities.Write2LogFile()
            End Try
            Thread.Sleep(My.Settings.MainThreadTimeOut)
        Loop
    End Sub
    Protected Overrides Sub OnStop()
        NonStop = False
        Try
            MyThread.Abort()
        Catch ex As Exception

        End Try
        MyThread = Nothing
        If Not Reader Is Nothing Then
            Reader.Close()
        End If
        Reader = Nothing
        CommandReader = Nothing
        CommandWriter = Nothing
        If CloseConnaection(Con) = False Then
            MainActivities.LogAction = "Error Closing Connection With Database"
            Call MainActivities.Write2LogFile()
        End If
        MainActivities.LogAction = "Stop Service"
        file.WriteLine(Format(Now, "yyyy-MM-dd HH:mm:ss") & ": " & MainActivities.LogAction)
        file.Close()
        file = Nothing
    End Sub
    Private Sub InitConStr()
        ConStr = ConStr.Replace("@MyServer", My.Settings.DBServer)
    End Sub
    Private Sub Get_SYMVAN()
        Try
            Call LoadSymvanta()
            MainActivities.LogAction = "Succesfully Load New Events "
            Call MainActivities.Write2LogFile()
            Do While Reader.Read
                MainActivities.LogAction = "Start Process Event_ID: " & Reader.Item("SYMBAN_ID") & " And Type: " & Reader.Item("SYMVAN_TYPE")
                Call MainActivities.Write2LogFile()
                Select Case Reader.Item("SYMVAN_TYPE")
                    Case 1  'Ατύχημα
                        Call handle_Accident()
                    Case 2  'Κλοπή
                        Call handle_Non_Accident("Κλοπή")
                    Case 3  'Πυρκαγιά
                        Call handle_Non_Accident("Πυρκαγιά")
                    Case 4  'θραύση Κρυστάλλων
                        Call handle_Non_Accident("θραύση Κρυστάλλων")
                End Select
                MainActivities.LogAction = "End Process Event_ID: " & Reader.Item("SYMBAN_ID") & " And Type: " & Reader.Item("SYMVAN_TYPE")
                Call MainActivities.Write2LogFile()
            Loop
            MainActivities.LogAction = "Succesfully UPDATE New Events and sleep for: " & My.Settings.MainThreadTimeOut
            Call MainActivities.Write2LogFile()
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub handle_Non_Accident(What2Do As String)
        If Reader.Item("SYMBAN_STATUS") = 0 Then
            Call UpDate_Status(1)
            MainActivities.LogAction = "Process Event_ID: " & Reader.Item("SYMBAN_ID") & " And Type: " & Reader.Item("SYMVAN_TYPE") & ", Updating status to 1"
            Call MainActivities.Write2LogFile()
        End If
        If IsDBNull(Reader.Item("KWDPRAGM")) = True Then
            Call AssignExpert()
            MainActivities.LogAction = "Process Event_ID: " & Reader.Item("SYMBAN_ID") & " And Type: " & Reader.Item("SYMVAN_TYPE") & ", Assign an Expert"
            Call MainActivities.Write2LogFile()
        End If
        If IsDBNull(Reader.Item("KLHSH_PRAGM")) = True Then
            Call UpdateSymvan("UpDate KLHSH_Pragm")
            MainActivities.LogAction = "Process Event_ID: " & Reader.Item("SYMBAN_ID") & " And Type: " & Reader.Item("SYMVAN_TYPE") & ", Update Symvan Set TimeStamp KLHSH_PRAGM"
            Call MainActivities.Write2LogFile()
            Call SendEmail(My.Settings.EmailAddress4Pragm, "Email Pragm")
            MainActivities.LogAction = "Process Event_ID: " & Reader.Item("SYMBAN_ID") & " And Type: " & Reader.Item("SYMVAN_TYPE") & ", Send Email to Pragmatognomona"
            Call MainActivities.Write2LogFile()
            Thread.Sleep(My.Settings.EmailTimeOut)
        End If
        Call UpDate_Status(2)
        MainActivities.LogAction = "Process Event_ID: " & Reader.Item("SYMBAN_ID") & " And Type: " & Reader.Item("SYMVAN_TYPE") & ", Updating status to 2"
        Call MainActivities.Write2LogFile()



        Call UpDate_Status(3)
        MainActivities.LogAction = "Process Event_ID: " & Reader.Item("SYMBAN_ID") & " And Type: " & Reader.Item("SYMVAN_TYPE") & ", Updating staus to 3"
        Call MainActivities.Write2LogFile()
        'Select Case What2Do
        '    Case "Κλοπή"

        '    Case "Πυρκαγιά"
        '    Case "θραύση Κρυστάλλων"
        'End Select
    End Sub
    Private Sub handle_Accident()
        Dim Check100 As Boolean = False
        Dim Check166 As Boolean = False
        Dim Check_OD_BOH As Boolean = False
        Dim Check_Pragm As Boolean = False
        If Reader.Item("SYMBAN_STATUS") = 0 Then
            Call UpDate_Status(1)
            MainActivities.LogAction = "Process Event_ID: " & Reader.Item("SYMBAN_ID") & " And Type: " & Reader.Item("SYMVAN_TYPE") & ", Updating status to 1"
            Call MainActivities.Write2LogFile()
        End If
        If IsDBNull(Reader.Item("KWDPRAGM")) = True Then
            Call AssignExpert()
            MainActivities.LogAction = "Process Event_ID: " & Reader.Item("SYMBAN_ID") & " And Type: " & Reader.Item("SYMVAN_TYPE") & ", Assign an Expert"
            Call MainActivities.Write2LogFile()
        End If
        If IsDBNull(Reader.Item("KLHSH_100")) = True Then
            If IsDBNull(Reader.Item("ANAGKH_100")) = False Then
                If Reader.Item("ANAGKH_100") = 1 Then
                    Check100 = True
                    Call UpdateSymvan("UpDate KLHSH100")
                    MainActivities.LogAction = "Process Event_ID: " & Reader.Item("SYMBAN_ID") & " And Type: " & Reader.Item("SYMVAN_TYPE") & ", Update Symvan Set TimeStamp KLHSH_100"
                    Call MainActivities.Write2LogFile()
                    Call SendEmail(My.Settings.EmailAddress4100, "Email 100")
                    MainActivities.LogAction = "Process Event_ID: " & Reader.Item("SYMBAN_ID") & " And Type: " & Reader.Item("SYMVAN_TYPE") & ", Send Email to 100"
                    Call MainActivities.Write2LogFile()
                    Thread.Sleep(My.Settings.EmailTimeOut)
                End If
            End If
        End If
        If IsDBNull(Reader.Item("KLHSH_166")) = True Then
            If IsDBNull(Reader.Item("ANAGKH_166")) = False Then
                If Reader.Item("ANAGKH_166") = 1 Then
                    Check166 = True
                    Call UpdateSymvan("UpDate KLHSH166")
                    MainActivities.LogAction = "Process Event_ID: " & Reader.Item("SYMBAN_ID") & " And Type: " & Reader.Item("SYMVAN_TYPE") & ", Update Symvan Set TimeStamp KLHSH_166"
                    Call MainActivities.Write2LogFile()
                    Call SendEmail(My.Settings.EmailAddress4166, "Email 166")
                    MainActivities.LogAction = "Process Event_ID: " & Reader.Item("SYMBAN_ID") & " And Type: " & Reader.Item("SYMVAN_TYPE") & ", Send Email to 166"
                    Call MainActivities.Write2LogFile()
                    Thread.Sleep(My.Settings.EmailTimeOut)
                End If
            End If
        End If
        If IsDBNull(Reader.Item("KLHSH_OD_BOH8EIA")) = True Then
            If IsDBNull(Reader.Item("ANAGKH_OD_BOH8EIA")) = False Then
                If Reader.Item("ANAGKH_OD_BOH8EIA") = 1 Then
                    Check_OD_BOH = True
                    Call UpdateSymvan("UpDate KLHSH_Od_Boh")
                    MainActivities.LogAction = "Process Event_ID: " & Reader.Item("SYMBAN_ID") & " And Type: " & Reader.Item("SYMVAN_TYPE") & ", Update Symvan Set TimeStamp KLHSH_OD_BOH8EIA"
                    Call MainActivities.Write2LogFile()
                    Call SendEmail(My.Settings.EmailAddressOD_Boh, "Email OD Boh")
                    MainActivities.LogAction = "Process Event_ID: " & Reader.Item("SYMBAN_ID") & " And Type: " & Reader.Item("SYMVAN_TYPE") & ", Send Email to Odiki Boh8eia"
                    Call MainActivities.Write2LogFile()
                    Thread.Sleep(My.Settings.EmailTimeOut)
                End If
            End If
        End If
        If IsDBNull(Reader.Item("KLHSH_PRAGM")) = True Then
            'If IsDBNull(Reader.Item("ANAGKH_NOM_KAL")) = False Then
            'If Reader.Item("ANAGKH_NOM_KAL") = 1 Then
            Check_Pragm = True
                    Call UpdateSymvan("UpDate KLHSH_Pragm")
                    MainActivities.LogAction = "Process Event_ID: " & Reader.Item("SYMBAN_ID") & " And Type: " & Reader.Item("SYMVAN_TYPE") & ", Update Symvan Set TimeStamp KLHSH_PRAGM"
                    Call MainActivities.Write2LogFile()
                    Call SendEmail(My.Settings.EmailAddress4Pragm, "Email Pragm")
                    MainActivities.LogAction = "Process Event_ID: " & Reader.Item("SYMBAN_ID") & " And Type: " & Reader.Item("SYMVAN_TYPE") & ", Send Email to Pragmatognomona"
                    Call MainActivities.Write2LogFile()
                    Thread.Sleep(My.Settings.EmailTimeOut)
            'End If
            'End If
        End If
        Call UpDate_Status(2)
        MainActivities.LogAction = "Process Event_ID: " & Reader.Item("SYMBAN_ID") & " And Type: " & Reader.Item("SYMVAN_TYPE") & ", Updating status to 2"
        Call MainActivities.Write2LogFile()




        Call UpDate_Status(3)
        MainActivities.LogAction = "Process Event_ID: " & Reader.Item("SYMBAN_ID") & " And Type: " & Reader.Item("SYMVAN_TYPE") & ", Updating staus to 3"
        Call MainActivities.Write2LogFile()
    End Sub
    Private Sub UpdateSymvan(What2Do As String)
        Dim SqlString As String = String.Empty
        Dim RecsAff As Integer = 0
        If Reader.Item("SYMVAN_TYPE") = 1 Then
            Select Case What2Do
                Case "UpDate KLHSH100"
                    SqlString = ""
                    SqlString = "Update InsOr_SYMBAN set "
                    SqlString = SqlString & "KLHSH_100=getdate(),OLOKL_100=getdate()"
                    SqlString = SqlString & " where SYMBAN_ID=" & Reader.Item("SYMBAN_ID")
                Case "UpDate KLHSH166"
                    SqlString = ""
                    SqlString = "Update InsOr_SYMBAN set "
                    SqlString = SqlString & "KLHSH_166=getdate(),OLOKL_166=getdate()"
                    SqlString = SqlString & " where SYMBAN_ID=" & Reader.Item("SYMBAN_ID")
                Case "UpDate KLHSH_Od_Boh"
                    SqlString = ""
                    SqlString = "Update InsOr_SYMBAN set "
                    SqlString = SqlString & "KLHSH_OD_BOH8EIA=getdate(),OLOKL_OD_BOH8=getdate()"
                    SqlString = SqlString & " where SYMBAN_ID=" & Reader.Item("SYMBAN_ID")
                Case "UpDate KLHSH_Pragm"
                    SqlString = ""
                    SqlString = "Update InsOr_SYMBAN set "
                    SqlString = SqlString & "KLHSH_PRAGM=getdate(),KLHSH_NOM_PRO=getdate(),OLOKL_PRAGM=getdate(),OLOKL_NOM_PRO=getdate()"
                    SqlString = SqlString & " where SYMBAN_ID=" & Reader.Item("SYMBAN_ID")
            End Select
        Else
            SqlString = ""
            SqlString = "Update InsOr_SYMBAN_DEYTERO set "
            SqlString = SqlString & "KLHSH_PRAGM=getdate(),OLOKL_PRAGM=getdate()"
            SqlString = SqlString & " where SYMBAN_DEYTERO_ID=" & Reader.Item("SYMBAN_ID")
        End If
        Try
            CommandWriter = Nothing
            CommandWriter = New SqlCommand
            CommandWriter.CommandType = CommandType.Text
            CommandWriter.CommandTimeout = My.Settings.CommandTimeOut
            CommandWriter.CommandText = SqlString
            CommandWriter.Connection = Con
            RecsAff = CommandWriter.ExecuteNonQuery
            CommandWriter = Nothing
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub SendEmail(EmailRecepint As String, What2Do As String)
        Dim Body As String = String.Empty
        Dim MyMap As String = String.Empty
        MyMap = "https://www.google.com/maps/place/" & Reader.Item("Lat").ToString.Replace(",", ".") & "," & Reader.Item("Lng").ToString.Replace(",", ".") & "/@" & Reader.Item("Lat").ToString.Replace(",", ".") & "," & Reader.Item("Lng").ToString.Replace(",", ".") & ",75z/data=!3m1!4b1"
        Select Case What2Do
            Case "Email 100"
                Body = "<html>"
                Body = Body & "<body>"
                Body = Body & "<Table border='1'>"
                Body = Body & "<tr>"
                Body = "<b>Υπάρχει ανάγκη να σταλεί επειγόντος περιπολικό του Τημήματος Οδικών Τροχαίων Ατυχημάτων για καταγραφή συμβάντος</b>"
                Body = Body & "</tr>"
                Body = Body & "<tr>"
                Body = Body & "</tr>"
                Body = Body & "<tr>"
                Body = Body & "</tr>"
                Body = Body & "<tr>"
                Body = Body & "<td>"
                Body = Body & "Χρονοσήμανση συμβάντος: "
                Body = Body & "</td>"
                Body = Body & "<td>"
                Body = Body & Format(Reader.Item("HMNIA"), "yyyy-MM-dd") & " " & Reader.Item("WRA").ToString.Substring(0, 8)
                Body = Body & "</td>"
                Body = Body & "</tr>"
                Body = Body & "<tr>"
                Body = Body & "<td>"
                Body = Body & "Γεωγραφικό μήκος τοποθεσίας ατυχήματος: "
                Body = Body & "</td>"
                Body = Body & "<td>"
                Body = Body & Reader.Item("Lat").ToString.Replace(",", ".")
                Body = Body & "</td>"
                Body = Body & "</tr>"
                Body = Body & "<tr>"
                Body = Body & "<td>"
                Body = Body & "Γεωγραφικό πλάτος τοποθεσίας ατυχήματος: "
                Body = Body & "</td>"
                Body = Body & "<td>"
                Body = Body & Reader.Item("Lng").ToString.Replace(",", ".")
                Body = Body & "</td>"
                Body = Body & "</tr>"
                Body = Body & "<tr>"
                Body = Body & "<td>"
                Body = Body & "Ονοματεπώνυμο Οδηγού: "
                Body = Body & "</td>"
                Body = Body & "<td>"
                Body = Body & Reader.Item("Onomatepwnymo")
                Body = Body & "</td>"
                Body = Body & "</tr>"
                Body = Body & "<tr>"
                Body = Body & "<td>"
                Body = Body & "Κινητό Τηλέφωνο Οδηγού: "
                Body = Body & "</td>"
                Body = Body & "<td>"
                Body = Body & Reader.Item("Tel1") & " - " & Reader.Item("Tel2")
                Body = Body & "</td>"
                Body = Body & "</tr>"
                Body = Body & "<tr>"
                Body = Body & "<td>"
                Body = Body & "Αρ Κυκλ Οχήματος: "
                Body = Body & "</td>"
                Body = Body & "<td>"
                Body = Body & Reader.Item("ARKYKL")
                Body = Body & "</td>"
                Body = Body & "</tr>"
                Body = Body & "<tr>"
                Body = Body & "<td>"
                Body = Body & "Μάρκα Οχήματος: "
                Body = Body & "</td>"
                Body = Body & "<td>"
                Body = Body & Reader.Item("MARKA")
                Body = Body & "</td>"
                Body = Body & "</tr>"
                Body = Body & "<tr>"
                Body = Body & "<td>"
                Body = Body & "Τοποθεσία Συμβάντος: "
                Body = Body & "</td>"
                Body = Body & "<td>"
                Body = Body & MyMap
                Body = Body & "</td>"
                Body = Body & "</tr>"
                Body = Body & "</Table>"
                Body = Body & "</body>"
                Body = Body & "</html>"
                Call MainActivities.MySendEmail(EmailRecepint, "Αποστολή Μηνύματος Προς 100", "Τροχαίο Ατύχημα Προς 100", Body)
            Case "Email 166"
                Body = "<html>"
                Body = Body & "<body>"
                Body = Body & "<Table border='1'>"
                Body = Body & "<tr>"
                Body = "<b>Υπάρχει ανάγκη να σταλεί επειγόντος Ασθενοφόρο για παραλαβή τραυματισμένου σε τροχαίο ατύχημα</b>"
                Body = Body & "</tr>"
                Body = Body & "<tr>"
                Body = Body & "</tr>"
                Body = Body & "<tr>"
                Body = Body & "</tr>"
                Body = Body & "<tr>"
                Body = Body & "<td>"
                Body = Body & "Χρονοσήμανση συμβάντος: "
                Body = Body & "</td>"
                Body = Body & "<td>"
                Body = Body & Format(Reader.Item("HMNIA"), "yyyy-MM-dd") & " " & Reader.Item("WRA").ToString.Substring(0, 8)
                Body = Body & "</td>"
                Body = Body & "</tr>"
                Body = Body & "<tr>"
                Body = Body & "<td>"
                Body = Body & "Γεωγραφικό μήκος τοποθεσίας ατυχήματος: "
                Body = Body & "</td>"
                Body = Body & "<td>"
                Body = Body & Reader.Item("Lat").ToString.Replace(",", ".")
                Body = Body & "</td>"
                Body = Body & "</tr>"
                Body = Body & "<tr>"
                Body = Body & "<td>"
                Body = Body & "Γεωγραφικό πλάτος τοποθεσίας ατυχήματος: "
                Body = Body & "</td>"
                Body = Body & "<td>"
                Body = Body & Reader.Item("Lng").ToString.Replace(",", ".")
                Body = Body & "</td>"
                Body = Body & "</tr>"
                Body = Body & "<tr>"
                Body = Body & "<td>"
                Body = Body & "Ονοματεπώνυμο Οδηγού: "
                Body = Body & "</td>"
                Body = Body & "<td>"
                Body = Body & Reader.Item("Onomatepwnymo")
                Body = Body & "</td>"
                Body = Body & "</tr>"
                Body = Body & "<tr>"
                Body = Body & "<td>"
                Body = Body & "Κινητό Τηλέφωνο Οδηγού: "
                Body = Body & "</td>"
                Body = Body & "<td>"
                Body = Body & Reader.Item("Tel1") & " - " & Reader.Item("Tel2")
                Body = Body & "</td>"
                Body = Body & "</tr>"
                Body = Body & "<tr>"
                Body = Body & "<td>"
                Body = Body & "Αρ Κυκλ Οχήματος: "
                Body = Body & "</td>"
                Body = Body & "<td>"
                Body = Body & Reader.Item("ARKYKL")
                Body = Body & "</td>"
                Body = Body & "</tr>"
                Body = Body & "<tr>"
                Body = Body & "<td>"
                Body = Body & "Μάρκα Οχήματος: "
                Body = Body & "</td>"
                Body = Body & "<td>"
                Body = Body & Reader.Item("MARKA")
                Body = Body & "</td>"
                Body = Body & "</tr>"
                Body = Body & "<tr>"
                Body = Body & "<td>"
                Body = Body & "Τοποθεσία Συμβάντος: "
                Body = Body & "</td>"
                Body = Body & "<td>"
                Body = Body & MyMap
                Body = Body & "</td>"
                Body = Body & "</tr>"
                Body = Body & "</Table>"
                Body = Body & "</body>"
                Body = Body & "</html>"
                Call MainActivities.MySendEmail(EmailRecepint, "Αποστολή Μηνύματος Προς 166", "Τροχαίο Ατύχημα Προς 166", Body)
            Case "Email OD Boh"
                Body = "<html>"
                Body = Body & "<body>"
                Body = Body & "<Table border='1'>"
                Body = Body & "<tr>"
                Body = "<b>Υπάρχει ανάγκη να σταλεί επειγόντος φορτηγό μεταφοράς οχήματος σε τροχαίο ατύχημα</b>"
                Body = Body & "</tr>"
                Body = Body & "<tr>"
                Body = Body & "</tr>"
                Body = Body & "<tr>"
                Body = Body & "</tr>"
                Body = Body & "<tr>"
                Body = Body & "<td>"
                Body = Body & "Χρονοσήμανση συμβάντος: "
                Body = Body & "</td>"
                Body = Body & "<td>"
                Body = Body & Format(Reader.Item("HMNIA"), "yyyy-MM-dd") & " " & Reader.Item("WRA").ToString.Substring(0, 8)
                Body = Body & "</td>"
                Body = Body & "</tr>"
                Body = Body & "<tr>"
                Body = Body & "<td>"
                Body = Body & "Γεωγραφικό μήκος τοποθεσίας ατυχήματος: "
                Body = Body & "</td>"
                Body = Body & "<td>"
                Body = Body & Reader.Item("Lat").ToString.Replace(",", ".")
                Body = Body & "</td>"
                Body = Body & "</tr>"
                Body = Body & "<tr>"
                Body = Body & "<td>"
                Body = Body & "Γεωγραφικό πλάτος τοποθεσίας ατυχήματος: "
                Body = Body & "</td>"
                Body = Body & "<td>"
                Body = Body & Reader.Item("Lng").ToString.Replace(",", ".")
                Body = Body & "</td>"
                Body = Body & "</tr>"
                Body = Body & "<tr>"
                Body = Body & "<td>"
                Body = Body & "Ονοματεπώνυμο Οδηγού: "
                Body = Body & "</td>"
                Body = Body & "<td>"
                Body = Body & Reader.Item("Onomatepwnymo")
                Body = Body & "</td>"
                Body = Body & "</tr>"
                Body = Body & "<tr>"
                Body = Body & "<td>"
                Body = Body & "Κινητό Τηλέφωνο Οδηγού: "
                Body = Body & "</td>"
                Body = Body & "<td>"
                Body = Body & Reader.Item("Tel1") & " - " & Reader.Item("Tel2")
                Body = Body & "</td>"
                Body = Body & "</tr>"
                Body = Body & "<tr>"
                Body = Body & "<td>"
                Body = Body & "Αρ Κυκλ Οχήματος: "
                Body = Body & "</td>"
                Body = Body & "<td>"
                Body = Body & Reader.Item("ARKYKL")
                Body = Body & "</td>"
                Body = Body & "</tr>"
                Body = Body & "<tr>"
                Body = Body & "<td>"
                Body = Body & "Μάρκα Οχήματος: "
                Body = Body & "</td>"
                Body = Body & "<td>"
                Body = Body & Reader.Item("MARKA")
                Body = Body & "</td>"
                Body = Body & "</tr>"
                Body = Body & "<tr>"
                Body = Body & "<td>"
                Body = Body & "Τοποθεσία Συμβάντος: "
                Body = Body & "</td>"
                Body = Body & "<td>"
                Body = Body & MyMap
                Body = Body & "</td>"
                Body = Body & "</tr>"
                Body = Body & "</Table>"
                Body = Body & "</body>"
                Body = Body & "</html>"
                Call MainActivities.MySendEmail(EmailRecepint, "Αποστολή Μηνύματος Προς Οδική Βοήθεια", "Τροχαίο Ατύχημα Προς Οδική Βοήθεια", Body)
            Case "Email Pragm"
                Body = "<html>"
                Body = Body & "<body>"
                Body = Body & "<Table border='1'>"
                Body = Body & "<tr>"
                Body = "<b>Υπάρχει ανάγκη να μεταβείτε σε τροχαίο ατύχημα με τα παρακάτω στοιχεία</b>"
                Body = Body & "</tr>"
                Body = Body & "<tr>"
                Body = Body & "</tr>"
                Body = Body & "<tr>"
                Body = Body & "</tr>"
                Body = Body & "<tr>"
                Body = Body & "<td>"
                Body = Body & "Χρονοσήμανση συμβάντος: "
                Body = Body & "</td>"
                Body = Body & "<td>"
                Body = Body & Format(Reader.Item("HMNIA"), "yyyy-MM-dd") & " " & Reader.Item("WRA").ToString.Substring(0, 8)
                Body = Body & "</td>"
                Body = Body & "</tr>"
                Body = Body & "<tr>"
                Body = Body & "<td>"
                Body = Body & "Γεωγραφικό μήκος τοποθεσίας ατυχήματος: "
                Body = Body & "</td>"
                Body = Body & "<td>"
                Body = Body & Reader.Item("Lat").ToString.Replace(",", ".")
                Body = Body & "</td>"
                Body = Body & "</tr>"
                Body = Body & "<tr>"
                Body = Body & "<td>"
                Body = Body & "Γεωγραφικό πλάτος τοποθεσίας ατυχήματος: "
                Body = Body & "</td>"
                Body = Body & "<td>"
                Body = Body & Reader.Item("Lng").ToString.Replace(",", ".")
                Body = Body & "</td>"
                Body = Body & "</tr>"
                Body = Body & "<tr>"
                Body = Body & "<td>"
                Body = Body & "Ονοματεπώνυμο Οδηγού: "
                Body = Body & "</td>"
                Body = Body & "<td>"
                Body = Body & Reader.Item("Onomatepwnymo")
                Body = Body & "</td>"
                Body = Body & "</tr>"
                Body = Body & "<tr>"
                Body = Body & "<td>"
                Body = Body & "Κινητό Τηλέφωνο Οδηγού: "
                Body = Body & "</td>"
                Body = Body & "<td>"
                Body = Body & Reader.Item("Tel1") & " - " & Reader.Item("Tel2")
                Body = Body & "</td>"
                Body = Body & "</tr>"
                Body = Body & "<tr>"
                Body = Body & "<td>"
                Body = Body & "Αρ Κυκλ Οχήματος: "
                Body = Body & "</td>"
                Body = Body & "<td>"
                Body = Body & Reader.Item("ARKYKL")
                Body = Body & "</td>"
                Body = Body & "</tr>"
                Body = Body & "<tr>"
                Body = Body & "<td>"
                Body = Body & "Μάρκα Οχήματος: "
                Body = Body & "</td>"
                Body = Body & "<td>"
                Body = Body & Reader.Item("MARKA")
                Body = Body & "</td>"
                Body = Body & "</tr>"
                Body = Body & "<tr>"
                Body = Body & "<td>"
                Body = Body & "Τοποθεσία Συμβάντος: "
                Body = Body & "</td>"
                Body = Body & "<td>"
                Body = Body & MyMap
                Body = Body & "</td>"
                Body = Body & "</tr>"
                Body = Body & "</Table>"
                Body = Body & "</body>"
                Body = Body & "</html>"
                Call MainActivities.MySendEmail(EmailRecepint, "Αποστολή Μηνύματος Προς Οδική Βοήθεια", "Τροχαίο Ατύχημα Προς Πραγματογνώμονα", Body)
            Case "Email XXX"
                'Body = "<html>"
                'Body = Body & "<body>"
                'Body = Body & "<Table border='1'>"
                'Body = Body & "<tr>"
                'Body = "<b>Υπάρχει ανάγκη να μεταβείτε σε τροχαίο ατύχημα με τα παρακάτω στοιχεία</b>"
                'Body = Body & "</tr>"
                'Body = Body & "<tr>"
                'Body = Body & "</tr>"
                'Body = Body & "<tr>"
                'Body = Body & "</tr>"
                'Body = Body & "<tr>"
                'Body = Body & "<td>"
                'Body = Body & "Χρονοσήμανση συμβάντος: "
                'Body = Body & "</td>"
                'Body = Body & "<td>"
                'Body = Body & Format(Reader.Item("HMNIA"), "yyyy-MM-dd") & " " & Reader.Item("WRA").ToString.Substring(0, 8)
                'Body = Body & "</td>"
                'Body = Body & "</tr>"
                'Body = Body & "<tr>"
                'Body = Body & "<td>"
                'Body = Body & "Γεωγραφικό μήκος τοποθεσίας ατυχήματος: "
                'Body = Body & "</td>"
                'Body = Body & "<td>"
                'Body = Body & Reader.Item("Lat").ToString.Replace(",", ".")
                'Body = Body & "</td>"
                'Body = Body & "</tr>"
                'Body = Body & "<tr>"
                'Body = Body & "<td>"
                'Body = Body & "Γεωγραφικό πλάτος τοποθεσίας ατυχήματος: "
                'Body = Body & "</td>"
                'Body = Body & "<td>"
                'Body = Body & Reader.Item("Lng").ToString.Replace(",", ".")
                'Body = Body & "</td>"
                'Body = Body & "</tr>"
                'Body = Body & "<tr>"
                'Body = Body & "<td>"
                'Body = Body & "Ονοματεπώνυμο Οδηγού: "
                'Body = Body & "</td>"
                'Body = Body & "<td>"
                'Body = Body & Reader.Item("Onomatepwnymo")
                'Body = Body & "</td>"
                'Body = Body & "</tr>"
                'Body = Body & "<tr>"
                'Body = Body & "<td>"
                'Body = Body & "Κινητό Τηλέφωνο Οδηγού: "
                'Body = Body & "</td>"
                'Body = Body & "<td>"
                'Body = Body & Reader.Item("Tel1") & " - " & Reader.Item("Tel2")
                'Body = Body & "</td>"
                'Body = Body & "</tr>"
                'Body = Body & "<tr>"
                'Body = Body & "<td>"
                'Body = Body & "Αρ Κυκλ Οχήματος: "
                'Body = Body & "</td>"
                'Body = Body & "<td>"
                'Body = Body & Reader.Item("ARKYKL")
                'Body = Body & "</td>"
                'Body = Body & "</tr>"
                'Body = Body & "<tr>"
                'Body = Body & "<td>"
                'Body = Body & "Μάρκα Οχήματος: "
                'Body = Body & "</td>"
                'Body = Body & "<td>"
                'Body = Body & Reader.Item("MARKA")
                'Body = Body & "</td>"
                'Body = Body & "</tr>"
                'Body = Body & "<tr>"
                'Body = Body & "<td>"
                'Body = Body & "Τοποθεσία Συμβάντος: "
                'Body = Body & "</td>"
                'Body = Body & "<td>"
                'Body = Body & MyMap
                'Body = Body & "</td>"
                'Body = Body & "</tr>"
                'Body = Body & "</Table>"
                'Body = Body & "</body>"
                'Body = Body & "</html>"
                'Call MainActivities.MySendEmail(My.Settings.EmailAddress4Pragm, "Αποστολή Μηνύματος Προς Οδική Βοήθεια", "Τροχαίο Ατύχημα Προς Πραγματογνώμονα", Body)
        End Select
    End Sub
    Private Sub UpDate_Status(Status As Short)
        Dim SqlString As String = String.Empty
        Dim RecsAff As Integer = 0
        If Reader.Item("SYMVAN_TYPE") = 1 Then
            SqlString = "Update InsOr_SYMBAN set SYMBAN_STATUS=" & Status & " where SYMBAN_ID=" & Reader.Item("SYMBAN_ID")
        Else
            SqlString = "Update InsOr_SYMBAN_DEYTERO set SYMBAN_DEYTERO_STATUS=" & Status & " where SYMBAN_DEYTERO_ID=" & Reader.Item("SYMBAN_ID")
        End If
        Try
            CommandWriter = Nothing
            CommandWriter = New SqlCommand
            CommandWriter.CommandType = CommandType.Text
            CommandWriter.CommandTimeout = My.Settings.CommandTimeOut
            CommandWriter.CommandText = SqlString
            CommandWriter.Connection = Con
            RecsAff = CommandWriter.ExecuteNonQuery
            CommandWriter = Nothing
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub AssignExpert()
        Dim SqlString As String = String.Empty
        Dim RecsAff As Short = 0
        If Reader.Item("SYMVAN_TYPE") = 1 Then
            SqlString = "Update InsOr_SYMBAN set KWDPRAGM=(Select top 1 KWD_PRAGM from InsOr_PRAGMAT where DIA8ESIMOS=1 order by KWD_PRAGM) where SYMBAN_ID=" & Reader.Item("SYMBAN_ID")
        Else
            SqlString = "Update InsOr_SYMBAN_DEYTERO set KWD_PRAGM=(Select top 1 KWD_PRAGM from InsOr_PRAGMAT where DIA8ESIMOS=1 order by KWD_PRAGM)  where SYMBAN_DEYTERO_ID=" & Reader.Item("SYMBAN_ID")
        End If
        Try
            CommandWriter = Nothing
            CommandWriter = New SqlCommand
            CommandWriter.CommandType = CommandType.Text
            CommandWriter.CommandTimeout = My.Settings.CommandTimeOut
            CommandWriter.CommandText = SqlString
            CommandWriter.Connection = Con
            RecsAff = CommandWriter.ExecuteNonQuery
            CommandWriter = Nothing
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
    Private Sub LoadSymvanta()
        Dim SqlString As String = String.Empty
        SqlString = ""
        SqlString = "Select "
        SqlString = SqlString & " SYMBAN_ID as SYMBAN_ID,"
        SqlString = SqlString & " 1 As SYMVAN_TYPE,"
        SqlString = SqlString & " isnull(SYMBAN_STATUS, 0) As SYMBAN_STATUS,"
        SqlString = SqlString & " HMNIA as HMNIA,"
        SqlString = SqlString & " WRA As WRA,"
        SqlString = SqlString & " Symvan.KWDPEL as KWDPEL,"
        SqlString = SqlString & " PELATHS.EPWNYMO + ' ' + PELATHS.ONOMA as Onomatepwnymo,"
        SqlString = SqlString & " SYMBOLAIO.KWDSYM	As KWDSYM,"
        SqlString = SqlString & " SYMBOLAIO.MARKA As MARKA,"
        SqlString = SqlString & " SYMBOLAIO.ARKYKL As ARKYKL,"
        SqlString = SqlString & " Lat as Lat,"
        SqlString = SqlString & " Lng As Lng,"
        SqlString = SqlString & " Tel1 as Tel1,"
        SqlString = SqlString & " Tel2 As Tel2,"
        SqlString = SqlString & " YPAITIOTHTA as YPAITIOTHTA,"
        SqlString = SqlString & " FIL_DIAK As FIL_DIAK,"
        SqlString = SqlString & " EMPLEK_AR_KYKL as EMPLEK_AR_KYKL,"
        SqlString = SqlString & " EMPLEK_ONOMAT As EMPLEK_ONOMAT,"
        SqlString = SqlString & " FIL_DIAK_PARAT as FIL_DIAK_PARAT,"
        SqlString = SqlString & " KWDPRAGM As KWDPRAGM,"
        SqlString = SqlString & " ANAGKH_166 as ANAGKH_166,"
        SqlString = SqlString & " ANAGKH_100 As ANAGKH_100,"
        SqlString = SqlString & " ANAGKH_OD_BOH8EIA as ANAGKH_OD_BOH8EIA,"
        SqlString = SqlString & " ANAGKH_NOM_KAL As ANAGKH_NOM_KAL,"
        SqlString = SqlString & " KLHSH_166 as KLHSH_166,"
        SqlString = SqlString & " KLHSH_100 As KLHSH_100,"
        SqlString = SqlString & " KLHSH_OD_BOH8EIA as KLHSH_OD_BOH8EIA,"
        SqlString = SqlString & " KLHSH_NOM_PRO As KLHSH_NOM_PRO,"
        SqlString = SqlString & " KLHSH_PRAGM As KLHSH_PRAGM,"
        SqlString = SqlString & " OLOKL_166 As OLOKL_166,"
        SqlString = SqlString & " OLOKL_100 as OLOKL_100,"
        SqlString = SqlString & " OLOKL_OD_BOH8 As OLOKL_OD_BOH8,"
        SqlString = SqlString & " OLOKL_NOM_PRO as OLOKL_NOM_PRO,"
        SqlString = SqlString & " OLOKL_PRAGM As OLOKL_PRAGM,"
        SqlString = SqlString & " null as SYMBAN_DEYTERO_TEXT"
        SqlString = SqlString & " from"
        SqlString = SqlString & " InsOr_SYMBAN as Symvan inner join InsOr_PELATHS as PELATHS"
        SqlString = SqlString & " on Symvan.KWDPEL=PELATHS.ENKWDPEL"
        SqlString = SqlString & " inner join InsOr_SYMBOLAIO as SYMBOLAIO"
        SqlString = SqlString & " on Symvan.KWDSYM=SYMBOLAIO.KWDSYM"
        SqlString = SqlString & " where"
        SqlString = SqlString & " (SYMBAN_STATUS Is null Or SYMBAN_STATUS<3)"
        SqlString = SqlString & " union all"
        SqlString = SqlString & " Select"
        SqlString = SqlString & " SYMBAN_DEYTERO_ID As SYMBAN_ID,"
        SqlString = SqlString & " Case SYMBAN_DEYTERO_TYPE When 1 Then 2 When 2 Then 3 When 3 Then 4 End As SYMVAN_TYPE,"
        SqlString = SqlString & " isnull(SYMBAN_DEYTERO_STATUS, 0) As SYMBAN_STATUS,"
        SqlString = SqlString & " HMNIA As HMNIA,"
        SqlString = SqlString & " WRA As WRA,"
        SqlString = SqlString & " Symvan.KWDPEL As KWDPEL,"
        SqlString = SqlString & " PELATHS.EPWNYMO + ' ' + PELATHS.ONOMA   as Onomatepwnymo,"
        SqlString = SqlString & " SYMBOLAIO.KWDSYM As KWDSYM,"
        SqlString = SqlString & " SYMBOLAIO.MARKA As MARKA,"
        SqlString = SqlString & " SYMBOLAIO.ARKYKL As ARKYKL,"
        SqlString = SqlString & " null as Lat,"
        SqlString = SqlString & " null As Lng,"
        SqlString = SqlString & " null as Tel1,"
        SqlString = SqlString & " null As Tel2,"
        SqlString = SqlString & " null as YPAITIOTHTA,"
        SqlString = SqlString & " null As FIL_DIAK,"
        SqlString = SqlString & " null as EMPLEK_AR_KYKL,"
        SqlString = SqlString & " null As EMPLEK_ONOMAT,"
        SqlString = SqlString & " null as FIL_DIAK_PARAT,"
        SqlString = SqlString & " KWD_PRAGM As KWDPRAGM,"
        SqlString = SqlString & " null as ANAGKH_166,"
        SqlString = SqlString & " null As ANAGKH_100,"
        SqlString = SqlString & " null as ANAGKH_OD_BOH8EIA,"
        SqlString = SqlString & " null As ANAGKH_NOM_KAL,"
        SqlString = SqlString & " null as KLHSH_166,"
        SqlString = SqlString & " null As KLHSH_100,"
        SqlString = SqlString & " null as KLHSH_OD_BOH8EIA,"
        SqlString = SqlString & " null As KLHSH_NOM_PRO,"
        SqlString = SqlString & " KLHSH_PRAGM as KLHSH_PRAGM,"
        SqlString = SqlString & " null As OLOKL_166,"
        SqlString = SqlString & " null as OLOKL_100,"
        SqlString = SqlString & " null As OLOKL_OD_BOH8,"
        SqlString = SqlString & " null as OLOKL_NOM_PRO,"
        SqlString = SqlString & " OLOKL_PRAGM As OLOKL_PRAGM,"
        SqlString = SqlString & " SYMBAN_DEYTERO_TEXT as SYMBAN_DEYTERO_TEXT"
        SqlString = SqlString & " from InsOr_SYMBAN_DEYTERO as Symvan inner join InsOr_PELATHS as PELATHS"
        SqlString = SqlString & " on Symvan.KWDPEL=PELATHS.ENKWDPEL"
        SqlString = SqlString & " inner join InsOr_SYMBOLAIO as SYMBOLAIO"
        SqlString = SqlString & " on Symvan.KWDSYM=SYMBOLAIO.KWDSYM"
        SqlString = SqlString & " where"
        SqlString = SqlString & " (SYMBAN_DEYTERO_STATUS Is null Or SYMBAN_DEYTERO_STATUS<3)"
        SqlString = SqlString & " order by SYMBAN_ID"
        Try
            CommandReader = Nothing
            CommandReader = New SqlCommand
            CommandReader.CommandType = CommandType.Text
            CommandReader.Connection = Con
            CommandReader.CommandTimeout = My.Settings.CommandTimeOut
            CommandReader.CommandText = SqlString
            Reader = CommandReader.ExecuteReader
        Catch ex As Exception
            Throw ex
        End Try
    End Sub
End Class
