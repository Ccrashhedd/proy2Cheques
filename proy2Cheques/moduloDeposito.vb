Imports System.Data.SqlClient
Imports MySqlConnector

Module moduloDeposito


    Dim cm As MySqlCommand
    Dim pr As MySqlDataAdapter
    Dim dsl As DataSet
    Dim conexion As String =
        "Server=localhost;Database=proycheque;Uid=root;Pwd=;"
    Dim miconexion As New MySqlConnection(conexion)


    Public Function agregarDeposito(ByVal idDepo As String,
                                    ByVal tipoDepo As Integer,
                                    ByVal fechaDepo As Date,
                                    ByVal monto As Double) As String
        Try
            Dim consulta As String = "INSERT INTO depositos(idDeposito, tipoDeposito, fechaDeposito, monto) " &
                                     "VALUES (@idDepo, @tipoDepo, @fechaDepo, @monto)"
            miconexion.Open()
            cm = New MySqlCommand(consulta, miconexion)
            cm.Parameters.AddWithValue("@idDepo", idDepo)
            cm.Parameters.AddWithValue("@tipoDepo", tipoDepo)
            cm.Parameters.AddWithValue("@fechaDepo", fechaDepo)
            cm.Parameters.AddWithValue("@monto", monto)
            cm.ExecuteNonQuery()
            miconexion.Close()
            Return "Depósito agregado correctamente."

        Catch ex As Exception
            Return "Error al registrar deposito: " & ex.Message
        End Try
    End Function

    ' Devuelve DataTable con depositos, incluyendo nombre del tipo
    Public Function ObtenerDepositos() As DataTable
        Dim dt As New DataTable()
        Try
            Dim sql As String = "SELECT d.idDeposito AS idDeposito, d.tipoDeposito AS tipoDeposito, " & _
                                "COALESCE(td.nombre, '') AS tipoNombre, d.monto AS monto, d.fechaDeposito AS fechaDeposito " & _
                                "FROM depositos d " & _
                                "LEFT JOIN TIPO_DEPOSITO td ON d.tipoDeposito = td.idTipoDepo " & _
                                "ORDER BY d.fechaDeposito DESC, d.idDeposito ASC;"
            Using da As New MySqlDataAdapter(sql, miconexion)
                da.Fill(dt)
            End Using
        Catch ex As Exception
            Debug.WriteLine("Error en ObtenerDepositos: " & ex.Message)
        End Try
        Return dt
    End Function

    ' Devuelve DataTable con tipos de deposito
    Public Function ObtenerTiposDeposito() As DataTable
        Dim dt As New DataTable()
        Try
            Dim sql As String = "SELECT idTipoDepo, nombre FROM TIPO_DEPOSITO ORDER BY nombre ASC;"
            Using da As New MySqlDataAdapter(sql, miconexion)
                da.Fill(dt)
            End Using
        Catch ex As Exception
            Debug.WriteLine("Error en ObtenerTiposDeposito: " & ex.Message)
        End Try
        Return dt
    End Function

End Module
