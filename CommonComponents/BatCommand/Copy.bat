@echo off

call setting.bat

xcopy %sourcePath% %targetPath% /e /y

echo success
