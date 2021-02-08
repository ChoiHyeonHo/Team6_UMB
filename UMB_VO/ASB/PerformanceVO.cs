using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMB_VO.ASB
{
    public class PerformanceVO
    {
        //performance_id, production_id, product_id, process_name, performance_qty_ok, performance_qty_ng, performance_qtyimport
        //production_state, production_sdate
        public int performance_id { get; set; }
        public int production_id { get; set; }
        public string product_id { get; set; }
        public string product_name { get; set; }
        public string process_name { get; set; }
        public int performance_qty_ok { get; set; }
        public int performance_qty_ng { get; set; }
        public int performance_qtyimport { get; set; }        
        public string production_state { get; set; }
        public string production_sdate { get; set; }

    }
}
