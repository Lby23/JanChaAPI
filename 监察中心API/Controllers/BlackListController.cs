using DAL;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MODEL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;

namespace 监察中心API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlackListController : ControllerBase
    {

        BlackListDAL blDaL = new BlackListDAL();

        [HttpGet]
        //黑名单显示查询
        public string GetBlacklist(string BUnit,int page,int limit)
        {
            List<Blacklist> data = blDaL.GetBlacklists(BUnit);
            int count = data.Count();
            data = data.Skip((page - 1) * limit).Take(limit).ToList();
            var json = JsonSerializer.Serialize(new { data = data, code = 0, count = count });
            return json;
        }
        [HttpPost]
        //黑名单添加
        public int AddBlacklist(Blacklist bl)
        {
            int i = blDaL.AddBlacklist(bl);
            return i;
        }
        [HttpDelete]
        //删除黑名单信息
        public int DelBlacklist(int Bid)
        {
            int i = blDaL.DelBlacklist(Bid);
            return i;
        }
        [HttpPut]
        //修改黑名单信息
        public int UpdateBlacklist(Blacklist bl)
        {
            int i = blDaL.UpdateBlacklist(bl);
            return i;
        }
    }
}
