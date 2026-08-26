<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmTagHistory
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
        Me.ListView1 = New System.Windows.Forms.ListView()
        Me.ColumnHeader3 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader4 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader10 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader5 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.ColumnHeader9 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.lblLSAt = New System.Windows.Forms.Label()
        Me.lblLSTime = New System.Windows.Forms.Label()
        Me.lblStage = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.lblIATA = New System.Windows.Forms.Label()
        Me.lblBHS = New System.Windows.Forms.Label()
        Me.lblThreat = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(33, Byte), Integer), CType(CType(150, Byte), Integer), CType(CType(243, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(12, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(69, 14)
        Me.Label1.TabIndex = 57
        Me.Label1.Text = "Tag History"
        '
        'ListView1
        '
        Me.ListView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListView1.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader3, Me.ColumnHeader4, Me.ColumnHeader10, Me.ColumnHeader5, Me.ColumnHeader9})
        Me.ListView1.Font = New System.Drawing.Font("Roboto", 9.0!)
        Me.ListView1.FullRowSelect = True
        Me.ListView1.Location = New System.Drawing.Point(12, 100)
        Me.ListView1.Name = "ListView1"
        Me.ListView1.Size = New System.Drawing.Size(852, 227)
        Me.ListView1.TabIndex = 59
        Me.ListView1.UseCompatibleStateImageBehavior = False
        Me.ListView1.View = System.Windows.Forms.View.Details
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
        'ColumnHeader10
        '
        Me.ColumnHeader10.Text = "Description"
        Me.ColumnHeader10.Width = 163
        '
        'ColumnHeader5
        '
        Me.ColumnHeader5.Text = "Location"
        Me.ColumnHeader5.Width = 76
        '
        'ColumnHeader9
        '
        Me.ColumnHeader9.Text = "SMIS"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Roboto", 16.0!)
        Me.Label2.Location = New System.Drawing.Point(12, 34)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(79, 27)
        Me.Label2.TabIndex = 60
        Me.Label2.Text = "Label2"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(599, 18)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(65, 14)
        Me.Label3.TabIndex = 61
        Me.Label3.Text = "Last Stage"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(599, 40)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 14)
        Me.Label4.TabIndex = 62
        Me.Label4.Text = "Last Seen"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(599, 62)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(75, 14)
        Me.Label5.TabIndex = 63
        Me.Label5.Text = "Last Seen At"
        '
        'lblLSAt
        '
        Me.lblLSAt.AutoSize = True
        Me.lblLSAt.Font = New System.Drawing.Font("Roboto", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLSAt.Location = New System.Drawing.Point(687, 62)
        Me.lblLSAt.Name = "lblLSAt"
        Me.lblLSAt.Size = New System.Drawing.Size(74, 14)
        Me.lblLSAt.TabIndex = 66
        Me.lblLSAt.Text = "Last Seen At"
        '
        'lblLSTime
        '
        Me.lblLSTime.AutoSize = True
        Me.lblLSTime.Font = New System.Drawing.Font("Roboto", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblLSTime.Location = New System.Drawing.Point(687, 40)
        Me.lblLSTime.Name = "lblLSTime"
        Me.lblLSTime.Size = New System.Drawing.Size(59, 14)
        Me.lblLSTime.TabIndex = 65
        Me.lblLSTime.Text = "Last Seen"
        '
        'lblStage
        '
        Me.lblStage.AutoSize = True
        Me.lblStage.Font = New System.Drawing.Font("Roboto", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblStage.Location = New System.Drawing.Point(687, 18)
        Me.lblStage.Name = "lblStage"
        Me.lblStage.Size = New System.Drawing.Size(70, 14)
        Me.lblStage.TabIndex = 64
        Me.lblStage.Text = "Threat Type"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(385, 40)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(47, 14)
        Me.Label10.TabIndex = 68
        Me.Label10.Text = "IATA ID"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(385, 18)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(82, 14)
        Me.Label11.TabIndex = 67
        Me.Label11.Text = "BHS Global ID"
        '
        'lblIATA
        '
        Me.lblIATA.AutoSize = True
        Me.lblIATA.Font = New System.Drawing.Font("Roboto", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblIATA.Location = New System.Drawing.Point(473, 40)
        Me.lblIATA.Name = "lblIATA"
        Me.lblIATA.Size = New System.Drawing.Size(49, 14)
        Me.lblIATA.TabIndex = 70
        Me.lblIATA.Text = "IATA ID"
        '
        'lblBHS
        '
        Me.lblBHS.AutoSize = True
        Me.lblBHS.Font = New System.Drawing.Font("Roboto", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblBHS.Location = New System.Drawing.Point(473, 18)
        Me.lblBHS.Name = "lblBHS"
        Me.lblBHS.Size = New System.Drawing.Size(82, 14)
        Me.lblBHS.TabIndex = 69
        Me.lblBHS.Text = "BHS Global ID"
        '
        'lblThreat
        '
        Me.lblThreat.AutoSize = True
        Me.lblThreat.Font = New System.Drawing.Font("Roboto", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblThreat.Location = New System.Drawing.Point(473, 62)
        Me.lblThreat.Name = "lblThreat"
        Me.lblThreat.Size = New System.Drawing.Size(49, 14)
        Me.lblThreat.TabIndex = 72
        Me.lblThreat.Text = "IATA ID"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(385, 62)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(67, 14)
        Me.Label7.TabIndex = 71
        Me.Label7.Text = "Theat Type"
        '
        'frmTagHistory
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 14.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer), CType(CType(249, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(876, 339)
        Me.Controls.Add(Me.lblThreat)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.lblIATA)
        Me.Controls.Add(Me.lblBHS)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.lblLSAt)
        Me.Controls.Add(Me.lblLSTime)
        Me.Controls.Add(Me.lblStage)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.ListView1)
        Me.Controls.Add(Me.Label1)
        Me.Font = New System.Drawing.Font("Roboto", 9.0!)
        Me.Name = "frmTagHistory"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Tag History"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ListView1 As System.Windows.Forms.ListView
    Friend WithEvents ColumnHeader3 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader4 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader10 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader5 As System.Windows.Forms.ColumnHeader
    Friend WithEvents ColumnHeader9 As System.Windows.Forms.ColumnHeader
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents lblLSAt As System.Windows.Forms.Label
    Friend WithEvents lblLSTime As System.Windows.Forms.Label
    Friend WithEvents lblStage As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents lblIATA As System.Windows.Forms.Label
    Friend WithEvents lblBHS As System.Windows.Forms.Label
    Friend WithEvents lblThreat As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
End Class
