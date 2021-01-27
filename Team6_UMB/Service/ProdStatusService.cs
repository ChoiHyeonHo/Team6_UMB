using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMB_DAC.CHH;
using UMB_VO.CHH;

namespace Team6_UMB.Service
{
    public class ProdStatusService
    {
        public List<ProdStatusVO> GetProdInfo()
        {
            ProdStatusDAC dac = new ProdStatusDAC();
            return dac.GetProdInfo();
        }
    }
}
