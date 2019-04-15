<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmAddProduct
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
        Me.components = New System.ComponentModel.Container()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.Label19 = New System.Windows.Forms.Label()
        Me.txtPrice = New System.Windows.Forms.TextBox()
        Me.Label18 = New System.Windows.Forms.Label()
        Me.Label17 = New System.Windows.Forms.Label()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.txtMax = New System.Windows.Forms.NumericUpDown()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.btnGenCode = New System.Windows.Forms.Button()
        Me.btnUnit = New System.Windows.Forms.Button()
        Me.btnMade = New System.Windows.Forms.Button()
        Me.btnCategory = New System.Windows.Forms.Button()
        Me.btnClass = New System.Windows.Forms.Button()
        Me.btnBrand = New System.Windows.Forms.Button()
        Me.txtAlert = New System.Windows.Forms.NumericUpDown()
        Me.cboUnit = New System.Windows.Forms.ComboBox()
        Me.cboMadeIn = New System.Windows.Forms.ComboBox()
        Me.cboCategory = New System.Windows.Forms.ComboBox()
        Me.cboClass = New System.Windows.Forms.ComboBox()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.rbNo = New System.Windows.Forms.RadioButton()
        Me.rbYes = New System.Windows.Forms.RadioButton()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.txtDes = New System.Windows.Forms.TextBox()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.txtWeight = New System.Windows.Forms.TextBox()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.cboBrand = New System.Windows.Forms.ComboBox()
        Me.txtPName = New System.Windows.Forms.TextBox()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.bntCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.txtCode = New System.Windows.Forms.TextBox()
        Me.Label23 = New System.Windows.Forms.Label()
        Me.ttProduct = New System.Windows.Forms.ToolTip(Me.components)
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.txtMax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtAlert, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Panel1)
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(708, 588)
        Me.Panel2.TabIndex = 6
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(7, 7)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(694, 40)
        Me.Panel1.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DimGray
        Me.Label1.Location = New System.Drawing.Point(284, 10)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(124, 21)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "ADD PRODUCT"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.White
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.Label19)
        Me.Panel4.Controls.Add(Me.txtPrice)
        Me.Panel4.Controls.Add(Me.Label18)
        Me.Panel4.Controls.Add(Me.Label17)
        Me.Panel4.Controls.Add(Me.Label16)
        Me.Panel4.Controls.Add(Me.txtMax)
        Me.Panel4.Controls.Add(Me.Label10)
        Me.Panel4.Controls.Add(Me.Label15)
        Me.Panel4.Controls.Add(Me.Label14)
        Me.Panel4.Controls.Add(Me.Label13)
        Me.Panel4.Controls.Add(Me.btnGenCode)
        Me.Panel4.Controls.Add(Me.btnUnit)
        Me.Panel4.Controls.Add(Me.btnMade)
        Me.Panel4.Controls.Add(Me.btnCategory)
        Me.Panel4.Controls.Add(Me.btnClass)
        Me.Panel4.Controls.Add(Me.btnBrand)
        Me.Panel4.Controls.Add(Me.txtAlert)
        Me.Panel4.Controls.Add(Me.cboUnit)
        Me.Panel4.Controls.Add(Me.cboMadeIn)
        Me.Panel4.Controls.Add(Me.cboCategory)
        Me.Panel4.Controls.Add(Me.cboClass)
        Me.Panel4.Controls.Add(Me.Label8)
        Me.Panel4.Controls.Add(Me.rbNo)
        Me.Panel4.Controls.Add(Me.rbYes)
        Me.Panel4.Controls.Add(Me.Label7)
        Me.Panel4.Controls.Add(Me.txtDes)
        Me.Panel4.Controls.Add(Me.Label9)
        Me.Panel4.Controls.Add(Me.Label11)
        Me.Panel4.Controls.Add(Me.txtWeight)
        Me.Panel4.Controls.Add(Me.Label12)
        Me.Panel4.Controls.Add(Me.Label6)
        Me.Panel4.Controls.Add(Me.cboBrand)
        Me.Panel4.Controls.Add(Me.txtPName)
        Me.Panel4.Controls.Add(Me.Label5)
        Me.Panel4.Controls.Add(Me.Label4)
        Me.Panel4.Controls.Add(Me.bntCancel)
        Me.Panel4.Controls.Add(Me.btnSave)
        Me.Panel4.Controls.Add(Me.Label3)
        Me.Panel4.Controls.Add(Me.Label2)
        Me.Panel4.Controls.Add(Me.txtCode)
        Me.Panel4.Controls.Add(Me.Label23)
        Me.Panel4.Location = New System.Drawing.Point(7, 51)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(694, 530)
        Me.Panel4.TabIndex = 1
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Red
        Me.Label19.Location = New System.Drawing.Point(166, 203)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(13, 17)
        Me.Label19.TabIndex = 306
        Me.Label19.Text = "*"
        '
        'txtPrice
        '
        Me.txtPrice.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPrice.Location = New System.Drawing.Point(66, 223)
        Me.txtPrice.MaxLength = 50
        Me.txtPrice.Name = "txtPrice"
        Me.txtPrice.Size = New System.Drawing.Size(250, 25)
        Me.txtPrice.TabIndex = 6
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label18.Location = New System.Drawing.Point(63, 203)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(97, 17)
        Me.Label18.TabIndex = 305
        Me.Label18.Text = "Unit Price (Php)"
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label17.ForeColor = System.Drawing.Color.Red
        Me.Label17.Location = New System.Drawing.Point(100, 154)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(13, 17)
        Me.Label17.TabIndex = 303
        Me.Label17.Text = "*"
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label16.ForeColor = System.Drawing.Color.Red
        Me.Label16.Location = New System.Drawing.Point(157, 58)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(13, 17)
        Me.Label16.TabIndex = 302
        Me.Label16.Text = "*"
        '
        'txtMax
        '
        Me.txtMax.Location = New System.Drawing.Point(379, 271)
        Me.txtMax.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.txtMax.Minimum = New Decimal(New Integer() {1, 0, 0, 0})
        Me.txtMax.Name = "txtMax"
        Me.txtMax.Size = New System.Drawing.Size(250, 25)
        Me.txtMax.TabIndex = 17
        Me.txtMax.Value = New Decimal(New Integer() {1, 0, 0, 0})
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label10.Location = New System.Drawing.Point(376, 250)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(115, 17)
        Me.Label10.TabIndex = 300
        Me.Label10.Text = "Maximum Stock-In"
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Red
        Me.Label15.Location = New System.Drawing.Point(161, 106)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(13, 17)
        Me.Label15.TabIndex = 299
        Me.Label15.Text = "*"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label14.ForeColor = System.Drawing.Color.Red
        Me.Label14.Location = New System.Drawing.Point(124, 443)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(13, 17)
        Me.Label14.TabIndex = 298
        Me.Label14.Text = "*"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.Location = New System.Drawing.Point(63, 443)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(149, 17)
        Me.Label13.TabIndex = 297
        Me.Label13.Text = "Field with  *  is required."
        '
        'btnGenCode
        '
        Me.btnGenCode.BackColor = System.Drawing.Color.White
        Me.btnGenCode.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.btnGenCode.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnGenCode.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnGenCode.Location = New System.Drawing.Point(322, 78)
        Me.btnGenCode.Name = "btnGenCode"
        Me.btnGenCode.Size = New System.Drawing.Size(25, 25)
        Me.btnGenCode.TabIndex = 2
        Me.btnGenCode.Text = "+"
        Me.ttProduct.SetToolTip(Me.btnGenCode, "Generate Product Code")
        Me.btnGenCode.UseVisualStyleBackColor = False
        '
        'btnUnit
        '
        Me.btnUnit.BackColor = System.Drawing.Color.White
        Me.btnUnit.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.btnUnit.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnUnit.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnUnit.Location = New System.Drawing.Point(322, 174)
        Me.btnUnit.Name = "btnUnit"
        Me.btnUnit.Size = New System.Drawing.Size(25, 25)
        Me.btnUnit.TabIndex = 5
        Me.btnUnit.Text = "+"
        Me.ttProduct.SetToolTip(Me.btnUnit, "Add Unit")
        Me.btnUnit.UseVisualStyleBackColor = False
        '
        'btnMade
        '
        Me.btnMade.BackColor = System.Drawing.Color.White
        Me.btnMade.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.btnMade.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnMade.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnMade.Location = New System.Drawing.Point(635, 78)
        Me.btnMade.Name = "btnMade"
        Me.btnMade.Size = New System.Drawing.Size(25, 25)
        Me.btnMade.TabIndex = 14
        Me.btnMade.Text = "+"
        Me.ttProduct.SetToolTip(Me.btnMade, "Add Made In")
        Me.btnMade.UseVisualStyleBackColor = False
        '
        'btnCategory
        '
        Me.btnCategory.BackColor = System.Drawing.Color.White
        Me.btnCategory.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.btnCategory.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnCategory.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnCategory.Location = New System.Drawing.Point(322, 367)
        Me.btnCategory.Name = "btnCategory"
        Me.btnCategory.Size = New System.Drawing.Size(25, 25)
        Me.btnCategory.TabIndex = 12
        Me.btnCategory.Text = "+"
        Me.ttProduct.SetToolTip(Me.btnCategory, "Add Category")
        Me.btnCategory.UseVisualStyleBackColor = False
        '
        'btnClass
        '
        Me.btnClass.BackColor = System.Drawing.Color.White
        Me.btnClass.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.btnClass.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnClass.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnClass.Location = New System.Drawing.Point(322, 319)
        Me.btnClass.Name = "btnClass"
        Me.btnClass.Size = New System.Drawing.Size(25, 25)
        Me.btnClass.TabIndex = 10
        Me.btnClass.Text = "+"
        Me.ttProduct.SetToolTip(Me.btnClass, "Add Class")
        Me.btnClass.UseVisualStyleBackColor = False
        '
        'btnBrand
        '
        Me.btnBrand.BackColor = System.Drawing.Color.White
        Me.btnBrand.FlatAppearance.BorderColor = System.Drawing.Color.Gray
        Me.btnBrand.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBrand.Font = New System.Drawing.Font("Segoe UI Semibold", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBrand.Location = New System.Drawing.Point(322, 271)
        Me.btnBrand.Name = "btnBrand"
        Me.btnBrand.Size = New System.Drawing.Size(25, 25)
        Me.btnBrand.TabIndex = 8
        Me.btnBrand.Text = "+"
        Me.ttProduct.SetToolTip(Me.btnBrand, "Add Brand")
        Me.btnBrand.UseVisualStyleBackColor = False
        '
        'txtAlert
        '
        Me.txtAlert.Location = New System.Drawing.Point(379, 368)
        Me.txtAlert.Name = "txtAlert"
        Me.txtAlert.Size = New System.Drawing.Size(250, 25)
        Me.txtAlert.TabIndex = 20
        Me.txtAlert.Value = New Decimal(New Integer() {50, 0, 0, 0})
        '
        'cboUnit
        '
        Me.cboUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboUnit.FormattingEnabled = True
        Me.cboUnit.Items.AddRange(New Object() {"Clerk", "Administrator"})
        Me.cboUnit.Location = New System.Drawing.Point(66, 174)
        Me.cboUnit.Name = "cboUnit"
        Me.cboUnit.Size = New System.Drawing.Size(250, 25)
        Me.cboUnit.TabIndex = 4
        '
        'cboMadeIn
        '
        Me.cboMadeIn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboMadeIn.FormattingEnabled = True
        Me.cboMadeIn.Items.AddRange(New Object() {"Clerk", "Administrator"})
        Me.cboMadeIn.Location = New System.Drawing.Point(379, 78)
        Me.cboMadeIn.Name = "cboMadeIn"
        Me.cboMadeIn.Size = New System.Drawing.Size(250, 25)
        Me.cboMadeIn.TabIndex = 13
        '
        'cboCategory
        '
        Me.cboCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboCategory.FormattingEnabled = True
        Me.cboCategory.Items.AddRange(New Object() {"Clerk", "Administrator"})
        Me.cboCategory.Location = New System.Drawing.Point(66, 367)
        Me.cboCategory.Name = "cboCategory"
        Me.cboCategory.Size = New System.Drawing.Size(250, 25)
        Me.cboCategory.TabIndex = 11
        '
        'cboClass
        '
        Me.cboClass.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboClass.FormattingEnabled = True
        Me.cboClass.Items.AddRange(New Object() {"Clerk", "Administrator"})
        Me.cboClass.Location = New System.Drawing.Point(66, 319)
        Me.cboClass.Name = "cboClass"
        Me.cboClass.Size = New System.Drawing.Size(250, 25)
        Me.cboClass.TabIndex = 9
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label8.Location = New System.Drawing.Point(376, 346)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(231, 17)
        Me.Label8.TabIndex = 284
        Me.Label8.Text = "If Yes, Quanty to Alert (In Percentile %)"
        '
        'rbNo
        '
        Me.rbNo.AutoSize = True
        Me.rbNo.Checked = True
        Me.rbNo.Location = New System.Drawing.Point(431, 321)
        Me.rbNo.Name = "rbNo"
        Me.rbNo.Size = New System.Drawing.Size(44, 21)
        Me.rbNo.TabIndex = 19
        Me.rbNo.TabStop = True
        Me.rbNo.Text = "No"
        Me.rbNo.UseVisualStyleBackColor = True
        '
        'rbYes
        '
        Me.rbYes.AutoSize = True
        Me.rbYes.Location = New System.Drawing.Point(379, 321)
        Me.rbYes.Name = "rbYes"
        Me.rbYes.Size = New System.Drawing.Size(46, 21)
        Me.rbYes.TabIndex = 18
        Me.rbYes.Text = "Yes"
        Me.rbYes.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label7.Location = New System.Drawing.Point(376, 299)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(35, 17)
        Me.Label7.TabIndex = 280
        Me.Label7.Text = "Alert"
        '
        'txtDes
        '
        Me.txtDes.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDes.Location = New System.Drawing.Point(379, 174)
        Me.txtDes.MaxLength = 50
        Me.txtDes.Multiline = True
        Me.txtDes.Name = "txtDes"
        Me.txtDes.Size = New System.Drawing.Size(250, 73)
        Me.txtDes.TabIndex = 16
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label9.Location = New System.Drawing.Point(376, 154)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(74, 17)
        Me.Label9.TabIndex = 277
        Me.Label9.Text = "Description"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(63, 154)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(31, 17)
        Me.Label11.TabIndex = 275
        Me.Label11.Text = "Unit"
        '
        'txtWeight
        '
        Me.txtWeight.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtWeight.Location = New System.Drawing.Point(379, 126)
        Me.txtWeight.MaxLength = 50
        Me.txtWeight.Name = "txtWeight"
        Me.txtWeight.Size = New System.Drawing.Size(250, 25)
        Me.txtWeight.TabIndex = 15
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label12.Location = New System.Drawing.Point(376, 106)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(77, 17)
        Me.Label12.TabIndex = 274
        Me.Label12.Text = "Size/Weight"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label6.Location = New System.Drawing.Point(376, 58)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(56, 17)
        Me.Label6.TabIndex = 268
        Me.Label6.Text = "Made In"
        '
        'cboBrand
        '
        Me.cboBrand.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.cboBrand.FormattingEnabled = True
        Me.cboBrand.Items.AddRange(New Object() {"Clerk", "Administrator"})
        Me.cboBrand.Location = New System.Drawing.Point(66, 271)
        Me.cboBrand.Name = "cboBrand"
        Me.cboBrand.Size = New System.Drawing.Size(250, 25)
        Me.cboBrand.TabIndex = 7
        '
        'txtPName
        '
        Me.txtPName.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtPName.Location = New System.Drawing.Point(66, 126)
        Me.txtPName.MaxLength = 50
        Me.txtPName.Name = "txtPName"
        Me.txtPName.Size = New System.Drawing.Size(250, 25)
        Me.txtPName.TabIndex = 3
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(63, 347)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(61, 17)
        Me.Label5.TabIndex = 266
        Me.Label5.Text = "Category"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(63, 299)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(38, 17)
        Me.Label4.TabIndex = 264
        Me.Label4.Text = "Class"
        '
        'bntCancel
        '
        Me.bntCancel.BackColor = System.Drawing.SystemColors.Control
        Me.bntCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bntCancel.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bntCancel.Location = New System.Drawing.Point(507, 431)
        Me.bntCancel.Name = "bntCancel"
        Me.bntCancel.Size = New System.Drawing.Size(122, 40)
        Me.bntCancel.TabIndex = 22
        Me.bntCancel.Text = "CANCEL"
        Me.bntCancel.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.White
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(379, 431)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(122, 40)
        Me.btnSave.TabIndex = 21
        Me.btnSave.Text = "SAVE"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(63, 251)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(42, 17)
        Me.Label3.TabIndex = 258
        Me.Label3.Text = "Brand"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(63, 106)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(92, 17)
        Me.Label2.TabIndex = 256
        Me.Label2.Text = "Product Name"
        '
        'txtCode
        '
        Me.txtCode.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCode.Location = New System.Drawing.Point(66, 78)
        Me.txtCode.MaxLength = 50
        Me.txtCode.Name = "txtCode"
        Me.txtCode.Size = New System.Drawing.Size(250, 25)
        Me.txtCode.TabIndex = 1
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Font = New System.Drawing.Font("Segoe UI", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label23.Location = New System.Drawing.Point(63, 58)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(88, 17)
        Me.Label23.TabIndex = 254
        Me.Label23.Text = "Product Code"
        '
        'frmAddProduct
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(708, 588)
        Me.Controls.Add(Me.Panel2)
        Me.Font = New System.Drawing.Font("Segoe UI", 9.75!)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(3, 4, 3, 4)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmAddProduct"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.txtMax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtAlert, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents bntCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents txtCode As System.Windows.Forms.TextBox
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents txtPName As TextBox
    Friend WithEvents cboBrand As ComboBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents txtDes As System.Windows.Forms.TextBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents txtWeight As System.Windows.Forms.TextBox
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents btnGenCode As System.Windows.Forms.Button
    Friend WithEvents btnUnit As System.Windows.Forms.Button
    Friend WithEvents btnMade As System.Windows.Forms.Button
    Friend WithEvents btnCategory As System.Windows.Forms.Button
    Friend WithEvents btnClass As System.Windows.Forms.Button
    Friend WithEvents btnBrand As System.Windows.Forms.Button
    Friend WithEvents txtAlert As System.Windows.Forms.NumericUpDown
    Friend WithEvents cboUnit As System.Windows.Forms.ComboBox
    Friend WithEvents cboMadeIn As System.Windows.Forms.ComboBox
    Friend WithEvents cboCategory As System.Windows.Forms.ComboBox
    Friend WithEvents cboClass As System.Windows.Forms.ComboBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents rbNo As System.Windows.Forms.RadioButton
    Friend WithEvents rbYes As System.Windows.Forms.RadioButton
    Friend WithEvents ttProduct As System.Windows.Forms.ToolTip
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents txtMax As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents txtPrice As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
End Class
