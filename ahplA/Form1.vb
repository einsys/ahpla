Public Class frmMain
    Private Sub txtF1_DragDrop(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles txtF1.DragDrop
        txtF1.Text = e.Data.GetData(DataFormats.FileDrop)(0)
    End Sub

    Private Sub txtF1_DragEnter(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles txtF1.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then e.Effect = DragDropEffects.Copy
    End Sub

    Private Sub txtF2_DragDrop(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles txtF2.DragDrop
        txtF2.Text = e.Data.GetData(DataFormats.FileDrop)(0)
    End Sub

    Private Sub txtF2_DragEnter(sender As Object, e As System.Windows.Forms.DragEventArgs) Handles txtF2.DragEnter
        If e.Data.GetDataPresent(DataFormats.FileDrop) Then e.Effect = DragDropEffects.Copy
    End Sub

    Private Sub btnWork_Click(sender As System.Object, e As System.EventArgs) Handles btnWork.Click
        Dim Setting As Byte = 0
        If chkMD.Checked Then Setting = 1
        If chkHI.Checked Then Setting = 2
        If chkNO.Checked Then Setting = 3

        Dim newAlpha As New AlphaDecompositioner
        newAlpha.StartProc(txtF1.Text, txtF2.Text, CInt(txtTH.Text), Setting)
    End Sub
End Class
