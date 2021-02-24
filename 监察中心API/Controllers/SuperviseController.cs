using Microsoft.AspNetCore.Http;
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
    [Route("api/[controller]")]
    [ApiController]
    public class SuperviseController : ControllerBase
    {
        SuperviseDal dl = new SuperviseDal();
        BlackListDAL blDaL = new BlackListDAL();

        [HttpGet]
        [EnableCors("any")]
        public List<User> Index()
        {
            return dl.GetUsers();
        }
        //黑名单显示查询
        public List<Blacklist> GetBlacklist(string BUnit)
        {
            return blDaL.GetBlacklists(BUnit);
        }
        //黑名单添加
        public int AddBlacklist(Blacklist bl)
        {
            return blDaL.AddBlacklist(bl);
        }
    }
}
