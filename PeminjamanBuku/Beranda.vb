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

    Private Sub FormAnggotaToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FormAnggotaToolStripMenuItem.Click
        FormAnggota.Show()
    End Sub

    Private Sub FormBukuToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FormBukuToolStripMenuItem.Click
        FormBuku.Show()
    End Sub

    Private Sub TransaksiPinjamToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TransaksiPinjamToolStripMenuItem.Click
        TransaksiPinjam.Show()
    End Sub
End Class