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
    public class LoginController : Controller
    {
        login lg = new login();

        [HttpGet]
        [EnableCors("any")]
        public int Login(string Number, string Password)//登录
        {
            return lg.Login(Number,Password);
        }
        [HttpPost]
        [EnableCors("any")]
        public int Registration(User u)//注册
        {
            return lg.Registration(u);
        }
    }
}
