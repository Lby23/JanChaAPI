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
    public class LoginController : Controller
    {
        login lg = new login();

        [HttpPost]
        [EnableCors("any")]
        public int Login(User data)//登录
        {
            return lg.Login(data.Number, data.Password);
        }
        [HttpPost]
        [EnableCors("any")]
        public int Registration([FromBody] User u)//注册
        {
            return lg.Registration(u);
        }

        [HttpGet]
        [EnableCors("any")]
        public List<User> GetUsers()
        {
            return lg.GetUsers();
        }
    }
}
