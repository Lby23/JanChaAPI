using System;
using System.Collections.Generic;
using System.Text;
using MODEL;
namespace DAL
{
    public class SuperviseDal
    {
        public List<User> GetUsers()

        {
            string sql = "select * from Users";
            return NewDBHelper.GetList<User>(sql);
        }
    }
}
