Imports System.Globalization
Imports MySql.Data.MySqlClient
Imports MySqlConnector

Public Class FormConciliacion

    ' Definición de los campos
    Private saldoSegunLibros As Decimal
    Private depositosTransito As Decimal
    Private chequesPendientes As Decimal
    Private saldoBanco As Decimal

    ' Evento que carga el formulario
    Private Sub FormConciliacion_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Inicializar valores de los campos
        txtSaldoSegunLibros.Text = "0.00"
        txtDepositosTransito.Text = "0.00"
        txtChequesPendientes.Text = "0.00"
        txtSaldoBanco.Text = "0.00"
    End Sub

    ' Evento que guarda los datos
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        ' Validación de la conciliación
        If Not ValidarConciliacion() Then
            MessageBox.Show("Los saldos no coinciden. No se puede guardar la conciliación.", "Error de conciliación", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Si la validación es correcta, guardar en la base de datos
        GuardarConciliacion()
    End Sub

    ' Método para validar la conciliación
    Private Function ValidarConciliacion() As Boolean
        ' Leer los valores de los campos
        saldoSegunLibros = Convert.ToDecimal(txtSaldoSegunLibros.Text)
        depositosTransito = Convert.ToDecimal(txtDepositosTransito.Text)
        chequesPendientes = Convert.ToDecimal(txtChequesPendientes.Text)
        saldoBanco = Convert.ToDecimal(txtSaldoBanco.Text)

        ' Calcular el saldo conciliado
        Dim saldoConciliado As Decimal = saldoSegunLibros + depositosTransito - chequesPendientes

        ' Comparar los saldos
        If saldoConciliado <> saldoBanco Then
            Return False
        End If

        Return True
    End Function

    ' Método para guardar la conciliación en la base de datos
    Private Sub GuardarConciliacion()
        ' Conexión a la base de datos (Asegúrate de tener los datos correctos)
        Dim conexion As String = "Server=localhost;Database=proycheque;Uid=root;Pwd=;"
        Using conn As New MySqlConnection(conexion)
            Try
                conn.Open()
                ' Consulta SQL para insertar los datos
                Dim query As String = "INSERT INTO concilacion (fechaMes, saldoLibros, depositTransito, chequesPendientes, saldoBanco) " &
                                      "VALUES (@fechaMes, @saldoLibros, @depositosTransito, @chequesPendientes, @saldoBanco)"

                ' Comando SQL
                Using cmd As New MySqlCommand(query, conn)
                    ' Agregar parámetros
                    cmd.Parameters.AddWithValue("@fechaMes", DateTime.Now) ' Fecha actual
                    cmd.Parameters.AddWithValue("@saldoLibros", saldoSegunLibros)
                    cmd.Parameters.AddWithValue("@depositosTransito", depositosTransito)
                    cmd.Parameters.AddWithValue("@chequesPendientes", chequesPendientes)
                    cmd.Parameters.AddWithValue("@saldoBanco", saldoBanco)

                    ' Ejecutar el comando
                    cmd.ExecuteNonQuery()
                End Using

                ' Mostrar mensaje de éxito
                MessageBox.Show("La conciliación se ha guardado correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)

            Catch ex As Exception
                ' Manejo de errores
                MessageBox.Show("Error al guardar la conciliación: " & ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            End Try
        End Using
    End Sub

End Class
