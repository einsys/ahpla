Imports System.Math
Imports ahplA.BMPTools

Public Class AlphaDecompositioner
    Const SPLIT_NUM As Integer = 4

    Dim BMP1, BMP2, BMP3 As Bitmap
    Dim BMP1s() As Bitmap
    Dim BMP2s() As Bitmap
    Dim BMP3s(SPLIT_NUM ^ 2 - 1) As Bitmap
    Dim compNum As Integer
    Dim F1, F2 As String
    Dim Sett As Byte

    Private Class CompResult
        Public BMP As Bitmap
        Public ID As Integer

        Public Sub New(BMP As Bitmap, ID As Integer)
            Me.BMP = BMP
            Me.ID = ID
        End Sub
    End Class

    Public Class Comparator
        Dim AlpStpArr(,) As Integer = {{0, 1, 2}, {1, 0, 2}, {2, 1, 0}}
        Dim AlpStpVal() As Integer = {0, 84, 170, 255}

        Public BMP1 As Bitmap
        Public BMP2 As Bitmap
        Public TH As Integer
        Public ID As Integer
        Public Sett As Byte

        Function Comp() As Bitmap
            Dim BMP3 As New Bitmap(BMP1.Width, BMP1.Height, Imaging.PixelFormat.Format32bppArgb)

            For i As Integer = 0 To BMP1.Width - 1
                For j As Integer = 0 To BMP1.Height - 1
                    Dim P1 As Color = BMP1.GetPixel(i, j)
                    Dim P2 As Color = BMP2.GetPixel(i, j)
                    Dim ColorOrderMax = GetColorOrder(P2.R, P2.G, P2.B)

                    If Abs(CInt(P1.R) - P2.R) > TH OrElse Abs(CInt(P1.G) - P2.G) > TH OrElse Abs(CInt(P1.B) - P2.B) > TH Then
                        Dim Found As Boolean = False
                        Dim pA, pR, pG, pB As Integer
                        Dim kA, kB As Integer

                        If Sett < 3 Then
                            For Stp As Integer = 0 To 2
                                kA = AlpStpVal(AlpStpArr(Sett, Stp)) + 1
                                kB = AlpStpVal(AlpStpArr(Sett, Stp) + 1)

                                For k As Integer = kA To kB
                                    Dim Alpha As Single = k / 255.0F

                                    Try
                                        pR = CInt((CInt(P2.R) - P1.R) / Alpha + P1.R)
                                        If pR < 0 Or pR > 255 Then Continue For
                                        pG = CInt((CInt(P2.G) - P1.G) / Alpha + P1.G)
                                        If pG < 0 Or pG > 255 Then Continue For
                                        pB = CInt((CInt(P2.B) - P1.B) / Alpha + P1.B)
                                        If pB < 0 Or pB > 255 Then Continue For

                                        Dim ColorOrderCurrent = GetColorOrder(pR, pG, pB)
                                        If isReversedColor(ColorOrderCurrent, ColorOrderMax) Then Continue For

                                        pA = k
                                        Found = True
                                        Exit For
                                    Catch ex As Exception
                                        Continue For
                                    End Try
                                Next

                                If Found Then Exit For
                            Next
                        End If

                        If Found Then
                            BMP3.SetPixel(i, j, Color.FromArgb(pA, pR, pG, pB))
                        Else
                            BMP3.SetPixel(i, j, P2)
                        End If
                    Else
                        BMP3.SetPixel(i, j, Color.Transparent)
                    End If
                Next
            Next

            Return BMP3
        End Function
    End Class

    Public Sub StartProc(File1 As String, File2 As String, TH As Integer, Setting As Byte)
        Me.F1 = File1
        Me.F2 = File2
        Me.Sett = Setting

        BMP1 = New Bitmap(F1)
        BMP2 = New Bitmap(F2)
        BMP1s = SplitBMP(BMP1, SPLIT_NUM)
        BMP2s = SplitBMP(BMP2, SPLIT_NUM)
        compNum = 0

        For i As Integer = 0 To SPLIT_NUM ^ 2 - 1
            Dim newComp As New Comparator
            newComp.BMP1 = BMP1s(i)
            newComp.BMP2 = BMP2s(i)
            newComp.TH = TH
            newComp.ID = i
            newComp.Sett = Sett

            Dim nBW As New System.ComponentModel.BackgroundWorker
            AddHandler nBW.DoWork, AddressOf BW_DoWork
            AddHandler nBW.RunWorkerCompleted, AddressOf BW_RunWorkerCompleted
            nBW.RunWorkerAsync(newComp)
        Next
    End Sub

    Private Sub BW_DoWork(ByVal sender As Object, ByVal e As System.ComponentModel.DoWorkEventArgs)
        Dim Comp As Comparator = CType(e.Argument, Comparator)
        e.Result = New CompResult(Comp.Comp(), Comp.ID)
    End Sub

    Private Sub BW_RunWorkerCompleted(ByVal sender As Object, ByVal e As System.ComponentModel.RunWorkerCompletedEventArgs)
        Dim cResult As CompResult = CType(e.Result, CompResult)
        BMP3s(cResult.ID) = cResult.BMP
        compNum += 1
        If compNum = SPLIT_NUM ^ 2 Then FinalizeProc()
    End Sub

    Private Sub FinalizeProc()
        BMP3 = MergeBMP(BMP3s, SPLIT_NUM)

        Dim fInfo = My.Computer.FileSystem.GetFileInfo(F2)
        Dim dName = fInfo.Directory.FullName & "\"
        Dim fName = fInfo.Name.Split({"."}, StringSplitOptions.RemoveEmptyEntries)(0) & "_.png"

        Dim pLT = BMP3.GetPixel(0, 0)
        Dim pRB = BMP3.GetPixel(BMP1.Width - 1, BMP1.Height - 1)

        If pLT.A = 0 Then
            BMP3.SetPixel(0, 0, Color.FromArgb(1, 0, 0, 0))
        End If

        If pRB.A = 0 Then
            BMP3.SetPixel(BMP1.Width - 1, BMP1.Height - 1, Color.FromArgb(1, 0, 0, 0))
        End If

        BMP3.Save(dName & fName, Imaging.ImageFormat.Png)

        BMP1.Dispose()
        BMP2.Dispose()
        BMP3.Dispose()

        For i As Integer = 0 To SPLIT_NUM ^ 2 - 1
            BMP1s(i).Dispose()
            BMP2s(i).Dispose()
            BMP3s(i).Dispose()
        Next
    End Sub
End Class
