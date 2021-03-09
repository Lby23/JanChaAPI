using System;
using System.Collections.Generic;
using System.Text;
using MODEL;
using System.Data.SqlClient;
using Newtonsoft.Json;

namespace DAL
{
    //黑名单
    public class BlackListDAL
    {
        //前台页面查找黑名单_企业/单位
        public List<Blacklist> GetBlacklists_front(string Bunit = null, string BpapersNumber = null)
        {
            string strSql = $"select * from Blacklist where Btype='单位' and Bunit=@Bunit and BpapersNumber=@BpapersNumber";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter{ ParameterName="@Bunit",Value=Bunit,DbType= System.Data.DbType.String },
                new SqlParameter{ ParameterName="@BpapersNumber",Value=BpapersNumber,DbType= System.Data.DbType.String }
            };
            return NewDBHelper.GetList<Blacklist>(strSql, System.Data.CommandType.Text, para);
        }
        //前台页面查找黑名单_个人
        public List<Blacklist> GetBlacklists_onePerson(string Bunit = null, string BpapersNumber = null)
        {
            string strSql = $"select * from Blacklist where Btype='个人' and Bunit=@Bunit and BpapersNumber=@BpapersNumber";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter{ ParameterName="@Bunit",Value=Bunit,DbType= System.Data.DbType.String },
                new SqlParameter{ ParameterName="@BpapersNumber",Value=BpapersNumber,DbType= System.Data.DbType.String }
            };
            return NewDBHelper.GetList<Blacklist>(strSql, System.Data.CommandType.Text, para);
        }
        //参数化显示查询
        public List<Blacklist> GetBlacklists_page(int pageIndex, int pageSize, out int totalCount, string BUnit = null)
        {
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter{ ParameterName="@PageIndex",Value=pageIndex,DbType=System.Data.DbType.Int32},
                new SqlParameter{ ParameterName="@pageSize",Value=pageSize,DbType=System.Data.DbType.Int32},
                new SqlParameter{ ParameterName="@Bunit",Value=BUnit,DbType=System.Data.DbType.String},
                new SqlParameter{ ParameterName="@totalCount", Direction= System.Data.ParameterDirection.Output,DbType=System.Data.DbType.Int32}
            };
            
            System.Data.DataTable dt = NewDBHelper.GetTable("p_PageBlackList", System.Data.CommandType.StoredProcedure, paras);
            totalCount = (int)(paras[3].Value);
            string json = JsonConvert.SerializeObject(dt);
            List<Blacklist> list = JsonConvert.DeserializeObject<List<Blacklist>>(json);
            return list;
        }
        //添加黑名单信息
        public int AddBlacklist(Blacklist bl)
        {
            string strSql = $"insert into Blacklist values(@Btype,@Bunit,@BpapersNumber,@Bmatter,@Bstate,@BUpdateTime,@PubLishPerson)";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter{ ParameterName="@Btype",Value=bl.Btype,DbType=System.Data.DbType.String },
                new SqlParameter{ ParameterName="@Bunit",Value=bl.Bunit,DbType=System.Data.DbType.String },
                new SqlParameter{ ParameterName="@BpapersNumber",Value=bl.BpapersNumber,DbType=System.Data.DbType.String },
                new SqlParameter{ ParameterName="@Bmatter",Value=bl.Bmatter,DbType=System.Data.DbType.String },
                new SqlParameter{ ParameterName="@Bstate",Value=bl.Bstate,DbType=System.Data.DbType.Boolean },
                new SqlParameter{ ParameterName="@BUpdateTime",Value=bl.BUpdateTime,DbType=System.Data.DbType.DateTime },
                new SqlParameter{ ParameterName="@PubLishPerson",Value=bl.PubLishPerson,DbType=System.Data.DbType.String },
            };
            return NewDBHelper.ExecuteNonQuery(strSql,System.Data.CommandType.Text,para);
        }
        //删除黑名单信息
        public int DelBlacklist(int Bid)
        {
            string strSql = $"delete from Blacklist where Bid=@Bid";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter{ ParameterName="@Bid",Value=Bid,DbType=System.Data.DbType.Int32 }
            };
            return NewDBHelper.ExecuteNonQuery(strSql,System.Data.CommandType.Text,para);
        }
        //修改黑名单
        public int UpdateBlacklist(Blacklist bl)
        {
            string strSql = $"update Blacklist set Btype=@Btype,Bunit=@Bunit,BpapersNumber=@BpapersNumber,Bmatter=@Bmatter,Bstate=@Bstate,BUpdateTime=@BUpdateTime,PubLishPerson=@PubLishPerson where Bid=@Bid";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter{ ParameterName="@Btype",Value=bl.Btype,DbType=System.Data.DbType.String },
                new SqlParameter{ ParameterName="@Bunit",Value=bl.Bunit,DbType=System.Data.DbType.String },
                new SqlParameter{ ParameterName="@BpapersNumber",Value=bl.BpapersNumber,DbType=System.Data.DbType.String },
                new SqlParameter{ ParameterName="@Bmatter",Value=bl.Bmatter,DbType=System.Data.DbType.String },
                new SqlParameter{ ParameterName="@Bstate",Value=bl.Bstate,DbType=System.Data.DbType.Boolean },
                new SqlParameter{ ParameterName="@BUpdateTime",Value=bl.BUpdateTime,DbType=System.Data.DbType.DateTime },
                new SqlParameter{ ParameterName="@PubLishPerson",Value=bl.PubLishPerson,DbType=System.Data.DbType.String },
                new SqlParameter{ ParameterName="@Bid",Value=bl.Bid,DbType= System.Data.DbType.Int32 },
            };
            return NewDBHelper.ExecuteNonQuery(strSql, System.Data.CommandType.Text, para);
        }
    }
}
