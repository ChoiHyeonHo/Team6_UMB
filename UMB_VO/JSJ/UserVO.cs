using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMB_VO
{
    public class UserVO
    {
        public int user_id { get; set; }
        public string user_name { get; set; }
        public string user_national { get; set; }
        public string user_hiredate { get; set; }
        public string user_enddate { get; set; }
        public bool user_isadmin { get; set; }
        public string user_pwd { get; set; }
        public string user_phone { get; set; }
        public string user_birth { get; set; }
        public string user_uadmin { get; set; }
        public string department_name { get; set; }
        public int department_id { get; set; }
    }
}
