Imports System.Data.SqlClient
Imports MySqlConnector

Module moduloCheque

    Dim cm As MySqlCommand
    Dim pr As MySqlDataAdapter
    Dim dsl As DataSet
    Dim conexion As String =
        "Server=localhost;Database=proycheque;Uid=root;Pwd=;"
    Dim miconexion As New MySqlConnection(conexion)

    ' Mapa de estados: llave = código, valor = descripción
    Public ReadOnly estadoCheque As New Dictionary(Of Integer, String) From {
        {0, "Anulado"},
        {1, "Circulante"}
    }

    Public Function agregarCheque(ByVal numCheque As String,
                                  ByVal fecha As Date,
                                  ByVal idPRov As String,
                                  ByVal monto As Double,
                                  ByVal montoText As String,
                                  ByVal detalle As String,
                                  ByVal idObjGast As String) As String
        Try
            ' Validaciones básicas
            If String.IsNullOrWhiteSpace(numCheque) Then
                Return "El número de cheque no puede estar vacío."
            End If

            Dim consulta As String = "INSERT INTO cheques (idCheque, fechaCheque, idProveedor, monto, montoTexto, detalle, idObjGasto, estado) " &
                                     "VALUES (@idcheq, @fechacheq, @idprove, @monto, @montoText, @detalle, @idObGast, @estado);"

            Using cmd As New MySqlCommand(consulta, miconexion)
                cmd.Parameters.AddWithValue("@idcheq", numCheque)
                cmd.Parameters.AddWithValue("@fechacheq", fecha)
                cmd.Parameters.AddWithValue("@idprove", idPRov)
                cmd.Parameters.AddWithValue("@monto", monto)
                cmd.Parameters.AddWithValue("@montoText", montoText)
                cmd.Parameters.AddWithValue("@detalle", detalle)
                cmd.Parameters.AddWithValue("@idObGast", idObjGast)

                ' Estado se guarda como entero en la BD
                cmd.Parameters.AddWithValue("@estado", estadoCheque(1))

                miconexion.Open()
                cmd.ExecuteNonQuery()
                Return "Cheque agregado exitosamente."
            End Using

        Catch ex As Exception
            Return "Error al agregar el cheque: " & ex.Message
        Finally
            If miconexion.State <> ConnectionState.Closed Then
                miconexion.Close()
            End If
        End Try

    End Function


    Public Function anularCheque(ByVal numCheque As String) As String
        Dim fechaNul As Date = Date.Now
        Try
            Dim consulta As String = "UPDATE cheques SET fechaAnulacion = @fechaNul, estado = @estado WHERE idCheque = @nuCheque"
            Using cmd As New MySqlCommand(consulta, miconexion)
                cmd.Parameters.AddWithValue("@fechaNul", fechaNul)
                cmd.Parameters.AddWithValue("@estado", estadoCheque(0))
                cmd.Parameters.AddWithValue("@nuCheque", numCheque)
                miconexion.Open()
                Dim filasAfectadas As Integer = cmd.ExecuteNonQuery()
                If filasAfectadas > 0 Then
                    Return "Cheque anulado exitosamente."
                Else
                    Return "No se encontró el cheque especificado."
                End If
            End Using
        Catch ex As Exception
            Return "Error al anular el cheque: " & ex.Message
        End Try

    End Function

End Module
