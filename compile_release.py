#!/usr/bin/env python3
# -*- coding: utf-8 -*-
"""
Token.exe Compiler - .NET Framework 4.8
編譯 Release 版本的 Token.exe
"""

import subprocess
import os
import sys
from pathlib import Path

def run_command(cmd, description):
    """執行命令並顯示結果"""
    print(f"\n🔨 {description}...")
    print(f"   {' '.join(cmd)}")
    print("-" * 70)
    
    try:
        result = subprocess.run(cmd, capture_output=False, text=True)
        return result.returncode == 0
    except Exception as e:
        print(f"❌ Error: {e}")
        return False

def main():
    os.chdir('C:\\projects')
    
    print("=" * 70)
    print("  Token.exe - CSV UUID Converter")
    print("  .NET Framework 4.8 Release Build")
    print("=" * 70)
    
    # 清理
    print("\n🧹 Cleaning old build...")
    for path in ['bin\\Release', 'obj']:
        if os.path.exists(path):
            import shutil
            shutil.rmtree(path)
            print(f"   Removed: {path}")
    
    # 編譯
    cmd = [
        'msbuild',
        'Token.csproj',
        '/p:Configuration=Release',
        '/p:Platform=AnyCPU',
        '/verbosity:minimal'
    ]
    
    if not run_command(cmd, "Building Release"):
        print("\n❌ Compilation failed!")
        return 1
    
    # 檢查 EXE
    exe_path = Path('bin\\Release\\Token.exe')
    if exe_path.exists():
        size = exe_path.stat().st_size
        print(f"\n✅ Token.exe successfully built!")
        print(f"   Path: {exe_path.absolute()}")
        print(f"   Size: {size:,} bytes")
        
        # 顯示檔案資訊
        print("\n" + "=" * 70)
        print("📁 Build Output Files:")
        print("=" * 70)
        for file in Path('bin\\Release').glob('*'):
            if file.is_file():
                size = file.stat().st_size
                print(f"  {file.name:30s} {size:>10,} bytes")
        
        return 0
    else:
        print(f"\n❌ Token.exe not found at: {exe_path}")
        print("\nBuild output folder contents:")
        if Path('bin\\Release').exists():
            for file in Path('bin\\Release').glob('*'):
                print(f"  {file.name}")
        return 1

if __name__ == '__main__':
    sys.exit(main())
