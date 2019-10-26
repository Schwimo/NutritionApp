using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using ExcelDataReader;
using Newtonsoft.Json;
using NutritionApp.Core.Models.Nutrition;

namespace NutritionApp.Scripts
{
    public class ExcelFileReader
    {
        private string _filePath = @"D:\NutritionApp\scripts\Schweizer-Nährwertdatenbank-V6.1.xlsx";

        public ExcelFileReader()
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);

            using (var stream = File.Open(_filePath, FileMode.Open, FileAccess.Read))
            {
                using (var reader = ExcelReaderFactory.CreateReader(stream))
                {
                    var result = reader.AsDataSet(new ExcelDataSetConfiguration()
                    {
                        ConfigureDataTable = (_) => new ExcelDataTableConfiguration()
                        {
                            UseHeaderRow = true
                        }
                    });

                    IList<NutritionItem> itemList = new List<NutritionItem>();
                    var headerRow = result.Tables[0].Rows[1];

                    for (int i = 2; i < result.Tables[0].Rows.Count; i++)
                    {
                        if ((i % 20) == 0)                        
                        {
                            Console.Write(".");
                        }
                        
                        itemList.Add(ConvertToNutritionItem.ConvertRow(headerRow, result.Tables[0].Rows[i]));
                    }

                    Console.WriteLine(' ');

                    string json = JsonConvert.SerializeObject(itemList);
                    foreach (NutritionItem item in itemList)
                    {
                        Console.WriteLine(item.ToString());
                    }

                    var dbPath = @"D:\NutritionApp\src\Core\NutritionApp.Core\Database\db.json";
                    // Create the file, or overwrite if the file exists.
                    using (FileStream fs = File.Create(dbPath))
                    {
                        byte[] info = new UTF8Encoding(true).GetBytes(json);
                        // Add some information to the file.
                        fs.Write(info, 0, info.Length);
                    }
                }
            }
        }
    }
}
