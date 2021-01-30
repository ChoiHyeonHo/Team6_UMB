﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMB_DAC;
using UMB_DAC.CHH;
using UMB_VO.CHH;

namespace Team6_UMB.Service
{
    class BOMService
    {
        public List<BOMVO> GetBOMInfo()
        {
            BOMDAC dac = new BOMDAC();
            return dac.GetBOMInfo();
        }
        public List<BOMVO> GetBOMInfoLv(int bomID)
        {
            BOMDAC dac = new BOMDAC();
            return dac.GetBOMInfoLv(bomID);
        }
        public List<BOMVO> GetBOMPreView(int bomPreView)
        {
            BOMDAC dac = new BOMDAC();
            return dac.GetBOMPreView(bomPreView);
        }
    }
}
