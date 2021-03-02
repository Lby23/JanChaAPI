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
    [Route("api/[controller]")]
    [ApiController]
    public class ComplainController : ControllerBase
    {
        ComplainDAL cndal = new ComplainDAL();

        [HttpGet]
        public string GetComplain(int page,int limit,string CName = null)
        {
            List<Complain> data = cndal.GetComplains(CName);
            int count = data.Count;
            data = data.Skip((page - 1) * limit).Take(limit).ToList();
            var json = JsonSerializer.Serialize(new { data = data, code = 0, count = count });
            return json;
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
    }
}
