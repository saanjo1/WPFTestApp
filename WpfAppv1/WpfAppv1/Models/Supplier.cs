using System;
using System.Collections.Generic;

namespace WpfAppv1.Models
{
    public partial class Supplier
    {
        public Supplier()
        {
            InventoryDocuments = new HashSet<InventoryDocument>();
        }

        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? VatNumber { get; set; }
        public bool IsDeleted { get; set; }
        public string? Address { get; set; }

        public virtual ICollection<InventoryDocument> InventoryDocuments { get; set; }
    }
}
