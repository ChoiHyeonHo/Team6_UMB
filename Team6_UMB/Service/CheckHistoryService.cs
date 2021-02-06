using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMB_DAC.CHH;
using UMB_VO.CHH;

namespace Team6_UMB.Service
{
    public class CheckHistoryService
    {
        public List<CheckHistoryVO> GetCheckHisInfo()
        {
            CheckHistoryDAC dac = new CheckHistoryDAC();
            return dac.GetCheckHisInfo();
        }
        public List<GetCheckTypeVO> GetCheckTypeComboBox()
        {
            CheckHistoryDAC dac = new CheckHistoryDAC();
            return dac.GetCheckTypeComboBox();
        }
        public List<CheckHistoryVO> GetCheckHisInfoWhere(string checkType)
        {
            CheckHistoryDAC dac = new CheckHistoryDAC();
            return dac.GetCheckHisInfoWhere(checkType);
        }
    }
}
