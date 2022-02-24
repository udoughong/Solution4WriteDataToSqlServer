using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace ClassLib4CreateSqlDb
{
    public class Class4CreateSqlDb
    {
        #region (v)新增資料庫
        public void CreateDatabase(string connectStr, string dbNameStr, string driveStr)
        {
            SqlConnection Connection4Db = new SqlConnection(connectStr);

            string str4Db = "CREATE DATABASE " + dbNameStr + " ON PRIMARY (NAME = " + dbNameStr + "_Data, FILENAME = '" + driveStr + @"\" + dbNameStr + "Data.mdf', SIZE = 2MB, MAXSIZE = 10MB, FILEGROWTH = 10%) LOG ON (NAME = " + dbNameStr + "_Log, FILENAME = '" + driveStr + @"\" + dbNameStr + "Log.ldf', SIZE = 1MB, MAXSIZE = 5MB, FILEGROWTH = 10%)";

            Connection4Db.Open();
            SqlCommand Command4DB = new SqlCommand(str4Db, Connection4Db);
            try
            {
                Command4DB.ExecuteNonQuery();
                Console.WriteLine("DataBase is Created Successfully");
            }
            catch (System.Exception)
            {
                Console.WriteLine("DataBase is Exist...");
            }
            finally
            {
                if (Connection4Db.State == ConnectionState.Open)
                {
                    Connection4Db.Close();
                }
            }
        }
        #endregion

        #region (v)新增資料表
        public void CreateDataTable(string connectStr, string tableName, string[] theFirstField, string[] theContentFields, string[] theContentTypes, string[] theContentNulls)
        {
            SqlConnection Connection4DbTable = new SqlConnection(connectStr);

            string str4DbTable = "CREATE TABLE [dbo].[" + tableName + "](" + theFirstField[0] + " INT NOT NULL PRIMARY KEY, ";
            for (int i = 0; i < theContentFields.Length; i++)
            {
                string stringOfNull;
                if (bool.Parse(theContentNulls[i]) == true)
                {
                    stringOfNull = "NULL";
                }
                else
                {
                    stringOfNull = "NOT NULL";
                }
                str4DbTable += "[" + theContentFields[i] + "] " + theContentTypes[i] + " " + stringOfNull;
                if (i < (theContentFields.Length - 1))
                    str4DbTable += ",";
                else
                    str4DbTable += ")";
            }

            Connection4DbTable.Open();
            SqlCommand Command4Table = new SqlCommand(str4DbTable, Connection4DbTable);
            try
            {
                Command4Table.ExecuteNonQuery();
                Console.WriteLine("Data Table is Created Successfully");
            }
            catch (System.Exception)
            {
                Console.WriteLine("DataTable is Exist...");
            }
            finally
            {
                if (Connection4DbTable.State == ConnectionState.Open)
                {
                    Connection4DbTable.Close();
                }
            }
        }
        #endregion

        #region (v)整合資料表欄位
        public string[] GetRealArray(string[] theTableFieldList, string[] columnNames)
        {
            string[] theArray = new string[theTableFieldList.Length + columnNames.Length];

            Array.Copy(theTableFieldList, theArray, theTableFieldList.Length);
            Array.Copy(columnNames, 0, theArray, theTableFieldList.Length, columnNames.Length);

            return theArray;
        }
        #endregion

        #region 利用「策略模式」新增資料到資料庫
        public void InsertDataByStrategyPatterm(int i, string[] newArray, string connectStr, string tableName, string ptxAppId, string ptxAppKey, string ptxAppUri, string ptxApiUri)
        {
            Context.ImplementCase(i, newArray, connectStr, tableName, ptxAppId, ptxAppKey, ptxAppUri, ptxApiUri);
        }
        #endregion

        #region (v)傳回新增的資料列數目
        /// <summary>
        /// 傳回新增的資料列數目
        /// </summary>
        /// <param name="connectStr">資料庫的連接字串</param>
        /// <param name="nameOfTable">資料表名稱</param>
        /// <param name="dataFieldList">資料欄位清單</param>
        /// <param name="dataList">資料清單</param>
        /// <returns>傳回受影響的資料列數目</returns>
        public int InsertData(string connectStr, string nameOfTable, string[] dataFieldList, string[] dataList)
        {
            SqlConnection cnn = new SqlConnection(connectStr);
            cnn.Open();
            int CountOfRow = 0;
            SqlCommand cmdOriginal = new SqlCommand("select * from " + nameOfTable, cnn);
            SqlDataReader dr = cmdOriginal.ExecuteReader();
            while (dr.Read())
            {
                CountOfRow++;
            }
            dr.Close();
            cmdOriginal.Cancel();

            int IndexOfNewRow = CountOfRow + 1;

            string query = "Insert into " + nameOfTable + " (";
            for (int i = 0; i < dataFieldList.Length; i++)
            {
                query += dataFieldList[i];
                if (i == dataFieldList.Length - 1)
                {
                    query += ") values(";
                }
                else
                {
                    query += ",";
                }
            }
            for (int i = 0; i < dataFieldList.Length; i++)
            {
                query = query + "@" + dataFieldList[i];
                if (i == dataFieldList.Length - 1)
                {
                    query += ")";
                }
                else
                {
                    query += ", ";
                }
            }
            SqlCommand cmd = new SqlCommand(query, cnn);
            cmd.Parameters.AddWithValue("@" + dataFieldList[0], IndexOfNewRow.ToString());
            for (int i = 1; i < dataFieldList.Length; i++)
            {
                if (dataList[i] == null || dataList[i] == "")
                {
                    dataList[i] = "無資料";
                }
                cmd.Parameters.AddWithValue("@" + dataFieldList[i].ToString(), dataList[i]);
            }

            int valueOfFinishRow = cmd.ExecuteNonQuery();

            cmd.Cancel();
            cnn.Close();

            return valueOfFinishRow;
        }
        #endregion

        #region (v)讀取檔案       
        public string ReadJsonString(string fileOfSetting)
        {
            string stringOfJson = "";
            string lineOfRead;
            StreamReader srOfRead = new StreamReader(fileOfSetting);
            try
            {
                lineOfRead = srOfRead.ReadLine();
                while (lineOfRead != null)
                {
                    stringOfJson += lineOfRead;
                    lineOfRead = srOfRead.ReadLine();
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                srOfRead.Close();
            }
            return stringOfJson;
        }
        #endregion

        #region (v)寫入檔案
        public void WriteFile(string fileOfSetting, string fileOfSetting4Dev)
        {
            string lineOfWrite;
            StreamWriter swOfWrite = new StreamWriter(fileOfSetting);
            StreamReader srOfWrite = new StreamReader(fileOfSetting4Dev);
            try
            {
                lineOfWrite = srOfWrite.ReadLine();
                while (lineOfWrite != null)
                {
                    swOfWrite.WriteLine(lineOfWrite);
                    lineOfWrite = srOfWrite.ReadLine();
                }
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                swOfWrite.Close();
                srOfWrite.Close();
            }
        }
        #endregion

        #region (v)從SQL SERVER讀取資料到DataTable
        /// <summary>
        /// 從SQL SERVER讀取資料到DataTable
        /// </summary>
        /// <param name="connectStr">資料庫的連接字串</param>
        /// <returns>傳回DataTable</returns>
        public DataTable ResultOfReadData(string connectStr, string tableName)
        {
            SqlConnection cnn = new SqlConnection(connectStr);
            cnn.Open();

            SqlCommand cmd = new SqlCommand("select * from " + tableName, cnn);
            SqlDataReader dr = cmd.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(dr);

            cmd.Cancel();
            dr.Close();
            cnn.Close();

            return dt;
        }
        #endregion

    }
}
