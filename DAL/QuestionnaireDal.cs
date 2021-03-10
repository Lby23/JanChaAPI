using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using MODEL;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;
namespace DAL
{
    public class QuestionnaireDal//问卷调查DAL层
    {
        public List<Questionnaire> GetQuestionnaires(int page, int limit,out int total,string title)
        {
            SqlParameter[] para =
            {
                new SqlParameter{ParameterName="@pageIndex",DbType= DbType.Int32,Value=page },
                new SqlParameter{ParameterName="@pageSize",DbType= DbType.Int32,Value=limit },
                new SqlParameter{ParameterName="@title",DbType= DbType.String,Value=title },
                new SqlParameter{ParameterName="@totalCount",Direction= ParameterDirection.Output,DbType= DbType.Int32 },
            };

            DataTable st = NewDBHelper.GetTable("p_Questionnaire", CommandType.StoredProcedure, para);

            total = (int)para[3].Value;

            string json = JsonConvert.SerializeObject(st);
            List<Questionnaire> data = JsonConvert.DeserializeObject<List<Questionnaire>>(json);

            return data;
        }

        public int QuestionnaireDelete(int id)
        {
            string sql = "delete from Questionnaire where QuesId=@id";
            SqlParameter[] para =
            {
                new SqlParameter{ParameterName="@id",DbType= DbType.Int32,Value=id }
            };
            return NewDBHelper.ExecuteNonQuery(sql,CommandType.Text,para);
        }

        public int QuestionnaireAdd(Questionnaire s)
        {
            s.Sno = DateTime.Now.ToString("yyyyMMddHHffss");
            s.Snum =0;
            s.CreateTime = DateTime.Now;
            s.CreatePeople = "超级管理员";
            string sql = "insert into Questionnaire values(@Title,@Sno,@Qsale,@Snum,@CreateTime,@CreatePeople,@BeginMs,@EndMs)";
            SqlParameter[] para =
            {
                new SqlParameter{ ParameterName="@Title",DbType= DbType.String,Value=s.Title},
                new SqlParameter{ ParameterName="@Sno",DbType= DbType.String,Value=s.Sno},
                new SqlParameter{ ParameterName="@Qsale",DbType= DbType.Int32,Value=s.Qsale},
                new SqlParameter{ ParameterName="@Snum",DbType= DbType.Int32,Value=s.Snum},
                new SqlParameter{ ParameterName="@CreateTime",DbType= DbType.DateTime,Value=s.CreateTime},
                new SqlParameter{ ParameterName="@CreatePeople",DbType= DbType.String,Value=s.CreatePeople},
                new SqlParameter{ ParameterName="@BeginMs",DbType= DbType.String,Value=s.BeginMs},
                new SqlParameter{ ParameterName="@EndMs",DbType= DbType.String,Value=s.EndMs}
            };
            return NewDBHelper.ExecuteNonQuery(sql,CommandType.Text,para);
        }

        public int QuestionnaireEdit(Questionnaire s)
        {
            s.Sno = DateTime.Now.ToString("yyyyMMddHHffss");
            s.Snum = 5;
            s.CreateTime = DateTime.Now;
            s.CreatePeople = "超级管理员";
            string sql = "update Questionnaire set Title=@Title,Sno=@Sno,Qsale=@Qsale,Snum=@Snum,CreateTime=@CreateTime,CreatePeople=@CreatePeople,BeginMs=@BeginMs,EndMs=@EndMs where QuesId=@QuesId";
            SqlParameter[] para =
            {
                new SqlParameter{ ParameterName="@Title",DbType= DbType.String,Value=s.Title},
                new SqlParameter{ ParameterName="@Sno",DbType= DbType.String,Value=s.Sno},
                new SqlParameter{ ParameterName="@Qsale",DbType= DbType.Int32,Value=s.Qsale},
                new SqlParameter{ ParameterName="@Snum",DbType= DbType.Int32,Value=s.Snum},
                new SqlParameter{ ParameterName="@CreateTime",DbType= DbType.DateTime,Value=s.CreateTime},
                new SqlParameter{ ParameterName="@CreatePeople",DbType= DbType.String,Value=s.CreatePeople},
                new SqlParameter{ ParameterName="@BeginMs",DbType= DbType.String,Value=s.BeginMs},
                new SqlParameter{ ParameterName="@EndMs",DbType= DbType.String,Value=s.EndMs},
                new SqlParameter{ParameterName="@QuesId",DbType= DbType.String,Value=s.QuesId}
            };
            return NewDBHelper.ExecuteNonQuery(sql,CommandType.Text,para);
        }


