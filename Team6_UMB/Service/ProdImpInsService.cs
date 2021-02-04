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
    public class ProdImpInsService
    {
        public List<ProdImpInsVO> GetIncomminInfo()
        {
            ProdImpInsDAC dac = new ProdImpInsDAC();
            return dac.GetIncomminInfo();
        }
        public List<InsCheckVO> GetInsCheckInfo(string temp)
        {
            ProdImpInsDAC dac = new ProdImpInsDAC();
            return dac.GetInsCheckInfo(temp);
        }

        public DataTable GetInsCheckInfoDEV(string temp)
        {
            ProdImpInsDAC dac = new ProdImpInsDAC();
            return dac.GetInsCheckInfoDEV(temp);
        }
        public bool Update(string pTemp, string cl_inc_Color, int cl_inc_id)
        {
            ProdImpInsDAC dac = new ProdImpInsDAC();
            return dac.Update(pTemp, cl_inc_Color, cl_inc_id);
        }
        public bool Comment(string pEtc, string comment, int pID)
        {
            ProdImpInsDAC dac = new ProdImpInsDAC();
            return dac.Comment(pEtc, comment, pID);
        }
    }
}
