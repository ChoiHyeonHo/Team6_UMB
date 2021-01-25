using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMB_VO
{
    public class BORVO
    {
        public int BOR_id { get; set; } //bor 아이디
        public int product_id { get; set; } // 품목 아이디
        public int process_name { get; set; } // 공정명
        public int m_id { get; set; } // 설비 아이디
        public int bor_tattime { get; set; } // Tact_Time
        public int bor_yn { get; set; } // 사용유무
        public int bor_comment { get; set; } // 비고
        public int bor_uadmin { get; set; } // 수정자
        public int bor_udate { get; set; } // 수정일
        public int product_name { get; set; } // 품목명
        public int m_name { get; set; } // 설비명
    }
}
