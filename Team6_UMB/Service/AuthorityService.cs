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

        public int UpdateAuthority(List<AuthorityVO> list, int department_id)
        {
            AuthorityDAC dac = new AuthorityDAC();
            return dac.UpdateAuthority(list, department_id);
        }

        public List<string> MenuCheck(int department_id)
        {
            AuthorityDAC dac = new AuthorityDAC();
            return dac.MenuCheck(department_id);
        }

        //public List<AuthorityVO> MenuCheck(int department_id)
        //{
        //    AuthorityDAC dac = new AuthorityDAC();
        //    return dac.MenuCheck(department_id);
        //}
    }
}
