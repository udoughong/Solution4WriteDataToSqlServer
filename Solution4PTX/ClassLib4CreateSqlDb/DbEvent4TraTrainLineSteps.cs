using ClassLib4Ptx2GetJson;
using ClassLib4PtxDbModel.Tra.Line;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLib4CreateSqlDb
{
    public class DbEvent4TraTrainLineSteps : IDbEvent
    {
        public void ImplementCase(string[] columnNameArray, string connectStr, string tableName, string ptxAppId, string ptxAppKey, string ptxAppUri, string ptxApiUri)
        {
            #region 從PTX API取得資料清單
            Class4GetJson event4GetJson = new Class4GetJson();
            List<Class4TraTrainLineSteps> traTrainLineStepObj = event4GetJson.GetListOfTraTrainLineSteps(ptxAppId, ptxAppKey, ptxAppUri, ptxApiUri);
            #endregion
            foreach (var itemOfLine in traTrainLineStepObj)
            {
                foreach (var itemOfStation in itemOfLine.Stations)
                {
                    #region 逐筆分析資料
                    List<string> dataArray = new List<string>
                    {
                        "0",
                        itemOfLine.LineID,
                        itemOfStation.Sequence.ToString(),
                        itemOfStation.StationID,
                        itemOfStation.StationName,
                        itemOfStation.TraveledDistance.ToString(),
                        itemOfLine.UpdateTime.ToString()
                    };
                    #endregion
                    #region 逐筆匯入資料到資料表
                    Class4CreateSqlDb event4ImportData = new Class4CreateSqlDb();
                    event4ImportData.InsertData(connectStr, tableName, columnNameArray, dataArray.ToArray());
                    #endregion
                }
                Console.WriteLine("{0}線已更新...", itemOfLine.LineID);
            }
        }
    }
}
