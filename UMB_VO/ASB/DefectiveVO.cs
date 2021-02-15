using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMB_VO.ASB
{
    public class DefectiveVO
    {
        public int defective_ID { get; set; }
        public string defective_stime { get; set; }        
        public int performance_id { get; set; }
        public int common_name { get; set; }
        public int defective_count { get; set; }
        public string product_id { get; set; }
        public string process_name { get; set; }
        public string product_name { get; set; }
    }
}
