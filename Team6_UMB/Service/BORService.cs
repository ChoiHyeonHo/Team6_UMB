using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMB_DAC;
using UMB_VO;

namespace Team6_UMB.Service
{
    class BORService
    {
        public List<BORVO> GetBORList()
        {
            BORDAC dac = new BORDAC();
            return dac.GetBORList();
        }

        internal void BORInsert()
        {
            BORDAC dac = new BORDAC();
            //return dac.BORInsert();
        }
    }
}
