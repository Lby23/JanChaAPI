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
            int tol;

            List<Questionnaire> St = dl.GetQuestionnaires(page, limit, out tol, title);
            return Ok(new { code = 0, msg = "", count = tol, data = St });
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

        [HttpPost]
        [Route("topic")]
        public int AddTop(Topic s)
        {
            return dl.AddTopic(s);
        }

        [HttpPost]
        [Route("option")]
        public int AddOpt(Options s)
        {
            return dl.AddOption(s);
        }

        [HttpGet]
        [Route("topic")]
        public ObjectResult GetTop(int id)
        {
            List<Topic> data = dl.GetTopics(id);

            int tal = data.Count;

            return Ok(new { code = 0, msg = "", count = tal, data = data });
        }
        [Route("topic1")]
        [HttpGet]
        public List<Topic> GETTop1()
        {
            return dl.GetTopicsCx();
        }
        [Route("option1")]
        [HttpGet]
        public List<Options> GetOptions1()
        {
            return dl.GetOptionsCx();
        }

        [Route("subon")]
        [HttpPost]
        public int AddSpion(SubmitOption s)
        {
            return dl.AddSOption(s);
        }

        [Route("up")]
        [HttpPost]

        public int Updatequ(int id)
        {
            return dl.UpdateQes(id);
        }
    }
}
