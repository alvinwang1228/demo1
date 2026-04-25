import os
import shutil
from pathlib import Path

# Create Release directory
release_dir = Path('C:\\projects\\bin\\Release')
release_dir.mkdir(parents=True, exist_ok=True)

# Copy exe
src = Path('C:\\projects\\bin\\Debug\\Token.exe')
dst = release_dir / 'Token.exe'

if src.exists():
    shutil.copy2(src, dst)
    print("✅ Token.exe copied to bin\\Release\\")
    print(f"   Size: {dst.stat().st_size:,} bytes")
    print(f"   Location: {dst}")
else:
    print("❌ Source file not found")
