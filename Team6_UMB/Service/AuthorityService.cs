using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMB_DAC;
using UMB_VO;

namespace Team6_UMB.Service
{
    class AuthorityService
    {
        public (List<DepartmentVO>, List<MenuVO>) DepartmentList()
        {
            AuthorityDAC dac = new AuthorityDAC();
            return dac.DepartmentList();
        }
    }
}
