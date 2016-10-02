<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmInsuranceCustomer_KLEIDAR
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmInsuranceCustomer_KLEIDAR))
        Me.GroupBoxFinal = New System.Windows.Forms.GroupBox()
        Me.BtnPrint = New System.Windows.Forms.Button()
        Me.ButtonFinalExit = New System.Windows.Forms.Button()
        Me.GroupBoxView = New System.Windows.Forms.GroupBox()
        Me.BtnStep2 = New System.Windows.Forms.Button()
        Me.BtnEdit = New System.Windows.Forms.Button()
        Me.GroupBoxEdit = New System.Windows.Forms.GroupBox()
        Me.BtnStep1 = New System.Windows.Forms.Button()
        Me.BtnExit = New System.Windows.Forms.Button()
        Me.GroupBoxCustomer = New System.Windows.Forms.GroupBox()
        Me.LblCaution = New System.Windows.Forms.Label()
        Me.Customer_id_txt = New System.Windows.Forms.TextBox()
        Me.Email_txt = New System.Windows.Forms.TextBox()
        Me.Name_txt = New System.Windows.Forms.TextBox()
        Me.Surname_txt = New System.Windows.Forms.TextBox()
        Me.LblCustomer_id = New System.Windows.Forms.Label()
        Me.LblEmail = New System.Windows.Forms.Label()
        Me.LblName = New System.Windows.Forms.Label()
        Me.LblSurname = New System.Windows.Forms.Label()
        Me.GroupBoxKLEIDAR = New System.Windows.Forms.GroupBox()
        Me.KLEIDAR_Time_txt = New System.Windows.Forms.TextBox()
        Me.KLEIDAR_Date_txt = New System.Windows.Forms.TextBox()
        Me.KLEIDAR_txt = New System.Windows.Forms.TextBox()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.GroupBoxFinal.SuspendLayout()
        Me.GroupBoxView.SuspendLayout()
        Me.GroupBoxEdit.SuspendLayout()
        Me.GroupBoxCustomer.SuspendLayout()
        Me.GroupBoxKLEIDAR.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBoxFinal
        '
        Me.GroupBoxFinal.Controls.Add(Me.BtnPrint)
        Me.GroupBoxFinal.Controls.Add(Me.ButtonFinalExit)
        Me.GroupBoxFinal.Location = New System.Drawing.Point(12, 479)
        Me.GroupBoxFinal.Name = "GroupBoxFinal"
        Me.GroupBoxFinal.Size = New System.Drawing.Size(626, 50)
        Me.GroupBoxFinal.TabIndex = 2
        Me.GroupBoxFinal.TabStop = False
        '
        'BtnPrint
        '
        Me.BtnPrint.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BtnPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.BtnPrint.Location = New System.Drawing.Point(439, 13)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(161, 31)
        Me.BtnPrint.TabIndex = 12
        Me.BtnPrint.Text = "Εκτύπωση"
        Me.BtnPrint.UseVisualStyleBackColor = False
        '
        'ButtonFinalExit
        '
        Me.ButtonFinalExit.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.ButtonFinalExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.ButtonFinalExit.Location = New System.Drawing.Point(6, 13)
        Me.ButtonFinalExit.Name = "ButtonFinalExit"
        Me.ButtonFinalExit.Size = New System.Drawing.Size(326, 31)
        Me.ButtonFinalExit.TabIndex = 11
        Me.ButtonFinalExit.Text = "Ολοκλήρωση"
        Me.ButtonFinalExit.UseVisualStyleBackColor = False
        '
        'GroupBoxView
        '
        Me.GroupBoxView.Controls.Add(Me.BtnStep2)
        Me.GroupBoxView.Controls.Add(Me.BtnEdit)
        Me.GroupBoxView.Location = New System.Drawing.Point(12, 423)
        Me.GroupBoxView.Name = "GroupBoxView"
        Me.GroupBoxView.Size = New System.Drawing.Size(626, 50)
        Me.GroupBoxView.TabIndex = 3
        Me.GroupBoxView.TabStop = False
        '
        'BtnStep2
        '
        Me.BtnStep2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BtnStep2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.BtnStep2.Location = New System.Drawing.Point(439, 13)
        Me.BtnStep2.Name = "BtnStep2"
        Me.BtnStep2.Size = New System.Drawing.Size(161, 31)
        Me.BtnStep2.TabIndex = 10
        Me.BtnStep2.Text = "Νέος Κλειδάριθμος"
        Me.BtnStep2.UseVisualStyleBackColor = False
        '
        'BtnEdit
        '
        Me.BtnEdit.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BtnEdit.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.BtnEdit.Location = New System.Drawing.Point(6, 13)
        Me.BtnEdit.Name = "BtnEdit"
        Me.BtnEdit.Size = New System.Drawing.Size(326, 31)
        Me.BtnEdit.TabIndex = 9
        Me.BtnEdit.Text = "Ακύρωση && Επιστροφή στο μενού Ασφαλιστή"
        Me.BtnEdit.UseVisualStyleBackColor = False
        '
        'GroupBoxEdit
        '
        Me.GroupBoxEdit.Controls.Add(Me.BtnStep1)
        Me.GroupBoxEdit.Controls.Add(Me.BtnExit)
        Me.GroupBoxEdit.Location = New System.Drawing.Point(12, 358)
        Me.GroupBoxEdit.Name = "GroupBoxEdit"
        Me.GroupBoxEdit.Size = New System.Drawing.Size(626, 50)
        Me.GroupBoxEdit.TabIndex = 4
        Me.GroupBoxEdit.TabStop = False
        '
        'BtnStep1
        '
        Me.BtnStep1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BtnStep1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.BtnStep1.Location = New System.Drawing.Point(439, 13)
        Me.BtnStep1.Name = "BtnStep1"
        Me.BtnStep1.Size = New System.Drawing.Size(161, 31)
        Me.BtnStep1.TabIndex = 8
        Me.BtnStep1.Text = "Εύρεση Πελάτη"
        Me.BtnStep1.UseVisualStyleBackColor = False
        '
        'BtnExit
        '
        Me.BtnExit.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BtnExit.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.BtnExit.Location = New System.Drawing.Point(6, 13)
        Me.BtnExit.Name = "BtnExit"
        Me.BtnExit.Size = New System.Drawing.Size(326, 31)
        Me.BtnExit.TabIndex = 7
        Me.BtnExit.Text = "Ακύρωση && επιστροφή στο μενού Ασφαλιστή"
        Me.BtnExit.UseVisualStyleBackColor = False
        '
        'GroupBoxCustomer
        '
        Me.GroupBoxCustomer.Controls.Add(Me.LblCaution)
        Me.GroupBoxCustomer.Controls.Add(Me.Customer_id_txt)
        Me.GroupBoxCustomer.Controls.Add(Me.Email_txt)
        Me.GroupBoxCustomer.Controls.Add(Me.Name_txt)
        Me.GroupBoxCustomer.Controls.Add(Me.Surname_txt)
        Me.GroupBoxCustomer.Controls.Add(Me.LblCustomer_id)
        Me.GroupBoxCustomer.Controls.Add(Me.LblEmail)
        Me.GroupBoxCustomer.Controls.Add(Me.LblName)
        Me.GroupBoxCustomer.Controls.Add(Me.LblSurname)
        Me.GroupBoxCustomer.Location = New System.Drawing.Point(12, 12)
        Me.GroupBoxCustomer.Name = "GroupBoxCustomer"
        Me.GroupBoxCustomer.Size = New System.Drawing.Size(626, 214)
        Me.GroupBoxCustomer.TabIndex = 5
        Me.GroupBoxCustomer.TabStop = False
        Me.GroupBoxCustomer.Text = "Στοιχεία Πελάτη"
        '
        'LblCaution
        '
        Me.LblCaution.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.LblCaution.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.LblCaution.Location = New System.Drawing.Point(133, 159)
        Me.LblCaution.Name = "LblCaution"
        Me.LblCaution.Size = New System.Drawing.Size(466, 45)
        Me.LblCaution.TabIndex = 4
        Me.LblCaution.Text = "ΠΡΟΣΟΧΗ: Ο νέος Κλειδάριθμος ακυρώνει τον παλαιό. Θα πρέπει να ξαναγίνουν ρυθμίσε" &
    "ις στην εφαρμογή INSORAMAP"
        '
        'Customer_id_txt
        '
        Me.Customer_id_txt.BackColor = System.Drawing.Color.White
        Me.Customer_id_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Customer_id_txt.Location = New System.Drawing.Point(168, 30)
        Me.Customer_id_txt.MaxLength = 50
        Me.Customer_id_txt.Name = "Customer_id_txt"
        Me.Customer_id_txt.Size = New System.Drawing.Size(431, 24)
        Me.Customer_id_txt.TabIndex = 0
        Me.Customer_id_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Email_txt
        '
        Me.Email_txt.BackColor = System.Drawing.Color.White
        Me.Email_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Email_txt.Location = New System.Drawing.Point(168, 121)
        Me.Email_txt.MaxLength = 50
        Me.Email_txt.Name = "Email_txt"
        Me.Email_txt.ReadOnly = True
        Me.Email_txt.Size = New System.Drawing.Size(431, 24)
        Me.Email_txt.TabIndex = 3
        '
        'Name_txt
        '
        Me.Name_txt.BackColor = System.Drawing.Color.White
        Me.Name_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Name_txt.Location = New System.Drawing.Point(169, 91)
        Me.Name_txt.MaxLength = 50
        Me.Name_txt.Name = "Name_txt"
        Me.Name_txt.ReadOnly = True
        Me.Name_txt.Size = New System.Drawing.Size(431, 24)
        Me.Name_txt.TabIndex = 2
        '
        'Surname_txt
        '
        Me.Surname_txt.BackColor = System.Drawing.Color.White
        Me.Surname_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Surname_txt.Location = New System.Drawing.Point(169, 61)
        Me.Surname_txt.MaxLength = 50
        Me.Surname_txt.Name = "Surname_txt"
        Me.Surname_txt.ReadOnly = True
        Me.Surname_txt.Size = New System.Drawing.Size(431, 24)
        Me.Surname_txt.TabIndex = 1
        '
        'LblCustomer_id
        '
        Me.LblCustomer_id.AutoSize = True
        Me.LblCustomer_id.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.LblCustomer_id.Location = New System.Drawing.Point(38, 33)
        Me.LblCustomer_id.Name = "LblCustomer_id"
        Me.LblCustomer_id.Size = New System.Drawing.Size(124, 18)
        Me.LblCustomer_id.TabIndex = 0
        Me.LblCustomer_id.Text = "Κωδικός Πελάτη:"
        '
        'LblEmail
        '
        Me.LblEmail.AutoSize = True
        Me.LblEmail.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.LblEmail.Location = New System.Drawing.Point(38, 124)
        Me.LblEmail.Name = "LblEmail"
        Me.LblEmail.Size = New System.Drawing.Size(49, 18)
        Me.LblEmail.TabIndex = 0
        Me.LblEmail.Text = "Email:"
        '
        'LblName
        '
        Me.LblName.AutoSize = True
        Me.LblName.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.LblName.Location = New System.Drawing.Point(38, 94)
        Me.LblName.Name = "LblName"
        Me.LblName.Size = New System.Drawing.Size(58, 18)
        Me.LblName.TabIndex = 0
        Me.LblName.Text = "Όνομα:"
        '
        'LblSurname
        '
        Me.LblSurname.AutoSize = True
        Me.LblSurname.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.LblSurname.Location = New System.Drawing.Point(38, 64)
        Me.LblSurname.Name = "LblSurname"
        Me.LblSurname.Size = New System.Drawing.Size(71, 18)
        Me.LblSurname.TabIndex = 0
        Me.LblSurname.Text = "Επώνυμο:"
        '
        'GroupBoxKLEIDAR
        '
        Me.GroupBoxKLEIDAR.Controls.Add(Me.KLEIDAR_Time_txt)
        Me.GroupBoxKLEIDAR.Controls.Add(Me.KLEIDAR_Date_txt)
        Me.GroupBoxKLEIDAR.Controls.Add(Me.KLEIDAR_txt)
        Me.GroupBoxKLEIDAR.Controls.Add(Me.Label7)
        Me.GroupBoxKLEIDAR.Controls.Add(Me.Label6)
        Me.GroupBoxKLEIDAR.Controls.Add(Me.Label5)
        Me.GroupBoxKLEIDAR.Location = New System.Drawing.Point(12, 232)
        Me.GroupBoxKLEIDAR.Name = "GroupBoxKLEIDAR"
        Me.GroupBoxKLEIDAR.Size = New System.Drawing.Size(626, 120)
        Me.GroupBoxKLEIDAR.TabIndex = 6
        Me.GroupBoxKLEIDAR.TabStop = False
        Me.GroupBoxKLEIDAR.Text = "Στοιχεία Κλειδάριθμου"
        '
        'KLEIDAR_Time_txt
        '
        Me.KLEIDAR_Time_txt.BackColor = System.Drawing.Color.White
        Me.KLEIDAR_Time_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.KLEIDAR_Time_txt.Location = New System.Drawing.Point(168, 87)
        Me.KLEIDAR_Time_txt.MaxLength = 50
        Me.KLEIDAR_Time_txt.Name = "KLEIDAR_Time_txt"
        Me.KLEIDAR_Time_txt.ReadOnly = True
        Me.KLEIDAR_Time_txt.Size = New System.Drawing.Size(431, 24)
        Me.KLEIDAR_Time_txt.TabIndex = 6
        Me.KLEIDAR_Time_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'KLEIDAR_Date_txt
        '
        Me.KLEIDAR_Date_txt.BackColor = System.Drawing.Color.White
        Me.KLEIDAR_Date_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.KLEIDAR_Date_txt.Location = New System.Drawing.Point(168, 58)
        Me.KLEIDAR_Date_txt.MaxLength = 50
        Me.KLEIDAR_Date_txt.Name = "KLEIDAR_Date_txt"
        Me.KLEIDAR_Date_txt.ReadOnly = True
        Me.KLEIDAR_Date_txt.Size = New System.Drawing.Size(431, 24)
        Me.KLEIDAR_Date_txt.TabIndex = 5
        Me.KLEIDAR_Date_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'KLEIDAR_txt
        '
        Me.KLEIDAR_txt.BackColor = System.Drawing.Color.White
        Me.KLEIDAR_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.KLEIDAR_txt.Location = New System.Drawing.Point(168, 28)
        Me.KLEIDAR_txt.MaxLength = 50
        Me.KLEIDAR_txt.Name = "KLEIDAR_txt"
        Me.KLEIDAR_txt.ReadOnly = True
        Me.KLEIDAR_txt.Size = New System.Drawing.Size(431, 24)
        Me.KLEIDAR_txt.TabIndex = 4
        Me.KLEIDAR_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label7.Location = New System.Drawing.Point(6, 90)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(43, 18)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Ώρα:"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label6.Location = New System.Drawing.Point(6, 61)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(93, 18)
        Me.Label6.TabIndex = 1
        Me.Label6.Text = "Ημερομηνία:"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label5.Location = New System.Drawing.Point(6, 31)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(146, 18)
        Me.Label5.TabIndex = 1
        Me.Label5.Text = "Νέος Κλειδάριθμος:"
        '
        'FrmInsuranceCustomer_KLEIDAR
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(650, 414)
        Me.Controls.Add(Me.GroupBoxKLEIDAR)
        Me.Controls.Add(Me.GroupBoxCustomer)
        Me.Controls.Add(Me.GroupBoxFinal)
        Me.Controls.Add(Me.GroupBoxView)
        Me.Controls.Add(Me.GroupBoxEdit)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "FrmInsuranceCustomer_KLEIDAR"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Έκδοση Κλειδάριθμου"
        Me.GroupBoxFinal.ResumeLayout(False)
        Me.GroupBoxView.ResumeLayout(False)
        Me.GroupBoxEdit.ResumeLayout(False)
        Me.GroupBoxCustomer.ResumeLayout(False)
        Me.GroupBoxCustomer.PerformLayout()
        Me.GroupBoxKLEIDAR.ResumeLayout(False)
        Me.GroupBoxKLEIDAR.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBoxFinal As GroupBox
    Friend WithEvents BtnPrint As Button
    Friend WithEvents ButtonFinalExit As Button
    Friend WithEvents GroupBoxView As GroupBox
    Friend WithEvents BtnStep2 As Button
    Friend WithEvents BtnEdit As Button
    Friend WithEvents GroupBoxEdit As GroupBox
    Friend WithEvents BtnStep1 As Button
    Friend WithEvents BtnExit As Button
    Friend WithEvents GroupBoxCustomer As GroupBox
    Friend WithEvents Customer_id_txt As TextBox
    Friend WithEvents Name_txt As TextBox
    Friend WithEvents Surname_txt As TextBox
    Friend WithEvents LblCustomer_id As Label
    Friend WithEvents LblName As Label
    Friend WithEvents LblSurname As Label
    Friend WithEvents Email_txt As TextBox
    Friend WithEvents LblEmail As Label
    Friend WithEvents LblCaution As Label
    Friend WithEvents GroupBoxKLEIDAR As GroupBox
    Friend WithEvents KLEIDAR_Time_txt As TextBox
    Friend WithEvents KLEIDAR_Date_txt As TextBox
    Friend WithEvents KLEIDAR_txt As TextBox
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
End Class
