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
            Sales model = new Sales();
            MainDAC dac = new MainDAC();
            model = dac.GetSales();

            return View(model);
        }
    }
}