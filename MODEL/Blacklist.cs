using System;
using System.Collections.Generic;
using System.Text;

namespace MODEL
{
    //黑名单
    public class Blacklist
    {
        public int Bid { get; set; }//序号
        public string Btype { get; set; }//违纪类别
        public string Bunit { get; set; }//违纪单位
        public string BpapersNumber { get; set; }//证件号
        public string Bmatter { get; set; }//违纪事项
        public bool Bstate { get; set; }//状态
        public DateTime BUpdateTime { get; set; }//更新时间
        public string PubLishPerson { get; set; }//发布人
    }
}
