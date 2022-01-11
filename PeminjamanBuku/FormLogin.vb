Imports System.Data.SqlClient
Public Class FormLogin

    Private Sub login_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles login.Click
        If username.Text = "" Or password.Text = "" Then
            MsgBox("Isikan Username dan Password dengan benar!")
        Else
            Call Koneksi()
            cmd = New SqlCommand("select * from login where username='" & username.Text & "' and password='" & password.Text & "'", Conn)
            DR = cmd.ExecuteReader
            DR.Read()
            If DR.HasRows Then
                Me.Hide()
                Beranda.Show()
            Else
                MsgBox("Username dan Password anda salah!")
            End If
        End If
    End Sub
End Class