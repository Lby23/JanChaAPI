using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MODEL;

namespace DAL
{
    public  class RegisteredUsers
    {
        public List<User> GetUsers(int page, int limit,string UserName,string Number)//显示注册的人员和查找人员
        {
            string sql = $"select * from Users where 1=1";
            if (!string.IsNullOrEmpty(UserName))
            {
                sql += $" and UserName='{UserName}'";
            }
            if (!string.IsNullOrEmpty(Number))
            {
                sql += $" and Number='{Number}'";
            }
            var data= NewDBHelper.GetList<User>(sql);
            return data.Skip((page - 1) * limit).Take(limit).ToList();
        }
        public List<User> GetUserOne(int UId)//显示当前Id人员的信息
        {
            var sql = $"select * from Users where 1=1";
            if (UId!=0)
            {
                sql += $" and UId={UId}";
            }
            return NewDBHelper.GetList<User>(sql);
        }
        public int Delete(int UId)//删除
        {
            var sql = $"delete from Users where UId={UId}";
            return NewDBHelper.ExecuteNonQuery(sql);
        }
        public int Enlt(User u)//修改
        {
            var sql = $"update Users set UserName='{u.UserName}',UserSex='{u.UserSex}',Age={u.Age},Phone={u.Phone},Password='{u.Password}'";
            return NewDBHelper.ExecuteNonQuery(sql);
        }
    }
}
