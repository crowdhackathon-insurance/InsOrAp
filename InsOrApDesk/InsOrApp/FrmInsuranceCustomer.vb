Imports System.Data.SqlClient

Public Class FrmInsuranceCustomer
    Private Sub FrmInsuranceCustomer_Load(sender As Object, e As EventArgs) Handles Me.Load
        Call InitConStr()
        Call InitForm()
        If OpenConnection(Con) = False Then
            Me.Close()
        End If
    End Sub
    Private Sub FrmInsuranceCustomer_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
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
        Surname_txt.Focus()
        Select Case What2Do
            Case "Edit"
                Surname_txt.ReadOnly = False
                Name_txt.ReadOnly = False
                Email_txt.ReadOnly = False
                Surname_txt.BackColor = ColorEdit
                Name_txt.BackColor = ColorEdit
                Email_txt.BackColor = ColorEdit
                GroupBoxEdit.Visible = True
                GroupBoxView.Visible = False
                GroupBoxFinal.Visible = False
                LblCustomer_id.Visible = False
                Customer_id_txt.Visible = False
            Case "View"
                Surname_txt.ReadOnly = True
                Name_txt.ReadOnly = True
                Email_txt.ReadOnly = True
                Surname_txt.BackColor = ColorView
                Name_txt.BackColor = ColorView
                Email_txt.BackColor = ColorView
                GroupBoxEdit.Visible = False
                GroupBoxView.Visible = True
                GroupBoxFinal.Visible = False
                LblCustomer_id.Visible = False
                Customer_id_txt.Visible = False
            Case "Final"
                Surname_txt.ReadOnly = True
                Name_txt.ReadOnly = True
                Email_txt.ReadOnly = True
                Surname_txt.BackColor = ColorView
                Name_txt.BackColor = ColorView
                Email_txt.BackColor = ColorView
                GroupBoxEdit.Visible = False
                GroupBoxView.Visible = False
                GroupBoxFinal.Visible = True
                LblCustomer_id.Visible = True
                Customer_id_txt.Visible = True
        End Select
    End Sub

    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles BtnExit.Click
        Me.Close()
    End Sub

    Private Sub BtnStep1_Click(sender As Object, e As EventArgs) Handles BtnStep1.Click
        If Surname_txt.Text.Trim = "" Then
            MsgBox("Το Επώνυμο του πελάτη είναι κενό!", MsgBoxStyle.Exclamation, Me.Text)
            Surname_txt.Focus()
            Exit Sub
        End If
        If Name_txt.Text.Trim = "" Then
            MsgBox("Το Όνομα του πελάτη είναι κενό!", MsgBoxStyle.Exclamation, Me.Text)
            Name_txt.Focus()
            Exit Sub
        End If
        If Email_txt.Text.Trim = "" Then
            MsgBox("Το Email του πελάτη είναι κενό!", MsgBoxStyle.Exclamation, Me.Text)
            Email_txt.Focus()
            Exit Sub
        End If
        Call DesignScreen("View")
    End Sub

    Private Sub BtnStep2_Click(sender As Object, e As EventArgs) Handles BtnStep2.Click
        Dim Command As SqlCommand = Nothing
        Dim Transaction As SqlTransaction = Nothing
        Dim SqlString As String = String.Empty
        Dim RecsAff As Integer = 0
        If MsgBox("Να προχωρήσει η Οριστικοποίηση?", MsgBoxStyle.Question + MsgBoxStyle.OkCancel, Me.Text) = MsgBoxResult.Cancel Then
            Exit Sub
        End If
        SqlString = "Set @CustomerCounter=(Select max(ENKWDPEL) + 1 from InsOr_PELATHS)"
        SqlString = SqlString & " Insert Into InsOr_PELATHS"
        SqlString = SqlString & " (ENKWDPEL,EPWNYMO,ONOMA,email,ASFALISTHS)"
        SqlString = SqlString & " values "
        SqlString = SqlString & " (@CustomerCounter,"
        SqlString = SqlString & "@Surname,"
        SqlString = SqlString & "@Name,"
        SqlString = SqlString & "@Email,"
        SqlString = SqlString & "1)"
        Try
            Transaction = Con.BeginTransaction
            Command = New SqlCommand
            Command.CommandType = CommandType.Text
            Command.CommandTimeout = My.Settings.DB_Command_TimeOut
            Command.Connection = Con
            Command.CommandText = SqlString
            Command.Transaction = Transaction
            Command.Parameters.Add("@Surname", SqlDbType.VarChar, 50)
            Command.Parameters.Add("@Name", SqlDbType.VarChar, 50)
            Command.Parameters.Add("@Email", SqlDbType.VarChar, 50)
            Command.Parameters.Add("@CustomerCounter", SqlDbType.Int)
            Command.Parameters("@CustomerCounter").Direction = ParameterDirection.Output
            Command.Parameters("@Surname").Value = Surname_txt.Text
            Command.Parameters("@Name").Value = Name_txt.Text
            Command.Parameters("@Email").Value = Email_txt.Text
            RecsAff = Command.ExecuteNonQuery
            Transaction.Commit()
            Customer_id_txt.Text = Command.Parameters("@CustomerCounter").Value
            Call DesignScreen("Final")
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
            Transaction.Rollback()
            Transaction = Nothing
            Command = Nothing
        End Try
    End Sub

    Private Sub BtnEdit_Click(sender As Object, e As EventArgs) Handles BtnEdit.Click
        Call DesignScreen("Edit")
    End Sub

    Private Sub ButtonFinalExit_Click(sender As Object, e As EventArgs) Handles ButtonFinalExit.Click
        Me.Close()
    End Sub

    Private Sub BtnPrint_Click(sender As Object, e As EventArgs) Handles BtnPrint.Click

    End Sub
End Class