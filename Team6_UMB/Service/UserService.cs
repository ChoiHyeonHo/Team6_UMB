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
    }
}
