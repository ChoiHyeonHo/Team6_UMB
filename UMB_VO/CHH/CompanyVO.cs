using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMB_VO.CHH
{
    public class CompanyVO
    {
        public int company_id { get; set; }
        public string company_name { get; set; }
        public string company_type { get; set; }
        public string company_ceo { get; set; }
        public string company_cnum { get; set; }
        public string company_btype { get; set; }
        public string company_gtype { get; set; }
        public string company_email { get; set; }
        public string company_phone { get; set; }
        public string company_fax { get; set; }
        public string company_ZipCode { get; set; }
        public string company_Address { get; set; }
        public string company_DetAddress { get; set; }
        public string company_uadmin { get; set; }
        public string company_udate { get; set; }
        public string company_comment { get; set; }
    }

    public class CompanyTypeVO
    {
        public int? common_id { get; set; }
        public string common_name { get; set; }
    }
}
