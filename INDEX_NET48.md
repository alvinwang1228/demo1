# 📇 Token.exe - .NET Framework 4.8 版本索引

## 🎯 我应该先看什么？

**推荐阅读顺序：**

1. **START_HERE.txt** ⭐ - 开始这个
2. **QUICKSTART_NET48.md** - 1 分钟快速开始
3. **BUILD_NET48.bat** - 编译脚本
4. **FINAL_SUMMARY_NET48.md** - 完整总结
5. **README_NET48.md** - 详细说明

---

## 📦 项目文件清单

### 核心源代码 (2 个)
```
Program.cs          - 命令行入口 (58 行)
CSVProcessor.cs     - 转换逻辑 (86 行)
```

### 项目配置 (1 个)
```
Token.csproj        - .NET Framework 4.8 项目配置
```

### 编译脚本 (1 个)
```
BUILD_NET48.bat     - 一键编译（推荐） ⭐
```

### 文档 (5 个)
```
START_HERE.txt           - 开始这里 ⭐
FINAL_SUMMARY_NET48.md   - 完整总结
QUICKSTART_NET48.md      - 快速开始
README_NET48.md          - 详细说明
SUMMARY_NET48.txt        - 快速概览
```

### 测试数据 (1 个)
```
sample_data.csv     - 5 行测试数据
```

**总计: 11 个文件**

---

## 🚀 快速开始

### 1. 安装 .NET Framework 4.8

```bash
# 下载
https://dotnet.microsoft.com/download/dotnet-framework/net48

# 验证
reg query "HKLM\SOFTWARE\Microsoft\NET Framework Setup\NDP\v4\Full"
```

### 2. 编译

```bash
cd C:\projects
BUILD_NET48.bat
```

### 3. 使用

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

**输入:**
```
EMPLOYEE_2,業務部,PRODUCT_2,17.67,8,141.36,2
```

**输出:**
```
EMPLOYEE_2,業務部,PRODUCT_2,17.67,8,141.36,a3f5c9e2-4d7b-11ee-b56f-0242ac110002
```

---

## ✨ 特色

✅ .NET Framework 4.8  
✅ 支持 Windows 7+  
✅ 命令行工具  
✅ 一键编译  
✅ 简单易用  

---

## 📁 编译位置

```
C:\projects\bin\Release\Token.exe
```

---

## 🎯 文档导航

| 需求 | 文档 | 时间 |
|------|------|------|
| 快速开始 | START_HERE.txt | 1 分钟 |
| 1 分钟开始 | QUICKSTART_NET48.md | 1 分钟 |
| 完整总结 | FINAL_SUMMARY_NET48.md | 10 分钟 |
| 详细说明 | README_NET48.md | 15 分钟 |
| 快速概览 | SUMMARY_NET48.txt | 5 分钟 |

---

## 🔧 系统要求

| 项目 | 要求 |
|------|------|
| OS | Windows 7 SP1+ |
| .NET Framework | 4.8 |
| Visual Studio | 2019+（可选） |

---

## 🎉 立即开始

```bash
cd C:\projects
BUILD_NET48.bat
```

然后：

```bash
bin\Release\Token.exe sample_data.csv
```

完成！ ✨

---

**项目**: Token.exe - CSV UUID 转换器  
**版本**: 1.0 (.NET Framework 4.8)  
**状态**: ✅ 准备编译
