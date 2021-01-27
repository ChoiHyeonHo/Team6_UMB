using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UMB_DAC;
using UMB_VO;

namespace Team6_UMB.Service
{
    public class DepartmentService
    {
        public List<DepartmentVO> DepartmentList()
        {
            DepartmentDAC dac = new DepartmentDAC();
            return dac.DepartmentList();
        }

        public int InsertDept(DepartmentVO vo)
        {
            DepartmentDAC dac = new DepartmentDAC();
            return dac.InsertDept(vo);
        }

        public int UpdateDept(DepartmentVO vo)
        {
            DepartmentDAC dac = new DepartmentDAC();
            return dac.UpdateDept(vo);
        }

        public DepartmentVO DetailDepartment(int department_id)
        {
            DepartmentDAC dac = new DepartmentDAC();
            return dac.DetailDepartment(department_id);
        }
    }
}
