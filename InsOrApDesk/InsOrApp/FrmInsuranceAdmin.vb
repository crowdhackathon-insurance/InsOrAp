Imports System.Data.SqlClient
Imports System.Threading
Imports System.Drawing.Imaging

Public Class FrmInsuranceAdmin
    Private MyThread As Thread
    Private Delegate Sub MyManageGrid(ByVal Row2Add As String, ByVal SelectedRow As Integer, What2Do As String)
    Private ManageGrid As New MyManageGrid(AddressOf InsertRows2GRid)
    Private Delegate Sub MyShowStatus(ByVal CountTotal As Integer, ByVal CountFinished As Integer, ByVal CountInProgerss As Integer)
    Private ShowStatus As New MyShowStatus(AddressOf Show_Status)
    Private isThreadChange As Boolean = False
    Private PreviousDate As Date = Nothing
    Private isForceClose As Boolean = False
    Private is4StopingThread As Boolean = True
    Private Sub FrmInsuranceAdmin_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Call InitConStr()
        Call InitGrid()
        Call InitForm()
        If OpenConnection(Con) = False Then
            isForceClose = True
            Me.Close()
        End If
        MyThread = New Thread(AddressOf ThreadProcess)
        MyThread.IsBackground = True
        MyThread.Start()
    End Sub

    Private Sub FrmInsuranceAdmin_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        'If isForceClose = False Then
        '    If MsgBox("Έξοδος από την εφαρμογή?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, Me.Text) = MsgBoxResult.Cancel Then
        '        e.Cancel = True
        '        Exit Sub
        '    End If
        'End If
        If CloseConnaection(Con) = False Then

        End If
        is4StopingThread = False
        Try
            MyThread.Abort()
        Catch ex As Exception

        End Try
        MyThread = Nothing
    End Sub

    Private Sub initform()

        DateTimeCurrent.Value = Now
        DateTimeCurrent.MaxDate = Now
        PreviousDate = Now
        Call IEbrowserFix()
        WebMap.Navigate(My.Application.Info.DirectoryPath & "\Map\MyMap.htm")

        ''WebMap.Document.InvokeScript("initLocationProcedure")

    End Sub
    Private Sub InitGrid()
        Dim ColImage_Status_Pragm As New DataGridViewImageColumn()
        Dim ColImage_Status_OdBoh As New DataGridViewImageColumn()
        Dim ColImage_Statu_166 As New DataGridViewImageColumn()
        Dim ColImage_Status_100 As New DataGridViewImageColumn()
        Dim ColImage_Status_NomKal As New DataGridViewImageColumn()
        MainGrid.RowsDefaultCellStyle.SelectionBackColor = Color.BlanchedAlmond
        MainGrid.RowsDefaultCellStyle.SelectionForeColor = Color.Black
        WebMap.Width = 760
        MainGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing
        MainGrid.ColumnHeadersHeight = 100
        MainGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing
        MainGrid.RowHeadersVisible = False
        MainGrid.Columns.Add("CarNumber", "ΑΡ ΚΥΚΛ")            '0
        MainGrid.Columns(0).Width = 60
        MainGrid.Columns(0).Resizable = DataGridViewTriState.False
        'MainGrid.Columns.Add("Status_Pragm", "ΠΡΑΓΜ")           '1
        MainGrid.Columns.Add(ColImage_Status_Pragm)
        MainGrid.Columns(1).HeaderText = "ΠΡΑΓΜ"
        MainGrid.Columns(1).Width = 25
        MainGrid.Columns(1).Resizable = DataGridViewTriState.False
        MainGrid.Columns.Add(ColImage_Status_OdBoh)
        MainGrid.Columns(2).HeaderText = "ΟΔ ΒΟΗ"
        MainGrid.Columns(2).Width = 25
        MainGrid.Columns(2).Resizable = DataGridViewTriState.False
        MainGrid.Columns.Add(ColImage_Statu_166)
        MainGrid.Columns(3).HeaderText = "166"
        MainGrid.Columns(3).Width = 25
        MainGrid.Columns(3).Resizable = DataGridViewTriState.False
        MainGrid.Columns.Add(ColImage_Status_100)
        MainGrid.Columns(4).HeaderText = "100"
        MainGrid.Columns(4).Width = 25
        MainGrid.Columns(4).Resizable = DataGridViewTriState.False
        MainGrid.Columns.Add(ColImage_Status_NomKal)
        MainGrid.Columns(5).HeaderText = "ΝΟΜ ΚΑΛ"
        MainGrid.Columns(5).Width = 25
        MainGrid.Columns(5).Resizable = DataGridViewTriState.False
        MainGrid.Columns.Add("Eidos", "ΕΙΔΟΣ")                  '6
        MainGrid.Columns(6).Width = 65
        MainGrid.Columns.Add("KWDSYM", "KWDSYM")                  '7
        MainGrid.Columns(7).Visible = False
        MainGrid.Columns.Add("KWDPEL", "KWDPEL")                  '8
        MainGrid.Columns(8).Visible = False
        MainGrid.Columns.Add("SYMBAN_ID", "SYMBAN_ID")                  '9
        MainGrid.Columns(9).Visible = False
        MainGrid.Columns.Add("SYMBAN_Type", "SYMBAN_Type")                  '10
        MainGrid.Columns(10).Visible = False
        MainGrid.Columns.Add("Lat", "Lat")                  '11
        MainGrid.Columns(11).Visible = False
        MainGrid.Columns.Add("Lng", "Lng")                  '12
        MainGrid.Columns(12).Visible = False
        MainGrid.Columns.Add("OLOKL_166", "OLOKL_166")                  '13
        MainGrid.Columns(13).Visible = False
        MainGrid.Columns.Add("OLOKL_100", "OLOKL_100")                  '14
        MainGrid.Columns(14).Visible = False
        MainGrid.Columns.Add("OLOKL_OD_BOH8", "OLOKL_OD_BOH8")                  '15
        MainGrid.Columns(15).Visible = False
        MainGrid.Columns.Add("OLOKL_NOM_PRO", "OLOKL_NOM_PRO")                  '16
        MainGrid.Columns(16).Visible = False
        MainGrid.Columns.Add("OLOKL_PRAGM", "OLOKL_PRAGM")                  '17
        MainGrid.Columns(17).Visible = False
        MainGrid.Columns.Add("Phones", "Phones")                  '18
        MainGrid.Columns(18).Visible = False
        MainGrid.Columns.Add("ANAGKH_166", "ANAGKH_166")                  '19
        MainGrid.Columns(19).Visible = False
        MainGrid.Columns.Add("ANAGKH_100", "ANAGKH_100")                  '20
        MainGrid.Columns(20).Visible = False
        MainGrid.Columns.Add("ANAGKH_Od_Boh", "ANAGKH_Od_Boh")                  '21
        MainGrid.Columns(21).Visible = False
        MainGrid.Columns.Add("ANAGKH_NOM_KAL", "ANAGKH_NOM_KAL")                  '22
        MainGrid.Columns(22).Visible = False
        MainGrid.Columns.Add("YPAITIOTHTA", "YPAITIOTHTA")                  '23
        MainGrid.Columns(23).Visible = False
        MainGrid.Columns.Add("HMNIA", "HMNIA")                  '24
        MainGrid.Columns(24).Visible = False
        MainGrid.Columns.Add("Sort", "Sort")                  '25
        MainGrid.Columns(25).Visible = False
        MainGrid.Columns.Add("Wra", "Wra")                  '26
        MainGrid.Columns(26).Visible = False
        MainGrid.Columns.Add("SYMBAN_STATUS", "SYMBAN_STATUS")                  '27
        MainGrid.Columns(27).Visible = False
    End Sub
    Private Sub InitConStr()
        ConStr = ConStr.Replace("@MyServer", My.Settings.DB_Server)
    End Sub

    Private Sub ThreadProcess()
        Do While is4StopingThread

            If MainGrid.Rows.Count = 0 Then
                Call Sub_MyManageGrid(-1)
            Else
                'If MainGrid.SelectedRows.Count = 0 Then
                Call Sub_MyManageGrid(-2)
                'Else
                'Call Sub_MyManageGrid(MainGrid.SelectedRows.Item(0).Index)
                'End If

            End If
            Thread.Sleep(My.Settings.MainThreadSleep)
        Loop
    End Sub
    Private Sub Show_Status(ByVal CountTotal As Integer, ByVal CountFinished As Integer, ByVal CountInProgerss As Integer)
        LblTotalCount.Text = CountTotal
        LblCountFinished.Text = CountFinished
        LblCountInProgress.Text = CountInProgerss
    End Sub
    Private Sub InsertRows2GRid(ByVal Row2Add As String, ByVal SelectedRow As Integer, What2Do As String, Optional is4Sort As Boolean = False)
        Dim MyArray() As String
        Dim i As Integer = 0
        '0  --> Red
        '1  --> Blue
        '2  --> Green
        '3  --> White
        isThreadChange = True
        If What2Do = "FirstInsert" Then
            MyArray = Row2Add.Split("~")
            MainGrid.Rows.Add(MyArray(0), "", "", "", "", "", MyArray(6), MyArray(7), MyArray(8), MyArray(9), MyArray(10), MyArray(11), MyArray(12) _
                          , MyArray(13), MyArray(14), MyArray(15), MyArray(16), MyArray(17), MyArray(18),
                          MyArray(19), MyArray(20), MyArray(21), MyArray(22), MyArray(23), MyArray(24), Format(MyArray(9), "000000##"), MyArray(25), MyArray(26))
            For i = 1 To 5
                'MainGrid.Rows(MainGrid.Rows.Count - 1).Cells(i).ValueType = Image.
                Select Case MyArray(i)
                    Case 0
                        MainGrid.Rows(MainGrid.Rows.Count - 1).Cells(i).Value = Image.FromFile(My.Application.Info.DirectoryPath & "\Images\Red.bmp")
                    Case 1
                        MainGrid.Rows(MainGrid.Rows.Count - 1).Cells(i).Value = Image.FromFile(My.Application.Info.DirectoryPath & "\Images\Blue.bmp")
                    Case 2
                        MainGrid.Rows(MainGrid.Rows.Count - 1).Cells(i).Value = Image.FromFile(My.Application.Info.DirectoryPath & "\Images\Green.bmp")
                    Case 3
                        MainGrid.Rows(MainGrid.Rows.Count - 1).Cells(i).Value = Image.FromFile(My.Application.Info.DirectoryPath & "\Images\White.bmp")
                        'Case 4
                        '    MainGrid.Rows(MainGrid.Rows.Count - 1).Cells(i).Value = Image.FromFile(My.Application.Info.DirectoryPath & "\Images\White.bmp")
                End Select
            Next
            MainGrid.Sort(MainGrid.Columns(25),
        System.ComponentModel.ListSortDirection.Descending)
            'MainGrid.Rows(SelectedRow).Selected = True
        ElseIf What2Do = "DeleteRow" Then
            MainGrid.Rows.RemoveAt(SelectedRow)
        ElseIf What2Do = "Edit" Then
            MyArray = Row2Add.Split("~")
            For i = 1 To 5
                'MainGrid.Rows(MainGrid.Rows.Count - 1).Cells(i).ValueType = Image.
                Select Case MyArray(i)
                    Case 0
                        MainGrid.Rows(SelectedRow).Cells(i).Value = Image.FromFile(My.Application.Info.DirectoryPath & "\Images\Red.bmp")
                    Case 1
                        MainGrid.Rows(SelectedRow).Cells(i).Value = Image.FromFile(My.Application.Info.DirectoryPath & "\Images\Blue.bmp")
                    Case 2
                        MainGrid.Rows(SelectedRow).Cells(i).Value = Image.FromFile(My.Application.Info.DirectoryPath & "\Images\Green.bmp")
                    Case 3
                        MainGrid.Rows(SelectedRow).Cells(i).Value = Image.FromFile(My.Application.Info.DirectoryPath & "\Images\White.bmp")
                        'Case 4
                        '    MainGrid.Rows(SelectedRow).Cells(i).Value = Image.FromFile(My.Application.Info.DirectoryPath & "\Images\White.bmp")
                End Select
            Next
            '    MainGrid.Sort(MainGrid.Columns(25),
            'System.ComponentModel.ListSortDirection.Descending)
        End If
        isThreadChange = False
    End Sub
    Private Sub Sub_MyManageGrid(ByVal SelectedRow As Integer)
        Dim Command As SqlCommand = Nothing
        Dim Reader As SqlDataReader = Nothing
        Dim SqlString As String = String.Empty
        Dim Row2Add As String = String.Empty
        Dim i As Integer = 0
        Dim CountTotal As Integer = 0
        Dim CountFinshed As Integer = 0
        Dim CountInProgerss As Integer = 0
        Dim MyRow As Integer = 0
        Dim FoundRow As Boolean = False
        Dim CurrentRow As Integer = 0

        SqlString = "Select"
        SqlString = SqlString & " SYMBAN_ID               As SYMBAN_ID, "
        SqlString = SqlString & " 1						As SYMBAN_Type, "
        SqlString = SqlString & " 'Ατύχημα'             As DeyteroType,"
        SqlString = SqlString & " isnull(SYMBAN_STATUS,0)         as SYMBAN_STATUS,"
        SqlString = SqlString & " SYMBOLAIO.ARKYKL       As CarNumber,"
        SqlString = SqlString & " HMNIA					As HMNIA,"
        SqlString = SqlString & " WRA                     As WRA,"
        SqlString = SqlString & " Lat						As Lat,"
        SqlString = SqlString & " Lng                     As Lng,"
        SqlString = SqlString & " Tel1						As Tel1,"
        SqlString = SqlString & " Tel2                     As Tel2,"
        SqlString = SqlString & " KWDPEL					As KWDPEL,"
        SqlString = SqlString & " SYMBAN.KWDSYM                  As KWDSYM,"
        SqlString = SqlString & " ANAGKH_166                As ANAGKH_166,"
        SqlString = SqlString & " ANAGKH_100                As ANAGKH_100,"
        SqlString = SqlString & " ANAGKH_OD_BOH8EIA         As ANAGKH_OD_BOH8EIA,"
        SqlString = SqlString & " ANAGKH_NOM_KAL            As ANAGKH_NOM_KAL,"
        SqlString = SqlString & " YPAITIOTHTA               As YPAITIOTHTA,"
        SqlString = SqlString & " KLHSH_166				As KLHSH_166,"
        SqlString = SqlString & " KLHSH_100               As KLHSH_100,"
        SqlString = SqlString & " KLHSH_OD_BOH8EIA		As KLHSH_OD_BOH8EIA,"
        SqlString = SqlString & " KLHSH_NOM_PRO           As KLHSH_NOM_PRO,"
        SqlString = SqlString & " KLHSH_PRAGM				As KLHSH_PRAGM,"
        SqlString = SqlString & " OLOKL_166               As OLOKL_166,"
        SqlString = SqlString & " OLOKL_100				As OLOKL_100,"
        SqlString = SqlString & " OLOKL_OD_BOH8           As OLOKL_OD_BOH8,"
        SqlString = SqlString & " OLOKL_NOM_PRO			As OLOKL_NOM_PRO,"
        SqlString = SqlString & " OLOKL_PRAGM             As OLOKL_PRAGM"
        SqlString = SqlString & " from"
        SqlString = SqlString & "     InsOr_SYMBAN As SYMBAN    inner join InsOr_SYMBOLAIO As SYMBOLAIO"
        SqlString = SqlString & "                               On SYMBAN.KWDSYM=SYMBOLAIO.KWDSYM"
        SqlString = SqlString & " where"
        SqlString = SqlString & " HMNIA='" & Format(DateTimeCurrent.Value, "yyyy-MM-dd") & "'"
        SqlString = SqlString & "     union all"
        SqlString = SqlString & " Select"
        SqlString = SqlString & " SYMBAN_DEYTERO_ID                       as SYMBAN_ID,"
        SqlString = SqlString & " 2										As SYMBAN_Type,"
        SqlString = SqlString & " SYMBAN_Types.SYMBAN_DEYTERO_TYPE_DESCR  as DeyteroType,"
        SqlString = SqlString & " isnull(SYMBAN_DEYTERO_STATUS,0)         as SYMBAN_STATUS,"
        SqlString = SqlString & " SYMBOLAIO.ARKYKL                      as CarNumber,"
        SqlString = SqlString & " HMNIA					As HMNIA,"
        SqlString = SqlString & " WRA                     as WRA,"
        SqlString = SqlString & " null					As Lat,"
        SqlString = SqlString & " null                    as Lng,"
        SqlString = SqlString & " null						As Tel1,"
        SqlString = SqlString & " null                     As Tel2,"
        SqlString = SqlString & " KWDPEL					As KWDPEL,"
        SqlString = SqlString & " SYMBAN.KWDSYM                  as KWDSYM,"
        SqlString = SqlString & " null                as ANAGKH_166,"
        SqlString = SqlString & " null                as ANAGKH_100,"
        SqlString = SqlString & " null         as ANAGKH_OD_BOH8EIA,"
        SqlString = SqlString & " null            as ANAGKH_NOM_KAL,"
        SqlString = SqlString & " null               as YPAITIOTHTA,"
        SqlString = SqlString & " null					As KLHSH_166,"
        SqlString = SqlString & " null                    as KLHSH_100,"
        SqlString = SqlString & " null					As KLHSH_OD_BOH8EIA,"
        SqlString = SqlString & " null                    as KLHSH_NOM_PRO,"
        SqlString = SqlString & " KLHSH_PRAGM				As KLHSH_PRAGM,"
        SqlString = SqlString & " null                    as OLOKL_166,"
        SqlString = SqlString & " null					As OLOKL_100,"
        SqlString = SqlString & " null                    as OLOKL_OD_BOH8,"
        SqlString = SqlString & " null					As OLOKL_NOM_PRO,"
        SqlString = SqlString & " OLOKL_PRAGM             as OLOKL_PRAGM"
        SqlString = SqlString & " From"
        SqlString = SqlString & " InsOr_SYMBAN_DEYTERO As SYMBAN  inner Join InsOr_SYMBAN_DEYTERO_TYPES As SYMBAN_Types"
        SqlString = SqlString & "                                 On SYMBAN.SYMBAN_DEYTERO_TYPE=SYMBAN_Types.SYMBAN_DEYTERO_TYPE"
        SqlString = SqlString & "                                 inner Join InsOr_SYMBOLAIO as SYMBOLAIO"
        SqlString = SqlString & "                               on SYMBAN.KWDSYM=SYMBOLAIO.KWDSYM"
        SqlString = SqlString & " where"
        SqlString = SqlString & " HMNIA='" & Format(DateTimeCurrent.Value, "yyyy-MM-dd") & "'"
        SqlString = SqlString & " Order By"
        SqlString = SqlString & " SYMBAN_ID desc"

        Select Case SelectedRow
            Case -1
                Try
                    PreviousDate = DateTimeCurrent.Value
                    Command = New SqlCommand
                    Command.Connection = Con
                    Command.CommandType = CommandType.Text
                    Command.CommandTimeout = My.Settings.DB_Command_TimeOut
                    Command.CommandText = SqlString
                    Reader = Command.ExecuteReader
                    Do While Reader.Read
                        Row2Add = ""
                        Row2Add = Reader.Item("CarNumber") & "~"
                        If IsDBNull(Reader.Item("KLHSH_PRAGM")) = True Then
                            Row2Add = Row2Add & "0" & "~"
                        Else
                            If IsDBNull(Reader.Item("OLOKL_PRAGM")) = False Then
                                Row2Add = Row2Add & "2" & "~"
                            Else
                                Row2Add = Row2Add & "1" & "~"
                            End If
                        End If
                        If Reader.Item("SYMBAN_Type") = 1 Then
                            If Reader.Item("ANAGKH_OD_BOH8EIA") = 1 Then
                                If IsDBNull(Reader.Item("KLHSH_OD_BOH8EIA")) = True Then
                                    Row2Add = Row2Add & "0" & "~"
                                Else
                                    If IsDBNull(Reader.Item("OLOKL_OD_BOH8")) = False Then
                                        Row2Add = Row2Add & "2" & "~"
                                    Else
                                        Row2Add = Row2Add & "1" & "~"
                                    End If
                                End If
                            Else
                                Row2Add = Row2Add & "3" & "~"
                            End If
                            If Reader.Item("ANAGKH_166") = 1 Then
                                If IsDBNull(Reader.Item("KLHSH_166")) = True Then
                                    Row2Add = Row2Add & "0" & "~"
                                Else
                                    If IsDBNull(Reader.Item("OLOKL_166")) = False Then
                                        Row2Add = Row2Add & "2" & "~"
                                    Else
                                        Row2Add = Row2Add & "1" & "~"
                                    End If
                                End If
                            Else
                                Row2Add = Row2Add & "3" & "~"
                            End If
                            If Reader.Item("ANAGKH_100") = 1 Then
                                If IsDBNull(Reader.Item("KLHSH_100")) = True Then
                                    Row2Add = Row2Add & "0" & "~"
                                Else
                                    If IsDBNull(Reader.Item("OLOKL_100")) = False Then
                                        Row2Add = Row2Add & "2" & "~"
                                    Else
                                        Row2Add = Row2Add & "1" & "~"
                                    End If
                                End If
                            Else
                                Row2Add = Row2Add & "3" & "~"
                            End If
                            If Reader.Item("ANAGKH_NOM_KAL") = 1 Then
                                If IsDBNull(Reader.Item("KLHSH_NOM_PRO")) = True Then
                                    Row2Add = Row2Add & "0" & "~"
                                Else
                                    If IsDBNull(Reader.Item("OLOKL_NOM_PRO")) = False Then
                                        Row2Add = Row2Add & "2" & "~"
                                    Else
                                        Row2Add = Row2Add & "1" & "~"
                                    End If
                                End If
                            Else
                                Row2Add = Row2Add & "3" & "~"
                            End If
                        Else
                            Row2Add = Row2Add & "3" & "~" & "3" & "~" & "3" & "~" & "3" & "~"
                        End If
                        Row2Add = Row2Add & Reader.Item("DeyteroType") & "~"
                        Row2Add = Row2Add & Reader.Item("KWDSYM") & "~"
                        Row2Add = Row2Add & Reader.Item("KWDPEL") & "~"
                        Row2Add = Row2Add & Reader.Item("SYMBAN_ID") & "~"
                        Row2Add = Row2Add & Reader.Item("SYMBAN_Type") & "~"
                        Row2Add = Row2Add & Reader.Item("Lat") & "~"
                        Row2Add = Row2Add & Reader.Item("Lng") & "~"
                        Row2Add = Row2Add & IIf(IsDBNull(Reader.Item("OLOKL_166")) = True, -1, Reader.Item("OLOKL_166")) & "~"
                        Row2Add = Row2Add & IIf(IsDBNull(Reader.Item("OLOKL_100")) = True, -1, Reader.Item("OLOKL_100")) & "~"
                        Row2Add = Row2Add & IIf(IsDBNull(Reader.Item("OLOKL_OD_BOH8")) = True, -1, Reader.Item("OLOKL_OD_BOH8")) & "~"
                        Row2Add = Row2Add & IIf(IsDBNull(Reader.Item("OLOKL_NOM_PRO")) = True, -1, Reader.Item("OLOKL_NOM_PRO")) & "~"
                        Row2Add = Row2Add & IIf(IsDBNull(Reader.Item("OLOKL_PRAGM")) = True, -1, Reader.Item("OLOKL_PRAGM")) & "~"
                        Row2Add = Row2Add & Reader.Item("Tel1") & " - " & Reader.Item("Tel2") & "~"
                        Row2Add = Row2Add & IIf(IsDBNull(Reader.Item("ANAGKH_166")) = True, -1, Reader.Item("ANAGKH_166")) & "~"
                        Row2Add = Row2Add & IIf(IsDBNull(Reader.Item("ANAGKH_100")) = True, -1, Reader.Item("ANAGKH_100")) & "~"
                        Row2Add = Row2Add & IIf(IsDBNull(Reader.Item("ANAGKH_OD_BOH8EIA")) = True, -1, Reader.Item("ANAGKH_OD_BOH8EIA")) & "~"
                        Row2Add = Row2Add & IIf(IsDBNull(Reader.Item("ANAGKH_NOM_KAL")) = True, -1, Reader.Item("ANAGKH_NOM_KAL")) & "~"
                        Row2Add = Row2Add & IIf(IsDBNull(Reader.Item("YPAITIOTHTA")) = True, -1, Reader.Item("YPAITIOTHTA")) & "~"
                        Row2Add = Row2Add & Reader.Item("HMNIA") & "~" & Reader.Item("WRA").ToString.Substring(0, 8) & "~" & Reader.Item("SYMBAN_STATUS")
                        Me.Invoke(ManageGrid, Row2Add, i, "FirstInsert")
                        CountTotal += 1
                        If Reader.Item("SYMBAN_Type") = 1 Then
                            If Reader.Item("SYMBAN_STATUS") = 3 Then
                                CountFinshed += 1
                            Else
                                CountInProgerss += 1
                            End If
                        Else
                            If Reader.Item("SYMBAN_STATUS") = 3 Then
                                CountFinshed += 1
                            Else
                                CountInProgerss += 1
                            End If
                        End If

                        i += 1
                    Loop
                    Me.Invoke(ShowStatus, CountTotal, CountFinshed, CountInProgerss)
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
            Case -2
                'For MyRow = 0 To MainGrid.Rows.Count - 1
                '    If Format(CDate(MainGrid.Rows(MyRow).Cells(24).Value), "yyyy-MM-dd") <> Format(DateTimeCurrent.Value, "yyyy-MM-dd") Then
                '        'MainGrid.Rows.Remove(MyRow)
                '        Me.Invoke(ManageGrid, "", 0, "DeleteRow")
                '    End If
                'Next
                If Format(PreviousDate, "yyyy-MM-dd") <> Format(DateTimeCurrent.Value, "yyyy-MM-dd") Then
                    For MyRow = 0 To MainGrid.Rows.Count - 1
                        Me.Invoke(ManageGrid, "", 0, "DeleteRow")
                    Next
                    PreviousDate = DateTimeCurrent.Value
                End If
                Try

                    Command = New SqlCommand
                    Command.Connection = Con
                    Command.CommandType = CommandType.Text
                    Command.CommandTimeout = My.Settings.DB_Command_TimeOut
                    Command.CommandText = SqlString
                    Reader = Command.ExecuteReader
                    Do While Reader.Read
                        FoundRow = False
                        For MyRow = 0 To MainGrid.Rows.Count - 1
                            If MainGrid.Rows(MyRow).Cells(9).Value = Reader.Item("SYMBAN_ID") And
                                MainGrid.Rows(MyRow).Cells(10).Value = Reader.Item("SYMBAN_Type") Then
                                FoundRow = True
                                CurrentRow = MyRow
                                Exit For
                            End If
                        Next

                        Row2Add = ""
                        Row2Add = Reader.Item("CarNumber") & "~"
                        If IsDBNull(Reader.Item("KLHSH_PRAGM")) = True Then
                            Row2Add = Row2Add & "0" & "~"
                        Else
                            If IsDBNull(Reader.Item("OLOKL_PRAGM")) = False Then
                                Row2Add = Row2Add & "2" & "~"
                            Else
                                Row2Add = Row2Add & "1" & "~"
                            End If
                        End If
                            If Reader.Item("SYMBAN_Type") = 1 Then
                                If Reader.Item("ANAGKH_OD_BOH8EIA") = 1 Then
                                    If IsDBNull(Reader.Item("KLHSH_OD_BOH8EIA")) = True Then
                                        Row2Add = Row2Add & "0" & "~"
                                    Else
                                        If IsDBNull(Reader.Item("OLOKL_OD_BOH8")) = False Then
                                            Row2Add = Row2Add & "2" & "~"
                                        Else
                                            Row2Add = Row2Add & "1" & "~"
                                        End If
                                    End If
                                Else
                                Row2Add = Row2Add & "3" & "~"
                            End If
                                If Reader.Item("ANAGKH_166") = 1 Then
                                    If IsDBNull(Reader.Item("KLHSH_166")) = True Then
                                        Row2Add = Row2Add & "0" & "~"
                                    Else
                                        If IsDBNull(Reader.Item("OLOKL_166")) = False Then
                                            Row2Add = Row2Add & "2" & "~"
                                        Else
                                            Row2Add = Row2Add & "1" & "~"
                                        End If
                                    End If
                                Else
                                Row2Add = Row2Add & "3" & "~"
                            End If
                                If Reader.Item("ANAGKH_100") = 1 Then
                                    If IsDBNull(Reader.Item("KLHSH_100")) = True Then
                                        Row2Add = Row2Add & "0" & "~"
                                    Else
                                        If IsDBNull(Reader.Item("OLOKL_100")) = False Then
                                            Row2Add = Row2Add & "2" & "~"
                                        Else
                                            Row2Add = Row2Add & "1" & "~"
                                        End If
                                    End If
                                Else
                                Row2Add = Row2Add & "3" & "~"
                            End If
                                If Reader.Item("ANAGKH_NOM_KAL") = 1 Then
                                    If IsDBNull(Reader.Item("KLHSH_NOM_PRO")) = True Then
                                        Row2Add = Row2Add & "0" & "~"
                                    Else
                                        If IsDBNull(Reader.Item("OLOKL_NOM_PRO")) = False Then
                                            Row2Add = Row2Add & "2" & "~"
                                        Else
                                            Row2Add = Row2Add & "1" & "~"
                                        End If
                                    End If
                                Else
                                Row2Add = Row2Add & "3" & "~"
                            End If
                            Else
                            Row2Add = Row2Add & "3" & "~" & "3" & "~" & "3" & "~" & "3" & "~"
                        End If
                            Row2Add = Row2Add & Reader.Item("DeyteroType") & "~"
                            Row2Add = Row2Add & Reader.Item("KWDSYM") & "~"
                            Row2Add = Row2Add & Reader.Item("KWDPEL") & "~"
                            Row2Add = Row2Add & Reader.Item("SYMBAN_ID") & "~"
                            Row2Add = Row2Add & Reader.Item("SYMBAN_Type") & "~"
                            Row2Add = Row2Add & Reader.Item("Lat") & "~"
                            Row2Add = Row2Add & Reader.Item("Lng") & "~"
                            Row2Add = Row2Add & IIf(IsDBNull(Reader.Item("OLOKL_166")) = True, -1, Reader.Item("OLOKL_166")) & "~"
                            Row2Add = Row2Add & IIf(IsDBNull(Reader.Item("OLOKL_100")) = True, -1, Reader.Item("OLOKL_100")) & "~"
                            Row2Add = Row2Add & IIf(IsDBNull(Reader.Item("OLOKL_OD_BOH8")) = True, -1, Reader.Item("OLOKL_OD_BOH8")) & "~"
                            Row2Add = Row2Add & IIf(IsDBNull(Reader.Item("OLOKL_NOM_PRO")) = True, -1, Reader.Item("OLOKL_NOM_PRO")) & "~"
                            Row2Add = Row2Add & IIf(IsDBNull(Reader.Item("OLOKL_PRAGM")) = True, -1, Reader.Item("OLOKL_PRAGM")) & "~"
                            Row2Add = Row2Add & Reader.Item("Tel1") & " - " & Reader.Item("Tel2") & "~"
                            Row2Add = Row2Add & IIf(IsDBNull(Reader.Item("ANAGKH_166")) = True, -1, Reader.Item("ANAGKH_166")) & "~"
                            Row2Add = Row2Add & IIf(IsDBNull(Reader.Item("ANAGKH_100")) = True, -1, Reader.Item("ANAGKH_100")) & "~"
                            Row2Add = Row2Add & IIf(IsDBNull(Reader.Item("ANAGKH_OD_BOH8EIA")) = True, -1, Reader.Item("ANAGKH_OD_BOH8EIA")) & "~"
                            Row2Add = Row2Add & IIf(IsDBNull(Reader.Item("ANAGKH_NOM_KAL")) = True, -1, Reader.Item("ANAGKH_NOM_KAL")) & "~"
                            Row2Add = Row2Add & IIf(IsDBNull(Reader.Item("YPAITIOTHTA")) = True, -1, Reader.Item("YPAITIOTHTA")) & "~"
                        Row2Add = Row2Add & Reader.Item("HMNIA") & "~" & Reader.Item("WRA").ToString.Substring(0, 8) & "~" & Reader.Item("SYMBAN_STATUS")

                        CountTotal += 1
                        If Reader.Item("SYMBAN_Type") = 1 Then
                            If Reader.Item("SYMBAN_STATUS") = 3 Then
                                CountFinshed += 1
                            Else
                                CountInProgerss += 1
                            End If
                        Else
                            If Reader.Item("SYMBAN_STATUS") = 3 Then
                                CountFinshed += 1
                            Else
                                CountInProgerss += 1
                                End If
                            End If

                            i += 1
                        If FoundRow = False Then
                            Me.Invoke(ManageGrid, Row2Add, i, "FirstInsert")
                        Else
                            Me.Invoke(ManageGrid, Row2Add, CurrentRow, "Edit")
                        End If
                    Loop
                    Me.Invoke(ShowStatus, CountTotal, CountFinshed, CountInProgerss)
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
            Case Else
        End Select
    End Sub

    Private Sub MainGrid_CellPainting(sender As Object, e As DataGridViewCellPaintingEventArgs) Handles MainGrid.CellPainting
        If e.RowIndex = -1 _
            And (e.ColumnIndex = 1 Or e.ColumnIndex = 2 Or e.ColumnIndex = 3 Or e.ColumnIndex = 4 Or e.ColumnIndex = 5) Then
            e.PaintBackground(e.CellBounds, True)
            e.Graphics.TranslateTransform(e.CellBounds.Left, e.CellBounds.Bottom)
            e.Graphics.RotateTransform(270)
            e.Graphics.DrawString(e.Value, e.CellStyle.Font, Brushes.Black, 5, 5)
            e.Graphics.ResetTransform()
            e.Handled = True
        End If
    End Sub

    Private Sub FrmInsuranceAdmin_Resize(sender As Object, e As EventArgs) Handles Me.Resize
        DateTimeCurrent.Left = Me.Width - DateTimeCurrent.Width - 20
    End Sub
    Private Sub MainGrid_CellEnter(sender As Object, e As DataGridViewCellEventArgs) Handles MainGrid.CellEnter
        Dim MyCommand As SqlCommand = Nothing
        Dim Reader As SqlDataReader = Nothing
        Dim SqlString As String = String.Empty
        Dim AddressArgs As Object()
        Dim Args As Object()
        If isThreadChange = True Then Exit Sub
        'MsgBox(MainGrid.Rows(e.RowIndex).Cells(10).Value & " - " & MainGrid.Rows(e.RowIndex).Cells(11).Value & " - " & MainGrid.Rows(e.RowIndex).Cells(12).Value & " - " & MainGrid.Rows(e.RowIndex).Cells(0).Value)
        If MainGrid.Rows(e.RowIndex).Cells(10).Value = 1 Then
            Try
                'If e.RowIndex = 0 And e.ColumnIndex = 0 Then Exit Sub
                SqlString = "Select"
                SqlString = SqlString & " EPWNYMO + ' ' + ONOMA as Onoma"
                SqlString = SqlString & " from"
                SqlString = SqlString & " InsOr_PELATHS"
                SqlString = SqlString & " where ENKWDPEL=" & MainGrid.Rows(e.RowIndex).Cells(8).Value
                MyCommand = Nothing
                MyCommand = New SqlCommand
                MyCommand.Connection = Con
                MyCommand.CommandType = CommandType.Text
                MyCommand.CommandTimeout = My.Settings.DB_Command_TimeOut
                MyCommand.CommandText = SqlString
                Reader = MyCommand.ExecuteReader
                If Reader.Read Then
                    If MainGrid.Rows(e.RowIndex).Cells(27).Value = 3 Then
                        Args = {Reader.Item("Onoma"), MainGrid.Rows(e.RowIndex).Cells(7).Value, MainGrid.Rows(e.RowIndex).Cells(0).Value,
                    MainGrid.Rows(e.RowIndex).Cells(18).Value, "ΝΑΙ", MainGrid.Rows(e.RowIndex).Cells(26).Value}
                    Else
                        Args = {Reader.Item("Onoma"), MainGrid.Rows(e.RowIndex).Cells(7).Value, MainGrid.Rows(e.RowIndex).Cells(0).Value,
                                MainGrid.Rows(e.RowIndex).Cells(18).Value, "ΟΧΙ", MainGrid.Rows(e.RowIndex).Cells(26).Value}
                    End If
                    WebMap.Document.InvokeScript("SetStoixeia", Args)
                    AddressArgs = {MainGrid.Rows(e.RowIndex).Cells(11).Value.ToString.Replace(",", "."), MainGrid.Rows(e.RowIndex).Cells(12).Value.ToString.Replace(",", "."), MainGrid.Rows(e.RowIndex).Cells(0).Value, "", ""}
                    WebMap.Document.InvokeScript("setMarkerPosition", AddressArgs)
                    If MainGrid.Rows(e.RowIndex).Cells(19).Value = 1 Then Lbl166.Text = "ΝΑΙ" Else Lbl166.Text = "ΟΧΙ"
                    If MainGrid.Rows(e.RowIndex).Cells(20).Value = 1 Then Lbl100.Text = "ΝΑΙ" Else Lbl100.Text = "ΟΧΙ"
                    If MainGrid.Rows(e.RowIndex).Cells(21).Value = 1 Then lblOdBoh.Text = "ΝΑΙ" Else lblOdBoh.Text = "ΟΧΙ"
                    If MainGrid.Rows(e.RowIndex).Cells(23).Value = 1 Then LblYpaitios.Text = "ΝΑΙ" Else LblYpaitios.Text = "ΟΧΙ"
                End If
                Reader.Close()
                Reader = Nothing
                MyCommand = Nothing
            Catch ex As Exception
                If Not Reader Is Nothing Then
                    If Reader.IsClosed = False Then Reader.Close()
                End If
                Reader = Nothing
                MyCommand = Nothing
                MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
            End Try
        Else
            Try
                SqlString = "Select"
                SqlString = SqlString & " EPWNYMO + ' ' + ONOMA as Onoma"
                SqlString = SqlString & " from"
                SqlString = SqlString & " InsOr_PELATHS"
                SqlString = SqlString & " where ENKWDPEL=" & MainGrid.Rows(e.RowIndex).Cells(8).Value
                MyCommand = Nothing
                MyCommand = New SqlCommand
                MyCommand.Connection = Con
                MyCommand.CommandType = CommandType.Text
                MyCommand.CommandTimeout = My.Settings.DB_Command_TimeOut
                MyCommand.CommandText = SqlString
                Reader = MyCommand.ExecuteReader
                If Reader.Read Then
                    If MainGrid.Rows(e.RowIndex).Cells(17).Value <> -1 Then
                        Args = {Reader.Item("Onoma"), MainGrid.Rows(e.RowIndex).Cells(7).Value, MainGrid.Rows(e.RowIndex).Cells(0).Value,
                                MainGrid.Rows(e.RowIndex).Cells(18).Value, "ΝΑΙ"}
                    Else
                        Args = {Reader.Item("Onoma"), MainGrid.Rows(e.RowIndex).Cells(7).Value, MainGrid.Rows(e.RowIndex).Cells(0).Value,
                                MainGrid.Rows(e.RowIndex).Cells(18).Value, "ΟΧΙ"}
                    End If
                    WebMap.Document.InvokeScript("SetStoixeia", Args)

                End If
                Lbl166.Text = "ΟΧΙ"
                Lbl100.Text = "ΟΧΙ"
                lblOdBoh.Text = "ΟΧΙ"
                LblYpaitios.Text = "ΟΧΙ"
                Reader.Close()
                Reader = Nothing
                MyCommand = Nothing
            Catch ex As Exception
                If Not Reader Is Nothing Then
                    If Reader.IsClosed = False Then Reader.Close()
                End If
                Reader = Nothing
                MyCommand = Nothing
                MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
            End Try
        End If

    End Sub
    Private Sub IEbrowserFix()
        Try
            Dim regDM As Microsoft.Win32.RegistryKey
            Dim is64 As Boolean = Environment.Is64BitOperatingSystem
            Dim KeyPath As String = ""
            If is64 Then
                KeyPath = "SOFTWARE\Wow6432Node\Microsoft\Internet Explorer\MAIN\FeatureControl\FEATURE_BROWSER_EMULATION"
            Else
                KeyPath = "SOFTWARE\Microsoft\Internet Explorer\MAIN\FeatureControl\FEATURE_BROWSER_EMULATION"
            End If

            regDM = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(KeyPath, False)
            If regDM Is Nothing Then
                regDM = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(KeyPath)
            End If

            Dim Sleutel As Object
            If Not regDM Is Nothing Then
                Dim location As String = System.Environment.GetCommandLineArgs()(0)
                Dim appName As String = System.IO.Path.GetFileName(location)

                Sleutel = regDM.GetValue(appName)
                If Sleutel Is Nothing Then
                    'Sleutel onbekend
                    regDM = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(KeyPath, True)
                    Sleutel = Microsoft.Win32.Registry.LocalMachine.CreateSubKey(KeyPath, Microsoft.Win32.RegistryKeyPermissionCheck.ReadWriteSubTree)

                    'What OS are we using
                    Dim OsVersion As Version = System.Environment.OSVersion.Version

                    If OsVersion.Major = 6 And OsVersion.Minor = 1 Then
                        'WIN 7
                        Sleutel.SetValue(appName, 36864, Microsoft.Win32.RegistryValueKind.DWord)
                    ElseIf OsVersion.Major = 6 And OsVersion.Minor = 2 Then
                        'WIN 8
                        Sleutel.SetValue(appName, 36864, Microsoft.Win32.RegistryValueKind.DWord)
                    ElseIf OsVersion.Major = 5 And OsVersion.Minor = 1 Then
                        'WIN xp
                        Sleutel.SetValue(appName, 36864, Microsoft.Win32.RegistryValueKind.DWord)
                    End If

                    Sleutel.Close()
                End If
            End If


        Catch ex As Exception
            'WriteErrorLog("", "", ex)
            MsgBox(ex.Message, MsgBoxStyle.Critical, Me.Text)
        End Try
    End Sub

End Class