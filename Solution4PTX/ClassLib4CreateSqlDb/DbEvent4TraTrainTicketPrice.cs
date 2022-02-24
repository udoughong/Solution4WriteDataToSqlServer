using ClassLib4Ptx2GetJson;
using ClassLib4PtxDbModel.Tra.Ticket;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClassLib4CreateSqlDb
{
    public class DbEvent4TraTrainTicketPrice : IDbEvent
    {
        public void ImplementCase(string[] columnNameArray, string connectStr, string tableName, string ptxAppId, string ptxAppKey, string ptxAppUri, string ptxApiUri)
        {
            #region 從PTX API取得資料清單
            Class4GetJson event4GetJson = new Class4GetJson();
            List<Class4TraTrainTicketPrice> traTrainTicketPriceObj = event4GetJson.GetListOfTraTrainTicketPrice(ptxAppId, ptxAppKey, ptxAppUri, ptxApiUri);
            #endregion
            foreach (var itemOfTrain in traTrainTicketPriceObj)
            {
                foreach (var itemOfFare in itemOfTrain.Fares)
                {
                    #region 逐筆分析資料
                    List<string> dataArray = new List<string>
                    {
                        "0",
                        itemOfTrain.OriginStationID,
                        itemOfTrain.OriginStationName.Zh_tw,
                        itemOfTrain.DestinationStationID,
                        itemOfTrain.DestinationStationName.Zh_tw,
                        itemOfTrain.Direction.ToString(),
                        itemOfFare.TicketType,
                        itemOfFare.Price.ToString(),
                        itemOfTrain.UpdateTime.ToString()
                    };
                    #endregion
                    #region 逐筆匯入資料到資料表
                    Class4CreateSqlDb event4ImportData = new Class4CreateSqlDb();
                    event4ImportData.InsertData(connectStr, tableName, columnNameArray, dataArray.ToArray());
                    #endregion
                }
                Console.WriteLine("{0}到{1}已更新...", itemOfTrain.OriginStationName.Zh_tw, itemOfTrain.DestinationStationName.Zh_tw);
            }

        }
    }
}


/* 

 */
