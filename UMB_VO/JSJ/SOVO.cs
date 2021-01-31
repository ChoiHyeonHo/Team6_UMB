using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMB_VO
{
    public class SOVO
    {
        public int so_id { get; set; }
        public int company_id { get; set; }
        public string product_id { get; set; }
        //public string so_state { get; set; }
        public string so_edate { get; set; }
        public int so_ocount { get; set; }
        public string so_rep { get; set; }
        public string so_comment { get; set; }
    }
    
    public class SOListVO
    {
        public int so_id { get; set; }
        public string company_name { get; set; }
        public string product_name { get; set; }
        public string so_edate { get; set; }
        public int so_ocount { get; set; }
        public string so_rep { get; set; }
    }

    public class SOPListVO
    {
        public string product_id { get; set; }
        public int company_id { get; set; }
        public string company_name { get; set; }
        public string product_name { get; set; }
    }

    public class SOCompanyVO
    {
        public string company_name { get; set; }
    }
}
