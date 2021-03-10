using System;
using System.Collections.Generic;
using System.Text;
using MODEL;
using System.Data.SqlClient;
using Newtonsoft.Json;
using System.Data;

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
                new SqlParameter{ ParameterName="@Bunit",Value=Bunit,DbType= DbType.String },
                new SqlParameter{ ParameterName="@BpapersNumber",Value=BpapersNumber,DbType=DbType.String }
            };
            return NewDBHelper.GetList<Blacklist>(strSql, CommandType.Text, para);
        }
        //前台页面查找黑名单_个人
        public List<Blacklist> GetBlacklists_onePerson(string Bunit = null, string BpapersNumber = null)
        {
            string strSql = $"select * from Blacklist where Btype='个人' and Bunit=@Bunit and BpapersNumber=@BpapersNumber";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter{ ParameterName="@Bunit",Value=Bunit,DbType=DbType.String },
                new SqlParameter{ ParameterName="@BpapersNumber",Value=BpapersNumber,DbType= DbType.String }
            };
            return NewDBHelper.GetList<Blacklist>(strSql,CommandType.Text, para);
        }
        //参数化显示查询
        public List<Blacklist> GetBlacklists_page(int pageIndex, int pageSize, out int totalCount, string BUnit = null)
        {
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter{ ParameterName="@pageIndex",Value=pageIndex,DbType=DbType.Int32},
                new SqlParameter{ ParameterName="@pageSize",Value=pageSize,DbType=DbType.Int32},
                new SqlParameter{ ParameterName="@Bunit",Value=BUnit,DbType=DbType.String},
                new SqlParameter{ ParameterName="@totalCount", Direction= ParameterDirection.Output,DbType=DbType.Int32}
            };
            
            DataTable dt = NewDBHelper.GetTable("p_PageBlackList", CommandType.StoredProcedure, paras);
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
                new SqlParameter{ ParameterName="@Btype",Value=bl.Btype,DbType=DbType.String },
                new SqlParameter{ ParameterName="@Bunit",Value=bl.Bunit,DbType=DbType.String },
                new SqlParameter{ ParameterName="@BpapersNumber",Value=bl.BpapersNumber,DbType=DbType.String },
                new SqlParameter{ ParameterName="@Bmatter",Value=bl.Bmatter,DbType=DbType.String },
                new SqlParameter{ ParameterName="@Bstate",Value=bl.Bstate,DbType=DbType.Boolean },
                new SqlParameter{ ParameterName="@BUpdateTime",Value=bl.BUpdateTime,DbType=DbType.DateTime },
                new SqlParameter{ ParameterName="@PubLishPerson",Value=bl.PubLishPerson,DbType=DbType.String },
            };
            return NewDBHelper.ExecuteNonQuery(strSql,CommandType.Text,para);
        }
        //删除黑名单信息
        public int DelBlacklist(int Bid)
        {
            string strSql = $"delete from Blacklist where Bid=@Bid";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter{ ParameterName="@Bid",Value=Bid,DbType=DbType.Int32 }
            };
            return NewDBHelper.ExecuteNonQuery(strSql,CommandType.Text,para);
        }
        //修改黑名单
        public int UpdateBlacklist(Blacklist bl)
        {
            string strSql = $"update Blacklist set Btype=@Btype,Bunit=@Bunit,BpapersNumber=@BpapersNumber,Bmatter=@Bmatter,Bstate=@Bstate,BUpdateTime=@BUpdateTime,PubLishPerson=@PubLishPerson where Bid=@Bid";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter{ ParameterName="@Btype",Value=bl.Btype,DbType=DbType.String },
                new SqlParameter{ ParameterName="@Bunit",Value=bl.Bunit,DbType=DbType.String },
                new SqlParameter{ ParameterName="@BpapersNumber",Value=bl.BpapersNumber,DbType=DbType.String },
                new SqlParameter{ ParameterName="@Bmatter",Value=bl.Bmatter,DbType=DbType.String },
                new SqlParameter{ ParameterName="@Bstate",Value=bl.Bstate,DbType=DbType.Boolean },
                new SqlParameter{ ParameterName="@BUpdateTime",Value=bl.BUpdateTime,DbType=DbType.DateTime },
                new SqlParameter{ ParameterName="@PubLishPerson",Value=bl.PubLishPerson,DbType=DbType.String },
                new SqlParameter{ ParameterName="@Bid",Value=bl.Bid,DbType= DbType.Int32 },
            };
            return NewDBHelper.ExecuteNonQuery(strSql, CommandType.Text, para);
        }
    }
}
