Imports System.IO.Compression
Imports Newtonsoft.Json

Public Class Form1

	Public Shared SharedCacheDir As String = ""
	Public Shared BackupDir As String = "C:\temp\EVErview\"

	Private Sub ExutToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExutToolStripMenuItem.Click
		Me.Close()
	End Sub

	Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

		SharedCacheDir = GetSharedCacheDir()
		If Not SharedCacheDir = "" Then
			GetCharacterNames(SharedCacheDir)
		Else
			btnCopy.Enabled = False
			ImportSettingsFromFileToolStripMenuItem.Enabled = False
			ExportSettingsToFileToolStripMenuItem.Enabled = False
			CopyClientSettingsToolStripMenuItem.Enabled = False
			MsgBox("Can't find shared Cache-Directory")
		End If
	End Sub

	Private Function GetSharedCacheDir() As String
		'Searching for the SharedCache Directory to find the Overview-Files

		Dim CacheDir As String = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData) & "\CCP" & "\EVE"
		For Each folder In My.Computer.FileSystem.GetDirectories(CacheDir)
			If folder.Contains("tranquility") Then
				Return folder & "\settings_Default"
			End If
		Next
		Return ""

	End Function

	Private Sub GetCharacterNames(ByVal SharedCacheDir)
		'Get the CharacterNames, retrieved from the UserID in the Overview-Files
		Dim list As List(Of KeyValuePair(Of String, String)) = New List(Of KeyValuePair(Of String, String))
		Dim list2 As List(Of KeyValuePair(Of String, String)) = New List(Of KeyValuePair(Of String, String))

		For Each file In IO.Directory.GetFiles(SharedCacheDir)
			Dim charID = IO.Path.GetFileName(file)

			If charID.Contains("core_char_") And charID.Length >= 18 Then
				Dim charName = RequestCharName(ReturnID(charID))

				If charName IsNot Nothing Then
					list.Add(New KeyValuePair(Of String, String)(charID, charName))
					list2.Add(New KeyValuePair(Of String, String)(charID, charName))
				End If
			End If
		Next

		lstCharacterFrom.ValueMember = "key"
		lstCharacterFrom.DisplayMember = "value"
		lstCharacterFrom.DataSource = list
		lstCharacterTo.ValueMember = "key"
		lstCharacterTo.DisplayMember = "value"
		lstCharacterTo.DataSource = list2
	End Sub

	Private Function ReturnID(ByVal charID)
		Return charID.Substring(charID.LastIndexOf(Chr(95)) + 1, charID.Length - charID.LastIndexOf(Chr(95)) - 5)
	End Function

	Private Function RequestCharName(ByVal ID)
		Try
			Dim webClient As New Net.WebClient
			Dim jsondata As String = webClient.DownloadString("https://esi.evetech.net/legacy/characters/" & ID & "/?datasource=tranquility")

			Dim result As JSON_result = JsonConvert.DeserializeObject(Of JSON_result)(jsondata)

			If Not result.name = "" Then
				Return result.name
			End If
		Catch ex As Exception
			'webclient cant handle the errorcode from server when an invalid charid is transmitted (422) - therefor using this bad boy here.
			'ToDo: Maybe, some day, using httpwebrequest
		End Try
		Return Nothing
	End Function

	Private Function RequestPortrait(ByVal ID) As IO.MemoryStream
		Dim webClient As New Net.WebClient
		Dim ImageInBytes() As Byte = webClient.DownloadData("http://image.eveonline.com/Character/" & ID & "_128.jpg")
		Dim ImageStream As New IO.MemoryStream(ImageInBytes)
		Return ImageStream
	End Function

	Private Sub CreateBackup()
		'Create a Backup from the SharedCache Directory, save in a new folder
		Dim timestamp As String = DateTime.Now.ToString("dd_MM_yyyy_HH-mm-ss")
		My.Computer.FileSystem.CopyDirectory(SharedCacheDir, BackupDir & timestamp)
	End Sub

	Private Sub RenameOverview()
		'Creating Backup before renaming files
		CreateBackup()

		If lstCharacterFrom.SelectedValue = lstCharacterTo.SelectedValue Then
			MsgBox("Error - Can't use the same source/destination.")
		ElseIf MsgBox("Do you really want to copy the overview from file " & lstCharacterFrom.SelectedValue & " to " & lstCharacterTo.SelectedValue & "?" & vbNewLine & vbNewLine & "There will be an backup at " & BackupDir, vbYesNo) = DialogResult.Yes Then
			My.Computer.FileSystem.CopyFile(SharedCacheDir & "\" & lstCharacterFrom.SelectedValue, SharedCacheDir & "\" & lstCharacterTo.SelectedValue, True)
		End If
	End Sub


	Private Sub lstCharacterFrom_SelectedValueChanged(sender As Object, e As EventArgs) Handles lstCharacterFrom.SelectedValueChanged
		If Not lstCharacterFrom.SelectedValue = "" Then
			picChar_from.Image = New Bitmap(RequestPortrait(ReturnID(lstCharacterFrom.SelectedValue)))
		End If

	End Sub

	Private Sub lstCharacterTo_SelectedValueChanged(sender As Object, e As EventArgs) Handles lstCharacterTo.SelectedValueChanged
		If Not lstCharacterTo.SelectedValue = "" Then
			picChar_to.Image = New Bitmap(RequestPortrait(ReturnID(lstCharacterTo.SelectedValue)))
		End If
	End Sub

	Private Sub btnCopy_Click(sender As Object, e As EventArgs) Handles btnCopy.Click
		Dim p() As Process = Process.GetProcessesByName("exefile")
		If p.Count > 0 Then
			MsgBox("Eve-Client is running, close it before copying the overview!")
		Else
			RenameOverview()
		End If
	End Sub

	Private Sub FileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles FileToolStripMenuItem.Click
		If IO.Directory.Exists(BackupDir) Then
			BrowseBackupsToolStripMenuItem.Enabled = True
		Else
			BrowseBackupsToolStripMenuItem.Enabled = False
		End If
	End Sub

	Private Sub BrowseBackupsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles BrowseBackupsToolStripMenuItem.Click
		If IO.Directory.Exists(BackupDir) Then
			Dim p As New Process
			p.Start(BackupDir)
		End If
	End Sub

	Private Sub CopyClientSettingsToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles CopyClientSettingsToolStripMenuItem.Click
		Me.Hide()
		Form2.Show()
	End Sub

	Private Sub ExportSettingsToFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ExportSettingsToFileToolStripMenuItem.Click

		FolderBrowserDialog1.RootFolder = Environment.SpecialFolder.MyComputer
		If FolderBrowserDialog1.ShowDialog() = DialogResult.OK Then
			Dim timestamp As String = DateTime.Now.ToString("dd_MM_yyyy_HH-mm-ss")
			ZipFile.CreateFromDirectory(SharedCacheDir, FolderBrowserDialog1.SelectedPath & "\Backup_" & timestamp & ".everview")
		End If

	End Sub

	Private Sub ImportSettingsFromFileToolStripMenuItem_Click(sender As Object, e As EventArgs) Handles ImportSettingsFromFileToolStripMenuItem.Click
		'Backup before doing stuff
		CreateBackup()

		Dim temp As String = "C:\temp\everviewtemp"

		OpenFileDialog1.FileName = "*.everview"
		OpenFileDialog1.Filter = "EVErview Backuparchive (*.everview) |"
		OpenFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop)

		If OpenFileDialog1.ShowDialog = DialogResult.OK Then
			If My.Computer.FileSystem.DirectoryExists(GetSharedCacheDir) Then
				If MsgBox("Importing backup " & OpenFileDialog1.SafeFileName & vbNewLine & vbNewLine & vbNewLine & "(YES) Copies only missing Setting-Files" & vbNewLine & "(NO) Overwrites all duplicate accounts/overviews" & vbNewLine & "(CANCEL) Stops Import - nothing will change", vbYesNoCancel) = DialogResult.Yes Then
					ZipFile.ExtractToDirectory(OpenFileDialog1.FileName, temp)
					Try
						My.Computer.FileSystem.CopyDirectory(temp, SharedCacheDir, False)
					Catch ex As Exception
					End Try

					My.Computer.FileSystem.DeleteDirectory(temp, FileIO.DeleteDirectoryOption.DeleteAllContents)
				ElseIf DialogResult.No Then
					ZipFile.ExtractToDirectory(OpenFileDialog1.FileName, temp)
					My.Computer.FileSystem.CopyDirectory(temp, SharedCacheDir, True)
					My.Computer.FileSystem.DeleteDirectory(temp, FileIO.DeleteDirectoryOption.DeleteAllContents)
				End If
			Else
				MsgBox("Can't find shared Cache-Directory")
			End If
		End If
	End Sub
End Class

Public Class JSON_result
	Public Property alliance_id As Integer
	Public Property ancestry_id As Integer
	Public Property birthday As DateTime
	Public Property bloodline_id As Integer
	Public Property corporation_id As Integer
	Public Property description As String
	Public Property faction_id As Integer
	Public Property gender As String
	Public Property name As String
	Public Property race_id As Integer
	Public Property security_status As Single
End Class