using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMB_VO.CHH
{
    public class ProdInsVO
    {
        public int production_id { get; set; }
        public int wo_id { get; set; }
        public int so_id { get; set; }
        public string product_id { get; set; }
        public string product_name { get; set; }
        public string ship_state { get; set; }
        public string production_state { get; set; }
        public string so_edate { get; set; }
        public int ship_id { get; set; }
        public int production_QtyReleased { get; set; }
    }
    public class ProdInsPopUpVO
    {
        public int cl_ship_id { get; set; }
        public int ship_id { get; set; }
        public string product_name { get; set; }
        public string cl_ship_Components { get; set; }
        public string cl_ship_Packing { get; set; }
        public string etc { get; set; }
        public string production_state { get; set; }
    }
}
