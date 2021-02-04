using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMB_VO.CHH
{
    public class ProdImpInsVO
    {
        public int incomming_ID { get; set; } //입고ID
        public string incomming_state { get; set; } //입고상태 (대기 / 확정)
        public string incomming_date { get; set; } //입고일
        public string incomming_rep { get; set; } // 담당자
        public int incomming_count { get; set; } // 입고량
        public string order_id { get; set; } // 발주번호
        public string orderexam_result { get; set; } // 합불판정 (합 / 불합 / 자동발주)
        public string incomming_uadmin { get; set; } // 수정자
        public string incomming_udate { get; set; } // 수정일
    }

    public class InsCheckVO
    {
        public int cl_inc_id { get; set; }
        public int incomming_ID { get; set; }
        public string cl_inc_Color { get; set; }
        public string cl_inc_Torn { get; set; }
        public string cl_inc_Length { get; set; }
        public string cl_inc_Crack { get; set; }
        public string etc { get; set; }
    }
}
