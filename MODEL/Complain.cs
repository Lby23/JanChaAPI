using System;
using System.Collections.Generic;
using System.Text;

namespace MODEL
{
    //投诉管理表
    class Complain
    {
        public int Cid { get; set; }//序号
        public string Cnumber { get; set; }//编号; 
        public string Ctype { get; set; }  //投诉类型;
        public string Crole { get; set; }  //身份信息;
        public string Cname { get; set; }  //姓名;
        public string Cphone { get; set; } //电话;
        public string WeChat { get; set; } //微信;
        public string Cemail { get; set; } //邮箱;
        public string ComplainPerson { get; set; }//投诉人IP
        public string Caccessory { get; set; }//是否有附件
        public bool Cstate { get; set; }//状态
        public DateTime? ComplainTime { get; set; }//投诉时间
        public string CdisposePerson { get; set; }//处理人
    }
}
