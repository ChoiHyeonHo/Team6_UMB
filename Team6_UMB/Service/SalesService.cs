using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMB_DAC;
using UMB_VO;

namespace Team6_UMB.Service
{
    class SalesService
    {
        public List<SalesVO> SalesList()
        {
            SalesDAC dac = new SalesDAC();
            return dac.SalesList();
        }
    }
}
