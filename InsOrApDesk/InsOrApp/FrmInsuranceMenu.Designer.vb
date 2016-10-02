<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmInsuranceMenu
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmInsuranceMenu))
        Me.BtnContract = New System.Windows.Forms.Button()
        Me.BtnKleidari8mos = New System.Windows.Forms.Button()
        Me.BtnCustomer = New System.Windows.Forms.Button()
        Me.BtnExit = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'BtnContract
        '
        Me.BtnContract.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BtnContract.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.BtnContract.Location = New System.Drawing.Point(116, 147)
        Me.BtnContract.Name = "BtnContract"
        Me.BtnContract.Size = New System.Drawing.Size(287, 31)
        Me.BtnContract.TabIndex = 5
        Me.BtnContract.Text = "Νέο Ασφαλιστικό Συμβόλαιο"
        Me.BtnContract.UseVisualStyleBackColor = False
        '
        'BtnKleidari8mos
        '
        Me.BtnKleidari8mos.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BtnKleidari8mos.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.BtnKleidari8mos.Location = New System.Drawing.Point(116, 103)
        Me.BtnKleidari8mos.Name = "BtnKleidari8mos"
        Me.BtnKleidari8mos.Size = New System.Drawing.Size(287, 31)
        Me.BtnKleidari8mos.TabIndex = 4
        Me.BtnKleidari8mos.Text = "Έκδοση Κλειδάριθμου"
        Me.BtnKleidari8mos.UseVisualStyleBackColor = False
        '
        'BtnCustomer
        '
        Me.BtnCustomer.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BtnCustomer.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.BtnCustomer.Location = New System.Drawing.Point(116, 59)
        Me.BtnCustomer.Name = "BtnCustomer"
        Me.BtnCustomer.Size = New System.Drawing.Size(287, 31)
        Me.BtnCustomer.TabIndex = 3
        Me.BtnCustomer.Text = "Καταχώρηση νέου Πελάτη"
        Me.BtnCustomer.UseVisualStyleBackColor = False
        '
        'BtnExit
        '
        Me.BtnExit.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BtnExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.BtnExit.Location = New System.Drawing.Point(116, 191)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(287, 31)
        Me.BtnExit.TabIndex = 5
        Me.BtnExit.Text = "Επιστροφή στο  Κεντρικό Μενού"
        Me.BtnExit.UseVisualStyleBackColor = False
        '
        'FrmInsuranceMenu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(498, 303)
        Me.Controls.Add(Me.BtnExit)
        Me.Controls.Add(Me.BtnContract)
        Me.Controls.Add(Me.BtnKleidari8mos)
        Me.Controls.Add(Me.BtnCustomer)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "FrmInsuranceMenu"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Μενού Ασφαλιστή"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BtnContract As Button
    Friend WithEvents BtnKleidari8mos As Button
    Friend WithEvents BtnCustomer As Button
    Friend WithEvents BtnExit As Button
End Class
