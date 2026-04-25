# 🚀 快速开始 - Token.exe (.NET Framework 4.8)

## 📦 一分钟开始

### 第 1 步：安装 .NET Framework 4.8

如果还没有安装：

```bash
# 下载 .NET Framework 4.8
# https://dotnet.microsoft.com/download/dotnet-framework/net48

# 安装后验证
reg query "HKLM\SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full" /v Version
```

### 第 2 步：编译

```bash
cd C:\projects
BUILD_NET48.bat
```

### 第 3 步：使用

```bash
bin\Release\Token.exe sample_data.csv
```

完成！ 🎉

---

## 📋 使用方式

```bash
Token.exe <CSV文件路径>
```

### 例子

```bash
Token.exe sample_data.csv
Token.exe C:\temp\1.csv
Token.exe "C:\Program Files\data.csv"
Token.exe          # 显示帮助
```

---

## 📊 转换示例

### 输入

```
EMPLOYEE_2,業務部,PRODUCT_2,17.67,8,141.36,2
```

### 输出

```
EMPLOYEE_2,業務部,PRODUCT_2,17.67,8,141.36,a3f5c9e2-4d7b-11ee-b56f-0242ac110002
```

---

## 🎯 编译错误排查

### 找不到 MSBuild？

**解决方案**:

1. 安装 Visual Studio 2019+ 或 Build Tools for Visual Studio
2. 或安装 .NET Framework 4.8 Developer Pack

下载: https://dotnet.microsoft.com/download/dotnet-framework/net48

### 编译失败？

**解决方案**:

```bash
# 删除临时文件
rmdir /s /q bin
rmdir /s /q obj

# 重新编译
BUILD_NET48.bat
```

---

## 📁 编译位置

```
C:\projects\bin\Release\Token.exe
```

---

## ✨ 特色

✅ .NET Framework 4.8  
✅ 支持 Windows 7+  
✅ 命令行工具  
✅ 简单易用  

---

**用法**: `Token.exe <CSV文件>`
