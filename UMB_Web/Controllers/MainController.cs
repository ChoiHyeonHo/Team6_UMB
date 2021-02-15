using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using UMB_WEB.Models;
using UMB_WEBAPI.DAC;
using UMB_WEBAPI.Models;

namespace UMB_WEB.Controllers
{
    public class MainController : Controller
    {
        
        // GET: Main
        public ActionResult Index()
        {
            Sales sale = new Sales();
            MainDAC dac = new MainDAC();
            sale = dac.GetSales();
            ViewBag.growth_rate = sale.growth_rate;
            ViewBag.sales_price = sale.sales_price;
            Performance per = new Performance();
            per = dac.GetPerformance();
            ViewBag.Per_gr = per.growth_rate;
            ViewBag.Per_ng = per.ng_rate;
            List<Performance> perList = new List<Performance>();
            perList = dac.GetPerList();
            ViewBag.performance = perList;

            return View();
        }
    }
}