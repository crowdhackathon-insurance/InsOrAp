Imports System.ComponentModel

Public Class FrmMainMenu
    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles BtnExit.Click
        Me.Close()
    End Sub

    Private Sub FrmMainMenu_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If MsgBox("Έξοδος από την εφαρμογή InsOrApp?", MsgBoxStyle.OkCancel + MsgBoxStyle.Question, Me.Text) = MsgBoxResult.Cancel Then
            e.Cancel = True
            Exit Sub
        End If
    End Sub

    Private Sub BtnInsurance_Click(sender As Object, e As EventArgs) Handles BtnInsurance.Click
        Dim InsuranceMenu As New FrmInsuranceMenu
        If InsuranceMenu.ShowDialog = DialogResult.Abort Then

        End If
        InsuranceMenu = Nothing
    End Sub

    Private Sub BtnCallCenter_Click(sender As Object, e As EventArgs) Handles BtnCallCenter.Click
        Dim InsuranceAdmin As New FrmInsuranceAdmin
        If InsuranceAdmin.ShowDialog = DialogResult.Abort Then

        End If
        InsuranceAdmin = Nothing
    End Sub


End Class