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
        public List<SalesPriceVO> GetSalesPriceNInfo()
        {
            SalesPriceDAC dac = new SalesPriceDAC();
            return dac.GetSalesPriceNInfo();
        }

        public List<SalesPriceVO> GetWhereInfo(string prodName, string companyName)
        {
            SalesPriceDAC dac = new SalesPriceDAC();
            return dac.GetWhereInfo(prodName, companyName);
        }

        public List<SalesPriceVO> GetSalesPriceYInfo()
        {
            SalesPriceDAC dac = new SalesPriceDAC();
            return dac.GetSalesPriceYInfo();
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

        public bool Update(SalesPriceVO vo)
        {
            SalesPriceDAC dac = new SalesPriceDAC();
            return dac.Update(vo);
        }

        public bool Delete(int priceID)
        {
            SalesPriceDAC dac = new SalesPriceDAC();
            return dac.Delete(priceID);
        }
        public List<SalesPriceVO> SearchProdID(string prodName)
        {
            SalesPriceDAC dac = new SalesPriceDAC();
            return dac.SearchProdID(prodName);
        }
        public List<SalesPriceVO> SearchCompanyID(string companyName)
        {
            SalesPriceDAC dac = new SalesPriceDAC();
            return dac.SearchCompanyID(companyName);
        }
    }
}
