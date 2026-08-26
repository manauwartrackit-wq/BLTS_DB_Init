<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTagReport
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
        Me.Label1 = New System.Windows.Forms.Label()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.btnSearch = New System.Windows.Forms.Button()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.dtTo = New System.Windows.Forms.DateTimePicker()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.cbMissed = New System.Windows.Forms.CheckBox()
        Me.cbImproper = New System.Windows.Forms.CheckBox()
        Me.cbProper = New System.Windows.Forms.CheckBox()
        Me.dtFrom = New System.Windows.Forms.DateTimePicker()
        Me.cbSuspect = New System.Windows.Forms.CheckBox()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.cbProhibited = New System.Windows.Forms.CheckBox()
        Me.txtTagID = New System.Windows.Forms.TextBox()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.ListView1 = New ListViewDoubleBuffered
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader2 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader6 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader7 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader8 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.cbNormal = New System.Windows.Forms.CheckBox()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(243, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(10, 7)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(67, 14)
        Me.Label1.TabIndex = 56
        Me.Label1.Text = "Tag Report"
        '
        'GroupBox1
        '
        Me.GroupBox1.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.GroupBox1.Controls.Add(Me.cbNormal)
        Me.GroupBox1.Controls.Add(Me.btnSearch)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.dtTo)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.cbMissed)
        Me.GroupBox1.Controls.Add(Me.cbImproper)
        Me.GroupBox1.Controls.Add(Me.cbProper)
        Me.GroupBox1.Controls.Add(Me.dtFrom)
        Me.GroupBox1.Controls.Add(Me.cbSuspect)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.cbProhibited)
        Me.GroupBox1.Controls.Add(Me.txtTagID)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(9, 26)
        Me.GroupBox1.Margin = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Padding = New System.Windows.Forms.Padding(2)
        Me.GroupBox1.Size = New System.Drawing.Size(805, 192)
        Me.GroupBox1.TabIndex = 57
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "View Settings"
        '
        'btnSearch
        '
        Me.btnSearch.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSearch.Font = New System.Drawing.Font("Roboto", 12.0!)
        Me.btnSearch.Location = New System.Drawing.Point(622, 128)
        Me.btnSearch.Name = "btnSearch"
        Me.btnSearch.Size = New System.Drawing.Size(164, 51)
        Me.btnSearch.TabIndex = 58
        Me.btnSearch.Text = "Search"
        Me.btnSearch.UseVisualStyleBackColor = True
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(263, 163)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(18, 14)
        Me.Label5.TabIndex = 68
        Me.Label5.Text = "to"
        '
        'dtTo
        '
        Me.dtTo.Checked = False
        Me.dtTo.CustomFormat = "dd MMM yyyy HH:mm"
        Me.dtTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtTo.Location = New System.Drawing.Point(287, 157)
        Me.dtTo.Name = "dtTo"
        Me.dtTo.Size = New System.Drawing.Size(181, 22)
        Me.dtTo.TabIndex = 67
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(24, 163)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(42, 14)
        Me.Label4.TabIndex = 66
        Me.Label4.Text = "Period"
        '
        'cbMissed
        '
        Me.cbMissed.AutoSize = True
        Me.cbMissed.Checked = True
        Me.cbMissed.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbMissed.Font = New System.Drawing.Font("Roboto", 8.0!)
        Me.cbMissed.Location = New System.Drawing.Point(252, 128)
        Me.cbMissed.Name = "cbMissed"
        Me.cbMissed.Size = New System.Drawing.Size(108, 17)
        Me.cbMissed.TabIndex = 65
        Me.cbMissed.Text = "Missed Luggage"
        Me.cbMissed.UseVisualStyleBackColor = True
        '
        'cbImproper
        '
        Me.cbImproper.AutoSize = True
        Me.cbImproper.Checked = True
        Me.cbImproper.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbImproper.Font = New System.Drawing.Font("Roboto", 8.0!)
        Me.cbImproper.Location = New System.Drawing.Point(252, 105)
        Me.cbImproper.Name = "cbImproper"
        Me.cbImproper.Size = New System.Drawing.Size(128, 17)
        Me.cbImproper.TabIndex = 64
        Me.cbImproper.Text = "Delay Improper Path"
        Me.cbImproper.UseVisualStyleBackColor = True
        '
        'cbProper
        '
        Me.cbProper.AutoSize = True
        Me.cbProper.Checked = True
        Me.cbProper.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbProper.Font = New System.Drawing.Font("Roboto", 8.0!)
        Me.cbProper.Location = New System.Drawing.Point(252, 82)
        Me.cbProper.Name = "cbProper"
        Me.cbProper.Size = New System.Drawing.Size(116, 17)
        Me.cbProper.TabIndex = 63
        Me.cbProper.Text = "Delay Proper Path"
        Me.cbProper.UseVisualStyleBackColor = True
        '
        'dtFrom
        '
        Me.dtFrom.Checked = False
        Me.dtFrom.CustomFormat = "dd MMM yyyy HH:mm"
        Me.dtFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom
        Me.dtFrom.Location = New System.Drawing.Point(76, 157)
        Me.dtFrom.Name = "dtFrom"
        Me.dtFrom.ShowCheckBox = True
        Me.dtFrom.Size = New System.Drawing.Size(181, 22)
        Me.dtFrom.TabIndex = 62
        '
        'cbSuspect
        '
        Me.cbSuspect.AutoSize = True
        Me.cbSuspect.Checked = True
        Me.cbSuspect.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbSuspect.Location = New System.Drawing.Point(237, 59)
        Me.cbSuspect.Name = "cbSuspect"
        Me.cbSuspect.Size = New System.Drawing.Size(100, 18)
        Me.cbSuspect.TabIndex = 61
        Me.cbSuspect.Text = "Suspect Bags"
        Me.cbSuspect.UseVisualStyleBackColor = True
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(24, 59)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(46, 14)
        Me.Label3.TabIndex = 60
        Me.Label3.Text = "Priority"
        '
        'cbProhibited
        '
        Me.cbProhibited.AutoSize = True
        Me.cbProhibited.Checked = True
        Me.cbProhibited.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbProhibited.Location = New System.Drawing.Point(76, 59)
        Me.cbProhibited.Name = "cbProhibited"
        Me.cbProhibited.Size = New System.Drawing.Size(113, 18)
        Me.cbProhibited.TabIndex = 58
        Me.cbProhibited.Text = "Prohibited Bags"
        Me.cbProhibited.UseVisualStyleBackColor = True
        '
        'txtTagID
        '
        Me.txtTagID.Location = New System.Drawing.Point(76, 27)
        Me.txtTagID.MaxLength = 24
        Me.txtTagID.Name = "txtTagID"
        Me.txtTagID.Size = New System.Drawing.Size(181, 22)
        Me.txtTagID.TabIndex = 58
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(24, 30)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(42, 14)
        Me.Label2.TabIndex = 59
        Me.Label2.Text = "Tag ID"
        '
        'ListView1
        '
        Me.ListView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1, Me.ColumnHeader2, Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader5, Me.ColumnHeader6, Me.ColumnHeader7, Me.ColumnHeader8})
        Me.ListView1.Font = New System.Drawing.Font("Roboto", 9.0!)
        Me.ListView1.FullRowSelect = True
        Me.ListView1.Location = New System.Drawing.Point(9, 223)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(805, 263)
        Me.ListView1.TabIndex = 58
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
        '
        'ColumnHeader1
        '
        Me.ColumnHeader1.Text = "Tag ID"
        '
        'ColumnHeader2
        '
        Me.ColumnHeader2.Text = "Threat"
        '
        'ColumnHeader3
        '
        Me.ColumnHeader3.Text = "Time"
        '
        'ColumnHeader4
        '
        Me.ColumnHeader4.Text = "Alarm Type"
        Me.ColumnHeader4.Width = 91
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Location"
        Me.ColumnHeader5.Width = 76
        '
        'ColumnHeader6
        '
        Me.ColumnHeader6.Text = "Last Seen"
        Me.ColumnHeader6.Width = 89
        '
        'ColumnHeader7
        '
        Me.ColumnHeader7.Text = "Last Seen Location"
        Me.ColumnHeader7.Width = 131
        '
        'ColumnHeader8
        '
        Me.ColumnHeader8.Text = "Count"
        '
        'cbNormal
        '
        Me.cbNormal.AutoSize = True
        Me.cbNormal.Checked = True
        Me.cbNormal.CheckState = System.Windows.Forms.CheckState.Checked
        Me.cbNormal.Location = New System.Drawing.Point(449, 58)
        Me.cbNormal.Name = "cbNormal"
        Me.cbNormal.Size = New System.Drawing.Size(96, 18)
        Me.cbNormal.TabIndex = 69
        Me.cbNormal.Text = "Normal Bags"
        Me.cbNormal.UseVisualStyleBackColor = True
        '
        'frmTagReport
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(825, 498)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Roboto", 9.0!)
        Me.Name = "frmTagReport"
        Me.Text = "Tag Report"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtTagID As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cbSuspect As System.Windows.Forms.CheckBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents cbProhibited As System.Windows.Forms.CheckBox
    Friend WithEvents dtFrom As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents cbMissed As System.Windows.Forms.CheckBox
    Friend WithEvents cbImproper As System.Windows.Forms.CheckBox
    Friend WithEvents cbProper As System.Windows.Forms.CheckBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents dtTo As System.Windows.Forms.DateTimePicker
    Friend WithEvents btnSearch As System.Windows.Forms.Button
    Friend WithEvents ListView1 As ListViewDoubleBuffered
    Friend WithEvents ColumnHeader1 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader2 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader6 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader7 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader8 As System.Windows.Forms.ColumnHeader
    Friend WithEvents cbNormal As System.Windows.Forms.CheckBox
End Class
