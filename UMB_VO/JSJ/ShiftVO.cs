using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMB_VO
{
    public class ShiftVO
    {
        public int shift_id { get; set; }
        public int m_id { get; set; }
        public string shift_stime { get; set; }
        public string shift_etime { get; set; }
        public string shift_sdate { get; set; }
        public string shift_edate { get; set; }
        public string shift_yn { get; set; }
        public string shift_comment { get; set; }
        public string shift_uadmin { get; set; }
        public string shift_udate { get; set; }
        public int shift_personnel { get; set; }
        public string shift_weekend { get; set; }
        public string shift_dns { get; set; }
    }

    public class cboMachineVO
    {
        public int m_id { get; set; }
        public string m_name { get; set; }
    }
}
