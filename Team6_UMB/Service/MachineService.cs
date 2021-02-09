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
        public List<MachineVO> CHH_GetMachineInfo()
        {
            MachineDAC dac = new MachineDAC();
            return dac.CHH_GetMachineInfo();
        }
        public bool CHH_MachineInsert(MachineVO vo)
        {
            MachineDAC dac = new MachineDAC();
            return dac.CHH_MachineInsert(vo);
        }
        public bool CHH_MachineUpdate(MachineVO vo)
        {
            MachineDAC dac = new MachineDAC();
            return dac.CHH_MachineUpdate(vo);
        }
        public bool CHH_MachineDelete(int m_id)
        {
            MachineDAC dac = new MachineDAC();
            return dac.CHH_MachineDelete(m_id);
        }
        public List<MachineVO> CHH_MachineWhere(string m_name)
        {
            MachineDAC dac = new MachineDAC();
            return dac.CHH_MachineWhere(m_name);
        }
    }
}
