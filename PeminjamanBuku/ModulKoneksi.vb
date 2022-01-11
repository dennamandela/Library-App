Imports System.Data.SqlClient
Module ModulKoneksi
    Public Conn As SqlConnection
    Public cmd As SqlCommand
    Public DA As SqlDataAdapter
    Public DS As DataSet
    Public DR As SqlDataReader
    Dim LokasiData As String
    Sub Koneksi()
        LokasiData = "Data Source=DESKTOP-GEAG14C\SQLEXPRESS; Initial Catalog=perpustakaan; Integrated Security=True"
        Conn = New SqlConnection(LokasiData)
        If Conn.State = ConnectionState.Closed Then
            Conn.Open()
        Else
            MsgBox("Koneksi Gagal")
        End If
    End Sub

End Module
