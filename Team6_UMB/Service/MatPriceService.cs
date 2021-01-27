using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMB_DAC.CHH;
using UMB_VO.CHH;

namespace Team6_UMB.Service
{
    class MatPriceService
    {
        public List<MatPriceVO> GetMatInfo()
        {
            MatPriceDAC dac = new MatPriceDAC();
            return dac.GetMatInfo();
        }
        public List<MatPriceVO> GetMatNInfo()
        {
            MatPriceDAC dac = new MatPriceDAC();
            return dac.GetMatNInfo();
        }
        public bool Insert(MatPriceVO vo)
        {
            MatPriceDAC dac = new MatPriceDAC();
            return dac.Insert(vo);
        }
        public bool Update(MatPriceVO vo)
        {
            MatPriceDAC dac = new MatPriceDAC();
            return dac.Update(vo);
        }
        public List<Mat_ProdCBOBindingVO> GetProdName()
        {
            MatPriceDAC dac = new MatPriceDAC();
            return dac.GetProdName();
        }
        public List<Mat_CompanyCBOBindingVO> GetCompanyNameName()
        {
            MatPriceDAC dac = new MatPriceDAC();
            return dac.GetCompanyNameName();
        }
        public bool Delete(int priceID)
        {
            MatPriceDAC dac = new MatPriceDAC();
            return dac.Delete(priceID);
        }
        public List<MatPriceVO> GetWhereInfo(string prodName, string companyName)
        {
            MatPriceDAC dac = new MatPriceDAC();
            return dac.GetWhereInfo(prodName, companyName);
        }
    }
}
