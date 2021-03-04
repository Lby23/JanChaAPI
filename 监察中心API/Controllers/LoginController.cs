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
    public class Log
    {
        public string Number { get; set; }
        public string Password { get; set; }
    }
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : Controller
    {
        login lg = new login();

        [HttpGet]
        [EnableCors("any")]
        public ObjectResult Login(string Number = "",string Password = "")//登录
        {
            var data = lg.Login(Number, Password);
            return Ok(data);
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

        [HttpPut]
        [EnableCors("any")]
        public int Update(User u)
        {
            return lg.Updatepass(u);
        }

    }
    
}
