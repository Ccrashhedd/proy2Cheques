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

                ' Estado se guarda como entero en la BD (1 = Circulante)
                cmd.Parameters.AddWithValue("@estado", 1)

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
                ' Guardar estado como entero (0 = Anulado)
                cmd.Parameters.AddWithValue("@estado", 0)
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
        Finally
            If miconexion.State <> ConnectionState.Closed Then
                miconexion.Close()
            End If
        End Try

    End Function

    ' Devuelve un DataTable con los cheques y datos relacionados (proveedor, objeto de gasto)
    Public Function ObtenerCheques() As DataTable
        Dim dt As New DataTable()
        Try
            Dim sql As String = "SELECT c.idCheque, c.fechaCheque, c.monto, c.montoTexto, c.detalle, c.fechaAnulacion, c.estado, " &
                                "p.nombre AS proveedor, o.detalle AS objeto " &
                                "FROM cheques c " &
                                "LEFT JOIN proveedores p ON c.idProveedor = p.codigo " &
                                "LEFT JOIN objeto_gasto o ON c.idObjGasto = o.codigo " &
                                "ORDER BY c.estado DESC, p.nombre ASC;"

            Using da As New MySqlDataAdapter(sql, miconexion)
                da.Fill(dt)
            End Using
        Catch ex As Exception
            Debug.WriteLine("Error en ObtenerCheques: " & ex.Message)
        End Try
        Return dt
    End Function

End Module
