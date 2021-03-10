using System;
using System.Collections.Generic;
using System.Text;
using MODEL;
using System.Data;
using System.Data.SqlClient;
using Newtonsoft.Json;
namespace DAL
{
    public class LinkDal
    {
        public List<Link> GetLink(int page, int limit,out int total,string URL)
        {
            SqlParameter[] para =
            {
                new SqlParameter{ParameterName="@pageIndex",DbType= DbType.Int32,Value=page },
                new SqlParameter{ParameterName="@pageSize",DbType= DbType.Int32,Value=limit },
                new SqlParameter{ParameterName="@url",DbType= DbType.String,Value=URL },
                new SqlParameter{ParameterName="@totalCount",Direction= ParameterDirection.Output,DbType= DbType.Int32 },
            };

            DataTable st = NewDBHelper.GetTable("p_link",CommandType.StoredProcedure,para);

            total = (int)para[3].Value;

            string json = JsonConvert.SerializeObject(st);
            List<Link> data = JsonConvert.DeserializeObject<List<Link>>(json);

            return data;
        }
        public int LinkDelete(int id)
        {
            string sql = $"delete from Link where Lid=@id";
            SqlParameter[] para =
            {
              new SqlParameter{ParameterName="@id",DbType= DbType.Int32,Value=id}
            };

            return NewDBHelper.ExecuteNonQuery(sql,CommandType.Text,para);
        }

        public int LinkAdd(Link s)
        {
            s.Zd = "全部";
            string sql = $"insert into Link values(@Lname,@URL,@Ltype,@Sale,@Zd,@Remark)";
            SqlParameter[] para =
            {
                new SqlParameter{ParameterName="@Lname",DbType= DbType.String,Value=s.Lname },
                new SqlParameter{ParameterName="@URL",DbType= DbType.String,Value=s.Lname },
                new SqlParameter{ParameterName="@Ltype",DbType= DbType.String,Value=s.Lname },
                new SqlParameter{ParameterName="@Sale",DbType= DbType.Int32,Value=s.Lname },
                new SqlParameter{ParameterName="@Zd",DbType= DbType.String,Value=s.Lname },
                new SqlParameter{ParameterName="@Remark",DbType= DbType.String,Value=s.Lname }
            };

            return NewDBHelper.ExecuteNonQuery(sql, CommandType.Text, para);
        }

        public int LinkEdit(Link s)
        {
            s.Zd = "全部";
            string sql = $"update Link set Lname=@Lname,URL=@URL,Ltype=@Ltype,Sale=@Sale,Zd=@Zd,Remark=@Remark where Lid=@Lid";
            SqlParameter[] para =
            {
                new SqlParameter{ParameterName="@Lname",DbType= DbType.String,Value=s.Lname },
                new SqlParameter{ParameterName="@URL",DbType= DbType.String,Value=s.URL },
                new SqlParameter{ParameterName="@Ltype",DbType= DbType.String,Value=s.Ltype },
                new SqlParameter{ParameterName="@Sale",DbType= DbType.Int32,Value=s.Sale },
                new SqlParameter{ParameterName="@Zd",DbType= DbType.String,Value=s.Zd },
                new SqlParameter{ParameterName="@Remark",DbType= DbType.String,Value=s.Remark },
                new SqlParameter{ParameterName="@Lid",DbType= DbType.Int32,Value=s.Lid }
            };
            return NewDBHelper.ExecuteNonQuery(sql, CommandType.Text, para);
        }
    }
}
