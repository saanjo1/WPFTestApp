using System;
using System.Collections.Generic;

namespace WpfAppv1.Models
{
    public partial class TaxArticle
    {
        public Guid TaxId { get; set; }
        public Guid ArticleId { get; set; }

        public virtual Taxis Tax { get; set; } = null!;
    }
}
