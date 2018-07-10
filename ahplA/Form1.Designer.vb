<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmMain
    Inherits System.Windows.Forms.Form

    'Form은 Dispose를 재정의하여 구성 요소 목록을 정리합니다.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows Form 디자이너에 필요합니다.
    Private components As System.ComponentModel.IContainer

    '참고: 다음 프로시저는 Windows Form 디자이너에 필요합니다.
    '수정하려면 Windows Form 디자이너를 사용하십시오.  
    '코드 편집기에서는 수정하지 마세요.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.chkNO = New System.Windows.Forms.RadioButton()
        Me.chkMD = New System.Windows.Forms.RadioButton()
        Me.chkHI = New System.Windows.Forms.RadioButton()
        Me.chkLO = New System.Windows.Forms.RadioButton()
        Me.txtTH = New System.Windows.Forms.TextBox()
        Me.txtF2 = New System.Windows.Forms.TextBox()
        Me.txtF1 = New System.Windows.Forms.TextBox()
        Me.btnWork = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'chkNO
        '
        Me.chkNO.AutoSize = True
        Me.chkNO.Location = New System.Drawing.Point(308, 86)
        Me.chkNO.Name = "chkNO"
        Me.chkNO.Size = New System.Drawing.Size(32, 16)
        Me.chkNO.TabIndex = 15
        Me.chkNO.Text = "N"
        Me.chkNO.UseVisualStyleBackColor = True
        '
        'chkMD
        '
        Me.chkMD.AutoSize = True
        Me.chkMD.Location = New System.Drawing.Point(308, 52)
        Me.chkMD.Name = "chkMD"
        Me.chkMD.Size = New System.Drawing.Size(34, 16)
        Me.chkMD.TabIndex = 14
        Me.chkMD.Text = "M"
        Me.chkMD.UseVisualStyleBackColor = True
        '
        'chkHI
        '
        Me.chkHI.AutoSize = True
        Me.chkHI.Location = New System.Drawing.Point(308, 69)
        Me.chkHI.Name = "chkHI"
        Me.chkHI.Size = New System.Drawing.Size(31, 16)
        Me.chkHI.TabIndex = 13
        Me.chkHI.Text = "H"
        Me.chkHI.UseVisualStyleBackColor = True
        '
        'chkLO
        '
        Me.chkLO.AutoSize = True
        Me.chkLO.Checked = True
        Me.chkLO.Location = New System.Drawing.Point(308, 35)
        Me.chkLO.Name = "chkLO"
        Me.chkLO.Size = New System.Drawing.Size(30, 16)
        Me.chkLO.TabIndex = 12
        Me.chkLO.TabStop = True
        Me.chkLO.Text = "L"
        Me.chkLO.UseVisualStyleBackColor = True
        '
        'txtTH
        '
        Me.txtTH.AllowDrop = True
        Me.txtTH.Location = New System.Drawing.Point(308, 11)
        Me.txtTH.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtTH.Name = "txtTH"
        Me.txtTH.Size = New System.Drawing.Size(29, 21)
        Me.txtTH.TabIndex = 11
        Me.txtTH.Text = "0"
        '
        'txtF2
        '
        Me.txtF2.AllowDrop = True
        Me.txtF2.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtF2.Location = New System.Drawing.Point(11, 59)
        Me.txtF2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtF2.Multiline = True
        Me.txtF2.Name = "txtF2"
        Me.txtF2.Size = New System.Drawing.Size(291, 42)
        Me.txtF2.TabIndex = 10
        '
        'txtF1
        '
        Me.txtF1.AllowDrop = True
        Me.txtF1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.txtF1.Location = New System.Drawing.Point(11, 11)
        Me.txtF1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.txtF1.Multiline = True
        Me.txtF1.Name = "txtF1"
        Me.txtF1.Size = New System.Drawing.Size(291, 42)
        Me.txtF1.TabIndex = 9
        '
        'btnWork
        '
        Me.btnWork.Anchor = CType((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnWork.Location = New System.Drawing.Point(342, 11)
        Me.btnWork.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.btnWork.Name = "btnWork"
        Me.btnWork.Size = New System.Drawing.Size(41, 90)
        Me.btnWork.TabIndex = 8
        Me.btnWork.Text = "GO"
        Me.btnWork.UseVisualStyleBackColor = True
        '
        'frmMain
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(394, 112)
        Me.Controls.Add(Me.chkNO)
        Me.Controls.Add(Me.chkMD)
        Me.Controls.Add(Me.chkHI)
        Me.Controls.Add(Me.chkLO)
        Me.Controls.Add(Me.txtTH)
        Me.Controls.Add(Me.txtF2)
        Me.Controls.Add(Me.txtF1)
        Me.Controls.Add(Me.btnWork)
        Me.Name = "frmMain"
        Me.Text = "ahplA"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents chkNO As RadioButton
    Friend WithEvents chkMD As RadioButton
    Friend WithEvents chkHI As RadioButton
    Friend WithEvents chkLO As RadioButton
    Friend WithEvents txtTH As TextBox
    Friend WithEvents txtF2 As TextBox
    Friend WithEvents txtF1 As TextBox
    Friend WithEvents btnWork As Button
End Class
