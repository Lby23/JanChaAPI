using System;
using System.Collections.Generic;
using System.Text;

namespace MODEL
{
    public partial class Questionnaire //问卷表
    {
        public int QuesId       { get; set; }//主键
        public string Title        { get; set; }//问卷标题
        public string Sno          { get; set; }//问卷编号
        public int Qsale        { get; set; }//问卷状态
        public int Snum         { get; set; }//回收数量
        public DateTime CreateTime   { get; set; }//创建时间
        public string CreatePeople { get; set; }//创建人
        public string BeginMs      { get; set; }//开始描述
        public string EndMs        { get; set; }//结束描述
    }
}
