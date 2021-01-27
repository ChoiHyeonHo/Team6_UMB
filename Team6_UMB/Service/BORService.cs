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

        

        public List<BORVO> SearchBorList(string product_id, int m_id, string process_name)
        {
            BORDAC dac = new BORDAC();
            return dac.SearchBorList(product_id, m_id, process_name);
        }

        public bool BORInsert(BORVO bor)
        {
            BORDAC dac = new BORDAC();
            return dac.BORInsert(bor);
        }

        public bool BORUpdate(BORVO bor)
        {
            BORDAC dac = new BORDAC();
            return dac.BORUpdate(bor);
        }

        public bool BORDelete(int BOR_id)
        {
            BORDAC dac = new BORDAC();
            return dac.BORDelete(BOR_id);
        }
    }
}
