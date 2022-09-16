﻿using System;
using System.Collections.Generic;

namespace WpfAppv1.Models
{
    public partial class InventoryDocument
    {
        public InventoryDocument()
        {
            InventoryItemBases = new HashSet<InventoryItemBasis>();
            InverseSourceInvoice = new HashSet<InventoryDocument>();
        }

        public Guid Id { get; set; }
        public DateTime Created { get; set; }
        public int Order { get; set; }
        public Guid? StorageId { get; set; }
        public Guid? SupplierId { get; set; }
        public bool IsActivated { get; set; }
        public bool IsDeleted { get; set; }
        public int Type { get; set; }
        public Guid? SourceInvoiceId { get; set; }

        public virtual InventoryDocument? SourceInvoice { get; set; }
        public virtual Storage? Storage { get; set; }
        public virtual Supplier? Supplier { get; set; }
        public virtual ICollection<InventoryItemBasis> InventoryItemBases { get; set; }
        public virtual ICollection<InventoryDocument> InverseSourceInvoice { get; set; }
    }
}
