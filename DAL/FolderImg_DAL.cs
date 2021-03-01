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
        /// <param name="folname"></param>
        /// <returns></returns>
        public List<FolderImg> GetFolderImgs(string folname)
        {
            string sql = $"select a.*,b.Name from folder_img a join folder b on a.Folder_Id=b.Id where 1=1";
            if(!string.IsNullOrEmpty(folname))
            {
                sql += $" and a.Name like '%{folname}%'";
            }
            return NewDBHelper.GetList<FolderImg>(sql);
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
