@ECHO OFF
SET WS=%~dp0
SET UNITY="C:\Program Files\Unity2017\Editor\Unity.exe"
SET PROJECT="%WS%"
SET RESULT="%WS%result.xml"
%UNITY% -batchmode -runTests -projectPath %PROJECT% -testResults %RESULT% -testPlatform editmode