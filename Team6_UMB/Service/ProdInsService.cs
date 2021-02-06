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
    public class ProdInsService
    {
        public List<ProdInsVO> GetProdInsInfo()
        {
            ProdInsDAC dac = new ProdInsDAC();
            return dac.GetProdInsInfo();
        }
        public List<ProdInsPopUpVO> GetProdInsPopUpInfo(string temp)
        {
            ProdInsDAC dac = new ProdInsDAC();
            return dac.GetProdInsPopUpInfo(temp);
        }
        public bool UpdateAll(string ctemp, string stemp, string userName)
        {
            ProdInsDAC dac = new ProdInsDAC();
            return dac.UpdateAll(ctemp, stemp, userName);
        }
        public bool Update(string state, string componentTemp, int clPK)
        {
            ProdInsDAC dac = new ProdInsDAC();
            return dac.Update(state, componentTemp, clPK);
        }
        public DataTable GetProdCheckInfoDEV(string temp)
        {
            ProdInsDAC dac = new ProdInsDAC();
            return dac.GetProdCheckInfoDEV(temp);
        }
        public bool Comment(string pEtc, string comment, int pID)
        {
            ProdInsDAC dac = new ProdInsDAC();
            return dac.Comment(pEtc, comment, pID);
        }
        public bool InsertCheckHistory(string ctemp)
        {
            ProdInsDAC dac = new ProdInsDAC();
            return dac.InsertCheckHistory(ctemp);
        }
    }
}
