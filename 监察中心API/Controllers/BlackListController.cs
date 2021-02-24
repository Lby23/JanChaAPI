using DAL;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace 监察中心API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlackListController : ControllerBase
    {

        BlackListDAL blDaL = new BlackListDAL();

        [HttpGet]
        [EnableCors("any")]
        //黑名单显示查询
        public List<Blacklist> GetBlacklist(string BUnit)
        {
            return blDaL.GetBlacklists(BUnit);
        }
        [HttpPost]
        [EnableCors("any")]
        //黑名单添加
        public int AddBlacklist(Blacklist bl)
        {
            return blDaL.AddBlacklist(bl);
        }
    }
}
