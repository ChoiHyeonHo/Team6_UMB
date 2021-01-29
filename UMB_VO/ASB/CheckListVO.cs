using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMB_VO.ASB
{
    public class CheckListVO
    {
        public int? cl_id { get; set; }
        public string cl_name { get; set; }
        public string product_id { get; set; }
        public string product_name { get; set; }
        public string cl_stnd { get; set; }
        public string cl_comment { get; set; }
        public string cl_uadmin { get; set; }
        public string cl_udate { get; set; }
        public string cl_type { get; set; }
    }
}
