using System;
using System.Collections.Generic;

namespace WpfAppv1.Models
{
    public partial class Sector
    {
        public Sector()
        {
            Tables = new HashSet<Table>();
        }

        public Guid Id { get; set; }
        public string? Name { get; set; }
        public bool Deleted { get; set; }
        public int Order { get; set; }

        public virtual ICollection<Table> Tables { get; set; }
    }
}
