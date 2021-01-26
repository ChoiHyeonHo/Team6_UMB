using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMB_DAC;
using UMB_VO;

namespace Team6_UMB.Service
{
    class UserService
    {
        public List<UserVO> UserList()
        {
            UserDAC dac = new UserDAC();
            return dac.UserList();
        }

        public int RegistUser(UserVO vo)
        {
            UserDAC dac = new UserDAC();
            return dac.RegistUser(vo);
        }

        public List<DepartmentVO> DepartmentCboList()
        {
            DepartmentDAC dac = new DepartmentDAC();
            return dac.DepartmentCboList();
        }

        public UserVO userDetail(int user_id)
        {
            UserDAC dac = new UserDAC();
            return dac.userDetail(user_id);
        }

        public int UpdateUser(UserVO vo)
        {
            UserDAC dac = new UserDAC();
            return dac.UpdateUser(vo);
        }

        public int EndUser(int user_id)
        {
            UserDAC dac = new UserDAC();
            return dac.EndUser(user_id);
        }
    }
}
