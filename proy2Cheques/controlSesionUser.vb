Public Class controlSesionUser
    Private Sub controlSesionUser_Load(sender As Object, e As EventArgs) Handles MyBase.Load

    End Sub

    Private Sub MaterialButton1_Click(sender As Object, e As EventArgs) Handles MaterialButton1.Click
        formInicioSesion.Show()
    End Sub

    Private Sub MaterialCard1_Paint(sender As Object, e As PaintEventArgs) Handles MaterialCard1.Paint

    End Sub

    Private Sub MaterialButton2_Click(sender As Object, e As EventArgs) Handles MaterialButton2.Click
        ' para poder cerrar toda la aplicacion
        If MessageBox.Show("Desea Cerrar?", "Confirme cerrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub
End Class
