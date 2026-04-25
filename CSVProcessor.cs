using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

// CSVProcessor.cs
// 負責讀取 CSV 檔案、將最後一欄替換為隨機 UUID，並將結果寫入新的輸出檔案。
// 輸入與輸出檔案均使用 Big5 編碼（繁體中文環境）。

namespace TokenCSVConverter
{
    /// <summary>
    /// CSV 檔案處理器。
    /// 提供將 CSV 最後一欄轉換為隨機 UUID（Globally Unique Identifier）的功能，
    /// 並將轉換結果輸出至新檔案，原始檔案保持不變。
    /// </summary>
    public class CSVProcessor
    {
        /// <summary>
        /// 取得或設定輸入 CSV 檔案的完整路徑。
        /// </summary>
        public string InputFilePath { get; set; }

        /// <summary>
        /// 取得或設定輸出 CSV 檔案的完整路徑。
        /// 輸出檔名為原始檔名加上 <c>_TOKEN</c> 後綴，副檔名不變。
        /// </summary>
        public string OutputFilePath { get; set; }

        /// <summary>
        /// 初始化 <see cref="CSVProcessor"/> 並依據輸入檔案路徑自動決定輸出檔案路徑。
        /// </summary>
        /// <param name="inputFile">欲處理的 CSV 檔案完整路徑。</param>
        public CSVProcessor(string inputFile)
        {
            InputFilePath = inputFile;

            // 輸出檔案與輸入檔案放在同一目錄下，檔名後綴加上 _TOKEN
            OutputFilePath = Path.Combine(
                Path.GetDirectoryName(inputFile),
                Path.GetFileNameWithoutExtension(inputFile) + "_TOKEN" + Path.GetExtension(inputFile)
            );
        }

        /// <summary>
        /// 讀取輸入 CSV 檔案，將每一行（非空白行）最後一欄替換為隨機 UUID，
        /// 並將所有處理後的行寫入輸出 CSV 檔案。
        /// </summary>
        /// <param name="progressCallback">
        /// 進度回呼委派，每處理完一行即呼叫一次，傳入描述目前進度的字串。
        /// 可傳入 <c>null</c> 以略過進度回報。
        /// </param>
        /// <exception cref="FileNotFoundException">
        /// 當 <see cref="InputFilePath"/> 所指定的檔案不存在時擲回。
        /// </exception>
        public void ConvertLastColumnToUUID(Action<string> progressCallback)
        {
            // 確認輸入檔案存在，否則提早擲出例外
            if (!File.Exists(InputFilePath))
                throw new FileNotFoundException(string.Format("文件不存在: {0}", InputFilePath));

            // 使用 Big5 編碼讀取，以支援繁體中文內容
            Encoding big5 = Encoding.GetEncoding("Big5");
            List<string> processedLines = new List<string>();
            int totalLines = 0;
            int processedCount = 0;

            // 第一次掃描：計算檔案總行數，供進度顯示使用
            using (StreamReader reader = new StreamReader(InputFilePath, big5, true))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    totalLines++;
                }
            }

            // 第二次掃描：逐行讀取並處理
            using (StreamReader reader = new StreamReader(InputFilePath, big5, true))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                {
                    processedCount++;
                    
                    // 空白行直接保留，不進行任何轉換
                    if (string.IsNullOrWhiteSpace(line))
                    {
                        processedLines.Add(line);
                        continue;
                    }

                    // 分割行，使用逗號作為分隔符
                    string[] fields = line.Split(',');

                    if (fields.Length > 0)
                    {
                        // 將最後一欄替換為新產生的 UUID
                        fields[fields.Length - 1] = Guid.NewGuid().ToString();
                        
                        // 重新組合各欄位，以逗號串接後加入處理清單
                        string newLine = string.Join(",", fields);
                        processedLines.Add(newLine);
                    }
                    else
                    {
                        // 無法分割的行（理論上不會發生）原樣保留
                        processedLines.Add(line);
                    }

                    // 透過回呼回報目前的處理進度
                    if (progressCallback != null)
                    {
                        progressCallback(string.Format("處理進度: {0}/{1}", processedCount, totalLines));
                    }
                }
            }

            // 將所有處理完畢的行寫入輸出檔案，採用 Big5 編碼
            using (StreamWriter writer = new StreamWriter(OutputFilePath, false, big5))
            {
                foreach (string outputLine in processedLines)
                {
                    writer.WriteLine(outputLine);
                }
            }
            
            // 全部處理完成後，透過回呼回報最終統計資訊
            if (progressCallback != null)
            {
                progressCallback(string.Format("完成！已將 {0} 行的最後一欄轉換為 TOKEN", processedCount));
            }
        }

        /// <summary>
        /// 計算並回傳輸入 CSV 檔案的總行數。
        /// </summary>
        /// <returns>檔案中的總行數（包含空白行）。</returns>
        public int GetTotalLines()
        {
            int count = 0;
            Encoding big5 = Encoding.GetEncoding("Big5");

            // 逐行讀取並累計行數
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
