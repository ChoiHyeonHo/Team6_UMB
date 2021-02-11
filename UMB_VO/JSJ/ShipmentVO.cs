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
        public string product_id { get; set; }
        public string product_name { get; set; }
        public string company_name { get; set; }
        public string ship_state { get; set; }
        public int ship_count { get; set; }
        public string ship_edate { get; set; }
    }

    public class ShipSOVO
    {
        public int so_id { get; set; }
        public string company_name { get; set; }
        public string product_name { get; set; }
        public string so_edate { get; set; }
        public int so_ocount { get; set; }
        public string so_rep { get; set; }
        public string so_state { get; set; }
    }

    public class ShipWaitVO
    {
        public int so_id { get; set; }
        public int ship_count { get; set; }
        public string ship_state { get; set; }
        public string product_id { get; set; }
    }
}
