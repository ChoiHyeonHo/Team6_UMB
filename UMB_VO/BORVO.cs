using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMB_VO
{
    public class BORVO
    {
        public int? BOR_id { get; set; } //bor 아이디
        public string product_id { get; set; } // 품목 아이디
        public string process_name { get; set; } // 공정명
        public int m_id { get; set; } // 설비 아이디
        public int bor_tattime { get; set; } // Tact_Time
        public string bor_yn { get; set; } // 사용유무
        public string bor_comment { get; set; } // 비고
        public string bor_uadmin { get; set; } // 수정자
        public string bor_udate { get; set; } // 수정일
        public string product_name { get; set; } // 품목명
        public string m_name { get; set; } // 설비명
    }
}
