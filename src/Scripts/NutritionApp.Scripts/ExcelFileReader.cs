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

                        NutritionItem nutritionItem = ConvertToNutritionItem.ConvertRow(headerRow, result.Tables[0].Rows[i]);
                        itemList.Add(nutritionItem);                        
                    }
                    
                    Console.WriteLine(' ');

                    string itemsJson = JsonConvert.SerializeObject(itemList);
                    //foreach (NutritionItem item in itemList)
                    //{
                    //    Console.WriteLine(item.ToString());
                    //}

                    string categoriesJson = JsonConvert.SerializeObject(ConvertToNutritionItem.ItemCategories);
                    foreach (NutritionItemCategorie item in ConvertToNutritionItem.ItemCategories)
                    {
                        Console.WriteLine($"ID: {item.ID}  {item.Name}  ITEMS: {item.ListOfNutritionItemIDs.Count}" );

                        if (item.ListOfSubCategories.Count == 0)
                        {
                            foreach (var nutriID in item.ListOfNutritionItemIDs)
                            {
                                Console.WriteLine($" - ID: {nutriID}");
                            }
                        }

                        foreach (var sub_item in item.ListOfSubCategories)
                        {
                            Console.WriteLine($"    ID: {sub_item.ID}  {sub_item.Name}");
                            foreach (var nutriID in sub_item.ListOfNutritionItemIDs)
                            {
                                Console.WriteLine($"     - ID: {nutriID}");
                            }
                        }
                    }

                    var dbPath = @"D:\NutritionApp\src\Core\NutritionApp.Core\Database\db.txt";
                    // Create the file, or overwrite if the file exists.
                    using (FileStream fs = File.Create(dbPath))
                    {
                        //byte[] semi = new UTF8Encoding(true).GetBytes("{");
                        //fs.Write(semi, 0, semi.Length);

                        byte[] info = new UTF8Encoding(true).GetBytes(itemsJson);
                        // Add some information to the file.
                        fs.Write(info, 0, info.Length);

                        byte[] semi = new UTF8Encoding(true).GetBytes(";");
                        fs.Write(semi, 0, semi.Length);

                        byte[] categroies_info = new UTF8Encoding(true).GetBytes(categoriesJson);
                        // Add some information to the file.
                        fs.Write(categroies_info, 0, categroies_info.Length);

                        //semi = new UTF8Encoding(true).GetBytes("}");
                        //fs.Write(semi, 0, semi.Length);

                    }
                }
            }
        }
    }
}
