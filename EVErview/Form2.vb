Imports System.ComponentModel

Public Class Form2
    Private Sub Form2_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        Form1.Show()
    End Sub

    Private Sub btnBrowseSource_Click(sender As Object, e As EventArgs) Handles btnBrowseSource.Click

        OpenFileDialog1.FileName = "core_user_*"
        OpenFileDialog1.Filter = "Client-Settings File (*.dat) |"
        OpenFileDialog1.InitialDirectory = Form1.SharedCacheDir

        If OpenFileDialog1.ShowDialog = DialogResult.OK Then
            txtSource.Text = OpenFileDialog1.FileName
            txtSource.SelectionStart = txtSource.TextLength
        End If

    End Sub

    Private Sub btnBrowseDestination_Click(sender As Object, e As EventArgs) Handles btnBrowseDestination.Click
        OpenFileDialog2.FileName = "core_user*"
        OpenFileDialog2.Filter = "Client-Settings File (*.dat) |"
        OpenFileDialog2.InitialDirectory = Form1.SharedCacheDir

        If OpenFileDialog2.ShowDialog = DialogResult.OK Then
            txtDestination.Text = OpenFileDialog2.FileName
            txtDestination.SelectionStart = txtDestination.TextLength
        End If
    End Sub

    Private Sub RenameOverview()
        CreateBackup()

        If txtSource.Text = txtDestination.Text Then
            MsgBox("Error - Can't use the same source/destination.")
        ElseIf MsgBox("Do you really want to copy the client settings from file " & vbNewLine & vbNewLine & txtSource.Text & vbNewLine & "to " & vbNewLine & txtDestination.Text & vbNewLine & "?" & vbNewLine & vbNewLine & "There will be an backup at " & Form1.BackupDir, vbYesNo) = DialogResult.Yes Then
            My.Computer.FileSystem.CopyFile(txtSource.Text, txtDestination.Text, True)
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

    Private Sub CreateBackup()
        'Create a Backup from the SharedCache Directory, save in a new folder
        Dim timestamp As String = DateTime.Now.ToString("dd_MM_yyyy_HH-mm-ss")
        My.Computer.FileSystem.CopyDirectory(Form1.SharedCacheDir, Form1.BackupDir & timestamp)
    End Sub
End Class