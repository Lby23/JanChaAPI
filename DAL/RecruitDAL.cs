using MODEL;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    //招聘管理
    public class RecruitDAL
    {
        public List<Recruit> GetRecruits(string RPosition)
        {
            string strSql = $"select * from Recruit where 1=1";
            if (RPosition != null)
            {
                strSql += $" and RPosition='{RPosition}'";
            }
            return NewDBHelper.GetList<Recruit>(strSql);
        }
        public int AddRecruits(Recruit rc)
        {
            string strSql = $"insert into Recruit values('{rc.Rtype}','{rc.Rposition}','{rc.RpositionDescride}','{rc.Rlocation}','{rc.Rcompany}','{rc.Rstate}','{rc.Rtime}','{rc.Rperson}')";
            return NewDBHelper.ExecuteNonQuery(strSql);
        }
        public int DeleteRecruits(int RId)
        {
            string strSql = $"delete from Recruit where RId={RId}";
            return NewDBHelper.ExecuteNonQuery(strSql);
        }
        public int UpdateRecruits(Recruit rc)
        {
            string strSql = $"update Recruit set RType='{rc.Rtype}',RPosition='{rc.Rposition}',RPositionDescride='{rc.RpositionDescride}',RLocation='{rc.Rlocation}',RCompany='{rc.Rcompany}',RState='{rc.Rstate}',RTime='{rc.Rtime}',RPerson='{rc.Rperson}' where RId='{rc.Rid}'";
            return NewDBHelper.ExecuteNonQuery(strSql);
        }
    }
}
