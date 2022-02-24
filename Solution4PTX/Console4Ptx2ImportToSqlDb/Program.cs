using ClassLib4CreateSqlDb;
using ClassLib4Ptx2GetJson;
using Newtonsoft.Json.Linq;

using System;
using System.Collections.Generic;
using System.IO;

namespace Console4Ptx2ImportToSqlDb
{
    internal class Program
    {
        static void Main(string[] args)
        {
            if (args is null)
            {
                throw new ArgumentNullException(nameof(args));
            }

            Class4CreateSqlDb theEvent = new();
            string fileOfSetting = Directory.GetCurrentDirectory().ToString() + @"\setting.json";
            string fileOfSetting4Dev = Directory.GetCurrentDirectory().Replace(@"bin\Debug\net5.0", @"") + @"setting.json";
            #region 複製設定檔案
            Console.WriteLine("Start to write...");
            theEvent.WriteFile(fileOfSetting, fileOfSetting4Dev);
            Console.WriteLine("Finish to write...");
            Console.ReadLine();
            #endregion
            #region 讀取設定值
            Console.WriteLine("Start to read...");
            string stringOfJson = theEvent.ReadJsonString(fileOfSetting);
            Console.WriteLine("Click to do next steps...");
            Console.ReadLine();
            #endregion
            #region 分析JSON值
            JObject o = JObject.Parse(stringOfJson);
            string dbName = (string)o["DbName"];
            string connectString = (string)o["ConnectString"];

            List<string> tableList = new();
            foreach (var item in o["Tables"])
            {
                tableList.Add(item.Value<string>());
            }

            List<string> requestUriList = new();
            foreach (var item in o["RequestUri"])
            {
                requestUriList.Add(item.Value<string>());
            }
            #endregion
            #region 新增資料庫
            Console.WriteLine("Click to create db...");

            Console.ReadLine();

            Console.WriteLine("Start to create db...");

            string pathOfDB = Directory.GetCurrentDirectory().ToString();

            theEvent.CreateDatabase(connectString, dbName, pathOfDB);
            #endregion
            Console.WriteLine("Click to create db table...");

            Console.ReadLine();

            Console.WriteLine("Start to create db table...");

            Class4GetJson event4GetJson = new();

            string[] theFirstField = { "id" };
            for (int i = 0; i < tableList.Count; i++)
            {
                #region 新增資料表
                string tableName = tableList[i];

                List<string> contentFieldNames = new();
                List<string> contentFieldTypes = new();
                List<string> contentFieldNulls = new();

                foreach (var item in o[tableList[i]])
                {
                    contentFieldNames.Add((string)item["ContentFieldName"]);
                    contentFieldTypes.Add((string)item["ContentType"]);
                    contentFieldNulls.Add((string)item["IsNull"]);
                }

                theEvent.CreateDataTable(connectString.Replace("master", dbName), tableName, theFirstField, contentFieldNames.ToArray(), contentFieldTypes.ToArray(), contentFieldNulls.ToArray());
                #endregion
                #region 新增資料
                string[] newArray = theEvent.GetRealArray(theFirstField, contentFieldNames.ToArray());
                //利用「策略模式」新增資料到資料庫
                theEvent.InsertDataByStrategyPatterm(i, newArray, connectString.Replace("master", dbName), tableList[i], event4GetJson.appID, event4GetJson.appKey, event4GetJson.baseAddress, requestUriList[i]);
                #endregion
            }

            Console.WriteLine("Finish to create db...");

            Console.ReadLine();
        }
    }
}

