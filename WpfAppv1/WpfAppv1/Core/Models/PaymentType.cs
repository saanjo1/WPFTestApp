using System;
using System.Collections.Generic;

namespace WpfAppv1.Models
{
    public partial class PaymentType
    {
        public PaymentType()
        {
            Invoices = new HashSet<Invoice>();
        }

        public Guid Id { get; set; }
        public int Order { get; set; }
        public string? Name { get; set; }

        public virtual ICollection<Invoice> Invoices { get; set; }
    }
}
