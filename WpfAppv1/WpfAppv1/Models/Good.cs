using System;
using System.Collections.Generic;

namespace WpfAppv1.Models
{
    public partial class Good
    {
        public Good()
        {
            ArticleGoods = new HashSet<ArticleGood>();
            InventoryItemBases = new HashSet<InventoryItemBasis>();
        }

        public Guid Id { get; set; }
        public string? Name { get; set; }
        public Guid? UnitId { get; set; }
        public decimal LatestPrice { get; set; }
        public decimal? Volumen { get; set; }
        public decimal? Refuse { get; set; }

        public virtual MeasureUnit? Unit { get; set; }
        public virtual ICollection<ArticleGood> ArticleGoods { get; set; }
        public virtual ICollection<InventoryItemBasis> InventoryItemBases { get; set; }
    }
}
