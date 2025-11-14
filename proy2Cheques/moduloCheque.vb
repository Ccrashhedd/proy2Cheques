Imports System.Data.SqlClient
Imports MySqlConnector

Module moduloCheque

    Dim cm As MySqlCommand
    Dim pr As MySqlDataAdapter
    Dim dsl As DataSet
    Dim conexion As String =
        "Server=localhost;Database=proycheque;Uid=root;Pwd=;"
    Dim miconexion As New MySqlConnection(conexion)


    Public Function agregarCheque(ByVal numCheque As String,
                                  ByVal fecha As Date,
                                  ByVal idPRov As String,
                                  ByVal monto As Double,
                                  ByVal montoText As String,
                                  ByVal detalle As String,
                                  ByVal idObjGast As String,
                                  ByVal fechaAnul As Date,
                                  ByVal estado As Integer) As String
        Try
            ' Validaciones básicas
            If String.IsNullOrWhiteSpace(numCheque) Then
                Return "El número de cheque no puede estar vacío."
            End If

            Dim consulta As String = "INSERT INTO cheques (idCheque, fechaCheque, idProveedor, monto, montoTexto, detalle, idObjGasto, fechaAnulacion, estado) " &
                "VALUES (@idcheq, @fechacheq, @idprove, @monto, @montoText, @detalle, @idObGast, @fechAnul, @estado);"

            Using cmd As New MySqlCommand(consulta, miconexion)
                cmd.Parameters.AddWithValue("@idcheq", numCheque)
                cmd.Parameters.AddWithValue("@fechacheq", fecha)
                cmd.Parameters.AddWithValue("@idprove", idPRov)
                cmd.Parameters.AddWithValue("@monto", monto)
                cmd.Parameters.AddWithValue("@montoText", montoText)
                cmd.Parameters.AddWithValue("@detalle", detalle)
                cmd.Parameters.AddWithValue("@idObGast", idObjGast)

                ' Manejar fecha de anulación nullable
                If fechaAnul = Date.MinValue Then
                    cmd.Parameters.AddWithValue("@fechAnul", DBNull.Value)
                Else
                    cmd.Parameters.AddWithValue("@fechAnul", fechaAnul)
                End If

                cmd.Parameters.AddWithValue("@estado", estado)

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

End Module
