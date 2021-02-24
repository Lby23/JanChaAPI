using System;
using System.Collections.Generic;
using System.Text;

namespace MODEL
{
    public partial class Folder
    {
        public Folder()
        {
            Articles = new HashSet<Article>();
            FolderImgs = new HashSet<FolderImg>();
        }

        public int Id { get; set; }
        public int? ParentId { get; set; }
        public string Name { get; set; }
        public string Key { get; set; }
        public string Path { get; set; }
        public int? Sort { get; set; }
        public int? Status { get; set; }
        public int? Type { get; set; }
        public string JumpUrl { get; set; }
        public string Content { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
        public virtual ICollection<FolderImg> FolderImgs { get; set; }
    }
}
