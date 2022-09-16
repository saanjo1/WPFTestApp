using System;
using System.Collections.Generic;

namespace WpfAppv1.Models
{
    public partial class SubCategory
    {
        public SubCategory()
        {
            Articles = new HashSet<Article>();
            Novis = new HashSet<Novi>();
        }

        public Guid Id { get; set; }
        public int Order { get; set; }
        public string? Printer { get; set; }
        public string? Name { get; set; }
        public bool Deleted { get; set; }
        public Guid? StorageId { get; set; }
        public Guid? CategoryId { get; set; }
        public string? Tag { get; set; }
        public string? ExtraPrinter1 { get; set; }
        public string? ExtraPrinter2 { get; set; }

        public virtual Category? Category { get; set; }
        public virtual Storage? Storage { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
        public virtual ICollection<Novi> Novis { get; set; }
    }
}
