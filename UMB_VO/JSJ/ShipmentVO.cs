using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMB_VO
{
    public class ShipmentVO
    {
        public int ship_id { get; set; }
        public string product_name { get; set; }
        public string company_name { get; set; }
        public string ship_state { get; set; }
        public int ship_count { get; set; }
        public string ship_edate { get; set; }
    }
}
