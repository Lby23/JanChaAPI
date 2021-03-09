using System;
using System.Collections.Generic;
using System.Text;
using MODEL;
using System.Data.SqlClient;
using System.Data;
using Newtonsoft.Json;

namespace DAL
{
    //投诉管理表
    public class ComplainDAL
    {

        //获取查询显示表信息
        public List<Complain> GetComplains(string CName)
        {
            string strSql = $"select * from Complain where 1=1";
            if (CName != null)
            {
                strSql += $" and CName='{CName}'";
            }
            return NewDBHelper.GetList<Complain>(strSql);
        }
        //参数化 存储过程 显示查询分页
        public List<Complain> GetComplains_page(int pageIndex, int pageSize, out int totalCount, string CName = null)
        {
            SqlParameter[] paras = new SqlParameter[]
            {
                new SqlParameter{ ParameterName="@PageIndex",Value=pageIndex,DbType=DbType.Int32},
                new SqlParameter{ ParameterName="@pageSize",Value=pageSize,DbType=DbType.Int32},
                new SqlParameter{ ParameterName="@CName",Value=CName,DbType=DbType.String},
                new SqlParameter{ ParameterName="@totalCount", Direction= ParameterDirection.Output,DbType=DbType.Int32}
            };

            DataTable dt = NewDBHelper.GetTable("p_PageComplain", CommandType.StoredProcedure, paras);
            totalCount = (int)(paras[3].Value);
            string json = JsonConvert.SerializeObject(dt);
            List<Complain> list = JsonConvert.DeserializeObject<List<Complain>>(json);
            return list;
        }
        //添加表信息-后
        public int AddComplains(Complain cn)
        {
            string strSql = $"insert into Complain values(@Cnumber,@Ctype,@Crole,@Cname,@Cphone,@WeChat,@Cemail,@ComplainPerson,@Caccessory,@Cstate,@ComplainTime,@CdisposePerson)";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter{ ParameterName="@Cnumber",Value=cn.Cnumber,DbType= DbType.String },
                new SqlParameter{ ParameterName="@Ctype",Value=cn.Ctype,DbType= DbType.String },
                new SqlParameter{ ParameterName="@Crole",Value=cn.Crole,DbType= DbType.String },
                new SqlParameter{ ParameterName="@Cname",Value=cn.Cname,DbType= DbType.String },
                new SqlParameter{ ParameterName="@Cphone",Value=cn.Cphone,DbType= DbType.String },
                new SqlParameter{ ParameterName="@WeChat",Value=cn.WeChat,DbType= DbType.String },
                new SqlParameter{ ParameterName="@Cemail",Value=cn.Cemail,DbType= DbType.String },
                new SqlParameter{ ParameterName="@ComplainPerson",Value=cn.ComplainPerson,DbType= DbType.String },
                new SqlParameter{ ParameterName="@Caccessory",Value=cn.Caccessory,DbType= DbType.String },
                new SqlParameter{ ParameterName="@Cstate",Value=cn.Cstate,DbType= DbType.Boolean },
                new SqlParameter{ ParameterName="@ComplainTime",Value=cn.ComplainTime,DbType= DbType.DateTime },
                new SqlParameter{ ParameterName="@CdisposePerson",Value=cn.CdisposePerson,DbType= DbType.String },
        };
            return NewDBHelper.ExecuteNonQuery(strSql, CommandType.Text, para);
        }
        //删除表信息
        public int DelComplains(int CId)
        {
            string strSql = $"delete from Complain where CId=@CId";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter{ ParameterName="@CId",Value=CId,DbType=DbType.Int32 }
            };
            return NewDBHelper.ExecuteNonQuery(strSql, CommandType.Text, para);
        }
        //修改表信息
        public int UpdateComplains(Complain cn)
        {
            string strSql = $"update Complain set CNumber=@Cnumber,CType=@Ctype,CRole=@Crole,CName=@Cname,CPhone=@Cphone,WeChat=@WeChat,Cemail=@Cemail,ComplainPerson=@ComplainPerson,Caccessory=@Caccessory,Cstate=@Cstate,ComplainTime=@ComplainTime,CdisposePerson=@CdisposePerson where CId=@Cid";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter{ ParameterName="@Cnumber",Value=cn.Cnumber,DbType= DbType.String },
                new SqlParameter{ ParameterName="@Ctype",Value=cn.Ctype,DbType= DbType.String },
                new SqlParameter{ ParameterName="@Crole",Value=cn.Crole,DbType= DbType.String },
                new SqlParameter{ ParameterName="@Cname",Value=cn.Cname,DbType= DbType.String },
                new SqlParameter{ ParameterName="@Cphone",Value=cn.Cphone,DbType= DbType.String },
                new SqlParameter{ ParameterName="@WeChat",Value=cn.WeChat,DbType= DbType.String },
                new SqlParameter{ ParameterName="@Cemail",Value=cn.Cemail,DbType= DbType.String },
                new SqlParameter{ ParameterName="@ComplainPerson",Value=cn.ComplainPerson,DbType= DbType.String },
                new SqlParameter{ ParameterName="@Caccessory",Value=cn.Caccessory,DbType= DbType.String },
                new SqlParameter{ ParameterName="@Cstate",Value=cn.Cstate,DbType= DbType.Boolean },
                new SqlParameter{ ParameterName="@ComplainTime",Value=cn.ComplainTime,DbType= DbType.DateTime },
                new SqlParameter{ ParameterName="@CdisposePerson",Value=cn.CdisposePerson,DbType= DbType.String },
                new SqlParameter{ ParameterName="@Cid",Value=cn.Cid,DbType= DbType.Int32 },
            };
            return NewDBHelper.ExecuteNonQuery(strSql, CommandType.Text, para);
        }

        //添加投诉举报信息_实名
        public int AddComplains_autonym(Complain cn)
        {
            string strSql = $"insert into Complain values(@Cnumber,@Ctype,@Crole,@Cname,@Cphone,@WeChat,@Cemail,@ComplainPerson,@Caccessory,@Cstate,@ComplainTime,@CdisposePerson)";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter{ ParameterName="@Cnumber",Value=cn.Cnumber,DbType= DbType.String },
                new SqlParameter{ ParameterName="@Ctype",Value="实名",DbType= DbType.String },
                new SqlParameter{ ParameterName="@Crole",Value=cn.Crole,DbType= DbType.String },
                new SqlParameter{ ParameterName="@Cname",Value=cn.Cname,DbType= DbType.String },
                new SqlParameter{ ParameterName="@Cphone",Value=cn.Cphone,DbType= DbType.String },
                new SqlParameter{ ParameterName="@WeChat",Value=cn.WeChat,DbType= DbType.String },
                new SqlParameter{ ParameterName="@Cemail",Value=cn.Cemail,DbType= DbType.String },
                new SqlParameter{ ParameterName="@ComplainPerson",Value="192.168.43.41",DbType= DbType.String },
                new SqlParameter{ ParameterName="@Caccessory",Value=cn.Caccessory,DbType= DbType.String },
                new SqlParameter{ ParameterName="@Cstate",Value=1,DbType= DbType.Boolean },
                new SqlParameter{ ParameterName="@ComplainTime",Value=DateTime.Now,DbType= DbType.DateTime },
                new SqlParameter{ ParameterName="@CdisposePerson",Value="超级管理员",DbType= DbType.String },
        };
            return NewDBHelper.ExecuteNonQuery(strSql, CommandType.Text, para);
        }
        //添加投诉举报信息_匿名
        public int AddComplains_anonymity(Complain cn)
        {
            string strSql = $"insert into Complain values(@Cnumber,@Ctype,@Crole,@Cname,@Cphone,@WeChat,@Cemail,@ComplainPerson,@Caccessory,@Cstate,@ComplainTime,@CdisposePerson)";
            SqlParameter[] para = new SqlParameter[]
            {
                new SqlParameter{ ParameterName="@Cnumber",Value=cn.Cnumber,DbType= DbType.String },
                new SqlParameter{ ParameterName="@Ctype",Value=cn.Ctype,DbType= DbType.String },
                new SqlParameter{ ParameterName="@Crole",Value=cn.Crole,DbType= DbType.String },
                new SqlParameter{ ParameterName="@Cname",Value=cn.Cname,DbType= DbType.String },
                new SqlParameter{ ParameterName="@Cphone",Value=cn.Cphone,DbType= DbType.String },
                new SqlParameter{ ParameterName="@WeChat",Value=cn.WeChat,DbType= DbType.String },
                new SqlParameter{ ParameterName="@Cemail",Value=cn.Cemail,DbType= DbType.String },
                new SqlParameter{ ParameterName="@ComplainPerson",Value=cn.ComplainPerson,DbType= DbType.String },
                new SqlParameter{ ParameterName="@Caccessory",Value=cn.Caccessory,DbType= DbType.String },
                new SqlParameter{ ParameterName="@Cstate",Value=cn.Cstate,DbType= DbType.Boolean },
                new SqlParameter{ ParameterName="@ComplainTime",Value=cn.ComplainTime,DbType= DbType.DateTime },
                new SqlParameter{ ParameterName="@CdisposePerson",Value=cn.CdisposePerson,DbType= DbType.String },
        };
            return NewDBHelper.ExecuteNonQuery(strSql, CommandType.Text, para);
        }
    }
}
