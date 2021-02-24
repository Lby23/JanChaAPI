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
        public List<Blacklist> GetBlacklists(string BUnit)
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
            string strSql = $"insert into Blacklist values('{bl.Bid}','{bl.Btype}','{bl.Bunit}','{bl.BpapersNumber}','{bl.Bmatter}','{bl.Bstate}','{bl.BUpdateTime}','{bl.PubLishPerson}')";
            return NewDBHelper.ExecuteNonQuery(strSql);
        }
        //
    }
}
