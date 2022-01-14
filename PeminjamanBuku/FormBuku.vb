Imports System.Data.SqlClient
Public Class FormBuku
    Sub baca()
        Call Koneksi()
        DA = New SqlDataAdapter("select * from buku", Conn)
        DS = New DataSet
        DS.Clear()
        DA.Fill(DS, "buku")
        DataGridView1.DataSource = (DS.Tables("buku"))
    End Sub
    Sub kosong()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        TextBox6.Text = ""
        Button1.Enabled = True
        Button2.Enabled = True
    End Sub

    Private Sub FormBuku_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call baca()

    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or TextBox6.Text = "" Then
            MsgBox("Data belum lengkap, pastikan semua form terisi")
            Exit Sub
        Else
            Call Koneksi()
            Dim simpan As String = "insert into buku values ('" & TextBox1.Text & "', '" & TextBox2.Text & "', '" & TextBox3.Text & "', '" & TextBox4.Text & "' , '" & TextBox5.Text & "', '" & TextBox6.Text & "')"
            cmd = New SqlCommand(simpan, Conn)
            cmd.ExecuteNonQuery()
            MsgBox("Data berhasil di Input", MsgBoxStyle.Information, "Information")
            Call baca()
            Call kosong()
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Dim update As String
        update = "update buku set judul='" & TextBox2.Text & "',pengarang='" & TextBox3.Text & "',tahun_terbit='" & TextBox4.Text & "',jenis_buku='" & TextBox5.Text & "', status='" & TextBox6.Text & "' where no_buku='" & TextBox1.Text & "'"
        cmd = New SqlCommand(update, Conn)
        cmd.ExecuteNonQuery()
        MsgBox("Data Sudah Terupdate", MsgBoxStyle.Information, "Informasi")
        TextBox1.Enabled = True
        Call baca()
        Call kosong()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Dim hapus As String
        hapus = "delete from buku where no_buku='" & TextBox1.Text & "'"
        cmd = New SqlCommand(hapus, Conn)
        cmd.ExecuteNonQuery()
        MsgBox("Data Sudah Terhapus", MsgBoxStyle.Information, "Informasi")
        TextBox1.Enabled = True
        Call baca()
        Call kosong()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Close()
    End Sub
End Class