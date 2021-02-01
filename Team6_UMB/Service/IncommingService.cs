using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMB_DAC;
using UMB_VO;

namespace Team6_UMB.Service
{
    class IncommingService
    {
        public List<OrderListVO> OrderList()
        {
            OrderDAC dac = new OrderDAC();
            return dac.OrderList();
        }

        public int IncommingWait(IncommingVO vo)
        {
            IncommingDAC dac = new IncommingDAC();
            return dac.IncommingWait(vo);
        }
    }
}
