using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMB_DAC.CHH;
using UMB_VO.CHH;

namespace Team6_UMB.Service
{
    public class CompanyService
    {
        public List<CompanyVO> GetCompanyInfo()
        {
            CompanyDAC dac = new CompanyDAC();
            return dac.GetCompanyInfo();
        }
        public List<CompanyTypeVO> GetCompanyType()
        {
            CompanyDAC dac = new CompanyDAC();
            return dac.GetCompanyType();
        }
        public bool Insert(CompanyVO vo)
        {
            CompanyDAC dac = new CompanyDAC();
            return dac.Insert(vo);
        }

        public bool Update(CompanyVO vo)
        {
            CompanyDAC dac = new CompanyDAC();
            return dac.Update(vo);
        }
        public bool Delete(int ID)
        {
            CompanyDAC dac = new CompanyDAC();
            return dac.Delete(ID);
        }
        public List<CompanyVO> GetWhereInfo(string cbName, string cbType)
        {
            CompanyDAC dac = new CompanyDAC();
            return dac.GetWhereInfo(cbName, cbType);
        }
    }
}
