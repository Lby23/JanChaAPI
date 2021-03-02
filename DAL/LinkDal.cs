using System;
using System.Collections.Generic;
using System.Text;
using MODEL;
namespace DAL
{
    public class LinkDal
    {
        public List<Link> GetLink(int page, int limit, string URL)
        {
            string sql = "select * from Link where 1=1";

            if (!string.IsNullOrEmpty(URL))
            {
                sql += $" and Lname='{URL}'";
            }

            List<Link> data = NewDBHelper.GetList<Link>(sql);
            return data;
        }
        public int LinkDelete(int id)
        {
            string sql = $"delete from Link where Lid={id}";
            return NewDBHelper.ExecuteNonQuery(sql);
        }

        public int LinkAdd(Link s)
        {
            s.Zd = "全部";
            string sql = $"insert into Link values('{s.Lname}','{s.URL}','{s.Ltype}',{s.Sale},'{s.Zd}','{s.Remark}')";

            return NewDBHelper.ExecuteNonQuery(sql);
        }

        public int LinkEdit(Link s)
        {
            s.Zd = "全部";
            string sql = $"update Link set Lname='{s.Lname}',URL='{s.URL}',Ltype='{s.Ltype}',Sale={s.Sale},Zd='{s.Zd}',Remark='{s.Remark}' where Lid={s.Lid}";

            return NewDBHelper.ExecuteNonQuery(sql);
        }
    }
}
