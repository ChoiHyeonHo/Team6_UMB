using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMB_VO.ASB
{
    public class WorkOrderVO
    {
        //wo_id, wo_date, wo_pcount, m_id, so_id, wo_count, wo_uadmin, wo_udate, wo_state, product_id, wo_sdate
        public int wo_id { get; set; }
        public string product_id { get; set; }
        public string product_name { get; set; }
        public int m_id { get; set; }
        public string m_name { get; set; }
        public int wo_pcount { get; set; }
        public int wo_count { get; set; }
        public string wo_date { get; set; }
        public string wo_sdate { get; set; }
        public string wo_state { get; set; }
        public string wo_uadminv { get; set; }
        public string wo_udate { get; set; }
    }
}
