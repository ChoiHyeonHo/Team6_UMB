using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMB_VO
{
    public class ComboItemVO
    {
        //common_id, common_type, common_name, common_value
        public int? common_id { get; set; }
        public string common_type { get; set; }
        public string common_name { get; set; }
        public string common_value { get; set; }
    }
}
