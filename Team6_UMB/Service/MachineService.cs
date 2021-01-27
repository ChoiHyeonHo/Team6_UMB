using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMB_DAC.ASB;
using UMB_VO;

namespace Team6_UMB.Service
{
    public class MachineService
    {
        internal List<MachineVO> GetMachineInfo()
        {
            MachineDAC dac = new MachineDAC();
            return dac.GetMachineInfo();
        }
    }
}
