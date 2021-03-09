using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using MODEL;
using Newtonsoft.Json;

namespace DAL
{
    public class FolderImg_DAL
    {
        /// <summary>
        /// 显示
        /// </summary>
        /// <param name="folname"></param>
        /// <returns></returns>
        public List<FolderImg> GetFolderImgs(int status, int page, int limit, out int total)
        {
            SqlParameter[] paras =
                {
                new SqlParameter("@pageIndex",page),
                new SqlParameter("@PageSize",limit),
                new SqlParameter("@status",status),
                new SqlParameter("@TotalCount",SqlDbType.Int),
            };
            paras[3].Direction = ParameterDirection.Output;
            DataTable dt = NewDBHelper.GetTable("p_folderimg", CommandType.StoredProcedure, paras);

            total = Convert.ToInt32(paras[3].Value);
            string json = JsonConvert.SerializeObject(dt);
            var list = JsonConvert.DeserializeObject<List<FolderImg>>(json);
            return list;
        }


        /// <summary>
        /// 下拉框
        /// </summary>
        /// <returns></returns>
        public List<FolderImg> GetFolders()
        {
            string sql = $"select * from Folder_Img";
            return NewDBHelper.GetList<FolderImg>(sql);
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        public int Add(FolderImg f)
        {
            string sql = $"insert into Folder_Img values({f.FolderId},'{f.Name}','{f.Countnt}',{f.Sort},{f.Status},'{f.Img}','{f.JumpUrl}','{f.CreateTime}')";
            return NewDBHelper.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="f"></param>
        /// <returns></returns>
        public int Alter(FolderImg f)
        {
            string sql = $"update Folder_Img set FolderId='{f.FolderId}',Name='{f.Name}',Countnt='{f.Countnt}',Sort={f.Sort},Status={f.Status},Img='{f.Img}',JumpUrl='{f.JumpUrl}',CreateTime='{f.CreateTime}' where Id={f.Id}";
            return NewDBHelper.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// 删除
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public int Remove(int id)
        {
            string sql = $"delete from Folder_Img where Id={id}";
            return NewDBHelper.ExecuteNonQuery(sql);
        }

        /// <summary>
        /// 返填
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public List<FolderImg> GetId(int id)
        {
            string sql = $"select * from Folder_Img where Id ={id}";
            return NewDBHelper.GetList<FolderImg>(sql);
        }
    }
}
