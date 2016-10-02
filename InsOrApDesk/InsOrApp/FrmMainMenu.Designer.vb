<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmMainMenu
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmMainMenu))
        Me.BtnInsurance = New System.Windows.Forms.Button()
        Me.BtnCallCenter = New System.Windows.Forms.Button()
        Me.BtnExit = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'BtnInsurance
        '
        Me.BtnInsurance.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BtnInsurance.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.BtnInsurance.Location = New System.Drawing.Point(76, 73)
        Me.BtnInsurance.Name = "BtnInsurance"
        Me.BtnInsurance.Size = New System.Drawing.Size(287, 31)
        Me.BtnInsurance.TabIndex = 0
        Me.BtnInsurance.Text = "Είσοδος ως Ασφαλιστής"
        Me.BtnInsurance.UseVisualStyleBackColor = False
        '
        'BtnCallCenter
        '
        Me.BtnCallCenter.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BtnCallCenter.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.BtnCallCenter.Location = New System.Drawing.Point(76, 116)
        Me.BtnCallCenter.Name = "BtnCallCenter"
        Me.BtnCallCenter.Size = New System.Drawing.Size(287, 31)
        Me.BtnCallCenter.TabIndex = 1
        Me.BtnCallCenter.Text = "Είσοδος ως Υπεύθυνος Τηλεφωνικού Κέντρου"
        Me.BtnCallCenter.UseVisualStyleBackColor = False
        '
        'BtnExit
        '
        Me.BtnExit.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BtnExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.BtnExit.Location = New System.Drawing.Point(76, 159)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(287, 31)
        Me.BtnExit.TabIndex = 2
        Me.BtnExit.Text = "Έξοδος από την εφαρμογή InsOrApp"
        Me.BtnExit.UseVisualStyleBackColor = False
        '
        'FrmMainMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(420, 262)
        Me.Controls.Add(Me.BtnExit)
        Me.Controls.Add(Me.BtnCallCenter)
        Me.Controls.Add(Me.BtnInsurance)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "FrmMainMenu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Κεντρικό Μενού Εφαρμογής InsOrApp"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BtnInsurance As Button
    Friend WithEvents BtnCallCenter As Button
    Friend WithEvents BtnExit As Button
End Class
