@echo off
cd /d C:\projects

REM Clean existing Release directory
if exist bin\Release (
    echo Cleaning bin\Release directory...
    rmdir /s /q bin\Release
    echo Cleaned.
)

echo.
echo ===================================================
echo Compiling Token.exe - NET Framework 4.8 Release
echo ===================================================
echo.

REM Run msbuild for Release configuration
msbuild Token.csproj /p:Configuration=Release /p:Platform=AnyCPU /v:minimal

echo.
echo ===================================================
echo Build Complete - Verifying Output
echo ===================================================
echo.

REM Check if exe was created
if exist bin\Release\Token.exe (
    echo SUCCESS: Token.exe created successfully
    echo.
    echo File Details:
    dir /s bin\Release\Token.exe
    echo.
    echo File Size and Timestamp:
    powershell -NoProfile -Command "Get-Item 'C:\projects\bin\Release\Token.exe' | Select-Object FullName, Length, LastWriteTime"
) else (
    echo ERROR: Token.exe was not created
    echo.
    echo Checking bin\Release directory contents:
    if exist bin\Release (
        dir bin\Release
    ) else (
        echo bin\Release directory does not exist
    )
)