        //题目添加
        public int AddTopic(Topic t)
        {
            string sql = "insert into Topic values(@Choice,@Issue,@TqueId)";
            SqlParameter[] para =
            {
                new SqlParameter{ ParameterName="@Choice",DbType= DbType.String,Value=t.Choice},
                new SqlParameter{ ParameterName="@Issue",DbType= DbType.String,Value=t.Issue},
                new SqlParameter{ ParameterName="@TqueId",DbType= DbType.Int32,Value=t.TqueId}
            };
            return NewDBHelper.ExecuteNonQuery(sql, CommandType.Text, para);
        }

        //选项添加
        public int AddOption(Options t)
        {
            string sql = "insert into Options values(@Oname,@Otid)";
            SqlParameter[] para =
            {
                new SqlParameter{ ParameterName="@Oname",DbType= DbType.String,Value=t.Oname},
                new SqlParameter{ ParameterName="@Otid",DbType= DbType.Int32,Value=t.Otid}
            };
            return NewDBHelper.ExecuteNonQuery(sql, CommandType.Text, para);
        }

        //题目的显示
        public List<Topic> GetTopics(int id)
        {
            string sql = "select t.Choice,t.Issue,t.TopicId,t.TqueId from Topic t join Questionnaire q on t.TqueId = q.QuesId where t.TqueId=@id";

            SqlParameter[] para =
            {
                new SqlParameter{ ParameterName="@id",DbType= DbType.Int32,Value=id}
            };
            return NewDBHelper.GetList<Topic>(sql,CommandType.Text,para);
        }

        //调查问卷题目查询
        public List<Topic> GetTopicsCx()
        {
            string sql = "select Choice,Issue,TopicId from Questionnaire join Topic on QuesId = TqueId where Qsale=1";

            return NewDBHelper.GetList<Topic>(sql);
        }
        //调查问卷选项查询
        public List<Options> GetOptionsCx()
        {
            string sql = "select Oid, Oname, Otid, TopicId, Choice, Issue,TopicId,QuesId from Questionnaire join Topic on QuesId=TqueId join Options on Otid=TopicId";
            return NewDBHelper.GetList<Options>(sql);
        }


        public int AddSOption(SubmitOption s)
        {
            string sql = "insert into Wjtj values(@Wqid,@WOid,@Listid)";
            SqlParameter[] para =
            {
                new SqlParameter{ ParameterName="@Wqid",DbType= DbType.Int32,Value=s.Wqid},
                new SqlParameter{ ParameterName="@WOid",DbType= DbType.Int32,Value=s.WOid},
                new SqlParameter{ ParameterName="@Listid",DbType= DbType.String,Value=s.Listid},
            };
            return NewDBHelper.ExecuteNonQuery(sql,CommandType.Text,para);
        }

        public int UpdateQes(int id)
        {
            string sql = "update Questionnaire set Snum=Snum+1 where QuesId=@id";
            SqlParameter[] para =
            {
                new SqlParameter{ParameterName="@id",DbType= DbType.Int32,Value=id}
            };
            return NewDBHelper.ExecuteNonQuery(sql,CommandType.Text,para);
        }
    }
}
