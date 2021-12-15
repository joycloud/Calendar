using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calendar.dto
{
    public class dtoItems
    {
        /// <summary>
        /// 編號
        /// </summary>
        public int no { get; set; }
        /// <summary>
        /// 標題
        /// </summary>
        public string title { get; set; }
        /// <summary>
        /// 備註
        /// </summary>
        public string remark { get; set; }
        /// <summary>
        /// 起始日期
        /// </summary>
        public string sdate { get; set; }
        /// <summary>
        /// 結束日期
        /// </summary>
        public string edate { get; set; }
        /// <summary>
        /// 開關
        /// </summary>
        public bool open { get; set; }
    }
}
