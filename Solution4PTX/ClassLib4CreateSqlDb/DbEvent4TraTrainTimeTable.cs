using ClassLib4Ptx2GetJson;
using ClassLib4PtxDbModel.Tra;
using ClassLib4PtxDbModel.Tra.Time;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace ClassLib4CreateSqlDb
{
    public class DbEvent4TraTrainTimeTable : IDbEvent
    {
        public void ImplementCase(string[] columnNameArray, string connectStr, string tableName, string ptxAppId, string ptxAppKey, string ptxAppUri, string ptxApiUri)
        {
            #region 從資料庫中取得車站清單
            Class4CreateSqlDb event4Sql = new Class4CreateSqlDb();
            DataTable tableOfStation = event4Sql.ResultOfReadData(connectStr, "TraTrainStation");
            List<string> traStationObj = new List<string>();
            for (int indexOfStation = 0; indexOfStation < tableOfStation.Rows.Count; indexOfStation++)
            {
                traStationObj.Add(tableOfStation.Rows[indexOfStation]["StationID"].ToString());
            }
            #endregion
            Class4GetJson event4GetJson = new Class4GetJson();
            foreach (var itemOfStation in traStationObj)//依據車站順序
            {
                #region 從PTX API取得資料清單
                string thisStationId = itemOfStation;
                string requestUri4TraTimes = ptxApiUri.Replace("1020", thisStationId).Replace("2022-02-12", event4GetJson.DateStringOfDateAfterToday(1));
                List<Class4TraTrainTimeTable> traTrainTimeTableObj = event4GetJson.GetListOfTraTrainTimeTable(ptxAppId, ptxAppKey, ptxAppUri, requestUri4TraTimes);
                #endregion
                foreach (var item in traTrainTimeTableObj)
                {
                    #region 逐筆分析資料
                    List<string> dataArray = new List<string>
                    {
                        "0",
                        item.ArrivalTime,
                        item.DepartureTime,
                        item.Direction.ToString(),
                        item.EndingStationID,
                        item.EndingStationName.Zh_tw,
                        item.StartingStationID,
                        item.StartingStationName.Zh_tw,
                        item.StationID,
                        item.StationName.Zh_tw,
                        item.TrainDate,
                        item.TrainNo,
                        item.TrainTypeCode,
                        item.TrainTypeID,
                        item.TrainTypeName.Zh_tw,
                        item.TripLine.ToString(),
                        item.UpdateTime.ToString()
                    };
                    #endregion
                    #region 逐筆匯入資料到資料表
                    Class4CreateSqlDb event4ImportData = new Class4CreateSqlDb();
                    event4ImportData.InsertData(connectStr, tableName, columnNameArray, dataArray.ToArray());
                    #endregion
                }
                Console.WriteLine("{0}已更新...", thisStationId);
            }
        }
    }
}