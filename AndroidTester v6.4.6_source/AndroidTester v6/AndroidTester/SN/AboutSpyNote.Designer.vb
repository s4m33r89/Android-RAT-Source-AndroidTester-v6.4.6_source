﻿<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class AboutSpyNote
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
        Me.PNL1 = New System.Windows.Forms.Panel()
        Me.PNL5 = New System.Windows.Forms.Panel()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Trans = New System.Windows.Forms.Timer(Me.components)
        Me.PNL1.SuspendLayout()
        Me.PNL5.SuspendLayout()
        Me.SuspendLayout()
        '
        'PNL1
        '
        Me.PNL1.BackColor = System.Drawing.Color.FromArgb(CType(CType(37, Byte), Integer), CType(CType(37, Byte), Integer), CType(CType(38, Byte), Integer))
        Me.PNL1.Controls.Add(Me.PNL5)
        Me.PNL1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.PNL1.Location = New System.Drawing.Point(0, 0)
        Me.PNL1.Name = "PNL1"
        Me.PNL1.Size = New System.Drawing.Size(495, 110)
        Me.PNL1.TabIndex = 0
        '
        'PNL5
        '
        Me.PNL5.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.PNL5.Controls.Add(Me.Label4)
        Me.PNL5.Controls.Add(Me.Label2)
        Me.PNL5.Controls.Add(Me.Label1)
        Me.PNL5.Dock = System.Windows.Forms.DockStyle.Top
        Me.PNL5.Location = New System.Drawing.Point(0, 0)
        Me.PNL5.Name = "PNL5"
        Me.PNL5.Size = New System.Drawing.Size(495, 122)
        Me.PNL5.TabIndex = 0
        '
        'Label4
        '
        Me.Label4.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label4.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(0, 66)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(495, 33)
        Me.Label4.TabIndex = 3
        Me.Label4.Text = "Tested Platforms: Win7, Win8, Win10, Server 2016"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label2
        '
        Me.Label2.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label2.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(0, 33)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(495, 33)
        Me.Label2.TabIndex = 1
        Me.Label2.Text = "Version: 6.4.6"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Label1
        '
        Me.Label1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Label1.Font = New System.Drawing.Font("Consolas", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(0, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(495, 33)
        Me.Label1.TabIndex = 0
        Me.Label1.Text = "Android Tester | Editing By: kkkk"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter
        '
        'Trans
        '
        Me.Trans.Interval = 40
        '
        'AboutSpyNote
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.FromArgb(CType(CType(28, Byte), Integer), CType(CType(28, Byte), Integer), CType(CType(28, Byte), Integer))
        Me.ClientSize = New System.Drawing.Size(495, 110)
        Me.Controls.Add(Me.PNL1)
        Me.Font = New System.Drawing.Font("Consolas", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ForeColor = System.Drawing.Color.FromArgb(CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer), CType(CType(170, Byte), Integer))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.Name = "AboutSpyNote"
        Me.Opacity = 0R
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "About Android Tester"
        Me.PNL1.ResumeLayout(False)
        Me.PNL5.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents PNL1 As Panel
    Friend WithEvents PNL5 As Panel
    Friend WithEvents Label2 As Label
    Friend WithEvents Label1 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents Trans As Timer
End Class
