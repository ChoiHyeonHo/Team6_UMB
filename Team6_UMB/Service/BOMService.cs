using System;
using System.Collections.Generic;
using System.Data;
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
        public List<BOMVO> GetBOMPreView(int bomID)
        {
            BOMDAC dac = new BOMDAC();
            return dac.GetBOMPreView(bomID);
        }
        public List<BOMVO> GetBOMCBProdName()
        {
            BOMDAC dac = new BOMDAC();
            return dac.GetBOMCBProdName();
        }
        public List<BOMVO> GetBOMWhereInfo(int level, string prodName, string prodType)
        {
            BOMDAC dac = new BOMDAC();
            return dac.GetBOMWhereInfo(level, prodName, prodType);
        }
        public bool Insert(BOMVO vo)
        {
            BOMDAC dac = new BOMDAC();
            return dac.Insert(vo);
        }
        public bool Update(BOMVO vo)
        {
            BOMDAC dac = new BOMDAC();
            return dac.Update(vo);
        }
        public bool Delete(int BOMID)
        {
            BOMDAC dac = new BOMDAC();
            return dac.Delete(BOMID);
        }
    }
}
