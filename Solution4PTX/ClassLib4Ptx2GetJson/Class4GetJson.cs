using ClassLib4PtxDbModel.Tra.Line;
using ClassLib4PtxDbModel.Tra.Ticket;
using ClassLib4PtxDbModel.Tra.Time;

using Newtonsoft.Json;

using PTXHttpClientExtension;

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;

namespace ClassLib4Ptx2GetJson
{
    public class Class4GetJson
    {
        #region 公用指令
        /// <summary>
        /// 串接Ptx Api使用的 appID
        /// </summary>
        public string appID = "";

        /// <summary>
        /// 串接Ptx Api使用的 appKey
        /// </summary>
        public string appKey = "";

        /// <summary>
        /// 串接Ptx Api的主網站網址
        /// </summary>
        public string baseAddress = "https://ptx.transportdata.tw/";

        /// <summary>
        /// 適合Ptx Api的日期字串
        /// </summary>
        public string DateStringOfDateAfterToday(int range)
        {
            return GetStringOfDate(DateTime.Today.AddDays(range));
        }

        /// <summary>
        /// 取得適合Ptx Api的日期字串
        /// </summary>
        /// <param name="date">日期變數</param>
        /// <returns>適合Ptx Api的日期字串</returns>
        static string GetStringOfDate(DateTime date)
        {
            string stringOfYearOfDate = date.Year.ToString();
            string stringOfMonthOfDate = GetTwoLetterLength(date.Month.ToString());
            string stringOfDayOfDate = GetTwoLetterLength(date.Day.ToString());
            string stringOfDate = stringOfYearOfDate + "-" + stringOfMonthOfDate + "-" + stringOfDayOfDate;
            return stringOfDate;
        }

        /// <summary>
        /// 取得雙位元字串
        /// </summary>
        /// <param name="str">輸入的字串</param>
        /// <returns>傳回雙位元字串</returns>
        static string GetTwoLetterLength(string str)
        {
            if (str.Length == 1)
                return "0" + str;
            else
                return str;
        }

        /// <summary>
        /// 從Ptx Api取得Json字串
        /// </summary>
        /// <param name="appID">Ptx Api使用的 appID</param>
        /// <param name="appKey">Ptx Api使用的 appKey</param>
        /// <param name="baseAddress">Ptx Api的主網站網址</param>
        /// <param name="requestUri">Ptx Api的指令字串</param>
        /// <returns>傳回的Json字串</returns>
        public string GetJsonString(string appID, string appKey, string baseAddress, string requestUri)
        {
            HttpClient _client;
            HttpClientHandler _clientHandler;

            _clientHandler = new HttpClientHandler
            {

                //啟用 GZip, Deflate 壓縮傳輸 / 減少傳遞的資料量
                AutomaticDecompression = DecompressionMethods.GZip | DecompressionMethods.Deflate
            };

            _client = new HttpClient(_clientHandler)
            {
                BaseAddress = new Uri(baseAddress)
            };

            //設定 RequestHeader 驗證簽章
            _client.SetSignature(appID, appKey);

            var _response = _client.GetAsync(requestUri).Result;

            return _response.Content.ReadAsStringAsync().Result;
        }
        #endregion

        #region 台鐵資訊集
        #region TraTrainStation(台鐵列車車站)
        /// <summary>
        /// 取得台鐵列車車站的指令字串
        /// </summary>
        public string requestUri4TraStations = "MOTC/v2/Rail/TRA/Station?%24format=JSON";

        /// <summary>
        /// 從Ptx Api取得台鐵列車車站資訊(https://ptx.transportdata.tw/MOTC/v2/Rail/TRA/Station?%24format=JSON)
        /// </summary>
        /// <param name="appID">串接Ptx Api使用的 appID</param>
        /// <param name="appKey">串接Ptx Api使用的 appKey</param>
        /// <param name="baseAddress">串接Ptx Api的主網站網址</param>
        /// <param name="requestUri">串接Ptx Api的指令字串</param>
        /// <returns>台鐵列車車站資訊</returns>
        public List<ClassLib4PtxDbModel.Tra.Class4TraTrainStation> GetListOfTraTrainStation(string appID, string appKey, string baseAddress, string requestUri)
        {
            string jsonOfObj = GetJsonString(appID, appKey, baseAddress, requestUri);
            return JsonConvert.DeserializeObject<List<ClassLib4PtxDbModel.Tra.Class4TraTrainStation>>(jsonOfObj);
        }
        #endregion

        #region TraTrainLine(台鐵列車路線)
        /// <summary>
        /// 取得台鐵列車路線的指令字串
        /// </summary>
        public string requestUri4TraTrainLine = "MOTC/v2/Rail/TRA/Line?$format=JSON";

