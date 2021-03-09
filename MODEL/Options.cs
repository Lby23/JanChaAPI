using System;
using System.Collections.Generic;
using System.Text;

namespace MODEL
{
    public partial class Options  //选项表
    {
        public int Oid   { get; set; }    //主键
        public string Oname { get; set; } //选项名

        public int Otid { get; set; }


        public int TopicId { get; set; }      //题目主键
        public string Choice { get; set; }   //多选或单选
        public string Issue { get; set; }   //-问题名

        public int QuesId { get; set; }//主键
    }
}
