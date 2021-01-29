using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMB_DAC.ASB;
using UMB_VO;
using UMB_VO.ASB;

namespace Team6_UMB.Service
{
    public class CheckListService
    {
        public List<CheckListVO> GetChkList()
        {
            CheckListDAC dac = new CheckListDAC();
            return dac.GetChkList();
        }

        public List<ComboItemVO> GetCheckTypeInfoByCodeTypes(string[] gubun)
        {
            CheckListDAC dac = new CheckListDAC();
            return dac.GetCheckTypeInfoByCodeTypes(gubun);
        }

        public List<CheckListVO> SearchChkList(string checkType)
        {
            CheckListDAC dac = new CheckListDAC();
            return dac.SearchChkList(checkType);
        }

        public bool ChkInsert(CheckListVO chk)
        {
            CheckListDAC dac = new CheckListDAC();
            return dac.ChkInsert(chk);
        }

        public bool ChkUpdate(CheckListVO chk)
        {
            CheckListDAC dac = new CheckListDAC();
            return dac.ChkUpdate(chk);
        }

        public bool ChkDelete(int cl_id)
        {
            CheckListDAC dac = new CheckListDAC();
            return dac.ChkDelete(cl_id);
        }
    }
}
