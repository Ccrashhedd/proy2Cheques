Imports MySql.Data.MySqlClient
Imports MySqlConnector

Public Class userConConcil

    ' Declaramos los controles de los campos de texto
    Private Sub btnGuardar_Click(sender As Object, e As EventArgs) Handles btnGuardar.Click
        ' Primero validamos si los campos están correctamente llenados
        If Not ValidarCampos() Then
            MessageBox.Show("Por favor, complete todos los campos.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Return
        End If

        ' Luego obtenemos los datos desde la base de datos
        Dim saldoLibros As Decimal = ObtenerSaldoSegunLibros()
        Dim depositosTransito As Decimal = ObtenerDepositosEnTransito()
        Dim chequesPendientes As Decimal = ObtenerChequesPendientes()

        ' Cálculo del saldo conciliado
        Dim saldoConciliado As Decimal = CalcularSaldoConciliado(saldoLibros, depositosTransito, chequesPendientes)

        ' Comparamos el saldo conciliado con el saldo bancario ingresado
        Dim saldoBanco As Decimal = Convert.ToDecimal(txtSaldoBanco.Text)

        If saldoConciliado <> saldoBanco Then
            Label6.Text = "Valores deben ser iguales"
            Label6.ForeColor = Color.Red
        Else
            Label6.Text = ""
            ' Guardar la conciliación en la base de datos
            GuardarConciliacion(saldoLibros, depositosTransito, chequesPendientes, saldoBanco, saldoConciliado)
            MessageBox.Show("Conciliación guardada correctamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        ' Actualizar el campo de saldo conciliado total
        txtSaldoConciliado.Text = saldoConciliado.ToString("C2")
    End Sub

    ' Función para validar que los campos no estén vacíos
    Private Function ValidarCampos() As Boolean
        If String.IsNullOrEmpty(txtSaldoSegunLibros.Text) OrElse
           String.IsNullOrEmpty(txtDepositosTransito.Text) OrElse
           String.IsNullOrEmpty(txtChequesPendientes.Text) OrElse
           String.IsNullOrEmpty(txtSaldoBanco.Text) Then
            Return False
        End If
        Return True
    End Function

    ' Función para obtener el saldo según libros de la base de datos
    Private Function ObtenerSaldoSegunLibros() As Decimal
        ' Aquí va la lógica para obtener el saldo según libros desde la base de datos
        ' Ejemplo de consulta a la base de datos:
        Dim saldo As Decimal = 0
        Dim query As String = "SELECT saldo_libros FROM conciliaciones WHERE mes = @mes AND anio = @anio"
        Using conn As New MySqlConnection("server=localhost;user=root;database=proycheque;port=3306;password=")
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@mes", MonthComboBox.SelectedIndex + 1)
                cmd.Parameters.AddWithValue("@anio", YearComboBox.SelectedItem.ToString())
                conn.Open()
                saldo = Convert.ToDecimal(cmd.ExecuteScalar())
            End Using
        End Using
        Return saldo
    End Function

    ' Función para obtener los depósitos en tránsito desde la base de datos
    Private Function ObtenerDepositosEnTransito() As Decimal
        ' Lógica para obtener depósitos en tránsito
        Dim totalDepositos As Decimal = 0
        Dim query As String = "SELECT SUM(monto) FROM depositos WHERE mes = @mes AND anio = @anio"
        Using conn As New MySqlConnection("server=localhost;user=root;database=proycheque;port=3306;password=")
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@mes", MonthComboBox.SelectedIndex + 1)
                cmd.Parameters.AddWithValue("@anio", YearComboBox.SelectedItem.ToString())
                conn.Open()
                totalDepositos = Convert.ToDecimal(cmd.ExecuteScalar())
            End Using
        End Using
        Return totalDepositos
    End Function

    ' Función para obtener los cheques pendientes desde la base de datos
    Private Function ObtenerChequesPendientes() As Decimal
        ' Lógica para obtener cheques pendientes
        Dim totalCheques As Decimal = 0
        Dim query As String = "SELECT SUM(monto) FROM cheques WHERE mes = @mes AND anio = @anio AND estado = 'Pendiente'"
        Using conn As New MySqlConnection("server=localhost;user=root;database=proycheque;port=3306;password=")
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@mes", MonthComboBox.SelectedIndex + 1)
                cmd.Parameters.AddWithValue("@anio", YearComboBox.SelectedItem.ToString())
                conn.Open()
                totalCheques = Convert.ToDecimal(cmd.ExecuteScalar())
            End Using
        End Using
        Return totalCheques
    End Function

    ' Función para calcular el saldo conciliado
    Private Function CalcularSaldoConciliado(saldoLibros As Decimal, depositosTransito As Decimal, chequesPendientes As Decimal) As Decimal
        ' Saldo conciliado = saldo libros + depósitos en tránsito - cheques pendientes
        Return saldoLibros + depositosTransito - chequesPendientes
    End Function

    ' Función para guardar la conciliación en la base de datos
    Private Sub GuardarConciliacion(saldoLibros As Decimal, depositosTransito As Decimal, chequesPendientes As Decimal, saldoBanco As Decimal, saldoConciliado As Decimal)
        ' Lógica para guardar la conciliación
        Dim query As String = "INSERT INTO conciliaciones (mes, anio, saldo_libros, depositos_transito, cheques_pendientes, saldo_banco, saldo_conciliado) " &
                              "VALUES (@mes, @anio, @saldoLibros, @depositosTransito, @chequesPendientes, @saldoBanco, @saldoConciliado)"
        Using conn As New MySqlConnection("server=localhost;user=root;database=proycheque;port=3306;password=")
            Using cmd As New MySqlCommand(query, conn)
                cmd.Parameters.AddWithValue("@mes", MonthComboBox.SelectedIndex + 1)
                cmd.Parameters.AddWithValue("@anio", YearComboBox.SelectedItem.ToString())
                cmd.Parameters.AddWithValue("@saldoLibros", saldoLibros)
                cmd.Parameters.AddWithValue("@depositosTransito", depositosTransito)
                cmd.Parameters.AddWithValue("@chequesPendientes", chequesPendientes)
                cmd.Parameters.AddWithValue("@saldoBanco", saldoBanco)
                cmd.Parameters.AddWithValue("@saldoConciliado", saldoConciliado)
                conn.Open()
                cmd.ExecuteNonQuery()
            End Using
        End Using
    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles Label8.Click

    End Sub

    Private Sub YearComboBox_SelectedIndexChanged(sender As Object, e As EventArgs) Handles YearComboBox.SelectedIndexChanged

    End Sub
End Class
