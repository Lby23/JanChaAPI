using System;
using System.Collections.Generic;
using System.Text;

namespace MODEL
{
    //招聘管理表
    class Recruit
    {
        public int Rid { get; set; }//序号
        public string Rtype { get; set; }//种类/类别
        public string Rposition { get; set; }//职位
        public string RpositionDescride { get; set; }//职位描述
        public string Rlocation { get; set; }//地址
        public string Rcompany { get; set; }//公司
        public bool Rstate { get; set; }//状态
        public DateTime? Rtime { get; set; }//发布时间
        public string Rperson { get; set; }//发布人
    }
}
