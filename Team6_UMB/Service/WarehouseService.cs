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

        public int InsertWH(WarehouseVO vo)
        {
            WarehouseDAC dac = new WarehouseDAC();
            return dac.InsertWH(vo);
        }

        public int UpdateWH(WarehouseVO vo)
        {
            WarehouseDAC dac = new WarehouseDAC();
            return dac.UpdateWH(vo);
        }

        public int DeleteWH(int w_id)
        {
            WarehouseDAC dac = new WarehouseDAC();
            return dac.DeleteWH(w_id);
        }

        public List<ComboItemVO> WType()
        {
            WarehouseDAC dac = new WarehouseDAC();
            return dac.WType();
        }
    }
}
