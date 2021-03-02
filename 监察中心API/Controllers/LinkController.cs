using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DAL;
using MODEL;
namespace 监察中心API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("any")]
    public class LinkController : ControllerBase
    {
        LinkDal dl =new LinkDal();
        [HttpGet]
        public ObjectResult GetLinks(int page, int limit, string URL = null)
        {
            List<Link> St = dl.GetLink(page, limit, URL);
            int total = dl.GetLink(page, limit, URL).Count();
            St = St.Skip((page - 1) * limit).Take(limit).ToList();
            return Ok(new { code = 0, msg = "", count = total, data = St });
        }
        [Route("delete")]
        [HttpDelete]
        public int DeleteId(int id)
        {
            return dl.LinkDelete(id);
        }

        [HttpPost]
        public int Add(Link s)
        {
            return dl.LinkAdd(s);
        }

        [HttpPut]
        public int Edit(Link s)
        {
            return dl.LinkEdit(s);
        }
    }
}
