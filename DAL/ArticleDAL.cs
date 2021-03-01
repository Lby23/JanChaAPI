using System;
using System.Collections.Generic;
using System.Text;
using MODEL;

namespace DAL
{
    public class ArticleDAL
    {
        //文章管理查询显示
        public List<Article> GetArticles(int artname, string folname, int status,int page,int limit)
        {
            string strSql = "select article.*,folder.Name from article join folder on article.FolderId =folder.Id";
            strSql += " and 1=1";
            if (artname != 0)
            {
                strSql += $"where article.folderId = '{artname}'";
            }
            if (!string.IsNullOrEmpty(folname))
            {
                strSql += $"where article.Title like '%{folname}%'";
            }
            if (status != 0)
            {
                strSql += $"where article.Status = '{status}'";
            }
            return NewDBHelper.GetList<Article>(strSql);
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
