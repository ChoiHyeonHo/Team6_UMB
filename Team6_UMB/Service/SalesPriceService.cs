using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMB_DAC.CHH;
using UMB_VO.CHH;

namespace Team6_UMB.Service
{
    class SalesPriceService
    {
        public List<SalesPriceVO> GetRegistOrderInfo()
        {
            SalesPriceDAC dac = new SalesPriceDAC();
            return dac.GetSalesPriceInfo();
        }

        public List<ProdCBOBindingVO> GetProdName()
        {
            SalesPriceDAC dac = new SalesPriceDAC();
            return dac.GetProdName();
        }

        public List<CompanyCBOBindingVO> GetCompanyName()
        {
            SalesPriceDAC dac = new SalesPriceDAC();
            return dac.GetCompanyName();
        }

        public bool Insert(SalesPriceVO vo)
        {
            SalesPriceDAC dac = new SalesPriceDAC();
            return dac.Insert(vo);
        }
    }
}
