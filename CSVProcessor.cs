using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TokenCSVConverter
{
    // 處理 CSV 轉換用途之類別
    public class CSVProcessor
    {
        public string InputFilePath { get; set; }       // 輸入檔案路徑
        public string OutputFilePath { get; set; }      // 輸出檔案路徑

        // 建構子，初始化輸入/輸出路徑
        public CSVProcessor(string inputFile)
        {
            InputFilePath = inputFile;
            OutputFilePath = Path.Combine(
                Path.GetDirectoryName(inputFile),
                Path.GetFileNameWithoutExtension(inputFile) + "_TOKEN" + Path.GetExtension(inputFile)
            );
        }

        // 將最後一欄轉換成 UUID
        public void ConvertLastColumnToUUID(Action<string> progressCallback)
        {
            if (!File.Exists(InputFilePath))
                throw new FileNotFoundException(string.Format("文件不存在: {0}", InputFilePath));

            Encoding big5 = Encoding.GetEncoding("Big5"); // 使用 Big5 編碼
            List<string> processedLines = new List<string>(); // 暫存處理結果
            int totalLines = 0;
            int processedCount = 0;

            // 先計算總行數，方便後面顯示進度
            using (StreamReader reader = new StreamReader(InputFilePath, big5, true))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    totalLines++;
                }
            }

            // 再重新讀一次檔案並進行逐行處理
            using (StreamReader reader = new StreamReader(InputFilePath, big5, true))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    processedCount++;
                    
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        processedLines.Add(line); // 空行直接加入
                        continue;
                    }

                    // 用逗號切割每行
                    string[] fields = line.Split(',');

                    if (fields.Length > 0)
                    {
                        // 替換最後一欄為 UUID
                        fields[fields.Length - 1] = Guid.NewGuid().ToString();
                        
                        // 合回一列再加進新資料
                        string newLine = string.Join(",", fields);
                        processedLines.Add(newLine);
                    }
                    else
                    {
                        processedLines.Add(line); // 無法切割的狀況直接存原本
                    }

                    // 回報目前進度
                    if (progressCallback != null)
                    {
                        progressCallback(string.Format("處理進度: {0}/{1}", processedCount, totalLines));
                    }
                }
            }

            // 寫出轉換後新檔案，Big5 編碼
            using (StreamWriter writer = new StreamWriter(OutputFilePath, false, big5))
            {
                foreach (string outputLine in processedLines)
                {
                    writer.WriteLine(outputLine);
                }
            }
            
            // 回報完成進度
            if (progressCallback != null)
            {
                progressCallback(string.Format("完成！已將 {0} 行的最後一欄轉換為 TOKEN", processedCount));
            }
        }

        // 計算檔案總行數，輔助用
        public int GetTotalLines()
        {
            int count = 0;
            Encoding big5 = Encoding.GetEncoding("Big5");
            using (StreamReader reader = new StreamReader(InputFilePath, big5, true))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    count++;
                }
            }
            return count;
        }
    }
}
