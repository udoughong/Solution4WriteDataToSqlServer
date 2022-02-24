using System;

namespace ClassLib4PtxDbModel.Tra.Time
{
    public class Class4TraTrainTimeTable
    {
        /// <summary>
        /// 時刻表日期
        /// </summary>
        public string TrainDate { get; set; }

        /// <summary>
        /// 車站代號
        /// </summary>
        public string StationID { get; set; }

        /// <summary>
        /// 車站名稱資訊
        /// </summary>
        public StationName StationName { get; set; }

        /// <summary>
        /// 車次代號
        /// </summary>
        public string TrainNo { get; set; }

        /// <summary>
        /// 順逆行(0:'順行',1:'逆行')
        /// </summary>
        public int Direction { get; set; }

        /// <summary>
        /// 山海線類型(0:'不經山海線',1:'山線',2:'海線',3:'成追線
        /// </summary>
        public int TripLine { get; set; }

        /// <summary>
        /// 列車車種代碼
        /// </summary>
        public string TrainTypeID { get; set; }

        /// <summary>
        /// 列車車種簡碼
        /// </summary>
        public string TrainTypeCode { get; set; }

        /// <summary>
        /// 列車車種名稱資訊
        /// </summary>
        public TrainTypeName TrainTypeName { get; set; }

        /// <summary>
        /// 起點車站代號
        /// </summary>
        public string StartingStationID { get; set; }

        /// <summary>
        /// 起點車站名稱資訊
        /// </summary>
        public StartingStationName StartingStationName { get; set; }

        /// <summary>
        /// 終點車站代號
        /// </summary>
        public string EndingStationID { get; set; }

        /// <summary>
        /// 終點車站名稱資訊
        /// </summary>
        public EndingStationName EndingStationName { get; set; }

        /// <summary>
        /// 到站時間(HH:mm:ss)
        /// </summary>
        public string ArrivalTime { get; set; }

        /// <summary>
        /// 離站時間(HH:mm:ss)
        /// </summary>
        public string DepartureTime { get; set; }

        /// <summary>
        /// 本平台資料更新時間(yyyy-MM-dd HH:mm:sszzz)
        /// </summary>
        public DateTime UpdateTime { get; set; }
        public int VersionID { get; set; }
    }

    /// <summary>
    /// 車站名稱資訊
    /// </summary>
    public class StationName
    {
        /// <summary>
        /// 中文版
        /// </summary>
        public string Zh_tw { get; set; }

        /// <summary>
        /// 英文版
        /// </summary>
        public string En { get; set; }
    }

    /// <summary>
    /// 列車車種名稱資訊
    /// </summary>
    public class TrainTypeName
    {
        /// <summary>
        /// 中文版
        /// </summary>
        public string Zh_tw { get; set; }

        /// <summary>
        /// 英文版
        /// </summary>
        public string En { get; set; }
    }

    /// <summary>
    /// 起點車站名稱資訊
    /// </summary>
    public class StartingStationName
    {
        /// <summary>
        /// 中文版
        /// </summary>
        public string Zh_tw { get; set; }

        /// <summary>
        /// 英文版
        /// </summary>
        public string En { get; set; }
    }

    /// <summary>
    /// 終點車站名稱資訊
    /// </summary>
    public class EndingStationName
    {
        /// <summary>
        /// 中文版
        /// </summary>
        public string Zh_tw { get; set; }

        /// <summary>
        /// 英文版
        /// </summary>
        public string En { get; set; }
    }
}
