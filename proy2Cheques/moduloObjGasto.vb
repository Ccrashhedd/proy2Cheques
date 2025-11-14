Imports System.Data.SqlClient
Imports MySqlConnector

Module moduloObjGasto

    Dim cm As MySqlCommand
    Dim pr As MySqlDataAdapter
    Dim dsl As DataSet
    Dim conexion As String =
        "Server=localhost;Database=proycheque;Uid=root;Pwd=;"

    Public Function agregarObjGas(ByVal codigo As String,
                                  ByVal detalle As String,
                                  ByVal objeto As String) As String
        Try
            Dim consulta As String = "INSERT INTO objeto_gasto(codigo, detalle, objeto) " &
                                     "VALUES (@codigo, @detalle, @objeto)"
            Using conn As New MySqlConnection(conexion)
                conn.Open()
                Using cmd As New MySqlCommand(consulta, conn)
                    cmd.Parameters.AddWithValue("@codigo", codigo)
                    cmd.Parameters.AddWithValue("@detalle", detalle)
                    cmd.Parameters.AddWithValue("@objeto", objeto)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            Return "Objeto de gasto agregado correctamente."
        Catch ex As Exception
            Return "Error al agregar objeto: " & ex.Message
        End Try

    End Function

    Public Function editarObjGas(ByVal codigo As String,
                                 ByVal detalle As String,
                                 ByVal objeto As String) As String
        Try
            Dim updateQuery As String = "UPDATE objeto_gasto SET detalle=@detalle, objeto=@objeto " &
                                        "WHERE codigo=@codigo"
            Using conn As New MySqlConnection(conexion)
                conn.Open()
                Using cmd As New MySqlCommand(updateQuery, conn)
                    cmd.Parameters.AddWithValue("@codigo", codigo)
                    cmd.Parameters.AddWithValue("@detalle", detalle)
                    cmd.Parameters.AddWithValue("@objeto", objeto)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            Return "Objeto de gasto editado correctamente."
        Catch ex As Exception
            Return "Error al editar objeto: " & ex.Message
        End Try
    End Function

    Public Function eliminarObjGas(ByVal codigo As String) As String
        Try
            Dim deleteQuery As String = "DELETE FROM objeto_gasto WHERE codigo=@codigo"
            Using conn As New MySqlConnection(conexion)
                conn.Open()
                Using cmd As New MySqlCommand(deleteQuery, conn)
                    cmd.Parameters.AddWithValue("@codigo", codigo)
                    cmd.ExecuteNonQuery()
                End Using
            End Using
            Return "Objeto de gasto eliminado correctamente."
        Catch ex As Exception
            Return "Error al eliminar objeto: " & ex.Message
        End Try
    End Function

    ' Devuelve DataTable con objetos de gasto ordenados por detalle
    Public Function ObtenerObjGastos() As DataTable
        Dim dt As New DataTable()
        Try
            Dim sql As String = "SELECT codigo, detalle, objeto FROM objeto_gasto ORDER BY detalle ASC;"
            Using conn As New MySqlConnection(conexion)
                Using da As New MySqlDataAdapter(sql, conn)
                    da.Fill(dt)
                End Using
            End Using
        Catch ex As Exception
            Debug.WriteLine("Error en ObtenerObjGastos: " & ex.Message)
        End Try
        Return dt
    End Function

End Module
