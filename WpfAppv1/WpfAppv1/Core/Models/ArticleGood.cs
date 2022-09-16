using System;
using System.Collections.Generic;

namespace WpfAppv1.Models
{
    public partial class ArticleGood
    {
        public Guid Id { get; set; }
        public decimal Quantity { get; set; }
        public DateTime ValidFrom { get; set; }
        public DateTime ValidUntil { get; set; }
        public Guid? ArticleId { get; set; }
        public Guid? GoodId { get; set; }

        public virtual Good? Good { get; set; }
    }
}
