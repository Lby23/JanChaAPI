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
            string sql = $"select * from Users where Number='{Number}' and Password='{Password}'";
            var data= NewDBHelper.GetList<User>(sql);
            if (data.Count!=0)
            {
                return 1;
            }
            return 0;
            
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
