<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmDiscount
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
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.rbPer = New System.Windows.Forms.RadioButton()
        Me.rbAmount = New System.Windows.Forms.RadioButton()
        Me.txtDis = New System.Windows.Forms.NumericUpDown()
        Me.bntCancel = New System.Windows.Forms.Button()
        Me.btnSave = New System.Windows.Forms.Button()
        Me.Panel2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.Panel4.SuspendLayout()
        CType(Me.txtDis, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.Panel1)
        Me.Panel2.Controls.Add(Me.Panel4)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel2.Location = New System.Drawing.Point(0, 0)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(311, 242)
        Me.Panel2.TabIndex = 9
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.White
        Me.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(7, 7)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(297, 40)
        Me.Panel1.TabIndex = 6
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DimGray
        Me.Label1.Location = New System.Drawing.Point(101, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(92, 21)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "DISCOUNT"
        '
        'Panel4
        '
        Me.Panel4.BackColor = System.Drawing.Color.White
        Me.Panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Panel4.Controls.Add(Me.rbPer)
        Me.Panel4.Controls.Add(Me.rbAmount)
        Me.Panel4.Controls.Add(Me.txtDis)
        Me.Panel4.Controls.Add(Me.bntCancel)
        Me.Panel4.Controls.Add(Me.btnSave)
        Me.Panel4.Location = New System.Drawing.Point(7, 51)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(297, 183)
        Me.Panel4.TabIndex = 1
        '
        'rbPer
        '
        Me.rbPer.AutoSize = True
        Me.rbPer.Location = New System.Drawing.Point(120, 23)
        Me.rbPer.Name = "rbPer"
        Me.rbPer.Size = New System.Drawing.Size(96, 25)
        Me.rbPer.TabIndex = 5
        Me.rbPer.Text = "Percentile"
        Me.rbPer.UseVisualStyleBackColor = True
        '
        'rbAmount
        '
        Me.rbAmount.AutoSize = True
        Me.rbAmount.Location = New System.Drawing.Point(21, 23)
        Me.rbAmount.Name = "rbAmount"
        Me.rbAmount.Size = New System.Drawing.Size(84, 25)
        Me.rbAmount.TabIndex = 4
        Me.rbAmount.Text = "Amount"
        Me.rbAmount.UseVisualStyleBackColor = True
        '
        'txtDis
        '
        Me.txtDis.DecimalPlaces = 2
        Me.txtDis.Enabled = False
        Me.txtDis.Font = New System.Drawing.Font("Segoe UI", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtDis.Location = New System.Drawing.Point(22, 58)
        Me.txtDis.Name = "txtDis"
        Me.txtDis.Size = New System.Drawing.Size(250, 32)
        Me.txtDis.TabIndex = 1
        Me.txtDis.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        Me.txtDis.ThousandsSeparator = True
        '
        'bntCancel
        '
        Me.bntCancel.BackColor = System.Drawing.SystemColors.Control
        Me.bntCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.bntCancel.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.bntCancel.Location = New System.Drawing.Point(150, 111)
        Me.bntCancel.Name = "bntCancel"
        Me.bntCancel.Size = New System.Drawing.Size(122, 40)
        Me.bntCancel.TabIndex = 3
        Me.bntCancel.Text = "CANCEL"
        Me.bntCancel.UseVisualStyleBackColor = False
        '
        'btnSave
        '
        Me.btnSave.BackColor = System.Drawing.Color.White
        Me.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSave.Font = New System.Drawing.Font("Segoe UI Semibold", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnSave.Location = New System.Drawing.Point(22, 111)
        Me.btnSave.Name = "btnSave"
        Me.btnSave.Size = New System.Drawing.Size(122, 40)
        Me.btnSave.TabIndex = 2
        Me.btnSave.Text = "OK"
        Me.btnSave.UseVisualStyleBackColor = False
        '
        'frmDiscount
        '
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None
        Me.ClientSize = New System.Drawing.Size(311, 242)
        Me.Controls.Add(Me.Panel2)
        Me.Font = New System.Drawing.Font("Segoe UI", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Margin = New System.Windows.Forms.Padding(4, 5, 4, 5)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "frmDiscount"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Panel2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.Panel4.ResumeLayout(False)
        Me.Panel4.PerformLayout()
        CType(Me.txtDis, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents Panel2 As System.Windows.Forms.Panel
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Panel4 As System.Windows.Forms.Panel
    Friend WithEvents bntCancel As System.Windows.Forms.Button
    Friend WithEvents btnSave As System.Windows.Forms.Button
    Friend WithEvents txtDis As System.Windows.Forms.NumericUpDown
    Friend WithEvents rbPer As System.Windows.Forms.RadioButton
    Friend WithEvents rbAmount As System.Windows.Forms.RadioButton

End Class
