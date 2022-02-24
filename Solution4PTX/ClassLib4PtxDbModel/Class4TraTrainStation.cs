using System;

namespace ClassLib4PtxDbModel.Tra
{
    public class Class4TraTrainStation
    {
        /// <summary>
        /// 車站唯一識別代碼
        /// </summary>
        public string StationUID { get; set; }

        /// <summary>
        /// 車站代碼
        /// </summary>
        public string StationID { get; set; }

        /// <summary>
        /// 車站名稱資訊
        /// </summary>
        public StationName StationName { get; set; }

        /// <summary>
        /// 車站地址
        /// </summary>
        public string StationAddress { get; set; }

        /// <summary>
        /// 車站聯絡電話
        /// </summary>
        public string StationPhone { get; set; }

        /// <summary>
        /// 營運業者代碼
        /// </summary>
        public string OperatorID { get; set; }

        /// <summary>
        /// 車站級別
        /// </summary>
        public string StationClass { get; set; }

        /// <summary>
        /// 平台資料更新時間(yyyy-MM-ddTHH:mm:sszzz)
        /// </summary>
        public DateTime UpdateTime { get; set; }

        public int VersionID { get; set; }

        /// <summary>
        /// 車站位置資訊
        /// </summary>
        public StationPosition StationPosition { get; set; }

        /// <summary>
        /// 車站位置所屬縣市
        /// </summary>
        public string LocationCity { get; set; }

        /// <summary>
        /// 車站位置所屬縣市代碼
        /// </summary>
        public string LocationCityCode { get; set; }

        /// <summary>
        /// 車站位置所屬鄉鎮
        /// </summary>
        public string LocationTown { get; set; }

        /// <summary>
        /// 車站位置所屬鄉鎮代碼
        /// </summary>
        public string LocationTownCode { get; set; }
    }

    /// <summary>
    /// 車站名稱資訊
    /// </summary>
    public class StationName
    {
        /// <summary>
        /// 車站名稱-中文
        /// </summary>
        public string Zh_tw { get; set; }

        /// <summary>
        /// 車站名稱-英文
        /// </summary>
        public string En { get; set; }
    }

    /// <summary>
    /// 車站位置資訊
    /// </summary>
    public class StationPosition
    {
        /// <summary>
        /// 車站位置經度(WGS84)
        /// </summary>
        public float PositionLon { get; set; }

        /// <summary>
        /// 車站位置緯度(WGS84)
        /// </summary>
        public float PositionLat { get; set; }

        /// <summary>
        /// 車站地理空間編碼
        /// </summary>
        public string GeoHash { get; set; }
    }
}
