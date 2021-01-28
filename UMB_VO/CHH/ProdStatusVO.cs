using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMB_VO.CHH
{
    public class ProdStatusVO
    {
        public string product_id { get; set; }
        public string product_name { get; set; }
        public string product_type { get; set; }
        public string product_unit { get; set; }
        public int price_present { get; set; }
        public string w_name { get; set; }
        public int product_lorder_count { get; set; }
        public int product_safety_count { get; set; }
        public string company_name { get; set; }
        public string product_exam { get; set; }
        public string price_yn { get; set; }
        public int company_id { get; set; }
        public int w_id { get; set; }
        public string product_stnd { get; set; }
        public string product_comment { get; set; }
        public string product_deleted { get; set; }
    }

    public class GetProdNameVO
    {
        public string product_id { get; set; }
        public string product_name { get; set; }
    }

    public class GetCompanyNameVO
    {
        public int? company_id { get; set; }
        public string company_name { get; set; }
    }

    public class GetWHNameVO
    {
        public int? w_id { get; set; }
        public string w_name { get; set; }
    }
}
