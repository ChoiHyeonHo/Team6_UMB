using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMB_DAC;
using UMB_VO;

namespace Team6_UMB.Service
{
    class SOService
    {
        public List<SOListVO> SOList()
        {
            SODAC dac = new SODAC();
            return dac.SOList();
        }

        public List<SOCompanyVO> CompanyList()
        {
            SODAC dac = new SODAC();
            return dac.CompanyList();
        }

        public List<SOPListVO> OrderPList()
        {
            SODAC dac = new SODAC();
            return dac.OrderPList();
        }

        public int RegistSO(List<SOVO> list)
        {
            SODAC dac = new SODAC();
            return dac.RegistSO(list);
        }
    }
}
