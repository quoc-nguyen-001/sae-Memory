<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FinJeu
    Inherits System.Windows.Forms.Form

    'Form remplace la méthode Dispose pour nettoyer la liste des composants.
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

    'Requise par le Concepteur Windows Form
    Private components As System.ComponentModel.IContainer

    'REMARQUE : la procédure suivante est requise par le Concepteur Windows Form
    'Elle peut être modifiée à l'aide du Concepteur Windows Form.  
    'Ne la modifiez pas à l'aide de l'éditeur de code.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.Label2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Location = New System.Drawing.Point(12, 110)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(488, 327)
        Me.Panel1.TabIndex = 0
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Ravie", 36.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(54, 188)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(393, 81)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = """EXODIA"""
        '
        'Label1
        '
        Me.Label1.Font = New System.Drawing.Font("Viner Hand ITC", 19.8!, CType((System.Drawing.FontStyle.Bold Or System.Drawing.FontStyle.Italic), System.Drawing.FontStyle), System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(43, 39)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(426, 246)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "You have SUMMON the FORBIDDEN GOD: "
        '
        'Label8
        '
        Me.Label8.Location = New System.Drawing.Point(298, 175)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(114, 135)
        Me.Label8.TabIndex = 12
        Me.Label8.Text = "Label8"
        '
        'Label9
        '
        Me.Label9.Location = New System.Drawing.Point(234, 278)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(114, 135)
        Me.Label9.TabIndex = 11
        Me.Label9.Text = "Label9"
        '
        'Label10
        '
        Me.Label10.Location = New System.Drawing.Point(58, 175)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(114, 135)
        Me.Label10.TabIndex = 10
        Me.Label10.Text = "Label10"
        '
        'Label11
        '
        Me.Label11.Location = New System.Drawing.Point(114, 278)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(114, 135)
        Me.Label11.TabIndex = 9
        Me.Label11.Text = "Label11"
        '
        'Label3
        '
        Me.Label3.Location = New System.Drawing.Point(178, 143)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(114, 135)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Label3"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(29, 51)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(57, 16)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Joueur : "
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(124, 51)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(48, 16)
        Me.Label5.TabIndex = 15
        Me.Label5.Text = "Label5"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(243, 51)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(53, 16)
        Me.Label6.TabIndex = 16
        Me.Label6.Text = "temps : "
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(344, 51)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(48, 16)
        Me.Label7.TabIndex = 17
        Me.Label7.Text = "Label7"
        '
        'FinJeu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(8.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(526, 457)
        Me.Controls.Add(Me.Label7)
        Me.Controls.Add(Me.Label6)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label8)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Panel1)
        Me.Name = "FinJeu"
        Me.Text = "FinJeu"
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Panel1 As Panel
    Friend WithEvents Label1 As Label
    Friend WithEvents Label2 As Label
    Friend WithEvents Label8 As Label
    Friend WithEvents Label9 As Label
    Friend WithEvents Label10 As Label
    Friend WithEvents Label11 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Label5 As Label
    Friend WithEvents Label6 As Label
    Friend WithEvents Label7 As Label
End Class
