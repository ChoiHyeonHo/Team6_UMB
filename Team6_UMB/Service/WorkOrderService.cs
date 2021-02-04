using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMB_DAC.ASB;
using UMB_VO.ASB;

namespace Team6_UMB.Service
{
    public class WorkOrderService
    {
        public List<WorkOrderVO> GetWoList()
        {
            WorkOrderDAC dac = new WorkOrderDAC();
            return dac.GetWoList();
        }
    }
}
