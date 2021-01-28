using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMB_VO
{
    public class OrderVO
    {
        public string product_id { get; set; }
        public int order_count { get; set; }
        public int company_id { get; set; }
        public string order_edate { get; set; }
    }

    public class OrderListVO
    {
        public int order_id { get; set; }        
        public string product_name { get; set; }
        public string company_name { get; set; }
        public string user_name { get; set; }
        public string order_date { get; set; }
        public string order_edate { get; set; }
        public int order_count { get; set; }
        //public int order_uadmin { get; set; }
        //public int order_udate { get; set; }
    }

    public class  OrderPlistVO
    {
        public string product_id { get; set; }
        public int company_id { get; set; }
        public string product_name { get; set; }
        public string company_name { get; set; }
    }

    public class OrderCompanyVO
    {
        public string company_name { get; set; }
    }
}
