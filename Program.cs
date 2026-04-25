using System;
using System.IO;

namespace TokenCSVConverter
{
    class Program
    {
        static int Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.GetEncoding("Big5");

            if (args.Length == 0)
            {
                ShowUsage();
                return 1;
            }

            string inputFile = args[0];

            if (!File.Exists(inputFile))
            {
                Console.Error.WriteLine("❌ 錯誤: 找不到檔案 '{0}'", inputFile);
                return 1;
            }

            try
            {
                Console.WriteLine("輸入檔案: {0}", inputFile);
                Console.WriteLine("開始轉換...\n");

                CSVProcessor processor = new CSVProcessor(inputFile);
                processor.ConvertLastColumnToUUID(progress =>
                {
                    Console.WriteLine(progress);
                });

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
                Console.Error.WriteLine("❌ 錯誤: {0}", ex.Message);
                return 1;
            }
        }

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
