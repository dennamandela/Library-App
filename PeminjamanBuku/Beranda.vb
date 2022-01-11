Public Class Beranda

    Private Sub Beranda_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PictureBox1.Load("perpustakaan.jpg")
        PictureBox1.SizeMode = PictureBoxSizeMode.StretchImage
    End Sub

    Private Sub LogoutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LogoutToolStripMenuItem.Click
        If MsgBox("Anda yakin mau Logout?", vbQuestion + vbYesNo, "LOGOUT") = vbYes Then
            End
        End If
    End Sub
End Class