Imports System.Data.SqlClient

Public Class FrmInsuranceContract
    Private Sub FrmInsuranceContract_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call InitConStr()
        Call InitForm()
        If OpenConnection(Con) = False Then
            Me.Close()
        End If
    End Sub
    Private Sub FrmInsuranceContract_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If CloseConnaection(Con) = False Then

        End If
    End Sub
    Private Sub InitForm()
        GroupBoxEdit2.Left = GroupBoxEdit.Left
        GroupBoxEdit2.Top = GroupBoxEdit.Top
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
                Customer_Id_txt.BackColor = ColorEdit
                Customer_Id_txt.ReadOnly = False
                LblSurname.Visible = False
                LblName.Visible = False
                LblEmail.Visible = False
                Surname_txt.Visible = False
                Name_txt.Visible = False
                Email_txt.Visible = False
                GroupBoxSymbolaio.Visible = False
                '===============================
                '===============================
                GroupBoxEdit.Visible = True
                GroupBoxEdit2.Visible = False
                GroupBoxView.Visible = False
                GroupBoxFinal.Visible = False
                LicencePlate_txt.Text = ""
                Brand_txt.Text = ""
                CheckBoxTheft.Checked = False
                CheckBoxFire.Checked = False
                CheckBoxKrystalla.Checked = False
                CheckBoxOdBoh.Checked = False
                CheckBoxNomikh.Checked = False
                DateTimePickerFrom.Value = Now
                DateTimePickerTo.Value = Now
            Case "Edit2"
                Customer_Id_txt.BackColor = ColorView
                Customer_Id_txt.ReadOnly = True
                LblSurname.Visible = True
                LblName.Visible = True
                LblEmail.Visible = True
                Surname_txt.Visible = True
                Name_txt.Visible = True
                Email_txt.Visible = True
                GroupBoxSymbolaio.Visible = True
                '===============================
                LicencePlate_txt.BackColor = ColorEdit
                LicencePlate_txt.ReadOnly = False
                Brand_txt.BackColor = ColorEdit
                Brand_txt.ReadOnly = False
                CheckBoxTheft.BackColor = ColorEdit
                CheckBoxTheft.Enabled = True
                CheckBoxFire.BackColor = ColorEdit
                CheckBoxFire.Enabled = True
                CheckBoxKrystalla.BackColor = ColorEdit
                CheckBoxKrystalla.Enabled = True
                CheckBoxOdBoh.BackColor = ColorEdit
                CheckBoxOdBoh.Enabled = True
                CheckBoxNomikh.BackColor = ColorEdit
                CheckBoxNomikh.Enabled = True
                DateTimePickerFrom.Enabled = True
                DateTimePickerTo.Enabled = True
                LblSymvolaio_id.Visible = False
                Symvolaio_id_txt.Visible = False
                '===============================
                GroupBoxEdit.Visible = False
                GroupBoxEdit2.Visible = True
                GroupBoxView.Visible = False
                GroupBoxFinal.Visible = False
            Case "View"
                Customer_Id_txt.BackColor = ColorView
                Customer_Id_txt.ReadOnly = True
                LblSurname.Visible = True
                LblName.Visible = True
                LblEmail.Visible = True
                Surname_txt.Visible = True
                Name_txt.Visible = True
                Email_txt.Visible = True
                GroupBoxSymbolaio.Visible = True
                '===============================
                LicencePlate_txt.BackColor = ColorView
                LicencePlate_txt.ReadOnly = True
                Brand_txt.BackColor = ColorView
                Brand_txt.ReadOnly = True
                CheckBoxTheft.BackColor = ColorView
                CheckBoxTheft.Enabled = False
                CheckBoxFire.BackColor = ColorView
                CheckBoxFire.Enabled = False
                CheckBoxKrystalla.BackColor = ColorView
                CheckBoxKrystalla.Enabled = False
                CheckBoxOdBoh.BackColor = ColorView
                CheckBoxOdBoh.Enabled = False
                CheckBoxNomikh.BackColor = ColorView
                CheckBoxNomikh.Enabled = False
                DateTimePickerFrom.Enabled = False
                DateTimePickerTo.Enabled = False
                LblSymvolaio_id.Visible = False
                Symvolaio_id_txt.Visible = False
                '===============================
                GroupBoxEdit.Visible = False
                GroupBoxEdit2.Visible = False
                GroupBoxView.Visible = True
                GroupBoxFinal.Visible = False
            Case "Final"
                Customer_Id_txt.BackColor = ColorView
                Customer_Id_txt.ReadOnly = True
                LblSurname.Visible = True
                LblName.Visible = True
                LblEmail.Visible = True
                Surname_txt.Visible = True
                Name_txt.Visible = True
                Email_txt.Visible = True
                GroupBoxSymbolaio.Visible = True
                '===============================
                LicencePlate_txt.BackColor = ColorView
                LicencePlate_txt.ReadOnly = True
                Brand_txt.BackColor = ColorView
                Brand_txt.ReadOnly = True
                CheckBoxTheft.BackColor = ColorView
                CheckBoxTheft.Enabled = False
                CheckBoxFire.BackColor = ColorView
                CheckBoxFire.Enabled = False
                CheckBoxKrystalla.BackColor = ColorView
                CheckBoxKrystalla.Enabled = False
                CheckBoxOdBoh.BackColor = ColorView
                CheckBoxOdBoh.Enabled = False
                CheckBoxNomikh.BackColor = ColorView
                CheckBoxNomikh.Enabled = False
                DateTimePickerFrom.Enabled = False
                DateTimePickerTo.Enabled = False
                LblSymvolaio_id.Visible = True
                Symvolaio_id_txt.Visible = True
                Symvolaio_id_txt.ReadOnly = True
                '===============================
                GroupBoxEdit.Visible = False
                GroupBoxEdit2.Visible = False
                GroupBoxView.Visible = False
                GroupBoxFinal.Visible = True
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
                Call DesignScreen("Edit2")
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
        If LicencePlate_txt.Text.Trim = "" Then
            MsgBox("Ο Αρ Κυκλ Νέου Οχήματος είναι κενός!", MsgBoxStyle.Exclamation, Me.Text)
            LicencePlate_txt.Focus()
            Exit Sub
        End If
        If Brand_txt.Text.Trim = "" Then
            MsgBox("Η Μάρκα Νέου Οχήματος είναι κενή!", MsgBoxStyle.Exclamation, Me.Text)
            Brand_txt.Focus()
            Exit Sub
        End If
        Call DesignScreen("View")
    End Sub

    Private Sub BtnEdit_Click(sender As Object, e As EventArgs) Handles BtnEdit.Click
        Call DesignScreen("Edit")
    End Sub

    Private Sub ButtonFinalExit_Click(sender As Object, e As EventArgs) Handles ButtonFinalExit.Click
        Me.Close()
    End Sub

    Private Sub BtnFinal_Click(sender As Object, e As EventArgs) Handles BtnFinal.Click
        Dim Command As SqlCommand = Nothing
        Dim Transaction As SqlTransaction = Nothing
        Dim SqlString As String = String.Empty
        Dim RecsAff As Integer = 0
        Const Lektiko_Symbolaiou As String = "SYMV"
        If MsgBox("Να προχωρήσει η Οριστικοποίηση Συμβολαίου?", MsgBoxStyle.Question + MsgBoxStyle.OkCancel, Me.Text) = MsgBoxResult.Cancel Then
            Exit Sub
        End If
        SqlString = "Set @ContractNum=(Select count(*) + 1 from InsOr_SYMBOLAIO where KVDPEL=" & Customer_Id_txt.Text & ")"
        SqlString = SqlString & " Insert Into InsOr_SYMBOLAIO"
        SqlString = SqlString & " (KWDSYM,KVDPEL,ARKYKL,MARKA,KLOPH,PYRKAIA,KRYSTALLA,ODIKH,NOMIKH,HMEROMAPO,HMEROMEWS)"
        SqlString = SqlString & " values "
        SqlString = SqlString & "('" & Customer_Id_txt.Text & Lektiko_Symbolaiou & "' + cast(@ContractNum as varchar),"
        SqlString = SqlString & Customer_Id_txt.Text & ","
        SqlString = SqlString & "'" & LicencePlate_txt.Text.Replace("'", "") & "',"
        SqlString = SqlString & "'" & Brand_txt.Text.Replace("'", "") & "',"
        SqlString = SqlString & IIf(CheckBoxTheft.Checked = True, 1, 0) & ","
        SqlString = SqlString & IIf(CheckBoxFire.Checked = True, 1, 0) & ","
        SqlString = SqlString & IIf(CheckBoxKrystalla.Checked = True, 1, 0) & ","
        SqlString = SqlString & IIf(CheckBoxOdBoh.Checked = True, 1, 0) & ","
        SqlString = SqlString & IIf(CheckBoxNomikh.Checked = True, 1, 0) & ","
        SqlString = SqlString & "'" & Format(DateTimePickerFrom.Value, "yyyy-MM-dd") & "',"
        SqlString = SqlString & "'" & Format(DateTimePickerTo.Value, "yyyy-MM-dd") & "')"
        Try
            Transaction = Con.BeginTransaction
            Command = New SqlCommand
            Command.CommandType = CommandType.Text
            Command.CommandTimeout = My.Settings.DB_Command_TimeOut
            Command.Connection = Con
            Command.CommandText = SqlString
            Command.Transaction = Transaction
            Command.Parameters.Add("@ContractNum", SqlDbType.Int)
            Command.Parameters("@ContractNum").Direction = ParameterDirection.Output
            RecsAff = Command.ExecuteNonQuery
            Transaction.Commit()
            Symvolaio_id_txt.Text = Customer_Id_txt.Text & Lektiko_Symbolaiou & Command.Parameters("@ContractNum").Value.ToString
            Call DesignScreen("Final")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
            Transaction.Rollback()
            Transaction = Nothing
            Command = Nothing
        End Try

    End Sub

    Private Sub BtnEdit2_Click(sender As Object, e As EventArgs) Handles BtnEdit2.Click
        Call DesignScreen("Edit2")
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click

    End Sub
End Class