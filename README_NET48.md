# 🎯 Token.exe - .NET Framework 4.8 版本

## 📦 项目完成

已用 **.NET Framework 4.8** 重新打造 Token.exe

---

## 🎯 为什么选择 .NET Framework 4.8？

- ✅ **最稳定** - 经过十多年验证
- ✅ **兼容性强** - 支持 Windows 7 到最新 Windows 11
- ✅ **部署简单** - 大多数 Windows 系统已预装
- ✅ **性能优异** - 经过多年优化

---

## 📋 源代码

### Program.cs (58 行)
```csharp
static int Main(string[] args)
{
    // 命令行入口
    // 参数解析
    // 帮助文本
}
```

### CSVProcessor.cs (86 行)
```csharp
public void ConvertLastColumnToUUID(Action<string> progressCallback)
{
    // 逐行读取 CSV
    // 分割字段
    // 替换最后一列为 UUID
    // 写入新文件
}
```

### Token.csproj (Project file)
```xml
<TargetFrameworkVersion>v4.8</TargetFrameworkVersion>
<AssemblyName>Token</AssemblyName>
```

---

## 🔨 编译要求

### 安装 .NET Framework 4.8 Developer Pack

```bash
# 下载
https://dotnet.microsoft.com/download/dotnet-framework/net48

# 或使用 Visual Studio 安装程序
# 选择 .NET desktop development workload
```

### 验证安装

```bash
# 检查 MSBuild
where msbuild

# 检查 .NET Framework
reg query "HKLM\SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full" /v Version
```

---

## 🚀 快速编译

### 一键编译

```bash
cd C:\projects
BUILD_NET48.bat
```

### 手动编译

```bash
# Debug 版本
msbuild Token.csproj /p:Configuration=Debug /p:Platform=AnyCPU

# Release 版本
msbuild Token.csproj /p:Configuration=Release /p:Platform=AnyCPU
```

### 或使用 Visual Studio

```bash
# 在 Visual Studio 中打开 Token.csproj
# 右键点击项目 → 生成
```

---

## 📁 编译后的位置

编译成功后，Token.exe 位于：

```
C:\projects\bin\Release\Token.exe
```

---

## 💻 使用方式

### 基本语法

```bash
Token.exe <CSV文件路径>
```

### 例子

```bash
# 相对路径
Token.exe sample_data.csv

# 绝对路径
Token.exe C:\temp\1.csv

# 带空格的路径
Token.exe "C:\Program Files\Data\my file.csv"

# 查看帮助
Token.exe
```

---

## 📊 转换示例

### 输入

```
EMPLOYEE_2,業務部,PRODUCT_2,17.67,8,141.36,2
EMPLOYEE_1,銷售部,PRODUCT_1,25.50,10,255.00,1
EMPLOYEE_3,技術部,PRODUCT_3,42.00,5,210.00,3
```

### 输出（自动生成）

```
EMPLOYEE_2,業務部,PRODUCT_2,17.67,8,141.36,a3f5c9e2-4d7b-11ee-b56f-0242ac110002
EMPLOYEE_1,銷售部,PRODUCT_1,25.50,10,255.00,b1c2d3e4-f5a6-47b8-9c0d-1e2f3a4b5c6d
EMPLOYEE_3,技術部,PRODUCT_3,42.00,5,210.00,c3d4e5f6-a7b8-4e9f-2a0b-3c4d5e6f7a8b
```

**注意**: 最后一列被替换为随机 UUID

---

## ✨ 特色

✅ **命令行工具**  
✅ **参数支持**  
✅ **UUID 转换**  
✅ **进度显示**  
✅ **错误处理**  
✅ **中文支持**  
✅ **文件保护**  
✅ **返回值正确**  

---

## 🎓 全局使用

### 方式 1: 复制到 System32

```bash
copy bin\Release\Token.exe C:\Windows\System32\
```

之后可以全局使用：

```bash
Token.exe your_file.csv
```

### 方式 2: 添加到 PATH

```bash
setx PATH "%PATH%;C:\projects\bin\Release"
```

重新开启命令行后可以使用：

```bash
Token.exe your_file.csv
```

---

## 🔍 故障排查

### 问题：找不到 MSBuild

```
❌ 错误: 找不到 MSBuild
```

**解决**:
1. 安装 Visual Studio 2019 或更新版本
2. 或安装 .NET Framework 4.8 Developer Pack
3. 下载: https://dotnet.microsoft.com/download/dotnet-framework/net48

### 问题：编译失败

```
❌ 编译失败
```

**解决**:
1. 删除 `bin` 和 `obj` 文件夹
2. 检查是否有编译错误信息
3. 重新运行 BUILD_NET48.bat

### 问题：Token.exe 未生成

**解决**: 检查编译输出中是否有错误

---

## 📋 系统要求

| 项目 | 要求 |
|------|------|
| OS | Windows 7 SP1 或更新版本 |
| .NET Framework | 4.8 (编译和运行) |
| Visual Studio | 2019 或更新版本（可选） |
| 磁盘空间 | 50-100 MB |

---

## 📊 代码统计

| 项目 | 数值 |
|------|------|
| 源代码行数 | 144 |
| 文件数 | 2 |
| 项目文件 | 1 |

---

## ✅ 编译检查清单

编译前确认已有：

- ✅ Program.cs
- ✅ CSVProcessor.cs
- ✅ Token.csproj
- ✅ sample_data.csv
- ✅ BUILD_NET48.bat

---

## 🎯 立即开始

```bash
# 进入项目
cd C:\projects

# 编译（一鍵完成）
BUILD_NET48.bat

# 使用
bin\Release\Token.exe sample_data.csv

# 查看结果
type sample_data_UUID.csv
```

完成！ ✨

---

**项目**: Token.exe - CSV UUID 转换器  
**版本**: 1.0 (.NET Framework 4.8)  
**类型**: 命令行工具  
**用法**: `Token.exe <CSV文件路径>`  
**状态**: ✅ 准备编译
