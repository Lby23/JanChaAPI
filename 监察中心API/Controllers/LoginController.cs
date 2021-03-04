﻿using Microsoft.AspNetCore.Mvc;
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

        [HttpGet]
        [EnableCors("any")]
        public ObjectResult Login(string Number="",string Password="")//登录
        {
            string str = "";
            str = lg.GetMd5String(Password);
            return Ok(lg.Login(Number,str));
        }
        [HttpPost]
        [EnableCors("any")]
        public int Registration([FromBody] User u)//注册
        {
            return lg.Registration(u);
        }

        

    }
    
}
