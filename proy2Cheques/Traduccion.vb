Module Traduccion

    ' Convierte un monto decimal (hasta 2 decimales) a texto en español: "x dólares con y centavos"
    Public Function ConvertirAMontoEnPalabras(monto As Decimal) As String
        ' Normalizar a dos decimales
        monto = Decimal.Round(monto, 2)

        ' Parte entera y centavos
        Dim dolares As Long = CLng(Math.Truncate(monto))
        Dim centavos As Integer = CInt(Decimal.Round((monto - dolares) * 100D))

        ' Ajuste si el redondeo produce 100 centavos
        If centavos = 100 Then
            dolares += 1
            centavos = 0
        End If

        ' Convertir a palabras
        Dim parteDolares As String = ConvertirNumeroEnPalabras(dolares)
        Dim parteCentavos As String = ConvertirNumeroEnPalabras(centavos)

        ' Formateo final con singular/plural
        Dim resultado As String
        If centavos = 0 Then
            If dolares = 1 Then
                resultado = "un dólar"
            Else
                resultado = String.Format("{0} dólares", parteDolares)
            End If
        Else
            If dolares = 0 Then
                resultado = String.Format("{0} centavos", parteCentavos)
            ElseIf dolares = 1 Then
                resultado = String.Format("un dólar con {0} centavos", parteCentavos)
            Else
                resultado = String.Format("{0} dólares con {1} centavos", parteDolares, parteCentavos)
            End If
        End If

        Return resultado
    End Function

    ' Convierte un número entero no negativo a palabras en español (soporta hasta miles de millones)
    Private Function ConvertirNumeroEnPalabras(numero As Long) As String
        If numero = 0 Then Return "cero"
        If numero < 0 Then Return "menos " & ConvertirNumeroEnPalabras(Math.Abs(numero))

        Dim partes As New List(Of String)()

        Dim millones = (numero \ 1000000)
        Dim restoMillones = numero Mod 1000000

        If millones > 0 Then
            If millones = 1 Then
                partes.Add("un millón")
            Else
                partes.Add(ConvertirHasta999(millones) & " millones")
            End If
            numero = restoMillones
        End If

        Dim miles = numero \ 1000
        Dim restoMiles = numero Mod 1000

        If miles > 0 Then
            If miles = 1 Then
                partes.Add("mil")
            Else
                partes.Add(ConvertirHasta999(miles) & " mil")
            End If
            numero = restoMiles
        End If

        If numero > 0 Then
            partes.Add(ConvertirHasta999(numero))
        End If

        Return String.Join(" ", partes).Trim()
    End Function

    ' Convierte 0..999 a palabras
    Private Function ConvertirHasta999(numero As Long) As String
        Dim unidades() As String = {"", "un", "dos", "tres", "cuatro", "cinco", "seis", "siete", "ocho", "nueve", "diez", "once", "doce", "trece", "catorce", "quince", "dieciséis", "diecisiete", "dieciocho", "diecinueve"}
        Dim decenas() As String = {"", "", "veinte", "treinta", "cuarenta", "cincuenta", "sesenta", "setenta", "ochenta", "noventa"}
        Dim centenas() As String = {"", "ciento", "doscientos", "trescientos", "cuatrocientos", "quinientos", "seiscientos", "setecientos", "ochocientos", "novecientos"}

        Dim n As Integer = CInt(numero)
        Dim parts As New List(Of String)()

        ' Centenas
        If n >= 100 Then
            If n = 100 Then
                parts.Add("cien")
            Else
                parts.Add(centenas(n \ 100))
            End If
            n = n Mod 100
        End If

        ' Decenas y unidades
        If n >= 20 Then
            Dim d As Integer = n \ 10
            Dim u As Integer = n Mod 10
            If d = 2 AndAlso u > 0 Then
                ' 21..29 -> veintiuno, veintidós...
                parts.Add("veinti" & unidades(u))
            Else
                If u = 0 Then
                    parts.Add(decenas(d))
                Else
                    parts.Add(decenas(d) & " y " & unidades(u))
                End If
            End If
        ElseIf n > 0 Then
            parts.Add(unidades(n))
        End If

        Return String.Join(" ", parts).Trim()
    End Function

End Module
