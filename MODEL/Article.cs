using System;
using System.Collections.Generic;
using System.Text;

namespace MODEL
{
    public partial class Article
    {
        public int Id { get; set; }
        public int? FolderId { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public int? Sort { get; set; }
        public int? Status { get; set; }
        public int? IsUp { get; set; }
        public int? IsComment { get; set; }
        public int? IsRecommend { get; set; }
        public int? ApproveStatus { get; set; }
        public DateTime? CreateTime { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public int? Type { get; set; }
        public string JumpUrl { get; set; }
        public string Image { get; set; }
        public string CreatePeople { get; set; }

        public virtual Folder Folder { get; set; }
    }
}
