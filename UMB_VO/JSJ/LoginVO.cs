using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMB_VO
{
    public class LoginVO
    {
        public static User user
        {
            get;
            set;
        }

        public class User
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public int Department { get; set; }
        }
    }
}
