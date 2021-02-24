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

        [HttpGet]
        [EnableCors("any")]
        public List<User> Index()
        {
            return dl.GetUsers();
        }
    }
}
