using System;
using System.Collections.Generic;
using MODEL;

namespace DAL
{
    public class Folder_DAL
    {
        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="folname"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public List<Folder> GetFolders(string folname, int status, int page, int limit)
        {
            string sql = $"select * from Folder where 1=1";
            if (!string.IsNullOrEmpty(folname))
            {
                sql += $" and Name like '%{folname}%' ";
            }
            if (status != 0)
            {
                sql += $" and Status = '{status}' ";
            }
            return NewDBHelper.GetList<Folder>(sql);
        }

        /// <summary>
        /// 下拉框
        /// </summary>
        /// <returns></returns>
        public List<Folder> Folders()
        {
            string sql = $"select * from Folder";
            return NewDBHelper.GetList<Folder>(sql);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        public int Add(Folder f)
        {
            string sql = $"insert into Folder values({f.ParentId},'{f.Name}','{f.Key}','{f.Path}',{f.Sort},{f.Status},{f.Type},'{f.Jump_url}','{f.Content}')";
            return NewDBHelper.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        public int Alter(Folder f)
        {
            string sql = $"update Folder set Name='{f.Name}',Key='{f.Key}',Path='{f.Path}',Sort={f.Sort},Status={f.Status},JumpUrl='{f.Jump_url}',Content='{f.Content}' where Id={f.Id}";
            return NewDBHelper.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Remove(int id)
        {
            string sql = $"delete from Folder where Id={id}";
            return NewDBHelper.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// 返填
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<Folder> GetId(int id)
        {
            string sql = $"select * from Folder where Id ={id}";
            return NewDBHelper.GetList<Folder>(sql);
        }
    }
}
