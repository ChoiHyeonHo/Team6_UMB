using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMB_VO.CHH
{
    public class SalesPriceVO
    {
        public int price_id { get; set; } //ID
        public string product_name { get; set; } // 제품명
        public string company_name { get; set; } // 회사명
        public int price_present { get; set; } // 현재단가
        public int price_past { get; set; } // 이전단가
        public string price_sdate { get; set; } // 시작일
        public string price_edate { get; set; } // 종료일
        public string price_yn { get; set; } // 사용유무
    }
}
