using MODEL;
using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;

namespace DAL
{
    //招聘管理
    public class RecruitDAL
    {
        
        public List<Recruit> GetRecruits_page(int pageIndex, int pageSize, out int totalCount, string RPosition = null)
        {
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter{ ParameterName="@PageIndex",Value=pageIndex,DbType=DbType.Int32},
                new SqlParameter{ ParameterName="@pageSize",Value=pageSize,DbType=DbType.Int32},
                new SqlParameter{ ParameterName="@RPosition",Value=RPosition,DbType=DbType.String},
                new SqlParameter{ ParameterName="@totalCount", Direction= ParameterDirection.Output,DbType=DbType.Int32}
            };

            DataTable dt = NewDBHelper.GetTable("p_PageRecruit", CommandType.StoredProcedure, paras);
            totalCount = (int)(paras[3].Value);
            string json = JsonConvert.SerializeObject(dt);
            List<Recruit> list = JsonConvert.DeserializeObject<List<Recruit>>(json);
            return list;
        }
        public List<Recruit> GetRecruitsType(string RType)
        {
            string strSql = $"select * from Recruit where RType=@RType";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter{ ParameterName="@RType",Value=RType,DbType= DbType.String }
            };
            return NewDBHelper.GetList<Recruit>(strSql, CommandType.Text, para);
        }
        public int AddRecruits(Recruit rc)
        {
            string strSql = $"insert into Recruit values(@Rtype,@Rposition,@RpositionDescride,@Rlocation,@Rcompany,@Rstate,@Rtime,@Rperson)";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter{ ParameterName="@Rtype",Value=rc.Rtype,DbType= DbType.String },
                new SqlParameter{ ParameterName="@Rposition",Value=rc.Rposition,DbType= DbType.String },
                new SqlParameter{ ParameterName="@RpositionDescride",Value=rc.RpositionDescride,DbType= DbType.String },
                new SqlParameter{ ParameterName="@Rlocation",Value=rc.Rlocation,DbType= DbType.String },
                new SqlParameter{ ParameterName="@Rcompany",Value=rc.Rcompany,DbType= DbType.String },
                new SqlParameter{ ParameterName="@Rstate",Value=rc.Rstate,DbType= DbType.Boolean },
                new SqlParameter{ ParameterName="@Rtime",Value=rc.Rtime,DbType= DbType.DateTime },
                new SqlParameter{ ParameterName="@Rperson",Value=rc.Rperson,DbType= DbType.String },
            };
            return NewDBHelper.ExecuteNonQuery(strSql, CommandType.Text, para);
        }
        public int DeleteRecruits(int RId)
        {
            string strSql = $"delete from Recruit where RId=@RId";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter{ ParameterName="@RId",Value=RId,DbType= DbType.Int32 }
            };
            return NewDBHelper.ExecuteNonQuery(strSql, CommandType.Text, para);
        }
        public int UpdateRecruits(Recruit rc)
        {
            string strSql = $"update Recruit set RType=@Rtype,RPosition=@Rposition,RPositionDescride=@RpositionDescride,RLocation=@Rlocation,RCompany=@Rcompany,RState=@Rstate,RTime=@Rtime,RPerson=@Rperson where RId=@Rid";
            SqlParameter[] para = new SqlParameter[]
             {
                new SqlParameter{ ParameterName="@Rtype",Value=rc.Rtype,DbType= DbType.String },
                new SqlParameter{ ParameterName="@Rposition",Value=rc.Rposition,DbType= DbType.String },
                new SqlParameter{ ParameterName="@RpositionDescride",Value=rc.RpositionDescride,DbType= DbType.String },
                new SqlParameter{ ParameterName="@Rlocation",Value=rc.Rlocation,DbType= DbType.String },
                new SqlParameter{ ParameterName="@Rcompany",Value=rc.Rcompany,DbType= DbType.String },
                new SqlParameter{ ParameterName="@Rstate",Value=rc.Rstate,DbType= DbType.Boolean },
                new SqlParameter{ ParameterName="@Rtime",Value=rc.Rtime,DbType= DbType.DateTime },
                new SqlParameter{ ParameterName="@Rperson",Value=rc.Rperson,DbType= DbType.String },
                new SqlParameter{ ParameterName="@Rid",Value=rc.Rid,DbType= DbType.Int32 },
             };
            return NewDBHelper.ExecuteNonQuery(strSql, CommandType.Text, para);
        }
    }
}
