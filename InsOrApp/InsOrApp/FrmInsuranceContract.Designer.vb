<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FrmInsuranceContract
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmInsuranceContract))
        Me.GroupBoxSymbolaio = New System.Windows.Forms.GroupBox()
        Me.DateTimePickerTo = New System.Windows.Forms.DateTimePicker()
        Me.DateTimePickerFrom = New System.Windows.Forms.DateTimePicker()
        Me.CheckBoxKrystalla = New System.Windows.Forms.CheckBox()
        Me.CheckBoxFire = New System.Windows.Forms.CheckBox()
        Me.CheckBoxNomikh = New System.Windows.Forms.CheckBox()
        Me.CheckBoxOdBoh = New System.Windows.Forms.CheckBox()
        Me.CheckBoxTheft = New System.Windows.Forms.CheckBox()
        Me.Brand_txt = New System.Windows.Forms.TextBox()
        Me.Symvolaio_id_txt = New System.Windows.Forms.TextBox()
        Me.LicencePlate_txt = New System.Windows.Forms.TextBox()
        Me.LblSymvolaio_id = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBoxCustomer = New System.Windows.Forms.GroupBox()
        Me.Customer_Id_txt = New System.Windows.Forms.TextBox()
        Me.Email_txt = New System.Windows.Forms.TextBox()
        Me.Name_txt = New System.Windows.Forms.TextBox()
        Me.Surname_txt = New System.Windows.Forms.TextBox()
        Me.LblCustomer_id = New System.Windows.Forms.Label()
        Me.LblEmail = New System.Windows.Forms.Label()
        Me.LblName = New System.Windows.Forms.Label()
        Me.LblSurname = New System.Windows.Forms.Label()
        Me.GroupBoxView = New System.Windows.Forms.GroupBox()
        Me.BtnFinal = New System.Windows.Forms.Button()
        Me.BtnEdit2 = New System.Windows.Forms.Button()
        Me.GroupBoxEdit2 = New System.Windows.Forms.GroupBox()
        Me.BtnStep2 = New System.Windows.Forms.Button()
        Me.BtnEdit = New System.Windows.Forms.Button()
        Me.GroupBoxEdit = New System.Windows.Forms.GroupBox()
        Me.BtnStep1 = New System.Windows.Forms.Button()
        Me.BtnExit = New System.Windows.Forms.Button()
        Me.GroupBoxFinal = New System.Windows.Forms.GroupBox()
        Me.BtnPrint = New System.Windows.Forms.Button()
        Me.ButtonFinalExit = New System.Windows.Forms.Button()
        Me.GroupBoxSymbolaio.SuspendLayout()
        Me.GroupBoxCustomer.SuspendLayout()
        Me.GroupBoxView.SuspendLayout()
        Me.GroupBoxEdit2.SuspendLayout()
        Me.GroupBoxEdit.SuspendLayout()
        Me.GroupBoxFinal.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBoxSymbolaio
        '
        Me.GroupBoxSymbolaio.Controls.Add(Me.DateTimePickerTo)
        Me.GroupBoxSymbolaio.Controls.Add(Me.DateTimePickerFrom)
        Me.GroupBoxSymbolaio.Controls.Add(Me.CheckBoxKrystalla)
        Me.GroupBoxSymbolaio.Controls.Add(Me.CheckBoxFire)
        Me.GroupBoxSymbolaio.Controls.Add(Me.CheckBoxNomikh)
        Me.GroupBoxSymbolaio.Controls.Add(Me.CheckBoxOdBoh)
        Me.GroupBoxSymbolaio.Controls.Add(Me.CheckBoxTheft)
        Me.GroupBoxSymbolaio.Controls.Add(Me.Brand_txt)
        Me.GroupBoxSymbolaio.Controls.Add(Me.Symvolaio_id_txt)
        Me.GroupBoxSymbolaio.Controls.Add(Me.LicencePlate_txt)
        Me.GroupBoxSymbolaio.Controls.Add(Me.LblSymvolaio_id)
        Me.GroupBoxSymbolaio.Controls.Add(Me.Label4)
        Me.GroupBoxSymbolaio.Controls.Add(Me.Label3)
        Me.GroupBoxSymbolaio.Controls.Add(Me.Label2)
        Me.GroupBoxSymbolaio.Controls.Add(Me.Label1)
        Me.GroupBoxSymbolaio.Location = New System.Drawing.Point(12, 173)
        Me.GroupBoxSymbolaio.Name = "GroupBoxSymbolaio"
        Me.GroupBoxSymbolaio.Size = New System.Drawing.Size(626, 271)
        Me.GroupBoxSymbolaio.TabIndex = 11
        Me.GroupBoxSymbolaio.TabStop = False
        Me.GroupBoxSymbolaio.Text = "Στοιχεία Συμβολαίου"
        '
        'DateTimePickerTo
        '
        Me.DateTimePickerTo.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.DateTimePickerTo.Location = New System.Drawing.Point(224, 197)
        Me.DateTimePickerTo.Name = "DateTimePickerTo"
        Me.DateTimePickerTo.Size = New System.Drawing.Size(375, 24)
        Me.DateTimePickerTo.TabIndex = 12
        '
        'DateTimePickerFrom
        '
        Me.DateTimePickerFrom.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.DateTimePickerFrom.Location = New System.Drawing.Point(224, 167)
        Me.DateTimePickerFrom.Name = "DateTimePickerFrom"
        Me.DateTimePickerFrom.Size = New System.Drawing.Size(375, 24)
        Me.DateTimePickerFrom.TabIndex = 11
        '
        'CheckBoxKrystalla
        '
        Me.CheckBoxKrystalla.AutoSize = True
        Me.CheckBoxKrystalla.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.CheckBoxKrystalla.Location = New System.Drawing.Point(391, 103)
        Me.CheckBoxKrystalla.Name = "CheckBoxKrystalla"
        Me.CheckBoxKrystalla.Size = New System.Drawing.Size(170, 22)
        Me.CheckBoxKrystalla.TabIndex = 8
        Me.CheckBoxKrystalla.Text = "Θραύση Κρυστάλλων"
        Me.CheckBoxKrystalla.UseVisualStyleBackColor = True
        '
        'CheckBoxFire
        '
        Me.CheckBoxFire.AutoSize = True
        Me.CheckBoxFire.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.CheckBoxFire.Location = New System.Drawing.Point(300, 103)
        Me.CheckBoxFire.Name = "CheckBoxFire"
        Me.CheckBoxFire.Size = New System.Drawing.Size(85, 22)
        Me.CheckBoxFire.TabIndex = 7
        Me.CheckBoxFire.Text = "Πυρκαϊά"
        Me.CheckBoxFire.UseVisualStyleBackColor = True
        '
        'CheckBoxNomikh
        '
        Me.CheckBoxNomikh.AutoSize = True
        Me.CheckBoxNomikh.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.CheckBoxNomikh.Location = New System.Drawing.Point(391, 131)
        Me.CheckBoxNomikh.Name = "CheckBoxNomikh"
        Me.CheckBoxNomikh.Size = New System.Drawing.Size(155, 22)
        Me.CheckBoxNomikh.TabIndex = 10
        Me.CheckBoxNomikh.Text = "Νομική Προστασία"
        Me.CheckBoxNomikh.UseVisualStyleBackColor = True
        '
        'CheckBoxOdBoh
        '
        Me.CheckBoxOdBoh.AutoSize = True
        Me.CheckBoxOdBoh.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.CheckBoxOdBoh.Location = New System.Drawing.Point(224, 131)
        Me.CheckBoxOdBoh.Name = "CheckBoxOdBoh"
        Me.CheckBoxOdBoh.Size = New System.Drawing.Size(128, 22)
        Me.CheckBoxOdBoh.TabIndex = 9
        Me.CheckBoxOdBoh.Text = "Οδική Βοήθεια"
        Me.CheckBoxOdBoh.UseVisualStyleBackColor = True
        '
        'CheckBoxTheft
        '
        Me.CheckBoxTheft.AutoSize = True
        Me.CheckBoxTheft.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.CheckBoxTheft.Location = New System.Drawing.Point(224, 103)
        Me.CheckBoxTheft.Name = "CheckBoxTheft"
        Me.CheckBoxTheft.Size = New System.Drawing.Size(70, 22)
        Me.CheckBoxTheft.TabIndex = 6
        Me.CheckBoxTheft.Text = "Κλοπή"
        Me.CheckBoxTheft.UseVisualStyleBackColor = True
        '
        'Brand_txt
        '
        Me.Brand_txt.BackColor = System.Drawing.Color.White
        Me.Brand_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Brand_txt.Location = New System.Drawing.Point(224, 67)
        Me.Brand_txt.MaxLength = 50
        Me.Brand_txt.Name = "Brand_txt"
        Me.Brand_txt.Size = New System.Drawing.Size(376, 24)
        Me.Brand_txt.TabIndex = 5
        Me.Brand_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'Symvolaio_id_txt
        '
        Me.Symvolaio_id_txt.BackColor = System.Drawing.Color.White
        Me.Symvolaio_id_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Symvolaio_id_txt.Location = New System.Drawing.Point(223, 234)
        Me.Symvolaio_id_txt.MaxLength = 50
        Me.Symvolaio_id_txt.Name = "Symvolaio_id_txt"
        Me.Symvolaio_id_txt.Size = New System.Drawing.Size(376, 24)
        Me.Symvolaio_id_txt.TabIndex = 13
        Me.Symvolaio_id_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LicencePlate_txt
        '
        Me.LicencePlate_txt.BackColor = System.Drawing.Color.White
        Me.LicencePlate_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.LicencePlate_txt.Location = New System.Drawing.Point(224, 30)
        Me.LicencePlate_txt.MaxLength = 10
        Me.LicencePlate_txt.Name = "LicencePlate_txt"
        Me.LicencePlate_txt.Size = New System.Drawing.Size(376, 24)
        Me.LicencePlate_txt.TabIndex = 4
        Me.LicencePlate_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'LblSymvolaio_id
        '
        Me.LblSymvolaio_id.AutoSize = True
        Me.LblSymvolaio_id.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.LblSymvolaio_id.Location = New System.Drawing.Point(38, 237)
        Me.LblSymvolaio_id.Name = "LblSymvolaio_id"
        Me.LblSymvolaio_id.Size = New System.Drawing.Size(153, 18)
        Me.LblSymvolaio_id.TabIndex = 0
        Me.LblSymvolaio_id.Text = "Κωδικός Συμβολαίου:"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label4.Location = New System.Drawing.Point(38, 202)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(126, 18)
        Me.Label4.TabIndex = 0
        Me.Label4.Text = "Έως Ημερομηνία:"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label3.Location = New System.Drawing.Point(38, 169)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(123, 18)
        Me.Label3.TabIndex = 0
        Me.Label3.Text = "Από Ημερομηνία:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label2.Location = New System.Drawing.Point(38, 70)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(172, 18)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Μάρκα Νέου Οχήματος:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label1.Location = New System.Drawing.Point(38, 33)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(180, 18)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Αρ Κυκλ Νέου Οχήματος:"
        '
        'GroupBoxCustomer
        '
        Me.GroupBoxCustomer.Controls.Add(Me.Customer_Id_txt)
        Me.GroupBoxCustomer.Controls.Add(Me.Email_txt)
        Me.GroupBoxCustomer.Controls.Add(Me.Name_txt)
        Me.GroupBoxCustomer.Controls.Add(Me.Surname_txt)
        Me.GroupBoxCustomer.Controls.Add(Me.LblCustomer_id)
        Me.GroupBoxCustomer.Controls.Add(Me.LblEmail)
        Me.GroupBoxCustomer.Controls.Add(Me.LblName)
        Me.GroupBoxCustomer.Controls.Add(Me.LblSurname)
        Me.GroupBoxCustomer.Location = New System.Drawing.Point(12, 12)
        Me.GroupBoxCustomer.Name = "GroupBoxCustomer"
        Me.GroupBoxCustomer.Size = New System.Drawing.Size(626, 155)
        Me.GroupBoxCustomer.TabIndex = 10
        Me.GroupBoxCustomer.TabStop = False
        Me.GroupBoxCustomer.Text = "Στοιχεία Πελάτη"
        '
        'Customer_Id_txt
        '
        Me.Customer_Id_txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Customer_Id_txt.Location = New System.Drawing.Point(169, 30)
        Me.Customer_Id_txt.MaxLength = 50
        Me.Customer_Id_txt.Name = "Customer_Id_txt"
        Me.Customer_Id_txt.Size = New System.Drawing.Size(430, 24)
        Me.Customer_Id_txt.TabIndex = 0
        Me.Customer_Id_txt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
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
        'GroupBoxView
        '
        Me.GroupBoxView.Controls.Add(Me.BtnFinal)
        Me.GroupBoxView.Controls.Add(Me.BtnEdit2)
        Me.GroupBoxView.Location = New System.Drawing.Point(12, 562)
        Me.GroupBoxView.Name = "GroupBoxView"
        Me.GroupBoxView.Size = New System.Drawing.Size(626, 50)
        Me.GroupBoxView.TabIndex = 7
        Me.GroupBoxView.TabStop = False
        '
        'BtnFinal
        '
        Me.BtnFinal.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BtnFinal.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.BtnFinal.Location = New System.Drawing.Point(338, 13)
        Me.BtnFinal.Name = "BtnFinal"
        Me.BtnFinal.Size = New System.Drawing.Size(262, 31)
        Me.BtnFinal.TabIndex = 12
        Me.BtnFinal.Text = "Οριστικοποίηση Συμβολαίου"
        Me.BtnFinal.UseVisualStyleBackColor = False
        '
        'BtnEdit2
        '
        Me.BtnEdit2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BtnEdit2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.BtnEdit2.Location = New System.Drawing.Point(6, 13)
        Me.BtnEdit2.Name = "BtnEdit2"
        Me.BtnEdit2.Size = New System.Drawing.Size(326, 31)
        Me.BtnEdit2.TabIndex = 11
        Me.BtnEdit2.Text = "Διόρθωση Στοιχείων Συμβολαίου"
        Me.BtnEdit2.UseVisualStyleBackColor = False
        '
        'GroupBoxEdit2
        '
        Me.GroupBoxEdit2.Controls.Add(Me.BtnStep2)
        Me.GroupBoxEdit2.Controls.Add(Me.BtnEdit)
        Me.GroupBoxEdit2.Location = New System.Drawing.Point(12, 506)
        Me.GroupBoxEdit2.Name = "GroupBoxEdit2"
        Me.GroupBoxEdit2.Size = New System.Drawing.Size(626, 50)
        Me.GroupBoxEdit2.TabIndex = 8
        Me.GroupBoxEdit2.TabStop = False
        '
        'BtnStep2
        '
        Me.BtnStep2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BtnStep2.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.BtnStep2.Location = New System.Drawing.Point(338, 13)
        Me.BtnStep2.Name = "BtnStep2"
        Me.BtnStep2.Size = New System.Drawing.Size(262, 31)
        Me.BtnStep2.TabIndex = 10
        Me.BtnStep2.Text = "Καταχώρηση Νέου Οχήματος"
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
        Me.BtnEdit.Text = "Διόρθωση Κωδικού Πελάτη"
        Me.BtnEdit.UseVisualStyleBackColor = False
        '
        'GroupBoxEdit
        '
        Me.GroupBoxEdit.Controls.Add(Me.BtnStep1)
        Me.GroupBoxEdit.Controls.Add(Me.BtnExit)
        Me.GroupBoxEdit.Location = New System.Drawing.Point(12, 450)
        Me.GroupBoxEdit.Name = "GroupBoxEdit"
        Me.GroupBoxEdit.Size = New System.Drawing.Size(626, 50)
        Me.GroupBoxEdit.TabIndex = 9
        Me.GroupBoxEdit.TabStop = False
        '
        'BtnStep1
        '
        Me.BtnStep1.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BtnStep1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.BtnStep1.Location = New System.Drawing.Point(338, 13)
        Me.BtnStep1.Name = "BtnStep1"
        Me.BtnStep1.Size = New System.Drawing.Size(262, 31)
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
        'GroupBoxFinal
        '
        Me.GroupBoxFinal.Controls.Add(Me.BtnPrint)
        Me.GroupBoxFinal.Controls.Add(Me.ButtonFinalExit)
        Me.GroupBoxFinal.Location = New System.Drawing.Point(12, 618)
        Me.GroupBoxFinal.Name = "GroupBoxFinal"
        Me.GroupBoxFinal.Size = New System.Drawing.Size(626, 50)
        Me.GroupBoxFinal.TabIndex = 7
        Me.GroupBoxFinal.TabStop = False
        '
        'BtnPrint
        '
        Me.BtnPrint.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.BtnPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.BtnPrint.Location = New System.Drawing.Point(338, 13)
        Me.BtnPrint.Name = "BtnPrint"
        Me.BtnPrint.Size = New System.Drawing.Size(262, 31)
        Me.BtnPrint.TabIndex = 12
        Me.BtnPrint.Text = "Εκτύπωση Στοιχείων Συμβολαίου"
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
        'FrmInsuranceContract
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(729, 504)
        Me.Controls.Add(Me.GroupBoxSymbolaio)
        Me.Controls.Add(Me.GroupBoxCustomer)
        Me.Controls.Add(Me.GroupBoxFinal)
        Me.Controls.Add(Me.GroupBoxView)
        Me.Controls.Add(Me.GroupBoxEdit2)
        Me.Controls.Add(Me.GroupBoxEdit)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "FrmInsuranceContract"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Νέο Ασφαλιστικό Συμβόλαιο"
        Me.GroupBoxSymbolaio.ResumeLayout(False)
        Me.GroupBoxSymbolaio.PerformLayout()
        Me.GroupBoxCustomer.ResumeLayout(False)
        Me.GroupBoxCustomer.PerformLayout()
        Me.GroupBoxView.ResumeLayout(False)
        Me.GroupBoxEdit2.ResumeLayout(False)
        Me.GroupBoxEdit.ResumeLayout(False)
        Me.GroupBoxFinal.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents GroupBoxSymbolaio As GroupBox
    Friend WithEvents GroupBoxCustomer As GroupBox
    Friend WithEvents Email_txt As TextBox
    Friend WithEvents Name_txt As TextBox
    Friend WithEvents Surname_txt As TextBox
    Friend WithEvents LblCustomer_id As Label
    Friend WithEvents LblEmail As Label
    Friend WithEvents LblName As Label
    Friend WithEvents LblSurname As Label
    Friend WithEvents GroupBoxView As GroupBox
    Friend WithEvents BtnFinal As Button
    Friend WithEvents BtnEdit2 As Button
    Friend WithEvents GroupBoxEdit2 As GroupBox
    Friend WithEvents BtnStep2 As Button
    Friend WithEvents BtnEdit As Button
    Friend WithEvents GroupBoxEdit As GroupBox
    Friend WithEvents BtnStep1 As Button
    Friend WithEvents BtnExit As Button
    Friend WithEvents CheckBoxTheft As CheckBox
    Friend WithEvents Brand_txt As TextBox
    Friend WithEvents LicencePlate_txt As TextBox
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents CheckBoxKrystalla As CheckBox
    Friend WithEvents CheckBoxFire As CheckBox
    Friend WithEvents CheckBoxNomikh As CheckBox
    Friend WithEvents CheckBoxOdBoh As CheckBox
    Friend WithEvents Label3 As Label
    Friend WithEvents DateTimePickerTo As DateTimePicker
    Friend WithEvents DateTimePickerFrom As DateTimePicker
    Friend WithEvents Label4 As Label
    Friend WithEvents GroupBoxFinal As GroupBox
    Friend WithEvents BtnPrint As Button
    Friend WithEvents ButtonFinalExit As Button
    Friend WithEvents Symvolaio_id_txt As TextBox
    Friend WithEvents LblSymvolaio_id As Label
    Friend WithEvents Customer_Id_txt As TextBox
End Class
