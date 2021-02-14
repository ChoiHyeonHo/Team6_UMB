using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMB_DAC;
using UMB_DAC.ASB;
using UMB_DAC.CHH;
using UMB_VO;
using UMB_VO.ASB;
using UMB_VO.CHH;

namespace Team6_UMB.Service
{
    public class DefService
    {
        public List<ComboItemVO> GetDefList()
        {
            WorkOrderDAC dac = new WorkOrderDAC();
            return dac.GetDefList();
        }

        public bool DefInsert(ComboItemVO def)
        {
            WorkOrderDAC dac = new WorkOrderDAC();
            return dac.DefInsert(def);
        }

        public int GetDefID(string common_name)
        {
            WorkOrderDAC dac = new WorkOrderDAC();
            return dac.GetDefID(common_name);
        }

        public bool DefUpdate(ComboItemVO def)
        {
            WorkOrderDAC dac = new WorkOrderDAC();
            return dac.DefUpdate(def);
        }

        public bool DefDelete(int common_id)
        {
            WorkOrderDAC dac = new WorkOrderDAC();
            return dac.DefDelete(common_id);
        }

        public List<DefectiveVO> GetDefStatus()
        {
            DefetiveDAC dac = new DefetiveDAC();
            return dac.GetDefStatus();
        }

        public List<DefectiveVO> SearchDefList(string pid, string pname)
        {
            DefetiveDAC dac = new DefetiveDAC();
            return dac.SearchDefList(pid ,pname);
        }
    }
}
