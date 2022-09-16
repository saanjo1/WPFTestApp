using System;
using System.Collections.Generic;

namespace WpfAppv1.Models
{
    public partial class MeasureUnit
    {
        public MeasureUnit()
        {
            Goods = new HashSet<Good>();
        }

        public Guid Id { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Good> Goods { get; set; }
    }
}
