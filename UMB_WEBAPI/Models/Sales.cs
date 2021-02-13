using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UMB_WEBAPI.Models
{
    public class Sales
    {
        public int sales_date { get; set; }
        public string product_name { get; set; }
        public int sales_price { get; set; }
        public int growth_rate { get; set; }
    }
}