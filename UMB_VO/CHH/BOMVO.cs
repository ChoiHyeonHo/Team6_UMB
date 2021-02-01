using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMB_VO.CHH
{
    public class BOMVO
    {
        public int bom_id { get; set; }
        public string bom_parent_id { get; set; }
        public string prod_parent_id { get; set; }
        public string prod_parent_name { get; set; }
        public string product_id { get; set; }
        public string product_name { get; set; }
        public string product_type { get; set; }
        public string product_unit { get; set; }
        public int bom_use_count { get; set; }
        public int bom_level { get; set; }
        public string bom_comment { get; set; }
        
    }
}
