using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using MODEL;
using System.Text.Json;

namespace 监察中心API.Controllers
{
    //投诉管理
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ComplainController : ControllerBase
    {
        ComplainDAL cndal = new ComplainDAL();

        [HttpGet]
        public ObjectResult GetComplain(int page,int limit,string CName = null)
        {
            int total;
            List<Complain> data = cndal.GetComplains_page(page, limit, out total, CName);
            return Ok(new { data = data, code = 0, count = total });
        }
        [HttpPost]
        public int AddComplain(Complain cn)
        {
            int i = cndal.AddComplains(cn);
            return i;
        }
        [HttpDelete]
        public int DelComplain(int CId)
        {
            int i = cndal.DelComplains(CId);
            return i;
        }
        [HttpPut]
        public int PutComplain(Complain cn)
        {
            int i = cndal.UpdateComplains(cn);
            return i;
        }

        //添加投诉举报信息_实名
        [HttpPost]
        public int AddComplains_autonym(Complain cn)
        {
            int i = cndal.AddComplains_autonym(cn);
            return i;
        }

    }
}
