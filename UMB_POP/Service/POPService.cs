using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMB_DAC;
using UMB_DAC.ASB;
using UMB_VO.ASB;

namespace UMB_POP.Service
{
    public class POPService
    {
        public void Login(int ID, int Pwd)
        {
            LoginDAC dac = new LoginDAC();
            dac.Login(ID, Pwd);
        }

        internal List<PerformanceVO> GetWaitPerList()
        {
            PerformanceDAC dac = new PerformanceDAC();
            return dac.GetWaitPerList();
        }

        internal List<PerformanceVO> GetWorkPerList()
        {
            PerformanceDAC dac = new PerformanceDAC();
            return dac.GetWorkPerList();
        }

        internal List<PerformanceVO> GetEndPerList()
        {
            PerformanceDAC dac = new PerformanceDAC();
            return dac.GetEndPerList();
        }
    }
}
