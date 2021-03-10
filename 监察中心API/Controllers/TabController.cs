using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MODEL;
using DAL;
using Microsoft.AspNetCore.Cors;

namespace 监察中心API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TabController : Controller
    {
        Tab tab = new Tab();
        [HttpGet]
        [EnableCors("any")]
        public List<tab> Index()
        {
            return tab.GetTabs();
        }

        [HttpPost]
        [EnableCors("any")]
        public int Add(tab u)
        {
            return tab.Add(u);
        }
    }
}
