using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using DAL;
using MODEL;
using Microsoft.AspNetCore.Cors;
namespace 监察中心API.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("any")]
    [ApiController]
    //[EnableCors("any")]
    public class QuestionnaireController : ControllerBase//问卷调查控制器
    {
        QuestionnaireDal dl = new QuestionnaireDal();
        [HttpGet]
        public ObjectResult GetAction(int page, int limit, string title = null)
        {
            List<Questionnaire> St = dl.GetQuestionnaires(page, limit, title);
            int total = dl.GetQuestionnaires(page, limit, title).Count();
            St = St.Skip((page - 1) * limit).Take(limit).ToList();
            return Ok(new { code = 0, msg = "", count = total, data = St});
        }
        [Route("delete")]
        [HttpDelete]
        public int DeleteId(int id)
        {
            return dl.QuestionnaireDelete(id);
        }

        [HttpPost]
        public int Add(Questionnaire s)
        {
            return dl.QuestionnaireAdd(s);
        }

        [HttpPost]
        [Route("edit")]
        public int Edit(Questionnaire s)
        {
            return dl.QuestionnaireEdit(s);
        }
    }
}
