<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmInsuranceCustomer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmInsuranceCustomer))
        Me.GroupBoxCustomer = New System.Windows.Forms.GroupBox()
        Me.Customer_id_txt = New System.Windows.Forms.TextBox()
        Me.Email_txt = New System.Windows.Forms.TextBox()
        Me.Name_txt = New System.Windows.Forms.TextBox()
        Me.Surname_txt = New System.Windows.Forms.TextBox()
        Me.LblCustomer_id = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBoxEdit = New System.Windows.Forms.GroupBox()
        Me.BtnStep1 = New System.Windows.Forms.Button()
        Me.BtnExit = New System.Windows.Forms.Button()
        Me.GroupBoxView = New System.Windows.Forms.GroupBox()
        Me.BtnStep2 = New System.Windows.Forms.Button()
        Me.BtnEdit = New System.Windows.Forms.Button()
        Me.GroupBoxFinal = New System.Windows.Forms.GroupBox()
        Me.BtnPrint = New System.Windows.Forms.Button()
        Me.ButtonFinalExit = New System.Windows.Forms.Button()
        Me.GroupBoxCustomer.SuspendLayout()
        Me.GroupBoxEdit.SuspendLayout()
        Me.GroupBoxView.SuspendLayout()
        Me.GroupBoxFinal.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBoxCustomer
        '
        Me.GroupBoxCustomer.Controls.Add(Me.Customer_id_txt)
        Me.GroupBoxCustomer.Controls.Add(Me.Email_txt)
        Me.GroupBoxCustomer.Controls.Add(Me.Name_txt)
        Me.GroupBoxCustomer.Controls.Add(Me.Surname_txt)
        Me.GroupBoxCustomer.Controls.Add(Me.LblCustomer_id)
        Me.GroupBoxCustomer.Controls.Add(Me.Label3)
        Me.GroupBoxCustomer.Controls.Add(Me.Label2)
        Me.GroupBoxCustomer.Controls.Add(Me.Label1)
        Me.GroupBoxCustomer.Location = New System.Drawing.Point(12, 12)
        Me.GroupBoxCustomer.Name = "GroupBoxCustomer"
        Me.GroupBoxCustomer.Size = New System.Drawing.Size(626, 185)
        Me.GroupBoxCustomer.TabIndex = 0
        Me.GroupBoxCustomer.TabStop = False
        Me.GroupBoxCustomer.Text = "Στοιχεία Πελάτη"
        '
        'Customer_id_txt
        '
        Me.Customer_id_txt.BackColor = System.Drawing.Color.White
        Me.Customer_id_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Customer_id_txt.Location = New System.Drawing.Point(168, 142)
        Me.Customer_id_txt.MaxLength = 50
        Me.Customer_id_txt.Name = "Customer_id_txt"
        Me.Customer_id_txt.ReadOnly = True
        Me.Customer_id_txt.Size = New System.Drawing.Size(431, 24)
        Me.Customer_id_txt.TabIndex = 3
        Me.Customer_id_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Email_txt
        '
        Me.Email_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Email_txt.Location = New System.Drawing.Point(168, 96)
        Me.Email_txt.MaxLength = 50
        Me.Email_txt.Name = "Email_txt"
        Me.Email_txt.Size = New System.Drawing.Size(431, 24)
        Me.Email_txt.TabIndex = 2
        '
        'Name_txt
        '
        Me.Name_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Name_txt.Location = New System.Drawing.Point(169, 66)
        Me.Name_txt.MaxLength = 50
        Me.Name_txt.Name = "Name_txt"
        Me.Name_txt.Size = New System.Drawing.Size(431, 24)
        Me.Name_txt.TabIndex = 1
        '
        'Surname_txt
        '
        Me.Surname_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Surname_txt.Location = New System.Drawing.Point(169, 36)
        Me.Surname_txt.MaxLength = 50
        Me.Surname_txt.Name = "Surname_txt"
        Me.Surname_txt.Size = New System.Drawing.Size(431, 24)
        Me.Surname_txt.TabIndex = 0
        '
        'LblCustomer_id
        '
        Me.LblCustomer_id.AutoSize = True
        Me.LblCustomer_id.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.LblCustomer_id.Location = New System.Drawing.Point(38, 145)
        Me.LblCustomer_id.Name = "LblCustomer_id"
        Me.LblCustomer_id.Size = New System.Drawing.Size(124, 18)
        Me.LblCustomer_id.TabIndex = 0
        Me.LblCustomer_id.Text = "Κωδικός Πελάτη:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label3.Location = New System.Drawing.Point(38, 99)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(49, 18)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Email:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label2.Location = New System.Drawing.Point(38, 69)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(58, 18)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Όνομα:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label1.Location = New System.Drawing.Point(38, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(71, 18)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Επώνυμο:"
        '
        'GroupBoxEdit
        '
        Me.GroupBoxEdit.Controls.Add(Me.BtnStep1)
        Me.GroupBoxEdit.Controls.Add(Me.BtnExit)
        Me.GroupBoxEdit.Location = New System.Drawing.Point(12, 233)
        Me.GroupBoxEdit.Name = "GroupBoxEdit"
        Me.GroupBoxEdit.Size = New System.Drawing.Size(626, 50)
        Me.GroupBoxEdit.TabIndex = 1
        Me.GroupBoxEdit.TabStop = False
        '
        'BtnStep1
        '
        Me.BtnStep1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BtnStep1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.BtnStep1.Location = New System.Drawing.Point(439, 13)
        Me.BtnStep1.Name = "BtnStep1"
        Me.BtnStep1.Size = New System.Drawing.Size(161, 31)
        Me.BtnStep1.TabIndex = 5
        Me.BtnStep1.Text = "Συνέχεια"
        Me.BtnStep1.UseVisualStyleBackColor = False
        '
        'BtnExit
        '
        Me.BtnExit.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BtnExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.BtnExit.Location = New System.Drawing.Point(6, 13)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(325, 31)
        Me.BtnExit.TabIndex = 4
        Me.BtnExit.Text = "Ακύρωση && επιστροφή στο μενού Ασφαλιστή"
        Me.BtnExit.UseVisualStyleBackColor = False
        '
        'GroupBoxView
        '
        Me.GroupBoxView.Controls.Add(Me.BtnStep2)
        Me.GroupBoxView.Controls.Add(Me.BtnEdit)
        Me.GroupBoxView.Location = New System.Drawing.Point(12, 298)
        Me.GroupBoxView.Name = "GroupBoxView"
        Me.GroupBoxView.Size = New System.Drawing.Size(626, 50)
        Me.GroupBoxView.TabIndex = 1
        Me.GroupBoxView.TabStop = False
        '
        'BtnStep2
        '
        Me.BtnStep2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BtnStep2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.BtnStep2.Location = New System.Drawing.Point(439, 13)
        Me.BtnStep2.Name = "BtnStep2"
        Me.BtnStep2.Size = New System.Drawing.Size(161, 31)
        Me.BtnStep2.TabIndex = 7
        Me.BtnStep2.Text = "Οριστικοποίηση"
        Me.BtnStep2.UseVisualStyleBackColor = False
        '
        'BtnEdit
        '
        Me.BtnEdit.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BtnEdit.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.BtnEdit.Location = New System.Drawing.Point(6, 13)
        Me.BtnEdit.Name = "BtnEdit"
        Me.BtnEdit.Size = New System.Drawing.Size(325, 31)
        Me.BtnEdit.TabIndex = 6
        Me.BtnEdit.Text = "Διόρθωση"
        Me.BtnEdit.UseVisualStyleBackColor = False
        '
        'GroupBoxFinal
        '
        Me.GroupBoxFinal.Controls.Add(Me.BtnPrint)
        Me.GroupBoxFinal.Controls.Add(Me.ButtonFinalExit)
        Me.GroupBoxFinal.Location = New System.Drawing.Point(12, 354)
        Me.GroupBoxFinal.Name = "GroupBoxFinal"
        Me.GroupBoxFinal.Size = New System.Drawing.Size(626, 50)
        Me.GroupBoxFinal.TabIndex = 1
        Me.GroupBoxFinal.TabStop = False
        '
        'BtnPrint
        '
        Me.BtnPrint.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BtnPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.BtnPrint.Location = New System.Drawing.Point(439, 13)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(161, 31)
        Me.BtnPrint.TabIndex = 9
        Me.BtnPrint.Text = "Εκτύπωση"
        Me.BtnPrint.UseVisualStyleBackColor = False
        '
        'ButtonFinalExit
        '
        Me.ButtonFinalExit.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ButtonFinalExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.ButtonFinalExit.Location = New System.Drawing.Point(6, 13)
        Me.ButtonFinalExit.Name = "ButtonFinalExit"
        Me.ButtonFinalExit.Size = New System.Drawing.Size(325, 31)
        Me.ButtonFinalExit.TabIndex = 8
        Me.ButtonFinalExit.Text = "Ολοκλήρωση"
        Me.ButtonFinalExit.UseVisualStyleBackColor = False
        '
        'FrmInsuranceCustomer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(650, 287)
        Me.Controls.Add(Me.GroupBoxFinal)
        Me.Controls.Add(Me.GroupBoxView)
        Me.Controls.Add(Me.GroupBoxEdit)
        Me.Controls.Add(Me.GroupBoxCustomer)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "FrmInsuranceCustomer"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Καταχώρηση νέου Πελάτη"
        Me.GroupBoxCustomer.ResumeLayout(False)
        Me.GroupBoxCustomer.PerformLayout()
        Me.GroupBoxEdit.ResumeLayout(False)
        Me.GroupBoxView.ResumeLayout(False)
        Me.GroupBoxFinal.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBoxCustomer As GroupBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents GroupBoxEdit As GroupBox
    Friend WithEvents GroupBoxView As GroupBox
    Friend WithEvents GroupBoxFinal As GroupBox
    Friend WithEvents BtnStep1 As Button
    Friend WithEvents BtnExit As Button
    Friend WithEvents BtnStep2 As Button
    Friend WithEvents BtnEdit As Button
    Friend WithEvents BtnPrint As Button
    Friend WithEvents ButtonFinalExit As Button
    Friend WithEvents LblCustomer_id As Label
    Friend WithEvents Customer_id_txt As TextBox
    Friend WithEvents Email_txt As TextBox
    Friend WithEvents Name_txt As TextBox
    Friend WithEvents Surname_txt As TextBox
End Class
