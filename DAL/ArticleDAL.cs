using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;
using MODEL;

namespace DAL
{
    public class ArticleDAL
    {
        //文章管理查询显示
        public List<Article> GetArticles(int artname, string folname, int status,int page,int limit,out int total)
        {
            SqlParameter[] paras =
                {
                new SqlParameter("@pageIndex",page),
                new SqlParameter("@PageSize",limit),
                new SqlParameter("@Artname",artname),
                new SqlParameter("@folname",folname),
                new SqlParameter("@status",status),
                new SqlParameter("@TotalCount",SqlDbType.Int),
            };
            paras[5].Direction = ParameterDirection.Output;
            DataTable dt = NewDBHelper.GetTable("p_page_article", CommandType.StoredProcedure, paras);
            
            total = Convert.ToInt32(paras[5].Value);
            string json = JsonConvert.SerializeObject(dt);
            var list = JsonConvert.DeserializeObject<List<Article>>(json);
            return list;
        }

        //栏目绑定下拉框
        public List<Folder> GetFolders()
        {
            string strSql = $"select * from folder";
            return NewDBHelper.GetList<Folder>(strSql);
        }

        //文章管理添加
        public int AddArticle(Article a)
        {
            string strSql = $"insert into article values('{a.FolderId}','{a.Title}','{a.Sort}','{a.Status}','1','{a.IsComment}','{a.IsRecommend}','1'," +
                $"getdate(),'{a.StartTime}','{a.EndTime}','{a.Type}','{a.JumpUrl}','{a.Image}','{a.CreatePeople}')";
            return NewDBHelper.ExecuteNonQuery(strSql);
        }

        //文章管理删除
        public int DelArticle(int id) 
        {
            string strSql = $"delete from article where id='{id}'";
            return NewDBHelper.ExecuteNonQuery(strSql);
        }

        //文章管理修改
        public int UpdArticle(Article a)
        {
            string strSql = $"update article set FolderId='{a.FolderId}',Title='{a.Title}',Sort='{a.Sort}',Status='{a.Status}',IsUp='1',IsComment='{a.IsComment}'," +
                $"IsRecommend='{a.IsRecommend}',ApproveStatus='1',CreateTime='{a.CreateTime}',StartTime='{a.StartTime}',EndTime='{a.EndTime}'," +
                $"Type='{a.Type}',JumpUrl='{a.JumpUrl}',Image='{a.Image}',CreatePeople='{a.CreatePeople}' where Id='{a.Id}'";
            return NewDBHelper.ExecuteNonQuery(strSql);
        }

        //文章管理
    }
}
