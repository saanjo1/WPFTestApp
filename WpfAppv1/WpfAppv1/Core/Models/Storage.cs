using System;
using System.Collections.Generic;

namespace WpfAppv1.Models
{
    public partial class Storage
    {
        public Storage()
        {
            Categories = new HashSet<Category>();
            InventoryDocuments = new HashSet<InventoryDocument>();
            InventoryItemBases = new HashSet<InventoryItemBasis>();
            SubCategories = new HashSet<SubCategory>();
        }

        public Guid Id { get; set; }
        public string? Name { get; set; }
        public bool Deleted { get; set; }

        public virtual ICollection<Category> Categories { get; set; }
        public virtual ICollection<InventoryDocument> InventoryDocuments { get; set; }
        public virtual ICollection<InventoryItemBasis> InventoryItemBases { get; set; }
        public virtual ICollection<SubCategory> SubCategories { get; set; }
    }
}
