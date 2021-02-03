using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMB_VO
{
    public class AuthorityVO
    {
        public int department_id { get; set; }
        public string auth_formname { get; set; }
        public string auth_comment { get; set; }
        public string auth_uadmin { get; set; }
        public string auth_udate { get; set; }
    }

    public class MenuVO
    {
        public string common_name { get; set; }
    }
}
