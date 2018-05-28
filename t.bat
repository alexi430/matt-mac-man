@ECHO OFF
SET UNITY="C:\Program Files\Unity2017\Editor\Unity.exe"
SET PROJECT=%~dp0
SET RESULT="%PROJECT%..\results.xml"
%UNITY% -batchmode -runTests -projectPath %PROJECT% -testResults %RESULT% -testPlatform editmode