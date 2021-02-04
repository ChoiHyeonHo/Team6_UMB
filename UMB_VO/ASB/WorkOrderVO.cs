using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMB_VO.ASB
{
    public class WorkOrderVO
    {
        // wo_id, so_id, product_id, product_name, m_id, m_name, wo_pcount, wo_count, wo_date, wo_sdate, wo_state, wo_uadmin, wo_udate
        public int wo_id { get; set; }
        public int so_id { get; set; }
        public string product_id { get; set; }
        public string product_name { get; set; }
        public int m_id { get; set; }
        public string m_name { get; set; }
        public int wo_pcount { get; set; }
        public int wo_count { get; set; }
        public string wo_date { get; set; }
        public string wo_sdate { get; set; }
        public string wo_state { get; set; }
        public string wo_uadmin { get; set; }
        public string wo_udate { get; set; }
    }
}
