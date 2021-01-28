using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMB_DAC;
using UMB_VO;

namespace Team6_UMB.Service
{
    class OrderService
    {
        public List<OrderListVO> OrderList()
        {
            OrderDAC dac = new OrderDAC();
            return dac.OrderList();
        }

        public int DeleteOrder(int order_id)
        {
            OrderDAC dac = new OrderDAC();
            return dac.DeleteOrder(order_id);
        }

        public List<OrderPlistVO> OrderPList()
        {
            OrderDAC dac = new OrderDAC();
            return dac.OrderPList();
        }

        public List<OrderCompanyVO> CompanyList()
        {
            OrderDAC dac = new OrderDAC();
            return dac.CompanyList();
        }

        public int RegistOrder(List<OrderVO> list)
        {
            OrderDAC dac = new OrderDAC();
            return dac.RegistOrder(list);
        }
    }
}
