Imports MySql.Data.MySqlClient
Imports MySqlConnector

Public Module ModuloConciliacion

    ' Cadena de conexión a la base de datos
    Dim conexion As String = "Server=localhost;Database=proycheque;Uid=root;Pwd=;"

    ' Función para guardar la conciliación en la base de datos
    Public Sub GuardarConciliacion(saldoLibros As Decimal, depositosTransito As Decimal, chequesPendientes As Decimal, saldoBanco As Decimal)
        Using conn As New MySqlConnection(conexion)
            Try
                conn.Open()

                ' Consulta SQL para insertar los datos
                Dim query As String = "INSERT INTO concilacion (fechaMes, saldoLibros, depositTransito, chequesPendientes, saldoBanco) " &
                                      "VALUES (@fechaMes, @saldoLibros, @depositosTransito, @chequesPendientes, @saldoBanco)"

                ' Comando SQL
                Using cmd As New MySqlCommand(query, conn)
                    cmd.Parameters.AddWithValue("@fechaMes", DateTime.Now) ' Fecha actual
                    cmd.Parameters.AddWithValue("@saldoLibros", saldoLibros)
                    cmd.Parameters.AddWithValue("@depositosTransito", depositosTransito)
                    cmd.Parameters.AddWithValue("@chequesPendientes", chequesPendientes)
                    cmd.Parameters.AddWithValue("@saldoBanco", saldoBanco)

                    ' Ejecutar el comando
                    cmd.ExecuteNonQuery()
                End Using

            Catch ex As Exception
                Throw New Exception("Error al guardar la conciliación: " & ex.Message)
            End Try
        End Using
    End Sub

End Module
