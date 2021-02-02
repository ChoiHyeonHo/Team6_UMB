using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMB_VO
{
    public class IncommingVO
    {
        public string incomming_rep { get; set; }
        public int incomming_count { get; set; }
        public int order_id { get; set; }
    }

    public class IncommingStatusVO
    {
        public int incomming_ID { get; set; }
        public string incomming_state { get; set; }
        public string incomming_date { get; set; }
        public string company_name { get; set; }
        public string incomming_rep { get; set; }
        public int incomming_count { get; set; }
        public string product_name { get; set; }
        public string orderexam_result { get; set; }
    }
}
