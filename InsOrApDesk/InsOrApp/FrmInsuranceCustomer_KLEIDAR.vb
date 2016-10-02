Imports System.Data.SqlClient

Public Class FrmInsuranceCustomer_KLEIDAR
    Private Sub FrmInsuranceCustomer_KLEIDAR_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call InitConStr()
        Call InitForm()
        If OpenConnection(Con) = False Then
            Me.Close()
        End If
    End Sub
    Private Sub FrmInsuranceCustomer_KLEIDAR_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If CloseConnaection(Con) = False Then

        End If
    End Sub
    Private Sub InitForm()
        GroupBoxView.Left = GroupBoxEdit.Left
        GroupBoxView.Top = GroupBoxEdit.Top
        GroupBoxFinal.Left = GroupBoxEdit.Left
        GroupBoxFinal.Top = GroupBoxEdit.Top
        Call DesignScreen("Edit")
    End Sub
    Private Sub InitConStr()
        ConStr = ConStr.Replace("@MyServer", My.Settings.DB_Server)
    End Sub
    Private Sub DesignScreen(ByVal What2Do As String)
        Select Case What2Do
            Case "Edit"
                Customer_id_txt.BackColor = ColorEdit
                Customer_id_txt.Focus()
                GroupBoxEdit.Visible = True
                GroupBoxFinal.Visible = False
                GroupBoxView.Visible = False
                GroupBoxKLEIDAR.Visible = False
                LblSurname.Visible = False
                LblName.Visible = False
                LblEmail.Visible = False
                LblCaution.Visible = False
                Surname_txt.Visible = False
                Name_txt.Visible = False
                Email_txt.Visible = False
            Case "View"
                Customer_id_txt.BackColor = ColorView
                Customer_id_txt.Focus()
                Customer_id_txt.ReadOnly = True
                Customer_id_txt.Focus()
                GroupBoxEdit.Visible = False
                GroupBoxFinal.Visible = False
                GroupBoxView.Visible = True
                GroupBoxKLEIDAR.Visible = False
                LblSurname.Visible = True
                LblName.Visible = True
                LblEmail.Visible = True
                LblCaution.Visible = True
                Surname_txt.Visible = True
                Name_txt.Visible = True
                Email_txt.Visible = True
            Case "Final"
                Customer_id_txt.BackColor = ColorView
                Customer_id_txt.Focus()
                Customer_id_txt.ReadOnly = False
                Customer_id_txt.Focus()
                GroupBoxEdit.Visible = False
                GroupBoxFinal.Visible = True
                GroupBoxView.Visible = False
                GroupBoxKLEIDAR.Visible = True
                LblSurname.Visible = True
                LblName.Visible = True
                LblEmail.Visible = True
                LblCaution.Visible = True
                Surname_txt.Visible = True
                Name_txt.Visible = True
                Email_txt.Visible = True
        End Select
    End Sub

    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles BtnExit.Click
        Me.Close()
    End Sub

    Private Sub BtnStep1_Click(sender As Object, e As EventArgs) Handles BtnStep1.Click
        Dim Command As SqlCommand = Nothing
        Dim Reader As SqlDataReader = Nothing
        Dim SqLString As String = String.Empty
        If Customer_id_txt.Text.Trim = "" Then
            MsgBox("Ο Κωδικός του πελάτη είναι κενός!", MsgBoxStyle.Exclamation, Me.Text)
            Customer_id_txt.Focus()
            Exit Sub
        End If
        If IsNumeric(Customer_id_txt.Text) = False Then
            MsgBox("Ο Κωδικός του πελάτη είναι λάθος!", MsgBoxStyle.Exclamation, Me.Text)
            Customer_id_txt.Focus()
            Exit Sub
        End If
        Try

            SqLString = "Select EPWNYMO,ONOMA,email"
            SqLString = SqLString & " from InsOr_PELATHS"
            SqLString = SqLString & " where ENKWDPEL=" & Customer_id_txt.Text.Replace("'", "")
            Command = New SqlCommand
            Command.CommandType = CommandType.Text
            Command.CommandTimeout = My.Settings.DB_Command_TimeOut
            Command.CommandText = SqLString
            Command.Connection = Con
            Reader = Command.ExecuteReader
            If Reader.Read Then
                Surname_txt.Text = Reader.Item("EPWNYMO")
                Name_txt.Text = Reader.Item("ONOMA")
                Email_txt.Text = Reader.Item("email")
                Call DesignScreen("View")
            Else
                MsgBox("Δεν βρέθηκε πελάτης!", MsgBoxStyle.Exclamation, Me.Text)
            End If
            Reader.Close()
            Reader = Nothing
            Command = Nothing
        Catch ex As Exception
            If Not Reader Is Nothing Then
                If Reader.IsClosed = False Then Reader.Close()
            End If
            Reader = Nothing
            Command = Nothing
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

    Private Sub BtnStep2_Click(sender As Object, e As EventArgs) Handles BtnStep2.Click
        Dim Command As SqlCommand = Nothing
        Dim Transaction As SqlTransaction = Nothing
        Dim SqlString As String = String.Empty
        Dim RecsAff As Integer = 0
        If MsgBox("Να προχωρήσει η Έκδοση Νέου Κλειδάριθμου?", MsgBoxStyle.Question + MsgBoxStyle.OkCancel, Me.Text) = MsgBoxResult.Cancel Then
            Exit Sub
        End If
        SqlString = "Set @KLEIDAR=(Select top 1 KLEIDAR from InsOr_KLEIDARI8MOS where KLEIDAR_Used=0 order by KWDKLEIDAR)"
        SqlString = SqlString & " Set @MyDate=getdate()"
        SqlString = SqlString & " Set @MyTime=getdate()"
        SqlString = SqlString & " Update InsOr_PELATHS set"
        SqlString = SqlString & " KLEIDAR=@KLEIDAR"
        SqlString = SqlString & " where ENKWDPEL=" & Customer_id_txt.Text
        SqlString = SqlString & " "
        SqlString = SqlString & " Update InsOr_KLEIDARI8MOS set"
        SqlString = SqlString & " KLEIDAR_Used=1,"
        SqlString = SqlString & " HMEROM_XRHSHS=@MyDate,"
        SqlString = SqlString & " WRA_XRHSHS=@MyTime"
        SqlString = SqlString & " where KLEIDAR=@KLEIDAR"
        Try
            Transaction = Con.BeginTransaction
            Command = New SqlCommand
            Command.CommandType = CommandType.Text
            Command.CommandTimeout = My.Settings.DB_Command_TimeOut
            Command.Connection = Con
            Command.CommandText = SqlString
            Command.Transaction = Transaction
            Command.Parameters.Add("@KLEIDAR", SqlDbType.NVarChar, 1000)
            Command.Parameters.Add("@MyDate", SqlDbType.Date)
            Command.Parameters.Add("@MyTime", SqlDbType.Time)
            Command.Parameters("@KLEIDAR").Direction = ParameterDirection.Output
            Command.Parameters("@MyDate").Direction = ParameterDirection.Output
            Command.Parameters("@MyTime").Direction = ParameterDirection.Output
            RecsAff = Command.ExecuteNonQuery
            Transaction.Commit()
            KLEIDAR_txt.Text = Command.Parameters("@KLEIDAR").Value
            KLEIDAR_Date_txt.Text = Command.Parameters("@MyDate").Value
            KLEIDAR_Time_txt.Text = Command.Parameters("@MyTime").Value.ToString.Substring(0, 8)
            Call DesignScreen("Final")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
            Transaction.Rollback()
            Transaction = Nothing
            Command = Nothing
        End Try
    End Sub

    Private Sub BtnEdit_Click(sender As Object, e As EventArgs) Handles BtnEdit.Click
        Me.Close()
    End Sub

    Private Sub ButtonFinalExit_Click(sender As Object, e As EventArgs) Handles ButtonFinalExit.Click
        Me.Close()
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click

    End Sub
End Class