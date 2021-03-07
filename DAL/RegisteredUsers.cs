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
            new SqlParameter{ ParameterName="@Size",DbType=DbType.Int32,Value=limit},
            new SqlParameter{ ParameterName="@UserName",DbType=DbType.String,Value=UserName},
            new SqlParameter{ ParameterName="@Number",DbType=DbType.String,Value=Number},
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
                sql += $" and UId=@UId";
            }
            SqlParameter[] a={ 
            new SqlParameter {ParameterName="@UId",DbType=DbType.Int32,Value=UId}
            };
            return NewDBHelper.GetList<User>(sql,CommandType.StoredProcedure,a);
        }
        public int Delete(int UId)//删除
        {
            var sql = $"delete from Users where UId=@UId";
            SqlParameter[] a = { 
            new SqlParameter{ ParameterName="@UId",DbType=DbType.Int32,Value=UId},
            };
            return NewDBHelper.ExecuteNonQuery(sql,CommandType.StoredProcedure,a);
        }
        public int Enlt(User u)//修改
        {
            string sql = $"update Users set UserName=@UserName,UserSex=@UserSex,Age=@AgePassword =@Password,Phone=@Phone where UId=@UId";
            SqlParameter[] a = {
            new SqlParameter{ ParameterName="@UId",DbType=DbType.Int32,Value=u.UId},
            new SqlParameter{ ParameterName="@UserName",DbType=DbType.String,Value=u.UserName},
            new SqlParameter{ ParameterName="@Time1",DbType=DbType.DateTime,Value=u.Time1=DateTime.Now},
            new SqlParameter{ ParameterName="@Phone",DbType=DbType.String,Value=u.Phone}, 
            new SqlParameter{ ParameterName="@Number",DbType=DbType.String,Value=u.Number},
             new SqlParameter{ ParameterName="@Password",DbType=DbType.String,Value=u.Password}
            };
            return NewDBHelper.ExecuteNonQuery(sql, CommandType.Text, a);
        }
        public int Add(User u)//添加
        {
            string sql = $"insert into Users values(@UserName,@UserSex,@Age,@Time1,@Phone,@Note,@Number,@Password)";
            SqlParameter[] a = {
            new SqlParameter{ ParameterName="@UserName",DbType=DbType.String,Value=u.UserName},
            new SqlParameter{ ParameterName="@UserSex",DbType=DbType.Boolean,Value=u.UserSex},
            new SqlParameter{ ParameterName="@Age",DbType=DbType.Int32,Value=u.Age},
            new SqlParameter{ ParameterName="@Time1",DbType=DbType.DateTime,Value=u.Time1=DateTime.Now},
            new SqlParameter{ ParameterName="@Phone",DbType=DbType.String,Value=u.Phone},
            new SqlParameter{ ParameterName="@Note",DbType=DbType.String,Value=u.Note},
            new SqlParameter{ ParameterName="@Number",DbType=DbType.String,Value=u.Number},
             new SqlParameter{ ParameterName="@Password",DbType=DbType.String,Value=u.Password}
            };
            return NewDBHelper.ExecuteNonQuery(sql, CommandType.Text, a);
        }
    }
}
