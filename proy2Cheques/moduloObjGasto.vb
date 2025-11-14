Imports System.Data.SqlClient
Imports MySqlConnector

Module moduloObjGasto

    Dim cm As MySqlCommand
    Dim pr As MySqlDataAdapter
    Dim dsl As DataSet
    Dim conexion As String =
        "Server=localhost;Database=proycheque;Uid=root;Pwd=;"
    Dim miconexion As New MySqlConnection(conexion)

    Public Function agregarObjGas(ByVal codigo As String,
                                  ByVal detalle As String,
                                  ByVal objeto As String) As String
        Try
            Dim consulta As String = "INSERT INTO objeto_gasto(codigo, detalle, objeto) " &
                                     "VALUES (@codigo, @detalle, @objeto)"
            miconexion.Open()
            cm = New MySqlCommand(consulta, miconexion)
            cm.Parameters.AddWithValue("@codigo", codigo)
            cm.Parameters.AddWithValue("@detalle", detalle)
            cm.Parameters.AddWithValue("@objeto", objeto)
            cm.ExecuteNonQuery()
            miconexion.Close()
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
            miconexion.Open()
            cm = New MySqlCommand(updateQuery, miconexion)
            cm.Parameters.AddWithValue("@codigo", codigo)
            cm.Parameters.AddWithValue("@detalle", detalle)
            cm.Parameters.AddWithValue("@objeto", objeto)
            cm.ExecuteNonQuery()
            miconexion.Close()
            Return "Objeto de gasto editado correctamente."
        Catch ex As Exception
            Return "Error al editar objeto: " & ex.Message
        End Try
    End Function

    Public Function eliminarObjGas(ByVal codigo As String) As String
        Try
            Dim deleteQuery As String = "DELETE FROM objeto_gasto WHERE codigo=@codigo"
            miconexion.Open()
            cm = New MySqlCommand(deleteQuery, miconexion)
            cm.Parameters.AddWithValue("@codigo", codigo)
            cm.ExecuteNonQuery()
            miconexion.Close()
            Return "Objeto de gasto eliminado correctamente."
        Catch ex As Exception
            Return "Error al eliminar objeto: " & ex.Message
        End Try
    End Function

End Module
