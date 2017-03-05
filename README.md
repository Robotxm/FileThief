# FileThief
A tool which allows you to copy file from removable media silently

# How to config
When you first run FileThief, it will create a configuration file named 'config.ini' in you application path with the default value.
You can edit the file as you want. But remember to restart FileThief to take effect. See 'Control FileThief' section.

##'File Type' Section
###Type
Define which type of files should be copied. 

Each type is separated with |. And...specific the type WITHOUT dot '.'

**Default value:** rar|zip|7z|doc|docx.

**Meaning:** rar, zip, 7z, doc and docx files.
###Size
File whose size is smaller than the specific value will be copied.
The unit is KB. 1MB = 1024KB, 1GB = 1024MB.

**Default value:** 10240

**Meaning:** File whose size is smaller  than 10 MB will be copied.
###Path
Define where to save the file.
Leaving blank means saving to the default location. Default path is %ApplictionPath%\Files (e.g. F:\FileThief\Files)

**Default value:** *BLANK*

**Meaning:** Files will be saved to %ApplictionPath%\Files (e.g. F:\FileThief\Files)
###VolumeLabel
Set the volume label of USB Driver which you want to copy file from.
Leaving blank means copying from all of USB Drivers.

**Default value:***BLANK*

**Meaning:** Copy from all of USB Drivers.

#Control FileThief
Because there isn't a UI, so everthing is processed in silent.
If you change the configuration, you need to use Task Manager(taskmgr.exe) to kill the process and then restart it.
Or just type **taskkill /im FileThief.exe /f**.

# Requirements
You must install .NET Framwork 3.5 before using FileThief. Luckily, Windows 7 has already contains it.
