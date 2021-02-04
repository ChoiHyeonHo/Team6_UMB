using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMB_DAC.CHH;
using UMB_VO.CHH;

namespace Team6_UMB.Service
{
    public class ProdStatusService
    {
        public List<ProdStatusVO> GetProdInfo()
        {
            ProdStatusDAC dac = new ProdStatusDAC();
            return dac.GetProdInfo();
        }
        public List<GetProdNameVO> GetProdName()
        {
            ProdStatusDAC dac = new ProdStatusDAC();
            return dac.GetProdName();
        }
        public List<GetCompanyNameVO> GetCompanyName()
        {
            ProdStatusDAC dac = new ProdStatusDAC();
            return dac.GetCompanyName();
        }
        public List<GetWHNameVO> GetWHName()
        {
            ProdStatusDAC dac = new ProdStatusDAC();
            return dac.GetWHName();
        }
        public List<GetProdTypeVO> GetProdType()
        {
            ProdStatusDAC dac = new ProdStatusDAC();
            return dac.GetProdType();
        }
        public bool Insert(ProdStatusVO vo)
        {
            ProdStatusDAC dac = new ProdStatusDAC();
            return dac.Insert(vo);
        }
        public bool Update(ProdStatusVO vo)
        {
            ProdStatusDAC dac = new ProdStatusDAC();
            return dac.Update(vo);
        }
        public bool Delete(string product_id)
        {
            ProdStatusDAC dac = new ProdStatusDAC();
            return dac.Delete(product_id);
        }
        public List<ProdStatusVO> GetWhereInfo(string cbpName, string cbpType, string cbpCompany, string cbpWH, string cbpExam)
        {
            ProdStatusDAC dac = new ProdStatusDAC();
            return dac.GetWhereInfo(cbpName, cbpType, cbpCompany, cbpWH, cbpExam);
        }
        public DataTable GetBarCode(string temp)
        {
            ProdStatusDAC dac = new ProdStatusDAC();
            return dac.GetBarCode(temp);
        }
    }
}
