using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TokenCSVConverter
{
    public class CSVProcessor
    {
        public string InputFilePath { get; set; }
        public string OutputFilePath { get; set; }

        public CSVProcessor(string inputFile)
        {
            InputFilePath = inputFile;
            OutputFilePath = Path.Combine(
                Path.GetDirectoryName(inputFile),
                Path.GetFileNameWithoutExtension(inputFile) + "_TOKEN" + Path.GetExtension(inputFile)
            );
        }

        public void ConvertLastColumnToUUID(Action<string> progressCallback)
        {
            if (!File.Exists(InputFilePath))
                throw new FileNotFoundException(string.Format("文件不存在: {0}", InputFilePath));

            Encoding big5 = Encoding.GetEncoding("Big5");
            List<string> processedLines = new List<string>();
            int totalLines = 0;
            int processedCount = 0;

            // 先計算總行數
            using (StreamReader reader = new StreamReader(InputFilePath, big5, true))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    totalLines++;
                }
            }

            // 處理每一行
            using (StreamReader reader = new StreamReader(InputFilePath, big5, true))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    processedCount++;
                    
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        processedLines.Add(line);
                        continue;
                    }

                    // 分割行，使用逗號作為分隔符
                    string[] fields = line.Split(',');

                    if (fields.Length > 0)
                    {
                        // 將最後一欄替換為 UUID
                        fields[fields.Length - 1] = Guid.NewGuid().ToString();
                        
                        // 重新組合行
                        string newLine = string.Join(",", fields);
                        processedLines.Add(newLine);
                    }
                    else
                    {
                        processedLines.Add(line);
                    }

                    // 回調進度
                    if (progressCallback != null)
                    {
                        progressCallback(string.Format("處理進度: {0}/{1}", processedCount, totalLines));
                    }
                }
            }

            // 寫入輸出文件，使用 Big5 编码并添加 BOM
            using (StreamWriter writer = new StreamWriter(OutputFilePath, false, big5))
            {
                foreach (string outputLine in processedLines)
                {
                    writer.WriteLine(outputLine);
                }
            }
            
            if (progressCallback != null)
            {
                progressCallback(string.Format("完成！已將 {0} 行的最後一欄轉換為 TOKEN", processedCount));
            }
        }

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
