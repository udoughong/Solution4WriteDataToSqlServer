using ClassLib4Ptx2GetJson;
using ClassLib4PtxDbModel.Tra.Line;
using System;
using System.Collections.Generic;

namespace ClassLib4CreateSqlDb
{
    public class DbEvent4TraTrainLine : IDbEvent
    {
        public void ImplementCase(string[] columnNameArray, string connectStr, string tableName, string ptxAppId, string ptxAppKey, string ptxAppUri, string ptxApiUri)
        {
            #region 從PTX API取得資料清單
            Class4GetJson event4GetJson = new Class4GetJson();
            List<Class4TraTrainLine> traTrainLineObj = event4GetJson.GetListOfTraTrainLine(ptxAppId, ptxAppKey, ptxAppUri, ptxApiUri);
            #endregion
            foreach (var item in traTrainLineObj)
            {
                #region 逐筆分析資料
                List<string> dataArray = new List<string>
                {
                    "0",
                    item.LineID,
                    item.LineNameZh,
                    item.LineNameEn,
                    item.LineSectionNameZh,
                    item.LineSectionNameEn,
                    item.IsBranch.ToString(),
                    item.UpdateTime.ToString()
                };
                #endregion
                #region 逐筆匯入資料到資料表
                Class4CreateSqlDb event4ImportData = new Class4CreateSqlDb();
                event4ImportData.InsertData(connectStr, tableName, columnNameArray, dataArray.ToArray());
                #endregion
                Console.WriteLine("{0}線已更新...", item.LineSectionNameZh);
            }
        }
    }
}