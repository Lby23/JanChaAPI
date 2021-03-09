using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using MODEL;
using System.Security.Cryptography;

namespace DAL
{
    public class login
    {
        public List<User> Login(string Number, string Password)//登录
        {
            string sql = $"select * from Users where Number=@Number and Password=@Password";
            SqlParameter[] a = {
                new SqlParameter { ParameterName= "@Number",DbType= DbType.String,Value= Number },
                new SqlParameter { ParameterName= "@Password",DbType= DbType.String,Value= Password }
                                };
            return NewDBHelper.GetList<User>(sql, CommandType.Text, a);
        }
        public int Registration(User u)
        {
            string sql = $"insert into Users values(@UserName,@UserSex,@Age,@Time1,@Phone,@Emile,@Note,@Number,@Password)";
            SqlParameter[] a = {
            new SqlParameter{ ParameterName="@UserName",DbType=DbType.String,Value=u.UserName},
            new SqlParameter{ ParameterName="@UserSex",DbType=DbType.Boolean,Value=u.UserSex},
            new SqlParameter{ ParameterName="@Age",DbType=DbType.Int32,Value=u.Age},
            new SqlParameter{ ParameterName="@Time1",DbType=DbType.DateTime,Value=u.Time1=DateTime.Now},
            new SqlParameter{ ParameterName="@Phone",DbType=DbType.String,Value=u.Phone},
            new SqlParameter{ ParameterName="@Emile",DbType=DbType.String,Value=u.Emile},
            new SqlParameter{ ParameterName="@Note",DbType=DbType.String,Value=u.Note},
            new SqlParameter{ ParameterName="@Number",DbType=DbType.String,Value=u.Number},
             new SqlParameter{ ParameterName="@Password",DbType=DbType.String,Value=u.Password}
            };
            return NewDBHelper.ExecuteNonQuery(sql, CommandType.Text, a);
        }

        public string GetMd5String(string str)
        {
            //实例化一个md5对像
            MD5 md5 = MD5.Create();
            // 加密后是一个字节类型的数组，这里要注意编码UTF8/Unicode等的选择　
            byte[] bytes = md5.ComputeHash(Encoding.UTF8.GetBytes(str));
            StringBuilder sb = new StringBuilder();
            // 通过使用循环，将字节类型的数组转换为字符串，此字符串是常规字符格式化所得
            for (int i = 0; i < bytes.Length; i++)
            {
                //加密结果"x2"结果为32位,"x3"结果为48位,"x4"结果为64位
                sb.Append(bytes[i].ToString("x2"));
            }
            return sb.ToString();
        }

        public int Updatepass(User u)
        {
            string sql = $"update Users set UserName=@UserName, Password =@Password,Emile=@Emile,Phone=@Phone,note=@Note where UId=@UId";
            SqlParameter[] a = {
            new SqlParameter{ ParameterName="@UId",DbType=DbType.Int32,Value=u.UId},
            new SqlParameter{ ParameterName="@UserName",DbType=DbType.String,Value=u.UserName},
            new SqlParameter{ ParameterName="@Time1",DbType=DbType.DateTime,Value=u.Time1=DateTime.Now},
            new SqlParameter{ ParameterName="@Phone",DbType=DbType.String,Value=u.Phone},
            new SqlParameter{ ParameterName="@Emile",DbType=DbType.String,Value=u.Emile},
            new SqlParameter{ ParameterName="@Note",DbType=DbType.String,Value=u.Note},
            new SqlParameter{ ParameterName="@Number",DbType=DbType.String,Value=u.Number},
             new SqlParameter{ ParameterName="@Password",DbType=DbType.String,Value=u.Password}
            };
            return NewDBHelper.ExecuteNonQuery(sql, CommandType.Text, a);
        }
    }

}
