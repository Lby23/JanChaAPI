using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;
using System.Linq;
using System.Text;
using MODEL;

namespace DAL
{
    public  class RegisteredUsers
    {
        public List<User> GetUsers(int page, int limit,string UserName,string Number,out int total)//显示注册的人员和查找人员
        {
            SqlParameter[] par = {
            new SqlParameter{ ParameterName="@Index",DbType=DbType.Int32,Value=page},
            new SqlParameter{ ParameterName="@Size",DbType=DbType.Int32,Value=page},
            new SqlParameter{ ParameterName="@UserName",DbType=DbType.String,Value=page},
            new SqlParameter{ ParameterName="@Number",DbType=DbType.String,Value=page},
            new SqlParameter{ ParameterName="@totalCount",Direction= ParameterDirection.Output,DbType= DbType.Int32}
            };
            DataTable tab = NewDBHelper.GetTable("Pro_name", CommandType.StoredProcedure, par);
            total = (int)par[4].Value;
            string json = JsonConvert.SerializeObject(tab);
            List<User> data = JsonConvert.DeserializeObject<List<User>>(json);

            return data;
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
            var sql = $"update Users set UserName='{u.UserName}',UserSex='{u.UserSex}',Age={u.Age},Phone={u.Phone},Password='{u.Password}' where UId={u.UId}";
            return NewDBHelper.ExecuteNonQuery(sql);
        }
        public int Add(User u)//添加
        {
            var sql=$"insert into Users values('{u.UserName}','{u.UserSex}',{u.Age},'{u.Phone}','{u.Number}','{u.Password}')";
            return NewDBHelper.ExecuteNonQuery(sql);
        }
    }
}
