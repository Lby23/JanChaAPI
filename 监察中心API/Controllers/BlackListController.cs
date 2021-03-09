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
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BlackListController : ControllerBase
    {

        BlackListDAL blDaL = new BlackListDAL();

        [HttpGet]
        public int GetBlacklists_front(string Bunit, string BpapersNumber)
        {
            List<Blacklist> data = blDaL.GetBlacklists_front(Bunit, BpapersNumber);
            int i = data.Count();
            return i;
        }
        [HttpGet]
        public int GetBlacklists_onePerson(string Bunit, string BpapersNumber)
        {
            List<Blacklist> data = blDaL.GetBlacklists_onePerson(Bunit, BpapersNumber);
            int i = data.Count();
            return i;
        }

        [HttpGet]
        //黑名单显示查询
        public ObjectResult GetBlacklist(int page, int limit, string BUnit = null)
        {
            int total;
            List<Blacklist> data = blDaL.GetBlacklists_page(page, limit, out total, BUnit);
            return Ok(new { data = data, code = 0, count = total });
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
