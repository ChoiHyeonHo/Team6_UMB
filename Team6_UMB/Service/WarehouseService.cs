using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMB_DAC;
using UMB_VO;

namespace Team6_UMB.Service
{
    class WarehouseService
    {
        public List<WarehouseVO> WarehouseList()
        {
            WarehouseDAC dac = new WarehouseDAC();
            return dac.WarehouseList();
        }
    }
}
