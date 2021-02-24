using System;
using System.Collections.Generic;
using System.Text;

namespace MODEL
{
    public class Topic   //问题表
    {
        public int TopicId { get; set; }      //题目主键
        public string Choice  { get; set; }   //多选或单选
        public string Issue   { get; set; }   //-问题名
        public int Toid { get; set; }         //问题表外键关联选项表
    }
}
