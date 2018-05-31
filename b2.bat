@ECHO OFF
SET WS=%~dp0
SET UNITY="C:\Program Files\Unity2017\Editor\Unity.exe"
SET PROJECT="%WS%"
SET RESULT="%WS%result.xml" 
ECHO %UNITY% -batchmode -runTests -projectPath %PROJECT% -testResults %RESULT% -testPlatform editmode
ECHO %UNITY% -batchmode -runTests xyz b2 -projectPath %PROJECT% -testResults %RESULT% -testPlatform editmode
%UNITY% -batchmode -runTests -projectPath %PROJECT% -testResults %RESULT% -testPlatform editmode