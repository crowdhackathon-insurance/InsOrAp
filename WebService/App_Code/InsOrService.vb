Imports System.Web
Imports System.Web.Services
Imports System.Web.Services.Protocols
Imports System.Data
Imports System.Data.SqlClient

<WebService(Namespace:="http://tempuri.org/")> _
<WebServiceBinding(ConformsTo:=WsiProfiles.BasicProfile1_1)> _
<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Public Class Service
    Inherits System.Web.Services.WebService

    <WebMethod()> _
    Public Function SignUp(ByVal ClientID As String, ByVal KeyNumber As String, ByVal HashCode As String) As String
        Return MySignUp(ClientID, KeyNumber, HashCode, "SignUp_")
    End Function

    <WebMethod()> _
    Public Function GetCarList(ByVal ClientID As String, ByVal KeyNumber As String, ByVal HashCode As String) As ClientCarList
        Dim MyCarList As New ClientCarList
        If MySignUp(ClientID, KeyNumber, HashCode, "SignUp_") = "1" Then
            Return MyGetCarList(ClientID, KeyNumber, HashCode)
        Else
            Return MyCarList
        End If
    End Function

    <WebMethod()> _
    Public Function CheckboxAccess(ByVal ClientID As String, ByVal KeyNumber As String, ByVal HashCode As String, ByVal Symvolaio_ID As String) As Boolean()
        Dim Checkbox() As Boolean
        ReDim Preserve Checkbox(0)
        Checkbox(0) = False
        If MySignUp(ClientID, KeyNumber, HashCode, "SignUp_") = "1" Then
            Return MyCheckboxAccess(ClientID, KeyNumber, HashCode, Symvolaio_ID)
        Else
            Return Checkbox
        End If
    End Function

    <WebMethod()> _
    Public Function SubmitData(ByVal ClientID As String, ByVal KeyNumber As String, ByVal HashCode As String, ByVal Symvolaio_ID As String, _
                                phone1 As String, phone2 As String, CheckBoxes() As Boolean, Latitude As String, Longitude As String) As String
        Dim ConStr As String = System.Configuration.ConfigurationManager.ConnectionStrings("myConnectionString").ConnectionString
        Dim TimeOut As Integer = System.Configuration.ConfigurationManager.AppSettings.Get("TimeOut")
        Dim RecsAff As Integer = 0
        Dim Con As SqlClient.SqlConnection = Nothing
        Dim Command As SqlCommand = Nothing
        Dim SqlString As String = String.Empty
        If MySignUp(ClientID, KeyNumber, HashCode, "SignUp_") = "1" Then
            Try
                Con = New SqlConnection(ConStr)
                Con.Open()
                SqlString = "Insert Into InsOr_SYMBAN"
                SqlString = SqlString & " (HMNIA,WRA,KWDPEL,KWDSYM,Lat,Lng,Tel1,Tel2,ANAGKH_166,ANAGKH_100,ANAGKH_OD_BOH8EIA,ANAGKH_NOM_KAL,YPAITIOTHTA)"
                SqlString = SqlString & " values "
                SqlString = SqlString & "(getdate(),getdate()," & ClientID.Replace("'", "") & ",'" & Symvolaio_ID.Replace("'", "") & "'," & Latitude.Replace(",", ".") & "," & _
                                        Longitude.Replace(",", ".") & "," & _
                                        "'" & phone1.Replace("'", "") & "'," & _
                                        "'" & phone2.Replace("'", "") & "'," & _
                                        IIf(CheckBoxes(0) = True, 1, 0) & "," & _
                                        IIf(CheckBoxes(1) = True, 1, 0) & "," & _
                                        IIf(CheckBoxes(2) = True, 1, 0) & "," & IIf(CheckBoxes(3) = True, 1, 0) & _
                                        "," & IIf(CheckBoxes(4) = True, 1, 0) & ")"
                Command = New SqlCommand
                Command.Connection = Con
                Command.CommandTimeout = TimeOut
                Command.CommandType = CommandType.Text
                Command.CommandText = SqlString
                RecsAff = Command.ExecuteNonQuery
                SqlString = "Insert Into InsOr_Log_File"
                SqlString = SqlString & " (Log_Date,Log_Time,Log_Text)"
                SqlString = SqlString & " values "
                SqlString = SqlString & "(getdate(),getdate(),'" & "SubmitData_Result=1 ClientID=" & ClientID.Replace("'", "") & _
                                        ", KeyNumber=" & KeyNumber.Replace("'", "") & ", HashCode=" & HashCode.Replace("'", "") & _
                                        ", Symvolaio_ID=" & Symvolaio_ID.Replace("'", "") & ", phone1=" & phone1 & ", phone2=" & phone2 & _
                                        ", ANAGKH_166=" & CheckBoxes(0) & ", ANAGKH_100=" & CheckBoxes(1) & _
                                        ", ANAGKH_OD_BOH8EIA=" & CheckBoxes(2) & ", ANAGKH_NOM_KAL=" & CheckBoxes(3) & _
                                        ", YPAITIOTHTA=" & CheckBoxes(4) & _
                                        ", Lat=" & Latitude.Replace("'", "") & ", Lng=" & Longitude.Replace("'", "") & "')"
                Command = Nothing
                Command = New SqlCommand
                Command.Connection = Con
                Command.CommandTimeout = TimeOut
                Command.CommandType = CommandType.Text
                Command.CommandText = SqlString
                RecsAff = Command.ExecuteNonQuery
                Con.Close()
                Command = Nothing
                Con = Nothing
                Return "1"
            Catch ex As Exception
                If Con.State = ConnectionState.Open Then
                    SqlString = "Insert Into InsOr_Log_File"
                    SqlString = SqlString & " (Log_Date,Log_Time,Log_Text)"
                    SqlString = SqlString & " values "
                    SqlString = SqlString & "(getdate(),getdate(),'SubmitData_Error: " & ex.Message.Replace("'", "") & ", ClientID=" & ClientID.Replace("'", "") & _
                                        ", KeyNumber=" & KeyNumber.Replace("'", "") & ", HashCode=" & HashCode.Replace("'", "") & _
                                        ", Symvolaio_ID=" & Symvolaio_ID.Replace("'", "") & ", phone1=" & phone1 & ", phone2=" & phone2 & _
                                        ", ANAGKH_166=" & CheckBoxes(0) & ", ANAGKH_100=" & CheckBoxes(1) & _
                                        ", ANAGKH_OD_BOH8EIA=" & CheckBoxes(2) & ", ANAGKH_NOM_KAL=" & CheckBoxes(3) & _
                                        ", YPAITIOTHTA=" & CheckBoxes(4) & _
                                        ", Lat=" & Latitude & ", Lng=" & Longitude & "')"
                    Command = Nothing
                    Command = New SqlCommand
                    Command.Connection = Con
                    Command.CommandTimeout = TimeOut
                    Command.CommandType = CommandType.Text
                    Command.CommandText = SqlString
                    RecsAff = Command.ExecuteNonQuery
                End If
                Con.Close()
                Command = Nothing
                Con = Nothing
                Return "0"
            End Try
        Else
            Return "0"
        End If
    End Function

    <WebMethod()> _
    Public Function SubmitDataExtended(ByVal ClientID As String, ByVal KeyNumber As String, ByVal HashCode As String, ByVal Symvolaio_ID As String, _
                                        phone1 As String, phone2 As String, CheckBoxes() As Boolean, Latitude As String, Longitude As String, _
                                        FriendlyArrangementLicensePlate As String, FriendlyArrangementName As String, _
                                        FriendlyArrangementComments As String) As String
        Dim ConStr As String = System.Configuration.ConfigurationManager.ConnectionStrings("myConnectionString").ConnectionString
        Dim TimeOut As Integer = System.Configuration.ConfigurationManager.AppSettings.Get("TimeOut")
        Dim RecsAff As Integer = 0
        Dim Con As SqlClient.SqlConnection = Nothing
        Dim Command As SqlCommand = Nothing
        Dim SqlString As String = String.Empty
        If MySignUp(ClientID, KeyNumber, HashCode, "SignUp_") = "1" Then
            Try
                Con = New SqlConnection(ConStr)
                Con.Open()
                SqlString = "Insert Into InsOr_SYMBAN"
                SqlString = SqlString & " (HMNIA,WRA,KWDPEL,KWDSYM,Lat,Lng,Tel1,Tel2,ANAGKH_166,ANAGKH_100,ANAGKH_OD_BOH8EIA,ANAGKH_NOM_KAL,YPAITIOTHTA," & _
                                        "FIL_DIAK,EMPLEK_AR_KYKL,EMPLEK_ONOMAT,FIL_DIAK_PARAT)"
                SqlString = SqlString & " values "
                SqlString = SqlString & "(getdate(),getdate()," & ClientID.Replace("'", "") & ",'" & Symvolaio_ID.Replace("'", "") & "'," & Latitude.Replace(",", ".") & "," & _
                                        Longitude.Replace(",", ".") & "," & _
                                        "'" & phone1.Replace("'", "") & "'," & _
                                        "'" & phone2.Replace("'", "") & "'," & _
                                        IIf(CheckBoxes(0) = True, 1, 0) & "," & _
                                        IIf(CheckBoxes(1) = True, 1, 0) & "," & _
                                        IIf(CheckBoxes(2) = True, 1, 0) & "," & IIf(CheckBoxes(3) = True, 1, 0) & _
                                        "," & IIf(CheckBoxes(4) = True, 1, 0) & _
                                        ",1," & _
                                        "'" & FriendlyArrangementLicensePlate & "'," & _
                                        "'" & FriendlyArrangementName & "'," & _
                                        "'" & FriendlyArrangementComments & "'" & _
                                        ")"
                Command = New SqlCommand
                Command.Connection = Con
                Command.CommandTimeout = TimeOut
                Command.CommandType = CommandType.Text
                Command.CommandText = SqlString
                RecsAff = Command.ExecuteNonQuery
                SqlString = "Insert Into InsOr_Log_File"
                SqlString = SqlString & " (Log_Date,Log_Time,Log_Text)"
                SqlString = SqlString & " values "
                SqlString = SqlString & "(getdate(),getdate(),'" & "SubmitData_Result=1 ClientID=" & ClientID.Replace("'", "") & _
                                        ", KeyNumber=" & KeyNumber.Replace("'", "") & ", HashCode=" & HashCode.Replace("'", "") & _
                                        ", Symvolaio_ID=" & Symvolaio_ID.Replace("'", "") & ", phone1=" & phone1 & ", phone2=" & phone2 & _
                                        ", ANAGKH_166=" & CheckBoxes(0) & ", ANAGKH_100=" & CheckBoxes(1) & _
                                        ", ANAGKH_OD_BOH8EIA=" & CheckBoxes(2) & ", ANAGKH_NOM_KAL=" & CheckBoxes(3) & _
                                        ", YPAITIOTHTA=" & CheckBoxes(4) & _
                                        ", Lat=" & Latitude.Replace("'", "") & ", Lng=" & Longitude.Replace("'", "") & _
                                        ", FriendlyArrangementLicensePlate=" & FriendlyArrangementLicensePlate & _
                                        ", FriendlyArrangementName=" & FriendlyArrangementName & _
                                        ", FriendlyArrangementComments=" & FriendlyArrangementComments & _
                                        "')"
                Command = Nothing
                Command = New SqlCommand
                Command.Connection = Con
                Command.CommandTimeout = TimeOut
                Command.CommandType = CommandType.Text
                Command.CommandText = SqlString
                RecsAff = Command.ExecuteNonQuery
                Con.Close()
                Command = Nothing
                Con = Nothing
                Return "1"
            Catch ex As Exception
                If Con.State = ConnectionState.Open Then
                    SqlString = "Insert Into InsOr_Log_File"
                    SqlString = SqlString & " (Log_Date,Log_Time,Log_Text)"
                    SqlString = SqlString & " values "
                    SqlString = SqlString & "(getdate(),getdate(),'SubmitData_Error: " & ex.Message.Replace("'", "") & ", ClientID=" & ClientID.Replace("'", "") & _
                                       ", KeyNumber=" & KeyNumber.Replace("'", "") & ", HashCode=" & HashCode.Replace("'", "") & _
                                        ", Symvolaio_ID=" & Symvolaio_ID.Replace("'", "") & ", phone1=" & phone1 & ", phone2=" & phone2 & _
                                        ", ANAGKH_166=" & CheckBoxes(0) & ", ANAGKH_100=" & CheckBoxes(1) & _
                                        ", ANAGKH_OD_BOH8EIA=" & CheckBoxes(2) & ", ANAGKH_NOM_KAL=" & CheckBoxes(3) & _
                                        ", YPAITIOTHTA=" & CheckBoxes(4) & _
                                        ", Lat=" & Latitude.Replace("'", "") & ", Lng=" & Longitude.Replace("'", "") & _
                                        ", FriendlyArrangementLicensePlate=" & FriendlyArrangementLicensePlate & _
                                        ", FriendlyArrangementName=" & FriendlyArrangementName & _
                                        ", FriendlyArrangementComments=" & FriendlyArrangementComments & _
                                        "')"
                    Command = Nothing
                    Command = New SqlCommand
                    Command.Connection = Con
                    Command.CommandTimeout = TimeOut
                    Command.CommandType = CommandType.Text
                    Command.CommandText = SqlString
                    RecsAff = Command.ExecuteNonQuery
                End If
                Con.Close()
                Command = Nothing
                Con = Nothing
                Return "0"
            End Try
        Else
            Return "0"
        End If
    End Function

    <WebMethod()> _
    Public Function SubmitProblem(ByVal ClientID As String, ByVal KeyNumber As String, ByVal HashCode As String, ByVal Symvolaio_ID As String, _
                                  ProblemType As Integer, ByVal Shatter As String) As String
        Dim ConStr As String = System.Configuration.ConfigurationManager.ConnectionStrings("myConnectionString").ConnectionString
        Dim TimeOut As Integer = System.Configuration.ConfigurationManager.AppSettings.Get("TimeOut")
        Dim RecsAff As Integer = 0
        Dim Con As SqlClient.SqlConnection = Nothing
        Dim Command As SqlCommand = Nothing
        Dim SqlString As String = String.Empty
        If MySignUp(ClientID, KeyNumber, HashCode, "SignUp_") = "1" Then
            Try
                Con = New SqlConnection(ConStr)
                Con.Open()
                SqlString = "Insert Into InsOr_SYMBAN_DEYTERO"
                SqlString = SqlString & " (SYMBAN_DEYTERO_TYPE,HMNIA,WRA,KWDPEL,KWDSYM,SYMBAN_DEYTERO_TEXT)"
                SqlString = SqlString & " values "
                SqlString = SqlString & "(" & ProblemType & ","
                SqlString = SqlString & "getdate()" & ","
                SqlString = SqlString & "getdate()" & ","
                SqlString = SqlString & ClientID.Replace("'", "") & ","
                SqlString = SqlString & "'" & Symvolaio_ID.Replace("'", "") & "',"
                If Shatter.Trim() = "" Then
                    SqlString = SqlString & "null"
                Else
                    SqlString = SqlString & "'" & Shatter & "'"
                End If
                SqlString = SqlString & ")"
                Command = New SqlCommand
                Command.Connection = Con
                Command.CommandTimeout = TimeOut
                Command.CommandType = CommandType.Text
                Command.CommandText = SqlString
                RecsAff = Command.ExecuteNonQuery
                SqlString = "Insert Into InsOr_Log_File"
                SqlString = SqlString & " (Log_Date,Log_Time,Log_Text)"
                SqlString = SqlString & " values "
                SqlString = SqlString & "(getdate(),getdate(),'" & "SubmitProblem_Result=1 ClientID=" & ClientID.Replace("'", "") & _
                                        ", KeyNumber=" & KeyNumber.Replace("'", "") & ", HashCode=" & HashCode.Replace("'", "") & _
                                        ", Symvolaio_ID=" & Symvolaio_ID.Replace("'", "") & ", ProblemType=" & ProblemType & _
                                        ", Shatter=" & Shatter & _
                                        "')"
                Command = Nothing
                Command = New SqlCommand
                Command.Connection = Con
                Command.CommandTimeout = TimeOut
                Command.CommandType = CommandType.Text
                Command.CommandText = SqlString
                RecsAff = Command.ExecuteNonQuery
                Con.Close()
                Command = Nothing
                Con = Nothing
                Return "1"
            Catch ex As Exception
                If Con.State = ConnectionState.Open Then
                    SqlString = "Insert Into InsOr_Log_File"
                    SqlString = SqlString & " (Log_Date,Log_Time,Log_Text)"
                    SqlString = SqlString & " values "
                    SqlString = SqlString & "(getdate(),getdate(),'SubmitProblem__Error: " & ex.Message.Replace("'", "") & ", ClientID=" & ClientID.Replace("'", "") & _
                                       ", KeyNumber=" & KeyNumber.Replace("'", "") & ", HashCode=" & HashCode.Replace("'", "") & _
                                        ", Symvolaio_ID=" & Symvolaio_ID.Replace("'", "") & ", ProblemType=" & ProblemType & _
                                        ", Shatter=" & Shatter & _
                                        "')"
                    Command = Nothing
                    Command = New SqlCommand
                    Command.Connection = Con
                    Command.CommandTimeout = TimeOut
                    Command.CommandType = CommandType.Text
                    Command.CommandText = SqlString
                    RecsAff = Command.ExecuteNonQuery
                End If
                Con.Close()
                Command = Nothing
                Con = Nothing
                Return "0"
            End Try
        Else
            Return "0"
        End If
    End Function

    Private Function MySignUp(ByVal ClientID As String, ByVal KeyNumber As String, ByVal HashCode As String, ByVal Prothema As String) As String
        Dim MyHashCode As String = "InsOrApp@20160919!789456123"
        Dim ConStr As String = System.Configuration.ConfigurationManager.ConnectionStrings("myConnectionString").ConnectionString
        Dim TimeOut As Integer = System.Configuration.ConfigurationManager.AppSettings.Get("TimeOut")
        Dim RecsAff As Integer = 0
        Dim Con As SqlClient.SqlConnection = Nothing
        Dim Command As SqlCommand = Nothing
        Dim Reader As SqlClient.SqlDataReader = Nothing
        Dim SqlString As String = String.Empty
        Try
            Con = New SqlConnection(ConStr)
            Con.Open()
            If MyHashCode <> HashCode Then
                SqlString = "Insert Into InsOr_Log_File"
                SqlString = SqlString & " (Log_Date,Log_Time,Log_Text)"
                SqlString = SqlString & " values "
                SqlString = SqlString & "(getdate(),getdate(),'" & Prothema & "Result=0 ClientID=" & ClientID.Replace("'", "") & ", KeyNumber=" & KeyNumber.Replace("'", "") & ", HashCode=" & HashCode.Replace("'", "") & "')"
                Command = New SqlCommand
                Command.Connection = Con
                Command.CommandTimeout = TimeOut
                Command.CommandType = CommandType.Text
                Command.CommandText = SqlString
                RecsAff = Command.ExecuteNonQuery
                Command = Nothing
                Con.Close()
                Con = Nothing
                Return "0"
            End If
            SqlString = "Select KLEIDAR from InsOr_PELATHS where ENKWDPEL=" & ClientID.Replace("'", "")
            Command = Nothing
            Command = New SqlCommand
            Command.Connection = Con
            Command.CommandTimeout = TimeOut
            Command.CommandType = CommandType.Text
            Command.CommandText = SqlString
            Reader = Command.ExecuteReader
            If Reader.Read Then
                If Reader.Item("KLEIDAR") = KeyNumber Then
                    SqlString = "Insert Into InsOr_Log_File"
                    SqlString = SqlString & " (Log_Date,Log_Time,Log_Text)"
                    SqlString = SqlString & " values "
                    SqlString = SqlString & "(getdate(),getdate(),'" & Prothema & "Result=1 ClientID=" & ClientID.Replace("'", "") & ", KeyNumber=" & KeyNumber.Replace("'", "") & ", HashCode=" & HashCode.Replace("'", "") & "')"
                    Reader.Close()
                    Reader = Nothing
                    Command = Nothing
                    Command = New SqlCommand
                    Command.Connection = Con
                    Command.CommandTimeout = TimeOut
                    Command.CommandType = CommandType.Text
                    Command.CommandText = SqlString
                    RecsAff = Command.ExecuteNonQuery
                    Con.Close()
                    Command = Nothing
                    Con = Nothing
                    Return "1"
                Else
                    SqlString = "Insert Into InsOr_Log_File"
                    SqlString = SqlString & " (Log_Date,Log_Time,Log_Text)"
                    SqlString = SqlString & " values "
                    SqlString = SqlString & "(getdate(),getdate(),'" & Prothema & "Result=0 ClientID=" & ClientID.Replace("'", "") & ", KeyNumber=" & KeyNumber.Replace("'", "") & ", HashCode=" & HashCode.Replace("'", "") & "')"
                    Reader.Close()
                    Reader = Nothing
                    Command = Nothing
                    Command = New SqlCommand
                    Command.Connection = Con
                    Command.CommandTimeout = TimeOut
                    Command.CommandType = CommandType.Text
                    Command.CommandText = SqlString
                    RecsAff = Command.ExecuteNonQuery
                    Command = Nothing
                    Con.Close()
                    Con = Nothing
                    Return "0"
                End If
            Else
                SqlString = "Insert Into InsOr_Log_File"
                SqlString = SqlString & " (Log_Date,Log_Time,Log_Text)"
                SqlString = SqlString & " values "
                SqlString = SqlString & "(getdate(),getdate(),'" & Prothema & "Result=0 ClientID=" & ClientID.Replace("'", "") & ", KeyNumber=" & KeyNumber.Replace("'", "") & ", HashCode=" & HashCode.Replace("'", "") & "')"
                Reader.Close()
                Reader = Nothing
                Command = Nothing
                Command = New SqlCommand
                Command.Connection = Con
                Command.CommandTimeout = TimeOut
                Command.CommandType = CommandType.Text
                Command.CommandText = SqlString
                RecsAff = Command.ExecuteNonQuery
                Con.Close()
                Command = Nothing
                Con = Nothing
                Return "0"
            End If
        Catch ex As Exception
            If Not Reader Is Nothing Then
                If Reader.IsClosed = False Then Reader.Close()
            End If
            Reader = Nothing
            If Con.State = ConnectionState.Open Then
                SqlString = "Insert Into InsOr_Log_File"
                SqlString = SqlString & " (Log_Date,Log_Time,Log_Text)"
                SqlString = SqlString & " values "
                SqlString = SqlString & "(getdate(),getdate(),'" & Prothema & "Error=" & ex.Message.Replace("'", "") & " ClientID=" & ClientID.Replace("'", "") & ", KeyNumber=" & KeyNumber.Replace("'", "") & ", HashCode=" & HashCode.Replace("'", "") & "')"
                Command = Nothing
                Command = New SqlCommand
                Command.Connection = Con
                Command.CommandTimeout = TimeOut
                Command.CommandType = CommandType.Text
                Command.CommandText = SqlString
                RecsAff = Command.ExecuteNonQuery
            End If
            Con.Close()
            Command = Nothing
            Con = Nothing
            Return "0"
        End Try
    End Function

    Private Function MyGetCarList(ByVal ClientID As String, ByVal KeyNumber As String, ByVal HashCode As String) As ClientCarList
        Dim ConStr As String = System.Configuration.ConfigurationManager.ConnectionStrings("myConnectionString").ConnectionString
        Dim TimeOut As Integer = System.Configuration.ConfigurationManager.AppSettings.Get("TimeOut")
        Dim RecsAff As Integer = 0
        Dim Con As SqlClient.SqlConnection = Nothing
        Dim Command As SqlCommand = Nothing
        Dim Reader As SqlClient.SqlDataReader = Nothing
        Dim SqlString As String = String.Empty
        Dim CarList As New ClientCarList
        Dim EmptyCarList As New ClientCarList
        Dim i As Integer = 0
        Try

            Con = New SqlConnection(ConStr)
            Con.Open()
            SqlString = "Select KWDSYM,ARKYKL,isnull(KLOPH,0) as KLOPH,isnull(PYRKAIA,0) as PYRKAIA,isnull(KRYSTALLA,0) as KRYSTALLA"
            SqlString = SqlString & " from InsOr_SYMBOLAIO"
            SqlString = SqlString & " where KVDPEL=" & ClientID.Replace("'", "")
            SqlString = SqlString & " order by KWDSYM"
            Command = Nothing
            Command = New SqlCommand
            Command.Connection = Con
            Command.CommandTimeout = TimeOut
            Command.CommandType = CommandType.Text
            Command.CommandText = SqlString
            Reader = Command.ExecuteReader
            Do While Reader.Read
                ReDim Preserve CarList.ContractNumber(i)
                ReDim Preserve CarList.CarNumber(i)
                ReDim Preserve CarList.Stolen(i)
                ReDim Preserve CarList.Fire(i)
                ReDim Preserve CarList.Shatter(i) 'KRYSTALLA
                CarList.ContractNumber(i) = Reader.Item("KWDSYM")
                CarList.CarNumber(i) = Reader.Item("ARKYKL")
                CarList.Stolen(i) = IIf(Reader.Item("KLOPH") = 1, True, False)
                CarList.Fire(i) = IIf(Reader.Item("PYRKAIA") = 1, True, False)
                CarList.Shatter(i) = IIf(Reader.Item("KRYSTALLA") = 1, True, False)
                i += 1
            Loop
            SqlString = "Insert Into InsOr_Log_File"
            SqlString = SqlString & " (Log_Date,Log_Time,Log_Text)"
            SqlString = SqlString & " values "
            SqlString = SqlString & "(getdate(),getdate(),'" & "GetCarList_Result=1 ClientID=" & ClientID.Replace("'", "") & ", KeyNumber=" & KeyNumber.Replace("'", "") & ", HashCode=" & HashCode.Replace("'", "") & "')"
            Reader.Close()
            Reader = Nothing
            Command = Nothing
            Command = New SqlCommand
            Command.Connection = Con
            Command.CommandTimeout = TimeOut
            Command.CommandType = CommandType.Text
            Command.CommandText = SqlString
            RecsAff = Command.ExecuteNonQuery
            Con.Close()
            Command = Nothing
            Con = Nothing
            Return CarList
        Catch ex As Exception
            If Not Reader Is Nothing Then
                If Reader.IsClosed = False Then Reader.Close()
            End If
            Reader = Nothing
            If Con.State = ConnectionState.Open Then
                SqlString = "Insert Into InsOr_Log_File"
                SqlString = SqlString & " (Log_Date,Log_Time,Log_Text)"
                SqlString = SqlString & " values "
                SqlString = SqlString & "(getdate(),getdate(),'" & "GetCarList_Error=" & ex.Message.Replace("'", "") & " ClientID=" & ClientID.Replace("'", "") & ", KeyNumber=" & KeyNumber.Replace("'", "") & ", HashCode=" & HashCode.Replace("'", "") & "')"
                Command = Nothing
                Command = New SqlCommand
                Command.Connection = Con
                Command.CommandTimeout = TimeOut
                Command.CommandType = CommandType.Text
                Command.CommandText = SqlString
                RecsAff = Command.ExecuteNonQuery
            End If
            Con.Close()
            Command = Nothing
            Con = Nothing
            Return EmptyCarList
        End Try
    End Function

    Private Function MyCheckboxAccess(ByVal ClientID As String, ByVal KeyNumber As String, ByVal HashCode As String, ByVal Symvolaio_ID As String) As Boolean()
        Dim CheckBoxes() As Boolean
        Dim ConStr As String = System.Configuration.ConfigurationManager.ConnectionStrings("myConnectionString").ConnectionString
        Dim TimeOut As Integer = System.Configuration.ConfigurationManager.AppSettings.Get("TimeOut")
        Dim RecsAff As Integer = 0
        Dim Con As SqlClient.SqlConnection = Nothing
        Dim Command As SqlCommand = Nothing
        Dim Reader As SqlClient.SqlDataReader = Nothing
        Dim SqlString As String = String.Empty
        Dim CarList As New ClientCarList
        Try
            Con = New SqlConnection(ConStr)
            Con.Open()
            SqlString = "Select ODIKH,NOMIKH"
            SqlString = SqlString & " from InsOr_SYMBOLAIO"
            SqlString = SqlString & " where KVDPEL=" & ClientID.Replace("'", "")
            SqlString = SqlString & " and KWDSYM='" & Symvolaio_ID.Replace("'", "") & "'"
            Command = Nothing
            Command = New SqlCommand
            Command.Connection = Con
            Command.CommandTimeout = TimeOut
            Command.CommandType = CommandType.Text
            Command.CommandText = SqlString
            Reader = Command.ExecuteReader
            If Reader.Read Then
                ReDim Preserve CheckBoxes(0)
                CheckBoxes(0) = IIf(Reader.Item("NOMIKH") = 1, True, False)
                ReDim Preserve CheckBoxes(1)
                CheckBoxes(1) = IIf(Reader.Item("ODIKH") = 1, True, False)
            Else
                ReDim Preserve CheckBoxes(0)
                CheckBoxes(0) = False
            End If
            SqlString = "Insert Into InsOr_Log_File"
            SqlString = SqlString & " (Log_Date,Log_Time,Log_Text)"
            SqlString = SqlString & " values "
            SqlString = SqlString & "(getdate(),getdate(),'" & "CheckboxAccess_Result=1 ClientID=" & ClientID.Replace("'", "") & ", KeyNumber=" & KeyNumber.Replace("'", "") & ", HashCode=" & HashCode.Replace("'", "") & ", Symvolaio_ID=" & Symvolaio_ID.Replace("'", "") & "')"
            Reader.Close()
            Reader = Nothing
            Command = Nothing
            Command = New SqlCommand
            Command.Connection = Con
            Command.CommandTimeout = TimeOut
            Command.CommandType = CommandType.Text
            Command.CommandText = SqlString
            RecsAff = Command.ExecuteNonQuery
            Con.Close()
            Command = Nothing
            Con = Nothing
            Return CheckBoxes
        Catch ex As Exception
            If Not Reader Is Nothing Then
                If Reader.IsClosed = False Then Reader.Close()
            End If
            Reader = Nothing
            If Con.State = ConnectionState.Open Then
                SqlString = "Insert Into InsOr_Log_File"
                SqlString = SqlString & " (Log_Date,Log_Time,Log_Text)"
                SqlString = SqlString & " values "
                SqlString = SqlString & "(getdate(),getdate(),'" & "CheckboxAccess_Error=" & ex.Message.Replace("'", "") & " ClientID=" & ClientID.Replace("'", "") & ", KeyNumber=" & KeyNumber.Replace("'", "") & ", HashCode=" & HashCode.Replace("'", "") & ", Symvolaio_ID=" & Symvolaio_ID.Replace("'", "") & "')"
                Command = Nothing
                Command = New SqlCommand
                Command.Connection = Con
                Command.CommandTimeout = TimeOut
                Command.CommandType = CommandType.Text
                Command.CommandText = SqlString
                RecsAff = Command.ExecuteNonQuery
            End If
            Con.Close()
            Command = Nothing
            Con = Nothing
            Return CheckBoxes
        End Try
    End Function
End Class

Public Class ClientCarList
    Public ContractNumber() As String
    Public CarNumber() As String
    Public Stolen() As Boolean
    Public Fire() As Boolean
    Public Shatter() As Boolean
End Class
