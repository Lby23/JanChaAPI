using System;
using System.Collections.Generic;
using System.Text;
using MODEL;

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
        //添加表信息
        public int AddComplains(Complain cn)
        {
            string strSql = $"insert into Complain values('{cn.Cnumber}','{cn.Ctype}','{cn.Crole}','{cn.Cname}','{cn.Cphone}','{cn.WeChat}','{cn.Cemail}','{cn.ComplainPerson}','{cn.Caccessory}','{cn.Cstate}','{cn.ComplainTime}','{cn.CdisposePerson}')";
            return NewDBHelper.ExecuteNonQuery(strSql);
        }
        //删除表信息
        public int DelComplains(int CId)
        {
            string strSql = $"delete from Complain where CId={CId}";
            return NewDBHelper.ExecuteNonQuery(strSql);
        }
        //修改表信息
        public int UpdateComplains(Complain cn)
        {
            string strSql = $"update Complain set CNumber='{cn.Cnumber}',CType='{cn.Ctype}',CRole='{cn.Crole}',CName='{cn.Cname}',CPhone='{cn.Cphone}',WeChat='{cn.WeChat}',Cemail='{cn.Cemail}',ComplainPerson='{cn.ComplainPerson}',Caccessory='{cn.Caccessory}',Cstate='{cn.Cstate}',ComplainTime='{cn.ComplainTime}',CdisposePerson='{cn.CdisposePerson}' where CId='{cn.Cid}'";
            return NewDBHelper.ExecuteNonQuery(strSql);
        }
    }
}
