using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMB_VO.CHH
{
    public class CheckHistoryVO
    {
        public int ch_id { get; set; }
        public string ch_item { get; set; }
        public string product_id { get; set; }
        public string ch_date { get; set; }
        public string ch_type { get; set; }
        public string ch_comment { get; set; }
        public int? cl_ship_id { get; set; }
        public int? cl_inc_id { get; set; }
    }
    public class GetCheckTypeVO
    {
        public int? common_id { get; set; }
        public string common_name { get; set; }
    }
}
