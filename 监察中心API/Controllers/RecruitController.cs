using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MODEL;
using DAL;
using System.Text.Json;

namespace 监察中心API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecruitController : ControllerBase
    {
        RecruitDAL rcdal = new RecruitDAL();
        [HttpGet]
        public string GetRecruits(string RPosition,int page,int limit)
        {
            List<Recruit> data = rcdal.GetRecruits(RPosition);
            int count = data.Count();
            data = data.Skip((page - 1) * limit).Take(limit).ToList();
            var json = JsonSerializer.Serialize(new { data = data, code = 0, count = count });
            return json;
        }
        [HttpPost]
        public int AddRecruits(Recruit rc)
        {
            int i = rcdal.AddRecruits(rc);
            return i;
        }
        [HttpDelete]
        public int DeleteRecruits(int RId)
        {
            int i = rcdal.DeleteRecruits(RId);
            return i;
        }
        [HttpPut]
        public int UpdateRecruits(Recruit rc)
        {
            int i = rcdal.UpdateRecruits(rc);
            return i;
        }
    }
}
