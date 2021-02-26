using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using MODEL;
namespace DAL
{
    public class QuestionnaireDal//问卷调查DAL层
    {
        public List<Questionnaire> GetQuestionnaires(int page, int limit,string title)
        {
            string sql = "select * from Questionnaire where 1=1";

            if (!string.IsNullOrEmpty(title))
            {
                sql += $" and Title='{title}'";
            }

            List<Questionnaire> data= NewDBHelper.GetList<Questionnaire>(sql);
            return data.Skip((page - 1) * limit).Take(limit).ToList();
        }

        public int QuestionnaireDelete(int id)
        {
            string sql = $"delete from Questionnaire where QuesId={id}";
            return NewDBHelper.ExecuteNonQuery(sql);
        }

        public int QuestionnaireAdd(Questionnaire s)
        {
            s.Sno = "176384";
            s.Snum = 5;
            s.CreateTime = DateTime.Now;
            s.CreatePeople = "李嘉诚";
            s.TopicId = 1;
            string sql = $"insert into Questionnaire values('{s.Title}','{s.Sno}','{s.Qsale}',{s.Snum},'{s.CreateTime}','{s.CreatePeople}','{s.BeginMs}','{s.EndMs}',{s.TopicId})";

            return NewDBHelper.ExecuteNonQuery(sql);
        }
    }
}
