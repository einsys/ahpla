Public Class BMPTools
    Public Shared Function SplitBMP(ByRef Target As Bitmap, SplitNum As Integer) As Bitmap()
        Dim tWidthQ As Integer = Math.Floor(Target.Width / CSng(SplitNum))
        Dim tHeightQ As Integer = Math.Floor(Target.Height / CSng(SplitNum))
        Dim wR As Integer = Target.Width - tWidthQ * SplitNum
        Dim hR As Integer = Target.Height - tHeightQ * SplitNum
        Dim returnArr((SplitNum * SplitNum) - 1) As Bitmap
        Dim cWidth, cHeight As Integer

        For i As Integer = 0 To SplitNum - 1
            If i = SplitNum - 1 Then cHeight = tHeightQ + hR Else cHeight = tHeightQ

            For j As Integer = 0 To SplitNum - 1
                If j = SplitNum - 1 Then cWidth = tWidthQ + wR Else cWidth = tWidthQ
                Dim cropRect As New Rectangle(j * tWidthQ, i * tHeightQ, cWidth, cHeight)
                Dim newBMP As Bitmap = New Bitmap(cWidth, cHeight, Imaging.PixelFormat.Format32bppArgb)

                Dim g As Graphics = Graphics.FromImage(newBMP)
                g.DrawImage(Target, New Rectangle(0, 0, cWidth, cHeight), cropRect, GraphicsUnit.Pixel)
                g.Dispose()

                returnArr(i * SplitNum + j) = newBMP
            Next
        Next

        Return returnArr
    End Function

    Public Shared Function MergeBMP(ByRef Target() As Bitmap, SplitNum As Integer) As Bitmap
        Dim tWidth As Integer = (Target(0).Width * 3) + Target(SplitNum - 1).Width
        Dim tHeight As Integer = (Target(0).Height * 3) + Target.Last.Height
        Dim returnBMP As New Bitmap(tWidth, tHeight, Imaging.PixelFormat.Format32bppArgb)
        Dim g As Graphics = Graphics.FromImage(returnBMP)
        Dim cLeft As Integer = 0
        Dim cTop As Integer = 0
        Dim cWidth, cHeight As Integer

        For i As Integer = 0 To SplitNum - 1
            cLeft = 0

            For j As Integer = 0 To SplitNum - 1
                Dim id As Integer = (i * SplitNum) + j
                cWidth = Target(id).Width
                cHeight = Target(id).Height
                Dim cropRect As New Rectangle(0, 0, cWidth, cHeight)
                g.DrawImage(Target(id), New Rectangle(cLeft, cTop, cWidth, cHeight), cropRect, GraphicsUnit.Pixel)
                If j = SplitNum - 1 Then cTop += cHeight
                cLeft += cWidth
            Next
        Next

        g.Dispose()

        Return returnBMP
    End Function

    Public Shared Function GetColorOrder(R As Byte, G As Byte, B As Byte) As Byte
        'Complementary relations (Largest-mid-smallest)
        'RGB  BGR   1  2
        'RBG  GBR   4  5
        'GRB  BRG   7  8

        'R=G>B  R=G<B   10  11
        'R=B>G  R=B<G   13  14
        'G=B>R  G=B<R   16  17

        'R=G=B  255

        If R > G Then
            If R > B Then
                If G > B Then
                    Return 1
                Else
                    If G = B Then
                        Return 17
                    Else
                        Return 4
                    End If
                End If
            Else
                If R = B Then
                    Return 13
                Else
                    Return 8
                End If
            End If
        Else
            If R = G Then
                If R = B Then
                    Return 255
                Else
                    If R > B Then
                        Return 10
                    Else
                        Return 11
                    End If
                End If
            Else
                If R > B Then
                    Return 7
                Else
                    If G > B Then
                        Return 5
                    Else
                        If G = B Then
                            Return 16
                        Else
                            If R = B Then
                                Return 14
                            Else
                                Return 2
                            End If
                        End If
                    End If
                End If
            End If
        End If
    End Function

    Public Shared Function isReversedColor(ColorOrder1 As Byte, ColorOrder2 As Byte) As Boolean
        If Math.Abs(CInt(ColorOrder1) - ColorOrder2) = 1 Then
            Return True
        Else
            Return False
        End If
    End Function
End Class
