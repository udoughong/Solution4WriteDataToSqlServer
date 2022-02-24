using ClassLib4Ptx2GetJson;
using ClassLib4PtxDbModel.Tra;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;

namespace ClassLib4CreateSqlDb
{
    public class DbEvent4TraTrainStation : IDbEvent
    {
        public void ImplementCase(string[] columnNameArray, string connectStr, string tableName, string ptxAppId, string ptxAppKey, string ptxAppUri, string ptxApiUri)
        {
            #region 從PTX API取得資料清單
            Class4GetJson event4GetJson = new Class4GetJson();
            List<Class4TraTrainStation> traStationObj = event4GetJson.GetListOfTraTrainStation(ptxAppId, ptxAppKey, ptxAppUri, ptxApiUri);
            #endregion
            foreach (var item in traStationObj)
            {
                #region 逐筆分析資料
                List<string> dataArray = new List<string>
                {
                    "0",
                    item.LocationCity,
                    item.LocationCityCode,
                    item.LocationTown,
                    item.LocationTownCode,
                    item.OperatorID,
                    item.StationAddress,
                    item.StationClass,
                    item.StationID,
                    item.StationName.Zh_tw,
                    item.StationPhone,
                    item.StationPosition.PositionLon.ToString(),
                    item.StationPosition.PositionLat.ToString(),
                    item.StationPosition.GeoHash,
                    item.StationUID,
                    item.UpdateTime.ToString()
                };
                #endregion
                #region 逐筆匯入資料到資料表
                Class4CreateSqlDb event4ImportData = new Class4CreateSqlDb();
                event4ImportData.InsertData(connectStr, tableName, columnNameArray, dataArray.ToArray());
                #endregion
                Console.WriteLine("{0}已更新...", item.StationName.Zh_tw);
            }
        }
    }
}