using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MODEL;
using DAL; 

namespace 监察中心API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ArticleController : ControllerBase
    {
        //实例化dal层
        ArticleDAL dal = new ArticleDAL();

        [HttpGet]
        [EnableCors("any")]
        //调用dal层显示方法
        public ObjectResult GetArticles(string artname="", string folname="", int status=0)
        {
            var data = dal.GetArticles(artname, folname, status);
            var count = data.Count();
            return Ok(new {data=data,code=0,count=count});
        }

        [HttpGet]
        [EnableCors("any")]
        //调用dal层绑定下拉方法
        public ObjectResult GetFolder()
        {
            var data = dal.GetFolders();
            return Ok(new { data = data});
        }

        [HttpPost]
        [EnableCors("any")]
        //调用dal层添加方法
        public int Create(Article a)
        {
            return dal.AddArticle(a);
        }

        [HttpDelete]
        [EnableCors("any")]
        //调用dal层删除方法
        public int Delete([FromBody]int id)
        {
            return dal.DelArticle(id);
        }

        [HttpPost]
        [EnableCors("any")]
        //调用dal层修改方法
        public int Update(Article a)
        {
            return dal.UpdArticle(a);
        }
    }
}
