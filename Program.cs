using System;
using System.IO;

// Token.exe - CSV UUID 轉換器
// 功能：將 CSV 檔案最後一欄的數值替換為隨機產生的 UUID（TOKEN）
// 平台：.NET Framework 4.8
// 編碼：Big5（繁體中文）

namespace TokenCSVConverter
{
    /// <summary>
    /// 程式進入點類別。
    /// 負責解析命令列引數、驗證輸入檔案，並協調 CSV 處理流程。
    /// </summary>
    class Program
    {
        /// <summary>
        /// 程式主要進入點。
        /// </summary>
        /// <param name="args">
        /// 命令列引數陣列。
        /// args[0]：欲處理的 CSV 檔案路徑（必要）。
        /// </param>
        /// <returns>
        /// 0：執行成功。
        /// 1：發生錯誤，可能原因為引數不足、檔案不存在或執行時期例外。
        /// </returns>
        static int Main(string[] args)
        {
            // 設定主控台輸出編碼為 Big5，以正確顯示繁體中文字元
            Console.OutputEncoding = System.Text.Encoding.GetEncoding("Big5");

            // 若未提供任何引數，顯示使用說明後結束
            if (args.Length == 0)
            {
                ShowUsage();
                return 1;
            }

            // 取得第一個引數作為輸入 CSV 檔案路徑
            string inputFile = args[0];

            // 確認指定的檔案存在；若不存在則輸出錯誤訊息並結束
            if (!File.Exists(inputFile))
            {
                Console.Error.WriteLine("❌ 錯誤: 找不到檔案 '{0}'", inputFile);
                return 1;
            }

            try
            {
                Console.WriteLine("輸入檔案: {0}", inputFile);
                Console.WriteLine("開始轉換...\n");

                // 建立 CSVProcessor 並執行轉換，透過回呼輸出處理進度
                CSVProcessor processor = new CSVProcessor(inputFile);
                processor.ConvertLastColumnToUUID(progress =>
                {
                    Console.WriteLine(progress);
                });

                // 計算輸出檔案路徑（與輸入檔案同目錄，檔名加上 _TOKEN 後綴）
                string outputFile = Path.Combine(
                    Path.GetDirectoryName(inputFile),
                    Path.GetFileNameWithoutExtension(inputFile) + "_TOKEN" + Path.GetExtension(inputFile)
                );

                Console.WriteLine("\n轉換完成!");
                Console.WriteLine("輸出檔案: {0}", outputFile);
                
                return 0;
            }
            catch (Exception ex)
            {
                // 捕捉並顯示非預期的執行時期錯誤
                Console.Error.WriteLine("❌ 錯誤: {0}", ex.Message);
                return 1;
            }
        }

        /// <summary>
        /// 在主控台輸出程式的使用說明，包含用法、參數及範例。
        /// 當使用者未提供命令列引數時自動呼叫。
        /// </summary>
        static void ShowUsage()
        {
            Console.WriteLine("╔════════════════════════════════════════════════════════════╗");
            Console.WriteLine("║              Token.exe - CSV UUID 轉換器                    ║");
            Console.WriteLine("║                                                            ║");
            Console.WriteLine("║              .NET Framework 4.8 版本                       ║");
            Console.WriteLine("╚════════════════════════════════════════════════════════════╝");
            Console.WriteLine();
            Console.WriteLine("用法:");
            Console.WriteLine("  Token.exe <CSV檔案路徑>");
            Console.WriteLine();
            Console.WriteLine("參數:");
            Console.WriteLine("  <CSV檔案路徑>  - CSV 檔案的完整路徑或相對路徑");
            Console.WriteLine();
            Console.WriteLine("範例:");
            Console.WriteLine("  Token.exe sample_data.csv");
            Console.WriteLine("  Token.exe c:\\temp\\1.csv");
            Console.WriteLine("  Token.exe \"C:\\Program Files\\data.csv\"");
            Console.WriteLine();
            Console.WriteLine("說明:");
            Console.WriteLine("  • 讀取 CSV 檔案的最後一欄");
            Console.WriteLine("  • 轉換為隨機 UUID");
            Console.WriteLine("  • 輸出到 *_UUID.csv 檔案");
            Console.WriteLine("  • 原檔案保持不變");
            Console.WriteLine();
            Console.WriteLine("範例檔案格式:");
            Console.WriteLine("  輸入:  EMPLOYEE_2,業務部,PRODUCT_2,17.67,8,141.36,2");
            Console.WriteLine("  輸出:  EMPLOYEE_2,業務部,PRODUCT_2,17.67,8,141.36,a3f5c9e2-4d7b-11ee-b56f-0242ac110002");
            Console.WriteLine();
        }
    }
}
