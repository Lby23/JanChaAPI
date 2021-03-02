 using System;
using System.Collections.Generic;
using System.Text;
using MODEL;

namespace DAL
{
    //黑名单
    public class BlackListDAL
    {
        //获取 查看 查询 黑名单表信息
        public List<Blacklist> GetBlacklists(string BUnit = null)
        {
            string strSql = $"select * from Blacklist where 1=1";
            if (BUnit != null)
            {
                strSql += $" and Bunit='{BUnit}'";
            }
            return NewDBHelper.GetList<Blacklist>(strSql);
        } 
        //添加黑名单信息
        public int AddBlacklist(Blacklist bl)
        {
            string strSql = $"insert into Blacklist values('{bl.Btype}','{bl.Bunit}','{bl.BpapersNumber}','{bl.Bmatter}','{bl.Bstate}','{bl.BUpdateTime}','{bl.PubLishPerson}')";
            return NewDBHelper.ExecuteNonQuery(strSql);
        }
        //删除黑名单信息
        public int DelBlacklist(int Bid)
        {
            string strSql = $"delete from Blacklist where Bid={Bid}";
            return NewDBHelper.ExecuteNonQuery(strSql);
        }
        //修改黑名单
        public int UpdateBlacklist(Blacklist bl)
        {
            string strSql = $"update Blacklist set Btype='{bl.Btype}',Bunit='{bl.Bunit}',BpapersNumber='{bl.BpapersNumber}',Bmatter='{bl.Bmatter}',Bstate='{bl.Bstate}',BUpdateTime='{bl.BUpdateTime}',PubLishPerson='{bl.PubLishPerson}' where Bid='{bl.Bid}'";
            return NewDBHelper.ExecuteNonQuery(strSql);
        }
    }
}
