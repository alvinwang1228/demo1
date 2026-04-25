@echo off
REM Token.exe 編譯腳本 - .NET Framework 4.8 版本

setlocal enabledelayedexpansion

echo ============================================================
echo  Token.exe - CSV UUID 轉換器
echo ============================================================
echo  版本: .NET Framework 4.8
echo ============================================================
echo.

cd /d C:\projects

REM 檢查 msbuild
where msbuild > nul 2>&1
if %errorlevel% neq 0 (
    echo ❌ 錯誤: 找不到 MSBuild
    echo.
    echo 請確保已安裝:
    echo - Visual Studio 2019 或更新版本
    echo - 或 .NET Framework 4.8 Developer Pack
    echo.
    echo 下載位置:
    echo https://dotnet.microsoft.com/download/dotnet-framework/net48
    echo.
    pause
    exit /b 1
)

echo ✅ MSBuild 已安裝

echo.
echo 🧹 清理舊編譯...
msbuild Token.csproj /t:Clean > nul 2>&1

echo.
echo 🔨 編譯 Release 版本...
msbuild Token.csproj /p:Configuration=Release /p:Platform=AnyCPU

if %errorlevel% neq 0 (
    echo.
    echo ❌ 編譯失敗
    pause
    exit /b 1
)

echo.
echo ✅ 編譯成功！

REM 檢查 EXE 是否生成
if exist "bin\Release\Token.exe" (
    echo ✅ Token.exe 已生成
    echo    位置: bin\Release\Token.exe
    echo.
    
    echo 🧪 測試運行...
    echo.
    bin\Release\Token.exe sample_data.csv
    echo.
    
    if exist "sample_data_UUID.csv" (
        echo ✅ 轉換成功！
        echo    輸出: sample_data_UUID.csv
        echo.
        echo 📋 預覽:
        type sample_data_UUID.csv | findstr /N "^" | findstr "1: 2:"
    )
) else (
    echo ❌ Token.exe 未找到
    echo    預期位置: bin\Release\Token.exe
)

echo.
echo ============================================================
echo 🎉 完成！
echo ============================================================
echo.
echo 使用方式:
echo   bin\Release\Token.exe sample_data.csv
echo   bin\Release\Token.exe c:\temp\1.csv
echo.
echo 或複製到 System32:
echo   copy bin\Release\Token.exe C:\Windows\System32\
echo   Token.exe your_file.csv
echo.

pause
