Imports System.Data.SqlClient
Public Class FormAnggota
    Sub baca()
        Call Koneksi()
        DA = New SqlDataAdapter("select * from anggota", Conn)
        DS = New DataSet
        DS.Clear()
        DA.Fill(DS, "anggota")
        DataGridView1.DataSource = (DS.Tables("anggota"))
        ComboBox1.Items.Clear()
        ComboBox1.Items.Add("Pria")
        ComboBox1.Items.Add("Wanita")
    End Sub
    Sub kosong()
        TextBox1.Text = ""
        TextBox2.Text = ""
        TextBox3.Text = ""
        TextBox4.Text = ""
        TextBox5.Text = ""
        ComboBox1.Text = ""
        Button1.Enabled = True
        Button2.Enabled = True
        Button3.Enabled = True
        Button4.Enabled = True
    End Sub

    Private Sub FormAnggota_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call baca()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        If TextBox1.Text = "" Or TextBox2.Text = "" Or TextBox3.Text = "" Or TextBox4.Text = "" Or TextBox5.Text = "" Or ComboBox1.Text = "" Then
            MsgBox("Data belum lengkap, pastikan semua form terisi")
            Exit Sub
        Else
            Call Koneksi()
            Dim simpan As String = "insert into anggota values ('" & TextBox1.Text & "', '" & TextBox2.Text & "', '" & TextBox3.Text & "', '" & TextBox4.Text & "' , '" & TextBox5.Text & "', '" & ComboBox1.Text & "')"
            cmd = New SqlCommand(simpan, Conn)
            cmd.ExecuteNonQuery()
            MsgBox("Data berhasil di Input", MsgBoxStyle.Information, "Information")
            Call baca()
            Call kosong()
        End If
    End Sub

    Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
        Call Koneksi()
        Dim update As String
        update = "update anggota set nama='" & TextBox2.Text & "',alamat='" & TextBox3.Text & "',kota='" & TextBox4.Text & "',no_telp='" & TextBox5.Text & "', jenis_kelamin='" & ComboBox1.Text & "' where id_anggota='" & TextBox1.Text & "'"
        cmd = New SqlCommand(update, Conn)
        cmd.ExecuteNonQuery()
        MsgBox("Data Berhasil Terupdate", MsgBoxStyle.Information, "Informasi")
        TextBox1.Enabled = True
        Call baca()
        Call kosong()
    End Sub

    Private Sub Button3_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button3.Click
        Call Koneksi()
        Dim delete As String = "delete from anggota where id_anggota = '" & TextBox1.Text & "'"
        cmd = New SqlCommand(delete, Conn)
        cmd.ExecuteNonQuery()
        MsgBox("Data Berhasil Terhapus", MsgBoxStyle.Information, "Informasi")
        TextBox1.Enabled = True
        Call baca()
        Call kosong()
    End Sub

    Private Sub Button4_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button4.Click
        Close()
    End Sub
End Class