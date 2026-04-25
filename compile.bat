@echo off
REM 清理
if exist bin\Release rmdir /s /q bin\Release
if exist obj rmdir /s /q obj

REM 編譯 Release
echo 編譯中...
msbuild Token.csproj /p:Configuration=Release /p:Platform=AnyCPU /verbosity:minimal

REM 檢查結果
if exist bin\Release\Token.exe (
    echo.
    echo 成功！Token.exe 已生成
    echo 位置: bin\Release\Token.exe
    dir bin\Release\Token.exe
) else (
    echo.
    echo 編譯失敗！Token.exe 未生成
    echo 請檢查 MSBuild 是否已安裝
)
