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

        public List<PerformanceVO> GetWaitPerList()
        {
            PerformanceDAC dac = new PerformanceDAC();
            return dac.GetWaitPerList();
        }

        public List<PerformanceVO> GetWorkPerList()
        {
            PerformanceDAC dac = new PerformanceDAC();
            return dac.GetWorkPerList();
        }

        public List<PerformanceVO> GetEndPerList()
        {
            PerformanceDAC dac = new PerformanceDAC();
            return dac.GetEndPerList();
        }

        public int setTacttime(string product_id)
        {
            POPDAC dac = new POPDAC();
            return dac.setTacttime(product_id);
        }

        internal bool updatePOP(int wo_id)
        {
            POPDAC dac = new POPDAC();
            return dac.updatePOP(wo_id);
        }
    }
}
