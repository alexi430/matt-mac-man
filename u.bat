@echo off 
set UNITY_PATH="C:\Program Files\Unity\Editor\Unity.exe"
set PROJECT_PATH="C:\Users\AlexYT\Documents\GitHub\matt-mac-man"
set BUILD_LOG_PATH="C:\Users\AlexYT\Documents\GitHub\matt-mac-man\build.log"
set DESTINATION_PATH="C:\Users\AlexYT\Documents\GitHub\matt-mac-man\build"
del "C:\Users\AlexYT\Documents\GitHub\matt-mac-man\build\NumbersFlip.apk"
echo Build Command: %UNITY_PATH% -quit -batchmode -projectPath %PROJECT_PATH% -executeMethod BuildTool.Build -logFile %BUILD_LOG_PATH% -destinationPath %DESTINATION_PATH%
%UNITY_PATH% -quit -batchmode -projectPath %PROJECT_PATH% -executeMethod BuildTool.Build -logFile %BUILD_LOG_PATH% -destinationPath %DESTINATION_PATH%