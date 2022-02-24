using System;

namespace ClassLib4PtxDbModel.Tra.Line
{
    public class Class4TraTrainLineSteps
    {
        /// <summary>
        /// 路線編號
        /// </summary>
        public string LineNo { get; set; }

        /// <summary>
        /// 路線代碼
        /// </summary>
        public string LineID { get; set; }

        /// <summary>
        /// 路線必經車站資訊
        /// </summary>
        public Station[] Stations { get; set; }

        /// <summary>
        /// 資料更新日期時間(yyyy-MM-dd HH:mm:sszzz)
        /// </summary>
        public DateTime UpdateTime { get; set; }
    }

    /// <summary>
    /// 路線必經車站資訊
    /// </summary>
    public class Station
    {
        /// <summary>
        /// 車站站序
        /// </summary>
        public int Sequence { get; set; }

        /// <summary>
        /// 車站代碼
        /// </summary>
        public string StationID { get; set; }

        /// <summary>
        /// 車站名稱
        /// </summary>
        public string StationName { get; set; }

        /// <summary>
        /// 已累積之里程距離(公里)
        /// </summary>
        public float TraveledDistance { get; set; }
    }
}
