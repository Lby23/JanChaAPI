using System;
using System.Collections.Generic;
using System.Text;
using MODEL;

namespace DAL
{
    public class FolderImg_DAL
    {
        /// <summary>
        /// 显示
        /// </summary>
        /// <returns></returns>
        public List<FolderImg> GetFolders()
        {
            string sql = $"select * from FolderImg";
            return NewDBHelper.GetList<FolderImg>(sql);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        public int Add(FolderImg f)
        {
            string sql = $"insert into FolderImg values({f.FolderId},'{f.Name}','{f.Countnt}',{f.Sort},{f.Status},'{f.Img}','{f.JumpUrl}','{f.CreateTime}')";
            return NewDBHelper.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        public int Alter(FolderImg f)
        {
            string sql = $"update FolderImg set FolderId='{f.FolderId}',Name='{f.Name}',Countnt='{f.Countnt}',Sort={f.Sort},Status={f.Status},Img='{f.Img}',JumpUrl='{f.JumpUrl}',CreateTime='{f.CreateTime}' where Id={f.Id}";
            return NewDBHelper.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Remove(int id)
        {
            string sql = $"delete from FolderImg where Id={id}";
            return NewDBHelper.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// 返填
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<FolderImg> GetId(int id)
        {
            string sql = $"select * from FolderImg where Id ={id}";
            return NewDBHelper.GetList<FolderImg>(sql);
        }
    }
}