        /// <summary>
        /// 從Ptx Api取得台鐵列車路線資訊(https://ptx.transportdata.tw/MOTC/v2/Rail/TRA/Line?$format=JSON)
        /// </summary>
        /// <param name="appID">串接Ptx Api使用的 appID</param>
        /// <param name="appKey">串接Ptx Api使用的 appKey</param>
        /// <param name="baseAddress">串接Ptx Api的主網站網址</param>
        /// <param name="requestUri">串接Ptx Api的指令字串</param>
        /// <returns>台鐵列車路線資訊</returns>
        public List<ClassLib4PtxDbModel.Tra.Line.Class4TraTrainLine> GetListOfTraTrainLine(string appID, string appKey, string baseAddress, string requestUri)
        {
            string jsonOfObj = GetJsonString(appID, appKey, baseAddress, requestUri);
            return JsonConvert.DeserializeObject<List<ClassLib4PtxDbModel.Tra.Line.Class4TraTrainLine>>(jsonOfObj);
        }
        #endregion

        #region TraTrainLineSteps(台鐵列車路線站序)
        /// <summary>
        /// 取得台鐵列車路線站序的指令字串
        /// </summary>
        public string requeatUri4TraTrainLineSteps = "MOTC/v2/Rail/TRA/StationOfLine?$format=JSON";

        /// <summary>
        /// 從Ptx Api取得台鐵列車路線站序資訊(https://ptx.transportdata.tw/MOTC/v2/Rail/TRA/StationOfLine?$format=JSON)
        /// </summary>
        /// <param name="appID">串接Ptx Api使用的 appID</param>
        /// <param name="appKey">串接Ptx Api使用的 appKey</param>
        /// <param name="baseAddress">串接Ptx Api的主網站網址</param>
        /// <param name="requestUri">串接Ptx Api的指令字串</param>
        /// <returns>台鐵列車路線站序資訊</returns>
        public List<Class4TraTrainLineSteps> GetListOfTraTrainLineSteps(string appID, string appKey, string baseAddress, string requestUri)
        {
            string jsonOfObj = GetJsonString(appID, appKey, baseAddress, requestUri);
            return JsonConvert.DeserializeObject<List<Class4TraTrainLineSteps>>(jsonOfObj);
        }
        #endregion

        #region TraTrainTimeTable(台鐵列車時刻)
        /// <summary>
        /// 取得台鐵列車時刻的指令字串
        /// </summary>
        public string requestUri4TraTimes = "MOTC/v2/Rail/TRA/DailyTimetable/Station/1020/2022-02-12?$format=JSON";

        /// <summary>
        /// 從Ptx Api取得台鐵列車時刻資訊(https://ptx.transportdata.tw/MOTC/v2/Rail/TRA/DailyTimetable/Station/1020/2022-02-12?$format=JSON)
        /// </summary>
        /// <param name="appID">串接Ptx Api使用的 appID</param>
        /// <param name="appKey">串接Ptx Api使用的 appKey</param>
        /// <param name="baseAddress">串接Ptx Api的主網站網址</param>
        /// <param name="requestUri">串接Ptx Api的指令字串</param>
        /// <returns>台鐵列車時刻資訊</returns>
        public List<Class4TraTrainTimeTable> GetListOfTraTrainTimeTable(string appID, string appKey, string baseAddress, string requestUri)
        {
            string jsonOfObj = GetJsonString(appID, appKey, baseAddress, requestUri);
            return JsonConvert.DeserializeObject<List<Class4TraTrainTimeTable>>(jsonOfObj);
        }
        #endregion

        #region TraTrainTicketPrice(台鐵車票票價)
        /// <summary>
        /// 取得台鐵車票票價的指令字串
        /// </summary>
        public string requestUri4TraTicketPrice = "MOTC/v2/Rail/TRA/ODFare?%24format=JSON";

        /// <summary>
        /// 從Ptx Api取得台鐵車票票價資訊(https://ptx.transportdata.tw/MOTC/v2/Rail/TRA/ODFare?%24format=JSON)
        /// </summary>
        /// <param name="appID">串接Ptx Api使用的 appID</param>
        /// <param name="appKey">串接Ptx Api使用的 appKey</param>
        /// <param name="baseAddress">串接Ptx Api的主網站網址</param>
        /// <param name="requestUri">串接Ptx Api的指令字串</param>
        /// <returns>台鐵車票票價資訊</returns>
        public List<Class4TraTrainTicketPrice> GetListOfTraTrainTicketPrice(string appID, string appKey, string baseAddress, string requestUri)
        {
            string jsonOfObj = GetJsonString(appID, appKey, baseAddress, requestUri);
            return JsonConvert.DeserializeObject<List<Class4TraTrainTicketPrice>>(jsonOfObj);
        }
        #endregion
        #endregion
    }
}
