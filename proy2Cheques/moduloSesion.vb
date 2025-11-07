Module moduloSesion
    ' Evento público de sesión
    Public Event sesionChanged()

    ' Lock para seguridad de hilos
    Private ReadOnly _lock As New Object()

    ' Estado interno (campos privados)
    Private _sesionIniciada As Boolean = False
    Private _nombreUsuario As String = String.Empty
    Private _idUsuario As String = String.Empty

    ' Propiedades públicas de sólo lectura
    Public ReadOnly Property sesionIniciada As Boolean
        Get
            SyncLock _lock
                Return _sesionIniciada
            End SyncLock
        End Get
    End Property

    Public ReadOnly Property nombreUsuario As String
        Get
            SyncLock _lock
                Return _nombreUsuario
            End SyncLock
        End Get
    End Property

    Public ReadOnly Property idUsuario As String
        Get
            SyncLock _lock
                Return _idUsuario
            End SyncLock
        End Get
    End Property

    ' Alias para compatibilidad si en otras partes usabas la variante con typo
    Public ReadOnly Property idUsusario As String
        Get
            Return idUsuario
        End Get
    End Property

    ' Método para iniciar sesión: único punto de modificación del estado
    Public Sub loged(username As String, userid As String)
        SyncLock _lock
            _sesionIniciada = True
            _nombreUsuario = username
            _idUsuario = userid
        End SyncLock
        RaiseEvent sesionChanged()
    End Sub

    ' Método para cerrar sesión y limpiar variables
    Public Sub logout()
        SyncLock _lock
            _sesionIniciada = False
            _nombreUsuario = String.Empty
            _idUsuario = String.Empty
        End SyncLock
        RaiseEvent sesionChanged()
    End Sub


    ' Funcion para obtener respuesta de sesion iniciada
    Public Function isLogged() As Boolean
        SyncLock _lock
            Return _sesionIniciada
        End SyncLock
    End Function
End Module
