using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMB_DAC.ASB;
using UMB_VO.ASB;

namespace Team6_UMB.Service
{
    class PerformanceService
    {
        public List<PerformanceVO> GetPerList()
        {
            PerformanceDAC dac = new PerformanceDAC();
            return dac.GetPerList();
        }

        internal List<PerformanceVO> SearchPerList(string pid, string process)
        {
            PerformanceDAC dac = new PerformanceDAC();
            return dac.SearchPerList(pid, process);
        }
    }
}
