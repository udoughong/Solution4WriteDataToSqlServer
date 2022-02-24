using System;

namespace ClassLib4PtxDbModel.Tra.Line
{
    public class Class4TraTrainLine
    {
        public string LineNo { get; set; }

        /// <summary>
        /// 路線代碼
        /// </summary>
        public string LineID { get; set; }

        /// <summary>
        /// 路線中文名稱
        /// </summary>
        public string LineNameZh { get; set; }

        /// <summary>
        /// 路線英文名稱
        /// </summary>
        public string LineNameEn { get; set; }

        /// <summary>
        /// 路線區間中文名稱
        /// </summary>
        public string LineSectionNameZh { get; set; }

        /// <summary>
        /// 路線區間英文名稱
        /// </summary>
        public string LineSectionNameEn { get; set; }

        /// <summary>
        /// 是否位於支線
        /// </summary>
        public bool IsBranch { get; set; }

        /// <summary>
        /// 資料更新日期時間(yyyy-MM-dd HH:mm:sszzz)
        /// </summary>
        public DateTime UpdateTime { get; set; }
    }
}
