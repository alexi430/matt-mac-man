@echo off 
set UNITY_PATH="C:\Program Files\Unity\Editor\Unity.exe"
set PROJECT_PATH="C:\Users\Alex_YT_Chen\Documents\New Unity Project 3"
set BUILD_LOG_PATH="C:\Users\Alex_YT_Chen\Documents\New Unity Project 3\build.log"
set DESTINATION_PATH="C:\Users\Alex_YT_Chen\Desktop\build"
del "C:\Users\Alex_YT_Chen\Desktop\build\New Unity Project 3.apk"
echo Build Command: %UNITY_PATH% -quit -batchmode -projectPath %PROJECT_PATH% -executeMethod BuildTool.Build -logFile %BUILD_LOG_PATH% -destinationPath %DESTINATION_PATH%
%UNITY_PATH% -quit -batchmode -projectPath %PROJECT_PATH% -executeMethod BuildTool.Build -logFile %BUILD_LOG_PATH% -destinationPath %DESTINATION_PATH%