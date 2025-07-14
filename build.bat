@echo off
echo Building AzAgroPOS solution in dependency order...

echo Step 1: Building Entities...
dotnet build AzAgroPOS.Entities\AzAgroPOS.Entities.csproj
if %errorlevel% neq 0 (
    echo Entities build failed with error code %errorlevel%
    pause
    exit /b %errorlevel%
)

echo Step 2: Building DAL...
dotnet build AzAgroPOS.DAL\AzAgroPOS.DAL.csproj
if %errorlevel% neq 0 (
    echo DAL build failed with error code %errorlevel%
    pause
    exit /b %errorlevel%
)

echo Step 3: Building BLL...
dotnet build AzAgroPOS.BLL\AzAgroPOS.BLL.csproj
if %errorlevel% neq 0 (
    echo BLL build failed with error code %errorlevel%
    pause
    exit /b %errorlevel%
)

echo Step 4: Building PL...
dotnet build AzAgroPOS.PL\AzAgroPOS.PL.csproj
if %errorlevel% neq 0 (
    echo PL build failed with error code %errorlevel%
    pause
    exit /b %errorlevel%
)

echo All projects built successfully!
pause