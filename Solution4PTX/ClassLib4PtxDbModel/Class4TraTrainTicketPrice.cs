using System;

namespace ClassLib4PtxDbModel.Tra.Ticket
{
    public class Class4TraTrainTicketPrice
    {
        /// <summary>
        /// 起點車站代碼
        /// </summary>
        public string OriginStationID { get; set; }

        /// <summary>
        /// 起點車站名稱資訊
        /// </summary>
        public Originstationname OriginStationName { get; set; }

        /// <summary>
        /// 迄點車站代碼
        /// </summary>
        public string DestinationStationID { get; set; }

        /// <summary>
        /// 迄點車站名稱資訊
        /// </summary>
        public Destinationstationname DestinationStationName { get; set; }

        /// <summary>
        /// 順逆行(0:'順行',1:'逆行')
        /// </summary>
        public int Direction { get; set; }

        /// <summary>
        /// 票價資訊
        /// </summary>
        public Fare[] Fares { get; set; }

        /// <summary>
        /// 更新時間(yyyy-MM-ddTHH:mm:sszzz)
        /// </summary>
        public DateTime UpdateTime { get; set; }
        public int VersionID { get; set; }
    }

    /// <summary>
    /// 起點車站名稱資訊
    /// </summary>
    public class Originstationname
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
    /// 迄點車站名稱資訊
    /// </summary>
    public class Destinationstationname
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
    /// 票價資訊
    /// </summary>
    public class Fare
    {
        /// <summary>
        /// 票種名稱
        /// </summary>
        public string TicketType { get; set; }

        /// <summary>
        /// 收費價格(新台幣)
        /// </summary>
        public float Price { get; set; }
    }
}
