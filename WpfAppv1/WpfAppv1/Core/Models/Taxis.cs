using System;
using System.Collections.Generic;

namespace WpfAppv1.Models
{
    public partial class Taxis
    {
        public Taxis()
        {
            TaxArticles = new HashSet<TaxArticle>();
            Rules = new HashSet<Rule>();
        }

        public Guid Id { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidTo { get; set; }
        public string? Name { get; set; }
        public decimal Value { get; set; }
        public bool IsDeleted { get; set; }
        public string? Description { get; set; }

        public virtual ICollection<TaxArticle> TaxArticles { get; set; }

        public virtual ICollection<Rule> Rules { get; set; }
    }
}
