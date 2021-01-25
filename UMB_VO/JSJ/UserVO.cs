using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMB_VO
{
            //    CommonUtil.SetInitGridView(dgvUser);
            //CommonUtil.AddGridTextColumn(dgvUser, "사원번호", "user_id", 80);
            //CommonUtil.AddGridTextColumn(dgvUser, "사원이름", "user_name", 80);
            //CommonUtil.AddGridTextColumn(dgvUser, "입사일", "user_hiredate", 80);
            //CommonUtil.AddGridTextColumn(dgvUser, "국적", "user_national", 80);
            //CommonUtil.AddGridTextColumn(dgvUser, "퇴사일", "user_enddate", 80);
            //CommonUtil.AddGridTextColumn(dgvUser, "관리자여부", "user_isadmin", 80);
            //CommonUtil.AddGridTextColumn(dgvUser, "부서", "department", 80);
            //CommonUtil.AddGridTextColumn(dgvUser, "전화번호", "user_phone", 80);
            //CommonUtil.AddGridTextColumn(dgvUser, "생년월일", "user_birth", 80);
            //CommonUtil.AddGridTextColumn(dgvUser, "비밀번호", "user_pwd", 80);
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
