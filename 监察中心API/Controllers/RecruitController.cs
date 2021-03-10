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
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class RecruitController : ControllerBase
    {
        RecruitDAL rcdal = new RecruitDAL();
        [HttpGet]
        public ObjectResult GetRecruits(int page, int limit, string RPosition = null)
        {
            int total;
            List<Recruit> data = rcdal.GetRecruits_page(page, limit, out total, RPosition);
            return Ok(new { data = data, code = 0, count = total });
        }
        [HttpGet]
        public List<Recruit> GetRecruits_RTYPE(string Rtype)
        {
            List<Recruit> data = rcdal.GetRecruitsType(Rtype);
            return data;
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
