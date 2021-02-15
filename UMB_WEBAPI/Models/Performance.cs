using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UMB_WEBAPI.Models
{
    public class Performance
    {
        public int production_edate { get; set; }
        public int performance_qty_ng { get; set; }
        public int performance_qty_ok { get; set; }
        public int ng_rate { get; set; }
        public int growth_rate { get; set; }
    }
}