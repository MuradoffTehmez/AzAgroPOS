@echo off
echo Building AzAgroPOS solution...
dotnet build AzAgroPOS.sln
if %errorlevel% neq 0 (
    echo Build failed with error code %errorlevel%
    pause
    exit /b %errorlevel%
)
echo Build completed successfully!
pause