using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMB_DAC;
using UMB_VO;

namespace Team6_UMB.Service
{
    class ShipmentService
    {
        public List<ShipmentVO> ShipmentList()
        {
            ShipmentDAC dac = new ShipmentDAC();
            return dac.ShipmentList();
        }

        public List<ShipSOVO> ShipmentSOList()
        {
            ShipmentDAC dac = new ShipmentDAC();
            return dac.ShipmentSOList();
        }

        public int ShipWait(ShipWaitVO vo)
        {
            ShipmentDAC dac = new ShipmentDAC();
            return dac.ShipWait(vo);
        }
    }
}
