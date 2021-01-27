using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UMB_VO
{
    public class MachineVO
    {
        //m_id, m_info, m_name, m_comment, m_yn, m_uadmin, m_udate
        public int? m_id { get; set; }
        public string m_info { get; set; }
        public string m_name { get; set; }
        public string m_comment { get; set; }
        public string m_yn { get; set; }
        public string m_uadmin { get; set; }
        public string m_udate { get; set; }
    }
}
