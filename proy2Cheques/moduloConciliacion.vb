Imports MySql.Data.MySqlClient
Imports MySqlConnector

Module ModuloConciliacion
    ' Cadena de conexión a la base de datos (usar la misma que en todo el proyecto)
    Private ReadOnly cs As String = "Server=127.0.0.1;Port=3306;Database=bdcbancaria;User ID=root;Password=;SslMode=None;"

    ' Registrar conciliación en la base de datos
    Public Function RegistrarConciliacion(saldoLibros As Decimal, saldoBanco As Decimal) As String
        ' Validar si los saldos coinciden
        If saldoLibros <> saldoBanco Then
            Return "Los saldos no coinciden. No se puede registrar la conciliación."
        End If

        ' Conexión a la base de datos
        Try
            Using connection As New MySqlConnection(cs)
                connection.Open()

                ' Consulta SQL para insertar la conciliación
                Dim query As String = "INSERT INTO conciliaciones (saldoLibros, saldoBanco, fechaConciliacion) VALUES (@saldoLibros, @saldoBanco, @fechaConciliacion)"

                Using cmd As New MySqlCommand(query, connection)
                    cmd.Parameters.AddWithValue("@saldoLibros", saldoLibros)
                    cmd.Parameters.AddWithValue("@saldoBanco", saldoBanco)
                    cmd.Parameters.AddWithValue("@fechaConciliacion", DateTime.Now)

                    cmd.ExecuteNonQuery()
                End Using
            End Using

            Return "Conciliación registrada exitosamente."
        Catch ex As Exception
            Return "Error al registrar la conciliación: " & ex.Message
        End Try
    End Function

    ' Obtener conciliaciones registradas
    Public Function ObtenerConciliaciones() As DataTable
        Dim dt As New DataTable()

        Try
            Using connection As New MySqlConnection(cs)
                connection.Open()

                ' Consulta SQL para obtener todas las conciliaciones
                Dim query As String = "SELECT idConciliacion, saldoLibros, saldoBanco, fechaConciliacion FROM conciliaciones ORDER BY fechaConciliacion DESC"
                Using da As New MySqlDataAdapter(query, connection)
                    da.Fill(dt)
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al obtener conciliaciones: " & ex.Message)
        End Try

        Return dt
    End Function

    ' Obtener el total de cheques del mes actual
    Public Function ObtenerCheques() As Decimal
        Dim totalCheques As Decimal = 0D

        Try
            Using connection As New MySqlConnection(cs)
                connection.Open()
                Dim query As String = "SELECT SUM(monto) FROM cheques WHERE estado = 'Pendiente' AND MONTH(fecha) = MONTH(NOW())"
                Using cmd As New MySqlCommand(query, connection)
                    totalCheques = Convert.ToDecimal(cmd.ExecuteScalar())
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al obtener los cheques: " & ex.Message)
        End Try

        Return totalCheques
    End Function

    ' Obtener el total de depósitos del mes actual
    Public Function ObtenerDepositos() As Decimal
        Dim totalDepositos As Decimal = 0D

        Try
            Using connection As New MySqlConnection(cs)
                connection.Open()
                Dim query As String = "SELECT SUM(monto) FROM depósitos WHERE MONTH(fecha) = MONTH(NOW())"
                Using cmd As New MySqlCommand(query, connection)
                    totalDepositos = Convert.ToDecimal(cmd.ExecuteScalar())
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show("Error al obtener los depósitos: " & ex.Message)
        End Try

        Return totalDepositos
    End Function

End Module
