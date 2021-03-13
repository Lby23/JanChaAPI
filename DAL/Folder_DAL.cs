using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using MODEL;
using Newtonsoft.Json;

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
        public List<Folder> GetFolders(string folname, int status, int page, int limit, out int total)
        {
            SqlParameter[] paras =
                {
                new SqlParameter("@pageIndex",page),
                new SqlParameter("@PageSize",limit),
                new SqlParameter("@folname",folname),
                new SqlParameter("@status",status),
                new SqlParameter("@TotalCount",SqlDbType.Int),
            };
            paras[4].Direction = ParameterDirection.Output;
            DataTable dt = NewDBHelper.GetTable("p_folder", CommandType.StoredProcedure, paras);

            total = Convert.ToInt32(paras[4].Value);
            string json = JsonConvert.SerializeObject(dt);
            var list = JsonConvert.DeserializeObject<List<Folder>>(json);
            return list;
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
            string sql = $"insert into Folder values({f.ParentId},'{f.Name}','{f.Key}','{f.Path}',{f.Sort},{f.Status},{f.Type},'{f.JumpUrl}','{f.Content}')";
            return NewDBHelper.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        public int Alter(Folder f)
        {
            string sql = $"update Folder set Name='{f.Name}',Key='{f.Key}',Path='{f.Path}',Sort={f.Sort},Status={f.Status},JumpUrl='{f.JumpUrl}',Content='{f.Content}' where Id={f.Id}";
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


        #region 树tree
        //查询
        public List<Folder> GetTreeData()
        {
            //加载第一层
            var list = Folders();
            //加载子节点
            foreach (var item in list)
            {
                //调用递归方法
                item.children = GetTreeDataRec(item.Id);
            }

            return list;
        }

        //递归加载树
        public List<Folder> GetTreeDataRec(int id)
        {
            var list = GetId(id);
            //加载孙节点
            foreach (var citem in list)
            {
                citem.children = GetTreeDataRec(citem.Id);
            }

            return list;
        } 
        #endregion


    }
}
