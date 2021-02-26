using System;
using System.Collections.Generic;
using System.Text;
using MODEL;

namespace DAL
{
    public class login
    {
        public int Login(string Number,string Password)//登录
        {
            string sql = $"select * from Users where 1=1";
            if (!string.IsNullOrEmpty(Number))
            {
                sql += $" and Number='{Number}'";
            }
            if (!string.IsNullOrEmpty(Password))
            {
                sql += $" and password='{Password}'";
            }
            var str= NewDBHelper.GetList<User>(sql);
            if (str!=null)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        public int Registration(User u)
        {
            string sql = $"insert into Users values('{u.UserName}','{u.UserSex}','{u.Age}','{u.Phone}','{u.Number}','{u.Password}')";
            return NewDBHelper.ExecuteNonQuery(sql);
        }
    }
}
