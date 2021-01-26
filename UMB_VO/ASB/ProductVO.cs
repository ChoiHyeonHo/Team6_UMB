using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMB_VO
{
    public class ProductVO
    {
        // product_id, product_name, product_unit, product_type, product_lorder_count, product_safety_count, company_id, product_exam, 
        // product_stnd, product_comment, product_deleted, w_id, product_uadmin, product_udate
        public string product_id { get; set; }
        public string product_name { get; set; }
        public string product_unit { get; set; }
        public string product_type { get; set; }
        public int product_lorder_count { get; set; }
        public int product_safety_count { get; set; }
        public int company_id { get; set; }
        public string product_exam { get; set; }
        public string product_stnd { get; set; }
        public string product_comment { get; set; }
        public string product_deleted { get; set; }
        public int w_id { get; set; }
        public string product_uadmin { get; set; }
        public string product_udate { get; set; }
    }
}