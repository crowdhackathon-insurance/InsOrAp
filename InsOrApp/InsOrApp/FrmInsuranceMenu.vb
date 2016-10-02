Imports System.ComponentModel

Public Class FrmInsuranceMenu
    Private Sub BtnExit_Click(sender As Object, e As EventArgs) Handles BtnExit.Click
        Me.Close()
    End Sub

    Private Sub BtnCustomer_Click(sender As Object, e As EventArgs) Handles BtnCustomer.Click
        Dim Customer As New FrmInsuranceCustomer
        If Customer.ShowDialog = DialogResult.Abort Then

        End If
        Customer = Nothing
    End Sub

    Private Sub BtnKleidari8mos_Click(sender As Object, e As EventArgs) Handles BtnKleidari8mos.Click
        Dim KLEIDAR As New FrmInsuranceCustomer_KLEIDAR
        If KLEIDAR.ShowDialog = DialogResult.Abort Then

        End If
        KLEIDAR = Nothing
    End Sub

    Private Sub BtnContract_Click(sender As Object, e As EventArgs) Handles BtnContract.Click
        Dim Symvolaio As New FrmInsuranceContract
        If Symvolaio.ShowDialog = DialogResult.Abort Then

        End If
        Symvolaio = Nothing
    End Sub
End Class