@echo off 
set WS=%~dp0
set UNITY_PATH="C:\Program Files\Unity\Editor\Unity.exe"
set PROJECT_PATH="%WS%"
set BUILD_LOG_PATH="%WS%build.log"
set DESTINATION_PATH="%WS%build"
del "%WS%build\NumbersFlip.apk"
echo Build Command: %UNITY_PATH% -quit -batchmode -projectPath %PROJECT_PATH% -executeMethod BuildTool.Build -logFile %BUILD_LOG_PATH% -destinationPath %DESTINATION_PATH%
%UNITY_PATH% -quit -batchmode -projectPath %PROJECT_PATH% -executeMethod BuildTool.Build -logFile %BUILD_LOG_PATH% -destinationPath %DESTINATION_PATH%