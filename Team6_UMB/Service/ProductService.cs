using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMB_DAC;
using UMB_VO;
using UMB_VO.CHH;

namespace Team6_UMB.Service
{
    public class ProductService
    {
        /// <summary>
        /// 공정명을 공통코드에서 콤보박스 바인딩을 위해 list로 가져옴
        /// </summary>
        /// <param name="gubun"></param>
        /// <returns></returns>
        public List<ComboItemVO> GetProcessInfoByCodeTypes(string[] gubun)
        {
            ProcessDAC dac = new ProcessDAC();
            return dac.GetProcessInfoByCodeTypes(gubun);
        }

        public List<ProdCBOBindingVO> GetProductInfo()
        {
            ProductDAC dac = new ProductDAC();
            return dac.GetProductInfo();
        }
    }
}
