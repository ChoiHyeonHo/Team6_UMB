using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMB_DAC.CHH;
using UMB_VO.CHH;

namespace Team6_UMB.Service
{
    public class PDStockService
    {
        public List<PDStockVO> GetPDStockInfo()
        {
            PDStockDAC dac = new PDStockDAC();
            return dac.GetPDStockInfo();
        }
        public List<PDStockVO> GetPDStockWhereInfo(string strProdName, string strProdType, string strWHName)
        {
            PDStockDAC dac = new PDStockDAC();
            return dac.GetPDStockWhereInfo(strProdName, strProdType, strWHName);
        }
        public List<PDStockVO> GetPDStockPopUpInfo(string product_id)
        {
            PDStockDAC dac = new PDStockDAC();
            return dac.GetPDStockPopUpInfo(product_id);
        }
        public bool Update(PDStockVO vo)
        {
            PDStockDAC dac = new PDStockDAC();
            return dac.Update(vo);
        }
        public bool Delete(PDStockVO vo)
        {
            PDStockDAC dac = new PDStockDAC();
            return dac.Delete(vo);
        }
    }
}
