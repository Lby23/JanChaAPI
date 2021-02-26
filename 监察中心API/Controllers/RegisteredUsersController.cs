using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using MODEL;
using Microsoft.AspNetCore.Cors;

namespace 监察中心API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RegisteredUsersController : ControllerBase
    {
        RegisteredUsers dal = new RegisteredUsers();

        [HttpGet]
        [EnableCors("any")]
        public ObjectResult GetUsers(int page=1, int limit=5, string UserName=null, string Number=null)//显示注册的人员和查找人员
        {
            var str= dal.GetUsers(page, limit,UserName,Number);
            int total = str.Count(); 
            return Ok(new { code = 0, msg = "", count = total, data = str, page = page, limit = limit });
        }

        [HttpGet]
        [EnableCors("any")]
        public List<User> GetUserOne(int UId)//显示当前Id人员的信息
        {
            return dal.GetUserOne(UId);
        }

        [HttpDelete]
        [EnableCors("any")]
        public int Delete(int UId)//删除
        {
            int result= dal.Delete(UId);
            return result;
        }

        [HttpPut]
        [EnableCors("any")]
        public int Enlt(User u)//修改
        {
            return dal.Enlt(u);
        }
    }
}
