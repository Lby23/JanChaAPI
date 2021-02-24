using System;
using System.Collections.Generic;
using System.Text;

namespace MODEL
{
    public partial class FolderImg
    {
        public int Id { get; set; }
        public int? FolderId { get; set; }
        public string Name { get; set; }
        public string Countnt { get; set; }
        public int? Sort { get; set; }
        public int? Status { get; set; }
        public string Img { get; set; }
        public string JumpUrl { get; set; }
        public DateTime? CreateTime { get; set; }

        public virtual Folder Folder { get; set; }
    }
}
