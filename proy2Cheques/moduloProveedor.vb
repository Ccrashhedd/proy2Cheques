Imports System.Data.SqlClient
Imports MySqlConnector

Module moduloProveedor

    Dim cm As MySqlCommand
    Dim pr As MySqlDataAdapter
    Dim dsl As DataSet
    Dim conexion As String =
        "Server=localhost;Database=proycheque;Uid=root;Pwd=;"
    Dim miconexion As New MySqlConnection(conexion)


    Public Function agregarProveedor(ByVal codigo As String,
                                     ByVal nombre As String,
                                     ByVal ruc As String,
                                     ByVal direccion As String) As String
        Try
            miconexion.Open()
            Dim consulta As String =
                "INSERT INTO proveedores(codigo,nombre,ruc,direccion) " &
                "VALUES(@codigo,@nombre,@ruc,@direccion)"
            cm = New MySqlCommand(consulta, miconexion)
            cm.Parameters.AddWithValue("@codigo", codigo)
            cm.Parameters.AddWithValue("@nombre", nombre)
            cm.Parameters.AddWithValue("@ruc", ruc)
            cm.Parameters.AddWithValue("@direccion", direccion)
            cm.ExecuteNonQuery()
            miconexion.Close()
            Return "Proveedor agregado correctamente."

        Catch ex As Exception
            Return "Error al agregar proveedor: " & ex.Message
        End Try
    End Function

    Public Function editarProveedor(ByVal codigo As String,
                                    ByVal nombre As String,
                                    ByVal ruc As String,
                                    ByVal direecion As String) As String
        Try
            Dim updateQuery As String =
                "UPDATE proveedores SET nombre=@nombre, ruc=@ruc, direccion=@direccion " &
                "WHERE codigo=@codigo"
            miconexion.Open()
            cm = New MySqlCommand(updateQuery, miconexion)
            cm.Parameters.AddWithValue("@codigo", codigo)
            cm.Parameters.AddWithValue("@nombre", nombre)
            cm.Parameters.AddWithValue("@ruc", ruc)
            cm.Parameters.AddWithValue("@direccion", direecion)
            cm.ExecuteNonQuery()
            miconexion.Close()
            Return "Proveedor editado correctamente."
        Catch ex As Exception
            Return "Error al editar proveedor: " & ex.Message
        End Try

    End Function

    ' Devuelve DataTable con proveedores
    Public Function ObtenerProveedores() As DataTable
        Dim dt As New DataTable()
        Try
            Dim sql As String = "SELECT codigo, nombre, ruc, direccion FROM proveedores ORDER BY nombre ASC;"
            Using da As New MySqlDataAdapter(sql, miconexion)
                da.Fill(dt)
            End Using
        Catch ex As Exception
            Debug.WriteLine("Error en ObtenerProveedores: " & ex.Message)
        End Try
        Return dt
    End Function
End Module
