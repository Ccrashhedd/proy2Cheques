Module Traduccion
    ' Función principal para convertir un número en palabras (dólares y centavos)
    Public Function ConvertirAMontoEnPalabras(monto As Decimal) As String
        ' Separar la parte de los dólares y los centavos
        Dim dolares As Integer = Math.Floor(monto) ' Parte entera (dólares)
        Dim centavos As Integer = (monto - dolares) * 100 ' Parte decimal (centavos)

        ' Convertir cada parte a palabras
        Dim parteDolares As String = ConvertirANumerosEnPalabras(dolares)
        Dim parteCentavos As String = ConvertirANumerosEnPalabras(centavos)

        ' Devolver el monto en formato adecuado
        If centavos = 0 Then
            Return $"{parteDolares} dólares"
        Else
            Return $"{parteDolares} dólares con {parteCentavos} centavos"
        End If
    End Function

    ' Función para convertir un número entero en palabras
    Private Function ConvertirANumerosEnPalabras(numero As Integer) As String
        ' Arrays de números y sus palabras equivalentes
        Dim unidades As String() = {"", "uno", "dos", "tres", "cuatro", "cinco", "seis", "siete", "ocho", "nueve"}
        Dim decenas As String() = {"", "", "veinte", "treinta", "cuarenta", "cincuenta", "sesenta", "setenta", "ochenta", "noventa"}
        Dim centenas As String() = {"", "cien", "doscientos", "trescientos", "cuatrocientos", "quinientos", "seiscientos", "setecientos", "ochocientos", "novecientos"}
        Dim especiales As String() = {"diez", "once", "doce", "trece", "catorce", "quince", "dieciséis", "diecisiete", "dieciocho", "diecinueve"}

        ' Inicializar la variable de salida
        Dim palabras As String = ""

        If numero = 0 Then
            Return "cero"
        End If

        ' Convertir centenas
        If numero >= 100 Then
            Dim centenasVal As Integer = Math.Floor(numero / 100)
            palabras &= centenas(centenasVal) & " "
            numero -= centenasVal * 100
        End If

        ' Convertir decenas
        If numero >= 20 Then
            Dim decenasVal As Integer = Math.Floor(numero / 10)
            palabras &= decenas(decenasVal) & " "
            numero -= decenasVal * 10
        ElseIf numero >= 10 Then
            palabras &= especiales(numero - 10) & " "
            Return palabras.Trim()
        End If

        ' Convertir unidades
        If numero > 0 Then
            palabras &= unidades(numero) & " "
        End If

        ' Devolver el resultado
        Return palabras.Trim()
    End Function
End Module
