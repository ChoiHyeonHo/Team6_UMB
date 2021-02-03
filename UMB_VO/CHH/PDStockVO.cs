using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMB_VO.CHH
{
    public class PDStockVO
    {
        public int ps_id { get; set; }
        public string product_id { get; set; }
        public string product_name { get; set; }
        public string product_type { get; set; }
        public int ps_stock { get; set; }
        public string ps_idate { get; set; }
        public string ps_odate { get; set; }
        public string w_name { get; set; }
        public string company_name { get; set; }
    }
}
