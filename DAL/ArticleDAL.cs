using System;
using System.Collections.Generic;
using System.Text;
using MODEL;

namespace DAL
{
    public class ArticleDAL
    {
        //文章管理查询显示
        public List<Article> GetArticles(string artname, string folname, int status)
        {
            string strSql = "select * from article join folder on article.Folder_Id =folder.Id";
            strSql += " and 1=1";
            if (!string.IsNullOrEmpty(artname))
            {
                strSql += $"where folder.Name like '%{artname}%'";
            }
            if (!string.IsNullOrEmpty(folname))
            {
                strSql += $"where article.Name like '%{folname}%'";
            }
            if (status != 0)
            {
                strSql += $"where article.Status = '{status}'";
            }
            return NewDBHelper.GetList<Article>(strSql);
        }

        //文章管理添加
        public int AddArticle(Article a)
        {
            string strSql = $"insert into article values('{a.FolderId}','{a.Title}','{a.Sort}','{a.Status}','{a.IsUp}','{a.IsComment}','{a.IsRecommend}','{a.ApproveStatus}','{a.CreateTime}','{a.StartTime}','{a.EndTime}','{a.Type}','{a.JumpUrl}','{a.Image}','{a.CreatePeople}')";
            return NewDBHelper.ExecuteNonQuery(strSql);
        }

        //文章管理删除
        public int DelArticle(int id) 
        {
            string strSql = $"delete from article where id='{id}'";
            return NewDBHelper.ExecuteNonQuery(strSql);
        }


    }
}
