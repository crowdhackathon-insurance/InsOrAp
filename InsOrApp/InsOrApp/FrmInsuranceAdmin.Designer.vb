<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class FrmInsuranceAdmin
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FrmInsuranceAdmin))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.ToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemCustomers = New System.Windows.Forms.ToolStripMenuItem()
        Me.ΠελάτηςToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemContracts = New System.Windows.Forms.ToolStripMenuItem()
        Me.ToolStripMenuItemPragmatognomonas = New System.Windows.Forms.ToolStripMenuItem()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.WebMap = New System.Windows.Forms.WebBrowser()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.MainGrid = New System.Windows.Forms.DataGridView()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.LblCountInProgress = New System.Windows.Forms.Label()
        Me.LblTotalCount = New System.Windows.Forms.Label()
        Me.LblCountFinished = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.LblYpaitios = New System.Windows.Forms.Label()
        Me.lblOdBoh = New System.Windows.Forms.Label()
        Me.Lbl100 = New System.Windows.Forms.Label()
        Me.Lbl166 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.DateTimeCurrent = New System.Windows.Forms.DateTimePicker()
        Me.MenuStrip1.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel3.SuspendLayout()
        CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel2.SuspendLayout()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.BackColor = System.Drawing.Color.FromArgb(CType(CType(82, Byte), Integer), CType(CType(186, Byte), Integer), CType(CType(147, Byte), Integer))
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripMenuItem, Me.ToolStripMenuItemCustomers, Me.ToolStripMenuItemContracts, Me.ToolStripMenuItemPragmatognomonas})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(1033, 143)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'ToolStripMenuItem
        '
        Me.ToolStripMenuItem.Image = CType(resources.GetObject("ToolStripMenuItem.Image"), System.Drawing.Image)
        Me.ToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None
        Me.ToolStripMenuItem.Name = "ToolStripMenuItem"
        Me.ToolStripMenuItem.Size = New System.Drawing.Size(162, 139)
        '
        'ToolStripMenuItemCustomers
        '
        Me.ToolStripMenuItemCustomers.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ΠελάτηςToolStripMenuItem})
        Me.ToolStripMenuItemCustomers.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.ToolStripMenuItemCustomers.ForeColor = System.Drawing.Color.Black
        Me.ToolStripMenuItemCustomers.Name = "ToolStripMenuItemCustomers"
        Me.ToolStripMenuItemCustomers.Size = New System.Drawing.Size(80, 139)
        Me.ToolStripMenuItemCustomers.Text = "Πελάτες"
        Me.ToolStripMenuItemCustomers.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'ΠελάτηςToolStripMenuItem
        '
        Me.ΠελάτηςToolStripMenuItem.Name = "ΠελάτηςToolStripMenuItem"
        Me.ΠελάτηςToolStripMenuItem.Size = New System.Drawing.Size(140, 26)
        Me.ΠελάτηςToolStripMenuItem.Text = "Πελάτης"
        '
        'ToolStripMenuItemContracts
        '
        Me.ToolStripMenuItemContracts.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.ToolStripMenuItemContracts.ForeColor = System.Drawing.Color.Black
        Me.ToolStripMenuItemContracts.Name = "ToolStripMenuItemContracts"
        Me.ToolStripMenuItemContracts.Size = New System.Drawing.Size(98, 139)
        Me.ToolStripMenuItemContracts.Text = "Συμβόλαια"
        Me.ToolStripMenuItemContracts.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'ToolStripMenuItemPragmatognomonas
        '
        Me.ToolStripMenuItemPragmatognomonas.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.ToolStripMenuItemPragmatognomonas.ForeColor = System.Drawing.Color.Black
        Me.ToolStripMenuItemPragmatognomonas.Name = "ToolStripMenuItemPragmatognomonas"
        Me.ToolStripMenuItemPragmatognomonas.Size = New System.Drawing.Size(168, 139)
        Me.ToolStripMenuItemPragmatognomonas.Text = "Πραγματογνώμονας"
        Me.ToolStripMenuItemPragmatognomonas.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.FromArgb(CType(CType(52, Byte), Integer), CType(CType(52, Byte), Integer), CType(CType(52, Byte), Integer))
        Me.Panel1.Controls.Add(Me.WebMap)
        Me.Panel1.Controls.Add(Me.Panel3)
        Me.Panel1.Controls.Add(Me.Panel2)
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel1.Location = New System.Drawing.Point(0, 143)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(1033, 590)
        Me.Panel1.TabIndex = 1
        '
        'WebMap
        '
        Me.WebMap.Dock = System.Windows.Forms.DockStyle.Fill
        Me.WebMap.Location = New System.Drawing.Point(257, 0)
        Me.WebMap.MinimumSize = New System.Drawing.Size(20, 20)
        Me.WebMap.Name = "WebMap"
        Me.WebMap.Size = New System.Drawing.Size(519, 590)
        Me.WebMap.TabIndex = 1
        '
        'Panel3
        '
        Me.Panel3.BackColor = System.Drawing.Color.FromArgb(CType(CType(21, Byte), Integer), CType(CType(21, Byte), Integer), CType(CType(21, Byte), Integer))
        Me.Panel3.Controls.Add(Me.MainGrid)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel3.Location = New System.Drawing.Point(776, 0)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(257, 590)
        Me.Panel3.TabIndex = 0
        '
        'MainGrid
        '
        Me.MainGrid.AllowUserToAddRows = False
        Me.MainGrid.AllowUserToDeleteRows = False
        Me.MainGrid.BackgroundColor = System.Drawing.Color.FromArgb(CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer), CType(CType(224, Byte), Integer))
        Me.MainGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.MainGrid.Dock = System.Windows.Forms.DockStyle.Right
        Me.MainGrid.Location = New System.Drawing.Point(0, 0)
        Me.MainGrid.MultiSelect = False
        Me.MainGrid.Name = "MainGrid"
        Me.MainGrid.ReadOnly = True
        Me.MainGrid.RowTemplate.DefaultCellStyle.NullValue = Nothing
        Me.MainGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.MainGrid.Size = New System.Drawing.Size(257, 590)
        Me.MainGrid.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.BackColor = System.Drawing.Color.White
        Me.Panel2.Controls.Add(Me.Label7)
        Me.Panel2.Controls.Add(Me.Label6)
        Me.Panel2.Controls.Add(Me.LblCountInProgress)
        Me.Panel2.Controls.Add(Me.LblTotalCount)
        Me.Panel2.Controls.Add(Me.LblCountFinished)
        Me.Panel2.Controls.Add(Me.Label13)
        Me.Panel2.Controls.Add(Me.Label5)
        Me.Panel2.Controls.Add(Me.Label12)
        Me.Panel2.Controls.Add(Me.Label11)
        Me.Panel2.Controls.Add(Me.Label10)
        Me.Panel2.Controls.Add(Me.LblYpaitios)
        Me.Panel2.Controls.Add(Me.lblOdBoh)
        Me.Panel2.Controls.Add(Me.Lbl100)
        Me.Panel2.Controls.Add(Me.Lbl166)
        Me.Panel2.Controls.Add(Me.Label9)
        Me.Panel2.Controls.Add(Me.Label3)
        Me.Panel2.Controls.Add(Me.Label8)
        Me.Panel2.Controls.Add(Me.Label4)
        Me.Panel2.Controls.Add(Me.Label2)
        Me.Panel2.Controls.Add(Me.Label1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(257, 590)
        Me.Panel2.TabIndex = 0
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label7.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(111, Byte), Integer), CType(CType(157, Byte), Integer))
        Me.Label7.Location = New System.Drawing.Point(45, 310)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(121, 16)
        Me.Label7.TabIndex = 2
        Me.Label7.Text = "Χρήσιμα Τηλέφωνα"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label6.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(111, Byte), Integer), CType(CType(157, Byte), Integer))
        Me.Label6.Location = New System.Drawing.Point(42, 273)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(124, 16)
        Me.Label6.TabIndex = 2
        Me.Label6.Text = "Tickets Σε Εξέλιξη"
        '
        'LblCountInProgress
        '
        Me.LblCountInProgress.AutoSize = True
        Me.LblCountInProgress.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.LblCountInProgress.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(111, Byte), Integer), CType(CType(157, Byte), Integer))
        Me.LblCountInProgress.Location = New System.Drawing.Point(207, 273)
        Me.LblCountInProgress.Name = "LblCountInProgress"
        Me.LblCountInProgress.Size = New System.Drawing.Size(16, 16)
        Me.LblCountInProgress.TabIndex = 2
        Me.LblCountInProgress.Text = "0"
        Me.LblCountInProgress.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblTotalCount
        '
        Me.LblTotalCount.AutoSize = True
        Me.LblTotalCount.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.LblTotalCount.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(111, Byte), Integer), CType(CType(157, Byte), Integer))
        Me.LblTotalCount.Location = New System.Drawing.Point(207, 207)
        Me.LblTotalCount.Name = "LblTotalCount"
        Me.LblTotalCount.Size = New System.Drawing.Size(16, 16)
        Me.LblTotalCount.TabIndex = 2
        Me.LblTotalCount.Text = "0"
        Me.LblTotalCount.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'LblCountFinished
        '
        Me.LblCountFinished.AutoSize = True
        Me.LblCountFinished.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.LblCountFinished.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(111, Byte), Integer), CType(CType(157, Byte), Integer))
        Me.LblCountFinished.Location = New System.Drawing.Point(207, 236)
        Me.LblCountFinished.Name = "LblCountFinished"
        Me.LblCountFinished.Size = New System.Drawing.Size(16, 16)
        Me.LblCountFinished.TabIndex = 2
        Me.LblCountFinished.Text = "0"
        Me.LblCountFinished.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(111, Byte), Integer), CType(CType(157, Byte), Integer))
        Me.Label13.Location = New System.Drawing.Point(42, 207)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(142, 16)
        Me.Label13.TabIndex = 2
        Me.Label13.Text = "Συνολικός Αρ. Tickets"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label5.ForeColor = System.Drawing.Color.FromArgb(CType(CType(68, Byte), Integer), CType(CType(111, Byte), Integer), CType(CType(157, Byte), Integer))
        Me.Label5.Location = New System.Drawing.Point(42, 236)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(147, 16)
        Me.Label5.TabIndex = 2
        Me.Label5.Text = "Tickets Ολοκληρωμένα"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label12.ForeColor = System.Drawing.Color.Black
        Me.Label12.Location = New System.Drawing.Point(42, 486)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(66, 16)
        Me.Label12.TabIndex = 2
        Me.Label12.Text = "Υπαίτιος :"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.Black
        Me.Label11.Location = New System.Drawing.Point(43, 452)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(113, 16)
        Me.Label11.TabIndex = 2
        Me.Label11.Text = "Ανάγκη Γερανού :"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label10.ForeColor = System.Drawing.Color.Black
        Me.Label10.Location = New System.Drawing.Point(42, 418)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(79, 16)
        Me.Label10.TabIndex = 2
        Me.Label10.Text = "Αίτηση 100 :"
        '
        'LblYpaitios
        '
        Me.LblYpaitios.AutoSize = True
        Me.LblYpaitios.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.LblYpaitios.ForeColor = System.Drawing.Color.Black
        Me.LblYpaitios.Location = New System.Drawing.Point(194, 486)
        Me.LblYpaitios.Name = "LblYpaitios"
        Me.LblYpaitios.Size = New System.Drawing.Size(29, 16)
        Me.LblYpaitios.TabIndex = 2
        Me.LblYpaitios.Text = "ΟΧΙ"
        Me.LblYpaitios.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'lblOdBoh
        '
        Me.lblOdBoh.AutoSize = True
        Me.lblOdBoh.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.lblOdBoh.ForeColor = System.Drawing.Color.Black
        Me.lblOdBoh.Location = New System.Drawing.Point(194, 452)
        Me.lblOdBoh.Name = "lblOdBoh"
        Me.lblOdBoh.Size = New System.Drawing.Size(29, 16)
        Me.lblOdBoh.TabIndex = 2
        Me.lblOdBoh.Text = "ΟΧΙ"
        Me.lblOdBoh.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Lbl100
        '
        Me.Lbl100.AutoSize = True
        Me.Lbl100.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Lbl100.ForeColor = System.Drawing.Color.Black
        Me.Lbl100.Location = New System.Drawing.Point(194, 418)
        Me.Lbl100.Name = "Lbl100"
        Me.Lbl100.Size = New System.Drawing.Size(29, 16)
        Me.Lbl100.TabIndex = 2
        Me.Lbl100.Text = "ΟΧΙ"
        Me.Lbl100.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Lbl166
        '
        Me.Lbl166.AutoSize = True
        Me.Lbl166.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Lbl166.ForeColor = System.Drawing.Color.Black
        Me.Lbl166.Location = New System.Drawing.Point(194, 378)
        Me.Lbl166.Name = "Lbl166"
        Me.Lbl166.Size = New System.Drawing.Size(29, 16)
        Me.Lbl166.TabIndex = 2
        Me.Lbl166.Text = "ΟΧΙ"
        Me.Lbl166.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label9.ForeColor = System.Drawing.Color.Black
        Me.Label9.Location = New System.Drawing.Point(43, 378)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(93, 16)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "Αίτηση ΕΚΑΒ :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label3.ForeColor = System.Drawing.Color.Black
        Me.Label3.Location = New System.Drawing.Point(85, 150)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(81, 25)
        Me.Label3.TabIndex = 2
        Me.Label3.Text = "Tickets"
        '
        'Label8
        '
        Me.Label8.BackColor = System.Drawing.Color.Gray
        Me.Label8.Location = New System.Drawing.Point(43, 348)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(163, 3)
        Me.Label8.TabIndex = 1
        Me.Label8.Text = "_______________"
        '
        'Label4
        '
        Me.Label4.BackColor = System.Drawing.Color.Gray
        Me.Label4.Location = New System.Drawing.Point(42, 188)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(163, 3)
        Me.Label4.TabIndex = 1
        Me.Label4.Text = "_______________"
        '
        'Label2
        '
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(51, Byte), Integer), CType(CType(122, Byte), Integer), CType(CType(174, Byte), Integer))
        Me.Label2.Location = New System.Drawing.Point(43, 119)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(163, 3)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "_______________"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, CType(161, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.Black
        Me.Label1.Location = New System.Drawing.Point(62, 75)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(114, 31)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "InsOrAp"
        '
        'DateTimeCurrent
        '
        Me.DateTimeCurrent.Location = New System.Drawing.Point(776, 123)
        Me.DateTimeCurrent.Name = "DateTimeCurrent"
        Me.DateTimeCurrent.Size = New System.Drawing.Size(254, 20)
        Me.DateTimeCurrent.TabIndex = 1
        '
        'FrmInsuranceAdmin
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1033, 733)
        Me.Controls.Add(Me.DateTimeCurrent)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "FrmInsuranceAdmin"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "InsOrApp"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        Me.Panel1.ResumeLayout(False)
        Me.Panel3.ResumeLayout(False)
        CType(Me.MainGrid, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents ToolStripMenuItemCustomers As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemContracts As ToolStripMenuItem
    Friend WithEvents ToolStripMenuItemPragmatognomonas As ToolStripMenuItem
    Friend WithEvents Panel1 As Panel
    Friend WithEvents Panel2 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label7 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label12 As Label
    Friend WithEvents Panel3 As Panel
    Friend WithEvents ToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ΠελάτηςToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents WebMap As WebBrowser
    Friend WithEvents MainGrid As DataGridView
    Friend WithEvents DateTimeCurrent As DateTimePicker
    Friend WithEvents LblCountInProgress As Label
    Friend WithEvents LblCountFinished As Label
    Friend WithEvents LblTotalCount As Label
    Friend WithEvents Label13 As Label
    Friend WithEvents LblYpaitios As Label
    Friend WithEvents lblOdBoh As Label
    Friend WithEvents Lbl100 As Label
    Friend WithEvents Lbl166 As Label
End Class
