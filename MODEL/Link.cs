using System;
using System.Collections.Generic;
using System.Text;

namespace MODEL
{
    public partial class Link    //相关链接表
    {
        public int Lid { get; set; }                 //链接主键
        public string Lname { get; set; }           //名称
        public string URL { get; set; }              //URL
        public string Ltype { get; set; }            //类型
        public int Sale { get; set; }              //是否显示
        public string Zd { get; set; }               //站点
        public string Remark { get; set; }           //备注
    }
}
