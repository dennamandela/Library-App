Imports System.Data.SqlClient
Public Class TransaksiPinjam
    Sub awal()
        Call NoOtomatis()
        Call KodeAnggota()
        LBLnama.Text = ""
        LBLalamat.Text = ""
        LBLtelepon.Text = ""
        LBLjudul.Text = ""
        LBLpengarang.Text = ""
        LBLtahun.Text = ""
        ComboBox1.Text = ""
        Call Kolom()
    End Sub

    Private Sub TransaksiPinjam_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Call awal()
    End Sub
    Sub NoOtomatis()
        Call Koneksi()
        cmd = New SqlCommand("select * from peminjaman where no_peminjaman in (select max (no_peminjaman) from peminjaman)", Conn)
        Dim urutanKode As String
        Dim hitung As Long
        DR = cmd.ExecuteReader
        DR.Read()
        If Not DR.HasRows Then
            urutanKode = "PJ" + Format(Now, "yyMMdd") + "001"
        Else
            hitung = Microsoft.VisualBasic.Right(DR.GetString(0), 9) + 1
            urutanKode = "PJ" + Format(Now, "yyMMdd") + Microsoft.VisualBasic.Right("000" & hitung, 3)
        End If
        LBLnopinjam.Text = urutanKode
        ' TextBox2.Text = Focus()
    End Sub
    Sub KodeAnggota()
        Call Koneksi()
        ComboBox1.Items.Clear()
        cmd = New SqlCommand("select * from anggota", Conn)
        DR = cmd.ExecuteReader
        Do While DR.Read
            ComboBox1.Items.Add(DR.Item(0))
        Loop
    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ComboBox1.SelectedIndexChanged
        Call Koneksi()
        cmd = New SqlCommand("select * from anggota where id_anggota = '" & ComboBox1.Text & "'", Conn)
        DR = cmd.ExecuteReader
        DR.Read()
        If DR.HasRows Then
            LBLnama.Text = DR!nama
            LBLalamat.Text = DR!alamat
            LBLtelepon.Text = DR!no_telp
        End If
    End Sub
    Sub Kolom()
        DataGridView1.Columns.Clear()
        DataGridView1.Columns.Add("no_buku", "No Buku")
        DataGridView1.Columns.Add("judul", "Judul Buku")
        DataGridView1.Columns.Add("pengarang", "Pengarang")
        DataGridView1.Columns.Add("tahun_terbit", "Tahun Terbit")
        DataGridView1.Columns.Add("status", "Status")
    End Sub

    Private Sub TextBox2_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TextBox2.KeyPress
        If e.KeyChar = Chr(13) Then
            Call Koneksi()
            cmd = New SqlCommand("select * from buku where no_buku = '" & TextBox2.Text & "'", Conn)
            DR = cmd.ExecuteReader
            DR.Read()
            If Not DR.HasRows Then
                MsgBox("No Buku Tidak Ada!")
            Else
                TextBox2.Text = DR.Item("no_buku")
                LBLjudul.Text = DR.Item("judul")
                LBLpengarang.Text = DR.Item("pengarang")
                LBLtahun.Text = DR.Item("tahun_terbit")
                TextBox1.Text = DR.Item("status")
            End If
        End If
    End Sub


    Private Sub btnInput_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnInput.Click
        If LBLjudul.Text = "" Or TextBox1.Text = "" Then
            MsgBox("Silahkan masukkan no buku dan tekan ENTER!")
        Else
            DataGridView1.Rows.Add(New String() {TextBox2.Text, LBLjudul.Text, LBLpengarang.Text, LBLtahun.Text, TextBox1.Text})
            TextBox2.Text = ""
            LBLjudul.Text = ""
            LBLpengarang.Text = ""
            LBLtahun.Text = ""
            TextBox1.Text = ""
        End If
    End Sub

    Private Sub btnSimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSimpan.Click
        If LBLnama.Text = "" Then
            MsgBox("Peminjaman Tidak Ada, Silahkan lakukan peminjaman terlebih dahulu")
        Else
            Call Koneksi()
            Dim tanggal As String
            Dim tanggalKedua As String
            tanggal = Format(Today, "yyyy-MM-dd")
            tanggalKedua = Format(Today, "yyyy-MM-dd")
            Dim PinjamBuku As String = "insert into peminjaman values ('" & LBLnopinjam.Text & "', '" & ComboBox1.Text & "', '" & TextBox2.Text & "', '" & tanggal & "', '" & tanggalKedua & "')"
            cmd = New SqlCommand(PinjamBuku, Conn)
            cmd.ExecuteNonQuery()

            For baris As Integer = 0 To DataGridView1.Rows.Count - 2
                Call Koneksi()
                cmd = New SqlCommand("select * from buku where no_buku = '" & DataGridView1.Rows(baris).Cells(0).Value & "'", Conn)
                cmd.ExecuteNonQuery()
            Next
            Call awal()
            MsgBox("Data Berhasil Disimpan")
        End If
    End Sub

    Private Sub btnBatal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnBatal.Click
        Call awal()
    End Sub

    Private Sub btnKeluar_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnKeluar.Click
        If MsgBox("Anda yakin mau Keluar?", vbQuestion + vbYesNo, "Informasi") = vbYes Then
            End
        End If
    End Sub
End Class