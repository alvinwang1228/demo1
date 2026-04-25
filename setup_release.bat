@echo off
REM 創建 Release 目錄
if not exist bin\Release mkdir bin\Release

REM 複製編譯好的 exe 到 Release
echo 設置 Release 版本...
copy bin\Debug\Token.exe bin\Release\Token.exe

REM 驗證
if exist bin\Release\Token.exe (
    echo.
    echo ✅ Token.exe 已準備好！
    echo 位置: bin\Release\Token.exe
    dir bin\Release\Token.exe /S
) else (
    echo ❌ 複製失敗
)

echo.
echo 用法: bin\Release\Token.exe sample_data.csv
