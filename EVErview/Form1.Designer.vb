<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Das Formular überschreibt den Löschvorgang, um die Komponentenliste zu bereinigen.
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

    'Wird vom Windows Form-Designer benötigt.
    Private components As System.ComponentModel.IContainer

    'Hinweis: Die folgende Prozedur ist für den Windows Form-Designer erforderlich.
    'Das Bearbeiten ist mit dem Windows Form-Designer möglich.  
    'Das Bearbeiten mit dem Code-Editor ist nicht möglich.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.MenuStrip1 = New System.Windows.Forms.MenuStrip()
        Me.FileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.BrowseBackupsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImportSettingsFromFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExportSettingsToFileToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.CopyClientSettingsToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ExutToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
        Me.picChar_from = New System.Windows.Forms.PictureBox()
        Me.picChar_to = New System.Windows.Forms.PictureBox()
        Me.lstCharacterFrom = New System.Windows.Forms.ListBox()
        Me.lstCharacterTo = New System.Windows.Forms.ListBox()
        Me.btnCopy = New System.Windows.Forms.Button()
        Me.lblFrom = New System.Windows.Forms.Label()
        Me.lblTo = New System.Windows.Forms.Label()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog()
        Me.FolderBrowserDialog1 = New System.Windows.Forms.FolderBrowserDialog()
        Me.MenuStrip1.SuspendLayout()
        CType(Me.picChar_from, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picChar_to, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'MenuStrip1
        '
        Me.MenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.FileToolStripMenuItem})
        Me.MenuStrip1.Location = New System.Drawing.Point(0, 0)
        Me.MenuStrip1.Name = "MenuStrip1"
        Me.MenuStrip1.Size = New System.Drawing.Size(757, 24)
        Me.MenuStrip1.TabIndex = 0
        Me.MenuStrip1.Text = "MenuStrip1"
        '
        'FileToolStripMenuItem
        '
        Me.FileToolStripMenuItem.DropDownItems.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BrowseBackupsToolStripMenuItem, Me.ImportSettingsFromFileToolStripMenuItem, Me.ExportSettingsToFileToolStripMenuItem, Me.CopyClientSettingsToolStripMenuItem, Me.ExutToolStripMenuItem})
        Me.FileToolStripMenuItem.Name = "FileToolStripMenuItem"
        Me.FileToolStripMenuItem.Size = New System.Drawing.Size(37, 20)
        Me.FileToolStripMenuItem.Text = "File"
        '
        'BrowseBackupsToolStripMenuItem
        '
        Me.BrowseBackupsToolStripMenuItem.Name = "BrowseBackupsToolStripMenuItem"
        Me.BrowseBackupsToolStripMenuItem.Size = New System.Drawing.Size(205, 22)
        Me.BrowseBackupsToolStripMenuItem.Text = "Browse Backups"
        '
        'ImportSettingsFromFileToolStripMenuItem
        '
        Me.ImportSettingsFromFileToolStripMenuItem.Name = "ImportSettingsFromFileToolStripMenuItem"
        Me.ImportSettingsFromFileToolStripMenuItem.Size = New System.Drawing.Size(205, 22)
        Me.ImportSettingsFromFileToolStripMenuItem.Text = "Import Settings from File"
        '
        'ExportSettingsToFileToolStripMenuItem
        '
        Me.ExportSettingsToFileToolStripMenuItem.Name = "ExportSettingsToFileToolStripMenuItem"
        Me.ExportSettingsToFileToolStripMenuItem.Size = New System.Drawing.Size(205, 22)
        Me.ExportSettingsToFileToolStripMenuItem.Text = "Export Settings to File"
        '
        'CopyClientSettingsToolStripMenuItem
        '
        Me.CopyClientSettingsToolStripMenuItem.Name = "CopyClientSettingsToolStripMenuItem"
        Me.CopyClientSettingsToolStripMenuItem.Size = New System.Drawing.Size(205, 22)
        Me.CopyClientSettingsToolStripMenuItem.Text = "Copy Client-Settings"
        '
        'ExutToolStripMenuItem
        '
        Me.ExutToolStripMenuItem.Name = "ExutToolStripMenuItem"
        Me.ExutToolStripMenuItem.Size = New System.Drawing.Size(205, 22)
        Me.ExutToolStripMenuItem.Text = "Exit"
        '
        'ImageList1
        '
        Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit
        Me.ImageList1.ImageSize = New System.Drawing.Size(16, 16)
        Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
        '
        'picChar_from
        '
        Me.picChar_from.Location = New System.Drawing.Point(12, 50)
        Me.picChar_from.Name = "picChar_from"
        Me.picChar_from.Size = New System.Drawing.Size(132, 158)
        Me.picChar_from.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.picChar_from.TabIndex = 1
        Me.picChar_from.TabStop = False
        '
        'picChar_to
        '
        Me.picChar_to.Location = New System.Drawing.Point(355, 52)
        Me.picChar_to.Name = "picChar_to"
        Me.picChar_to.Size = New System.Drawing.Size(132, 158)
        Me.picChar_to.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage
        Me.picChar_to.TabIndex = 2
        Me.picChar_to.TabStop = False
        '
        'lstCharacterFrom
        '
        Me.lstCharacterFrom.FormattingEnabled = True
        Me.lstCharacterFrom.Location = New System.Drawing.Point(150, 50)
        Me.lstCharacterFrom.Name = "lstCharacterFrom"
        Me.lstCharacterFrom.Size = New System.Drawing.Size(175, 160)
        Me.lstCharacterFrom.TabIndex = 3
        '
        'lstCharacterTo
        '
        Me.lstCharacterTo.FormattingEnabled = True
        Me.lstCharacterTo.Location = New System.Drawing.Point(493, 52)
        Me.lstCharacterTo.Name = "lstCharacterTo"
        Me.lstCharacterTo.Size = New System.Drawing.Size(175, 160)
        Me.lstCharacterTo.TabIndex = 4
        '
        'btnCopy
        '
        Me.btnCopy.Location = New System.Drawing.Point(674, 106)
        Me.btnCopy.Name = "btnCopy"
        Me.btnCopy.Size = New System.Drawing.Size(75, 59)
        Me.btnCopy.TabIndex = 5
        Me.btnCopy.Text = "Copy"
        Me.btnCopy.UseVisualStyleBackColor = True
        '
        'lblFrom
        '
        Me.lblFrom.AutoSize = True
        Me.lblFrom.Location = New System.Drawing.Point(12, 50)
        Me.lblFrom.Name = "lblFrom"
        Me.lblFrom.Size = New System.Drawing.Size(92, 13)
        Me.lblFrom.TabIndex = 6
        Me.lblFrom.Text = "Overview Source:"
        '
        'lblTo
        '
        Me.lblTo.AutoSize = True
        Me.lblTo.Location = New System.Drawing.Point(352, 52)
        Me.lblTo.Name = "lblTo"
        Me.lblTo.Size = New System.Drawing.Size(111, 13)
        Me.lblTo.TabIndex = 7
        Me.lblTo.Text = "Overview Destination:"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(12, 34)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(274, 13)
        Me.Label1.TabIndex = 8
        Me.Label1.Text = "Copies your Overview from one to another CHARACTER"
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(757, 229)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.lblTo)
        Me.Controls.Add(Me.lblFrom)
        Me.Controls.Add(Me.btnCopy)
        Me.Controls.Add(Me.lstCharacterTo)
        Me.Controls.Add(Me.lstCharacterFrom)
        Me.Controls.Add(Me.picChar_to)
        Me.Controls.Add(Me.picChar_from)
        Me.Controls.Add(Me.MenuStrip1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MainMenuStrip = Me.MenuStrip1
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.Text = "EVErview"
        Me.MenuStrip1.ResumeLayout(False)
        Me.MenuStrip1.PerformLayout()
        CType(Me.picChar_from, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picChar_to, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents MenuStrip1 As MenuStrip
    Friend WithEvents FileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExutToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ImageList1 As ImageList
    Friend WithEvents picChar_from As PictureBox
    Friend WithEvents picChar_to As PictureBox
    Friend WithEvents lstCharacterFrom As ListBox
    Friend WithEvents lstCharacterTo As ListBox
    Friend WithEvents btnCopy As Button
    Friend WithEvents lblFrom As Label
    Friend WithEvents lblTo As Label
    Friend WithEvents BrowseBackupsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents CopyClientSettingsToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ImportSettingsFromFileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents ExportSettingsToFileToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents Label1 As Label
    Friend WithEvents OpenFileDialog1 As OpenFileDialog
    Friend WithEvents FolderBrowserDialog1 As FolderBrowserDialog
End Class
