using System;
using System.Collections.Generic;
using System.Text;
using MODEL;
using DAL;
using System.Data.SqlClient;
using System.Data;

namespace DAL
{
    public class Tab
    {
        public List<tab> GetTabs()
        {
            string sql = $"select * from tab";
            return NewDBHelper.GetList<tab>(sql);
        }
        public int Add(tab t)
        {
            if (t.TId == 0)
            {
                string str = $"delete  from tab";
                //SqlParameter[] a = {
                //new SqlParameter{ParameterName="@tid",DbType=DbType.Int32,Value=1},
                //};
                int i = NewDBHelper.ExecuteNonQuery(str);/*, CommandType.Text, a*/
                if (i == 0)
                {
                    return 0;
                }
            };
            string sql = $"insert into tab values(@Tittle,@Tittle1,@Tittle11,@Tittle12,@Tittle2,@Tittle21,@Tittle22,@Tittle23,@Severce1,@Vocation)";
            SqlParameter[] b = {
               new SqlParameter{ParameterName="@Tittle",DbType=DbType.String,Value=t.Tittle},
               new SqlParameter{ParameterName="@Tittle1",DbType=DbType.String,Value=t.Tittle1},
               new SqlParameter{ParameterName="@Tittle11",DbType=DbType.String,Value=t.Tittle11},
               new SqlParameter{ParameterName="@Tittle12",DbType=DbType.String,Value=t.Tittle12},
               new SqlParameter{ParameterName="@Tittle2",DbType=DbType.String,Value=t.Tittle2},
               new SqlParameter{ParameterName="@Tittle21",DbType=DbType.String,Value=t.Tittle21},
               new SqlParameter{ParameterName="@Tittle22",DbType=DbType.String,Value=t.Tittle22},
               new SqlParameter{ParameterName="@Tittle23",DbType=DbType.String,Value=t.Tittle23},
               new SqlParameter{ParameterName="@Severce1",DbType=DbType.String,Value=t.Severce1},
               new SqlParameter{ParameterName="@Vocation",DbType=DbType.String,Value=t.Vocation},
            };
            return NewDBHelper.ExecuteNonQuery(sql, CommandType.Text, b);
        }
    }
}
