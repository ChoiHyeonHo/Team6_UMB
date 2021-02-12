using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMB_DAC;
using UMB_VO;

namespace Team6_UMB.Service
{
    class ShiftService
    {
        public List<ShiftVO> ShiftList()
        {
            ShiftDAC dac = new ShiftDAC();
            return dac.ShiftList();
        }

        public List<cboMachineVO> cboMachine()
        {
            ShiftDAC dac = new ShiftDAC();
            return dac.cboMachine();
        }

        public int InsertShift(ShiftVO vo)
        {
            ShiftDAC dac = new ShiftDAC();
            return dac.InsertShift(vo);
        }

        public int UpdateShift(ShiftVO vo)
        {
            ShiftDAC dac = new ShiftDAC();
            return dac.UpdateShift(vo);
        }

        public int DeleteShift(int shift_id)
        {
            ShiftDAC dac = new ShiftDAC();
            return dac.DeleteShift(shift_id);
        }
    }
}
