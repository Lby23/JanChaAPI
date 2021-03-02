using System;
using System.Collections.Generic;
using System.Text;
using MODEL;

namespace DAL
{
    public class login
    {
        public List<User> Login(string number, string pass)//登录
        {
            string sql = $"select * from Users where Number='{number}' and Password='{pass}'";
            return NewDBHelper.GetList<User>(sql);            
        }
        public int Registration(User u)
        {
            string sql = $"insert into Users values('{u.UserName}','{u.UserSex}','{u.Age}',GETDATE(),'{u.Phone}','{u.Emile}','{u.Note}','{u.Number}','{u.Password}')";
            return NewDBHelper.ExecuteNonQuery(sql);
        }

        public List<User> GetUsers()
        {
            string sql = $"select * from Users";
            return NewDBHelper.GetList<User>(sql);
        }
    }
}
